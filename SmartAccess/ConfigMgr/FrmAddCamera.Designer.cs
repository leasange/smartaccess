namespace SmartAccess.ConfigMgr
{
    partial class FrmAddCamera
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
            this.tbCameraName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbIp = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.iiPort = new DevComponents.Editors.IntegerInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.tbPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.iiCapPort = new DevComponents.Editors.IntegerInput();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cbModel = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.cbCapType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnTestCap = new DevComponents.DotNetBar.ButtonX();
            this.picBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iiPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iiCapPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(46, 16);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(68, 20);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "摄像头名称";
            // 
            // tbCameraName
            // 
            // 
            // 
            // 
            this.tbCameraName.Border.Class = "TextBoxBorder";
            this.tbCameraName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbCameraName.Location = new System.Drawing.Point(120, 13);
            this.tbCameraName.Name = "tbCameraName";
            this.tbCameraName.Size = new System.Drawing.Size(184, 23);
            this.tbCameraName.TabIndex = 0;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Red;
            this.labelX2.Location = new System.Drawing.Point(96, 44);
            this.labelX2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(18, 20);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "IP";
            // 
            // tbIp
            // 
            // 
            // 
            // 
            this.tbIp.Border.Class = "TextBoxBorder";
            this.tbIp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbIp.Location = new System.Drawing.Point(120, 41);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(184, 23);
            this.tbIp.TabIndex = 1;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(83, 72);
            this.labelX3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(31, 20);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "端口";
            // 
            // iiPort
            // 
            this.iiPort.AllowEmptyState = false;
            // 
            // 
            // 
            this.iiPort.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iiPort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iiPort.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iiPort.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.iiPort.Location = new System.Drawing.Point(120, 69);
            this.iiPort.MaxValue = 65535;
            this.iiPort.MinValue = 0;
            this.iiPort.Name = "iiPort";
            this.iiPort.ShowUpDown = true;
            this.iiPort.Size = new System.Drawing.Size(184, 23);
            this.iiPort.TabIndex = 2;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(70, 100);
            this.labelX4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(44, 20);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "用户名";
            // 
            // tbUser
            // 
            // 
            // 
            // 
            this.tbUser.Border.Class = "TextBoxBorder";
            this.tbUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbUser.Location = new System.Drawing.Point(120, 97);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(184, 23);
            this.tbUser.TabIndex = 3;
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(83, 129);
            this.labelX5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(31, 20);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "密码";
            // 
            // tbPwd
            // 
            // 
            // 
            // 
            this.tbPwd.Border.Class = "TextBoxBorder";
            this.tbPwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbPwd.Location = new System.Drawing.Point(120, 126);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(184, 23);
            this.tbPwd.TabIndex = 4;
            // 
            // labelX6
            // 
            this.labelX6.AutoSize = true;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(58, 196);
            this.labelX6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(56, 20);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "截图方式";
            // 
            // iiCapPort
            // 
            this.iiCapPort.AllowEmptyState = false;
            // 
            // 
            // 
            this.iiCapPort.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iiCapPort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iiCapPort.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iiCapPort.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.iiCapPort.Location = new System.Drawing.Point(120, 221);
            this.iiCapPort.MaxValue = 65535;
            this.iiCapPort.MinValue = 0;
            this.iiCapPort.Name = "iiCapPort";
            this.iiCapPort.ShowUpDown = true;
            this.iiCapPort.Size = new System.Drawing.Size(184, 23);
            this.iiCapPort.TabIndex = 7;
            this.iiCapPort.Value = 80;
            // 
            // labelX7
            // 
            this.labelX7.AutoSize = true;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(83, 164);
            this.labelX7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(31, 20);
            this.labelX7.TabIndex = 0;
            this.labelX7.Text = "型号";
            // 
            // cbModel
            // 
            this.cbModel.DisplayMember = "Text";
            this.cbModel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModel.FormattingEnabled = true;
            this.cbModel.ItemHeight = 17;
            this.cbModel.Location = new System.Drawing.Point(120, 160);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(184, 23);
            this.cbModel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbModel.TabIndex = 5;
            // 
            // labelX8
            // 
            this.labelX8.AutoSize = true;
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(58, 224);
            this.labelX8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(56, 20);
            this.labelX8.TabIndex = 0;
            this.labelX8.Text = "截图端口";
            // 
            // cbCapType
            // 
            this.cbCapType.DisplayMember = "Text";
            this.cbCapType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCapType.FormattingEnabled = true;
            this.cbCapType.ItemHeight = 17;
            this.cbCapType.Location = new System.Drawing.Point(120, 189);
            this.cbCapType.Name = "cbCapType";
            this.cbCapType.Size = new System.Drawing.Size(184, 23);
            this.cbCapType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbCapType.TabIndex = 6;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(120, 261);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 23);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(209, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTestCap
            // 
            this.btnTestCap.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTestCap.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTestCap.Location = new System.Drawing.Point(298, 261);
            this.btnTestCap.Name = "btnTestCap";
            this.btnTestCap.Size = new System.Drawing.Size(83, 23);
            this.btnTestCap.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTestCap.TabIndex = 10;
            this.btnTestCap.Text = "测试截图";
            this.btnTestCap.Click += new System.EventHandler(this.btnTestCap_Click);
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.picBox.Location = new System.Drawing.Point(310, 13);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(217, 231);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 11;
            this.picBox.TabStop = false;
            // 
            // FrmAddCamera
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(538, 296);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.btnTestCap);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbCapType);
            this.Controls.Add(this.cbModel);
            this.Controls.Add(this.iiCapPort);
            this.Controls.Add(this.iiPort);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbIp);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.tbCameraName);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddCamera";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加摄像头";
            this.Load += new System.EventHandler(this.FrmAddCamera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iiPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iiCapPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCameraName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbIp;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.IntegerInput iiPort;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbUser;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX tbPwd;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.Editors.IntegerInput iiCapPort;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbModel;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbCapType;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnTestCap;
        private System.Windows.Forms.PictureBox picBox;
    }
}