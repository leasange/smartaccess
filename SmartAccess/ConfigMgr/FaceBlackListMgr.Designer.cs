namespace SmartAccess.ConfigMgr
{
    partial class FaceBlackListMgr
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("11111", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("22222", 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceBlackListMgr));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biAdd = new DevComponents.DotNetBar.ButtonItem();
            this.biModify = new DevComponents.DotNetBar.ButtonItem();
            this.biDelete = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.tbSex = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.listFaces = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biAdd,
            this.biModify,
            this.biDelete});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(802, 46);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 15;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biAdd
            // 
            this.biAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAdd.Image = global::SmartAccess.Properties.Resources.增加;
            this.biAdd.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biAdd.Name = "biAdd";
            this.biAdd.Text = "添加";
            this.biAdd.Tooltip = "添加人脸黑名单";
            this.biAdd.Click += new System.EventHandler(this.biAdd_Click);
            // 
            // biModify
            // 
            this.biModify.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biModify.Image = global::SmartAccess.Properties.Resources.增加;
            this.biModify.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biModify.Name = "biModify";
            this.biModify.Text = "修改";
            this.biModify.Tooltip = " 修改选择";
            // 
            // biDelete
            // 
            this.biDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDelete.Image = global::SmartAccess.Properties.Resources.销卡;
            this.biDelete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.biDelete.Name = "biDelete";
            this.biDelete.Text = "删除";
            this.biDelete.Tooltip = "添加人脸黑名单";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.picBox);
            this.panelEx1.Controls.Add(this.tbSex);
            this.panelEx1.Controls.Add(this.textBoxX2);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.tbName);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx1.Location = new System.Drawing.Point(570, 46);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(232, 413);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 18;
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(20, 217);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(31, 20);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "照片";
            // 
            // picBox
            // 
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(57, 217);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(156, 160);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 6;
            this.picBox.TabStop = false;
            // 
            // tbSex
            // 
            // 
            // 
            // 
            this.tbSex.Border.Class = "TextBoxBorder";
            this.tbSex.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbSex.Location = new System.Drawing.Point(57, 41);
            this.tbSex.MaxLength = 25;
            this.tbSex.Name = "tbSex";
            this.tbSex.ReadOnly = true;
            this.tbSex.Size = new System.Drawing.Size(156, 23);
            this.tbSex.TabIndex = 5;
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.Location = new System.Drawing.Point(57, 70);
            this.textBoxX2.MaxLength = 250;
            this.textBoxX2.Multiline = true;
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.ReadOnly = true;
            this.textBoxX2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxX2.Size = new System.Drawing.Size(156, 141);
            this.textBoxX2.TabIndex = 4;
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(20, 70);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(31, 20);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "描述";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(20, 44);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(31, 20);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "性别";
            // 
            // tbName
            // 
            // 
            // 
            // 
            this.tbName.Border.Class = "TextBoxBorder";
            this.tbName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbName.Location = new System.Drawing.Point(57, 12);
            this.tbName.MaxLength = 25;
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(156, 23);
            this.tbName.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(20, 15);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(31, 20);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "姓名";
            // 
            // listFaces
            // 
            this.listFaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFaces.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listFaces.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listFaces.LargeImageList = this.imageList;
            this.listFaces.Location = new System.Drawing.Point(0, 46);
            this.listFaces.Name = "listFaces";
            this.listFaces.ShowItemToolTips = true;
            this.listFaces.Size = new System.Drawing.Size(570, 413);
            this.listFaces.TabIndex = 20;
            this.listFaces.UseCompatibleStateImageBehavior = false;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "default");
            this.imageList.Images.SetKeyName(1, "loading");
            // 
            // FaceBlackListMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listFaces);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.bar1);
            this.Name = "FaceBlackListMgr";
            this.Size = new System.Drawing.Size(802, 459);
            this.Load += new System.EventHandler(this.FaceBlackListMgr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biAdd;
        private DevComponents.DotNetBar.ButtonItem biDelete;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.ButtonItem biModify;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSex;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.ListView listFaces;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.ImageList imageList;

    }
}
