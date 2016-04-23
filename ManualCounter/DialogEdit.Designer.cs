namespace ManualCounter
{
    partial class DialogEdit
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.resetFrequency = new System.Windows.Forms.ComboBox();
            this.content = new System.Windows.Forms.TextBox();
            this.currentValue = new System.Windows.Forms.NumericUpDown();
            this.totalValue = new System.Windows.Forms.NumericUpDown();
            this.progressColor = new ElectronicObserver.Window.Control.ColorPicker();
            this.resetAlongWithQuests = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(3, 3);
            label1.Margin = new System.Windows.Forms.Padding(3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 21);
            label1.TabIndex = 0;
            label1.Text = "标题内容";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(3, 30);
            label2.Margin = new System.Windows.Forms.Padding(3);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(53, 20);
            label2.TabIndex = 4;
            label2.Text = "重置频率";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(3, 56);
            label3.Margin = new System.Windows.Forms.Padding(3);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(53, 21);
            label3.TabIndex = 6;
            label3.Text = "当前数值";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Location = new System.Drawing.Point(3, 83);
            label4.Margin = new System.Windows.Forms.Padding(3);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(53, 21);
            label4.TabIndex = 7;
            label4.Text = "最大数值";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.acceptButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 163);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(286, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // acceptButton
            // 
            this.acceptButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.acceptButton.Location = new System.Drawing.Point(3, 3);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(137, 23);
            this.acceptButton.TabIndex = 0;
            this.acceptButton.Text = "确定";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButton.Location = new System.Drawing.Point(146, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(137, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.resetFrequency, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.content, 1, 0);
            this.tableLayoutPanel2.Controls.Add(label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.currentValue, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.totalValue, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.progressColor, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.resetAlongWithQuests, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(286, 160);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // resetFrequency
            // 
            this.resetFrequency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetFrequency.FormattingEnabled = true;
            this.resetFrequency.Location = new System.Drawing.Point(62, 30);
            this.resetFrequency.Name = "resetFrequency";
            this.resetFrequency.Size = new System.Drawing.Size(221, 20);
            this.resetFrequency.TabIndex = 2;
            // 
            // content
            // 
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(62, 3);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(221, 21);
            this.content.TabIndex = 3;
            // 
            // currentValue
            // 
            this.currentValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentValue.Location = new System.Drawing.Point(62, 56);
            this.currentValue.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.currentValue.Name = "currentValue";
            this.currentValue.Size = new System.Drawing.Size(221, 21);
            this.currentValue.TabIndex = 8;
            // 
            // totalValue
            // 
            this.totalValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalValue.Location = new System.Drawing.Point(62, 83);
            this.totalValue.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.totalValue.Name = "totalValue";
            this.totalValue.Size = new System.Drawing.Size(221, 21);
            this.totalValue.TabIndex = 9;
            // 
            // progressColor
            // 
            this.progressColor.AutoSize = true;
            this.progressColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.progressColor.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.SetColumnSpan(this.progressColor, 2);
            this.progressColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressColor.Location = new System.Drawing.Point(3, 110);
            this.progressColor.MinimumSize = new System.Drawing.Size(190, 23);
            this.progressColor.Name = "progressColor";
            this.progressColor.Size = new System.Drawing.Size(280, 23);
            this.progressColor.TabIndex = 10;
            this.progressColor.Text = "进度条颜色";
            // 
            // resetAlongWithQuests
            // 
            this.resetAlongWithQuests.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.resetAlongWithQuests, 2);
            this.resetAlongWithQuests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetAlongWithQuests.Location = new System.Drawing.Point(3, 139);
            this.resetAlongWithQuests.Name = "resetAlongWithQuests";
            this.resetAlongWithQuests.Size = new System.Drawing.Size(280, 18);
            this.resetAlongWithQuests.TabIndex = 11;
            this.resetAlongWithQuests.Text = "是否随任务刷新时间重置";
            this.resetAlongWithQuests.UseVisualStyleBackColor = true;
            // 
            // DialogEdit
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(292, 195);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogEdit";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox resetFrequency;
        private System.Windows.Forms.TextBox content;
        private System.Windows.Forms.NumericUpDown currentValue;
        private System.Windows.Forms.NumericUpDown totalValue;
        private ElectronicObserver.Window.Control.ColorPicker progressColor;
        private System.Windows.Forms.CheckBox resetAlongWithQuests;
    }
}