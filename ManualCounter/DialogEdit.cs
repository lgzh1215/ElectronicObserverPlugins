using System;
using System.Windows.Forms;

namespace ManualCounter
{
    public partial class DialogEdit : Form
    {
        private Counter counter;

        public DialogEdit(Counter counter, string title = "添加")
        {
            this.counter = counter;
            InitializeComponent();
            Text = title;
            Font = ElectronicObserver.Utility.Configuration.Config.UI.MainFont;

            resetFrequency.Items.Add(new FrequencyObject(Frequency.None));
            resetFrequency.Items.Add(new FrequencyObject(Frequency.Day));
            resetFrequency.Items.Add(new FrequencyObject(Frequency.Week));
            resetFrequency.Items.Add(new FrequencyObject(Frequency.Month));
            resetFrequency.Items.Add(new FrequencyObject(Frequency.Year));

            content.Text = counter.Content;
            resetFrequency.SelectedIndex = (int)counter.ResetFrequency;
            currentValue.Value = counter.CurrentValue;
            totalValue.Value = counter.TotalValue;
            incrementation.Value = counter.Incrementation;
            resetAlongWithQuests.Checked = counter.ResetAlongWithQuests;
            progressColor.SelectedColor = counter.ProgressColor;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            counter.Content = content.Text;
            counter.ResetFrequency = ((FrequencyObject)resetFrequency.SelectedItem).frequency;
            counter.CurrentValue = (uint)currentValue.Value;
            counter.TotalValue = (uint)totalValue.Value;
            counter.Incrementation = (uint)incrementation.Value;
            counter.ResetAlongWithQuests = resetAlongWithQuests.Checked;
            counter.ProgressColor = progressColor.SelectedColor;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private class FrequencyObject
        {
            public FrequencyObject(Frequency f) { frequency = f; }

            public readonly Frequency frequency;

            public override string ToString()
            {
                return CounterHolder.Instance.FrequencyName[frequency];
            }
        }
    }
}