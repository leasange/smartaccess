namespace SmartAccess.RealDetectMgr
{
    partial class VideoPlayer
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            this.plClose = new DevComponents.DotNetBar.PanelEx();
            this.lbTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerCheck
            // 
            this.timerCheck.Interval = 300;
            this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
            // 
            // plClose
            // 
            this.plClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.plClose.CanvasColor = System.Drawing.SystemColors.Control;
            this.plClose.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.plClose.Location = new System.Drawing.Point(359, 1);
            this.plClose.Name = "plClose";
            this.plClose.Size = new System.Drawing.Size(16, 10);
            this.plClose.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.plClose.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.plClose.Style.BackColor2.Color = System.Drawing.Color.Gray;
            this.plClose.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.plClose.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.plClose.Style.GradientAngle = 90;
            this.plClose.TabIndex = 1;
            this.plClose.Text = "×";
            this.plClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbTip
            // 
            this.lbTip.AutoSize = true;
            this.lbTip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTip.ForeColor = System.Drawing.Color.Red;
            this.lbTip.Location = new System.Drawing.Point(158, 107);
            this.lbTip.Name = "lbTip";
            this.lbTip.Size = new System.Drawing.Size(65, 20);
            this.lbTip.TabIndex = 2;
            this.lbTip.Text = "暂无视频";
            // 
            // VideoPlayer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.lbTip);
            this.Controls.Add(this.plClose);
            this.DoubleBuffered = true;
            this.Name = "VideoPlayer";
            this.Size = new System.Drawing.Size(377, 254);
            this.Load += new System.EventHandler(this.VideoPlayer_Load);
            this.SizeChanged += new System.EventHandler(this.VideoPlayer_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.VideoPlayer_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.VideoPlayer_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerCheck;
        private DevComponents.DotNetBar.PanelEx plClose;
        private System.Windows.Forms.Label lbTip;
    }
}
