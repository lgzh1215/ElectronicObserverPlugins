using CoreAudioApi;
using ElectronicObserver.Utility.Storage;
using ElectronicObserver.Window;
using ElectronicObserver.Window.Plugins;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Windows.Forms;

namespace BossKey
{
    public class BossKey : ServerPlugin
    {
        private readonly string ConfigFile = Application.StartupPath + @"\Settings\BossKey.xml";

        private FormMain formMain;

        private bool init = true;
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

        public override string MenuTitle { get { return "老板键"; } }

        public override string Version { get { return "1.0.0.0"; } }

        public override PluginSettingControl GetSettings()
        {
            if (init)
                return new Settings(this);
            else return null;
        }

        public override PluginUpdateInformation UpdateInformation
        {
            get
            {
                return new PluginUpdateInformation(PluginUpdateInformation.UpdateType.Auto)
                {
                    UpdateInformationURI = "http://lgzh1215.github.io/Files/BossKey/UpdateInfo.json",
                    PluginDownloadURI = "http://lgzh1215.github.io/Files/BossKey/BossKey.zip"
                };
            }
        }

        public override bool RunService(FormMain main)
        {
            foreach (var plugin in main.Plugins)
            {
                if (plugin.ToString().StartsWith("TrayIconKai"))
                {
                    init = false;
                    return false;
                }
            }

            formMain = main;

            //载入配置
            Config = new Config();
            if (System.IO.File.Exists(ConfigFile))
            {
                Config loadConfig = (Config)Config.Load(ConfigFile);
                if (loadConfig != null)
                    Config = loadConfig;
            }
            ApplyConfig();

            main.SizeChanged += Main_SizeChanged;
            main.FormClosed += Main_FormClosed;
            main.VisibleChanged += Main_VisibleChanged;
            return true;
        }

        public Config GetConfig()
        {
            return new Config
            {
                EnableBossKey = Config.EnableBossKey,
                MuteWhenBossCome = Config.MuteWhenBossCome,
                RegisterModifiers = Config.RegisterModifiers,
                RegisterKey = Config.RegisterKey,
            };
        }

        public void UpdateConfig(Config newConfig)
        {
            Config.EnableBossKey = newConfig.EnableBossKey;
            Config.MuteWhenBossCome = newConfig.MuteWhenBossCome;
            Config.RegisterModifiers = newConfig.RegisterModifiers;
            Config.RegisterKey = newConfig.RegisterKey;

            ApplyConfig();
        }

        public void ApplyConfig()
        {
            if (Config.EnableBossKey)
                RegisterBossKey();
            else UnregisterBossKey();
        }

        public void SaveConfig()
        {
            Config.Save(ConfigFile);
        }

        private void RegisterBossKey()
        {
            if (HotKeyRegister.IsCombineKey(Config.RegisterModifiers, Config.RegisterKey))
            {
                UnregisterBossKey();
                hotKeyToRegister = new HotKeyRegister(formMain.Handle, 100,
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
            formMain.Visible = false;
        }

        private void ShowWindow()
        {
            formMain.Visible = true;
            formMain.WindowState = oldWindowState;
            formMain.Activate();
        }

        private VolumeManager GetVolumeManager()
        {
            if (volumeManager == null)
            {
                //获得浏览器进程的窗口句柄
                IntPtr browserHwnd = NativeMethods.FindWindowEx(formMain.Browser.Handle, IntPtr.Zero, null, null);
                if (browserHwnd == IntPtr.Zero) return null;
                //获得浏览器进程的PID
                uint processID;
                NativeMethods.GetWindowThreadProcessId(browserHwnd, out processID);
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
            if (formMain.Visible)
            {
                //BOSS IS COMING!！!
                HideWindow();
                if (Config.MuteWhenBossCome)
                    Mute();
            }
            else
            {
                //老板吔屎啦！!！
                ShowWindow();
                //取消静音在Main_VisibleChanged()里
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnregisterBossKey();
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (formMain.WindowState != FormWindowState.Minimized)
            {
                oldWindowState = formMain.WindowState;
            }
        }

        private void Main_VisibleChanged(object sender, EventArgs e)
        {
            if (formMain.Visible) UnMute();
        }
    }

    [DataContract(Name = "BossKey")]
    public class Config : DataStorage
    {
        public override void Initialize() { }

        /// <summary>
        /// 启用老板键
        /// </summary>
        [DataMember]
        public bool EnableBossKey { get; set; }
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
    }

    internal class HotKeyRegister : IMessageFilter, IDisposable
    {
        private const int WM_HOTKEY = 0x0312;

        public IntPtr Hwnd { get; private set; }
        public int ID { get; private set; }
        public KeyModifiers Modifiers { get; protected set; }
        public Keys Key { get; protected set; }

        public event EventHandler HotKeyPressed;

        public HotKeyRegister(IntPtr hwnd, int id, KeyModifiers modifiers, Keys key)
        {
            Hwnd = hwnd;
            ID = id;
            Modifiers = modifiers;
            Key = key;
            RegisterHotKey();

            Application.AddMessageFilter(this);
        }

        private void RegisterHotKey()
        {
            bool isKeyRegisterd = NativeMethods.RegisterHotKey(Hwnd, ID, Modifiers, Key);
            if (!isKeyRegisterd)
            {
                //热键被占用了！试图解除以前注册的热键！
                NativeMethods.UnregisterHotKey(IntPtr.Zero, ID);
                //再试一次！
                isKeyRegisterd = NativeMethods.RegisterHotKey(Hwnd, ID, Modifiers, Key);
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

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Application.RemoveMessageFilter(this);
                    NativeMethods.UnregisterHotKey(Hwnd, ID);
                }
                disposedValue = true;
            }
        }

        public void Dispose()
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