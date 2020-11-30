namespace SmartAccess.RealDetectMgr
{
    partial class FrmMultiFaceVideo
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnFour = new DevComponents.DotNetBar.ButtonX();
            this.btnOne = new DevComponents.DotNetBar.ButtonX();
            this.multiVideoCtrl = new SmartAccess.RealDetectMgr.MultiFaceVideoCtrl();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnFour);
            this.panelEx1.Controls.Add(this.btnOne);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx1.Location = new System.Drawing.Point(0, 374);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(660, 29);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // btnFour
            // 
            this.btnFour.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFour.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFour.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFour.Location = new System.Drawing.Point(50, 0);
            this.btnFour.Name = "btnFour";
            this.btnFour.Size = new System.Drawing.Size(50, 29);
            this.btnFour.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFour.TabIndex = 1;
            this.btnFour.Text = "四画面";
            this.btnFour.Click += new System.EventHandler(this.btnFour_Click);
            // 
            // btnOne
            // 
            this.btnOne.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOne.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOne.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOne.Location = new System.Drawing.Point(0, 0);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(50, 29);
            this.btnOne.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOne.TabIndex = 0;
            this.btnOne.Text = "一画面";
            this.btnOne.Click += new System.EventHandler(this.btnOne_Click);
            // 
            // multiVideoCtrl
            // 
            this.multiVideoCtrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.multiVideoCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiVideoCtrl.Location = new System.Drawing.Point(0, 0);
            this.multiVideoCtrl.MultiVideoType = SmartAccess.RealDetectMgr.MultiVideoType.Four;
            this.multiVideoCtrl.Name = "multiVideoCtrl";
            this.multiVideoCtrl.Size = new System.Drawing.Size(660, 374);
            this.multiVideoCtrl.TabIndex = 2;
            // 
            // FrmMultiFaceVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 403);
            this.Controls.Add(this.multiVideoCtrl);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.Name = "FrmMultiFaceVideo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "人脸识别视频监控";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMultiFaceVideo_FormClosed);
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnOne;
        private DevComponents.DotNetBar.ButtonX btnFour;
        private MultiFaceVideoCtrl multiVideoCtrl;
    }
}