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
            this.llReset50 = new System.Windows.Forms.LinkLabel();
            this.lbReset100 = new System.Windows.Forms.LinkLabel();
            this.llReset200 = new System.Windows.Forms.LinkLabel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.viewSizeSlider = new DevComponents.DotNetBar.Controls.Slider();
            this.lbImageState = new System.Windows.Forms.Label();
            this.barProccess = new DevComponents.DotNetBar.Bar();
            this.biOpen = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem5 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.cbClipItem = new DevComponents.DotNetBar.ComboBoxItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.tbClipWidth = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.tbClipHeight = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.biCancel = new DevComponents.DotNetBar.ButtonItem();
            this.plImageBack = new System.Windows.Forms.Panel();
            this.openImageDlg = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox = new Li.Controls.ImageEditors.PicturePanel();
            this.biClip = new DevComponents.DotNetBar.ButtonItem();
            this.biZoom = new DevComponents.DotNetBar.ButtonItem();
            this.biRotate = new DevComponents.DotNetBar.ButtonItem();
            this.biRotate90 = new DevComponents.DotNetBar.ButtonItem();
            this.biReverse90 = new DevComponents.DotNetBar.ButtonItem();
            this.biRotate180 = new DevComponents.DotNetBar.ButtonItem();
            this.biFlipVertical = new DevComponents.DotNetBar.ButtonItem();
            this.biFlipHorizintal = new DevComponents.DotNetBar.ButtonItem();
            this.plState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barProccess)).BeginInit();
            this.plImageBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // plState
            // 
            this.plState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plState.Controls.Add(this.llReset50);
            this.plState.Controls.Add(this.lbReset100);
            this.plState.Controls.Add(this.llReset200);
            this.plState.Controls.Add(this.labelX1);
            this.plState.Controls.Add(this.viewSizeSlider);
            this.plState.Controls.Add(this.lbImageState);
            this.plState.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plState.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plState.Location = new System.Drawing.Point(0, 343);
            this.plState.Name = "plState";
            this.plState.Size = new System.Drawing.Size(648, 18);
            this.plState.TabIndex = 2;
            // 
            // llReset50
            // 
            this.llReset50.AutoSize = true;
            this.llReset50.Dock = System.Windows.Forms.DockStyle.Left;
            this.llReset50.Location = new System.Drawing.Point(557, 0);
            this.llReset50.Name = "llReset50";
            this.llReset50.Size = new System.Drawing.Size(33, 17);
            this.llReset50.TabIndex = 5;
            this.llReset50.TabStop = true;
            this.llReset50.Text = "50%";
            this.llReset50.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llReset50_LinkClicked);
            // 
            // lbReset100
            // 
            this.lbReset100.AutoSize = true;
            this.lbReset100.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbReset100.Location = new System.Drawing.Point(517, 0);
            this.lbReset100.Name = "lbReset100";
            this.lbReset100.Size = new System.Drawing.Size(40, 17);
            this.lbReset100.TabIndex = 3;
            this.lbReset100.TabStop = true;
            this.lbReset100.Text = "100%";
            this.lbReset100.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbReset100_LinkClicked);
            // 
            // llReset200
            // 
            this.llReset200.AutoSize = true;
            this.llReset200.Dock = System.Windows.Forms.DockStyle.Left;
            this.llReset200.Location = new System.Drawing.Point(477, 0);
            this.llReset200.Name = "llReset200";
            this.llReset200.Size = new System.Drawing.Size(40, 17);
            this.llReset200.TabIndex = 6;
            this.llReset200.TabStop = true;
            this.llReset200.Text = "200%";
            this.llReset200.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llReset200_LinkClicked);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX1.Location = new System.Drawing.Point(436, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(41, 20);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "  重置:";
            // 
            // viewSizeSlider
            // 
            // 
            // 
            // 
            this.viewSizeSlider.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.viewSizeSlider.Dock = System.Windows.Forms.DockStyle.Left;
            this.viewSizeSlider.LabelPosition = DevComponents.DotNetBar.eSliderLabelPosition.Right;
            this.viewSizeSlider.LabelVisible = false;
            this.viewSizeSlider.Location = new System.Drawing.Point(180, 0);
            this.viewSizeSlider.Name = "viewSizeSlider";
            this.viewSizeSlider.Size = new System.Drawing.Size(256, 16);
            this.viewSizeSlider.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.viewSizeSlider.TabIndex = 1;
            this.viewSizeSlider.Text = "100%";
            this.viewSizeSlider.Value = 50;
            this.viewSizeSlider.ValueChanged += new System.EventHandler(this.viewSizeSlider_ValueChanged);
            // 
            // lbImageState
            // 
            this.lbImageState.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbImageState.Location = new System.Drawing.Point(0, 0);
            this.lbImageState.Name = "lbImageState";
            this.lbImageState.Size = new System.Drawing.Size(180, 16);
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
            this.biZoom,
            this.biRotate,
            this.labelItem4,
            this.biCancel});
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
            this.comboItem3,
            this.comboItem4});
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
            this.comboItem3.Text = "一寸比例";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "二寸比例";
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
            // labelItem4
            // 
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Text = "|";
            // 
            // biCancel
            // 
            this.biCancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biCancel.Image = global::Li.Controls.Properties.Resources.cancelproccess;
            this.biCancel.ImageFixedSize = new System.Drawing.Size(15, 15);
            this.biCancel.Name = "biCancel";
            this.biCancel.Text = "撤销";
            this.biCancel.Click += new System.EventHandler(this.biCancel_Click);
            // 
            // plImageBack
            // 
            this.plImageBack.AutoScroll = true;
            this.plImageBack.BackColor = System.Drawing.Color.Beige;
            this.plImageBack.Controls.Add(this.pictureBox);
            this.plImageBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plImageBack.Location = new System.Drawing.Point(0, 28);
            this.plImageBack.Name = "plImageBack";
            this.plImageBack.Size = new System.Drawing.Size(648, 315);
            this.plImageBack.TabIndex = 5;
            // 
            // openImageDlg
            // 
            this.openImageDlg.Filter = "图片文件|*.jpg;*jpeg;*.bmp;*.png;*.gif；*.tiff";
            this.openImageDlg.Title = "打开图片文件";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox.Image = null;
            this.pictureBox.Location = new System.Drawing.Point(62, 51);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(235, 158);
            this.pictureBox.TabIndex = 0;
            // 
            // biClip
            // 
            this.biClip.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biClip.Image = global::Li.Controls.Properties.Resources.clip;
            this.biClip.ImageFixedSize = new System.Drawing.Size(12, 15);
            this.biClip.Name = "biClip";
            this.biClip.Text = "剪切";
            this.biClip.Click += new System.EventHandler(this.biClip_Click);
            // 
            // biZoom
            // 
            this.biZoom.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biZoom.Image = global::Li.Controls.Properties.Resources.zoom;
            this.biZoom.ImageFixedSize = new System.Drawing.Size(18, 15);
            this.biZoom.Name = "biZoom";
            this.biZoom.Text = "缩放";
            this.biZoom.Click += new System.EventHandler(this.biZoom_Click);
            // 
            // biRotate
            // 
            this.biRotate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biRotate.Image = global::Li.Controls.Properties.Resources.rotateright;
            this.biRotate.ImageFixedSize = new System.Drawing.Size(18, 15);
            this.biRotate.Name = "biRotate";
            this.biRotate.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biRotate90,
            this.biReverse90,
            this.biRotate180,
            this.biFlipVertical,
            this.biFlipHorizintal});
            this.biRotate.Text = "旋转";
            this.biRotate.Tooltip = "旋转";
            this.biRotate.Click += new System.EventHandler(this.biRotate_Click);
            // 
            // biRotate90
            // 
            this.biRotate90.Image = global::Li.Controls.Properties.Resources.rotateright;
            this.biRotate90.ImageFixedSize = new System.Drawing.Size(23, 17);
            this.biRotate90.Name = "biRotate90";
            this.biRotate90.Text = "顺时针旋转90°";
            this.biRotate90.Tooltip = "顺时针旋转90°";
            this.biRotate90.Click += new System.EventHandler(this.biRotate90_Click);
            // 
            // biReverse90
            // 
            this.biReverse90.Image = global::Li.Controls.Properties.Resources.rotatereverse;
            this.biReverse90.ImageFixedSize = new System.Drawing.Size(23, 17);
            this.biReverse90.Name = "biReverse90";
            this.biReverse90.Text = "逆时针旋转90°";
            this.biReverse90.Tooltip = "逆时针旋转90°";
            this.biReverse90.Click += new System.EventHandler(this.biReverse90_Click);
            // 
            // biRotate180
            // 
            this.biRotate180.Image = global::Li.Controls.Properties.Resources.rotate180;
            this.biRotate180.ImageFixedSize = new System.Drawing.Size(23, 17);
            this.biRotate180.Name = "biRotate180";
            this.biRotate180.Text = "旋转180°";
            this.biRotate180.Tooltip = "旋转180°";
            this.biRotate180.Click += new System.EventHandler(this.biRotate180_Click);
            // 
            // biFlipVertical
            // 
            this.biFlipVertical.Image = global::Li.Controls.Properties.Resources.flipVertical;
            this.biFlipVertical.ImageFixedSize = new System.Drawing.Size(23, 17);
            this.biFlipVertical.Name = "biFlipVertical";
            this.biFlipVertical.Text = "垂直翻转";
            this.biFlipVertical.Tooltip = "垂直翻转";
            this.biFlipVertical.Click += new System.EventHandler(this.biFlipVertical_Click);
            // 
            // biFlipHorizintal
            // 
            this.biFlipHorizintal.Image = global::Li.Controls.Properties.Resources.fliphorizintal;
            this.biFlipHorizintal.ImageFixedSize = new System.Drawing.Size(23, 17);
            this.biFlipHorizintal.Name = "biFlipHorizintal";
            this.biFlipHorizintal.Text = "水平翻转";
            this.biFlipHorizintal.Tooltip = "水平翻转";
            this.biFlipHorizintal.Click += new System.EventHandler(this.biFlipHorizintal_Click);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plState;
        private System.Windows.Forms.Label lbImageState;
        private DevComponents.DotNetBar.Bar barProccess;
        private DevComponents.DotNetBar.ButtonItem biClip;
        private System.Windows.Forms.Panel plImageBack;
        private DevComponents.DotNetBar.ComboBoxItem cbClipItem;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem tbClipWidth;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.TextBoxItem tbClipHeight;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.LabelItem labelItem4;
        private DevComponents.DotNetBar.ButtonItem biOpen;
        private DevComponents.DotNetBar.LabelItem labelItem5;
        private System.Windows.Forms.OpenFileDialog openImageDlg;
        private DevComponents.DotNetBar.Controls.Slider viewSizeSlider;
        private ImageEditors.PicturePanel pictureBox;
        private System.Windows.Forms.LinkLabel lbReset100;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.LinkLabel llReset50;
        private System.Windows.Forms.LinkLabel llReset200;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.DotNetBar.ButtonItem biCancel;
        private DevComponents.DotNetBar.ButtonItem biZoom;
        private DevComponents.DotNetBar.ButtonItem biRotate;
        private DevComponents.DotNetBar.ButtonItem biRotate90;
        private DevComponents.DotNetBar.ButtonItem biReverse90;
        private DevComponents.DotNetBar.ButtonItem biRotate180;
        private DevComponents.DotNetBar.ButtonItem biFlipVertical;
        private DevComponents.DotNetBar.ButtonItem biFlipHorizintal;
    }
}
