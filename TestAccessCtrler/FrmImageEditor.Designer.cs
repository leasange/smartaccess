namespace TestAccessCtrler
{
    partial class FrmImageEditor
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
            this.imageEditor1 = new Li.Controls.ImageEditor();
            this.SuspendLayout();
            // 
            // imageEditor1
            // 
            this.imageEditor1.BaseImage = null;
            this.imageEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageEditor1.Location = new System.Drawing.Point(0, 0);
            this.imageEditor1.Name = "imageEditor1";
            this.imageEditor1.ProccessBarVisible = true;
            this.imageEditor1.Size = new System.Drawing.Size(673, 383);
            this.imageEditor1.StateVisible = true;
            this.imageEditor1.TabIndex = 0;
            this.imageEditor1.ViewMultiple = 1D;
            // 
            // FrmImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 383);
            this.Controls.Add(this.imageEditor1);
            this.Name = "FrmImageEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图片编辑器";
            this.ResumeLayout(false);

        }

        #endregion

        private Li.Controls.ImageEditor imageEditor1;
    }
}