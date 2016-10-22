namespace SmartKey
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biNT158Tool = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.tbAppID = new DevComponents.DotNetBar.TextBoxItem();
            this.biResetAppID = new DevComponents.DotNetBar.ButtonItem();
            this.biRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.tbPin1 = new DevComponents.DotNetBar.TextBoxItem();
            this.tbPin2 = new DevComponents.DotNetBar.TextBoxItem();
            this.tbPin3 = new DevComponents.DotNetBar.TextBoxItem();
            this.tbPin4 = new DevComponents.DotNetBar.TextBoxItem();
            this.dogListTree = new Li.Controls.AdvTreeEx();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelPrivate = new DevComponents.DotNetBar.PanelEx();
            this.dtiStartTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.tbDogName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dtiEndTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.lbTimePrivate = new DevComponents.DotNetBar.LabelX();
            this.btnSetOneMonth = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSet3Month = new DevComponents.DotNetBar.ButtonX();
            this.btnSetHalfYear = new DevComponents.DotNetBar.ButtonX();
            this.btnSetOneYear = new DevComponents.DotNetBar.ButtonX();
            this.btnSet3Year = new DevComponents.DotNetBar.ButtonX();
            this.btnSet5Year = new DevComponents.DotNetBar.ButtonX();
            this.btnSet10Year = new DevComponents.DotNetBar.ButtonX();
            this.btnSet30Year = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.biExportKeyFile = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.tbSeed = new DevComponents.DotNetBar.TextBoxItem();
            this.sfdKeyDialog = new System.Windows.Forms.SaveFileDialog();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.lbDevNo = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dogListTree)).BeginInit();
            this.panelPrivate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtiStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiEndTime)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biNT158Tool,
            this.labelItem2,
            this.labelItem1,
            this.tbAppID,
            this.biResetAppID,
            this.biRefresh,
            this.labelItem4,
            this.tbSeed,
            this.labelItem3,
            this.tbPin1,
            this.tbPin2,
            this.tbPin3,
            this.tbPin4,
            this.biExportKeyFile});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1155, 26);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biNT158Tool
            // 
            this.biNT158Tool.Name = "biNT158Tool";
            this.biNT158Tool.Text = "NT158官方工具";
            this.biNT158Tool.Click += new System.EventHandler(this.biNT158Tool_Click);
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "|";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "识别码:";
            // 
            // tbAppID
            // 
            this.tbAppID.MaxLength = 32;
            this.tbAppID.Name = "tbAppID";
            this.tbAppID.TextBoxWidth = 124;
            this.tbAppID.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // biResetAppID
            // 
            this.biResetAppID.Name = "biResetAppID";
            this.biResetAppID.Text = "重置默认识别码";
            this.biResetAppID.Click += new System.EventHandler(this.biResetAppID_Click);
            // 
            // biRefresh
            // 
            this.biRefresh.Name = "biRefresh";
            this.biRefresh.Text = "刷新列表";
            this.biRefresh.Click += new System.EventHandler(this.biRefresh_Click);
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "登陆密码:";
            // 
            // tbPin1
            // 
            this.tbPin1.Name = "tbPin1";
            this.tbPin1.TextBoxWidth = 85;
            this.tbPin1.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // tbPin2
            // 
            this.tbPin2.Name = "tbPin2";
            this.tbPin2.TextBoxWidth = 85;
            this.tbPin2.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // tbPin3
            // 
            this.tbPin3.Name = "tbPin3";
            this.tbPin3.TextBoxWidth = 85;
            this.tbPin3.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // tbPin4
            // 
            this.tbPin4.Name = "tbPin4";
            this.tbPin4.TextBoxWidth = 85;
            this.tbPin4.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // dogListTree
            // 
            this.dogListTree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.dogListTree.AllowDrop = true;
            this.dogListTree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.dogListTree.BackgroundStyle.Class = "TreeBorderKey";
            this.dogListTree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dogListTree.CheckBoxVisible = false;
            this.dogListTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.dogListTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dogListTree.Location = new System.Drawing.Point(0, 26);
            this.dogListTree.Name = "dogListTree";
            this.dogListTree.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.dogListTree.NodesConnector = this.nodeConnector1;
            this.dogListTree.NodeStyle = this.elementStyle1;
            this.dogListTree.PathSeparator = ";";
            this.dogListTree.SelectionPerCell = true;
            this.dogListTree.Size = new System.Drawing.Size(284, 420);
            this.dogListTree.Styles.Add(this.elementStyle1);
            this.dogListTree.TabIndex = 1;
            this.dogListTree.Text = "advTreeEx1";
            this.dogListTree.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.dogListTree_NodeClick);
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Text = "所有连接的加密狗";
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
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(60)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(284, 26);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 420);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 2;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelPrivate
            // 
            this.panelPrivate.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelPrivate.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelPrivate.Controls.Add(this.btnOk);
            this.panelPrivate.Controls.Add(this.groupPanel1);
            this.panelPrivate.Controls.Add(this.lbDevNo);
            this.panelPrivate.Controls.Add(this.lbTimePrivate);
            this.panelPrivate.Controls.Add(this.dtiEndTime);
            this.panelPrivate.Controls.Add(this.dtiStartTime);
            this.panelPrivate.Controls.Add(this.tbDogName);
            this.panelPrivate.Controls.Add(this.labelX3);
            this.panelPrivate.Controls.Add(this.labelX4);
            this.panelPrivate.Controls.Add(this.labelX2);
            this.panelPrivate.Controls.Add(this.labelX5);
            this.panelPrivate.Controls.Add(this.labelX1);
            this.panelPrivate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrivate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelPrivate.Location = new System.Drawing.Point(290, 26);
            this.panelPrivate.Name = "panelPrivate";
            this.panelPrivate.Size = new System.Drawing.Size(865, 420);
            this.panelPrivate.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelPrivate.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelPrivate.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelPrivate.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelPrivate.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelPrivate.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelPrivate.Style.GradientAngle = 90;
            this.panelPrivate.TabIndex = 3;
            // 
            // dtiStartTime
            // 
            this.dtiStartTime.AllowEmptyState = false;
            // 
            // 
            // 
            this.dtiStartTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiStartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiStartTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiStartTime.ButtonDropDown.Visible = true;
            this.dtiStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtiStartTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtiStartTime.IsPopupCalendarOpen = false;
            this.dtiStartTime.Location = new System.Drawing.Point(123, 183);
            // 
            // 
            // 
            this.dtiStartTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiStartTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiStartTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiStartTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiStartTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiStartTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiStartTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiStartTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiStartTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 10, 1, 0, 0, 0, 0);
            this.dtiStartTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtiStartTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiStartTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiStartTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiStartTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiStartTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiStartTime.MonthCalendar.TodayButtonVisible = true;
            this.dtiStartTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiStartTime.Name = "dtiStartTime";
            this.dtiStartTime.Size = new System.Drawing.Size(259, 23);
            this.dtiStartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiStartTime.TabIndex = 2;
            // 
            // tbDogName
            // 
            // 
            // 
            // 
            this.tbDogName.Border.Class = "TextBoxBorder";
            this.tbDogName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDogName.Location = new System.Drawing.Point(123, 59);
            this.tbDogName.MaxLength = 64;
            this.tbDogName.Multiline = true;
            this.tbDogName.Name = "tbDogName";
            this.tbDogName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDogName.Size = new System.Drawing.Size(259, 80);
            this.tbDogName.TabIndex = 1;
            this.tbDogName.WatermarkText = "输入名称作为加密狗的身份标识或者介绍";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(26, 219);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(86, 28);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "有效结束时间";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(26, 183);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(86, 28);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "有效开始时间";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(26, 59);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(77, 28);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "身份名称";
            // 
            // dtiEndTime
            // 
            this.dtiEndTime.AllowEmptyState = false;
            // 
            // 
            // 
            this.dtiEndTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiEndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiEndTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiEndTime.ButtonDropDown.Visible = true;
            this.dtiEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtiEndTime.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtiEndTime.IsPopupCalendarOpen = false;
            this.dtiEndTime.Location = new System.Drawing.Point(123, 219);
            // 
            // 
            // 
            this.dtiEndTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiEndTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiEndTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiEndTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiEndTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiEndTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiEndTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiEndTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiEndTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 10, 1, 0, 0, 0, 0);
            this.dtiEndTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtiEndTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtiEndTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtiEndTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiEndTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiEndTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiEndTime.MonthCalendar.TodayButtonVisible = true;
            this.dtiEndTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtiEndTime.Name = "dtiEndTime";
            this.dtiEndTime.Size = new System.Drawing.Size(259, 23);
            this.dtiEndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiEndTime.TabIndex = 2;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(26, 141);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(86, 28);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "最后授权时间";
            // 
            // lbTimePrivate
            // 
            this.lbTimePrivate.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTimePrivate.Location = new System.Drawing.Point(123, 145);
            this.lbTimePrivate.Name = "lbTimePrivate";
            this.lbTimePrivate.Size = new System.Drawing.Size(128, 20);
            this.lbTimePrivate.TabIndex = 3;
            this.lbTimePrivate.Text = "2000-12-12 12:00:00";
            // 
            // btnSetOneMonth
            // 
            this.btnSetOneMonth.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetOneMonth.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetOneMonth.Location = new System.Drawing.Point(19, 22);
            this.btnSetOneMonth.Name = "btnSetOneMonth";
            this.btnSetOneMonth.Size = new System.Drawing.Size(79, 24);
            this.btnSetOneMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetOneMonth.TabIndex = 4;
            this.btnSetOneMonth.Text = "一个月";
            this.btnSetOneMonth.Click += new System.EventHandler(this.btnSetOneMonth_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnSet30Year);
            this.groupPanel1.Controls.Add(this.btnSet10Year);
            this.groupPanel1.Controls.Add(this.btnSet5Year);
            this.groupPanel1.Controls.Add(this.btnSet3Year);
            this.groupPanel1.Controls.Add(this.btnSetOneYear);
            this.groupPanel1.Controls.Add(this.btnSetHalfYear);
            this.groupPanel1.Controls.Add(this.btnSet3Month);
            this.groupPanel1.Controls.Add(this.btnSetOneMonth);
            this.groupPanel1.Location = new System.Drawing.Point(410, 59);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(214, 183);
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
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
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
            this.groupPanel1.Text = "快速设置有效期";
            // 
            // btnSet3Month
            // 
            this.btnSet3Month.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSet3Month.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSet3Month.Location = new System.Drawing.Point(104, 22);
            this.btnSet3Month.Name = "btnSet3Month";
            this.btnSet3Month.Size = new System.Drawing.Size(79, 24);
            this.btnSet3Month.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSet3Month.TabIndex = 4;
            this.btnSet3Month.Text = "三个月";
            this.btnSet3Month.Click += new System.EventHandler(this.btnSet3Month_Click);
            // 
            // btnSetHalfYear
            // 
            this.btnSetHalfYear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetHalfYear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetHalfYear.Location = new System.Drawing.Point(19, 52);
            this.btnSetHalfYear.Name = "btnSetHalfYear";
            this.btnSetHalfYear.Size = new System.Drawing.Size(79, 24);
            this.btnSetHalfYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetHalfYear.TabIndex = 4;
            this.btnSetHalfYear.Text = "半年";
            this.btnSetHalfYear.Click += new System.EventHandler(this.btnSetHalfYear_Click);
            // 
            // btnSetOneYear
            // 
            this.btnSetOneYear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetOneYear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetOneYear.Location = new System.Drawing.Point(104, 52);
            this.btnSetOneYear.Name = "btnSetOneYear";
            this.btnSetOneYear.Size = new System.Drawing.Size(79, 24);
            this.btnSetOneYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetOneYear.TabIndex = 4;
            this.btnSetOneYear.Text = "一年";
            this.btnSetOneYear.Click += new System.EventHandler(this.btnSetOneYear_Click);
            // 
            // btnSet3Year
            // 
            this.btnSet3Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSet3Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSet3Year.Location = new System.Drawing.Point(19, 82);
            this.btnSet3Year.Name = "btnSet3Year";
            this.btnSet3Year.Size = new System.Drawing.Size(79, 24);
            this.btnSet3Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSet3Year.TabIndex = 4;
            this.btnSet3Year.Text = "三年";
            this.btnSet3Year.Click += new System.EventHandler(this.btnSet3Year_Click);
            // 
            // btnSet5Year
            // 
            this.btnSet5Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSet5Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSet5Year.Location = new System.Drawing.Point(104, 82);
            this.btnSet5Year.Name = "btnSet5Year";
            this.btnSet5Year.Size = new System.Drawing.Size(79, 24);
            this.btnSet5Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSet5Year.TabIndex = 4;
            this.btnSet5Year.Text = "五年";
            this.btnSet5Year.Click += new System.EventHandler(this.btnSet5Year_Click);
            // 
            // btnSet10Year
            // 
            this.btnSet10Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSet10Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSet10Year.Location = new System.Drawing.Point(19, 111);
            this.btnSet10Year.Name = "btnSet10Year";
            this.btnSet10Year.Size = new System.Drawing.Size(79, 24);
            this.btnSet10Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSet10Year.TabIndex = 4;
            this.btnSet10Year.Text = "十年";
            this.btnSet10Year.Click += new System.EventHandler(this.btnSet10Year_Click);
            // 
            // btnSet30Year
            // 
            this.btnSet30Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSet30Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSet30Year.Location = new System.Drawing.Point(104, 112);
            this.btnSet30Year.Name = "btnSet30Year";
            this.btnSet30Year.Size = new System.Drawing.Size(79, 24);
            this.btnSet30Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSet30Year.TabIndex = 4;
            this.btnSet30Year.Text = "三十年";
            this.btnSet30Year.Click += new System.EventHandler(this.btnSet30Year_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(123, 283);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(128, 29);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "确定写入授权";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // biExportKeyFile
            // 
            this.biExportKeyFile.Name = "biExportKeyFile";
            this.biExportKeyFile.Text = "导出密钥文件";
            this.biExportKeyFile.Tooltip = "导出密钥文件(已加密)，密钥文件放于客户端下（dogkey.data）一起随客户端打包发布";
            this.biExportKeyFile.Click += new System.EventHandler(this.biExportKeyFile_Click);
            // 
            // labelItem4
            // 
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Text = "密码种子:";
            // 
            // tbSeed
            // 
            this.tbSeed.Name = "tbSeed";
            this.tbSeed.TextBoxWidth = 120;
            this.tbSeed.Tooltip = "密码种子是用于生成登陆密码的随机种子，在官方工具中使用";
            this.tbSeed.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // sfdKeyDialog
            // 
            this.sfdKeyDialog.FileName = "dogkey.data";
            this.sfdKeyDialog.Filter = "密钥文件(*.data)|*.data";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(26, 18);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(77, 28);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "硬件序列号";
            // 
            // lbDevNo
            // 
            this.lbDevNo.AutoSize = true;
            // 
            // 
            // 
            this.lbDevNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbDevNo.Location = new System.Drawing.Point(123, 22);
            this.lbDevNo.Name = "lbDevNo";
            this.lbDevNo.Size = new System.Drawing.Size(128, 20);
            this.lbDevNo.TabIndex = 3;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 446);
            this.Controls.Add(this.panelPrivate);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.dogListTree);
            this.Controls.Add(this.bar1);
            this.DoubleBuffered = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智能门禁加密狗管理工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dogListTree)).EndInit();
            this.panelPrivate.ResumeLayout(false);
            this.panelPrivate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtiStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiEndTime)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private Li.Controls.AdvTreeEx dogListTree;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ButtonItem biRefresh;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem tbAppID;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.PanelEx panelPrivate;
        private DevComponents.DotNetBar.ButtonItem biNT158Tool;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.ButtonItem biResetAppID;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.TextBoxItem tbPin1;
        private DevComponents.DotNetBar.TextBoxItem tbPin2;
        private DevComponents.DotNetBar.TextBoxItem tbPin3;
        private DevComponents.DotNetBar.TextBoxItem tbPin4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDogName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiStartTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiEndTime;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX lbTimePrivate;
        private DevComponents.DotNetBar.ButtonX btnSetOneMonth;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnSet3Month;
        private DevComponents.DotNetBar.ButtonX btnSetHalfYear;
        private DevComponents.DotNetBar.ButtonX btnSetOneYear;
        private DevComponents.DotNetBar.ButtonX btnSet3Year;
        private DevComponents.DotNetBar.ButtonX btnSet5Year;
        private DevComponents.DotNetBar.ButtonX btnSet10Year;
        private DevComponents.DotNetBar.ButtonX btnSet30Year;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonItem biExportKeyFile;
        private DevComponents.DotNetBar.LabelItem labelItem4;
        private DevComponents.DotNetBar.TextBoxItem tbSeed;
        private System.Windows.Forms.SaveFileDialog sfdKeyDialog;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX lbDevNo;
    }
}

