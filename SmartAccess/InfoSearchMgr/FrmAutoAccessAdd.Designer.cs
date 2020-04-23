namespace SmartAccess.InfoSearchMgr
{
    partial class FrmAutoAccessAdd
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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tbNum = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbTitle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dtpEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.dtpStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.advMemTree = new Li.Controls.AdvTreeEx();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.tbMemFilter = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.doorTree = new SmartAccess.VerInfoMgr.DoorTree();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advMemTree)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(26, 14);
            this.labelX2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 20);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "授权编号";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(335, 13);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(31, 20);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "标题";
            // 
            // tbNum
            // 
            // 
            // 
            // 
            this.tbNum.Border.Class = "TextBoxBorder";
            this.tbNum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbNum.Location = new System.Drawing.Point(84, 11);
            this.tbNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbNum.Name = "tbNum";
            this.tbNum.ReadOnly = true;
            this.tbNum.Size = new System.Drawing.Size(226, 23);
            this.tbNum.TabIndex = 2;
            // 
            // tbTitle
            // 
            // 
            // 
            // 
            this.tbTitle.Border.Class = "TextBoxBorder";
            this.tbTitle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbTitle.Location = new System.Drawing.Point(372, 11);
            this.tbTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(248, 23);
            this.tbTitle.TabIndex = 2;
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
            this.dtpEnd.Location = new System.Drawing.Point(372, 41);
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
            this.dtpEnd.Size = new System.Drawing.Size(248, 23);
            this.dtpEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpEnd.TabIndex = 7;
            this.dtpEnd.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(335, 42);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(20, 23);
            this.labelX6.TabIndex = 5;
            this.labelX6.Text = "~";
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
            this.dtpStart.Location = new System.Drawing.Point(84, 42);
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
            this.dtpStart.Size = new System.Drawing.Size(226, 23);
            this.dtpStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpStart.TabIndex = 8;
            this.dtpStart.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(26, 44);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(56, 20);
            this.labelX5.TabIndex = 6;
            this.labelX5.Text = "授权时间";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(26, 74);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(56, 20);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "授权人员";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(335, 74);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(56, 20);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "授权门禁";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(335, 414);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 32);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(219, 414);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 32);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // advMemTree
            // 
            this.advMemTree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advMemTree.AllowDrop = true;
            this.advMemTree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advMemTree.BackgroundStyle.Class = "TreeBorderKey";
            this.advMemTree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advMemTree.CheckBoxVisible = true;
            this.advMemTree.Location = new System.Drawing.Point(29, 120);
            this.advMemTree.Name = "advMemTree";
            this.advMemTree.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advMemTree.NodesConnector = this.nodeConnector1;
            this.advMemTree.NodeStyle = this.elementStyle1;
            this.advMemTree.PathSeparator = ";";
            this.advMemTree.SelectionPerCell = true;
            this.advMemTree.Size = new System.Drawing.Size(281, 287);
            this.advMemTree.Styles.Add(this.elementStyle1);
            this.advMemTree.TabIndex = 13;
            this.advMemTree.Text = "advTreeEx1";
            this.advMemTree.NodeMouseUp += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.Tree_NodeMouseUp);
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
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.tbMemFilter);
            this.panelEx1.Controls.Add(this.labelX7);
            this.panelEx1.Location = new System.Drawing.Point(29, 94);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(281, 27);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 14;
            // 
            // tbMemFilter
            // 
            // 
            // 
            // 
            this.tbMemFilter.Border.Class = "TextBoxBorder";
            this.tbMemFilter.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbMemFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMemFilter.Location = new System.Drawing.Point(42, 0);
            this.tbMemFilter.Multiline = true;
            this.tbMemFilter.Name = "tbMemFilter";
            this.tbMemFilter.Size = new System.Drawing.Size(239, 27);
            this.tbMemFilter.TabIndex = 1;
            this.tbMemFilter.WatermarkText = "输入关键字或拼音首字符";
            this.tbMemFilter.TextChanged += new System.EventHandler(this.tbMemFilter_TextChanged);
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX7.Location = new System.Drawing.Point(0, 0);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(42, 27);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "过滤";
            // 
            // doorTree
            // 
            this.doorTree.CheckBoxVisible = true;
            this.doorTree.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doorTree.IsVisitor = false;
            this.doorTree.Location = new System.Drawing.Point(335, 94);
            this.doorTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.doorTree.Name = "doorTree";
            this.doorTree.Size = new System.Drawing.Size(285, 314);
            this.doorTree.TabIndex = 10;
            // 
            // FrmAutoAccessAdd
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(658, 458);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.advMemTree);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.doorTree);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.tbNum);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAutoAccessAdd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加自动授权";
            this.Load += new System.EventHandler(this.FrmAutoAccessAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advMemTree)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbNum;
        private DevComponents.DotNetBar.Controls.TextBoxX tbTitle;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpEnd;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpStart;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX3;
        private VerInfoMgr.DoorTree doorTree;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private Li.Controls.AdvTreeEx advMemTree;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX tbMemFilter;
    }
}