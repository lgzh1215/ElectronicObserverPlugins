using ElectronicObserver.Utility.Storage;
using ElectronicObserver.Window.Plugins;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace ManualCounter
{
    public class ManualCounter : DockPlugin
    {
        public override string MenuTitle { get { return "手动计数器"; } }

        public override PluginSettingControl GetSettings() { return null; }

        public override string Version { get { return "1.0.0.0"; } }

        public override Image MenuIcon { get { return Resource.icon; } }

        public override PluginUpdateInformation UpdateInformation
        {
            get
            {
                return new PluginUpdateInformation(PluginUpdateInformation.UpdateType.Auto)
                {
                    UpdateInformationURI = "http://lgzh1215.github.io/Files/ManualCounter/UpdateInfo.json",
                    PluginDownloadURI = "http://lgzh1215.github.io/Files/ManualCounter/ManualCounter.zip"
                };
            }
        }

        private readonly static string ConfigFile = Application.StartupPath + @"\Settings\ManualCounter.xml";

        public static Config Config { get; private set; } = new Config();

        public static void Load()
        {
            if (File.Exists(ConfigFile))
            {
                Config load = (Config)Config.Load(ConfigFile);
                if (load != null) Config = load;
                else return;
            }
        }

        public static void Save()
        {
            Config.Save(ConfigFile);
        }

        public static bool IsLoaded { get; set; } = false;

        static ManualCounter() { Load(); IsLoaded = true; }
    }

    public class Counter
    {
        public Counter() { setResetDate(); }

        public string Content { get; set; } = "";

        private Frequency resetFrequency = Frequency.None;
        public Frequency ResetFrequency
        {
            get { return resetFrequency; }
            set
            {
                if (resetFrequency != value)
                {
                    resetFrequency = value;
                    setResetDate();
                }
            }
        }

        public uint CurrentValue { get; set; } = 0;

        public uint TotalValue { get; set; } = 0;

        public DateTime ResetDate { get; set; } = DateTime.Now;

        public bool ResetAlongWithQuests { get; set; } = false;

        public Color ProgressColor { get; set; } = ManualCounter.Config.DefaultColor;

        public double Progress
        {
            get { return TotalValue == 0 ? 0 : CurrentValue * 1.0 / TotalValue; }
        }

        public string ProgressText
        {
            get
            {
                string progressText = string.Format("{0:N0} / {1}", CurrentValue, TotalValue == 0 ? "∞" : TotalValue.ToString("N0"));
                if (TotalValue > 0)
                {
                    string percentText = "    " + string.Format("{0:P}", Progress);
                    progressText += percentText;
                }
                return progressText;
            }
        }

        public void Increase(bool autoReset = false)
        {
            if (TotalValue == 0)
            {
                CurrentValue++;
            }
            else
            {
                if (CurrentValue >= TotalValue)
                {
                    if (autoReset)
                    {
                        Reset();
                        return;
                    }
                }
                else
                {
                    CurrentValue++;
                }
            }

            //ManualCounter.Save();
        }

        public void Reset()
        {
            CurrentValue = 0;
            setResetDate();

            //ManualCounter.Save();
        }

        private void setResetDate()
        {
            if (!ManualCounter.IsLoaded) return;
            DateTime now = DateTime.Now;
            switch (resetFrequency)
            {
                case Frequency.Day:
                    if (ResetAlongWithQuests)
                        ResetDate = new DateTime(now.Year, now.Month, now.Hour > 2 ? now.Day : now.Day - 1, 3, 0, 0, 0);
                    else
                        ResetDate = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, 0);
                    break;
                case Frequency.Week:
                    if (ResetAlongWithQuests)
                        ResetDate = new DateTime(now.Year, now.Month, now.Hour > 2 ? now.Day : now.Day - 1, 3, 0, 0, 0) - TimeSpan.FromDays(getDayOfWeek(now) - 1);
                    else
                        ResetDate = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, 0) - TimeSpan.FromDays(getDayOfWeek(now) - 1);
                    break;
                case Frequency.Month:
                    if (ResetAlongWithQuests)
                        ResetDate = new DateTime(now.Year, now.Month, now.Hour > 2 ? now.Day : now.Day - 1, 3, 0, 0, 0) - TimeSpan.FromDays(now.Day - 1);
                    else
                        ResetDate = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, 0) - TimeSpan.FromDays(now.Day - 1);
                    break;
                case Frequency.Year:
                    if (ResetAlongWithQuests)
                        ResetDate = new DateTime(now.Year, now.Month, now.Hour > 2 ? now.Day : now.Day - 1, 3, 0, 0, 0) - TimeSpan.FromDays(now.DayOfYear - 1);
                    else
                        ResetDate = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, 0) - TimeSpan.FromDays(now.DayOfYear - 1);
                    break;
            }
        }

        private int getDayOfWeek(DateTime time)
        {
            switch (time.DayOfWeek)
            {
                default:
                case DayOfWeek.Monday:
                    return 1;
                case DayOfWeek.Tuesday:
                    return 2;
                case DayOfWeek.Wednesday:
                    return 3;
                case DayOfWeek.Thursday:
                    return 4;
                case DayOfWeek.Friday:
                    return 5;
                case DayOfWeek.Saturday:
                    return 6;
                case DayOfWeek.Sunday:
                    return 7; //就是因为这货才搞的这么复杂！
            }
        }
    }

    public class CounterHolder
    {
        private readonly static CounterHolder instance = new CounterHolder();
        public static CounterHolder Instance { get { return instance; } }

        private CounterHolder()
        {
            FrequencyName = new Dictionary<Frequency, string>();
            FrequencyName.Add(Frequency.None, "无");
            FrequencyName.Add(Frequency.Day, "每日");
            FrequencyName.Add(Frequency.Week, "每周");
            FrequencyName.Add(Frequency.Month, "每月");
            FrequencyName.Add(Frequency.Year, "每年");
        }

        public List<Counter> Counters
        {
            get { return ManualCounter.Config.Counters; }
            private set { ManualCounter.Config.Counters = value; }
        }

        public void AddCounter(Counter c)
        {
            Counters.Add(c);
        }

        public void RemoveCounter(Counter c)
        {
            Counters.Remove(c);
        }

        /// <summary>
        /// 重置计数器
        /// </summary>
        public void UpdateCounter()
        {
            DateTime now = DateTime.Now;
            foreach (Counter c in Counters)
            {
                if (c == null || c.ResetFrequency == Frequency.None) continue;
                switch (c.ResetFrequency)
                {
                    case Frequency.Day:
                        if (now - c.ResetDate >= TimeSpan.FromDays(1))
                            c.Reset();
                        break;
                    case Frequency.Week:
                        if (now - c.ResetDate >= TimeSpan.FromDays(7))
                            c.Reset();
                        break;
                    case Frequency.Month:
                        if (now - c.ResetDate >= TimeSpan.FromDays(DateTime.DaysInMonth(c.ResetDate.Year, c.ResetDate.Month)))
                            c.Reset();
                        break;
                    case Frequency.Year:
                        if (now - c.ResetDate >= TimeSpan.FromDays(DateTime.IsLeapYear(c.ResetDate.Year) ? 366 : 365))
                            c.Reset();
                        break;
                }
            }
        }

        public void UpdateCounter(Counter c)
        {
            DateTime now = DateTime.Now;
            if (c == null || c.ResetFrequency == Frequency.None) return;
            switch (c.ResetFrequency)
            {
                case Frequency.Day:
                    if (now - c.ResetDate >= TimeSpan.FromDays(1))
                        c.Reset();
                    break;
                case Frequency.Week:
                    if (now - c.ResetDate >= TimeSpan.FromDays(7))
                        c.Reset();
                    break;
                case Frequency.Month:
                    if (now - c.ResetDate >= TimeSpan.FromDays(DateTime.DaysInMonth(c.ResetDate.Year, c.ResetDate.Month)))
                        c.Reset();
                    break;
                case Frequency.Year:
                    if (now - c.ResetDate >= TimeSpan.FromDays(DateTime.IsLeapYear(c.ResetDate.Year) ? 366 : 365))
                        c.Reset();
                    break;
            }
        }

        public Dictionary<Frequency, string> FrequencyName { get; private set; }
    }

    public enum Frequency { None, Day, Week, Month, Year }

    [DataContract(Name = "ManualCounter")]
    public class Config : DataStorage
    {
        public override void Initialize()
        {
            Counters = new List<Counter>();
            ColumnWidth = new List<int>();
            DefaultColor = Color.FromArgb(0x66, 0xCC, 0xFF);
        }

        [DataMember]
        public List<Counter> Counters { get; set; }

        [DataMember]
        public List<int> ColumnWidth { get; set; }

        [DataMember]
        public Color DefaultColor { get; set; }
    }
}