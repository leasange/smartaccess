namespace SmartAccess.ConfigMgr
{
    partial class FrmDBBackup
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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnStartBk = new DevComponents.DotNetBar.ButtonX();
            this.tbPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.iiDays = new DevComponents.Editors.IntegerInput();
            this.cbAutoBk = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.iiDays)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(43, 30);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(58, 20);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "备份目录";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(43, 94);
            this.labelX2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(58, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "备份天数";
            // 
            // btnStartBk
            // 
            this.btnStartBk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartBk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStartBk.Location = new System.Drawing.Point(71, 164);
            this.btnStartBk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStartBk.Name = "btnStartBk";
            this.btnStartBk.Size = new System.Drawing.Size(118, 33);
            this.btnStartBk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnStartBk.TabIndex = 1;
            this.btnStartBk.Text = "立即执行备份";
            this.btnStartBk.Click += new System.EventHandler(this.btnStartBk_Click);
            // 
            // tbPath
            // 
            // 
            // 
            // 
            this.tbPath.Border.Class = "TextBoxBorder";
            this.tbPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbPath.Location = new System.Drawing.Point(107, 27);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(266, 23);
            this.tbPath.TabIndex = 2;
            this.tbPath.WatermarkText = "数据库服务器目录，FTP目录或远程共享目录";
            // 
            // iiDays
            // 
            this.iiDays.AllowEmptyState = false;
            // 
            // 
            // 
            this.iiDays.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iiDays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iiDays.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iiDays.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.iiDays.Location = new System.Drawing.Point(107, 94);
            this.iiDays.MaxValue = 100;
            this.iiDays.MinValue = 1;
            this.iiDays.Name = "iiDays";
            this.iiDays.ShowUpDown = true;
            this.iiDays.Size = new System.Drawing.Size(266, 23);
            this.iiDays.TabIndex = 3;
            this.iiDays.Value = 5;
            // 
            // cbAutoBk
            // 
            // 
            // 
            // 
            this.cbAutoBk.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbAutoBk.Checked = true;
            this.cbAutoBk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoBk.CheckValue = "Y";
            this.cbAutoBk.Location = new System.Drawing.Point(107, 123);
            this.cbAutoBk.Name = "cbAutoBk";
            this.cbAutoBk.Size = new System.Drawing.Size(100, 23);
            this.cbAutoBk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbAutoBk.TabIndex = 4;
            this.cbAutoBk.Text = "启动自动备份";
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(195, 164);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 33);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(277, 164);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 33);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Red;
            this.labelX3.Location = new System.Drawing.Point(107, 52);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(266, 32);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "数据库服务器:存在的目录或FTP目录\r\n或远程共享目录(\\\\IP\\bakfolder)";
            // 
            // FrmDBBackup
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 219);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.cbAutoBk);
            this.Controls.Add(this.iiDays);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnStartBk);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDBBackup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据库备份";
            this.Load += new System.EventHandler(this.FrmDBBackup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iiDays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX btnStartBk;
        private DevComponents.DotNetBar.Controls.TextBoxX tbPath;
        private DevComponents.Editors.IntegerInput iiDays;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbAutoBk;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}