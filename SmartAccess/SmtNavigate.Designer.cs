namespace SmartAccess
{
    partial class SmtNavigate
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
            this.navigateItems = new Li.Controls.NavigateItems();
            this.SuspendLayout();
            // 
            // navigateItems
            // 
            this.navigateItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigateItems.Location = new System.Drawing.Point(0, 0);
            this.navigateItems.Name = "navigateItems";
            this.navigateItems.Size = new System.Drawing.Size(235, 385);
            this.navigateItems.TabIndex = 1;
            // 
            // SmtNavigate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigateItems);
            this.Name = "SmtNavigate";
            this.Size = new System.Drawing.Size(235, 385);
            this.ResumeLayout(false);

        }

        #endregion

        private Li.Controls.NavigateItems navigateItems;
    }
}
