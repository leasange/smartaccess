﻿namespace SmartAccess.VerInfoMgr
{
    partial class FaceDevPriMgr
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.advTree = new Li.Controls.AdvTreeEx();
            this.node1 = new DevComponents.AdvTree.Node();
            this.node2 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.tbFilter = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.pageDataGridView = new Li.Controls.PageDataGridView();
            this.dgvStaffs = new Li.Controls.DataGridViewEx();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Pic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_DELETE = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Col_SC = new Li.Controls.DataGridViewLinkLabelColumn();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.biAddPrivate = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteSelect = new DevComponents.DotNetBar.ButtonItem();
            this.biUploadSelect = new DevComponents.DotNetBar.ButtonItem();
            this.biOneKeyUpload = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.tbName = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.tbDeptName = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem5 = new DevComponents.DotNetBar.LabelItem();
            this.tbStaffNo = new DevComponents.DotNetBar.TextBoxItem();
            this.biDoSearch = new DevComponents.DotNetBar.ButtonItem();
            this.biClear = new DevComponents.DotNetBar.ButtonItem();
            this.dtpValidTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.labelItem7 = new DevComponents.DotNetBar.LabelItem();
            this.tbJob = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem6 = new DevComponents.DotNetBar.LabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.pageDataGridView.DataGridPanel.SuspendLayout();
            this.pageDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpValidTime)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.advTree);
            this.splitContainer1.Panel1.Controls.Add(this.panelEx1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pageDataGridView);
            this.splitContainer1.Panel2.Controls.Add(this.bar2);
            this.splitContainer1.Size = new System.Drawing.Size(1130, 385);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.TabIndex = 0;
            // 
            // advTree
            // 
            this.advTree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree.AllowDrop = true;
            this.advTree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree.CheckBoxVisible = true;
            this.advTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.advTree.Location = new System.Drawing.Point(0, 25);
            this.advTree.MultiSelect = true;
            this.advTree.Name = "advTree";
            this.advTree.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advTree.NodesConnector = this.nodeConnector1;
            this.advTree.NodeStyle = this.elementStyle1;
            this.advTree.PathSeparator = ";";
            this.advTree.SelectionPerCell = true;
            this.advTree.Size = new System.Drawing.Size(217, 360);
            this.advTree.Styles.Add(this.elementStyle1);
            this.advTree.TabIndex = 5;
            this.advTree.Text = "advTreeEx1";
            this.advTree.AfterCheck += new DevComponents.AdvTree.AdvTreeCellEventHandler(this.advTree_AfterCheck);
            // 
            // node1
            // 
            this.node1.CheckBoxVisible = true;
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node2});
            this.node1.Text = "区域1";
            // 
            // node2
            // 
            this.node2.CheckBoxVisible = true;
            this.node2.Expanded = true;
            this.node2.Name = "node2";
            this.node2.Text = "人脸设备";
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
            this.panelEx1.Controls.Add(this.tbFilter);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(217, 25);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 4;
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbFilter.Border.Class = "TextBoxBorder";
            this.tbFilter.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbFilter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbFilter.Location = new System.Drawing.Point(44, 1);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(170, 23);
            this.tbFilter.TabIndex = 2;
            this.tbFilter.WatermarkText = "输入关键字或拼音首字符";
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(38, 25);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "过滤";
            // 
            // pageDataGridView
            // 
            this.pageDataGridView.BackColor = System.Drawing.Color.GhostWhite;
            // 
            // pageDataGridView.DataGridPanel
            // 
            this.pageDataGridView.DataGridPanel.Controls.Add(this.dgvStaffs);
            this.pageDataGridView.DataGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDataGridView.DataGridPanel.Location = new System.Drawing.Point(0, 0);
            this.pageDataGridView.DataGridPanel.Name = "DataGridPanel";
            this.pageDataGridView.DataGridPanel.Size = new System.Drawing.Size(909, 324);
            this.pageDataGridView.DataGridPanel.TabIndex = 1;
            this.pageDataGridView.DataGridView = this.dgvStaffs;
            this.pageDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDataGridView.Location = new System.Drawing.Point(0, 29);
            this.pageDataGridView.Name = "pageDataGridView";
            // 
            // pageDataGridView.PageControl
            // 
            this.pageDataGridView.PageControl.CurrentPage = 1;
            this.pageDataGridView.PageControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageDataGridView.PageControl.ExportButtonVisible = false;
            this.pageDataGridView.PageControl.Location = new System.Drawing.Point(0, 324);
            this.pageDataGridView.PageControl.Name = "PageControl";
            this.pageDataGridView.PageControl.RecordsPerPage = 100;
            this.pageDataGridView.PageControl.Size = new System.Drawing.Size(909, 32);
            this.pageDataGridView.PageControl.TabIndex = 0;
            this.pageDataGridView.PageControl.TotalRecords = 0;
            this.pageDataGridView.PageControl.PageChanged += new Li.Controls.PageCtrl.PageEventHandle(this.pageDataGridView_PageControl_PageChanged);
            this.pageDataGridView.Size = new System.Drawing.Size(909, 356);
            this.pageDataGridView.SqlWhere = null;
            this.pageDataGridView.TabIndex = 4;
            // 
            // dgvStaffs
            // 
            this.dgvStaffs.AllowUserToAddRows = false;
            this.dgvStaffs.AllowUserToDeleteRows = false;
            this.dgvStaffs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaffs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStaffs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column8,
            this.Col_Pic,
            this.Col_DELETE,
            this.Col_SC});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStaffs.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStaffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaffs.EnableHeadersVisualStyles = false;
            this.dgvStaffs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvStaffs.Location = new System.Drawing.Point(0, 0);
            this.dgvStaffs.Name = "dgvStaffs";
            this.dgvStaffs.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaffs.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStaffs.RowTemplate.Height = 23;
            this.dgvStaffs.Size = new System.Drawing.Size(909, 324);
            this.dgvStaffs.TabIndex = 3;
            this.dgvStaffs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaffs_CellContentClick);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "人脸设备";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 47.90625F;
            this.Column1.HeaderText = "证件编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 47.90625F;
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 47.90625F;
            this.Column3.HeaderText = "部门";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 47.90625F;
            this.Column6.HeaderText = "状态";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 47.90625F;
            this.Column8.HeaderText = "有效期";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Col_Pic
            // 
            this.Col_Pic.FillWeight = 24.42989F;
            this.Col_Pic.HeaderText = "照片";
            this.Col_Pic.Name = "Col_Pic";
            this.Col_Pic.ReadOnly = true;
            this.Col_Pic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col_Pic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Col_DELETE
            // 
            this.Col_DELETE.FillWeight = 24.42989F;
            this.Col_DELETE.HeaderText = "删除";
            this.Col_DELETE.Name = "Col_DELETE";
            this.Col_DELETE.ReadOnly = true;
            this.Col_DELETE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col_DELETE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Col_SC
            // 
            this.Col_SC.FillWeight = 24.42989F;
            this.Col_SC.HeaderText = "上传";
            this.Col_SC.Name = "Col_SC";
            this.Col_SC.ReadOnly = true;
            this.Col_SC.SplitLinkSymbol = ",";
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biAddPrivate,
            this.biDeleteSelect,
            this.biUploadSelect,
            this.biOneKeyUpload,
            this.labelItem1,
            this.tbName,
            this.labelItem2,
            this.tbDeptName,
            this.labelItem5,
            this.tbStaffNo,
            this.biDoSearch,
            this.biClear});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(909, 29);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 2;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // biAddPrivate
            // 
            this.biAddPrivate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAddPrivate.Image = global::SmartAccess.Properties.Resources.一键上传;
            this.biAddPrivate.Name = "biAddPrivate";
            this.biAddPrivate.Text = "添加权限";
            this.biAddPrivate.Click += new System.EventHandler(this.biAddPrivate_Click);
            // 
            // biDeleteSelect
            // 
            this.biDeleteSelect.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDeleteSelect.Image = global::SmartAccess.Properties.Resources.删除;
            this.biDeleteSelect.Name = "biDeleteSelect";
            this.biDeleteSelect.Text = "删除选择权限";
            this.biDeleteSelect.Click += new System.EventHandler(this.biDeleteSelect_Click);
            // 
            // biUploadSelect
            // 
            this.biUploadSelect.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biUploadSelect.Image = global::SmartAccess.Properties.Resources.一键上传;
            this.biUploadSelect.Name = "biUploadSelect";
            this.biUploadSelect.Text = "上传选择权限";
            this.biUploadSelect.Click += new System.EventHandler(this.biUploadSelect_Click);
            // 
            // biOneKeyUpload
            // 
            this.biOneKeyUpload.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biOneKeyUpload.Image = global::SmartAccess.Properties.Resources.一键上传;
            this.biOneKeyUpload.Name = "biOneKeyUpload";
            this.biOneKeyUpload.Text = "上传所有权限";
            this.biOneKeyUpload.Click += new System.EventHandler(this.biOneKeyUpload_Click);
            // 
            // labelItem1
            // 
            this.labelItem1.ForeColor = System.Drawing.Color.Black;
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "姓名";
            // 
            // tbName
            // 
            this.tbName.Name = "tbName";
            this.tbName.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.tbName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyUp);
            // 
            // labelItem2
            // 
            this.labelItem2.ForeColor = System.Drawing.Color.Black;
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "部门";
            // 
            // tbDeptName
            // 
            this.tbDeptName.Name = "tbDeptName";
            this.tbDeptName.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.tbDeptName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyUp);
            // 
            // labelItem5
            // 
            this.labelItem5.ForeColor = System.Drawing.Color.Black;
            this.labelItem5.Name = "labelItem5";
            this.labelItem5.Text = "证件号";
            // 
            // tbStaffNo
            // 
            this.tbStaffNo.Name = "tbStaffNo";
            this.tbStaffNo.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.tbStaffNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyUp);
            // 
            // biDoSearch
            // 
            this.biDoSearch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDoSearch.Image = global::SmartAccess.Properties.Resources.查询;
            this.biDoSearch.Name = "biDoSearch";
            this.biDoSearch.Text = "查询";
            this.biDoSearch.Click += new System.EventHandler(this.biDoSearch_Click);
            // 
            // biClear
            // 
            this.biClear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biClear.Image = global::SmartAccess.Properties.Resources.删除;
            this.biClear.Name = "biClear";
            this.biClear.Text = "清空";
            this.biClear.Click += new System.EventHandler(this.biClear_Click);
            // 
            // dtpValidTime
            // 
            // 
            // 
            // 
            this.dtpValidTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpValidTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpValidTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpValidTime.ButtonDropDown.Visible = true;
            this.dtpValidTime.IsPopupCalendarOpen = false;
            this.dtpValidTime.Location = new System.Drawing.Point(313, 3);
            // 
            // 
            // 
            this.dtpValidTime.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpValidTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpValidTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtpValidTime.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtpValidTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtpValidTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpValidTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtpValidTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtpValidTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtpValidTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtpValidTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpValidTime.MonthCalendar.DisplayMonth = new System.DateTime(2016, 6, 1, 0, 0, 0, 0);
            this.dtpValidTime.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtpValidTime.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpValidTime.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpValidTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtpValidTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtpValidTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtpValidTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpValidTime.MonthCalendar.TodayButtonVisible = true;
            this.dtpValidTime.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpValidTime.Name = "dtpValidTime";
            this.dtpValidTime.Size = new System.Drawing.Size(90, 21);
            this.dtpValidTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpValidTime.TabIndex = 2;
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.dtpValidTime;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // labelItem7
            // 
            this.labelItem7.ForeColor = System.Drawing.Color.Black;
            this.labelItem7.Name = "labelItem7";
            this.labelItem7.Text = "有效期";
            // 
            // tbJob
            // 
            this.tbJob.Name = "tbJob";
            this.tbJob.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // labelItem6
            // 
            this.labelItem6.ForeColor = System.Drawing.Color.Black;
            this.labelItem6.Name = "labelItem6";
            this.labelItem6.Text = "职务";
            // 
            // FaceDevPriMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FaceDevPriMgr";
            this.Size = new System.Drawing.Size(1130, 385);
            this.Load += new System.EventHandler(this.FaceDevPriMgr_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.pageDataGridView.DataGridPanel.ResumeLayout(false);
            this.pageDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpValidTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Li.Controls.AdvTreeEx advTree;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbFilter;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem tbName;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.TextBoxItem tbDeptName;
        private DevComponents.DotNetBar.LabelItem labelItem5;
        private DevComponents.DotNetBar.TextBoxItem tbStaffNo;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.ButtonItem biDoSearch;
        private DevComponents.DotNetBar.ButtonItem biClear;
        private Li.Controls.DataGridViewEx dgvStaffs;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpValidTime;
        private DevComponents.DotNetBar.LabelItem labelItem7;
        private DevComponents.DotNetBar.TextBoxItem tbJob;
        private DevComponents.DotNetBar.LabelItem labelItem6;
        private DevComponents.DotNetBar.ButtonItem biUploadSelect;
        private DevComponents.DotNetBar.ButtonItem biOneKeyUpload;
        private DevComponents.DotNetBar.ButtonItem biAddPrivate;
        private Li.Controls.PageDataGridView pageDataGridView;
        private DevComponents.DotNetBar.ButtonItem biDeleteSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Pic;
        private System.Windows.Forms.DataGridViewLinkColumn Col_DELETE;
        private Li.Controls.DataGridViewLinkLabelColumn Col_SC;
    }
}