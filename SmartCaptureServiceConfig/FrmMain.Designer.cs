namespace SmartServiceConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbConnStr = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboVer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDb = new System.Windows.Forms.TextBox();
            this.cbUseConnStr = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nScanRate = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nScanRate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "连接字符串";
            // 
            // tbConnStr
            // 
            this.tbConnStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConnStr.Enabled = false;
            this.tbConnStr.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbConnStr.Location = new System.Drawing.Point(96, 180);
            this.tbConnStr.Multiline = true;
            this.tbConnStr.Name = "tbConnStr";
            this.tbConnStr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbConnStr.Size = new System.Drawing.Size(300, 76);
            this.tbConnStr.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(93, 324);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(106, 30);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(205, 324);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(26, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "服务器地址";
            // 
            // tbServer
            // 
            this.tbServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbServer.Location = new System.Drawing.Point(96, 21);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(300, 23);
            this.tbServer.TabIndex = 4;
            this.tbServer.Text = "(local)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(26, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "身份认证";
            // 
            // cboVer
            // 
            this.cboVer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboVer.FormattingEnabled = true;
            this.cboVer.Items.AddRange(new object[] {
            "Windows认证",
            "用户名密码认证"});
            this.cboVer.Location = new System.Drawing.Point(96, 48);
            this.cboVer.Name = "cboVer";
            this.cboVer.Size = new System.Drawing.Size(300, 25);
            this.cboVer.TabIndex = 6;
            this.cboVer.SelectedIndexChanged += new System.EventHandler(this.cboVer_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(26, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "用户名";
            // 
            // tbUser
            // 
            this.tbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUser.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbUser.Location = new System.Drawing.Point(96, 74);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(300, 23);
            this.tbUser.TabIndex = 4;
            this.tbUser.Text = "sa";
            // 
            // tbPwd
            // 
            this.tbPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPwd.Location = new System.Drawing.Point(96, 101);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(300, 23);
            this.tbPwd.TabIndex = 4;
            this.tbPwd.Text = "123456";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(26, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(26, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "数据库";
            // 
            // tbDb
            // 
            this.tbDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDb.Location = new System.Drawing.Point(96, 128);
            this.tbDb.Name = "tbDb";
            this.tbDb.Size = new System.Drawing.Size(300, 23);
            this.tbDb.TabIndex = 4;
            this.tbDb.Text = "SmartAccess";
            // 
            // cbUseConnStr
            // 
            this.cbUseConnStr.AutoSize = true;
            this.cbUseConnStr.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbUseConnStr.Location = new System.Drawing.Point(96, 158);
            this.cbUseConnStr.Name = "cbUseConnStr";
            this.cbUseConnStr.Size = new System.Drawing.Size(147, 21);
            this.cbUseConnStr.TabIndex = 9;
            this.cbUseConnStr.Text = "使用自定义连接字符串";
            this.cbUseConnStr.UseVisualStyleBackColor = true;
            this.cbUseConnStr.CheckedChanged += new System.EventHandler(this.cbUseConnStr_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(26, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "扫描门禁频率(ms)";
            // 
            // nScanRate
            // 
            this.nScanRate.Location = new System.Drawing.Point(137, 264);
            this.nScanRate.Maximum = new decimal(new int[] {
            600000,
            0,
            0,
            0});
            this.nScanRate.Name = "nScanRate";
            this.nScanRate.Size = new System.Drawing.Size(120, 21);
            this.nScanRate.TabIndex = 11;
            this.nScanRate.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(26, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "图片保存路径";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(112, 290);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(235, 21);
            this.tbPath.TabIndex = 13;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(353, 288);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(43, 23);
            this.btnView.TabIndex = 14;
            this.btnView.Text = "浏览";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(408, 366);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nScanRate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbUseConnStr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboVer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.tbDb);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbConnStr);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库配置";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nScanRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConnStr;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboVer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDb;
        private System.Windows.Forms.CheckBox cbUseConnStr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nScanRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

