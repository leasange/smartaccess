namespace SmartAccess.ConfigMgr
{
    partial class FrmInOutTimeEditor
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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbTimeNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tbName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dtpStartDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.dtpEndDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cbNextTimeNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbWeek1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbWeek2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbWeek3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbWeek4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbWeek5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbWeek6 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbWeek7 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.dtiTimeAreaStart1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtiTimeAreaEnd1 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.dtiTimeAreaStart2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtiTimeAreaEnd2 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.dtiTimeAreaStart3 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtiTimeAreaEnd3 = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeAreaStart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeAreaEnd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeAreaStart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeAreaEnd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeAreaStart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeAreaEnd3)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(60, 6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(44, 20);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "时段号";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(28, 13);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(31, 20);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "名称";
            // 
            // cbTimeNo
            // 
            this.cbTimeNo.DisplayMember = "Text";
            this.cbTimeNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTimeNo.DropDownHeight = 200;
            this.cbTimeNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeNo.FormattingEnabled = true;
            this.cbTimeNo.IntegralHeight = false;
            this.cbTimeNo.ItemHeight = 17;
            this.cbTimeNo.Location = new System.Drawing.Point(110, 3);
            this.cbTimeNo.Name = "cbTimeNo";
            this.cbTimeNo.Size = new System.Drawing.Size(167, 23);
            this.cbTimeNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbTimeNo.TabIndex = 1;
            // 
            // tbName
            // 
            // 
            // 
            // 
            this.tbName.Border.Class = "TextBoxBorder";
            this.tbName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbName.Location = new System.Drawing.Point(65, 12);
            this.tbName.MaxLength = 100;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(248, 21);
            this.tbName.TabIndex = 2;
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
            this.dtpStartDate.TabIndex = 3;
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
            this.dtpEndDate.TabIndex = 3;
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
            this.labelX5.Location = new System.Drawing.Point(12, 32);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(93, 20);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "下一链接时段号";
            // 
            // cbNextTimeNo
            // 
            this.cbNextTimeNo.DisplayMember = "Text";
            this.cbNextTimeNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbNextTimeNo.DropDownHeight = 200;
            this.cbNextTimeNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNextTimeNo.FormattingEnabled = true;
            this.cbNextTimeNo.IntegralHeight = false;
            this.cbNextTimeNo.ItemHeight = 17;
            this.cbNextTimeNo.Location = new System.Drawing.Point(110, 30);
            this.cbNextTimeNo.Name = "cbNextTimeNo";
            this.cbNextTimeNo.Size = new System.Drawing.Size(167, 23);
            this.cbNextTimeNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbNextTimeNo.TabIndex = 1;
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
            this.cbWeek1.Location = new System.Drawing.Point(72, 3);
            this.cbWeek1.Name = "cbWeek1";
            this.cbWeek1.Size = new System.Drawing.Size(64, 20);
            this.cbWeek1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek1.TabIndex = 4;
            this.cbWeek1.Text = "星期一";
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
            this.cbWeek2.Location = new System.Drawing.Point(72, 27);
            this.cbWeek2.Name = "cbWeek2";
            this.cbWeek2.Size = new System.Drawing.Size(64, 20);
            this.cbWeek2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek2.TabIndex = 4;
            this.cbWeek2.Text = "星期二";
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
            this.cbWeek3.Location = new System.Drawing.Point(72, 51);
            this.cbWeek3.Name = "cbWeek3";
            this.cbWeek3.Size = new System.Drawing.Size(64, 20);
            this.cbWeek3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek3.TabIndex = 4;
            this.cbWeek3.Text = "星期三";
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
            this.cbWeek4.Location = new System.Drawing.Point(72, 75);
            this.cbWeek4.Name = "cbWeek4";
            this.cbWeek4.Size = new System.Drawing.Size(64, 20);
            this.cbWeek4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek4.TabIndex = 4;
            this.cbWeek4.Text = "星期四";
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
            this.cbWeek5.Location = new System.Drawing.Point(72, 99);
            this.cbWeek5.Name = "cbWeek5";
            this.cbWeek5.Size = new System.Drawing.Size(64, 20);
            this.cbWeek5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek5.TabIndex = 4;
            this.cbWeek5.Text = "星期五";
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
            this.cbWeek6.Location = new System.Drawing.Point(72, 123);
            this.cbWeek6.Name = "cbWeek6";
            this.cbWeek6.Size = new System.Drawing.Size(64, 20);
            this.cbWeek6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek6.TabIndex = 4;
            this.cbWeek6.Text = "星期六";
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
            this.cbWeek7.Location = new System.Drawing.Point(72, 147);
            this.cbWeek7.Name = "cbWeek7";
            this.cbWeek7.Size = new System.Drawing.Size(64, 20);
            this.cbWeek7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbWeek7.TabIndex = 4;
            this.cbWeek7.Text = "星期日";
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
            this.labelX6.Location = new System.Drawing.Point(17, 24);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(38, 20);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "时区1";
            // 
            // dtiTimeAreaStart1
            // 
            // 
            // 
            // 
            this.dtiTimeAreaStart1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiTimeAreaStart1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaStart1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiTimeAreaStart1.ButtonDropDown.Visible = true;
            this.dtiTimeAreaStart1.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime;
            this.dtiTimeAreaStart1.IsPopupCalendarOpen = false;
            this.dtiTimeAreaStart1.Location = new System.Drawing.Point(61, 21);
            // 
            // 
            // 
            this.dtiTimeAreaStart1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeAreaStart1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaStart1.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiTimeAreaStart1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiTimeAreaStart1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiTimeAreaStart1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeAreaStart1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiTimeAreaStart1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiTimeAreaStart1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiTimeAreaStart1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiTimeAreaStart1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaStart1.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            this.dtiTimeAreaStart1.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtiTimeAreaStart1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiTimeAreaStart1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeAreaStart1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiTimeAreaStart1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeAreaStart1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiTimeAreaStart1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaStart1.MonthCalendar.TodayButtonVisible = true;
            this.dtiTimeAreaStart1.MonthCalendar.Visible = false;
            this.dtiTimeAreaStart1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiTimeAreaStart1.Name = "dtiTimeAreaStart1";
            this.dtiTimeAreaStart1.ShowUpDown = true;
            this.dtiTimeAreaStart1.Size = new System.Drawing.Size(103, 23);
            this.dtiTimeAreaStart1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiTimeAreaStart1.TabIndex = 3;
            this.dtiTimeAreaStart1.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            this.dtiTimeAreaStart1.Value = new System.DateTime(2016, 9, 22, 1, 3, 47, 0);
            // 
            // dtiTimeAreaEnd1
            // 
            // 
            // 
            // 
            this.dtiTimeAreaEnd1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiTimeAreaEnd1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaEnd1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiTimeAreaEnd1.ButtonDropDown.Visible = true;
            this.dtiTimeAreaEnd1.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime;
            this.dtiTimeAreaEnd1.IsPopupCalendarOpen = false;
            this.dtiTimeAreaEnd1.Location = new System.Drawing.Point(176, 21);
            // 
            // 
            // 
            this.dtiTimeAreaEnd1.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeAreaEnd1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaEnd1.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiTimeAreaEnd1.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiTimeAreaEnd1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiTimeAreaEnd1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeAreaEnd1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiTimeAreaEnd1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiTimeAreaEnd1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiTimeAreaEnd1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiTimeAreaEnd1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaEnd1.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            this.dtiTimeAreaEnd1.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtiTimeAreaEnd1.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiTimeAreaEnd1.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeAreaEnd1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiTimeAreaEnd1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeAreaEnd1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiTimeAreaEnd1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaEnd1.MonthCalendar.TodayButtonVisible = true;
            this.dtiTimeAreaEnd1.MonthCalendar.Visible = false;
            this.dtiTimeAreaEnd1.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiTimeAreaEnd1.Name = "dtiTimeAreaEnd1";
            this.dtiTimeAreaEnd1.ShowUpDown = true;
            this.dtiTimeAreaEnd1.Size = new System.Drawing.Size(103, 23);
            this.dtiTimeAreaEnd1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiTimeAreaEnd1.TabIndex = 3;
            this.dtiTimeAreaEnd1.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            this.dtiTimeAreaEnd1.Value = new System.DateTime(2016, 9, 22, 1, 3, 47, 0);
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
            this.labelX7.Location = new System.Drawing.Point(165, 21);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(12, 20);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "-";
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            this.labelX8.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX8.Location = new System.Drawing.Point(17, 51);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(38, 20);
            this.labelX8.TabIndex = 0;
            this.labelX8.Text = "时区2";
            // 
            // labelX9
            // 
            this.labelX9.AutoSize = true;
            this.labelX9.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX9.Location = new System.Drawing.Point(165, 48);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(12, 20);
            this.labelX9.TabIndex = 0;
            this.labelX9.Text = "-";
            // 
            // dtiTimeAreaStart2
            // 
            // 
            // 
            // 
            this.dtiTimeAreaStart2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiTimeAreaStart2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaStart2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiTimeAreaStart2.ButtonDropDown.Visible = true;
            this.dtiTimeAreaStart2.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime;
            this.dtiTimeAreaStart2.IsPopupCalendarOpen = false;
            this.dtiTimeAreaStart2.Location = new System.Drawing.Point(61, 48);
            // 
            // 
            // 
            this.dtiTimeAreaStart2.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeAreaStart2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaStart2.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiTimeAreaStart2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiTimeAreaStart2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiTimeAreaStart2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeAreaStart2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiTimeAreaStart2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiTimeAreaStart2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiTimeAreaStart2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiTimeAreaStart2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaStart2.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            this.dtiTimeAreaStart2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtiTimeAreaStart2.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiTimeAreaStart2.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeAreaStart2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiTimeAreaStart2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeAreaStart2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiTimeAreaStart2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaStart2.MonthCalendar.TodayButtonVisible = true;
            this.dtiTimeAreaStart2.MonthCalendar.Visible = false;
            this.dtiTimeAreaStart2.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiTimeAreaStart2.Name = "dtiTimeAreaStart2";
            this.dtiTimeAreaStart2.ShowUpDown = true;
            this.dtiTimeAreaStart2.Size = new System.Drawing.Size(103, 23);
            this.dtiTimeAreaStart2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiTimeAreaStart2.TabIndex = 3;
            this.dtiTimeAreaStart2.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            this.dtiTimeAreaStart2.Value = new System.DateTime(2016, 9, 22, 1, 3, 47, 0);
            // 
            // dtiTimeAreaEnd2
            // 
            // 
            // 
            // 
            this.dtiTimeAreaEnd2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiTimeAreaEnd2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaEnd2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiTimeAreaEnd2.ButtonDropDown.Visible = true;
            this.dtiTimeAreaEnd2.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime;
            this.dtiTimeAreaEnd2.IsPopupCalendarOpen = false;
            this.dtiTimeAreaEnd2.Location = new System.Drawing.Point(176, 48);
            // 
            // 
            // 
            this.dtiTimeAreaEnd2.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeAreaEnd2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaEnd2.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiTimeAreaEnd2.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiTimeAreaEnd2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiTimeAreaEnd2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeAreaEnd2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiTimeAreaEnd2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiTimeAreaEnd2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiTimeAreaEnd2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiTimeAreaEnd2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaEnd2.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            this.dtiTimeAreaEnd2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtiTimeAreaEnd2.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiTimeAreaEnd2.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeAreaEnd2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiTimeAreaEnd2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeAreaEnd2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiTimeAreaEnd2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaEnd2.MonthCalendar.TodayButtonVisible = true;
            this.dtiTimeAreaEnd2.MonthCalendar.Visible = false;
            this.dtiTimeAreaEnd2.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiTimeAreaEnd2.Name = "dtiTimeAreaEnd2";
            this.dtiTimeAreaEnd2.ShowUpDown = true;
            this.dtiTimeAreaEnd2.Size = new System.Drawing.Size(103, 23);
            this.dtiTimeAreaEnd2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiTimeAreaEnd2.TabIndex = 3;
            this.dtiTimeAreaEnd2.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            this.dtiTimeAreaEnd2.Value = new System.DateTime(2016, 9, 22, 1, 3, 47, 0);
            // 
            // labelX10
            // 
            this.labelX10.AutoSize = true;
            this.labelX10.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX10.Location = new System.Drawing.Point(17, 77);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(38, 20);
            this.labelX10.TabIndex = 0;
            this.labelX10.Text = "时区3";
            // 
            // labelX11
            // 
            this.labelX11.AutoSize = true;
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX11.Location = new System.Drawing.Point(165, 74);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(12, 20);
            this.labelX11.TabIndex = 0;
            this.labelX11.Text = "-";
            // 
            // dtiTimeAreaStart3
            // 
            // 
            // 
            // 
            this.dtiTimeAreaStart3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiTimeAreaStart3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaStart3.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiTimeAreaStart3.ButtonDropDown.Visible = true;
            this.dtiTimeAreaStart3.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime;
            this.dtiTimeAreaStart3.IsPopupCalendarOpen = false;
            this.dtiTimeAreaStart3.Location = new System.Drawing.Point(61, 74);
            // 
            // 
            // 
            this.dtiTimeAreaStart3.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeAreaStart3.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaStart3.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiTimeAreaStart3.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiTimeAreaStart3.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiTimeAreaStart3.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeAreaStart3.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiTimeAreaStart3.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiTimeAreaStart3.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiTimeAreaStart3.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiTimeAreaStart3.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaStart3.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            this.dtiTimeAreaStart3.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtiTimeAreaStart3.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiTimeAreaStart3.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeAreaStart3.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiTimeAreaStart3.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeAreaStart3.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiTimeAreaStart3.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaStart3.MonthCalendar.TodayButtonVisible = true;
            this.dtiTimeAreaStart3.MonthCalendar.Visible = false;
            this.dtiTimeAreaStart3.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiTimeAreaStart3.Name = "dtiTimeAreaStart3";
            this.dtiTimeAreaStart3.ShowUpDown = true;
            this.dtiTimeAreaStart3.Size = new System.Drawing.Size(103, 23);
            this.dtiTimeAreaStart3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiTimeAreaStart3.TabIndex = 3;
            this.dtiTimeAreaStart3.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            this.dtiTimeAreaStart3.Value = new System.DateTime(2016, 9, 22, 1, 3, 47, 0);
            // 
            // dtiTimeAreaEnd3
            // 
            // 
            // 
            // 
            this.dtiTimeAreaEnd3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiTimeAreaEnd3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaEnd3.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiTimeAreaEnd3.ButtonDropDown.Visible = true;
            this.dtiTimeAreaEnd3.Format = DevComponents.Editors.eDateTimePickerFormat.LongTime;
            this.dtiTimeAreaEnd3.IsPopupCalendarOpen = false;
            this.dtiTimeAreaEnd3.Location = new System.Drawing.Point(176, 74);
            // 
            // 
            // 
            this.dtiTimeAreaEnd3.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeAreaEnd3.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaEnd3.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiTimeAreaEnd3.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiTimeAreaEnd3.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiTimeAreaEnd3.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeAreaEnd3.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiTimeAreaEnd3.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiTimeAreaEnd3.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiTimeAreaEnd3.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiTimeAreaEnd3.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaEnd3.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            this.dtiTimeAreaEnd3.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtiTimeAreaEnd3.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiTimeAreaEnd3.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiTimeAreaEnd3.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiTimeAreaEnd3.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiTimeAreaEnd3.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiTimeAreaEnd3.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiTimeAreaEnd3.MonthCalendar.TodayButtonVisible = true;
            this.dtiTimeAreaEnd3.MonthCalendar.Visible = false;
            this.dtiTimeAreaEnd3.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiTimeAreaEnd3.Name = "dtiTimeAreaEnd3";
            this.dtiTimeAreaEnd3.ShowUpDown = true;
            this.dtiTimeAreaEnd3.Size = new System.Drawing.Size(103, 23);
            this.dtiTimeAreaEnd3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiTimeAreaEnd3.TabIndex = 3;
            this.dtiTimeAreaEnd3.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            this.dtiTimeAreaEnd3.Value = new System.DateTime(2016, 9, 22, 1, 3, 47, 0);
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
            this.groupPanel1.Location = new System.Drawing.Point(26, 152);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(192, 200);
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
            this.groupPanel1.TabIndex = 5;
            this.groupPanel1.Text = "有效星期";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dtiTimeAreaStart1);
            this.groupPanel2.Controls.Add(this.labelX6);
            this.groupPanel2.Controls.Add(this.dtiTimeAreaEnd3);
            this.groupPanel2.Controls.Add(this.labelX7);
            this.groupPanel2.Controls.Add(this.dtiTimeAreaStart3);
            this.groupPanel2.Controls.Add(this.labelX8);
            this.groupPanel2.Controls.Add(this.dtiTimeAreaEnd2);
            this.groupPanel2.Controls.Add(this.labelX10);
            this.groupPanel2.Controls.Add(this.dtiTimeAreaStart2);
            this.groupPanel2.Controls.Add(this.labelX9);
            this.groupPanel2.Controls.Add(this.dtiTimeAreaEnd1);
            this.groupPanel2.Controls.Add(this.labelX11);
            this.groupPanel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel2.Location = new System.Drawing.Point(244, 152);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(286, 200);
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
            this.groupPanel2.TabIndex = 6;
            this.groupPanel2.Text = "有效时区";
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(188, 367);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 31);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(276, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.dtpStartDate);
            this.groupPanel3.Controls.Add(this.labelX3);
            this.groupPanel3.Controls.Add(this.labelX4);
            this.groupPanel3.Controls.Add(this.dtpEndDate);
            this.groupPanel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel3.Location = new System.Drawing.Point(26, 54);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(192, 92);
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
            this.groupPanel3.TabIndex = 8;
            this.groupPanel3.Text = "日期范围";
            // 
            // groupPanel4
            // 
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.cbTimeNo);
            this.groupPanel4.Controls.Add(this.labelX1);
            this.groupPanel4.Controls.Add(this.labelX5);
            this.groupPanel4.Controls.Add(this.cbNextTimeNo);
            this.groupPanel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel4.Location = new System.Drawing.Point(244, 54);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(286, 92);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 8;
            this.groupPanel4.Text = "时段号";
            // 
            // FrmInOutTimeEditor
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(560, 402);
            this.Controls.Add(this.groupPanel4);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labelX2);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInOutTimeEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "时段添加或编辑";
            this.Load += new System.EventHandler(this.FrmInOutTimeEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeAreaStart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeAreaEnd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeAreaStart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeAreaEnd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeAreaStart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiTimeAreaEnd3)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbTimeNo;
        private DevComponents.DotNetBar.Controls.TextBoxX tbName;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpStartDate;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpEndDate;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbNextTimeNo;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek2;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek3;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek4;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek5;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek6;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbWeek7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiTimeAreaStart1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiTimeAreaEnd1;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiTimeAreaStart2;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiTimeAreaEnd2;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiTimeAreaStart3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiTimeAreaEnd3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
    }
}