namespace SmartAccess.InfoSearchMgr
{
    partial class OprLogsInfo
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.dtpEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.dtpStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.dgvData = new Li.Controls.DataGridViewEx();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.pageDataGridView = new Li.Controls.PageDataGridView();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.cboLevel = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pageDataGridView.DataGridPanel.SuspendLayout();
            this.pageDataGridView.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(666, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.AllowEmptyState = false;
            // 
            // 
            // 
            this.dtpEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpEnd.ButtonDropDown.Visible = true;
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpEnd.IsPopupCalendarOpen = false;
            this.dtpEnd.Location = new System.Drawing.Point(439, 39);
            // 
            // 
            // 
            this.dtpEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpEnd.MonthCalendar.DisplayMonth = new System.DateTime(2016, 6, 1, 0, 0, 0, 0);
            this.dtpEnd.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtpEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpEnd.MonthCalendar.TodayButtonVisible = true;
            this.dtpEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(205, 23);
            this.dtpEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpEnd.TabIndex = 4;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(368, 39);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(65, 23);
            this.labelX6.TabIndex = 3;
            this.labelX6.Text = "结束时间";
            // 
            // dtpStart
            // 
            this.dtpStart.AllowEmptyState = false;
            // 
            // 
            // 
            this.dtpStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpStart.ButtonDropDown.Visible = true;
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpStart.IsPopupCalendarOpen = false;
            this.dtpStart.Location = new System.Drawing.Point(149, 39);
            // 
            // 
            // 
            this.dtpStart.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpStart.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpStart.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpStart.MonthCalendar.DisplayMonth = new System.DateTime(2016, 6, 1, 0, 0, 0, 0);
            this.dtpStart.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtpStart.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpStart.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpStart.MonthCalendar.TodayButtonVisible = true;
            this.dtpStart.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Size = new System.Drawing.Size(205, 23);
            this.dtpStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpStart.TabIndex = 4;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(12, 39);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(73, 23);
            this.labelX5.TabIndex = 3;
            this.labelX5.Text = "开始时间";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column6,
            this.Column5,
            this.Column1,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(977, 346);
            this.dgvData.TabIndex = 0;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "操作人";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "操作时间";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "日志级别";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "日志类型";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "操作内容";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // tbName
            // 
            // 
            // 
            // 
            this.tbName.Border.Class = "TextBoxBorder";
            this.tbName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbName.Location = new System.Drawing.Point(149, 10);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(205, 23);
            this.tbName.TabIndex = 1;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 10);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(121, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "操作人用户名或姓名";
            // 
            // pageDataGridView
            // 
            this.pageDataGridView.BackColor = System.Drawing.Color.GhostWhite;
            // 
            // pageDataGridView.DataGridPanel
            // 
            this.pageDataGridView.DataGridPanel.Controls.Add(this.dgvData);
            this.pageDataGridView.DataGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDataGridView.DataGridPanel.Location = new System.Drawing.Point(0, 0);
            this.pageDataGridView.DataGridPanel.Name = "DataGridPanel";
            this.pageDataGridView.DataGridPanel.Size = new System.Drawing.Size(977, 346);
            this.pageDataGridView.DataGridPanel.TabIndex = 1;
            this.pageDataGridView.DataGridView = this.dgvData;
            this.pageDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDataGridView.Location = new System.Drawing.Point(0, 68);
            this.pageDataGridView.Name = "pageDataGridView";
            // 
            // pageDataGridView.PageControl
            // 
            this.pageDataGridView.PageControl.CurrentPage = 1;
            this.pageDataGridView.PageControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageDataGridView.PageControl.ExportButtonVisible = true;
            this.pageDataGridView.PageControl.Location = new System.Drawing.Point(0, 346);
            this.pageDataGridView.PageControl.Name = "PageControl";
            this.pageDataGridView.PageControl.RecordsPerPage = 30;
            this.pageDataGridView.PageControl.Size = new System.Drawing.Size(977, 32);
            this.pageDataGridView.PageControl.TabIndex = 0;
            this.pageDataGridView.PageControl.TotalRecords = 0;
            this.pageDataGridView.PageControl.PageChanged += new Li.Controls.PageCtrl.PageEventHandle(this.pageDataGridView1_PageControl_PageChanged);
            this.pageDataGridView.PageControl.ExportCurrent += new Li.Controls.PageCtrl.PageEventHandle(this.pageDataGridView1_PageControl_ExportCurrent);
            this.pageDataGridView.PageControl.ExportAll += new Li.Controls.PageCtrl.PageEventHandle(this.pageDataGridView1_PageControl_ExportAll);
            this.pageDataGridView.Size = new System.Drawing.Size(977, 378);
            this.pageDataGridView.SqlWhere = null;
            this.pageDataGridView.TabIndex = 3;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnSearch);
            this.panelEx1.Controls.Add(this.dtpEnd);
            this.panelEx1.Controls.Add(this.labelX6);
            this.panelEx1.Controls.Add(this.dtpStart);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.cboLevel);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.tbName);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(977, 68);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 2;
            // 
            // cboLevel
            // 
            this.cboLevel.DisplayMember = "Text";
            this.cboLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevel.FormattingEnabled = true;
            this.cboLevel.ItemHeight = 17;
            this.cboLevel.Items.AddRange(new object[] {
            this.comboItem5,
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4});
            this.cboLevel.Location = new System.Drawing.Point(439, 10);
            this.cboLevel.Name = "cboLevel";
            this.cboLevel.Size = new System.Drawing.Size(205, 23);
            this.cboLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboLevel.TabIndex = 2;
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "所有级别";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "调试";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "信息";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "警告";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "错误";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(367, 10);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(58, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "日志级别";
            // 
            // OprLogsInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageDataGridView);
            this.Controls.Add(this.panelEx1);
            this.Name = "OprLogsInfo";
            this.Size = new System.Drawing.Size(977, 446);
            this.Load += new System.EventHandler(this.OprLogsInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pageDataGridView.DataGridPanel.ResumeLayout(false);
            this.pageDataGridView.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpEnd;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpStart;
        private DevComponents.DotNetBar.LabelX labelX5;
        private Li.Controls.DataGridViewEx dgvData;
        private DevComponents.DotNetBar.Controls.TextBoxX tbName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private Li.Controls.PageDataGridView pageDataGridView;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboLevel;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private DevComponents.Editors.ComboItem comboItem5;
    }
}
