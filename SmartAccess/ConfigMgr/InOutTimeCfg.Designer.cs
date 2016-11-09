namespace SmartAccess.ConfigMgr
{
    partial class InOutTimeCfg
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.biNew = new DevComponents.DotNetBar.ButtonItem();
            this.biModify = new DevComponents.DotNetBar.ButtonItem();
            this.biDelete = new DevComponents.DotNetBar.ButtonItem();
            this.biView = new DevComponents.DotNetBar.ButtonItem();
            this.biWeekEX = new DevComponents.DotNetBar.ButtonItem();
            this.biUploadTimeNo = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.dgvData = new Li.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column3 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column4 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column5 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column6 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column7 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column8 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
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
            this.biDelete,
            this.biView,
            this.biWeekEX,
            this.biUploadTimeNo,
            this.labelItem1});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(800, 29);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 4;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biRefresh
            // 
            this.biRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biRefresh.Image = global::SmartAccess.Properties.Resources.刷新;
            this.biRefresh.Name = "biRefresh";
            this.biRefresh.Text = "刷新";
            this.biRefresh.Click += new System.EventHandler(this.biRefresh_Click);
            // 
            // biNew
            // 
            this.biNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biNew.Name = "biNew";
            this.biNew.Text = "添加";
            this.biNew.Click += new System.EventHandler(this.biNew_Click);
            // 
            // biModify
            // 
            this.biModify.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biModify.Name = "biModify";
            this.biModify.Text = "修改";
            this.biModify.Click += new System.EventHandler(this.biModify_Click);
            // 
            // biDelete
            // 
            this.biDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDelete.Name = "biDelete";
            this.biDelete.Text = "删除(自动重新上传)";
            this.biDelete.Click += new System.EventHandler(this.biDelete_Click);
            // 
            // biView
            // 
            this.biView.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biView.Name = "biView";
            this.biView.Text = "查看";
            this.biView.Click += new System.EventHandler(this.biView_Click);
            // 
            // biWeekEX
            // 
            this.biWeekEX.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biWeekEX.Name = "biWeekEX";
            this.biWeekEX.Text = "假期约束";
            this.biWeekEX.Click += new System.EventHandler(this.biWeekEX_Click);
            // 
            // biUploadTimeNo
            // 
            this.biUploadTimeNo.Name = "biUploadTimeNo";
            this.biUploadTimeNo.Text = "上传所有时间段";
            this.biUploadTimeNo.Click += new System.EventHandler(this.biUploadTimeNo_Click);
            // 
            // labelItem1
            // 
            this.labelItem1.ForeColor = System.Drawing.Color.Red;
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "时段1为每天任意时间有效，时段0为完全禁止";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
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
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(0, 29);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(800, 313);
            this.dgvData.TabIndex = 5;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "时段号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 66;
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
            this.Column2.Checked = true;
            this.Column2.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column2.CheckValue = "N";
            this.Column2.HeaderText = "星期一";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 66;
            // 
            // Column3
            // 
            this.Column3.Checked = true;
            this.Column3.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column3.CheckValue = "N";
            this.Column3.HeaderText = "二";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 42;
            // 
            // Column4
            // 
            this.Column4.Checked = true;
            this.Column4.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column4.CheckValue = "N";
            this.Column4.HeaderText = "三";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 42;
            // 
            // Column5
            // 
            this.Column5.Checked = true;
            this.Column5.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column5.CheckValue = "N";
            this.Column5.HeaderText = "四";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 42;
            // 
            // Column6
            // 
            this.Column6.Checked = true;
            this.Column6.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column6.CheckValue = "N";
            this.Column6.HeaderText = "五";
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
            this.Column7.HeaderText = "六";
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
            this.Column8.HeaderText = "日";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column8.Width = 42;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "时区1起始";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 84;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "1结束";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 60;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "2起始";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 60;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "2结束";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 60;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "3起始";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 60;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "3结束";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 60;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "下一时间段";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 90;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "开始日期";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 78;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "结束日期";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 78;
            // 
            // InOutTimeCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.bar1);
            this.Name = "InOutTimeCfg";
            this.Size = new System.Drawing.Size(800, 342);
            this.Load += new System.EventHandler(this.InOutTimeCfg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biRefresh;
        private DevComponents.DotNetBar.ButtonItem biNew;
        private DevComponents.DotNetBar.ButtonItem biModify;
        private DevComponents.DotNetBar.ButtonItem biWeekEX;
        private Li.Controls.DataGridViewEx dgvData;
        private DevComponents.DotNetBar.ButtonItem biDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column2;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column3;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column4;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column5;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column6;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column7;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private DevComponents.DotNetBar.ButtonItem biView;
        private DevComponents.DotNetBar.ButtonItem biUploadTimeNo;
        private DevComponents.DotNetBar.LabelItem labelItem1;
    }
}
