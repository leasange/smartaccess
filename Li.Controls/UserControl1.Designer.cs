namespace Li.Controls
{
    partial class UserControl1
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
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.verTextBox1 = new Li.Controls.VerTextBox();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(53, 50);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 21);
            this.maskedTextBox1.TabIndex = 0;
            this.maskedTextBox1.ValidatingType = typeof(int);
            // 
            // verTextBox1
            // 
            this.verTextBox1.Location = new System.Drawing.Point(33, 132);
            this.verTextBox1.Mask = "00000";
            this.verTextBox1.Name = "verTextBox1";
            this.verTextBox1.Size = new System.Drawing.Size(168, 21);
            this.verTextBox1.TabIndex = 1;
            this.verTextBox1.ValidatingType = typeof(System.DateTime);
            this.verTextBox1.VerTextFormat = "[0][A][a][N][n]";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.verTextBox1);
            this.Controls.Add(this.maskedTextBox1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(285, 255);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private VerTextBox verTextBox1;
    }
}
