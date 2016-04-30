namespace TrayIconKai
{
    partial class Settings
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.GroupBox bossKeyGroupBox;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
            System.Windows.Forms.Label label;
            System.Windows.Forms.GroupBox trayIconGroupBox;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
            System.Windows.Forms.TabControl tabControl;
            System.Windows.Forms.TabPage tabPage;
            this.enableTrayIcon = new System.Windows.Forms.CheckBox();
            this.muteWhenBossCome = new System.Windows.Forms.CheckBox();
            this.hideTrayIconWhenBossCome = new System.Windows.Forms.CheckBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.activateWhenShow = new System.Windows.Forms.CheckBox();
            this.hideWhenMinimized = new System.Windows.Forms.CheckBox();
            this.hideWhenClickTrayIcon = new System.Windows.Forms.CheckBox();
            this.enableBossKey = new System.Windows.Forms.CheckBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            bossKeyGroupBox = new System.Windows.Forms.GroupBox();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            label = new System.Windows.Forms.Label();
            trayIconGroupBox = new System.Windows.Forms.GroupBox();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            tabControl = new System.Windows.Forms.TabControl();
            tabPage = new System.Windows.Forms.TabPage();
            tableLayoutPanel1.SuspendLayout();
            bossKeyGroupBox.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            trayIconGroupBox.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(this.enableTrayIcon, 0, 0);
            tableLayoutPanel1.Controls.Add(bossKeyGroupBox, 0, 3);
            tableLayoutPanel1.Controls.Add(this.activateWhenShow, 0, 4);
            tableLayoutPanel1.Controls.Add(trayIconGroupBox, 0, 1);
            tableLayoutPanel1.Controls.Add(this.enableBossKey, 0, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(280, 263);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // enableTrayIcon
            // 
            this.enableTrayIcon.AutoSize = true;
            this.enableTrayIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enableTrayIcon.Location = new System.Drawing.Point(3, 3);
            this.enableTrayIcon.Name = "enableTrayIcon";
            this.enableTrayIcon.Size = new System.Drawing.Size(274, 16);
            this.enableTrayIcon.TabIndex = 1;
            this.enableTrayIcon.Text = "启用托盘图标";
            this.enableTrayIcon.UseVisualStyleBackColor = true;
            // 
            // bossKeyGroupBox
            // 
            bossKeyGroupBox.AutoSize = true;
            bossKeyGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            bossKeyGroupBox.Controls.Add(tableLayoutPanel3);
            bossKeyGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            bossKeyGroupBox.Location = new System.Drawing.Point(3, 117);
            bossKeyGroupBox.Name = "bossKeyGroupBox";
            bossKeyGroupBox.Size = new System.Drawing.Size(274, 91);
            bossKeyGroupBox.TabIndex = 5;
            bossKeyGroupBox.TabStop = false;
            bossKeyGroupBox.Text = "老板键";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(this.muteWhenBossCome, 0, 2);
            tableLayoutPanel3.Controls.Add(label, 0, 0);
            tableLayoutPanel3.Controls.Add(this.hideTrayIconWhenBossCome, 0, 1);
            tableLayoutPanel3.Controls.Add(this.textBox, 1, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel3.Size = new System.Drawing.Size(268, 71);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // muteWhenBossCome
            // 
            this.muteWhenBossCome.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(this.muteWhenBossCome, 2);
            this.muteWhenBossCome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.muteWhenBossCome.Location = new System.Drawing.Point(3, 52);
            this.muteWhenBossCome.Name = "muteWhenBossCome";
            this.muteWhenBossCome.Size = new System.Drawing.Size(262, 16);
            this.muteWhenBossCome.TabIndex = 4;
            this.muteWhenBossCome.Text = "按下老板键时关闭声音";
            this.muteWhenBossCome.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.Location = new System.Drawing.Point(3, 3);
            label.Margin = new System.Windows.Forms.Padding(3);
            label.Name = "label";
            label.Size = new System.Drawing.Size(41, 21);
            label.TabIndex = 0;
            label.Text = "老板键";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hideTrayIconWhenBossCome
            // 
            this.hideTrayIconWhenBossCome.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(this.hideTrayIconWhenBossCome, 2);
            this.hideTrayIconWhenBossCome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hideTrayIconWhenBossCome.Location = new System.Drawing.Point(3, 30);
            this.hideTrayIconWhenBossCome.Name = "hideTrayIconWhenBossCome";
            this.hideTrayIconWhenBossCome.Size = new System.Drawing.Size(262, 16);
            this.hideTrayIconWhenBossCome.TabIndex = 3;
            this.hideTrayIconWhenBossCome.Text = "按下老板键时隐藏托盘图标";
            this.hideTrayIconWhenBossCome.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Location = new System.Drawing.Point(50, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(215, 21);
            this.textBox.TabIndex = 1;
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // activateWhenShow
            // 
            this.activateWhenShow.AutoSize = true;
            this.activateWhenShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.activateWhenShow.Location = new System.Drawing.Point(3, 214);
            this.activateWhenShow.Name = "activateWhenShow";
            this.activateWhenShow.Size = new System.Drawing.Size(274, 16);
            this.activateWhenShow.TabIndex = 6;
            this.activateWhenShow.Text = "恢复被隐藏的窗口时将其激活(前置)";
            this.activateWhenShow.UseVisualStyleBackColor = true;
            // 
            // trayIconGroupBox
            // 
            trayIconGroupBox.AutoSize = true;
            trayIconGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            trayIconGroupBox.Controls.Add(tableLayoutPanel2);
            trayIconGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            trayIconGroupBox.Location = new System.Drawing.Point(3, 25);
            trayIconGroupBox.Name = "trayIconGroupBox";
            trayIconGroupBox.Size = new System.Drawing.Size(274, 64);
            trayIconGroupBox.TabIndex = 3;
            trayIconGroupBox.TabStop = false;
            trayIconGroupBox.Text = "托盘图标";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(this.hideWhenMinimized, 0, 1);
            tableLayoutPanel2.Controls.Add(this.hideWhenClickTrayIcon, 0, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.Size = new System.Drawing.Size(268, 44);
            tableLayoutPanel2.TabIndex = 8;
            // 
            // hideWhenMinimized
            // 
            this.hideWhenMinimized.AutoSize = true;
            this.hideWhenMinimized.Location = new System.Drawing.Point(3, 25);
            this.hideWhenMinimized.Name = "hideWhenMinimized";
            this.hideWhenMinimized.Size = new System.Drawing.Size(156, 16);
            this.hideWhenMinimized.TabIndex = 0;
            this.hideWhenMinimized.Text = "最小化时隐藏窗口到托盘";
            this.hideWhenMinimized.UseVisualStyleBackColor = true;
            // 
            // hideWhenClickTrayIcon
            // 
            this.hideWhenClickTrayIcon.AutoSize = true;
            this.hideWhenClickTrayIcon.Location = new System.Drawing.Point(3, 3);
            this.hideWhenClickTrayIcon.Name = "hideWhenClickTrayIcon";
            this.hideWhenClickTrayIcon.Size = new System.Drawing.Size(156, 16);
            this.hideWhenClickTrayIcon.TabIndex = 2;
            this.hideWhenClickTrayIcon.Text = "点击托盘图标时隐藏窗口";
            this.hideWhenClickTrayIcon.UseVisualStyleBackColor = true;
            // 
            // enableBossKey
            // 
            this.enableBossKey.AutoSize = true;
            this.enableBossKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enableBossKey.Location = new System.Drawing.Point(3, 95);
            this.enableBossKey.Name = "enableBossKey";
            this.enableBossKey.Size = new System.Drawing.Size(274, 16);
            this.enableBossKey.TabIndex = 4;
            this.enableBossKey.Text = "启用老板键";
            this.enableBossKey.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage);
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(294, 295);
            tabControl.TabIndex = 0;
            // 
            // tabPage
            // 
            tabPage.Controls.Add(tableLayoutPanel1);
            tabPage.Location = new System.Drawing.Point(4, 22);
            tabPage.Name = "tabPage";
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(286, 269);
            tabPage.TabIndex = 0;
            tabPage.Text = "托盘图标和老板键";
            tabPage.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tabControl);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(294, 295);
            this.Load += new System.EventHandler(this.Settings_Load);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            bossKeyGroupBox.ResumeLayout(false);
            bossKeyGroupBox.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            trayIconGroupBox.ResumeLayout(false);
            trayIconGroupBox.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPage.ResumeLayout(false);
            tabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox enableTrayIcon;
        private System.Windows.Forms.CheckBox hideWhenMinimized;
        private System.Windows.Forms.CheckBox hideWhenClickTrayIcon;

        private System.Windows.Forms.CheckBox enableBossKey;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.CheckBox hideTrayIconWhenBossCome;
        private System.Windows.Forms.CheckBox muteWhenBossCome;
        private System.Windows.Forms.CheckBox activateWhenShow;
    }
}
