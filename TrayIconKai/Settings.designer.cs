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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.activateWhenShow = new System.Windows.Forms.CheckBox();
            this.bossKeyGroupBox = new System.Windows.Forms.GroupBox();
            this.muteWhenBossCome = new System.Windows.Forms.CheckBox();
            this.hideTrayIconWhenBossCome = new System.Windows.Forms.CheckBox();
            this.globalBossKey = new System.Windows.Forms.CheckBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.enableBossKey = new System.Windows.Forms.CheckBox();
            this.trayIconGroupBox = new System.Windows.Forms.GroupBox();
            this.hideWhenClickTrayIcon = new System.Windows.Forms.CheckBox();
            this.hideWhenMinimized = new System.Windows.Forms.CheckBox();
            this.enableTrayIcon = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.bossKeyGroupBox.SuspendLayout();
            this.trayIconGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(378, 371);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.activateWhenShow);
            this.tabPage.Controls.Add(this.bossKeyGroupBox);
            this.tabPage.Controls.Add(this.enableBossKey);
            this.tabPage.Controls.Add(this.trayIconGroupBox);
            this.tabPage.Controls.Add(this.enableTrayIcon);
            this.tabPage.Location = new System.Drawing.Point(4, 22);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(370, 345);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "托盘图标和老板键";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // activateWhenShow
            // 
            this.activateWhenShow.AutoSize = true;
            this.activateWhenShow.Location = new System.Drawing.Point(6, 267);
            this.activateWhenShow.Name = "activateWhenShow";
            this.activateWhenShow.Size = new System.Drawing.Size(216, 16);
            this.activateWhenShow.TabIndex = 6;
            this.activateWhenShow.Text = "恢复被隐藏的窗口时将其激活(前置)";
            this.activateWhenShow.UseVisualStyleBackColor = true;
            // 
            // bossKeyGroupBox
            // 
            this.bossKeyGroupBox.AutoSize = true;
            this.bossKeyGroupBox.Controls.Add(this.muteWhenBossCome);
            this.bossKeyGroupBox.Controls.Add(this.hideTrayIconWhenBossCome);
            this.bossKeyGroupBox.Controls.Add(this.globalBossKey);
            this.bossKeyGroupBox.Controls.Add(this.textBox);
            this.bossKeyGroupBox.Controls.Add(this.label);
            this.bossKeyGroupBox.Location = new System.Drawing.Point(6, 134);
            this.bossKeyGroupBox.Name = "bossKeyGroupBox";
            this.bossKeyGroupBox.Size = new System.Drawing.Size(358, 127);
            this.bossKeyGroupBox.TabIndex = 5;
            this.bossKeyGroupBox.TabStop = false;
            this.bossKeyGroupBox.Text = "老板键";
            // 
            // muteWhenBossCome
            // 
            this.muteWhenBossCome.AutoSize = true;
            this.muteWhenBossCome.Location = new System.Drawing.Point(6, 91);
            this.muteWhenBossCome.Name = "muteWhenBossCome";
            this.muteWhenBossCome.Size = new System.Drawing.Size(144, 16);
            this.muteWhenBossCome.TabIndex = 4;
            this.muteWhenBossCome.Text = "按下老板键时关闭声音";
            this.muteWhenBossCome.UseVisualStyleBackColor = true;
            // 
            // hideTrayIconWhenBossCome
            // 
            this.hideTrayIconWhenBossCome.AutoSize = true;
            this.hideTrayIconWhenBossCome.Location = new System.Drawing.Point(6, 69);
            this.hideTrayIconWhenBossCome.Name = "hideTrayIconWhenBossCome";
            this.hideTrayIconWhenBossCome.Size = new System.Drawing.Size(168, 16);
            this.hideTrayIconWhenBossCome.TabIndex = 3;
            this.hideTrayIconWhenBossCome.Text = "按下老板键时隐藏托盘图标";
            this.hideTrayIconWhenBossCome.UseVisualStyleBackColor = true;
            // 
            // globalBossKey
            // 
            this.globalBossKey.AutoSize = true;
            this.globalBossKey.Location = new System.Drawing.Point(6, 47);
            this.globalBossKey.Name = "globalBossKey";
            this.globalBossKey.Size = new System.Drawing.Size(108, 16);
            this.globalBossKey.TabIndex = 2;
            this.globalBossKey.Text = "使用全局老板键";
            this.globalBossKey.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox.Location = new System.Drawing.Point(65, 20);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(287, 21);
            this.textBox.TabIndex = 1;
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(6, 23);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(53, 12);
            this.label.TabIndex = 0;
            this.label.Text = "快捷键：";
            // 
            // enableBossKey
            // 
            this.enableBossKey.AutoSize = true;
            this.enableBossKey.Location = new System.Drawing.Point(6, 112);
            this.enableBossKey.Name = "enableBossKey";
            this.enableBossKey.Size = new System.Drawing.Size(84, 16);
            this.enableBossKey.TabIndex = 4;
            this.enableBossKey.Text = "启用老板键";
            this.enableBossKey.UseVisualStyleBackColor = true;
            // 
            // trayIconGroupBox
            // 
            this.trayIconGroupBox.AutoSize = true;
            this.trayIconGroupBox.Controls.Add(this.hideWhenClickTrayIcon);
            this.trayIconGroupBox.Controls.Add(this.hideWhenMinimized);
            this.trayIconGroupBox.Location = new System.Drawing.Point(6, 28);
            this.trayIconGroupBox.Name = "trayIconGroupBox";
            this.trayIconGroupBox.Size = new System.Drawing.Size(358, 78);
            this.trayIconGroupBox.TabIndex = 3;
            this.trayIconGroupBox.TabStop = false;
            this.trayIconGroupBox.Text = "托盘图标";
            // 
            // hideWhenClickTrayIcon
            // 
            this.hideWhenClickTrayIcon.AutoSize = true;
            this.hideWhenClickTrayIcon.Location = new System.Drawing.Point(6, 20);
            this.hideWhenClickTrayIcon.Name = "hideWhenClickTrayIcon";
            this.hideWhenClickTrayIcon.Size = new System.Drawing.Size(156, 16);
            this.hideWhenClickTrayIcon.TabIndex = 2;
            this.hideWhenClickTrayIcon.Text = "点击托盘图标时隐藏窗口";
            this.hideWhenClickTrayIcon.UseVisualStyleBackColor = true;
            // 
            // hideWhenMinimized
            // 
            this.hideWhenMinimized.AutoSize = true;
            this.hideWhenMinimized.Location = new System.Drawing.Point(6, 42);
            this.hideWhenMinimized.Name = "hideWhenMinimized";
            this.hideWhenMinimized.Size = new System.Drawing.Size(156, 16);
            this.hideWhenMinimized.TabIndex = 0;
            this.hideWhenMinimized.Text = "最小化时隐藏窗口到托盘";
            this.hideWhenMinimized.UseVisualStyleBackColor = true;
            // 
            // enableTrayIcon
            // 
            this.enableTrayIcon.AutoSize = true;
            this.enableTrayIcon.Location = new System.Drawing.Point(6, 6);
            this.enableTrayIcon.Name = "enableTrayIcon";
            this.enableTrayIcon.Size = new System.Drawing.Size(96, 16);
            this.enableTrayIcon.TabIndex = 1;
            this.enableTrayIcon.Text = "启用托盘图标";
            this.enableTrayIcon.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(378, 371);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.tabPage.PerformLayout();
            this.bossKeyGroupBox.ResumeLayout(false);
            this.bossKeyGroupBox.PerformLayout();
            this.trayIconGroupBox.ResumeLayout(false);
            this.trayIconGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.CheckBox enableTrayIcon;
        private System.Windows.Forms.GroupBox trayIconGroupBox;
        private System.Windows.Forms.CheckBox hideWhenMinimized;
        private System.Windows.Forms.CheckBox hideWhenClickTrayIcon;

        private System.Windows.Forms.CheckBox enableBossKey;
        private System.Windows.Forms.GroupBox bossKeyGroupBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.CheckBox globalBossKey;
        private System.Windows.Forms.CheckBox hideTrayIconWhenBossCome;
        private System.Windows.Forms.CheckBox muteWhenBossCome;
        private System.Windows.Forms.CheckBox activateWhenShow;
    }
}
