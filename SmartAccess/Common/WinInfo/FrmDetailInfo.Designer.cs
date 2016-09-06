namespace SmartAccess.Common.WinInfo
{
    partial class FrmDetailInfo
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
            this.progressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.tbMsg = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.cmsStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            // 
            // 
            // 
            this.progressBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.progressBar.Location = new System.Drawing.Point(0, 327);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(787, 26);
            this.progressBar.TabIndex = 1;
            this.progressBar.Text = "当前进度：0%";
            this.progressBar.TextVisible = true;
            // 
            // tbMsg
            // 
            // 
            // 
            // 
            this.tbMsg.BackgroundStyle.Class = "RichTextBoxBorder";
            this.tbMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbMsg.ContextMenuStrip = this.cmsStrip;
            this.tbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMsg.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMsg.Location = new System.Drawing.Point(0, 0);
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.ReadOnly = true;
            this.tbMsg.Size = new System.Drawing.Size(787, 327);
            this.tbMsg.TabIndex = 3;
            // 
            // cmsStrip
            // 
            this.cmsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopy});
            this.cmsStrip.Name = "cmsStrip";
            this.cmsStrip.Size = new System.Drawing.Size(101, 26);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(152, 22);
            this.tsmiCopy.Text = "复制";
            this.tsmiCopy.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // FrmDetailInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 353);
            this.Controls.Add(this.tbMsg);
            this.Controls.Add(this.progressBar);
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.Name = "FrmDetailInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "详细信息";
            this.cmsStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ProgressBarX progressBar;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx tbMsg;
        private System.Windows.Forms.ContextMenuStrip cmsStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
    }
}