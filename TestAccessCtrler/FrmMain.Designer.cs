namespace TestAccessCtrler
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnGetTime = new System.Windows.Forms.Button();
            this.btnSetTime = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnReadRecord = new System.Windows.Forms.Button();
            this.btnGetReadedIndex = new System.Windows.Forms.Button();
            this.btnReadNextRecord = new System.Windows.Forms.Button();
            this.btnOpenRemoteDoor = new System.Windows.Forms.Button();
            this.iintValue = new System.Windows.Forms.NumericUpDown();
            this.btnAddAuth = new System.Windows.Forms.Button();
            this.btnResetRecord = new System.Windows.Forms.Button();
            this.btnCardIssue = new System.Windows.Forms.Button();
            this.btnRevIP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iintValue)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "搜索控制器";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column7,
            this.Column5,
            this.Column6,
            this.Column8,
            this.Column10});
            this.dataGridView1.Location = new System.Drawing.Point(12, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(929, 306);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序列号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 66;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "控制器门类型";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 102;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "IP";
            this.Column2.Name = "Column2";
            this.Column2.Width = 42;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "子网掩码";
            this.Column3.Name = "Column3";
            this.Column3.Width = 78;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "网关";
            this.Column4.Name = "Column4";
            this.Column4.Width = 54;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "MAC地址";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 72;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "驱动号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 66;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "驱动发布日期";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 102;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "修改";
            this.Column8.Name = "Column8";
            this.Column8.Width = 35;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "控制器状态操作";
            this.Column10.Name = "Column10";
            this.Column10.Width = 95;
            // 
            // btnGetTime
            // 
            this.btnGetTime.Location = new System.Drawing.Point(237, 12);
            this.btnGetTime.Name = "btnGetTime";
            this.btnGetTime.Size = new System.Drawing.Size(88, 31);
            this.btnGetTime.TabIndex = 2;
            this.btnGetTime.Text = "获取时间";
            this.btnGetTime.UseVisualStyleBackColor = true;
            this.btnGetTime.Click += new System.EventHandler(this.btnGetTime_Click);
            // 
            // btnSetTime
            // 
            this.btnSetTime.Location = new System.Drawing.Point(493, 12);
            this.btnSetTime.Name = "btnSetTime";
            this.btnSetTime.Size = new System.Drawing.Size(88, 31);
            this.btnSetTime.TabIndex = 2;
            this.btnSetTime.Text = "设置时间";
            this.btnSetTime.UseVisualStyleBackColor = true;
            this.btnSetTime.Click += new System.EventHandler(this.btnSetTime_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(331, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(156, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // btnReadRecord
            // 
            this.btnReadRecord.Location = new System.Drawing.Point(587, 12);
            this.btnReadRecord.Name = "btnReadRecord";
            this.btnReadRecord.Size = new System.Drawing.Size(100, 31);
            this.btnReadRecord.TabIndex = 2;
            this.btnReadRecord.Text = "读取第一条记录";
            this.btnReadRecord.UseVisualStyleBackColor = true;
            this.btnReadRecord.Click += new System.EventHandler(this.btnReadRecord_Click);
            // 
            // btnGetReadedIndex
            // 
            this.btnGetReadedIndex.Location = new System.Drawing.Point(693, 12);
            this.btnGetReadedIndex.Name = "btnGetReadedIndex";
            this.btnGetReadedIndex.Size = new System.Drawing.Size(88, 31);
            this.btnGetReadedIndex.TabIndex = 4;
            this.btnGetReadedIndex.Text = "获取已读索引";
            this.btnGetReadedIndex.UseVisualStyleBackColor = true;
            this.btnGetReadedIndex.Click += new System.EventHandler(this.btnGetReadedIndex_Click);
            // 
            // btnReadNextRecord
            // 
            this.btnReadNextRecord.Location = new System.Drawing.Point(787, 12);
            this.btnReadNextRecord.Name = "btnReadNextRecord";
            this.btnReadNextRecord.Size = new System.Drawing.Size(99, 31);
            this.btnReadNextRecord.TabIndex = 2;
            this.btnReadNextRecord.Text = "读取下一条记录";
            this.btnReadNextRecord.UseVisualStyleBackColor = true;
            this.btnReadNextRecord.Click += new System.EventHandler(this.btnReadNextRecord_Click);
            // 
            // btnOpenRemoteDoor
            // 
            this.btnOpenRemoteDoor.Location = new System.Drawing.Point(156, 49);
            this.btnOpenRemoteDoor.Name = "btnOpenRemoteDoor";
            this.btnOpenRemoteDoor.Size = new System.Drawing.Size(88, 31);
            this.btnOpenRemoteDoor.TabIndex = 2;
            this.btnOpenRemoteDoor.Text = "远程开门";
            this.btnOpenRemoteDoor.UseVisualStyleBackColor = true;
            this.btnOpenRemoteDoor.Click += new System.EventHandler(this.btnOpenRemoteDoor_Click);
            // 
            // iintValue
            // 
            this.iintValue.Location = new System.Drawing.Point(30, 56);
            this.iintValue.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.iintValue.Name = "iintValue";
            this.iintValue.Size = new System.Drawing.Size(120, 21);
            this.iintValue.TabIndex = 5;
            this.iintValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddAuth
            // 
            this.btnAddAuth.Location = new System.Drawing.Point(250, 49);
            this.btnAddAuth.Name = "btnAddAuth";
            this.btnAddAuth.Size = new System.Drawing.Size(88, 31);
            this.btnAddAuth.TabIndex = 2;
            this.btnAddAuth.Text = "添加权限";
            this.btnAddAuth.UseVisualStyleBackColor = true;
            this.btnAddAuth.Click += new System.EventHandler(this.btnAddAuth_Click);
            // 
            // btnResetRecord
            // 
            this.btnResetRecord.Location = new System.Drawing.Point(344, 49);
            this.btnResetRecord.Name = "btnResetRecord";
            this.btnResetRecord.Size = new System.Drawing.Size(88, 31);
            this.btnResetRecord.TabIndex = 2;
            this.btnResetRecord.Text = "重置读取记录";
            this.btnResetRecord.UseVisualStyleBackColor = true;
            this.btnResetRecord.Click += new System.EventHandler(this.btnResetRecord_Click);
            // 
            // btnCardIssue
            // 
            this.btnCardIssue.Location = new System.Drawing.Point(493, 49);
            this.btnCardIssue.Name = "btnCardIssue";
            this.btnCardIssue.Size = new System.Drawing.Size(88, 31);
            this.btnCardIssue.TabIndex = 2;
            this.btnCardIssue.Text = "发卡器测试";
            this.btnCardIssue.UseVisualStyleBackColor = true;
            this.btnCardIssue.Click += new System.EventHandler(this.btnCardIssue_Click);
            // 
            // btnRevIP
            // 
            this.btnRevIP.Location = new System.Drawing.Point(587, 49);
            this.btnRevIP.Name = "btnRevIP";
            this.btnRevIP.Size = new System.Drawing.Size(111, 31);
            this.btnRevIP.TabIndex = 6;
            this.btnRevIP.Text = "获取接收服务器";
            this.btnRevIP.UseVisualStyleBackColor = true;
            this.btnRevIP.Click += new System.EventHandler(this.btnRevIP_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 404);
            this.Controls.Add(this.btnRevIP);
            this.Controls.Add(this.iintValue);
            this.Controls.Add(this.btnGetReadedIndex);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnReadNextRecord);
            this.Controls.Add(this.btnReadRecord);
            this.Controls.Add(this.btnCardIssue);
            this.Controls.Add(this.btnResetRecord);
            this.Controls.Add(this.btnAddAuth);
            this.Controls.Add(this.btnOpenRemoteDoor);
            this.Controls.Add(this.btnSetTime);
            this.Controls.Add(this.btnGetTime);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iintValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn Column8;
        private System.Windows.Forms.DataGridViewButtonColumn Column10;
        private System.Windows.Forms.Button btnGetTime;
        private System.Windows.Forms.Button btnSetTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnReadRecord;
        private System.Windows.Forms.Button btnGetReadedIndex;
        private System.Windows.Forms.Button btnReadNextRecord;
        private System.Windows.Forms.Button btnOpenRemoteDoor;
        private System.Windows.Forms.NumericUpDown iintValue;
        private System.Windows.Forms.Button btnAddAuth;
        private System.Windows.Forms.Button btnResetRecord;
        private System.Windows.Forms.Button btnCardIssue;
        private System.Windows.Forms.Button btnRevIP;

    }
}

