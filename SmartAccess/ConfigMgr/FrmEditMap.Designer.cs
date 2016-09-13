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
            this.biFullExtent = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteDoor = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.tbMapName = new DevComponents.DotNetBar.TextBoxItem();
            this.biSave = new DevComponents.DotNetBar.ButtonItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mapCtrl = new SmartAccess.ConfigMgr.MapCtrl();
            this.doorTree = new SmartAccess.VerInfoMgr.DoorTree();
            this.biClearDoors = new DevComponents.DotNetBar.ButtonItem();
            this.biClearImage = new DevComponents.DotNetBar.ButtonItem();
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
            this.biClearImage,
            this.biFullExtent,
            this.biDeleteDoor,
            this.biClearDoors,
            this.labelItem1,
            this.tbMapName,
            this.biSave});
            this.bar1.Location = new System.Drawing.Point(270, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(740, 29);
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
            this.biSelectImage.Click += new System.EventHandler(this.biSelectImage_Click);
            // 
            // biFullExtent
            // 
            this.biFullExtent.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biFullExtent.Image = global::SmartAccess.Properties.Resources.修改部门;
            this.biFullExtent.Name = "biFullExtent";
            this.biFullExtent.Text = "全图显示";
            this.biFullExtent.Click += new System.EventHandler(this.biFullExtent_Click);
            // 
            // biDeleteDoor
            // 
            this.biDeleteDoor.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDeleteDoor.Image = global::SmartAccess.Properties.Resources.换卡;
            this.biDeleteDoor.Name = "biDeleteDoor";
            this.biDeleteDoor.Text = "删除选择门禁";
            this.biDeleteDoor.Click += new System.EventHandler(this.biDeleteDoor_Click);
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
            this.biSave.Click += new System.EventHandler(this.biSave_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "jpg";
            this.openFileDialog.Filter = "图片文件|*.jpg;*.jpeg;*.bmp;*.png;*.tiff;*.gif|所有文件|*.*";
            this.openFileDialog.Title = "选择地图背景";
            // 
            // mapCtrl
            // 
            this.mapCtrl.AllowDrop = true;
            this.mapCtrl.BackColor = System.Drawing.Color.White;
            this.mapCtrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mapCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapCtrl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mapCtrl.ForeColor = System.Drawing.Color.Black;
            this.mapCtrl.IsEditMode = true;
            this.mapCtrl.Location = new System.Drawing.Point(270, 29);
            this.mapCtrl.MapImage = null;
            this.mapCtrl.MapRect = ((System.Drawing.RectangleF)(resources.GetObject("mapCtrl.MapRect")));
            this.mapCtrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mapCtrl.Name = "mapCtrl";
            this.mapCtrl.Size = new System.Drawing.Size(740, 417);
            this.mapCtrl.TabIndex = 9;
            this.mapCtrl.TextBoundColor = System.Drawing.Color.White;
            this.mapCtrl.DragDrop += new System.Windows.Forms.DragEventHandler(this.mapCtrl_DragDrop);
            this.mapCtrl.DragEnter += new System.Windows.Forms.DragEventHandler(this.mapCtrl_DragEnter);
            this.mapCtrl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mapCtrl_KeyUp);
            // 
            // doorTree
            // 
            this.doorTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.doorTree.Location = new System.Drawing.Point(0, 0);
            this.doorTree.Name = "doorTree";
            this.doorTree.Size = new System.Drawing.Size(270, 446);
            this.doorTree.TabIndex = 7;
            // 
            // biClearDoors
            // 
            this.biClearDoors.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biClearDoors.Image = global::SmartAccess.Properties.Resources.换卡;
            this.biClearDoors.Name = "biClearDoors";
            this.biClearDoors.Text = "清除门禁";
            this.biClearDoors.Click += new System.EventHandler(this.biClearDoors_Click);
            // 
            // biClearImage
            // 
            this.biClearImage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biClearImage.Image = global::SmartAccess.Properties.Resources.换卡;
            this.biClearImage.Name = "biClearImage";
            this.biClearImage.Text = "清除地图图片";
            this.biClearImage.Click += new System.EventHandler(this.biClearImage_Click);
            // 
            // FrmEditMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 446);
            this.Controls.Add(this.mapCtrl);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.doorTree);
            this.DoubleBuffered = true;
            this.Name = "FrmEditMap";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑/修改地图";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEditMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private VerInfoMgr.DoorTree doorTree;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biSelectImage;
        private DevComponents.DotNetBar.ButtonItem biFullExtent;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.TextBoxItem tbMapName;
        private DevComponents.DotNetBar.ButtonItem biSave;
        private DevComponents.DotNetBar.ButtonItem biDeleteDoor;
        private MapCtrl mapCtrl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevComponents.DotNetBar.ButtonItem biClearDoors;
        private DevComponents.DotNetBar.ButtonItem biClearImage;
    }
}