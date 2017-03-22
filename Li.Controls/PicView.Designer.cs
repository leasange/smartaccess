namespace Li.Controls
{
    partial class PicView
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
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lbiCount = new DevComponents.DotNetBar.LabelItem();
            this.btiPre = new DevComponents.DotNetBar.ButtonItem();
            this.btiNext = new DevComponents.DotNetBar.ButtonItem();
            this.lbiCurrent = new DevComponents.DotNetBar.LabelItem();
            this.btiSave = new DevComponents.DotNetBar.ButtonItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.biEdit = new DevComponents.DotNetBar.ButtonItem();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btiSave,
            this.biEdit,
            this.lbiCount,
            this.btiPre,
            this.lbiCurrent,
            this.btiNext});
            this.bar1.Location = new System.Drawing.Point(0, 184);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(295, 26);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 3;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.Color.Silver;
            this.picBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox.Location = new System.Drawing.Point(0, 0);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(295, 184);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 4;
            this.picBox.TabStop = false;
            // 
            // lbiCount
            // 
            this.lbiCount.Name = "lbiCount";
            this.lbiCount.Text = "共0张";
            // 
            // btiPre
            // 
            this.btiPre.Name = "btiPre";
            this.btiPre.Text = "上一张";
            this.btiPre.Click += new System.EventHandler(this.btiPre_Click);
            // 
            // btiNext
            // 
            this.btiNext.Name = "btiNext";
            this.btiNext.Text = "下一张";
            this.btiNext.Click += new System.EventHandler(this.btiNext_Click);
            // 
            // lbiCurrent
            // 
            this.lbiCurrent.Name = "lbiCurrent";
            this.lbiCurrent.Text = "0";
            // 
            // btiSave
            // 
            this.btiSave.Name = "btiSave";
            this.btiSave.Text = "保存";
            this.btiSave.Click += new System.EventHandler(this.btiSave_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "jpg";
            this.saveFileDialog.Filter = "jpg图片|*.jpg|png图片|*.png|bmp图片|*.bmp";
            this.saveFileDialog.Title = "保存图片";
            // 
            // biEdit
            // 
            this.biEdit.Name = "biEdit";
            this.biEdit.Text = "编辑";
            this.biEdit.Click += new System.EventHandler(this.biEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(270, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 14);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "X";
            this.btnClose.Tooltip = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PicView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.bar1);
            this.Name = "PicView";
            this.Size = new System.Drawing.Size(295, 210);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private System.Windows.Forms.PictureBox picBox;
        private DevComponents.DotNetBar.LabelItem lbiCount;
        private DevComponents.DotNetBar.ButtonItem btiPre;
        private DevComponents.DotNetBar.ButtonItem btiNext;
        private DevComponents.DotNetBar.LabelItem lbiCurrent;
        private DevComponents.DotNetBar.ButtonItem btiSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private DevComponents.DotNetBar.ButtonItem biEdit;
        private DevComponents.DotNetBar.ButtonX btnClose;

    }
}
