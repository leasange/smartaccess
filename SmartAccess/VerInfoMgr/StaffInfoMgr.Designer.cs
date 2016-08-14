namespace SmartAccess.VerInfoMgr
{
    partial class StaffInfoMgr
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biAddUser = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteStaff = new DevComponents.DotNetBar.ButtonItem();
            this.biReadCard = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteCard = new DevComponents.DotNetBar.ButtonItem();
            this.biChangeCard = new DevComponents.DotNetBar.ButtonItem();
            this.biForbbiden = new DevComponents.DotNetBar.ButtonItem();
            this.biUnForbbiden = new DevComponents.DotNetBar.ButtonItem();
            this.biPrivateCopy = new DevComponents.DotNetBar.ButtonItem();
            this.biExportPhoto = new DevComponents.DotNetBar.ButtonItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.deptTree = new SmartAccess.VerInfoMgr.DeptTree();
            this.pageDataGridView = new Li.Controls.PageDataGridView();
            this.dgvStaffs = new Li.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_CK = new Li.Controls.DataGridViewLinkLabelColumn();
            this.Col_XG = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Col_SQ = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Col_SC = new Li.Controls.DataGridViewLinkLabelColumn();
            this.bar3 = new DevComponents.DotNetBar.Bar();
            this.labelItem8 = new DevComponents.DotNetBar.LabelItem();
            this.cbHasCard = new DevComponents.DotNetBar.CheckBoxItem();
            this.cbHasNoCard = new DevComponents.DotNetBar.CheckBoxItem();
            this.cbIsForbbiden = new DevComponents.DotNetBar.CheckBoxItem();
            this.cbHasDoor = new DevComponents.DotNetBar.CheckBoxItem();
            this.cbHasNoDoor = new DevComponents.DotNetBar.CheckBoxItem();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.dtpValidTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.tbName = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.tbDeptName = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem5 = new DevComponents.DotNetBar.LabelItem();
            this.tbStaffNo = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem6 = new DevComponents.DotNetBar.LabelItem();
            this.tbJob = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem7 = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.biDoSearch = new DevComponents.DotNetBar.ButtonItem();
            this.biClear = new DevComponents.DotNetBar.ButtonItem();
            this.controlContainerItem2 = new DevComponents.DotNetBar.ControlContainerItem();
            this.saveImageDlg = new System.Windows.Forms.SaveFileDialog();
            this.biOneKeyUpload = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pageDataGridView.DataGridPanel.SuspendLayout();
            this.pageDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.bar2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpValidTime)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biAddUser,
            this.biDeleteStaff,
            this.biReadCard,
            this.biDeleteCard,
            this.biChangeCard,
            this.biForbbiden,
            this.biUnForbbiden,
            this.biPrivateCopy,
            this.biOneKeyUpload,
            this.biExportPhoto});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1131, 29);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biAddUser
            // 
            this.biAddUser.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAddUser.Image = global::SmartAccess.Properties.Resources.注册;
            this.biAddUser.Name = "biAddUser";
            this.biAddUser.Text = "注册";
            this.biAddUser.Click += new System.EventHandler(this.biAddUser_Click);
            // 
            // biDeleteStaff
            // 
            this.biDeleteStaff.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDeleteStaff.Image = global::SmartAccess.Properties.Resources.销户;
            this.biDeleteStaff.Name = "biDeleteStaff";
            this.biDeleteStaff.Text = "注销";
            this.biDeleteStaff.Click += new System.EventHandler(this.biDeleteStaff_Click);
            // 
            // biReadCard
            // 
            this.biReadCard.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biReadCard.Image = global::SmartAccess.Properties.Resources.editor;
            this.biReadCard.Name = "biReadCard";
            this.biReadCard.Text = "读卡";
            this.biReadCard.Click += new System.EventHandler(this.biReadCard_Click);
            // 
            // biDeleteCard
            // 
            this.biDeleteCard.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDeleteCard.Image = global::SmartAccess.Properties.Resources.销卡;
            this.biDeleteCard.Name = "biDeleteCard";
            this.biDeleteCard.Text = "销卡";
            this.biDeleteCard.Click += new System.EventHandler(this.biDeleteCard_Click);
            // 
            // biChangeCard
            // 
            this.biChangeCard.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biChangeCard.Image = global::SmartAccess.Properties.Resources.换卡;
            this.biChangeCard.Name = "biChangeCard";
            this.biChangeCard.Text = "换卡/发卡";
            this.biChangeCard.Click += new System.EventHandler(this.biChangeCard_Click);
            // 
            // biForbbiden
            // 
            this.biForbbiden.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biForbbiden.Image = global::SmartAccess.Properties.Resources.editor;
            this.biForbbiden.Name = "biForbbiden";
            this.biForbbiden.Text = "挂失";
            this.biForbbiden.Click += new System.EventHandler(this.biForbbiden_Click);
            // 
            // biUnForbbiden
            // 
            this.biUnForbbiden.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biUnForbbiden.Image = global::SmartAccess.Properties.Resources.editor;
            this.biUnForbbiden.Name = "biUnForbbiden";
            this.biUnForbbiden.Text = "解挂";
            this.biUnForbbiden.Click += new System.EventHandler(this.biUnForbbiden_Click);
            // 
            // biPrivateCopy
            // 
            this.biPrivateCopy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biPrivateCopy.Image = global::SmartAccess.Properties.Resources.editor;
            this.biPrivateCopy.Name = "biPrivateCopy";
            this.biPrivateCopy.Text = "权限复制";
            this.biPrivateCopy.Click += new System.EventHandler(this.biPrivateCopy_Click);
            // 
            // biExportPhoto
            // 
            this.biExportPhoto.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biExportPhoto.Image = global::SmartAccess.Properties.Resources.导出;
            this.biExportPhoto.Name = "biExportPhoto";
            this.biExportPhoto.Text = "导出照片";
            this.biExportPhoto.Click += new System.EventHandler(this.biExportPhoto_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 29);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.deptTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pageDataGridView);
            this.splitContainer1.Panel2.Controls.Add(this.bar3);
            this.splitContainer1.Panel2.Controls.Add(this.bar2);
            this.splitContainer1.Size = new System.Drawing.Size(1131, 480);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 1;
            // 
            // deptTree
            // 
            this.deptTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deptTree.Location = new System.Drawing.Point(0, 0);
            this.deptTree.Name = "deptTree";
            this.deptTree.Size = new System.Drawing.Size(228, 480);
            this.deptTree.TabIndex = 0;
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
            this.pageDataGridView.DataGridPanel.Size = new System.Drawing.Size(899, 394);
            this.pageDataGridView.DataGridPanel.TabIndex = 1;
            this.pageDataGridView.DataGridView = this.dgvStaffs;
            this.pageDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDataGridView.Location = new System.Drawing.Point(0, 54);
            this.pageDataGridView.Name = "pageDataGridView";
            // 
            // pageDataGridView.PageControl
            // 
            this.pageDataGridView.PageControl.CurrentPage = 1;
            this.pageDataGridView.PageControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageDataGridView.PageControl.ExportButtonVisible = true;
            this.pageDataGridView.PageControl.Location = new System.Drawing.Point(0, 394);
            this.pageDataGridView.PageControl.Name = "PageControl";
            this.pageDataGridView.PageControl.RecordsPerPage = 30;
            this.pageDataGridView.PageControl.Size = new System.Drawing.Size(899, 32);
            this.pageDataGridView.PageControl.TabIndex = 0;
            this.pageDataGridView.PageControl.TotalRecords = 0;
            this.pageDataGridView.PageControl.PageChanged += new Li.Controls.PageCtrl.PageEventHandle(this.pageDataGridView_PageControl_PageChanged);
            this.pageDataGridView.Size = new System.Drawing.Size(899, 426);
            this.pageDataGridView.SqlWhere = null;
            this.pageDataGridView.TabIndex = 3;
            // 
            // dgvStaffs
            // 
            this.dgvStaffs.AllowUserToAddRows = false;
            this.dgvStaffs.AllowUserToDeleteRows = false;
            this.dgvStaffs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaffs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvStaffs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaffs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column8,
            this.Column10,
            this.Col_CK,
            this.Col_XG,
            this.Col_SQ,
            this.Col_SC});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStaffs.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvStaffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStaffs.EnableHeadersVisualStyles = false;
            this.dgvStaffs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvStaffs.Location = new System.Drawing.Point(0, 0);
            this.dgvStaffs.Name = "dgvStaffs";
            this.dgvStaffs.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStaffs.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvStaffs.RowTemplate.Height = 23;
            this.dgvStaffs.Size = new System.Drawing.Size(899, 394);
            this.dgvStaffs.TabIndex = 0;
            this.dgvStaffs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaffs_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "证件号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "部门";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "卡号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "发卡数";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "状态";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "有效期";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "电话";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Col_CK
            // 
            this.Col_CK.HeaderText = "详情";
            this.Col_CK.Name = "Col_CK";
            this.Col_CK.ReadOnly = true;
            this.Col_CK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col_CK.SplitLinkSymbol = ",";
            // 
            // Col_XG
            // 
            this.Col_XG.HeaderText = "修改";
            this.Col_XG.Name = "Col_XG";
            this.Col_XG.ReadOnly = true;
            this.Col_XG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col_XG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Col_SQ
            // 
            this.Col_SQ.HeaderText = "授权";
            this.Col_SQ.Name = "Col_SQ";
            this.Col_SQ.ReadOnly = true;
            this.Col_SQ.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col_SQ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Col_SC
            // 
            this.Col_SC.HeaderText = "上传";
            this.Col_SC.Name = "Col_SC";
            this.Col_SC.ReadOnly = true;
            this.Col_SC.SplitLinkSymbol = ",";
            // 
            // bar3
            // 
            this.bar3.AntiAlias = true;
            this.bar3.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem8,
            this.cbHasCard,
            this.cbHasNoCard,
            this.cbIsForbbiden,
            this.cbHasDoor,
            this.cbHasNoDoor});
            this.bar3.Location = new System.Drawing.Point(0, 28);
            this.bar3.Name = "bar3";
            this.bar3.Size = new System.Drawing.Size(899, 26);
            this.bar3.Stretch = true;
            this.bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar3.TabIndex = 2;
            this.bar3.TabStop = false;
            this.bar3.Text = "bar3";
            // 
            // labelItem8
            // 
            this.labelItem8.ForeColor = System.Drawing.Color.Black;
            this.labelItem8.Name = "labelItem8";
            this.labelItem8.Text = "证件状态";
            // 
            // cbHasCard
            // 
            this.cbHasCard.Name = "cbHasCard";
            this.cbHasCard.Text = "已发卡";
            this.cbHasCard.Click += new System.EventHandler(this.cbHasCard_Click);
            // 
            // cbHasNoCard
            // 
            this.cbHasNoCard.Name = "cbHasNoCard";
            this.cbHasNoCard.Text = "未发卡";
            this.cbHasNoCard.Click += new System.EventHandler(this.cbHasNoCard_Click);
            // 
            // cbIsForbbiden
            // 
            this.cbIsForbbiden.Name = "cbIsForbbiden";
            this.cbIsForbbiden.Text = "已挂失";
            this.cbIsForbbiden.Click += new System.EventHandler(this.cbIsForbbiden_Click);
            // 
            // cbHasDoor
            // 
            this.cbHasDoor.Name = "cbHasDoor";
            this.cbHasDoor.Text = "已授权";
            this.cbHasDoor.Click += new System.EventHandler(this.cbHasDoor_Click);
            // 
            // cbHasNoDoor
            // 
            this.cbHasNoDoor.Name = "cbHasNoDoor";
            this.cbHasNoDoor.Text = "未授权";
            this.cbHasNoDoor.Click += new System.EventHandler(this.cbHasNoDoor_Click);
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Controls.Add(this.dtpValidTime);
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.tbName,
            this.labelItem2,
            this.tbDeptName,
            this.labelItem5,
            this.tbStaffNo,
            this.labelItem6,
            this.tbJob,
            this.labelItem7,
            this.controlContainerItem1,
            this.biDoSearch,
            this.biClear});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(899, 28);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 1;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
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
            this.dtpValidTime.Location = new System.Drawing.Point(456, 2);
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
            this.dtpValidTime.Size = new System.Drawing.Size(90, 23);
            this.dtpValidTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpValidTime.TabIndex = 2;
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
            // 
            // labelItem6
            // 
            this.labelItem6.ForeColor = System.Drawing.Color.Black;
            this.labelItem6.Name = "labelItem6";
            this.labelItem6.Text = "职务";
            // 
            // tbJob
            // 
            this.tbJob.Name = "tbJob";
            this.tbJob.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // labelItem7
            // 
            this.labelItem7.ForeColor = System.Drawing.Color.Black;
            this.labelItem7.Name = "labelItem7";
            this.labelItem7.Text = "有效期";
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.dtpValidTime;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // biDoSearch
            // 
            this.biDoSearch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDoSearch.Image = global::SmartAccess.Properties.Resources.editor;
            this.biDoSearch.Name = "biDoSearch";
            this.biDoSearch.Text = "查询";
            this.biDoSearch.Click += new System.EventHandler(this.biDoSearch_Click);
            // 
            // biClear
            // 
            this.biClear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biClear.Image = global::SmartAccess.Properties.Resources.editor;
            this.biClear.Name = "biClear";
            this.biClear.Text = "清空";
            this.biClear.Click += new System.EventHandler(this.biClear_Click);
            // 
            // controlContainerItem2
            // 
            this.controlContainerItem2.AllowItemResize = false;
            this.controlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem2.Name = "controlContainerItem2";
            // 
            // saveImageDlg
            // 
            this.saveImageDlg.DefaultExt = "png";
            this.saveImageDlg.Filter = "图片文件(*.png)|*.png";
            // 
            // biOneKeyUpload
            // 
            this.biOneKeyUpload.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biOneKeyUpload.Image = global::SmartAccess.Properties.Resources.editor;
            this.biOneKeyUpload.Name = "biOneKeyUpload";
            this.biOneKeyUpload.Text = "一键上传所有权限";
            this.biOneKeyUpload.Click += new System.EventHandler(this.biOneKeyUpload_Click);
            // 
            // StaffInfoMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bar1);
            this.Name = "StaffInfoMgr";
            this.Size = new System.Drawing.Size(1131, 509);
            this.Load += new System.EventHandler(this.StaffInfoMgr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pageDataGridView.DataGridPanel.ResumeLayout(false);
            this.pageDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.bar2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpValidTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biAddUser;
        private DevComponents.DotNetBar.ButtonItem biReadCard;
        private DevComponents.DotNetBar.ButtonItem biDeleteStaff;
        private DevComponents.DotNetBar.ButtonItem biDeleteCard;
        private DevComponents.DotNetBar.ButtonItem biChangeCard;
        private DevComponents.DotNetBar.ButtonItem biForbbiden;
        private DevComponents.DotNetBar.ButtonItem biUnForbbiden;
        private DevComponents.DotNetBar.ButtonItem biExportPhoto;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DeptTree deptTree;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpValidTime;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem tbName;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.LabelItem labelItem5;
        private DevComponents.DotNetBar.TextBoxItem tbStaffNo;
        private DevComponents.DotNetBar.LabelItem labelItem6;
        private DevComponents.DotNetBar.TextBoxItem tbJob;
        private DevComponents.DotNetBar.LabelItem labelItem7;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.ButtonItem biDoSearch;
        private DevComponents.DotNetBar.Bar bar3;
        private DevComponents.DotNetBar.LabelItem labelItem8;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem2;
        private DevComponents.DotNetBar.CheckBoxItem cbHasCard;
        private DevComponents.DotNetBar.CheckBoxItem cbHasNoCard;
        private DevComponents.DotNetBar.CheckBoxItem cbIsForbbiden;
        private DevComponents.DotNetBar.CheckBoxItem cbHasDoor;
        private DevComponents.DotNetBar.CheckBoxItem cbHasNoDoor;
        private Li.Controls.PageDataGridView pageDataGridView;
        private Li.Controls.DataGridViewEx dgvStaffs;
        private System.Windows.Forms.SaveFileDialog saveImageDlg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private Li.Controls.DataGridViewLinkLabelColumn Col_CK;
        private System.Windows.Forms.DataGridViewLinkColumn Col_XG;
        private System.Windows.Forms.DataGridViewLinkColumn Col_SQ;
        private Li.Controls.DataGridViewLinkLabelColumn Col_SC;
        private DevComponents.DotNetBar.TextBoxItem tbDeptName;
        private DevComponents.DotNetBar.ButtonItem biClear;
        private DevComponents.DotNetBar.ButtonItem biPrivateCopy;
        private DevComponents.DotNetBar.ButtonItem biOneKeyUpload;
    }
}
