namespace BossKey
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
            this.muteWhenBossCome = new System.Windows.Forms.CheckBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.enableBossKey = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabPage.SuspendLayout();
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
            this.tabPage.Controls.Add(this.muteWhenBossCome);
            this.tabPage.Controls.Add(this.textBox);
            this.tabPage.Controls.Add(this.enableBossKey);
            this.tabPage.Location = new System.Drawing.Point(4, 22);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(370, 345);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "老板键";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // muteWhenBossCome
            // 
            this.muteWhenBossCome.AutoSize = true;
            this.muteWhenBossCome.Location = new System.Drawing.Point(6, 33);
            this.muteWhenBossCome.Name = "muteWhenBossCome";
            this.muteWhenBossCome.Size = new System.Drawing.Size(144, 16);
            this.muteWhenBossCome.TabIndex = 4;
            this.muteWhenBossCome.Text = "按下老板键时关闭声音";
            this.muteWhenBossCome.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox.Location = new System.Drawing.Point(96, 6);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(268, 21);
            this.textBox.TabIndex = 1;
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // enableBossKey
            // 
            this.enableBossKey.AutoSize = true;
            this.enableBossKey.Location = new System.Drawing.Point(6, 8);
            this.enableBossKey.Name = "enableBossKey";
            this.enableBossKey.Size = new System.Drawing.Size(84, 16);
            this.enableBossKey.TabIndex = 4;
            this.enableBossKey.Text = "启用老板键";
            this.enableBossKey.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage;

        private System.Windows.Forms.CheckBox enableBossKey;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.CheckBox muteWhenBossCome;
    }
}
