namespace SmartAccess
{
    partial class FrmDataBaseConfig
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tbServerName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbVerType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btnTestDataBase = new DevComponents.DotNetBar.ButtonX();
            this.btnCreateDatabase = new DevComponents.DotNetBar.ButtonX();
            this.lbMsg = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.tbDatabase = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(31, 27);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "服务器地址";
            // 
            // tbServerName
            // 
            // 
            // 
            // 
            this.tbServerName.Border.Class = "TextBoxBorder";
            this.tbServerName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbServerName.Location = new System.Drawing.Point(112, 28);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.Size = new System.Drawing.Size(227, 23);
            this.tbServerName.TabIndex = 1;
            this.tbServerName.Text = "(local)";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(31, 57);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "身 份 验 证";
            // 
            // cbVerType
            // 
            this.cbVerType.DisplayMember = "Text";
            this.cbVerType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVerType.FormattingEnabled = true;
            this.cbVerType.ItemHeight = 17;
            this.cbVerType.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cbVerType.Location = new System.Drawing.Point(112, 57);
            this.cbVerType.Name = "cbVerType";
            this.cbVerType.Size = new System.Drawing.Size(227, 23);
            this.cbVerType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbVerType.TabIndex = 3;
            this.cbVerType.SelectedIndexChanged += new System.EventHandler(this.cbVerType_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "Windows身份验证";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "用户名密码验证";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(31, 86);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "用   户   名";
            // 
            // tbUser
            // 
            // 
            // 
            // 
            this.tbUser.Border.Class = "TextBoxBorder";
            this.tbUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbUser.Location = new System.Drawing.Point(112, 86);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(227, 23);
            this.tbUser.TabIndex = 1;
            this.tbUser.Text = "sa";
            // 
            // tbPwd
            // 
            // 
            // 
            // 
            this.tbPwd.Border.Class = "TextBoxBorder";
            this.tbPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbPwd.Location = new System.Drawing.Point(112, 115);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(227, 23);
            this.tbPwd.TabIndex = 1;
            this.tbPwd.Text = "123456";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(31, 115);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 2;
            this.labelX4.Text = "密         码";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(31, 144);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 4;
            this.labelX5.Text = "数   据   库";
            // 
            // btnTestDataBase
            // 
            this.btnTestDataBase.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTestDataBase.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTestDataBase.Location = new System.Drawing.Point(112, 174);
            this.btnTestDataBase.Name = "btnTestDataBase";
            this.btnTestDataBase.Size = new System.Drawing.Size(91, 23);
            this.btnTestDataBase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTestDataBase.TabIndex = 5;
            this.btnTestDataBase.Text = "检测/测试";
            this.btnTestDataBase.Click += new System.EventHandler(this.btnTestDataBase_Click);
            // 
            // btnCreateDatabase
            // 
            this.btnCreateDatabase.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCreateDatabase.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCreateDatabase.Location = new System.Drawing.Point(221, 174);
            this.btnCreateDatabase.Name = "btnCreateDatabase";
            this.btnCreateDatabase.Size = new System.Drawing.Size(92, 23);
            this.btnCreateDatabase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCreateDatabase.TabIndex = 5;
            this.btnCreateDatabase.Text = "创建数据库";
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            // 
            // 
            // 
            this.lbMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbMsg.ForeColor = System.Drawing.Color.Red;
            this.lbMsg.Location = new System.Drawing.Point(112, 203);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(0, 0);
            this.lbMsg.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(112, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 32);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(221, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 32);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbDatabase
            // 
            // 
            // 
            // 
            this.tbDatabase.Border.Class = "TextBoxBorder";
            this.tbDatabase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDatabase.Location = new System.Drawing.Point(112, 144);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Size = new System.Drawing.Size(227, 23);
            this.tbDatabase.TabIndex = 1;
            this.tbDatabase.Text = "SmartAccess";
            // 
            // FrmDataBaseConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 271);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCreateDatabase);
            this.Controls.Add(this.btnTestDataBase);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.cbVerType);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.tbDatabase);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbServerName);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDataBaseConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据库连接配置";
            this.Load += new System.EventHandler(this.FrmDataBaseConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbServerName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbVerType;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbUser;
        private DevComponents.DotNetBar.Controls.TextBoxX tbPwd;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ButtonX btnTestDataBase;
        private DevComponents.DotNetBar.ButtonX btnCreateDatabase;
        private DevComponents.DotNetBar.LabelX lbMsg;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDatabase;

    }
}