namespace SmartAccess.ConfigMgr
{
    partial class FrmEditMap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditMap));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biSelectImage = new DevComponents.DotNetBar.ButtonItem();
            this.doorTree = new SmartAccess.VerInfoMgr.DoorTree();
            this.mapCtrl = new SmartAccess.ConfigMgr.MapCtrl();
            this.biFullExtent = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.tbMapName = new DevComponents.DotNetBar.TextBoxItem();
            this.biSave = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biSelectImage,
            this.biFullExtent,
            this.labelItem1,
            this.tbMapName,
            this.biSave});
            this.bar1.Location = new System.Drawing.Point(270, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(641, 29);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 8;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biSelectImage
            // 
            this.biSelectImage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biSelectImage.Image = global::SmartAccess.Properties.Resources.注册;
            this.biSelectImage.Name = "biSelectImage";
            this.biSelectImage.Text = "选择地图图片";
            // 
            // doorTree
            // 
            this.doorTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.doorTree.Location = new System.Drawing.Point(0, 0);
            this.doorTree.Name = "doorTree";
            this.doorTree.Size = new System.Drawing.Size(270, 446);
            this.doorTree.TabIndex = 7;
            // 
            // mapCtrl
            // 
            this.mapCtrl.BackColor = System.Drawing.Color.White;
            this.mapCtrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mapCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapCtrl.Location = new System.Drawing.Point(270, 29);
            this.mapCtrl.MapImage = null;
            this.mapCtrl.MapRect = ((System.Drawing.RectangleF)(resources.GetObject("mapCtrl.MapRect")));
            this.mapCtrl.Name = "mapCtrl";
            this.mapCtrl.Size = new System.Drawing.Size(641, 417);
            this.mapCtrl.TabIndex = 9;
            this.mapCtrl.DragDrop += new System.Windows.Forms.DragEventHandler(this.mapCtrl_DragDrop);
            this.mapCtrl.DragEnter += new System.Windows.Forms.DragEventHandler(this.mapCtrl_DragEnter);
            // 
            // biFullExtent
            // 
            this.biFullExtent.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biFullExtent.Image = global::SmartAccess.Properties.Resources.修改部门;
            this.biFullExtent.Name = "biFullExtent";
            this.biFullExtent.Text = "全图显示";
            // 
            // labelItem1
            // 
            this.labelItem1.ForeColor = System.Drawing.Color.Black;
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "地图名称:";
            // 
            // tbMapName
            // 
            this.tbMapName.Name = "tbMapName";
            this.tbMapName.TextBoxWidth = 128;
            this.tbMapName.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.tbMapName.WatermarkText = "输入地图名称";
            // 
            // biSave
            // 
            this.biSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biSave.Image = global::SmartAccess.Properties.Resources.换卡;
            this.biSave.Name = "biSave";
            this.biSave.Text = "保存";
            // 
            // FrmEditMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 446);
            this.Controls.Add(this.mapCtrl);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.doorTree);
            this.DoubleBuffered = true;
            this.Name = "FrmEditMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑/修改地图";
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private VerInfoMgr.DoorTree doorTree;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biSelectImage;
        private MapCtrl mapCtrl;
        private DevComponents.DotNetBar.ButtonItem biFullExtent;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem tbMapName;
        private DevComponents.DotNetBar.ButtonItem biSave;
    }
}