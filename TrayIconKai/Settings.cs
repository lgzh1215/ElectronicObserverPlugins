using ElectronicObserver.Window.Plugins;
using System;
using System.Windows.Forms;

namespace TrayIconKai
{
    public partial class Settings : PluginSettingControl
    {
        private Plugin plugin;
        public Settings(Plugin plugin)
        {
            this.plugin = plugin;
            InitializeComponent();
        }

        private Keys registerKey = Keys.None;
        private KeyModifiers registerModifiers = KeyModifiers.None;

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //按退格键就可以清空数据啦！
            if (e.KeyCode == Keys.Back)
            {
                textBox.Text = "";
                registerKey = Keys.None;
                registerModifiers = KeyModifiers.None;
                return;
            }
            e.SuppressKeyPress = true;
            //没有修饰符也算热键？你特么在逗我！
            if (e.Modifiers != Keys.None)
            {
                Keys key = Keys.None;
                KeyModifiers modifiers = HotKeyRegister.GetModifiers(e.KeyData, out key);
                //只按了修饰符可不行！
                if (key != Keys.None)
                {
                    //输入有效！显示输入的热键！
                    registerKey = key;
                    registerModifiers = modifiers;
                    textBox.Text = string.Format("{0}+{1}",
                        registerModifiers, GetKeysString(registerKey));
                }
            }
        }

        private string GetKeysString(Keys key)
        {
            //对一些不好看的按键名做点处理！
            int keyValue = (int)key;
            if (48 <= keyValue && keyValue <= 57)    //0-9
            {
                return key.ToString().Substring(1);
            }
            else if (96 <= keyValue && keyValue <= 105)    //数字小键盘0-9
            {
                return "Num" + key.ToString().Substring(6);
            }
            else
                switch (keyValue)    //标点符号
                {
                    case (int)Keys.Oemtilde:
                        return "`";
                    case (int)Keys.Oemcomma:
                        return ",";
                    case (int)Keys.OemPeriod:
                        return ".";
                    case (int)Keys.OemQuestion:
                        return "/";
                    case (int)Keys.OemSemicolon:
                        return ";";
                    case (int)Keys.OemQuotes:
                        return "\"";
                    case (int)Keys.OemOpenBrackets:
                        return "[";
                    case (int)Keys.OemCloseBrackets:
                        return "]";
                    case (int)Keys.OemPipe:
                        return "\\";
                    case (int)Keys.OemMinus:
                        return "-";
                    case (int)Keys.Oemplus:
                        return "=";
                    //其他东西
                    default:
                        return key.ToString();
                }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Config config = plugin.Config;

            enableTrayIcon.Checked = config.EnableTrayIcon;
            hideWhenClickTrayIcon.Checked = config.HideWhenClickTrayIcon;
            hideWhenMinimized.Checked = config.HideWhenMinimized;

            enableBossKey.Checked = config.EnableBossKey;
            hideTrayIconWhenBossCome.Checked = config.HideTrayIconWhenBossCome;
            muteWhenBossCome.Checked = config.MuteWhenBossCome;

            registerKey = config.RegisterKey;
            registerModifiers = config.RegisterModifiers;

            activateWhenShow.Checked = config.ActivateWhenShow;

            //显示之前保存的热键！
            if (HotKeyRegister.IsCombineKey(registerModifiers, registerKey))
                textBox.Text = string.Format("{0}+{1}",
                            registerModifiers, GetKeysString(registerKey));
        }

        public override bool Save()
        {
            Config newConfig = new Config();

            newConfig.EnableTrayIcon = enableTrayIcon.Checked;
            newConfig.HideWhenClickTrayIcon = hideWhenClickTrayIcon.Checked;
            newConfig.HideWhenMinimized = hideWhenMinimized.Checked;

            newConfig.EnableBossKey = enableBossKey.Checked;
            newConfig.HideTrayIconWhenBossCome = hideTrayIconWhenBossCome.Checked;
            newConfig.MuteWhenBossCome = muteWhenBossCome.Checked;

            newConfig.RegisterKey = registerKey;
            newConfig.RegisterModifiers = registerModifiers;

            newConfig.ActivateWhenShow = activateWhenShow.Checked;

            plugin.UpdateConfig(newConfig);
            plugin.SaveConfig();
            return true;
        }
    }
}