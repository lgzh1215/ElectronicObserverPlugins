using BrowserLib;
using ElectronicObserver.Utility.Storage;
using ElectronicObserver.Window;
using ElectronicObserver.Window.Plugins;
using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Forms;

namespace TrayIconKai
{
    public class Plugin : ServerPlugin
    {
        private readonly string ConfigFile = Application.StartupPath + @"\Settings\TrayIconKai.xml";

        private NotifyIcon notifyIcon;
        private FormMain mainForm;

        private FormWindowState oldWindowState;
        private bool oldMuteState = true;

        private HotKeyRegister hotKeyToRegister;

        public Config Config { get; private set; }

        public override string MenuTitle
        {
            get { return "托盘图标改"; }
        }

        public override string Version
        {
            get { return "1.0.0.2"; }
        }

        public override PluginSettingControl GetSettings()
        {
            return new Settings(this);
        }

        public override bool RunService(FormMain main)
        {
            mainForm = main;
            Config blankConfig = new Config();
            //妈个鸡！为什么这个Load不是静态方法！
            Config config = (Config)blankConfig.Load(ConfigFile);
            if (config != null)
                UpdateConfig(config);
            else
                UpdateConfig(blankConfig);

            // 最小化事件
            oldWindowState = main.WindowState;
            main.SizeChanged += Main_SizeChanged;
            main.FormClosed += Main_FormClosed;

            return true;
        }

        public void UpdateConfig(Config newConfig)
        {
            Config = newConfig;

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
            if (notifyIcon == null)
            {
                notifyIcon = new NotifyIcon();
                notifyIcon.Icon = mainForm.Icon;
                notifyIcon.Text = mainForm.Text;
                notifyIcon.Click += NotifyIcon_Click;
                notifyIcon.Visible = true;
            }
        }

        private void DestroyTrayIcon()
        {
            if (notifyIcon != null)
            {
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
                notifyIcon = null;
            }
        }

        private void RegisterBossKey()
        {
            if (HotKeyRegister.IsCombineKey(Config.RegisterModifiers, Config.RegisterKey))
            {
                if (hotKeyToRegister != null)
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
        }

        private void Mute()
        {
            //如果已经静音了就不管了！
            BrowserConfiguration config = mainForm.fBrowser.Configuration;
            if (!config.IsMute)
            {
                oldMuteState = false;
                config.IsMute = true;
                mainForm.fBrowser.ConfigurationUpdated(config);
            }
        }

        private void UnMute()
        {
            //如果原来不是静音则恢复！
            if (!oldMuteState)
            {
                oldMuteState = true;
                BrowserConfiguration config = mainForm.fBrowser.Configuration;
                config.IsMute = false;
                mainForm.fBrowser.ConfigurationUpdated(config);
            }
        }

        private void BossKeyPressed(object sender, EventArgs e)
        {
            bool visible = mainForm.Visible;
            if (visible)
            {
                //BOSS IS COMING!！!
                HideWindow(); 
                //不使用全局热键时不能隐藏托盘图标
                if (Config.HideTrayIcon && Config.GlobalBossKey && notifyIcon != null) 
                    notifyIcon.Visible = false;
                if (Config.MuteWhenBossCome)
                    Mute();
            }
            else
            {
                //老板吔屎啦！!！
                ShowWindow();
                if (notifyIcon != null)
                    notifyIcon.Visible = true;
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
            if (Config.HideWhenClickTrayIcon)
            {
                if (mainForm.Visible)
                {
                    //点击托盘图标隐藏窗口
                    HideWindow();
                }
                else
                {
                    //显示由于点击托盘图标隐藏的窗口
                    ShowWindow();
                }
            }
            else if (!mainForm.Visible)
            {
                //显示由于最小化或老板键隐藏的窗口
                ShowWindow();
                UnMute();
            }
        }
    }

    [DataContract(Name = "TrayIconKai")]
    public class Config : DataStorage
    {
        public override void Initialize()
        {
            EnableTrayIcon = true;
            HideWhenClickTrayIcon = true;
            GlobalBossKey = true;
            HideTrayIcon = true;
            MuteWhenBossCome = true;
            RegisterKey = Keys.None;
            RegisterModifiers = KeyModifiers.None;
        }

        [DataMember]
        public bool EnableTrayIcon { get; set; }
        [DataMember]
        public bool HideWhenClickTrayIcon { get; set; }
        [DataMember]
        public bool HideWhenMinimized { get; set; }

        [DataMember]
        public bool EnableBossKey { get; set; }
        [DataMember]
        public bool GlobalBossKey { get; set; }
        [DataMember]
        public bool HideTrayIcon { get; set; }
        [DataMember]
        public bool MuteWhenBossCome { get; set; }

        [DataMember]
        public Keys RegisterKey { get; set; }
        [DataMember]
        public KeyModifiers RegisterModifiers { get; set; }
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

        public static KeyModifiers GetModifiers(Keys keyData, out Keys key)
        {
            key = keyData;
            KeyModifiers modifers = KeyModifiers.None;
            // Check whether the keydata contains the CTRL modifier key.
            if ((keyData & Keys.Control) == Keys.Control)
            {
                modifers |= KeyModifiers.Control;
                key = keyData ^ Keys.Control;
            }
            // Check whether the keydata contains the SHIFT modifier key.
            if ((keyData & Keys.Shift) == Keys.Shift)
            {
                modifers |= KeyModifiers.Shift;
                key = key ^ Keys.Shift;
            }
            // Check whether the keydata contains the ALT modifier key.
            if ((keyData & Keys.Alt) == Keys.Alt)
            {
                modifers |= KeyModifiers.Alt;
                key = key ^ Keys.Alt;
            }
            // Check whether a key other than SHIFT, CTRL or ALT (Menu) is pressed.
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
        private bool oldState;

        public override event EventHandler HotKeyPressed;

        public Form Form { get; private set; }

        public LocalHotKeyRegister(Form form, KeyModifiers modifiers, Keys key) : base(modifiers, key)
        {
            Form = form;
            RegisterHotKey();
        }

        private void RegisterHotKey()
        {
            oldState = Form.KeyPreview;
            Form.KeyPreview = true;
            Form.KeyDown += Form_KeyDown;
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (HotKeyPressed != null && e.Modifiers != Keys.None)
            {
                Keys key = Keys.None;
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
                    Form.KeyPreview = oldState;
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

        public IntPtr Handle { get; private set; }
        public int ID { get; private set; }

        public override event EventHandler HotKeyPressed;

        public GlobalHotKeyRegister(IntPtr handle, int id, KeyModifiers modifiers, Keys key) : base(modifiers, key)
        {
            Handle = handle;
            ID = id;
            RegisterHotKey();

            Application.AddMessageFilter(this);
        }

        private void RegisterHotKey()
        {
            bool isKeyRegisterd = RegisterHotKey(Handle, ID, Modifiers, Key);
            if (!isKeyRegisterd)
            {
                //热键被占用了！试图解除以前注册的热键！
                UnregisterHotKey(IntPtr.Zero, ID);
                //再试一次！
                isKeyRegisterd = RegisterHotKey(Handle, ID, Modifiers, Key);
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
                && m.HWnd == Handle
                && m.WParam == (IntPtr)ID
                && HotKeyPressed != null)
            {
                HotKeyPressed(this, EventArgs.Empty);
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
                    UnregisterHotKey(Handle, ID);
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
}