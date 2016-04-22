using ElectronicObserver.Utility;
using ElectronicObserver.Window;
using ElectronicObserver.Window.Support;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ManualCounter
{
    public partial class FormCounter : DockContent
    {
        private DataGridViewCellStyle leftCellStyle, middleCellStyle;
        private bool IsLoaded = false;

        private CounterHolder CounterHolder { get { return CounterHolder.Instance; } }

        public FormCounter(FormMain parent)
        {
            parent.FormClosing += Parent_FormClosing;

            this.SuspendLayoutForDpiScale();
            InitializeComponent();
            ControlHelper.SetDoubleBuffered(counterView);

            #region 设置表格样式
            leftCellStyle = new DataGridViewCellStyle();
            leftCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            leftCellStyle.BackColor =
            leftCellStyle.SelectionBackColor = Configuration.Config.UI.BackColor;
            leftCellStyle.ForeColor =
            leftCellStyle.SelectionForeColor = Configuration.Config.UI.ForeColor;
            leftCellStyle.WrapMode = DataGridViewTriState.False;

            middleCellStyle = new DataGridViewCellStyle(leftCellStyle);
            middleCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            counterView.DefaultCellStyle = middleCellStyle;
            counterView.GridColor = Configuration.Config.UI.LineColor;
            columnContent.DefaultCellStyle = leftCellStyle;
            columnProgress.DefaultCellStyle = leftCellStyle;
            counterView.ColumnHeadersHeight = this.GetDpiHeight(24);

            counterView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            #endregion

            this.ResumeLayoutForDpiScale();
        }

        private void FormCounter_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resource.icon.GetHicon());

            //恢复之前保存的列宽
            List<int> width = ManualCounter.Config.ColumnWidth;
            DataGridViewColumnCollection columns = counterView.Columns;
            if (columns.Count <= width.Count)
                for (int i = 0; i < columns.Count; i++)
                {
                    columns[i].Width = width[i];
                }

            UpdateView();
            IsLoaded = true;
        }

        internal void AddCounter(Counter c)
        {
            CounterHolder.AddCounter(c);
            UpdateView();
        }

        internal void RemoveCounter(Counter c)
        {
            CounterHolder.RemoveCounter(c);
            UpdateView();
        }

        internal void MoveUp(Counter c)
        {
            int index = CounterHolder.Counters.IndexOf(c);
            if (index <= 0) return;
            CounterHolder.Counters.Reverse(index - 1, 2);
        }

        internal void MoveDown(Counter c)
        {
            int index = CounterHolder.Counters.IndexOf(c);
            if (index < 0 || index == CounterHolder.Counters.Count - 1) return;
            CounterHolder.Counters.Reverse(index, 2);
        }

        /// <summary>
        /// 更新表格所有数据
        /// </summary>
        private void UpdateView(bool needSave = false)
        {
            counterView.SuspendLayout();
            counterView.Rows.Clear();

            CounterHolder.UpdateCounter();
            foreach (Counter c in CounterHolder.Counters)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(counterView);
                newRow.Tag = c;

                newRow.SetValues(
                    CounterHolder.FrequencyName[c.ResetFrequency],
                    c.Content,
                    c.ProgressText,
                    c.TotalValue == 0 || c.CurrentValue < c.TotalValue ? "+1" : "RE"
                );
                //newRow.Cells[columnFrequency.Index].Value = CounterHolder.FrequencyName[c.ResetFrequency];
                //newRow.Cells[columnContent.Index].Value = c.Content;
                //newRow.Cells[columnProgress.Index].Value = c.ProgressText;
                //newRow.Cells[columnIncrease.Index].Value = c.TotalValue == 0 || c.CurrentValue < c.TotalValue ? "+1" : "RE";
                counterView.Rows.Add(newRow);
            }

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(counterView);
            row.Cells[columnContent.Index].Value = "点击「+1」添加计数";
            row.Cells[columnIncrease.Index].Value = "+1";
            counterView.Rows.Add(row);

            counterView.ResumeLayout();

            if (needSave) ManualCounter.Save();
        }

        /// <summary>
        /// 更新某行的数据
        /// </summary>
        private void UpdateRow(DataGridViewRow row, bool needSave = false)
        {
            counterView.SuspendLayout();
            row.SetValues(null, null, null, null);

            Counter c = (Counter)row.Tag;
            if (c != null)
            {
                row.SetValues(
                    CounterHolder.FrequencyName[c.ResetFrequency],
                    c.Content,
                    c.ProgressText,
                    c.TotalValue == 0 || c.CurrentValue < c.TotalValue ? "+1" : "RE"
                );
            }
            counterView.ResumeLayout();

            if (needSave) ManualCounter.Save();
        }

        /// <summary>
        /// 绘制进度条
        /// </summary>
        private void counterView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //抄了74oe任务列表的代码
            if (e.ColumnIndex != columnProgress.Index ||
                e.RowIndex < 0 ||
                (e.PaintParts & DataGridViewPaintParts.Background) == 0)
                return;

            Counter c = (Counter)counterView.Rows[e.RowIndex].Tag;
            if (c == null) return;

            using (SolidBrush back = new SolidBrush(e.CellStyle.BackColor),
                progress = new SolidBrush(c.ProgressColor))
            {
                const int thickness = 4;
                double rate = c.Progress;
                e.Graphics.FillRectangle(back, e.CellBounds);
                e.Graphics.FillRectangle(progress,
                    new Rectangle(e.CellBounds.X, e.CellBounds.Bottom - thickness, (int)(e.CellBounds.Width * rate), thickness));
            }

            e.Paint(e.ClipBounds, e.PaintParts & ~DataGridViewPaintParts.Background);
            e.Handled = true;
        }

        /// <summary>
        /// 保存表格列宽
        /// </summary>
        private void counterView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (IsLoaded)
                ManualCounter.Config.ColumnWidth
                    = counterView.Columns.Cast<DataGridViewColumn>().Select(c => c.Width).ToList();
        }

        /// <summary>
        /// 点击表格+1按钮列
        /// </summary>
        private void counterView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex == columnIncrease.Index && rowIndex > -1)
            {
                if (rowIndex == counterView.Rows.Count - 1)
                {
                    //点击了表格尾行，添加新计数
                    Counter newCounter = new Counter();
                    DialogEdit edit = new DialogEdit(newCounter);
                    DialogResult result = edit.ShowDialog();
                    if (result == DialogResult.OK)
                        AddCounter(newCounter);
                }
                else
                {
                    //点击了计数器的+1
                    var row = counterView.Rows[rowIndex];
                    ((Counter)row.Tag).Increase(true);
                    UpdateRow(row);
                }
            }
        }

        /// <summary>
        /// 设置表格行的选择状态以配合菜单食用
        /// </summary>
        private void counterView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                counterView.ClearSelection();
                if (e.RowIndex >= 0)
                    counterView.Rows[e.RowIndex].Selected = true;
            }
        }

        /// <summary>
        /// 显示菜单：「…」+1
        /// </summary>
        private void contextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var row = GetSelectedRow();
            if (row == null)
            {
                menuItemIncrease.Visible = false;
                toolStripSeparator.Visible = false;
            }
            else
            {
                Counter c = (Counter)row.Tag;
                string content = c.Content;
                if (c.Content.Length > 4)
                    content = content.Substring(0, 4) + "…";
                else if (string.IsNullOrWhiteSpace(c.Content))
                    content = "空白";
                menuItemIncrease.Text = "「" + content + "」+1";
                menuItemIncrease.Visible = true;
                toolStripSeparator.Visible = true;
            }
        }

        /// <summary>
        /// 点击菜单：「…」+1
        /// </summary>
        private void menuItemIncrease_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow();
            if (row != null)
            {
                ((Counter)row.Tag).Increase(true);
                UpdateRow(row);
                ManualCounter.Save();
            }
        }

        /// <summary>
        /// 点击菜单：编辑
        /// </summary>
        private void menuItemEdit_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow();
            if (row != null)
            {
                Counter c = (Counter)row.Tag;
                DialogEdit edit = new DialogEdit(c, "编辑");
                DialogResult result = edit.ShowDialog();
                if (result == DialogResult.OK)
                {
                    UpdateRow(row);
                }
            }
        }

        /// <summary>
        /// 点击菜单：重置
        /// </summary>
        private void menuItemReset_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow();
            if (row != null)
            {
                ((Counter)row.Tag).Reset();
                UpdateRow(row);
            }
        }

        /// <summary>
        /// 点击菜单：删除
        /// </summary>
        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            var row = counterView.SelectedRows[0];
            int index = row.Index;
            if (index > -1 && index < counterView.Rows.Count - 1)
            {
                RemoveCounter((Counter)row.Tag);
                UpdateView();
            }
        }

        /// <summary>
        /// 点击菜单：上移
        /// </summary>
        private void menuItemMoveUp_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow();
            if (row != null)
            {
                MoveUp((Counter)row.Tag);
                UpdateView();
            }
        }

        /// <summary>
        /// 点击菜单：下移
        /// </summary>
        private void menuItemMoveDown_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow();
            if (row != null)
            {
                MoveDown((Counter)row.Tag);
                UpdateView();
            }
        }

        /// <summary>
        /// 获得菜单选择的行，排除表头与尾行
        /// </summary>
        private DataGridViewRow GetSelectedRow()
        {
            if (counterView.SelectedRows.Count != 0)
            {
                DataGridViewRow row = counterView.SelectedRows[0];
                if (row.Index > -1 && row.Index < counterView.Rows.Count - 1)
                    return row;
            }
            return null;
        }

        /// <summary>
        /// 关闭74前保存数据
        /// </summary>
        private void Parent_FormClosing(object sender, FormClosingEventArgs e)
        {
            CounterHolder.UpdateCounter();
            ManualCounter.Save();
        }
    }
}