namespace SmartAccess.ConfigMgr
{
    partial class DoorCameraSetting
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biAddCamera = new DevComponents.DotNetBar.ButtonItem();
            this.dgvCamera = new Li.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Delete = new Li.Controls.DataGridViewLinkLabelColumn();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.biAddDoorCamera = new DevComponents.DotNetBar.ButtonItem();
            this.bar3 = new DevComponents.DotNetBar.Bar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.tbPicUrl = new DevComponents.DotNetBar.TextBoxItem();
            this.biSave = new DevComponents.DotNetBar.ButtonItem();
            this.dgvDoorCamera = new Li.Controls.DataGridViewEx();
            this.doorTree = new SmartAccess.VerInfoMgr.DoorTree();
            this.cbEnableCap = new DevComponents.DotNetBar.CheckBoxItem();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Col_DCDetele = new Li.Controls.DataGridViewLinkLabelColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoorCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biAddCamera});
            this.bar1.Location = new System.Drawing.Point(249, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(772, 29);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 3;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biAddCamera
            // 
            this.biAddCamera.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAddCamera.Image = global::SmartAccess.Properties.Resources.增加;
            this.biAddCamera.Name = "biAddCamera";
            this.biAddCamera.Text = "添加摄像头";
            this.biAddCamera.Click += new System.EventHandler(this.biAddCamera_Click);
            // 
            // dgvCamera
            // 
            this.dgvCamera.AllowUserToAddRows = false;
            this.dgvCamera.AllowUserToDeleteRows = false;
            this.dgvCamera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCamera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCamera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Col_Delete});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCamera.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCamera.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCamera.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvCamera.Location = new System.Drawing.Point(249, 29);
            this.dgvCamera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCamera.Name = "dgvCamera";
            this.dgvCamera.ReadOnly = true;
            this.dgvCamera.RowTemplate.Height = 23;
            this.dgvCamera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCamera.Size = new System.Drawing.Size(772, 252);
            this.dgvCamera.TabIndex = 6;
            this.dgvCamera.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCamera_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "摄像头名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "摄像头IP";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "摄像头端口";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "摄像头用户名";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "摄像头密码";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "摄像头抓拍端口";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "摄像头抓拍方式";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Col_Delete
            // 
            this.Col_Delete.HeaderText = "删除";
            this.Col_Delete.Name = "Col_Delete";
            this.Col_Delete.ReadOnly = true;
            this.Col_Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col_Delete.SplitLinkSymbol = ",";
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cbEnableCap,
            this.biAddDoorCamera});
            this.bar2.Location = new System.Drawing.Point(249, 281);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(772, 29);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 7;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // biAddDoorCamera
            // 
            this.biAddDoorCamera.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAddDoorCamera.Image = global::SmartAccess.Properties.Resources.增加;
            this.biAddDoorCamera.Name = "biAddDoorCamera";
            this.biAddDoorCamera.Text = "执行添加对应关系";
            this.biAddDoorCamera.Tooltip = "执行添加当前选择的门和相机关联关系";
            this.biAddDoorCamera.Click += new System.EventHandler(this.biAddDoorCamera_Click);
            // 
            // bar3
            // 
            this.bar3.AntiAlias = true;
            this.bar3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar3.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.tbPicUrl,
            this.biSave});
            this.bar3.Location = new System.Drawing.Point(249, 548);
            this.bar3.Name = "bar3";
            this.bar3.Size = new System.Drawing.Size(772, 26);
            this.bar3.Stretch = true;
            this.bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar3.TabIndex = 9;
            this.bar3.TabStop = false;
            this.bar3.Text = "bar3";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "抓拍图片访问服务地址：";
            // 
            // tbPicUrl
            // 
            this.tbPicUrl.Name = "tbPicUrl";
            this.tbPicUrl.TextBoxWidth = 400;
            this.tbPicUrl.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.tbPicUrl.WatermarkText = "HTTP或FTP地址";
            // 
            // biSave
            // 
            this.biSave.Name = "biSave";
            this.biSave.Text = "保存地址";
            this.biSave.Click += new System.EventHandler(this.biSave_Click);
            // 
            // dgvDoorCamera
            // 
            this.dgvDoorCamera.AllowUserToAddRows = false;
            this.dgvDoorCamera.AllowUserToDeleteRows = false;
            this.dgvDoorCamera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoorCamera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoorCamera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column10,
            this.Column11,
            this.Col_DCDetele});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDoorCamera.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDoorCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoorCamera.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvDoorCamera.Location = new System.Drawing.Point(249, 310);
            this.dgvDoorCamera.Name = "dgvDoorCamera";
            this.dgvDoorCamera.ReadOnly = true;
            this.dgvDoorCamera.RowTemplate.Height = 23;
            this.dgvDoorCamera.Size = new System.Drawing.Size(772, 238);
            this.dgvDoorCamera.TabIndex = 10;
            this.dgvDoorCamera.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoorCamera_CellClick);
            this.dgvDoorCamera.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoorCamera_CellContentClick);
            // 
            // doorTree
            // 
            this.doorTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doorTree.CheckBoxVisible = false;
            this.doorTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.doorTree.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doorTree.Location = new System.Drawing.Point(0, 0);
            this.doorTree.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.doorTree.Name = "doorTree";
            this.doorTree.Size = new System.Drawing.Size(249, 574);
            this.doorTree.TabIndex = 1;
            // 
            // cbEnableCap
            // 
            this.cbEnableCap.Checked = true;
            this.cbEnableCap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnableCap.Name = "cbEnableCap";
            this.cbEnableCap.Text = "启用抓拍";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "门禁";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "摄像头";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.Checked = true;
            this.Column11.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column11.CheckValue = "N";
            this.Column11.HeaderText = "是否启动抓拍";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Col_DCDetele
            // 
            this.Col_DCDetele.HeaderText = "删除";
            this.Col_DCDetele.Name = "Col_DCDetele";
            this.Col_DCDetele.ReadOnly = true;
            this.Col_DCDetele.SplitLinkSymbol = ",";
            // 
            // DoorCameraSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDoorCamera);
            this.Controls.Add(this.bar3);
            this.Controls.Add(this.bar2);
            this.Controls.Add(this.dgvCamera);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.doorTree);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DoorCameraSetting";
            this.Size = new System.Drawing.Size(1021, 574);
            this.Load += new System.EventHandler(this.DoorCameraSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoorCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private VerInfoMgr.DoorTree doorTree;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biAddCamera;
        private Li.Controls.DataGridViewEx dgvCamera;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem biAddDoorCamera;
        private DevComponents.DotNetBar.Bar bar3;
        private Li.Controls.DataGridViewEx dgvDoorCamera;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem tbPicUrl;
        private DevComponents.DotNetBar.ButtonItem biSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private Li.Controls.DataGridViewLinkLabelColumn Col_Delete;
        private DevComponents.DotNetBar.CheckBoxItem cbEnableCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column11;
        private Li.Controls.DataGridViewLinkLabelColumn Col_DCDetele;
    }
}
