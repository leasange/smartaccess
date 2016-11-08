namespace SmartAccess.RuleSetMrg
{
    partial class DoorRuleCtrlTask
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvData = new Li.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.Column3 = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column6 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column7 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column8 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column9 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column10 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column11 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.biUpload = new DevComponents.DotNetBar.ButtonItem();
            this.biView = new DevComponents.DotNetBar.ButtonItem();
            this.biDelete = new DevComponents.DotNetBar.ButtonItem();
            this.biModify = new DevComponents.DotNetBar.ButtonItem();
            this.biNew = new DevComponents.DotNetBar.ButtonItem();
            this.biRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column18,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(0, 29);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(995, 355);
            this.dgvData.TabIndex = 7;
            this.dgvData.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentDoubleClick);
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 54;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "名称";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 54;
            // 
            // Column2
            // 
            // 
            // 
            // 
            this.Column2.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.Column2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column2.HeaderText = "起始日期";
            this.Column2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.Column2.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.Column2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column2.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.Column2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column2.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            this.Column2.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.Column2.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.Column2.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.Column2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column2.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.Width = 78;
            // 
            // Column3
            // 
            // 
            // 
            // 
            this.Column3.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.Column3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column3.HeaderText = "结束日期";
            this.Column3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.Column3.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.Column3.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column3.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.Column3.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column3.MonthCalendar.DisplayMonth = new System.DateTime(2016, 9, 1, 0, 0, 0, 0);
            this.Column3.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.Column3.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.Column3.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.Column3.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Column3.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 78;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "触发时间";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.Width = 78;
            // 
            // Column5
            // 
            this.Column5.Checked = true;
            this.Column5.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column5.CheckValue = "N";
            this.Column5.HeaderText = "星期一";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 66;
            // 
            // Column6
            // 
            this.Column6.Checked = true;
            this.Column6.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column6.CheckValue = "N";
            this.Column6.HeaderText = "二";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column6.Width = 42;
            // 
            // Column7
            // 
            this.Column7.Checked = true;
            this.Column7.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column7.CheckValue = "N";
            this.Column7.HeaderText = "三";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column7.Width = 42;
            // 
            // Column8
            // 
            this.Column8.Checked = true;
            this.Column8.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column8.CheckValue = "N";
            this.Column8.HeaderText = "四";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column8.Width = 42;
            // 
            // Column9
            // 
            this.Column9.Checked = true;
            this.Column9.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column9.CheckValue = "N";
            this.Column9.HeaderText = "五";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column9.Width = 42;
            // 
            // Column10
            // 
            this.Column10.Checked = true;
            this.Column10.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column10.CheckValue = "N";
            this.Column10.HeaderText = "六";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column10.Width = 42;
            // 
            // Column11
            // 
            this.Column11.Checked = true;
            this.Column11.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column11.CheckValue = "N";
            this.Column11.HeaderText = "日";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column11.Width = 42;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "门禁";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 54;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "控制方式";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 78;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "备注";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 54;
            // 
            // biUpload
            // 
            this.biUpload.Name = "biUpload";
            this.biUpload.Text = "上传所有定时任务";
            this.biUpload.Click += new System.EventHandler(this.biUpload_Click);
            // 
            // biView
            // 
            this.biView.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biView.Name = "biView";
            this.biView.Text = "查看";
            this.biView.Click += new System.EventHandler(this.biView_Click);
            // 
            // biDelete
            // 
            this.biDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDelete.Name = "biDelete";
            this.biDelete.Text = "删除(自动重新上传定时任务)";
            this.biDelete.Click += new System.EventHandler(this.biDelete_Click);
            // 
            // biModify
            // 
            this.biModify.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biModify.Name = "biModify";
            this.biModify.Text = "修改";
            this.biModify.Click += new System.EventHandler(this.biModify_Click);
            // 
            // biNew
            // 
            this.biNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biNew.Name = "biNew";
            this.biNew.Text = "添加";
            this.biNew.Click += new System.EventHandler(this.biNew_Click);
            // 
            // biRefresh
            // 
            this.biRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biRefresh.Image = global::SmartAccess.Properties.Resources.刷新;
            this.biRefresh.Name = "biRefresh";
            this.biRefresh.Text = "刷新";
            this.biRefresh.Click += new System.EventHandler(this.biRefresh_Click);
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biRefresh,
            this.biNew,
            this.biModify,
            this.biView,
            this.biDelete,
            this.biUpload});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(995, 29);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 6;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // DoorRuleCtrlTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.bar1);
            this.Name = "DoorRuleCtrlTask";
            this.Size = new System.Drawing.Size(995, 384);
            this.Load += new System.EventHandler(this.DoorRuleCtrlTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Li.Controls.DataGridViewEx dgvData;
        private DevComponents.DotNetBar.ButtonItem biUpload;
        private DevComponents.DotNetBar.ButtonItem biView;
        private DevComponents.DotNetBar.ButtonItem biDelete;
        private DevComponents.DotNetBar.ButtonItem biModify;
        private DevComponents.DotNetBar.ButtonItem biNew;
        private DevComponents.DotNetBar.ButtonItem biRefresh;
        private DevComponents.DotNetBar.Bar bar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn Column2;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column5;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column6;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column7;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column8;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column9;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column10;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;

    }
}
