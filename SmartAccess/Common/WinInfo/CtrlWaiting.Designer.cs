namespace SmartAccess.Common.WinInfo
{
    partial class CtrlWaiting
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.plLoading = new System.Windows.Forms.Panel();
            this.lbText = new DevComponents.DotNetBar.LabelX();
            this.timerShowBack = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.plLoading.SuspendLayout();
            this.SuspendLayout();
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
            // plLoading
            // 
            this.plLoading.Controls.Add(this.lbText);
            this.plLoading.Controls.Add(this.picBox);
            this.plLoading.Location = new System.Drawing.Point(18, 21);
            this.plLoading.Name = "plLoading";
            this.plLoading.Size = new System.Drawing.Size(142, 36);
            this.plLoading.TabIndex = 1;
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
            this.lbText.Size = new System.Drawing.Size(100, 23);
            this.lbText.TabIndex = 1;
            this.lbText.Text = "加载中...";
            // 
            // timerShowBack
            // 
            this.timerShowBack.Tick += new System.EventHandler(this.timerShowBack_Tick);
            // 
            // CtrlWaiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.plLoading);
            this.DoubleBuffered = true;
            this.Name = "CtrlWaiting";
            this.Size = new System.Drawing.Size(270, 89);
            this.Load += new System.EventHandler(this.CtrlWaiting_Load);
            this.SizeChanged += new System.EventHandler(this.CtrlWaiting_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.plLoading.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Panel plLoading;
        private DevComponents.DotNetBar.LabelX lbText;
        private System.Windows.Forms.Timer timerShowBack;

    }
}
