namespace SmartAccess.VerInfoMgr
{
    partial class FrmUSBInput
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
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerClose
            // 
            this.timerClose.Interval = 500;
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // FrmUSBInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SmartAccess.Properties.Resources.dkq_2525;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(132, 23);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUSBInput";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请刷卡";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmUSBInput_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmUSBInput_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerClose;
    }
}