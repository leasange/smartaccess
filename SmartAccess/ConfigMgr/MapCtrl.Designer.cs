namespace SmartAccess.ConfigMgr
{
    partial class MapCtrl
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
            this.timerWheel = new System.Windows.Forms.Timer(this.components);
            this.cmsFullMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiFullMap = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFullMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerWheel
            // 
            this.timerWheel.Interval = 200;
            this.timerWheel.Tick += new System.EventHandler(this.timerWheel_Tick);
            // 
            // cmsFullMap
            // 
            this.cmsFullMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFullMap});
            this.cmsFullMap.Name = "cmsFullMap";
            this.cmsFullMap.Size = new System.Drawing.Size(125, 26);
            // 
            // tsmiFullMap
            // 
            this.tsmiFullMap.Name = "tsmiFullMap";
            this.tsmiFullMap.Size = new System.Drawing.Size(124, 22);
            this.tsmiFullMap.Text = "全图显示";
            this.tsmiFullMap.Click += new System.EventHandler(this.tsmiFullMap_Click);
            // 
            // MapCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.cmsFullMap;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MapCtrl";
            this.Size = new System.Drawing.Size(633, 388);
            this.Load += new System.EventHandler(this.MapCtrl_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapCtrl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapCtrl_MouseMove);
            this.cmsFullMap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerWheel;
        private System.Windows.Forms.ContextMenuStrip cmsFullMap;
        private System.Windows.Forms.ToolStripMenuItem tsmiFullMap;
    }
}
