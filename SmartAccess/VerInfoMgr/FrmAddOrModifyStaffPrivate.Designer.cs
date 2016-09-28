namespace SmartAccess.VerInfoMgr
{
    partial class FrmAddOrModifyStaffPrivate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnAllSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnAllUnSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnUnSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnOkUpload = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.dgvSelectDoor = new Li.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doorTree = new SmartAccess.VerInfoMgr.DoorTree();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dtpStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtpEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cbTimeNum = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.LabelX5 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectDoor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(21, 10);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(237, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "可以选择的门";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(441, 10);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(237, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "已选择的门";
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAllSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAllSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllSelect.Location = new System.Drawing.Point(332, 112);
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(95, 22);
            this.btnAllSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAllSelect.TabIndex = 3;
            this.btnAllSelect.Text = ">>";
            this.btnAllSelect.Tooltip = "全部选择";
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.Location = new System.Drawing.Point(332, 150);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(95, 22);
            this.btnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = ">";
            this.btnSelect.Tooltip = "选择";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnAllUnSelect
            // 
            this.btnAllUnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAllUnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAllUnSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAllUnSelect.Location = new System.Drawing.Point(332, 247);
            this.btnAllUnSelect.Name = "btnAllUnSelect";
            this.btnAllUnSelect.Size = new System.Drawing.Size(95, 22);
            this.btnAllUnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAllUnSelect.TabIndex = 3;
            this.btnAllUnSelect.Text = "<<";
            this.btnAllUnSelect.Tooltip = "全部移除选择";
            this.btnAllUnSelect.Click += new System.EventHandler(this.btnAllUnSelect_Click);
            // 
            // btnUnSelect
            // 
            this.btnUnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUnSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUnSelect.Location = new System.Drawing.Point(332, 207);
            this.btnUnSelect.Name = "btnUnSelect";
            this.btnUnSelect.Size = new System.Drawing.Size(95, 22);
            this.btnUnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUnSelect.TabIndex = 3;
            this.btnUnSelect.Text = "<";
            this.btnUnSelect.Tooltip = "移除选择";
            this.btnUnSelect.Click += new System.EventHandler(this.btnUnSelect_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(219, 464);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(121, 36);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnOkUpload
            // 
            this.btnOkUpload.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOkUpload.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOkUpload.Location = new System.Drawing.Point(346, 464);
            this.btnOkUpload.Name = "btnOkUpload";
            this.btnOkUpload.Size = new System.Drawing.Size(121, 36);
            this.btnOkUpload.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOkUpload.TabIndex = 4;
            this.btnOkUpload.Text = "确定并上传";
            this.btnOkUpload.Click += new System.EventHandler(this.btnOkUpload_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(473, 464);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 36);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            // 
            // dgvSelectDoor
            // 
            this.dgvSelectDoor.AllowUserToAddRows = false;
            this.dgvSelectDoor.AllowUserToDeleteRows = false;
            this.dgvSelectDoor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectDoor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSelectDoor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectDoor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelectDoor.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSelectDoor.EnableHeadersVisualStyles = false;
            this.dgvSelectDoor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvSelectDoor.Location = new System.Drawing.Point(441, 39);
            this.dgvSelectDoor.Name = "dgvSelectDoor";
            this.dgvSelectDoor.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectDoor.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSelectDoor.RowTemplate.Height = 23;
            this.dgvSelectDoor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectDoor.Size = new System.Drawing.Size(306, 376);
            this.dgvSelectDoor.TabIndex = 2;
            this.dgvSelectDoor.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSelectDoor_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "已选门名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 93;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "所属区域";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 81;
            // 
            // doorTree
            // 
            this.doorTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doorTree.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doorTree.Location = new System.Drawing.Point(21, 40);
            this.doorTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.doorTree.Name = "doorTree";
            this.doorTree.Size = new System.Drawing.Size(299, 375);
            this.doorTree.TabIndex = 0;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(330, 421);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "有效时间：";
            // 
            // dtpStart
            // 
            this.dtpStart.AllowEmptyState = false;
            // 
            // 
            // 
            this.dtpStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpStart.ButtonClear.Text = "清除";
            this.dtpStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpStart.ButtonDropDown.Visible = true;
            this.dtpStart.CustomFormat = "yyyy-MM-dd";
            this.dtpStart.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpStart.IsPopupCalendarOpen = false;
            this.dtpStart.Location = new System.Drawing.Point(399, 421);
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
            this.dtpStart.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
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
            this.dtpStart.Size = new System.Drawing.Size(148, 23);
            this.dtpStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpStart.TabIndex = 6;
            // 
            // dtpEnd
            // 
            this.dtpEnd.AllowEmptyState = false;
            // 
            // 
            // 
            this.dtpEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtpEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpEnd.ButtonClear.Text = "清除";
            this.dtpEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpEnd.ButtonDropDown.Visible = true;
            this.dtpEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtpEnd.IsPopupCalendarOpen = false;
            this.dtpEnd.Location = new System.Drawing.Point(575, 421);
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
            this.dtpEnd.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
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
            this.dtpEnd.Size = new System.Drawing.Size(148, 23);
            this.dtpEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpEnd.TabIndex = 6;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(553, 421);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(22, 23);
            this.labelX4.TabIndex = 5;
            this.labelX4.Text = "至";
            // 
            // cbTimeNum
            // 
            this.cbTimeNum.DisplayMember = "Text";
            this.cbTimeNum.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTimeNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeNum.FormattingEnabled = true;
            this.cbTimeNum.ItemHeight = 17;
            this.cbTimeNum.Location = new System.Drawing.Point(166, 422);
            this.cbTimeNum.Name = "cbTimeNum";
            this.cbTimeNum.Size = new System.Drawing.Size(121, 23);
            this.cbTimeNum.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbTimeNum.TabIndex = 7;
            this.cbTimeNum.SelectedIndexChanged += new System.EventHandler(this.cbTimeNum_SelectedIndexChanged);
            // 
            // LabelX5
            // 
            // 
            // 
            // 
            this.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX5.Location = new System.Drawing.Point(113, 422);
            this.LabelX5.Name = "LabelX5";
            this.LabelX5.Size = new System.Drawing.Size(75, 23);
            this.LabelX5.TabIndex = 5;
            this.LabelX5.Text = "时间段：";
            // 
            // FrmAddOrModifyStaffPrivate
            // 
            this.AcceptButton = this.btnOkUpload;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(804, 512);
            this.Controls.Add(this.cbTimeNum);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.LabelX5);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOkUpload);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnUnSelect);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnAllUnSelect);
            this.Controls.Add(this.btnAllSelect);
            this.Controls.Add(this.dgvSelectDoor);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.doorTree);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddOrModifyStaffPrivate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加或修改人员门禁权限";
            this.Load += new System.EventHandler(this.FrmAddOrModifyStaffPrivate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectDoor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DoorTree doorTree;
        private DevComponents.DotNetBar.LabelX labelX1;
        private Li.Controls.DataGridViewEx dgvSelectDoor;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnAllSelect;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.ButtonX btnAllUnSelect;
        private DevComponents.DotNetBar.ButtonX btnUnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnOkUpload;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpStart;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpEnd;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbTimeNum;
        private DevComponents.DotNetBar.LabelX LabelX5;

    }
}