namespace SmartAccess.ConfigMgr
{
    partial class FrmEditorUser
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tbUserName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbRealName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cbEnable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.tbTel = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.tbAddress = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.tbEmail = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.tbQQ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.cbtDept = new DevComponents.DotNetBar.Controls.ComboTree();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.cboRole = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnResetPwd = new DevComponents.DotNetBar.ButtonX();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Red;
            this.labelX1.Location = new System.Drawing.Point(20, 23);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(61, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "用户名";
            // 
            // tbUserName
            // 
            // 
            // 
            // 
            this.tbUserName.Border.Class = "TextBoxBorder";
            this.tbUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbUserName.Location = new System.Drawing.Point(87, 23);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(126, 23);
            this.tbUserName.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(20, 52);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(61, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "密码";
            // 
            // tbPwd
            // 
            // 
            // 
            // 
            this.tbPwd.Border.Class = "TextBoxBorder";
            this.tbPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbPwd.Location = new System.Drawing.Point(87, 52);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.ReadOnly = true;
            this.tbPwd.Size = new System.Drawing.Size(126, 23);
            this.tbPwd.TabIndex = 2;
            this.tbPwd.Text = "123456";
            this.toolTip1.SetToolTip(this.tbPwd, "默认密码123456");
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(20, 81);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(61, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "真实姓名";
            // 
            // tbRealName
            // 
            // 
            // 
            // 
            this.tbRealName.Border.Class = "TextBoxBorder";
            this.tbRealName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbRealName.Location = new System.Drawing.Point(87, 81);
            this.tbRealName.Name = "tbRealName";
            this.tbRealName.Size = new System.Drawing.Size(126, 23);
            this.tbRealName.TabIndex = 4;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(20, 110);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(61, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "是否启用";
            // 
            // cbEnable
            // 
            // 
            // 
            // 
            this.cbEnable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbEnable.Checked = true;
            this.cbEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnable.CheckValue = "Y";
            this.cbEnable.Location = new System.Drawing.Point(87, 110);
            this.cbEnable.Name = "cbEnable";
            this.cbEnable.Size = new System.Drawing.Size(100, 23);
            this.cbEnable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbEnable.TabIndex = 6;
            this.cbEnable.Text = "启用";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(251, 23);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(61, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "电话";
            // 
            // tbTel
            // 
            // 
            // 
            // 
            this.tbTel.Border.Class = "TextBoxBorder";
            this.tbTel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbTel.Location = new System.Drawing.Point(314, 23);
            this.tbTel.Name = "tbTel";
            this.tbTel.Size = new System.Drawing.Size(126, 23);
            this.tbTel.TabIndex = 1;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(251, 52);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(61, 23);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "联系地址";
            // 
            // tbAddress
            // 
            // 
            // 
            // 
            this.tbAddress.Border.Class = "TextBoxBorder";
            this.tbAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbAddress.Location = new System.Drawing.Point(314, 52);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(126, 23);
            this.tbAddress.TabIndex = 3;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(251, 81);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(61, 23);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "邮箱";
            // 
            // tbEmail
            // 
            // 
            // 
            // 
            this.tbEmail.Border.Class = "TextBoxBorder";
            this.tbEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEmail.Location = new System.Drawing.Point(314, 81);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(126, 23);
            this.tbEmail.TabIndex = 5;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(251, 110);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(61, 23);
            this.labelX8.TabIndex = 0;
            this.labelX8.Text = "QQ";
            // 
            // tbQQ
            // 
            // 
            // 
            // 
            this.tbQQ.Border.Class = "TextBoxBorder";
            this.tbQQ.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbQQ.Location = new System.Drawing.Point(314, 110);
            this.tbQQ.Name = "tbQQ";
            this.tbQQ.Size = new System.Drawing.Size(126, 23);
            this.tbQQ.TabIndex = 7;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(20, 139);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(61, 23);
            this.labelX9.TabIndex = 0;
            this.labelX9.Text = "所属部门";
            // 
            // cbtDept
            // 
            this.cbtDept.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cbtDept.BackgroundStyle.Class = "TextBoxBorder";
            this.cbtDept.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbtDept.ButtonDropDown.Visible = true;
            this.cbtDept.Location = new System.Drawing.Point(87, 139);
            this.cbtDept.Name = "cbtDept";
            this.cbtDept.Size = new System.Drawing.Size(126, 23);
            this.cbtDept.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbtDept.TabIndex = 8;
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(251, 139);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(61, 23);
            this.labelX10.TabIndex = 0;
            this.labelX10.Text = "角色";
            // 
            // cboRole
            // 
            this.cboRole.DisplayMember = "Text";
            this.cboRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.ItemHeight = 17;
            this.cboRole.Location = new System.Drawing.Point(313, 139);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(127, 23);
            this.cboRole.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboRole.TabIndex = 9;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(143, 210);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(89, 29);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(247, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 29);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            // 
            // btnResetPwd
            // 
            this.btnResetPwd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnResetPwd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnResetPwd.Location = new System.Drawing.Point(215, 52);
            this.btnResetPwd.Name = "btnResetPwd";
            this.btnResetPwd.Size = new System.Drawing.Size(30, 23);
            this.btnResetPwd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnResetPwd.TabIndex = 6;
            this.btnResetPwd.Text = "重置";
            this.btnResetPwd.Tooltip = "默认密码123456";
            this.btnResetPwd.Click += new System.EventHandler(this.btnResetPwd_Click);
            // 
            // FrmEditorUser
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(463, 268);
            this.Controls.Add(this.btnResetPwd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.cbtDept);
            this.Controls.Add(this.cbEnable);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX10);
            this.Controls.Add(this.tbQQ);
            this.Controls.Add(this.labelX9);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.tbTel);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.tbRealName);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditorUser";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑用户";
            this.Load += new System.EventHandler(this.FrmEditorUser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbUserName;
        private DevComponents.DotNetBar.Controls.TextBoxX tbPwd;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbRealName;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbEnable;
        private DevComponents.DotNetBar.Controls.TextBoxX tbTel;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX tbAddress;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEmail;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX tbQQ;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.ComboTree cbtDept;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboRole;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnResetPwd;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}