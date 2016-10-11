namespace SmartAccess.Common.WinInfo
{
    partial class FrmWaiting
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
            this.plLoading = new System.Windows.Forms.Panel();
            this.lbText = new DevComponents.DotNetBar.LabelX();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.plLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // plLoading
            // 
            this.plLoading.Controls.Add(this.lbText);
            this.plLoading.Controls.Add(this.picBox);
            this.plLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plLoading.Location = new System.Drawing.Point(0, 0);
            this.plLoading.Name = "plLoading";
            this.plLoading.Size = new System.Drawing.Size(183, 34);
            this.plLoading.TabIndex = 2;
            // 
            // lbText
            // 
            this.lbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.lbText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbText.Location = new System.Drawing.Point(39, 6);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(141, 21);
            this.lbText.TabIndex = 1;
            this.lbText.Text = "加载中...";
            // 
            // picBox
            // 
            this.picBox.Image = global::SmartAccess.Properties.Resources.loading;
            this.picBox.Location = new System.Drawing.Point(3, 3);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(29, 28);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // FrmWaiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 34);
            this.Controls.Add(this.plLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmWaiting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmWaiting";
            this.plLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Panel plLoading;
        private DevComponents.DotNetBar.LabelX lbText;
    }
}