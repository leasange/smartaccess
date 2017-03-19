namespace SmartAccess.RealDetectMgr
{
    partial class RealDoorState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealDoorState));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("11111", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("22222", 2);
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.tbFilterItem = new DevComponents.DotNetBar.TextBoxItem();
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.cmsDoorState = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDoorStateCfg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemoteOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.lbAction = new DevComponents.DotNetBar.LabelX();
            this.lbDoorName = new DevComponents.DotNetBar.LabelX();
            this.lbTime = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.lbDeptName = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.lbStaffName = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelDown = new DevComponents.DotNetBar.PanelEx();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.listDoors = new System.Windows.Forms.ListView();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.biSelectAll = new DevComponents.DotNetBar.ButtonItem();
            this.biRealDetect = new DevComponents.DotNetBar.ButtonItem();
            this.biStop = new DevComponents.DotNetBar.ButtonItem();
            this.biDetectCtrlr = new DevComponents.DotNetBar.ButtonItem();
            this.biAdjustTime = new DevComponents.DotNetBar.ButtonItem();
            this.biRemoteOpen = new DevComponents.DotNetBar.ButtonItem();
            this.biClearInfo = new DevComponents.DotNetBar.ButtonItem();
            this.biSearch = new DevComponents.DotNetBar.ButtonItem();
            this.dgvRealLog = new Li.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.cmsDoorState.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.panelDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealLog)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biSelectAll,
            this.biRealDetect,
            this.biStop,
            this.biDetectCtrlr,
            this.biAdjustTime,
            this.biRemoteOpen,
            this.biClearInfo,
            this.tbFilterItem,
            this.biSearch});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(955, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 3;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // tbFilterItem
            // 
            this.tbFilterItem.Name = "tbFilterItem";
            this.tbFilterItem.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.tbFilterItem.WatermarkText = "输入查找关键字";
            // 
            // smallImageList
            // 
            this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImageList.Images.SetKeyName(0, "door_close.jpg");
            this.smallImageList.Images.SetKeyName(1, "room_open.png");
            this.smallImageList.Images.SetKeyName(2, "door_dump.png");
            this.smallImageList.Images.SetKeyName(3, "door_disable.jpg");
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.GlobalItem = false;
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // cmsDoorState
            // 
            this.cmsDoorState.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDoorStateCfg,
            this.tsmiRemoteOpen});
            this.cmsDoorState.Name = "cmsDoorState";
            this.cmsDoorState.Size = new System.Drawing.Size(149, 48);
            // 
            // tsmiDoorStateCfg
            // 
            this.tsmiDoorStateCfg.Name = "tsmiDoorStateCfg";
            this.tsmiDoorStateCfg.Size = new System.Drawing.Size(148, 22);
            this.tsmiDoorStateCfg.Text = "设置门禁状态";
            this.tsmiDoorStateCfg.Click += new System.EventHandler(this.tsmiDoorStateCfg_Click);
            // 
            // tsmiRemoteOpen
            // 
            this.tsmiRemoteOpen.Name = "tsmiRemoteOpen";
            this.tsmiRemoteOpen.Size = new System.Drawing.Size(148, 22);
            this.tsmiRemoteOpen.Text = "远程开门";
            this.tsmiRemoteOpen.Click += new System.EventHandler(this.tsmiRemoteOpen_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.lbAction);
            this.panelEx1.Controls.Add(this.lbDoorName);
            this.panelEx1.Controls.Add(this.lbTime);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.lbDeptName);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.lbStaffName);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.picBox);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEx1.Location = new System.Drawing.Point(696, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(259, 181);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 9;
            // 
            // lbAction
            // 
            this.lbAction.AutoSize = true;
            // 
            // 
            // 
            this.lbAction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbAction.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAction.Location = new System.Drawing.Point(40, 79);
            this.lbAction.Name = "lbAction";
            this.lbAction.Size = new System.Drawing.Size(28, 20);
            this.lbAction.TabIndex = 9;
            this.lbAction.Text = "----";
            // 
            // lbDoorName
            // 
            this.lbDoorName.AutoSize = true;
            // 
            // 
            // 
            this.lbDoorName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbDoorName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDoorName.Location = new System.Drawing.Point(40, 55);
            this.lbDoorName.Name = "lbDoorName";
            this.lbDoorName.Size = new System.Drawing.Size(28, 20);
            this.lbDoorName.TabIndex = 9;
            this.lbDoorName.Text = "----";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            // 
            // 
            // 
            this.lbTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.Location = new System.Drawing.Point(40, 30);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(28, 20);
            this.lbTime.TabIndex = 9;
            this.lbTime.Text = "----";
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(9, 79);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(35, 20);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "动作:";
            // 
            // lbDeptName
            // 
            this.lbDeptName.AutoSize = true;
            // 
            // 
            // 
            this.lbDeptName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbDeptName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDeptName.Location = new System.Drawing.Point(159, 6);
            this.lbDeptName.Name = "lbDeptName";
            this.lbDeptName.Size = new System.Drawing.Size(28, 20);
            this.lbDeptName.TabIndex = 9;
            this.lbDeptName.Text = "----";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(9, 55);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(35, 20);
            this.labelX4.TabIndex = 9;
            this.labelX4.Text = "门禁:";
            // 
            // lbStaffName
            // 
            this.lbStaffName.AutoSize = true;
            // 
            // 
            // 
            this.lbStaffName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbStaffName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStaffName.Location = new System.Drawing.Point(40, 6);
            this.lbStaffName.Name = "lbStaffName";
            this.lbStaffName.Size = new System.Drawing.Size(28, 20);
            this.lbStaffName.TabIndex = 9;
            this.lbStaffName.Text = "----";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(9, 30);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(35, 20);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "时间:";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(128, 6);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(35, 20);
            this.labelX2.TabIndex = 9;
            this.labelX2.Text = "部门:";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(9, 6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(35, 20);
            this.labelX1.TabIndex = 9;
            this.labelX1.Text = "姓名:";
            // 
            // panelDown
            // 
            this.panelDown.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelDown.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelDown.Controls.Add(this.dgvRealLog);
            this.panelDown.Controls.Add(this.panelEx1);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDown.Location = new System.Drawing.Point(0, 217);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(955, 181);
            this.panelDown.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDown.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelDown.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelDown.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelDown.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelDown.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelDown.Style.GradientAngle = 90;
            this.panelDown.TabIndex = 11;
            this.panelDown.Text = "panelEx2";
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandableSplitter1.ExpandableControl = this.panelDown;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 211);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(955, 6);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 12;
            this.expandableSplitter1.TabStop = false;
            // 
            // listDoors
            // 
            this.listDoors.ContextMenuStrip = this.cmsDoorState;
            this.listDoors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDoors.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listDoors.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listDoors.LargeImageList = this.smallImageList;
            this.listDoors.Location = new System.Drawing.Point(0, 28);
            this.listDoors.Name = "listDoors";
            this.listDoors.ShowItemToolTips = true;
            this.listDoors.Size = new System.Drawing.Size(955, 183);
            this.listDoors.TabIndex = 13;
            this.listDoors.UseCompatibleStateImageBehavior = false;
            // 
            // picBox
            // 
            this.picBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(128, 51);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(119, 127);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 8;
            this.picBox.TabStop = false;
            // 
            // biSelectAll
            // 
            this.biSelectAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biSelectAll.Image = global::SmartAccess.Properties.Resources.editor;
            this.biSelectAll.Name = "biSelectAll";
            this.biSelectAll.Text = "全选";
            this.biSelectAll.Click += new System.EventHandler(this.biSelectAll_Click);
            // 
            // biRealDetect
            // 
            this.biRealDetect.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biRealDetect.Image = global::SmartAccess.Properties.Resources.editor;
            this.biRealDetect.Name = "biRealDetect";
            this.biRealDetect.Text = "实时监控";
            this.biRealDetect.Click += new System.EventHandler(this.biRealDetect_Click);
            // 
            // biStop
            // 
            this.biStop.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biStop.Image = global::SmartAccess.Properties.Resources.editor;
            this.biStop.Name = "biStop";
            this.biStop.Text = "停止";
            this.biStop.Click += new System.EventHandler(this.biStop_Click);
            // 
            // biDetectCtrlr
            // 
            this.biDetectCtrlr.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDetectCtrlr.Image = global::SmartAccess.Properties.Resources.editor;
            this.biDetectCtrlr.Name = "biDetectCtrlr";
            this.biDetectCtrlr.Text = "检测控制器";
            this.biDetectCtrlr.Click += new System.EventHandler(this.biDetectCtrlr_Click);
            // 
            // biAdjustTime
            // 
            this.biAdjustTime.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAdjustTime.Image = global::SmartAccess.Properties.Resources.editor;
            this.biAdjustTime.Name = "biAdjustTime";
            this.biAdjustTime.Text = "校准时间";
            this.biAdjustTime.Click += new System.EventHandler(this.biAdjustTime_Click);
            // 
            // biRemoteOpen
            // 
            this.biRemoteOpen.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biRemoteOpen.Image = global::SmartAccess.Properties.Resources.editor;
            this.biRemoteOpen.Name = "biRemoteOpen";
            this.biRemoteOpen.Text = "远程开门";
            this.biRemoteOpen.Click += new System.EventHandler(this.biRemoteOpen_Click);
            // 
            // biClearInfo
            // 
            this.biClearInfo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biClearInfo.Image = global::SmartAccess.Properties.Resources.editor;
            this.biClearInfo.Name = "biClearInfo";
            this.biClearInfo.Text = "清空信息";
            this.biClearInfo.Click += new System.EventHandler(this.biClearInfo_Click);
            // 
            // biSearch
            // 
            this.biSearch.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biSearch.Image = global::SmartAccess.Properties.Resources.editor;
            this.biSearch.Name = "biSearch";
            this.biSearch.Text = "查找";
            this.biSearch.Click += new System.EventHandler(this.biSearch_Click);
            // 
            // dgvRealLog
            // 
            this.dgvRealLog.AllowUserToAddRows = false;
            this.dgvRealLog.AllowUserToDeleteRows = false;
            this.dgvRealLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRealLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRealLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRealLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRealLog.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRealLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRealLog.EnableHeadersVisualStyles = false;
            this.dgvRealLog.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvRealLog.Location = new System.Drawing.Point(0, 0);
            this.dgvRealLog.Name = "dgvRealLog";
            this.dgvRealLog.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRealLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRealLog.RowTemplate.Height = 23;
            this.dgvRealLog.Size = new System.Drawing.Size(696, 181);
            this.dgvRealLog.TabIndex = 11;
            this.dgvRealLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRealLog_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.FillWeight = 193.5371F;
            this.Column1.HeaderText = "时间";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.FillWeight = 76.14214F;
            this.Column2.HeaderText = "门禁";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.FillWeight = 30.32081F;
            this.Column3.HeaderText = "描述";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // RealDoorState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listDoors);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.panelDown);
            this.Controls.Add(this.bar1);
            this.Name = "RealDoorState";
            this.Size = new System.Drawing.Size(955, 398);
            this.Load += new System.EventHandler(this.RealDoorState_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.cmsDoorState.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.panelDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biSelectAll;
        private DevComponents.DotNetBar.ButtonItem biRealDetect;
        private DevComponents.DotNetBar.ButtonItem biStop;
        private DevComponents.DotNetBar.ButtonItem biDetectCtrlr;
        private DevComponents.DotNetBar.ButtonItem biAdjustTime;
        private DevComponents.DotNetBar.ButtonItem biClearInfo;
        private DevComponents.DotNetBar.ButtonItem biSearch;
        private System.Windows.Forms.ImageList smallImageList;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private System.Windows.Forms.ContextMenuStrip cmsDoorState;
        private System.Windows.Forms.ToolStripMenuItem tsmiDoorStateCfg;
        private DevComponents.DotNetBar.TextBoxItem tbFilterItem;
        private System.Windows.Forms.PictureBox picBox;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lbStaffName;
        private DevComponents.DotNetBar.LabelX lbDeptName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.PanelEx panelDown;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private Li.Controls.DataGridViewEx dgvRealLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ListView listDoors;
        private DevComponents.DotNetBar.LabelX lbTime;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX lbDoorName;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX lbAction;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoteOpen;
        private DevComponents.DotNetBar.ButtonItem biRemoteOpen;
    }
}
