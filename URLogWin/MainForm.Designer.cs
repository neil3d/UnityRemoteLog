namespace URLogWin
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.checkBtnInfo = new System.Windows.Forms.ToolStripButton();
            this.checkBtnWarning = new System.Windows.Forms.ToolStripButton();
            this.checkBtnError = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnHelp = new System.Windows.Forms.ToolStripButton();
            this.panelStart = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTips = new System.Windows.Forms.Label();
            this.pictureBoxLog = new System.Windows.Forms.PictureBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listViewLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListLog = new System.Windows.Forms.ImageList(this.components);
            this.textBoxDetail = new System.Windows.Forms.TextBox();
            this.eventTickTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStripTop.SuspendLayout();
            this.panelStart.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripTop
            // 
            this.toolStripTop.CanOverflow = false;
            this.toolStripTop.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkBtnInfo,
            this.checkBtnWarning,
            this.checkBtnError,
            this.toolStripSeparator1,
            this.btnClear,
            this.btnSave,
            this.btnHelp});
            this.toolStripTop.Location = new System.Drawing.Point(0, 0);
            this.toolStripTop.Name = "toolStripTop";
            this.toolStripTop.Size = new System.Drawing.Size(927, 25);
            this.toolStripTop.TabIndex = 0;
            this.toolStripTop.Text = "Tool Bar";
            // 
            // checkBtnInfo
            // 
            this.checkBtnInfo.Checked = true;
            this.checkBtnInfo.CheckOnClick = true;
            this.checkBtnInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBtnInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkBtnInfo.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBtnInfo.Image = ((System.Drawing.Image)(resources.GetObject("checkBtnInfo.Image")));
            this.checkBtnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBtnInfo.Name = "checkBtnInfo";
            this.checkBtnInfo.Size = new System.Drawing.Size(23, 22);
            this.checkBtnInfo.Text = "toolStripButton1";
            this.checkBtnInfo.ToolTipText = "Show/Hide Info";
            this.checkBtnInfo.CheckedChanged += new System.EventHandler(this.checkBtnInfo_CheckedChanged);
            // 
            // checkBtnWarning
            // 
            this.checkBtnWarning.Checked = true;
            this.checkBtnWarning.CheckOnClick = true;
            this.checkBtnWarning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBtnWarning.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkBtnWarning.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBtnWarning.Image = global::URLogWin.Properties.Resources.icon_warning;
            this.checkBtnWarning.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBtnWarning.Name = "checkBtnWarning";
            this.checkBtnWarning.Size = new System.Drawing.Size(23, 22);
            this.checkBtnWarning.Text = "toolStripButton1";
            this.checkBtnWarning.ToolTipText = "Show/Hide Warning";
            this.checkBtnWarning.CheckedChanged += new System.EventHandler(this.checkBtnWarning_CheckedChanged);
            // 
            // checkBtnError
            // 
            this.checkBtnError.Checked = true;
            this.checkBtnError.CheckOnClick = true;
            this.checkBtnError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBtnError.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.checkBtnError.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBtnError.Image = global::URLogWin.Properties.Resources.icon_error;
            this.checkBtnError.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkBtnError.Name = "checkBtnError";
            this.checkBtnError.Size = new System.Drawing.Size(23, 22);
            this.checkBtnError.Text = "toolStripButton1";
            this.checkBtnError.ToolTipText = "Show/Hide Error";
            this.checkBtnError.CheckedChanged += new System.EventHandler(this.checkBtnError_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClear
            // 
            this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClear.Image = global::URLogWin.Properties.Resources.icon_clear;
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(23, 22);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::URLogWin.Properties.Resources.icon_save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Save to File";
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHelp.Image = global::URLogWin.Properties.Resources.icon_help;
            this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 22);
            this.btnHelp.Text = "Help";
            // 
            // panelStart
            // 
            this.panelStart.Controls.Add(this.statusStrip);
            this.panelStart.Controls.Add(this.labelTips);
            this.panelStart.Controls.Add(this.pictureBoxLog);
            this.panelStart.Controls.Add(this.splitContainer);
            this.panelStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStart.Location = new System.Drawing.Point(0, 25);
            this.panelStart.Name = "panelStart";
            this.panelStart.Size = new System.Drawing.Size(927, 375);
            this.panelStart.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 353);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(927, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(44, 17);
            this.lbStatus.Text = "Ready";
            // 
            // labelTips
            // 
            this.labelTips.AutoSize = true;
            this.labelTips.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTips.Location = new System.Drawing.Point(407, 172);
            this.labelTips.Name = "labelTips";
            this.labelTips.Size = new System.Drawing.Size(329, 21);
            this.labelTips.TabIndex = 1;
            this.labelTips.Text = "正在等待UnityRemoteLog连接...";
            // 
            // pictureBoxLog
            // 
            this.pictureBoxLog.Image = global::URLogWin.Properties.Resources.Logo;
            this.pictureBoxLog.Location = new System.Drawing.Point(254, 121);
            this.pictureBoxLog.Name = "pictureBoxLog";
            this.pictureBoxLog.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxLog.TabIndex = 0;
            this.pictureBoxLog.TabStop = false;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listViewLog);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.textBoxDetail);
            this.splitContainer.Size = new System.Drawing.Size(927, 375);
            this.splitContainer.SplitterDistance = 220;
            this.splitContainer.TabIndex = 3;
            // 
            // listViewLog
            // 
            this.listViewLog.AutoArrange = false;
            this.listViewLog.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLog.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewLog.FullRowSelect = true;
            this.listViewLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewLog.LabelWrap = false;
            this.listViewLog.LargeImageList = this.imageListLog;
            this.listViewLog.Location = new System.Drawing.Point(0, 0);
            this.listViewLog.MultiSelect = false;
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(927, 220);
            this.listViewLog.SmallImageList = this.imageListLog;
            this.listViewLog.TabIndex = 0;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            this.listViewLog.SelectedIndexChanged += new System.EventHandler(this.listViewLog_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            this.columnHeader1.Width = 18;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Log";
            this.columnHeader2.Width = 818;
            // 
            // imageListLog
            // 
            this.imageListLog.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLog.ImageStream")));
            this.imageListLog.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLog.Images.SetKeyName(0, "icon_info.png");
            this.imageListLog.Images.SetKeyName(1, "icon_warning.png");
            this.imageListLog.Images.SetKeyName(2, "icon_error.png");
            // 
            // textBoxDetail
            // 
            this.textBoxDetail.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxDetail.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDetail.Location = new System.Drawing.Point(0, 0);
            this.textBoxDetail.Multiline = true;
            this.textBoxDetail.Name = "textBoxDetail";
            this.textBoxDetail.ReadOnly = true;
            this.textBoxDetail.Size = new System.Drawing.Size(927, 151);
            this.textBoxDetail.TabIndex = 0;
            // 
            // eventTickTimer
            // 
            this.eventTickTimer.Enabled = true;
            this.eventTickTimer.Tick += new System.EventHandler(this.eventTickTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 400);
            this.Controls.Add(this.panelStart);
            this.Controls.Add(this.toolStripTop);
            this.Font = new System.Drawing.Font("Courier New", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unity Remote Log Window";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.toolStripTop.ResumeLayout(false);
            this.toolStripTop.PerformLayout();
            this.panelStart.ResumeLayout(false);
            this.panelStart.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLog)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripTop;
        private System.Windows.Forms.ToolStripButton checkBtnInfo;
        private System.Windows.Forms.ToolStripButton checkBtnWarning;
        private System.Windows.Forms.ToolStripButton checkBtnError;
        private System.Windows.Forms.Panel panelStart;
        private System.Windows.Forms.PictureBox pictureBoxLog;
        private System.Windows.Forms.Label labelTips;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.TextBox textBoxDetail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnHelp;
        private System.Windows.Forms.Timer eventTickTimer;
        private System.Windows.Forms.ImageList imageListLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripButton btnSave;

    }
}

