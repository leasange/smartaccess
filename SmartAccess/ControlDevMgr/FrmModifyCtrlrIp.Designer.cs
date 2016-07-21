namespace SmartAccess.ControlDevMgr
{
    partial class FrmModifyCtrlrIp
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
            this.tbSn = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbMac = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.ipAdd = new DevComponents.Editors.IpAddressInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.ipMask = new DevComponents.Editors.IpAddressInput();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.ipGateway = new DevComponents.Editors.IpAddressInput();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.ipAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipGateway)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(11, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX1.Size = new System.Drawing.Size(72, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "序列号";
            // 
            // tbSn
            // 
            // 
            // 
            // 
            this.tbSn.Border.Class = "TextBoxBorder";
            this.tbSn.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbSn.Location = new System.Drawing.Point(89, 12);
            this.tbSn.Name = "tbSn";
            this.tbSn.ReadOnly = true;
            this.tbSn.Size = new System.Drawing.Size(158, 21);
            this.tbSn.TabIndex = 1;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(11, 41);
            this.labelX2.Name = "labelX2";
            this.labelX2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX2.Size = new System.Drawing.Size(72, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "MAC";
            // 
            // tbMac
            // 
            // 
            // 
            // 
            this.tbMac.Border.Class = "TextBoxBorder";
            this.tbMac.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbMac.Location = new System.Drawing.Point(89, 41);
            this.tbMac.Name = "tbMac";
            this.tbMac.ReadOnly = true;
            this.tbMac.Size = new System.Drawing.Size(158, 21);
            this.tbMac.TabIndex = 1;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(11, 68);
            this.labelX3.Name = "labelX3";
            this.labelX3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX3.Size = new System.Drawing.Size(72, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "IP";
            // 
            // ipAdd
            // 
            this.ipAdd.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipAdd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipAdd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipAdd.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipAdd.ButtonFreeText.Visible = true;
            this.ipAdd.Location = new System.Drawing.Point(89, 70);
            this.ipAdd.Name = "ipAdd";
            this.ipAdd.Size = new System.Drawing.Size(158, 21);
            this.ipAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipAdd.TabIndex = 2;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(11, 97);
            this.labelX4.Name = "labelX4";
            this.labelX4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX4.Size = new System.Drawing.Size(72, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "子网掩码";
            // 
            // ipMask
            // 
            this.ipMask.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipMask.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipMask.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipMask.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipMask.ButtonFreeText.Visible = true;
            this.ipMask.Location = new System.Drawing.Point(89, 99);
            this.ipMask.Name = "ipMask";
            this.ipMask.Size = new System.Drawing.Size(158, 21);
            this.ipMask.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipMask.TabIndex = 2;
            this.ipMask.Value = "255.255.255.0";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(11, 127);
            this.labelX5.Name = "labelX5";
            this.labelX5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelX5.Size = new System.Drawing.Size(72, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "网关";
            // 
            // ipGateway
            // 
            this.ipGateway.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipGateway.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipGateway.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipGateway.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipGateway.ButtonFreeText.Visible = true;
            this.ipGateway.Location = new System.Drawing.Point(89, 129);
            this.ipGateway.Name = "ipGateway";
            this.ipGateway.Size = new System.Drawing.Size(158, 21);
            this.ipGateway.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipGateway.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(75, 173);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(83, 29);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(164, 173);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 29);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmModifyCtrlrIp
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(310, 221);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ipGateway);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.ipMask);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.ipAdd);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.tbMac);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.tbSn);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModifyCtrlrIp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改控制器IP";
            this.Load += new System.EventHandler(this.FrmModifyCtrlrIp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ipAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipGateway)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSn;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbMac;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.IpAddressInput ipAdd;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.IpAddressInput ipMask;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.Editors.IpAddressInput ipGateway;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}