namespace ManualCounter
{
    partial class FormCounter
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
            this.components = new System.ComponentModel.Container();
            this.counterView = new System.Windows.Forms.DataGridView();
            this.columnFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnIncrease = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.counterView)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // counterView
            // 
            this.counterView.AllowUserToAddRows = false;
            this.counterView.AllowUserToDeleteRows = false;
            this.counterView.AllowUserToResizeRows = false;
            this.counterView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.counterView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.counterView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.counterView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnFrequency,
            this.columnContent,
            this.columnProgress,
            this.columnIncrease});
            this.counterView.ContextMenuStrip = this.contextMenu;
            this.counterView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.counterView.Location = new System.Drawing.Point(0, 0);
            this.counterView.MultiSelect = false;
            this.counterView.Name = "counterView";
            this.counterView.ReadOnly = true;
            this.counterView.RowHeadersVisible = false;
            this.counterView.RowTemplate.Height = 21;
            this.counterView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.counterView.Size = new System.Drawing.Size(300, 200);
            this.counterView.TabIndex = 0;
            this.counterView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.counterView_CellContentClick);
            this.counterView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.counterView_CellMouseDown);
            this.counterView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.counterView_CellPainting);
            this.counterView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.counterView_ColumnWidthChanged);
            // 
            // columnFrequency
            // 
            this.columnFrequency.HeaderText = "重置";
            this.columnFrequency.Name = "columnFrequency";
            this.columnFrequency.ReadOnly = true;
            this.columnFrequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnFrequency.Width = 40;
            // 
            // columnContent
            // 
            this.columnContent.FillWeight = 200F;
            this.columnContent.HeaderText = "标题内容";
            this.columnContent.Name = "columnContent";
            this.columnContent.ReadOnly = true;
            this.columnContent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnContent.Width = 143;
            // 
            // columnProgress
            // 
            this.columnProgress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnProgress.HeaderText = "进度";
            this.columnProgress.Name = "columnProgress";
            this.columnProgress.ReadOnly = true;
            this.columnProgress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnIncrease
            // 
            this.columnIncrease.HeaderText = "";
            this.columnIncrease.Name = "columnIncrease";
            this.columnIncrease.ReadOnly = true;
            this.columnIncrease.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnIncrease.Text = "";
            this.columnIncrease.Width = 24;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemIncrease,
            this.toolStripSeparator,
            this.menuItemEdit,
            this.menuItemReset,
            this.menuItemMoveUp,
            this.menuItemMoveDown,
            this.menuItemDelete});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(153, 164);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Name = "menuItemEdit";
            this.menuItemEdit.Size = new System.Drawing.Size(152, 22);
            this.menuItemEdit.Text = "编辑";
            this.menuItemEdit.Click += new System.EventHandler(this.menuItemEdit_Click);
            // 
            // menuItemMoveUp
            // 
            this.menuItemMoveUp.Name = "menuItemMoveUp";
            this.menuItemMoveUp.Size = new System.Drawing.Size(152, 22);
            this.menuItemMoveUp.Text = "上移";
            this.menuItemMoveUp.Click += new System.EventHandler(this.menuItemMoveUp_Click);
            // 
            // menuItemMoveDown
            // 
            this.menuItemMoveDown.Name = "menuItemMoveDown";
            this.menuItemMoveDown.Size = new System.Drawing.Size(152, 22);
            this.menuItemMoveDown.Text = "下移";
            this.menuItemMoveDown.Click += new System.EventHandler(this.menuItemMoveDown_Click);
            // 
            // menuItemReset
            // 
            this.menuItemReset.Name = "menuItemReset";
            this.menuItemReset.Size = new System.Drawing.Size(152, 22);
            this.menuItemReset.Text = "重置";
            this.menuItemReset.Click += new System.EventHandler(this.menuItemReset_Click);
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Name = "menuItemDelete";
            this.menuItemDelete.Size = new System.Drawing.Size(152, 22);
            this.menuItemDelete.Text = "删除";
            this.menuItemDelete.Click += new System.EventHandler(this.menuItemDelete_Click);
            // 
            // menuItemIncrease
            // 
            this.menuItemIncrease.Image = global::ManualCounter.Resource.icon;
            this.menuItemIncrease.Name = "menuItemIncrease";
            this.menuItemIncrease.Size = new System.Drawing.Size(152, 22);
            this.menuItemIncrease.ToolTipText = "+1后立即保存数据";
            this.menuItemIncrease.Click += new System.EventHandler(this.menuItemIncrease_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // FormCounter
            // 
            this.AutoHidePortion = 150D;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.counterView);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HideOnClose = true;
            this.Name = "FormCounter";
            this.Text = "手动计数器";
            this.Load += new System.EventHandler(this.FormCounter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.counterView)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView counterView;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnProgress;
        private System.Windows.Forms.DataGridViewButtonColumn columnIncrease;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem menuItemReset;
        private System.Windows.Forms.ToolStripMenuItem menuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem menuItemMoveUp;
        private System.Windows.Forms.ToolStripMenuItem menuItemMoveDown;
        private System.Windows.Forms.ToolStripMenuItem menuItemIncrease;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    }
}