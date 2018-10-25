namespace SmartAccess
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsmiNowTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslStateUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsmiServerIp = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.smtNavigate = new SmartAccess.SmtNavigate();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biSystem = new DevComponents.DotNetBar.ButtonItem();
            this.biSelectStyle = new DevComponents.DotNetBar.ButtonItem();
            this.biLogout = new DevComponents.DotNetBar.ButtonItem();
            this.biExitSys = new DevComponents.DotNetBar.ButtonItem();
            this.superTabControl = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.panelWelCome = new DevComponents.DotNetBar.PanelEx();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.panelHeader = new DevComponents.DotNetBar.PanelEx();
            this.lbTitle = new DevComponents.DotNetBar.LabelX();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl)).BeginInit();
            this.superTabControl.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNowTime,
            this.toolStripStatusLabel3,
            this.tsslStateUser,
            this.toolStripStatusLabel1,
            this.tsmiServerIp,
            this.toolStripStatusLabel4});
            this.statusStrip.Location = new System.Drawing.Point(0, 711);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip.Size = new System.Drawing.Size(1014, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // tsmiNowTime
            // 
            this.tsmiNowTime.ForeColor = System.Drawing.Color.White;
            this.tsmiNowTime.Name = "tsmiNowTime";
            this.tsmiNowTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiNowTime.Size = new System.Drawing.Size(126, 17);
            this.tsmiNowTime.Text = "00:00:00 0000-00-00";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Yellow;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel3.Text = "时间:";
            // 
            // tsslStateUser
            // 
            this.tsslStateUser.ForeColor = System.Drawing.Color.White;
            this.tsslStateUser.Name = "tsslStateUser";
            this.tsslStateUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsslStateUser.Size = new System.Drawing.Size(44, 17);
            this.tsslStateUser.Text = "admin";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Yellow;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel1.Text = "用户:";
            // 
            // tsmiServerIp
            // 
            this.tsmiServerIp.ForeColor = System.Drawing.Color.White;
            this.tsmiServerIp.Name = "tsmiServerIp";
            this.tsmiServerIp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsmiServerIp.Size = new System.Drawing.Size(45, 17);
            this.tsmiServerIp.Text = "0.0.0.0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Yellow;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel4.Text = "服务器:";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 58);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.smtNavigate);
            this.splitContainer.Panel1.Controls.Add(this.bar1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.superTabControl);
            this.splitContainer.Size = new System.Drawing.Size(1014, 653);
            this.splitContainer.SplitterDistance = 225;
            this.splitContainer.TabIndex = 4;
            // 
            // smtNavigate
            // 
            this.smtNavigate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smtNavigate.Location = new System.Drawing.Point(0, 26);
            this.smtNavigate.Name = "smtNavigate";
            this.smtNavigate.Size = new System.Drawing.Size(225, 627);
            this.smtNavigate.TabIndex = 2;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.BarType = DevComponents.DotNetBar.eBarType.MenuBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biSystem});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(225, 26);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biSystem
            // 
            this.biSystem.Name = "biSystem";
            this.biSystem.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biSelectStyle,
            this.biLogout,
            this.biExitSys});
            this.biSystem.SubItemsExpandWidth = 18;
            this.biSystem.Text = "系统";
            // 
            // biSelectStyle
            // 
            this.biSelectStyle.Name = "biSelectStyle";
            this.biSelectStyle.Text = "选择样式";
            // 
            // biLogout
            // 
            this.biLogout.Name = "biLogout";
            this.biLogout.Text = "注销系统";
            this.biLogout.Click += new System.EventHandler(this.biLogout_Click);
            // 
            // biExitSys
            // 
            this.biExitSys.Name = "biExitSys";
            this.biExitSys.Text = "退出系统(&Q)";
            this.biExitSys.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // superTabControl
            // 
            this.superTabControl.CloseButtonOnTabsVisible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl.ControlBox.MenuBox.Name = "";
            this.superTabControl.ControlBox.Name = "";
            this.superTabControl.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl.ControlBox.MenuBox,
            this.superTabControl.ControlBox.CloseBox});
            this.superTabControl.Controls.Add(this.superTabControlPanel1);
            this.superTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl.Location = new System.Drawing.Point(0, 0);
            this.superTabControl.Name = "superTabControl";
            this.superTabControl.ReorderTabsEnabled = true;
            this.superTabControl.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl.SelectedTabIndex = 0;
            this.superTabControl.Size = new System.Drawing.Size(785, 653);
            this.superTabControl.TabIndex = 0;
            this.superTabControl.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1});
            this.superTabControl.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.panelWelCome);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 39);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(785, 614);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // panelWelCome
            // 
            this.panelWelCome.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelWelCome.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelWelCome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWelCome.Font = new System.Drawing.Font("微软雅黑", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelWelCome.Location = new System.Drawing.Point(0, 0);
            this.panelWelCome.Name = "panelWelCome";
            this.panelWelCome.Size = new System.Drawing.Size(785, 614);
            this.panelWelCome.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelWelCome.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelWelCome.Style.BackgroundImage = global::SmartAccess.Properties.Resources.welcomeback;
            this.panelWelCome.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelWelCome.Style.ForeColor.Color = System.Drawing.Color.White;
            this.panelWelCome.Style.GradientAngle = 90;
            this.panelWelCome.TabIndex = 0;
            this.panelWelCome.Text = "欢迎使用智能门禁管理系统";
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.CloseButtonVisible = false;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Image = global::SmartAccess.Properties.Resources.欢迎;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "欢迎";
            // 
            // panelHeader
            // 
            this.panelHeader.AutoScroll = true;
            this.panelHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHeader.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.panelHeader.Controls.Add(this.lbTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1014, 58);
            this.panelHeader.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelHeader.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelHeader.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelHeader.Style.BackgroundImage = global::SmartAccess.Properties.Resources.企业logo;
            this.panelHeader.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.CenterRight;
            this.panelHeader.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelHeader.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelHeader.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelHeader.Style.GradientAngle = 90;
            this.panelHeader.TabIndex = 2;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTitle.Font = new System.Drawing.Font("方正姚体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbTitle.Location = new System.Drawing.Point(3, 5);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(592, 49);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "智能卡综合管理系统，您的好管家！";
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 733);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.statusStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智能卡综合管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl)).EndInit();
            this.superTabControl.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelHeader;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStateUser;
        private System.Windows.Forms.SplitContainer splitContainer;
        private DevComponents.DotNetBar.SuperTabControl superTabControl;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.LabelX lbTitle;
        private DevComponents.DotNetBar.PanelEx panelWelCome;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biSystem;
        private DevComponents.DotNetBar.ButtonItem biSelectStyle;
        private DevComponents.DotNetBar.ButtonItem biExitSys;
        private DevComponents.DotNetBar.ButtonItem biLogout;
        private SmtNavigate smtNavigate;
        private System.Windows.Forms.ToolStripStatusLabel tsmiNowTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.ToolStripStatusLabel tsmiServerIp;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
    }
}

