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
            this.biClearImage = new DevComponents.DotNetBar.ButtonItem();
            this.biFullExtent = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteDoor = new DevComponents.DotNetBar.ButtonItem();
            this.biClearDoors = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.tbMapName = new DevComponents.DotNetBar.TextBoxItem();
            this.biSave = new DevComponents.DotNetBar.ButtonItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mapCtrl = new SmartAccess.ConfigMgr.MapCtrl();
            this.doorTree = new SmartAccess.VerInfoMgr.DoorTree();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.faceDevTree = new SmartAccess.VerInfoMgr.FaceDevTree();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
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
            this.bar1.Size = new System.Drawing.Size(699, 29);
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
            // biClearImage
            // 
            this.biClearImage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biClearImage.Image = global::SmartAccess.Properties.Resources.换卡;
            this.biClearImage.Name = "biClearImage";
            this.biClearImage.Text = "清除地图图片";
            this.biClearImage.Click += new System.EventHandler(this.biClearImage_Click);
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
            // biClearDoors
            // 
            this.biClearDoors.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biClearDoors.Image = global::SmartAccess.Properties.Resources.换卡;
            this.biClearDoors.Name = "biClearDoors";
            this.biClearDoors.Text = "清除门禁";
            this.biClearDoors.Click += new System.EventHandler(this.biClearDoors_Click);
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
            this.mapCtrl.MapName = "";
            this.mapCtrl.MapRect = ((System.Drawing.RectangleF)(resources.GetObject("mapCtrl.MapRect")));
            this.mapCtrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mapCtrl.Name = "mapCtrl";
            this.mapCtrl.Size = new System.Drawing.Size(699, 366);
            this.mapCtrl.TabIndex = 9;
            this.mapCtrl.TextBoundColor = System.Drawing.Color.White;
            this.mapCtrl.DragDrop += new System.Windows.Forms.DragEventHandler(this.mapCtrl_DragDrop);
            this.mapCtrl.DragEnter += new System.Windows.Forms.DragEventHandler(this.mapCtrl_DragEnter);
            this.mapCtrl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mapCtrl_KeyUp);
            // 
            // doorTree
            // 
            this.doorTree.CheckBoxVisible = false;
            this.doorTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doorTree.Location = new System.Drawing.Point(1, 1);
            this.doorTree.Name = "doorTree";
            this.doorTree.Size = new System.Drawing.Size(268, 367);
            this.doorTree.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(270, 395);
            this.tabControl1.TabIndex = 10;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.doorTree);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(270, 369);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "门禁设备";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.faceDevTree);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(270, 369);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // faceDevTree
            // 
            this.faceDevTree.CheckBoxVisible = false;
            this.faceDevTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faceDevTree.Location = new System.Drawing.Point(1, 1);
            this.faceDevTree.Name = "faceDevTree";
            this.faceDevTree.Size = new System.Drawing.Size(268, 367);
            this.faceDevTree.TabIndex = 0;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "人脸设备";
            // 
            // FrmEditMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 395);
            this.Controls.Add(this.mapCtrl);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "FrmEditMap";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑/修改地图";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEditMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
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
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private VerInfoMgr.FaceDevTree faceDevTree;
    }
}