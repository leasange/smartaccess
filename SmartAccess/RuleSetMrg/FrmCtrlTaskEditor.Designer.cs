namespace SmartAccess.RuleSetMrg
{
    partial class FrmCtrlTaskEditor
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tbTaskNum = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbTaskName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtiTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.dtpStartDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.dtpEndDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cbWeek1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbWeek4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbWeek7 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbWeek5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbWeek3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbWeek2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbWeek6 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboCtrlStyle = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.comboItem11 = new DevComponents.Editors.ComboItem();
            this.comboItem12 = new DevComponents.Editors.ComboItem();
            this.comboItem13 = new DevComponents.Editors.ComboItem();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.tbTaskDesc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.tbDoorDropDown = new DevComponents.DotNetBar.Controls.TextBoxDropDown();
            this.doorTree = new Li.Controls.AdvTreeEx();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doorTree)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(65, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "任务编号";
            // 
            // tbTaskNum
            // 
            // 
            // 
            // 
            this.tbTaskNum.Border.Class = "TextBoxBorder";
            this.tbTaskNum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbTaskNum.Location = new System.Drawing.Point(83, 12);
            this.tbTaskNum.Name = "tbTaskNum";
            this.tbTaskNum.Size = new System.Drawing.Size(144, 23);
            this.tbTaskNum.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(12, 41);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(65, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "任务名称";
            // 
            // tbTaskName
            // 
            // 
            // 
            // 
            this.tbTaskName.Border.Class = "TextBoxBorder";
            this.tbTaskName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbTaskName.Location = new System.Drawing.Point(83, 41);
            this.tbTaskName.Name = "tbTaskName";
            this.tbTaskName.Size = new System.Drawing.Size(144, 23);
            this.tbTaskName.TabIndex = 1;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.dtiTime);
            this.groupPanel3.Controls.Add(this.labelX6);
            this.groupPanel3.Controls.Add(this.dtpStartDate);
            this.groupPanel3.Controls.Add(this.labelX3);
            this.groupPanel3.Controls.Add(this.labelX4);
            this.groupPanel3.Controls.Add(this.dtpEndDate);
            this.groupPanel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel3.Location = new System.Drawing.Point(233, 12);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(192, 118);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 9;
            this.groupPanel3.Text = "时间范围";
            // 
            // dtiTime
            // 
            // 
            // 
            // 
            this.dtiTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiTime.ButtonDropDown.Visible = true;
            this.dtiTime.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime;
            this.dtiTime.IsPopupCalendarOpen = false;
            this.dtiTime.Location = new System.Drawing.Point(69, 59);
            // 
            // 
            // 
            this.dtiTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            this.dtiTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtiTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTime.MonthCalendar.TodayButtonVisible = true;
            this.dtiTime.MonthCalendar.Visible = false;
            this.dtiTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiTime.Name = "dtiTime";
            this.dtiTime.ShowUpDown = true;
            this.dtiTime.Size = new System.Drawing.Size(114, 23);
            this.dtiTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiTime.TabIndex = 2;
            this.dtiTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            this.dtiTime.Value = new System.DateTime(2016, 9, 22, 1, 3, 47, 0);
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX6.Location = new System.Drawing.Point(8, 62);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(56, 20);
            this.labelX6.TabIndex = 11;
            this.labelX6.Text = "触发时间";
            // 
            // dtpStartDate
            // 
            // 
            // 
            // 
            this.dtpStartDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpStartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpStartDate.ButtonDropDown.Visible = true;
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpStartDate.IsPopupCalendarOpen = false;
            this.dtpStartDate.Location = new System.Drawing.Point(69, 3);
            // 
            // 
            // 
            this.dtpStartDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpStartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpStartDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpStartDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpStartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpStartDate.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            this.dtpStartDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtpStartDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpStartDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpStartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpStartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpStartDate.MonthCalendar.TodayButtonVisible = true;
            this.dtpStartDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(114, 23);
            this.dtpStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpStartDate.TabIndex = 0;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(7, 4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(56, 20);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "开始日期";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(8, 33);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(56, 20);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "结束日期";
            // 
            // dtpEndDate
            // 
            // 
            // 
            // 
            this.dtpEndDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpEndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpEndDate.ButtonDropDown.Visible = true;
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpEndDate.IsPopupCalendarOpen = false;
            this.dtpEndDate.Location = new System.Drawing.Point(69, 30);
            // 
            // 
            // 
            this.dtpEndDate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpEndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpEndDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpEndDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpEndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpEndDate.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            this.dtpEndDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtpEndDate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpEndDate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpEndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpEndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpEndDate.MonthCalendar.TodayButtonVisible = true;
            this.dtpEndDate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(114, 23);
            this.dtpEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpEndDate.TabIndex = 1;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cbWeek1);
            this.groupPanel1.Controls.Add(this.cbWeek4);
            this.groupPanel1.Controls.Add(this.cbWeek7);
            this.groupPanel1.Controls.Add(this.cbWeek5);
            this.groupPanel1.Controls.Add(this.cbWeek3);
            this.groupPanel1.Controls.Add(this.cbWeek2);
            this.groupPanel1.Controls.Add(this.cbWeek6);
            this.groupPanel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel1.Location = new System.Drawing.Point(431, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(117, 211);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 10;
            this.groupPanel1.Text = "星期选择";
            // 
            // cbWeek1
            // 
            this.cbWeek1.AutoSize = true;
            this.cbWeek1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbWeek1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbWeek1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbWeek1.Location = new System.Drawing.Point(21, 6);
            this.cbWeek1.Name = "cbWeek1";
            this.cbWeek1.Size = new System.Drawing.Size(64, 20);
            this.cbWeek1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek1.TabIndex = 0;
            this.cbWeek1.Text = "星期一";
            // 
            // cbWeek4
            // 
            this.cbWeek4.AutoSize = true;
            this.cbWeek4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbWeek4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbWeek4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbWeek4.Location = new System.Drawing.Point(21, 78);
            this.cbWeek4.Name = "cbWeek4";
            this.cbWeek4.Size = new System.Drawing.Size(64, 20);
            this.cbWeek4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek4.TabIndex = 3;
            this.cbWeek4.Text = "星期四";
            // 
            // cbWeek7
            // 
            this.cbWeek7.AutoSize = true;
            this.cbWeek7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbWeek7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbWeek7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbWeek7.Location = new System.Drawing.Point(21, 150);
            this.cbWeek7.Name = "cbWeek7";
            this.cbWeek7.Size = new System.Drawing.Size(64, 20);
            this.cbWeek7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek7.TabIndex = 6;
            this.cbWeek7.Text = "星期日";
            // 
            // cbWeek5
            // 
            this.cbWeek5.AutoSize = true;
            this.cbWeek5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbWeek5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbWeek5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbWeek5.Location = new System.Drawing.Point(21, 102);
            this.cbWeek5.Name = "cbWeek5";
            this.cbWeek5.Size = new System.Drawing.Size(64, 20);
            this.cbWeek5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek5.TabIndex = 4;
            this.cbWeek5.Text = "星期五";
            // 
            // cbWeek3
            // 
            this.cbWeek3.AutoSize = true;
            this.cbWeek3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbWeek3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbWeek3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbWeek3.Location = new System.Drawing.Point(21, 54);
            this.cbWeek3.Name = "cbWeek3";
            this.cbWeek3.Size = new System.Drawing.Size(64, 20);
            this.cbWeek3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek3.TabIndex = 2;
            this.cbWeek3.Text = "星期三";
            // 
            // cbWeek2
            // 
            this.cbWeek2.AutoSize = true;
            this.cbWeek2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbWeek2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbWeek2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbWeek2.Location = new System.Drawing.Point(21, 30);
            this.cbWeek2.Name = "cbWeek2";
            this.cbWeek2.Size = new System.Drawing.Size(64, 20);
            this.cbWeek2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek2.TabIndex = 1;
            this.cbWeek2.Text = "星期二";
            // 
            // cbWeek6
            // 
            this.cbWeek6.AutoSize = true;
            this.cbWeek6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbWeek6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbWeek6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbWeek6.Location = new System.Drawing.Point(21, 126);
            this.cbWeek6.Name = "cbWeek6";
            this.cbWeek6.Size = new System.Drawing.Size(64, 20);
            this.cbWeek6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek6.TabIndex = 5;
            this.cbWeek6.Text = "星期六";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.cboCtrlStyle);
            this.groupPanel2.Controls.Add(this.tbDoorDropDown);
            this.groupPanel2.Controls.Add(this.labelX7);
            this.groupPanel2.Controls.Add(this.labelX5);
            this.groupPanel2.Controls.Add(this.doorTree);
            this.groupPanel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel2.Location = new System.Drawing.Point(233, 136);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(192, 87);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 10;
            this.groupPanel2.Text = "门及控制方式";
            // 
            // cboCtrlStyle
            // 
            this.cboCtrlStyle.DisplayMember = "Text";
            this.cboCtrlStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCtrlStyle.FormattingEnabled = true;
            this.cboCtrlStyle.ItemHeight = 17;
            this.cboCtrlStyle.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6,
            this.comboItem7,
            this.comboItem8,
            this.comboItem9,
            this.comboItem10,
            this.comboItem11,
            this.comboItem12,
            this.comboItem13});
            this.cboCtrlStyle.Location = new System.Drawing.Point(65, 31);
            this.cboCtrlStyle.Name = "cboCtrlStyle";
            this.cboCtrlStyle.Size = new System.Drawing.Size(118, 23);
            this.cboCtrlStyle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboCtrlStyle.TabIndex = 1;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "0. 在线";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "1. 常开";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "2. 常闭";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "3. 禁止 2以上时段的用户开门(包括2时段)";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "4. 取消禁止 2以上时段的用户开门(包括2时段)";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "5. 刷卡-无密码";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "6. (进门) 刷卡 + 密码";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "7. (进出门) 刷卡 + 密码";
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "8. 多卡开门生效";
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "9. 单卡开门, 不要求多卡";
            // 
            // comboItem11
            // 
            this.comboItem11.Text = "10. 动作一次";
            // 
            // comboItem12
            // 
            this.comboItem12.Text = "11. 禁用按钮";
            // 
            // comboItem13
            // 
            this.comboItem13.Text = "12. 启用按钮";
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            this.labelX7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX7.Location = new System.Drawing.Point(3, 36);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(56, 20);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "控制方式";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(3, 7);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(56, 20);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "适用门禁";
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(12, 71);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(65, 23);
            this.labelX8.TabIndex = 0;
            this.labelX8.Text = "备注";
            // 
            // tbTaskDesc
            // 
            // 
            // 
            // 
            this.tbTaskDesc.Border.Class = "TextBoxBorder";
            this.tbTaskDesc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbTaskDesc.Location = new System.Drawing.Point(83, 71);
            this.tbTaskDesc.Multiline = true;
            this.tbTaskDesc.Name = "tbTaskDesc";
            this.tbTaskDesc.Size = new System.Drawing.Size(144, 152);
            this.tbTaskDesc.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(286, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(198, 252);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 31);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbDoorDropDown
            // 
            // 
            // 
            // 
            this.tbDoorDropDown.BackgroundStyle.Class = "TextBoxBorder";
            this.tbDoorDropDown.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDoorDropDown.ButtonDropDown.Visible = true;
            this.tbDoorDropDown.DropDownControl = this.doorTree;
            this.tbDoorDropDown.Location = new System.Drawing.Point(65, 3);
            this.tbDoorDropDown.Name = "tbDoorDropDown";
            this.tbDoorDropDown.Size = new System.Drawing.Size(118, 22);
            this.tbDoorDropDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tbDoorDropDown.TabIndex = 11;
            this.tbDoorDropDown.Text = "";
            // 
            // doorTree
            // 
            this.doorTree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.doorTree.AllowDrop = true;
            this.doorTree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.doorTree.BackgroundStyle.Class = "TreeBorderKey";
            this.doorTree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doorTree.CheckBoxVisible = true;
            this.doorTree.Location = new System.Drawing.Point(65, 26);
            this.doorTree.Name = "doorTree";
            this.doorTree.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.doorTree.NodesConnector = this.nodeConnector1;
            this.doorTree.NodeStyle = this.elementStyle1;
            this.doorTree.PathSeparator = ";";
            this.doorTree.SelectionPerCell = true;
            this.doorTree.Size = new System.Drawing.Size(187, 160);
            this.doorTree.Styles.Add(this.elementStyle1);
            this.doorTree.TabIndex = 12;
            this.doorTree.Text = "doorTree";
            this.doorTree.AfterCheck += new DevComponents.AdvTree.AdvTreeCellEventHandler(this.doorTree_AfterCheck);
            // 
            // node1
            // 
            this.node1.CheckBoxVisible = true;
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Text = "node1";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // FrmCtrlTaskEditor
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(558, 305);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.tbTaskDesc);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.tbTaskName);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.tbTaskNum);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCtrlTaskEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "定时任务编辑";
            this.Load += new System.EventHandler(this.FrmCtrlTaskEditor_Load);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doorTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbTaskNum;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbTaskName;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpStartDate;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpEndDate;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek4;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek7;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek5;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek3;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek2;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek6;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiTime;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboCtrlStyle;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX tbTaskDesc;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.Editors.ComboItem comboItem11;
        private DevComponents.Editors.ComboItem comboItem12;
        private DevComponents.Editors.ComboItem comboItem13;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown tbDoorDropDown;
        private Li.Controls.AdvTreeEx doorTree;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
    }
}