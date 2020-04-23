namespace SmartAccess.VerInfoMgr
{
    partial class FrmBatchModify
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbTreeDept = new DevComponents.DotNetBar.Controls.ComboTree();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnUnSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnAllUnSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnAllSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOkUpload = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvStaffs = new Li.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSelected = new Li.Controls.DataGridViewEx();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbStaffType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.plValidate = new System.Windows.Forms.Panel();
            this.dtValidEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtValidStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.plForbidden = new System.Windows.Forms.Panel();
            this.cbForbbiden = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbNormal = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbIsValidValid = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chStaffType = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbisForbidden = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffs)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelected)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.plValidate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtValidEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtValidStart)).BeginInit();
            this.plForbidden.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTreeDept
            // 
            this.cbTreeDept.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cbTreeDept.BackgroundStyle.Class = "TextBoxBorder";
            this.cbTreeDept.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbTreeDept.ButtonDropDown.Visible = true;
            this.cbTreeDept.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbTreeDept.Location = new System.Drawing.Point(65, 25);
            this.cbTreeDept.Name = "cbTreeDept";
            this.cbTreeDept.Size = new System.Drawing.Size(302, 23);
            this.cbTreeDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbTreeDept.TabIndex = 0;
            this.cbTreeDept.SelectionChanged += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.cbTreeDept_SelectionChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(16, 25);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(43, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "部门";
            // 
            // btnUnSelect
            // 
            this.btnUnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUnSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUnSelect.Location = new System.Drawing.Point(434, 215);
            this.btnUnSelect.Name = "btnUnSelect";
            this.btnUnSelect.Size = new System.Drawing.Size(74, 22);
            this.btnUnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUnSelect.TabIndex = 4;
            this.btnUnSelect.Text = "<";
            this.btnUnSelect.Tooltip = "移除选择";
            this.btnUnSelect.Click += new System.EventHandler(this.btnUnSelect_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.Location = new System.Drawing.Point(434, 158);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(74, 22);
            this.btnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = ">";
            this.btnSelect.Tooltip = "选择";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnAllUnSelect
            // 
            this.btnAllUnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAllUnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAllUnSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllUnSelect.Location = new System.Drawing.Point(434, 255);
            this.btnAllUnSelect.Name = "btnAllUnSelect";
            this.btnAllUnSelect.Size = new System.Drawing.Size(74, 22);
            this.btnAllUnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAllUnSelect.TabIndex = 6;
            this.btnAllUnSelect.Text = "<<";
            this.btnAllUnSelect.Tooltip = "全部移除选择";
            this.btnAllUnSelect.Click += new System.EventHandler(this.btnAllUnSelect_Click);
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAllSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAllSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllSelect.Location = new System.Drawing.Point(434, 120);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(74, 22);
            this.btnAllSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAllSelect.TabIndex = 7;
            this.btnAllSelect.Text = ">>";
            this.btnAllSelect.Tooltip = "全部选择";
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(483, 487);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 36);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "关闭";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkUpload
            // 
            this.btnOkUpload.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOkUpload.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOkUpload.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOkUpload.Location = new System.Drawing.Point(356, 487);
            this.btnOkUpload.Name = "btnOkUpload";
            this.btnOkUpload.Size = new System.Drawing.Size(121, 36);
            this.btnOkUpload.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOkUpload.TabIndex = 9;
            this.btnOkUpload.Text = "保存并上传";
            this.btnOkUpload.Click += new System.EventHandler(this.btnOkUpload_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(229, 487);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(121, 36);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "保存";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvStaffs);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.cbTreeDept);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(27, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 380);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "待选择人员";
            // 
            // dgvStaffs
            // 
            this.dgvStaffs.AllowUserToAddRows = false;
            this.dgvStaffs.AllowUserToDeleteRows = false;
            this.dgvStaffs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvStaffs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaffs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column9,
            this.Column5,
            this.Column7});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStaffs.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStaffs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.dgvStaffs.Location = new System.Drawing.Point(16, 54);
            this.dgvStaffs.Name = "dgvStaffs";
            this.dgvStaffs.ReadOnly = true;
            this.dgvStaffs.RowTemplate.Height = 23;
            this.dgvStaffs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaffs.Size = new System.Drawing.Size(351, 307);
            this.dgvStaffs.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "证件号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 69;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 57;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "类别";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 57;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "有效期至";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 81;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "状态";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 57;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSelected);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(523, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 380);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已选择人员";
            // 
            // dgvSelected
            // 
            this.dgvSelected.AllowUserToAddRows = false;
            this.dgvSelected.AllowUserToDeleteRows = false;
            this.dgvSelected.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column10,
            this.Column6,
            this.Column8});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelected.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSelected.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.dgvSelected.Location = new System.Drawing.Point(18, 54);
            this.dgvSelected.Name = "dgvSelected";
            this.dgvSelected.ReadOnly = true;
            this.dgvSelected.RowTemplate.Height = 23;
            this.dgvSelected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelected.Size = new System.Drawing.Size(345, 307);
            this.dgvSelected.TabIndex = 2;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "证件号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 69;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "姓名";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 57;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "类别";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 57;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "有效期至";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 81;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "状态";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 57;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbStaffType);
            this.groupBox3.Controls.Add(this.plValidate);
            this.groupBox3.Controls.Add(this.plForbidden);
            this.groupBox3.Controls.Add(this.cbIsValidValid);
            this.groupBox3.Controls.Add(this.chStaffType);
            this.groupBox3.Controls.Add(this.cbisForbidden);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(27, 398);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(877, 83);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "批量修改信息";
            // 
            // cbStaffType
            // 
            this.cbStaffType.DisplayMember = "Text";
            this.cbStaffType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStaffType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStaffType.Enabled = false;
            this.cbStaffType.FormattingEnabled = true;
            this.cbStaffType.ItemHeight = 17;
            this.cbStaffType.Location = new System.Drawing.Point(393, 45);
            this.cbStaffType.Name = "cbStaffType";
            this.cbStaffType.Size = new System.Drawing.Size(121, 23);
            this.cbStaffType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbStaffType.TabIndex = 9;
            // 
            // plValidate
            // 
            this.plValidate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plValidate.Controls.Add(this.dtValidEnd);
            this.plValidate.Controls.Add(this.dtValidStart);
            this.plValidate.Controls.Add(this.labelX3);
            this.plValidate.Enabled = false;
            this.plValidate.Location = new System.Drawing.Point(20, 40);
            this.plValidate.Name = "plValidate";
            this.plValidate.Size = new System.Drawing.Size(337, 32);
            this.plValidate.TabIndex = 8;
            // 
            // dtValidEnd
            // 
            // 
            // 
            // 
            this.dtValidEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtValidEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtValidEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtValidEnd.ButtonDropDown.Visible = true;
            this.dtValidEnd.CustomFormat = "yyyy-MM-dd";
            this.dtValidEnd.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector;
            this.dtValidEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtValidEnd.IsPopupCalendarOpen = false;
            this.dtValidEnd.Location = new System.Drawing.Point(179, 4);
            // 
            // 
            // 
            this.dtValidEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtValidEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtValidEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtValidEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtValidEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtValidEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtValidEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtValidEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtValidEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtValidEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtValidEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtValidEnd.MonthCalendar.DisplayMonth = new System.DateTime(2018, 7, 1, 0, 0, 0, 0);
            this.dtValidEnd.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtValidEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtValidEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtValidEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtValidEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtValidEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtValidEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtValidEnd.MonthCalendar.TodayButtonVisible = true;
            this.dtValidEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtValidEnd.Name = "dtValidEnd";
            this.dtValidEnd.ShowCheckBox = true;
            this.dtValidEnd.ShowUpDown = true;
            this.dtValidEnd.Size = new System.Drawing.Size(154, 23);
            this.dtValidEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtValidEnd.TabIndex = 2;
            // 
            // dtValidStart
            // 
            // 
            // 
            // 
            this.dtValidStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtValidStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtValidStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtValidStart.ButtonDropDown.Visible = true;
            this.dtValidStart.CustomFormat = "yyyy-MM-dd";
            this.dtValidStart.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector;
            this.dtValidStart.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtValidStart.IsPopupCalendarOpen = false;
            this.dtValidStart.Location = new System.Drawing.Point(6, 4);
            this.dtValidStart.LockUpdateChecked = false;
            // 
            // 
            // 
            this.dtValidStart.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtValidStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtValidStart.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtValidStart.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtValidStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtValidStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtValidStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtValidStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtValidStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtValidStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtValidStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtValidStart.MonthCalendar.DisplayMonth = new System.DateTime(2018, 7, 1, 0, 0, 0, 0);
            this.dtValidStart.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dtValidStart.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtValidStart.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtValidStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtValidStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtValidStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtValidStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtValidStart.MonthCalendar.TodayButtonVisible = true;
            this.dtValidStart.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtValidStart.Name = "dtValidStart";
            this.dtValidStart.ShowCheckBox = true;
            this.dtValidStart.ShowUpDown = true;
            this.dtValidStart.Size = new System.Drawing.Size(154, 23);
            this.dtValidStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtValidStart.TabIndex = 1;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(160, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(19, 16);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "~";
            // 
            // plForbidden
            // 
            this.plForbidden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plForbidden.Controls.Add(this.cbForbbiden);
            this.plForbidden.Controls.Add(this.cbNormal);
            this.plForbidden.Enabled = false;
            this.plForbidden.Location = new System.Drawing.Point(564, 40);
            this.plForbidden.Name = "plForbidden";
            this.plForbidden.Size = new System.Drawing.Size(170, 32);
            this.plForbidden.TabIndex = 7;
            // 
            // cbForbbiden
            // 
            // 
            // 
            // 
            this.cbForbbiden.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbForbbiden.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbForbbiden.Location = new System.Drawing.Point(96, 6);
            this.cbForbbiden.Name = "cbForbbiden";
            this.cbForbbiden.Size = new System.Drawing.Size(57, 17);
            this.cbForbbiden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbForbbiden.TabIndex = 9;
            this.cbForbbiden.Text = "冻结";
            // 
            // cbNormal
            // 
            // 
            // 
            // 
            this.cbNormal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbNormal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbNormal.Checked = true;
            this.cbNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNormal.CheckValue = "Y";
            this.cbNormal.Location = new System.Drawing.Point(14, 8);
            this.cbNormal.Name = "cbNormal";
            this.cbNormal.Size = new System.Drawing.Size(79, 14);
            this.cbNormal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbNormal.TabIndex = 8;
            this.cbNormal.Text = "正常有效";
            // 
            // cbIsValidValid
            // 
            // 
            // 
            // 
            this.cbIsValidValid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbIsValidValid.Location = new System.Drawing.Point(16, 19);
            this.cbIsValidValid.Name = "cbIsValidValid";
            this.cbIsValidValid.Size = new System.Drawing.Size(100, 23);
            this.cbIsValidValid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbIsValidValid.TabIndex = 6;
            this.cbIsValidValid.Text = "有效期：";
            this.cbIsValidValid.CheckedChanged += new System.EventHandler(this.cbIsValidValid_CheckedChanged);
            // 
            // chStaffType
            // 
            // 
            // 
            // 
            this.chStaffType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chStaffType.Location = new System.Drawing.Point(393, 19);
            this.chStaffType.Name = "chStaffType";
            this.chStaffType.Size = new System.Drawing.Size(99, 23);
            this.chStaffType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chStaffType.TabIndex = 5;
            this.chStaffType.Text = "人员类别：";
            this.chStaffType.CheckedChanged += new System.EventHandler(this.chStaffType_CheckedChanged);
            // 
            // cbisForbidden
            // 
            // 
            // 
            // 
            this.cbisForbidden.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbisForbidden.Location = new System.Drawing.Point(559, 19);
            this.cbisForbidden.Name = "cbisForbidden";
            this.cbisForbidden.Size = new System.Drawing.Size(99, 23);
            this.cbisForbidden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbisForbidden.TabIndex = 5;
            this.cbisForbidden.Text = "冻结状态：";
            this.cbisForbidden.CheckedChanged += new System.EventHandler(this.cbisForbidden_CheckedChanged);
            // 
            // FrmBatchModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 535);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkUpload);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnUnSelect);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnAllUnSelect);
            this.Controls.Add(this.btnAllSelect);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBatchModify";
            this.ShowInTaskbar = false;
            this.Text = "批量修改信息";
            this.Load += new System.EventHandler(this.FrmPrivateCopy_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffs)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelected)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.plValidate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtValidEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtValidStart)).EndInit();
            this.plForbidden.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboTree cbTreeDept;
        private DevComponents.DotNetBar.LabelX labelX1;
        private Li.Controls.DataGridViewEx dgvStaffs;
        private Li.Controls.DataGridViewEx dgvSelected;
        private DevComponents.DotNetBar.ButtonX btnUnSelect;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.ButtonX btnAllUnSelect;
        private DevComponents.DotNetBar.ButtonX btnAllSelect;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOkUpload;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtValidStart;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtValidEnd;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbisForbidden;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbIsValidValid;
        private System.Windows.Forms.Panel plForbidden;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbForbbiden;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbNormal;
        private System.Windows.Forms.Panel plValidate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private DevComponents.DotNetBar.Controls.CheckBoxX chStaffType;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbStaffType;
    }
}