namespace Li.Controls
{
    partial class PageDataGridView
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
            this.pageCtrl = new Li.Controls.PageCtrl();
            this.dataGridPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pageCtrl
            // 
            this.pageCtrl.CurrentPage = 1;
            this.pageCtrl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageCtrl.ExportButtonVisible = true;
            this.pageCtrl.Location = new System.Drawing.Point(0, 279);
            this.pageCtrl.Name = "pageCtrl";
            this.pageCtrl.RecordsPerPage = 30;
            this.pageCtrl.Size = new System.Drawing.Size(697, 32);
            this.pageCtrl.TabIndex = 0;
            this.pageCtrl.TotalRecords = 0;
            this.pageCtrl.PageChanged += new Li.Controls.PageCtrl.PageEventHandle(this.pageCtrl_PageChanged);
            // 
            // dataGridPanel
            // 
            this.dataGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridPanel.Location = new System.Drawing.Point(0, 0);
            this.dataGridPanel.Name = "dataGridPanel";
            this.dataGridPanel.Size = new System.Drawing.Size(697, 279);
            this.dataGridPanel.TabIndex = 1;
            this.dataGridPanel.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.dataGridPanel_ControlAdded);
            // 
            // PageDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.dataGridPanel);
            this.Controls.Add(this.pageCtrl);
            this.Name = "PageDataGridView";
            this.Size = new System.Drawing.Size(697, 311);
            this.ResumeLayout(false);

        }

        #endregion

        private PageCtrl pageCtrl;
        private System.Windows.Forms.Panel dataGridPanel;
    }
}
