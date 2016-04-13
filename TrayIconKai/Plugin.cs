﻿using BrowserLib;
using CoreAudioApi;
using ElectronicObserver.Utility.Storage;
using ElectronicObserver.Window;
using ElectronicObserver.Window.Plugins;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Forms;

namespace TrayIconKai
{
    public class Plugin : ServerPlugin
    {
        private readonly string ConfigFile = Application.StartupPath + @"\Settings\TrayIconKai.xml";

        private NotifyIcon trayIcon;
        private FormMain mainForm;

        /// <summary>
        /// 记录隐藏窗口前是最大化还是通常状态，显示窗口时还原
        /// </summary>
        private FormWindowState oldWindowState;
        /// <summary>
        /// <para>true：插件没有改动音量，或者浏览器本来就是静音</para>
        /// <para>false：插件将浏览器改成了静音</para>
        /// </summary>
        private bool oldMuteState = true;

        private HotKeyRegister hotKeyToRegister;
        private VolumeManager volumeManager;

        internal Config Config { get; private set; }

        public override string MenuTitle
        {
            get { return "托盘图标改"; }
        }

        public override string Version
        {
            get { return "1.0.1.0"; }
        }

        public override PluginSettingControl GetSettings()
        {
            return new Settings(this);
        }

        public override bool RunService(FormMain main)
        {
            mainForm = main;
            oldWindowState = main.WindowState;

            //载入配置
            Config config = new Config();
            if (System.IO.File.Exists(ConfigFile))
            {
                Config loadConfig = (Config)config.Load(ConfigFile);
                if (loadConfig != null)
                    config = loadConfig;
            }
            UpdateConfig(config);

            main.SizeChanged += Main_SizeChanged;
            main.FormClosed += Main_FormClosed;

            return true;
        }

        public Config GetConfig()
        {
            return new Config
            {
                EnableTrayIcon = Config.EnableTrayIcon,
                HideWhenClickTrayIcon = Config.HideWhenClickTrayIcon,
                HideWhenMinimized = Config.HideWhenMinimized,

                EnableBossKey = Config.EnableBossKey,
                GlobalBossKey = Config.GlobalBossKey,
                HideTrayIconWhenBossCome = Config.HideTrayIconWhenBossCome,
                MuteWhenBossCome = Config.MuteWhenBossCome,

                RegisterModifiers = Config.RegisterModifiers,
                RegisterKey = Config.RegisterKey,
                ActivateWhenShow = Config.ActivateWhenShow,
            };
        }

        public void UpdateConfig(Config newConfig)
        {
            Config.EnableTrayIcon = newConfig.EnableTrayIcon;
            Config.HideWhenClickTrayIcon = newConfig.HideWhenClickTrayIcon;
            Config.HideWhenMinimized = newConfig.HideWhenMinimized;

            Config.EnableBossKey = newConfig.EnableBossKey;
            Config.GlobalBossKey = newConfig.GlobalBossKey;
            Config.HideTrayIconWhenBossCome = newConfig.HideTrayIconWhenBossCome;
            Config.MuteWhenBossCome = newConfig.MuteWhenBossCome;

            Config.RegisterModifiers = newConfig.RegisterModifiers;
            Config.RegisterKey = newConfig.RegisterKey;
            Config.ActivateWhenShow = newConfig.ActivateWhenShow;

            if (Config.EnableTrayIcon)
                CreateTrayIcon();
            else DestroyTrayIcon();

            if (Config.EnableBossKey)
                RegisterBossKey();
            else UnregisterBossKey();
        }

        public void SaveConfig()
        {
            Config.Save(ConfigFile);
        }

        private void CreateTrayIcon()
        {
            if (trayIcon == null)
            {
                trayIcon = new NotifyIcon();
                trayIcon.Icon = mainForm.Icon;
                trayIcon.Text = mainForm.Text;
                trayIcon.Click += NotifyIcon_Click;
                trayIcon.Visible = true;
            }
        }

        private void DestroyTrayIcon()
        {
            if (trayIcon != null)
            {
                trayIcon.Visible = false;
                trayIcon.Dispose();
                trayIcon = null;
            }
        }

        private void HideTrayIcon()
        {
            if (trayIcon != null)
                trayIcon.Visible = false;
        }

        private void ShowTrayIcon()
        {
            if (trayIcon != null)
                trayIcon.Visible = true;
        }

        private void RegisterBossKey()
        {
            if (HotKeyRegister.IsCombineKey(Config.RegisterModifiers, Config.RegisterKey))
            {
                UnregisterBossKey();
                if (Config.GlobalBossKey)
                    hotKeyToRegister = new GlobalHotKeyRegister(mainForm.Handle, 100,
                        Config.RegisterModifiers, Config.RegisterKey);
                else
                    hotKeyToRegister = new LocalHotKeyRegister(mainForm,
                        Config.RegisterModifiers, Config.RegisterKey);
                hotKeyToRegister.HotKeyPressed += new EventHandler(BossKeyPressed);
            }
        }

        private void UnregisterBossKey()
        {
            if (hotKeyToRegister != null)
            {
                hotKeyToRegister.Dispose();
                hotKeyToRegister = null;
            }
        }

        private void HideWindow()
        {
            mainForm.Visible = false;
        }

        private void ShowWindow()
        {
            mainForm.Visible = true;
            mainForm.WindowState = oldWindowState;
            if (Config.ActivateWhenShow)
                mainForm.Activate();
        }

        private VolumeManager GetVolumeManager()
        {
            if (volumeManager == null)
            {
                //获得浏览器进程的窗口句柄
                IntPtr browserHwnd = FindWindowEx(mainForm.Browser.Handle, IntPtr.Zero, null, null);
                if (browserHwnd == IntPtr.Zero) return null;
                //获得浏览器进程的PID
                uint processID;
                GetWindowThreadProcessId(browserHwnd, out processID);
                if (processID == 0U) return null;
                volumeManager = new VolumeManager(processID);
            }
            return volumeManager;
        }

        private void Mute()
        {
            try
            {
                VolumeManager volume = GetVolumeManager();
                if (volume != null && !volume.IsMute)
                {
                    volume.IsMute = true;
                    oldMuteState = false;
                }
            }
            catch { }//浏览器已打开但未载入网页
        }

        private void UnMute()
        {
            try
            {
                if (!oldMuteState)
                {
                    VolumeManager volume = GetVolumeManager();
                    if (volume != null && volume.IsMute)
                        volume.IsMute = false;
                    oldMuteState = true;
                }
            }
            catch { }//浏览器已打开但未载入网页
        }

        private void BossKeyPressed(object sender, EventArgs e)
        {
            if (mainForm.Visible)
            {
                //BOSS IS COMING!！!
                HideWindow();
                if (Config.GlobalBossKey)
                {
                    //使用全局热键时才能隐藏托盘图标
                    if (Config.HideTrayIconWhenBossCome)
                        HideTrayIcon();
                }
                else
                {
                    //非全局热键但是没启用托盘时，开启一个用于复原窗口的托盘图标
                    if (!Config.EnableTrayIcon)
                        CreateTrayIcon();
                }
                if (Config.MuteWhenBossCome)
                    Mute();
            }
            else
            {
                //老板吔屎啦！!！
                ShowWindow();
                ShowTrayIcon();
                UnMute();
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            DestroyTrayIcon();
            UnregisterBossKey();
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (mainForm.WindowState == FormWindowState.Minimized)
            {
                //最小化时隐藏窗口
                if (Config.EnableTrayIcon && Config.HideWhenMinimized)
                    HideWindow();
            }
            else
            {
                oldWindowState = mainForm.WindowState;
            }
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            if (mainForm.Visible)
            {
                if (Config.HideWhenClickTrayIcon)
                {
                    HideWindow();
                }
            }
            else
            {
                ShowWindow();
                //非全局热键但是没启用托盘时，开启一个一次性的托盘图标用于复原窗口
                if (!Config.EnableTrayIcon)
                    DestroyTrayIcon();
                //可能是老板键关闭的声音
                UnMute();
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hwnd, out uint ID);
    }

    [DataContract(Name = "TrayIconKai")]
    public class Config : DataStorage
    {
        public override void Initialize() { }

        /// <summary>
        /// 启用托盘图标
        /// </summary>
        [DataMember]
        public bool EnableTrayIcon { get; set; } = true;
        /// <summary>
        /// 点击托盘图标时隐藏窗口
        /// </summary>
        [DataMember]
        public bool HideWhenClickTrayIcon { get; set; } = true;
        /// <summary>
        /// 最小化时隐藏窗口到托盘
        /// </summary>
        [DataMember]
        public bool HideWhenMinimized { get; set; }

        /// <summary>
        /// 启用老板键
        /// </summary>
        [DataMember]
        public bool EnableBossKey { get; set; }
        /// <summary>
        /// 使用全局老板键
        /// </summary>
        [DataMember]
        public bool GlobalBossKey { get; set; } = true;
        /// <summary>
        /// 按下老板键时隐藏托盘图标
        /// </summary>
        [DataMember]
        public bool HideTrayIconWhenBossCome { get; set; } = true;
        /// <summary>
        /// 按下老板键时关闭声音
        /// </summary>
        [DataMember]
        public bool MuteWhenBossCome { get; set; } = true;

        /// <summary>
        /// 老板键
        /// </summary>
        [DataMember]
        public Keys RegisterKey { get; set; } = Keys.None;
        /// <summary>
        /// 老板键修饰符（Ctrl、Shift、Alt）
        /// </summary>
        [DataMember]
        public KeyModifiers RegisterModifiers { get; set; } = KeyModifiers.None;

        /// <summary>
        /// 恢复被隐藏的窗口时将其激活
        /// </summary>
        [DataMember]
        public bool ActivateWhenShow { get; set; }
    }

    internal abstract class HotKeyRegister : IDisposable
    {
        public virtual event EventHandler HotKeyPressed;
        public virtual KeyModifiers Modifiers { get; protected set; }
        public virtual Keys Key { get; protected set; }

        public HotKeyRegister(KeyModifiers modifiers, Keys key)
        {
            Modifiers = modifiers;
            Key = key;
        }

        public abstract void Dispose();

        /// <summary>
        /// 获得按下的修饰符和其他键
        /// </summary>
        public static KeyModifiers GetModifiers(Keys keyData, out Keys key)
        {
            key = keyData;
            KeyModifiers modifers = KeyModifiers.None;
            //检查是否按下了Ctrl修饰符
            if ((keyData & Keys.Control) == Keys.Control)
            {
                modifers |= KeyModifiers.Control;
                key = keyData ^ Keys.Control;
            }
            //检查是否按下了Shift修饰符
            if ((keyData & Keys.Shift) == Keys.Shift)
            {
                modifers |= KeyModifiers.Shift;
                key = key ^ Keys.Shift;
            }
            //检查是否按下了Alt修饰符
            if ((keyData & Keys.Alt) == Keys.Alt)
            {
                modifers |= KeyModifiers.Alt;
                key = key ^ Keys.Alt;
            }
            //检查是否按下了除了修饰符以外的其他键
            if (key == Keys.ShiftKey || key == Keys.ControlKey || key == Keys.Menu)
            {
                key = Keys.None;
            }
            return modifers;
        }

        /// <summary>
        /// 判断是否是组合键
        /// </summary>
        public static bool IsCombineKey(KeyModifiers modifiers, Keys key)
        {
            return modifiers != KeyModifiers.None && key != Keys.None;
        }
    }

    internal class LocalHotKeyRegister : HotKeyRegister
    {
        /// <summary>
        /// 记录注册快捷键前的Form.KeyPreview属性的状态，删除快捷键时还原
        /// </summary>
        private bool oldKeyPreviewState;

        public override event EventHandler HotKeyPressed;

        public Form Form { get; private set; }

        public LocalHotKeyRegister(Form form, KeyModifiers modifiers, Keys key) : base(modifiers, key)
        {
            Form = form;
            RegisterHotKey();
        }

        private void RegisterHotKey()
        {
            oldKeyPreviewState = Form.KeyPreview;
            Form.KeyPreview = true;
            Form.KeyDown += Form_KeyDown;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (HotKeyPressed != null && e.Modifiers != Keys.None)
            {
                Keys key;
                KeyModifiers modifiers = GetModifiers(e.KeyData, out key);
                if ((int)key == (int)Key && (int)modifiers == (int)Modifiers)
                {
                    e.Handled = true;
                    HotKeyPressed(this, EventArgs.Empty);
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Form.KeyPreview = oldKeyPreviewState;
                    Form.KeyDown -= Form_KeyDown;
                }
                disposedValue = true;
            }
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    internal class GlobalHotKeyRegister : HotKeyRegister, IMessageFilter
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id,
            KeyModifiers fsModifiers, Keys vk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int WM_HOTKEY = 0x0312;

        public IntPtr Hwnd { get; private set; }
        public int ID { get; private set; }

        public override event EventHandler HotKeyPressed;

        public GlobalHotKeyRegister(IntPtr hwnd, int id, KeyModifiers modifiers, Keys key) : base(modifiers, key)
        {
            Hwnd = hwnd;
            ID = id;
            RegisterHotKey();

            Application.AddMessageFilter(this);
        }

        private void RegisterHotKey()
        {
            bool isKeyRegisterd = RegisterHotKey(Hwnd, ID, Modifiers, Key);
            if (!isKeyRegisterd)
            {
                //热键被占用了！试图解除以前注册的热键！
                UnregisterHotKey(IntPtr.Zero, ID);
                //再试一次！
                isKeyRegisterd = RegisterHotKey(Hwnd, ID, Modifiers, Key);
                if (!isKeyRegisterd)
                {
                    //啊！该热键被其他程序占用了！
                    MessageBox.Show("老板键已被其他程序占用，请检查设置");
                }
            }
        }

        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_HOTKEY
                && m.HWnd == Hwnd
                && m.WParam == (IntPtr)ID
                && HotKeyPressed != null)
            {
                HotKeyPressed(this, EventArgs.Empty);
                //截断此信息
                return true;
            }
            return false;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Application.RemoveMessageFilter(this);
                    UnregisterHotKey(Hwnd, ID);
                }
                disposedValue = true;
            }
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    [Flags]
    public enum KeyModifiers
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
    }

    internal class VolumeManager
    {
        private const string ErrorMessageNotFound = "指定したプロセスIDの音量オブジェクトは存在しません。";

        public uint ProcessID { get; private set; }

        public VolumeManager(uint processID)
        {
            ProcessID = processID;
        }

        private SimpleAudioVolume simpleAudioVolume;

        private SimpleAudioVolume GetVolumeObject()
        {
            if (simpleAudioVolume == null)
            {
                var deviceEnumerator = new MMDeviceEnumerator();
                MMDevice devices;
                try
                {
                    devices = deviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
                }
                catch
                {
                    return null;
                }
                for (int i = 0; i < devices.AudioSessionManager.Sessions.Count; i++)
                {
                    var session = devices.AudioSessionManager.Sessions[i];
                    if (session.ProcessID == ProcessID)
                    {
                        simpleAudioVolume = session.SimpleAudioVolume;
                        break;
                    }
                }
            }
            return simpleAudioVolume;
        }

        private bool GetApplicationMute()
        {
            var volume = GetVolumeObject();
            if (volume == null)
                throw new ArgumentException(ErrorMessageNotFound);
            return volume.Mute;
        }

        private void SetApplicationMute(bool mute)
        {
            var volume = GetVolumeObject();
            if (volume == null)
                throw new ArgumentException(ErrorMessageNotFound);

            volume.Mute = mute;
        }

        public bool IsMute
        {
            get { return GetApplicationMute(); }
            set { SetApplicationMute(value); }
        }

        public bool ToggleMute()
        {
            bool mute = !GetApplicationMute();
            SetApplicationMute(mute);
            return mute;
        }
    }
}