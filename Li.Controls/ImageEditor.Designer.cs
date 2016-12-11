namespace Li.Controls
{
    partial class ImageEditor
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
            this.plState = new System.Windows.Forms.Panel();
            this.lbImageState = new System.Windows.Forms.Label();
            this.barProccess = new DevComponents.DotNetBar.Bar();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.cbClipItem = new DevComponents.DotNetBar.ComboBoxItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.tbClipWidth = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.tbClipHeight = new DevComponents.DotNetBar.TextBoxItem();
            this.biClip = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.plImageBack = new System.Windows.Forms.Panel();
            this.biOpen = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem5 = new DevComponents.DotNetBar.LabelItem();
            this.openImageDlg = new System.Windows.Forms.OpenFileDialog();
            this.viewSizeSlider = new DevComponents.DotNetBar.Controls.Slider();
            this.clipController = new Li.Controls.ImageEditors.ClipController();
            this.pictureBox = new Li.Controls.ImageEditors.PictureBoxEx();
            this.plState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barProccess)).BeginInit();
            this.plImageBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // plState
            // 
            this.plState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plState.Controls.Add(this.viewSizeSlider);
            this.plState.Controls.Add(this.lbImageState);
            this.plState.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plState.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plState.Location = new System.Drawing.Point(0, 337);
            this.plState.Name = "plState";
            this.plState.Size = new System.Drawing.Size(648, 24);
            this.plState.TabIndex = 2;
            // 
            // lbImageState
            // 
            this.lbImageState.AutoSize = true;
            this.lbImageState.Location = new System.Drawing.Point(3, 4);
            this.lbImageState.Name = "lbImageState";
            this.lbImageState.Size = new System.Drawing.Size(143, 17);
            this.lbImageState.TabIndex = 0;
            this.lbImageState.Text = "宽:0 高:0 显示比例:100%";
            // 
            // barProccess
            // 
            this.barProccess.AntiAlias = true;
            this.barProccess.Dock = System.Windows.Forms.DockStyle.Top;
            this.barProccess.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.barProccess.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biOpen,
            this.labelItem5,
            this.labelItem3,
            this.cbClipItem,
            this.labelItem1,
            this.tbClipWidth,
            this.labelItem2,
            this.tbClipHeight,
            this.biClip,
            this.labelItem4});
            this.barProccess.Location = new System.Drawing.Point(0, 0);
            this.barProccess.Name = "barProccess";
            this.barProccess.RoundCorners = false;
            this.barProccess.Size = new System.Drawing.Size(648, 28);
            this.barProccess.Stretch = true;
            this.barProccess.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.barProccess.TabIndex = 4;
            this.barProccess.TabStop = false;
            this.barProccess.Text = "bar1";
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "选项:";
            // 
            // cbClipItem
            // 
            this.cbClipItem.ComboWidth = 80;
            this.cbClipItem.DropDownHeight = 106;
            this.cbClipItem.ItemHeight = 17;
            this.cbClipItem.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.cbClipItem.Name = "cbClipItem";
            this.cbClipItem.SelectedIndexChanged += new System.EventHandler(this.cbClipItem_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "自由裁剪";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "固定比例";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "指定大小";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "宽:";
            // 
            // tbClipWidth
            // 
            this.tbClipWidth.Name = "tbClipWidth";
            this.tbClipWidth.Text = "3";
            this.tbClipWidth.TextBoxWidth = 32;
            this.tbClipWidth.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "高:";
            // 
            // tbClipHeight
            // 
            this.tbClipHeight.Name = "tbClipHeight";
            this.tbClipHeight.Text = "4";
            this.tbClipHeight.TextBoxWidth = 32;
            this.tbClipHeight.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // biClip
            // 
            this.biClip.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biClip.Name = "biClip";
            this.biClip.Text = "剪切";
            this.biClip.Click += new System.EventHandler(this.biClip_Click);
            // 
            // labelItem4
            // 
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Text = "|";
            // 
            // plImageBack
            // 
            this.plImageBack.AutoScroll = true;
            this.plImageBack.Controls.Add(this.clipController);
            this.plImageBack.Controls.Add(this.pictureBox);
            this.plImageBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plImageBack.Location = new System.Drawing.Point(0, 28);
            this.plImageBack.Name = "plImageBack";
            this.plImageBack.Size = new System.Drawing.Size(648, 309);
            this.plImageBack.TabIndex = 5;
            // 
            // biOpen
            // 
            this.biOpen.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biOpen.Name = "biOpen";
            this.biOpen.Text = "打开";
            this.biOpen.Click += new System.EventHandler(this.biOpen_Click);
            // 
            // labelItem5
            // 
            this.labelItem5.Name = "labelItem5";
            this.labelItem5.Text = "|";
            // 
            // openImageDlg
            // 
            this.openImageDlg.Filter = "图片文件|*.jpg;*jpeg;*.bmp;*.png;*.gif；*.tiff";
            this.openImageDlg.Title = "打开图片文件";
            // 
            // viewSizeSlider
            // 
            // 
            // 
            // 
            this.viewSizeSlider.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.viewSizeSlider.Dock = System.Windows.Forms.DockStyle.Right;
            this.viewSizeSlider.Location = new System.Drawing.Point(434, 0);
            this.viewSizeSlider.Name = "viewSizeSlider";
            this.viewSizeSlider.Size = new System.Drawing.Size(212, 22);
            this.viewSizeSlider.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.viewSizeSlider.TabIndex = 1;
            this.viewSizeSlider.Text = "显示比例";
            this.viewSizeSlider.Value = 50;
            this.viewSizeSlider.ValueChanged += new System.EventHandler(this.viewSizeSlider_ValueChanged);
            // 
            // clipController
            // 
            this.clipController.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.clipController.Location = new System.Drawing.Point(57, 52);
            this.clipController.Name = "clipController";
            this.clipController.Size = new System.Drawing.Size(79, 62);
            this.clipController.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(248, 248);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plImageBack);
            this.Controls.Add(this.barProccess);
            this.Controls.Add(this.plState);
            this.Name = "ImageEditor";
            this.Size = new System.Drawing.Size(648, 361);
            this.Load += new System.EventHandler(this.ImageEditor_Load);
            this.SizeChanged += new System.EventHandler(this.ImageEditor_SizeChanged);
            this.plState.ResumeLayout(false);
            this.plState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barProccess)).EndInit();
            this.plImageBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plState;
        private System.Windows.Forms.Label lbImageState;
        private DevComponents.DotNetBar.Bar barProccess;
        private DevComponents.DotNetBar.ButtonItem biClip;
        private System.Windows.Forms.Panel plImageBack;
        private  Li.Controls.ImageEditors.PictureBoxEx pictureBox;
        private DevComponents.DotNetBar.ComboBoxItem cbClipItem;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem tbClipWidth;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.TextBoxItem tbClipHeight;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.DotNetBar.LabelItem labelItem4;
        private DevComponents.DotNetBar.ButtonItem biOpen;
        private DevComponents.DotNetBar.LabelItem labelItem5;
        private System.Windows.Forms.OpenFileDialog openImageDlg;
        private DevComponents.DotNetBar.Controls.Slider viewSizeSlider;
        private ImageEditors.ClipController clipController;
    }
}
