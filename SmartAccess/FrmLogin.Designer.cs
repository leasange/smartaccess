﻿namespace SmartAccess
{
    partial class FrmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnLogin = new DevComponents.DotNetBar.ButtonX();
            this.btnLogout = new DevComponents.DotNetBar.ButtonX();
            this.btnICMS = new DevComponents.DotNetBar.ButtonX();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.styleManager = new DevComponents.DotNetBar.StyleManager(this.components);
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.lbDogTips = new DevComponents.DotNetBar.LabelX();
            this.timerDogCheck = new System.Windows.Forms.Timer(this.components);
            this.cbRememberUser = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbRememberPwd = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(134, 159);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(67, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "用户名";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.ForeColor = System.Drawing.Color.White;
            this.labelX2.Location = new System.Drawing.Point(134, 202);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(67, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "密  码";
            // 
            // tbUserName
            // 
            // 
            // 
            // 
            this.tbUserName.Border.Class = "TextBoxBorder";
            this.tbUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbUserName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbUserName.Location = new System.Drawing.Point(207, 159);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(182, 23);
            this.tbUserName.TabIndex = 0;
            // 
            // tbPwd
            // 
            // 
            // 
            // 
            this.tbPwd.Border.Class = "TextBoxBorder";
            this.tbPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbPwd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPwd.Location = new System.Drawing.Point(207, 202);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(182, 23);
            this.tbPwd.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(154, 250);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(70, 30);
            this.btnLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登陆";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogout.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLogout.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogout.Location = new System.Drawing.Point(230, 250);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(70, 30);
            this.btnLogout.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "关闭";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnICMS
            // 
            this.btnICMS.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnICMS.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnICMS.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnICMS.Location = new System.Drawing.Point(306, 250);
            this.btnICMS.Name = "btnICMS";
            this.btnICMS.Size = new System.Drawing.Size(83, 30);
            this.btnICMS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnICMS.TabIndex = 4;
            this.btnICMS.Text = "数据库配置";
            this.btnICMS.Click += new System.EventHandler(this.btnICMS_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(388, 307);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(121, 20);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "显示软件注册信息";
            // 
            // styleManager
            // 
            this.styleManager.ManagerColorTint = System.Drawing.Color.Black;
            this.styleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black;
            this.styleManager.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.Black, System.Drawing.Color.Black);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(489, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.btnClose.Size = new System.Drawing.Size(16, 16);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "x";
            this.btnClose.Tooltip = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbDogTips
            // 
            this.lbDogTips.AutoSize = true;
            this.lbDogTips.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbDogTips.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbDogTips.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDogTips.ForeColor = System.Drawing.Color.Red;
            this.lbDogTips.Location = new System.Drawing.Point(134, 286);
            this.lbDogTips.Name = "lbDogTips";
            this.lbDogTips.Size = new System.Drawing.Size(180, 23);
            this.lbDogTips.TabIndex = 6;
            this.lbDogTips.Text = "授权已过期，请联系管理员";
            this.lbDogTips.Visible = false;
            // 
            // timerDogCheck
            // 
            this.timerDogCheck.Interval = 1000;
            this.timerDogCheck.Tick += new System.EventHandler(this.timerDogCheck_Tick);
            // 
            // cbRememberUser
            // 
            this.cbRememberUser.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbRememberUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbRememberUser.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbRememberUser.Location = new System.Drawing.Point(395, 159);
            this.cbRememberUser.Name = "cbRememberUser";
            this.cbRememberUser.Size = new System.Drawing.Size(100, 23);
            this.cbRememberUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbRememberUser.TabIndex = 7;
            this.cbRememberUser.Text = "记住用户名";
            // 
            // cbRememberPwd
            // 
            this.cbRememberPwd.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbRememberPwd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbRememberPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbRememberPwd.Location = new System.Drawing.Point(395, 202);
            this.cbRememberPwd.Name = "cbRememberPwd";
            this.cbRememberPwd.Size = new System.Drawing.Size(100, 23);
            this.cbRememberPwd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbRememberPwd.TabIndex = 7;
            this.cbRememberPwd.Text = "记住密码";
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.BackgroundImage = global::SmartAccess.Properties.Resources.loginbk;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(521, 345);
            this.Controls.Add(this.cbRememberPwd);
            this.Controls.Add(this.cbRememberUser);
            this.Controls.Add(this.lbDogTips);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnICMS);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎登陆门禁系统";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbUserName;
        private DevComponents.DotNetBar.Controls.TextBoxX tbPwd;
        private DevComponents.DotNetBar.ButtonX btnLogin;
        private DevComponents.DotNetBar.ButtonX btnLogout;
        private DevComponents.DotNetBar.ButtonX btnICMS;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private DevComponents.DotNetBar.StyleManager styleManager;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.LabelX lbDogTips;
        private System.Windows.Forms.Timer timerDogCheck;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbRememberUser;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbRememberPwd;
    }
}