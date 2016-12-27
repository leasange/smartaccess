namespace SmartAccess.ControlDevMgr
{
    partial class FrmSearchController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.tbSnFilter = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dtpTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.cbAutoSearch = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSetTime = new DevComponents.DotNetBar.ButtonX();
            this.btnGetTime = new DevComponents.DotNetBar.ButtonX();
            this.btnSearchCtrlr = new DevComponents.DotNetBar.ButtonX();
            this.dgvCtrlr = new Li.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_XQ = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Col_TJ = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiResetIP = new System.Windows.Forms.ToolStripMenuItem();
            this.控制IP访问约束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置读卡器输入格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.恢复读卡器默认格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.指定格式WG26不带校验ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.指定读卡器35位ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.通信10M100M配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置为10M100M自适应ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置为10M半双工适用于布线长ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtrlr)).BeginInit();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.tbSnFilter);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.dtpTime);
            this.panelEx1.Controls.Add(this.cbAutoSearch);
            this.panelEx1.Controls.Add(this.btnSetTime);
            this.panelEx1.Controls.Add(this.btnGetTime);
            this.panelEx1.Controls.Add(this.btnSearchCtrlr);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(950, 66);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // tbSnFilter
            // 
            // 
            // 
            // 
            this.tbSnFilter.Border.Class = "TextBoxBorder";
            this.tbSnFilter.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbSnFilter.Location = new System.Drawing.Point(134, 42);
            this.tbSnFilter.Name = "tbSnFilter";
            this.tbSnFilter.Size = new System.Drawing.Size(114, 21);
            this.tbSnFilter.TabIndex = 4;
            this.tbSnFilter.WatermarkText = "输入匹配字符";
            this.tbSnFilter.TextChanged += new System.EventHandler(this.tbSnFilter_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(42, 41);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(86, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "序列号过滤：";
            // 
            // dtpTime
            // 
            // 
            // 
            // 
            this.dtpTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpTime.ButtonDropDown.Visible = true;
            this.dtpTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
            this.dtpTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpTime.IsPopupCalendarOpen = false;
            this.dtpTime.Location = new System.Drawing.Point(518, 16);
            // 
            // 
            // 
            this.dtpTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpTime.MonthCalendar.DayClickAutoClosePopup = false;
            this.dtpTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 8, 1, 0, 0, 0, 0);
            this.dtpTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtpTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpTime.MonthCalendar.TodayButtonVisible = true;
            this.dtpTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(189, 21);
            this.dtpTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpTime.TabIndex = 2;
            this.dtpTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            this.dtpTime.Value = new System.DateTime(2016, 8, 21, 16, 22, 51, 0);
            // 
            // cbAutoSearch
            // 
            // 
            // 
            // 
            this.cbAutoSearch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbAutoSearch.Checked = true;
            this.cbAutoSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoSearch.CheckValue = "Y";
            this.cbAutoSearch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbAutoSearch.Location = new System.Drawing.Point(190, 16);
            this.cbAutoSearch.Name = "cbAutoSearch";
            this.cbAutoSearch.Size = new System.Drawing.Size(159, 23);
            this.cbAutoSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbAutoSearch.TabIndex = 1;
            this.cbAutoSearch.Text = "修改IP后自动重新搜索";
            // 
            // btnSetTime
            // 
            this.btnSetTime.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetTime.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetTime.Location = new System.Drawing.Point(713, 12);
            this.btnSetTime.Name = "btnSetTime";
            this.btnSetTime.Size = new System.Drawing.Size(142, 27);
            this.btnSetTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetTime.TabIndex = 0;
            this.btnSetTime.Text = "设置控制器时间";
            this.btnSetTime.Click += new System.EventHandler(this.btnSetTime_Click);
            // 
            // btnGetTime
            // 
            this.btnGetTime.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGetTime.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGetTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetTime.Location = new System.Drawing.Point(370, 12);
            this.btnGetTime.Name = "btnGetTime";
            this.btnGetTime.Size = new System.Drawing.Size(142, 27);
            this.btnGetTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGetTime.TabIndex = 0;
            this.btnGetTime.Text = "获取控制器时间";
            this.btnGetTime.Click += new System.EventHandler(this.btnGetTime_Click);
            // 
            // btnSearchCtrlr
            // 
            this.btnSearchCtrlr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchCtrlr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearchCtrlr.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearchCtrlr.Location = new System.Drawing.Point(42, 12);
            this.btnSearchCtrlr.Name = "btnSearchCtrlr";
            this.btnSearchCtrlr.Size = new System.Drawing.Size(142, 27);
            this.btnSearchCtrlr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearchCtrlr.TabIndex = 0;
            this.btnSearchCtrlr.Text = "搜索网段内控制器";
            this.btnSearchCtrlr.Click += new System.EventHandler(this.btnSearchCtrlr_Click);
            // 
            // dgvCtrlr
            // 
            this.dgvCtrlr.AllowUserToAddRows = false;
            this.dgvCtrlr.AllowUserToDeleteRows = false;
            this.dgvCtrlr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCtrlr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCtrlr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Col_XQ,
            this.Col_TJ});
            this.dgvCtrlr.ContextMenuStrip = this.cmsMenu;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCtrlr.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCtrlr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtrlr.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvCtrlr.Location = new System.Drawing.Point(0, 66);
            this.dgvCtrlr.Name = "dgvCtrlr";
            this.dgvCtrlr.ReadOnly = true;
            this.dgvCtrlr.RowTemplate.Height = 23;
            this.dgvCtrlr.Size = new System.Drawing.Size(950, 451);
            this.dgvCtrlr.TabIndex = 1;
            this.dgvCtrlr.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCtrlr_CellContentClick);
            this.dgvCtrlr.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCtrlr_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序列号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "IP";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "子网掩码";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "网关";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Port";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "MAC地址";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "电脑IP地址";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "驱动版本";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Col_XQ
            // 
            this.Col_XQ.HeaderText = "修改";
            this.Col_XQ.Name = "Col_XQ";
            this.Col_XQ.ReadOnly = true;
            // 
            // Col_TJ
            // 
            this.Col_TJ.HeaderText = "添加";
            this.Col_TJ.Name = "Col_TJ";
            this.Col_TJ.ReadOnly = true;
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNetTest,
            this.tsmiResetIP,
            this.控制IP访问约束ToolStripMenuItem,
            this.设置读卡器输入格式ToolStripMenuItem,
            this.通信10M100M配置ToolStripMenuItem});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(189, 136);
            // 
            // tsmiNetTest
            // 
            this.tsmiNetTest.Name = "tsmiNetTest";
            this.tsmiNetTest.Size = new System.Drawing.Size(188, 22);
            this.tsmiNetTest.Text = "通信丢包测试";
            this.tsmiNetTest.Click += new System.EventHandler(this.tsmiNetTest_Click);
            // 
            // tsmiResetIP
            // 
            this.tsmiResetIP.Name = "tsmiResetIP";
            this.tsmiResetIP.Size = new System.Drawing.Size(188, 22);
            this.tsmiResetIP.Text = "恢复默认IP";
            this.tsmiResetIP.Click += new System.EventHandler(this.tsmiResetIP_Click);
            // 
            // 控制IP访问约束ToolStripMenuItem
            // 
            this.控制IP访问约束ToolStripMenuItem.Name = "控制IP访问约束ToolStripMenuItem";
            this.控制IP访问约束ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.控制IP访问约束ToolStripMenuItem.Text = "控制IP访问约束";
            // 
            // 设置读卡器输入格式ToolStripMenuItem
            // 
            this.设置读卡器输入格式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.恢复读卡器默认格式ToolStripMenuItem,
            this.指定格式WG26不带校验ToolStripMenuItem,
            this.指定读卡器35位ToolStripMenuItem});
            this.设置读卡器输入格式ToolStripMenuItem.Name = "设置读卡器输入格式ToolStripMenuItem";
            this.设置读卡器输入格式ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.设置读卡器输入格式ToolStripMenuItem.Text = "设置读卡器输入格式";
            // 
            // 恢复读卡器默认格式ToolStripMenuItem
            // 
            this.恢复读卡器默认格式ToolStripMenuItem.Name = "恢复读卡器默认格式ToolStripMenuItem";
            this.恢复读卡器默认格式ToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.恢复读卡器默认格式ToolStripMenuItem.Text = "恢复读卡器默认格式";
            // 
            // 指定格式WG26不带校验ToolStripMenuItem
            // 
            this.指定格式WG26不带校验ToolStripMenuItem.Name = "指定格式WG26不带校验ToolStripMenuItem";
            this.指定格式WG26不带校验ToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.指定格式WG26不带校验ToolStripMenuItem.Text = "指定格式(WG26不带校验)";
            // 
            // 指定读卡器35位ToolStripMenuItem
            // 
            this.指定读卡器35位ToolStripMenuItem.Name = "指定读卡器35位ToolStripMenuItem";
            this.指定读卡器35位ToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.指定读卡器35位ToolStripMenuItem.Text = "指定读卡器35位输入格式";
            // 
            // 通信10M100M配置ToolStripMenuItem
            // 
            this.通信10M100M配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置为10M100M自适应ToolStripMenuItem,
            this.设置为10M半双工适用于布线长ToolStripMenuItem});
            this.通信10M100M配置ToolStripMenuItem.Name = "通信10M100M配置ToolStripMenuItem";
            this.通信10M100M配置ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.通信10M100M配置ToolStripMenuItem.Text = "通信10M/100M配置";
            // 
            // 设置为10M100M自适应ToolStripMenuItem
            // 
            this.设置为10M100M自适应ToolStripMenuItem.Name = "设置为10M100M自适应ToolStripMenuItem";
            this.设置为10M100M自适应ToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.设置为10M100M自适应ToolStripMenuItem.Text = "设置为10M/100M自适应";
            // 
            // 设置为10M半双工适用于布线长ToolStripMenuItem
            // 
            this.设置为10M半双工适用于布线长ToolStripMenuItem.Name = "设置为10M半双工适用于布线长ToolStripMenuItem";
            this.设置为10M半双工适用于布线长ToolStripMenuItem.Size = new System.Drawing.Size(302, 22);
            this.设置为10M半双工适用于布线长ToolStripMenuItem.Text = "设置为10M半双工(适用于布线长，干扰多)";
            // 
            // FrmSearchController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 517);
            this.Controls.Add(this.dgvCtrlr);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "FrmSearchController";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "搜索控制器";
            this.Load += new System.EventHandler(this.FrmSearchController_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtrlr)).EndInit();
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnSearchCtrlr;
        private Li.Controls.DataGridViewEx dgvCtrlr;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbAutoSearch;
        private DevComponents.DotNetBar.ButtonX btnGetTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpTime;
        private DevComponents.DotNetBar.ButtonX btnSetTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewLinkColumn Col_XQ;
        private System.Windows.Forms.DataGridViewLinkColumn Col_TJ;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSnFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmiNetTest;
        private System.Windows.Forms.ToolStripMenuItem tsmiResetIP;
        private System.Windows.Forms.ToolStripMenuItem 控制IP访问约束ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置读卡器输入格式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 恢复读卡器默认格式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 指定格式WG26不带校验ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 指定读卡器35位ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 通信10M100M配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置为10M100M自适应ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置为10M半双工适用于布线长ToolStripMenuItem;
    }
}