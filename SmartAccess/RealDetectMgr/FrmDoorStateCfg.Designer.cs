namespace SmartAccess.RealDetectMgr
{
    partial class FrmDoorStateCfg
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
            this.iDelayTime = new DevComponents.Editors.IntegerInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.rbOnline = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbAlwaysOpen = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbAlwaysClose = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnApplyState = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.iDelayTime)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(12, 54);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(96, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "开门延时（秒）";
            // 
            // iDelayTime
            // 
            // 
            // 
            // 
            this.iDelayTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iDelayTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iDelayTime.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iDelayTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iDelayTime.Location = new System.Drawing.Point(114, 54);
            this.iDelayTime.MaxValue = 120;
            this.iDelayTime.MinValue = 1;
            this.iDelayTime.Name = "iDelayTime";
            this.iDelayTime.ShowUpDown = true;
            this.iDelayTime.Size = new System.Drawing.Size(165, 23);
            this.iDelayTime.TabIndex = 1;
            this.iDelayTime.Value = 3;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(12, 96);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(96, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "门禁状态";
            // 
            // rbOnline
            // 
            this.rbOnline.AutoSize = true;
            // 
            // 
            // 
            this.rbOnline.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbOnline.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbOnline.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbOnline.Location = new System.Drawing.Point(114, 99);
            this.rbOnline.Name = "rbOnline";
            this.rbOnline.Size = new System.Drawing.Size(51, 20);
            this.rbOnline.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbOnline.TabIndex = 3;
            this.rbOnline.Text = "在线";
            // 
            // rbAlwaysOpen
            // 
            this.rbAlwaysOpen.AutoSize = true;
            // 
            // 
            // 
            this.rbAlwaysOpen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbAlwaysOpen.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbAlwaysOpen.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbAlwaysOpen.Location = new System.Drawing.Point(171, 99);
            this.rbAlwaysOpen.Name = "rbAlwaysOpen";
            this.rbAlwaysOpen.Size = new System.Drawing.Size(51, 20);
            this.rbAlwaysOpen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbAlwaysOpen.TabIndex = 3;
            this.rbAlwaysOpen.Text = "常开";
            // 
            // rbAlwaysClose
            // 
            this.rbAlwaysClose.AutoSize = true;
            // 
            // 
            // 
            this.rbAlwaysClose.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbAlwaysClose.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbAlwaysClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbAlwaysClose.Location = new System.Drawing.Point(228, 99);
            this.rbAlwaysClose.Name = "rbAlwaysClose";
            this.rbAlwaysClose.Size = new System.Drawing.Size(51, 20);
            this.rbAlwaysClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbAlwaysClose.TabIndex = 3;
            this.rbAlwaysClose.Text = "常关";
            // 
            // btnApplyState
            // 
            this.btnApplyState.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnApplyState.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnApplyState.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnApplyState.Location = new System.Drawing.Point(114, 147);
            this.btnApplyState.Name = "btnApplyState";
            this.btnApplyState.Size = new System.Drawing.Size(76, 23);
            this.btnApplyState.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnApplyState.TabIndex = 4;
            this.btnApplyState.Text = "确定";
            this.btnApplyState.Click += new System.EventHandler(this.btnApplyState_Click);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.ForeColor = System.Drawing.Color.Red;
            this.labelX3.Location = new System.Drawing.Point(33, 4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(347, 35);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "谨慎设置门禁状态，注意恢复门禁在线";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(196, 147);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 23);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            // 
            // FrmDoorStateCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(308, 182);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApplyState);
            this.Controls.Add(this.rbAlwaysClose);
            this.Controls.Add(this.rbAlwaysOpen);
            this.Controls.Add(this.rbOnline);
            this.Controls.Add(this.iDelayTime);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDoorStateCfg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "门禁设置";
            this.Load += new System.EventHandler(this.FrmDoorStateCfg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iDelayTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IntegerInput iDelayTime;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbOnline;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbAlwaysOpen;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbAlwaysClose;
        private DevComponents.DotNetBar.ButtonX btnApplyState;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btnClose;
    }
}