namespace SmartAccess.ConfigMgr
{
    partial class UserManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.tbFilter = new DevComponents.DotNetBar.TextBoxItem();
            this.pageDataGridView = new Li.Controls.PageDataGridView();
            this.dgvData = new Li.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new Li.Controls.DataGridViewLinkLabelColumn();
            this.biAddUser = new DevComponents.DotNetBar.ButtonItem();
            this.biEditUser = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteUser = new DevComponents.DotNetBar.ButtonItem();
            this.biRoleMgr = new DevComponents.DotNetBar.ButtonItem();
            this.biSearch = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.pageDataGridView.DataGridPanel.SuspendLayout();
            this.pageDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biAddUser,
            this.biEditUser,
            this.biDeleteUser,
            this.biRoleMgr,
            this.labelItem1,
            this.tbFilter,
            this.biSearch});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(713, 29);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "|";
            // 
            // tbFilter
            // 
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.TextBoxWidth = 128;
            this.tbFilter.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.tbFilter.WatermarkText = "输入用户名或姓名";
            this.tbFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbFilter_KeyUp);
            // 
            // pageDataGridView
            // 
            this.pageDataGridView.BackColor = System.Drawing.Color.GhostWhite;
            // 
            // pageDataGridView.DataGridPanel
            // 
            this.pageDataGridView.DataGridPanel.Controls.Add(this.dgvData);
            this.pageDataGridView.DataGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDataGridView.DataGridPanel.Location = new System.Drawing.Point(0, 0);
            this.pageDataGridView.DataGridPanel.Name = "DataGridPanel";
            this.pageDataGridView.DataGridPanel.Size = new System.Drawing.Size(713, 344);
            this.pageDataGridView.DataGridPanel.TabIndex = 1;
            this.pageDataGridView.DataGridView = this.dgvData;
            this.pageDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDataGridView.Location = new System.Drawing.Point(0, 29);
            this.pageDataGridView.Name = "pageDataGridView";
            // 
            // pageDataGridView.PageControl
            // 
            this.pageDataGridView.PageControl.CurrentPage = 1;
            this.pageDataGridView.PageControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageDataGridView.PageControl.ExportButtonVisible = false;
            this.pageDataGridView.PageControl.Location = new System.Drawing.Point(0, 344);
            this.pageDataGridView.PageControl.Name = "PageControl";
            this.pageDataGridView.PageControl.RecordsPerPage = 30;
            this.pageDataGridView.PageControl.Size = new System.Drawing.Size(713, 32);
            this.pageDataGridView.PageControl.TabIndex = 0;
            this.pageDataGridView.PageControl.TotalRecords = 0;
            this.pageDataGridView.PageControl.PageChanged += new Li.Controls.PageCtrl.PageEventHandle(this.pageDataGridView1_PageControl_PageChanged);
            this.pageDataGridView.Size = new System.Drawing.Size(713, 376);
            this.pageDataGridView.SqlWhere = null;
            this.pageDataGridView.TabIndex = 2;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(713, 344);
            this.dgvData.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "用户名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 69;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "是否启用";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 81;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "真实姓名";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 81;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "所属部门";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 81;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "电话";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 57;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "联系地址";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 81;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "邮箱";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 57;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "QQ";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 53;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "所属角色";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column9.SplitLinkSymbol = ",";
            this.Column9.Width = 81;
            // 
            // biAddUser
            // 
            this.biAddUser.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAddUser.Image = global::SmartAccess.Properties.Resources.注册;
            this.biAddUser.Name = "biAddUser";
            this.biAddUser.Text = "新建用户";
            this.biAddUser.Click += new System.EventHandler(this.biAddUser_Click);
            // 
            // biEditUser
            // 
            this.biEditUser.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biEditUser.Image = global::SmartAccess.Properties.Resources.销户;
            this.biEditUser.Name = "biEditUser";
            this.biEditUser.Text = "编辑用户";
            this.biEditUser.Click += new System.EventHandler(this.biEditUser_Click);
            // 
            // biDeleteUser
            // 
            this.biDeleteUser.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDeleteUser.Image = global::SmartAccess.Properties.Resources.读卡;
            this.biDeleteUser.Name = "biDeleteUser";
            this.biDeleteUser.Text = "删除用户";
            this.biDeleteUser.Click += new System.EventHandler(this.biDeleteUser_Click);
            // 
            // biRoleMgr
            // 
            this.biRoleMgr.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biRoleMgr.Image = global::SmartAccess.Properties.Resources.销卡;
            this.biRoleMgr.Name = "biRoleMgr";
            this.biRoleMgr.Text = "角色管理";
            this.biRoleMgr.Click += new System.EventHandler(this.biRoleMgr_Click);
            // 
            // biSearch
            // 
            this.biSearch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biSearch.Image = global::SmartAccess.Properties.Resources.editor;
            this.biSearch.Name = "biSearch";
            this.biSearch.Text = "查找";
            this.biSearch.Click += new System.EventHandler(this.biSearch_Click);
            // 
            // UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageDataGridView);
            this.Controls.Add(this.bar1);
            this.Name = "UserManager";
            this.Size = new System.Drawing.Size(713, 405);
            this.Load += new System.EventHandler(this.UserManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.pageDataGridView.DataGridPanel.ResumeLayout(false);
            this.pageDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biAddUser;
        private DevComponents.DotNetBar.ButtonItem biEditUser;
        private DevComponents.DotNetBar.ButtonItem biDeleteUser;
        private DevComponents.DotNetBar.ButtonItem biRoleMgr;
        private DevComponents.DotNetBar.ButtonItem biSearch;
        private Li.Controls.PageDataGridView pageDataGridView;
        private Li.Controls.DataGridViewEx dgvData;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem tbFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private Li.Controls.DataGridViewLinkLabelColumn Column9;
    }
}
