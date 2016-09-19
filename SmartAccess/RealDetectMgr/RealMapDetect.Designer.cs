namespace SmartAccess.RealDetectMgr
{
    partial class RealMapDetect
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
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.modelTree = new Li.Controls.AdvTreeEx();
            this.node2 = new DevComponents.AdvTree.Node();
            this.node4 = new DevComponents.AdvTree.Node();
            this.node5 = new DevComponents.AdvTree.Node();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.biZoomPlus = new DevComponents.DotNetBar.ButtonItem();
            this.biZoomMinus = new DevComponents.DotNetBar.ButtonItem();
            this.biDetectCurMap = new DevComponents.DotNetBar.ButtonItem();
            this.biStopCurrMap = new DevComponents.DotNetBar.ButtonItem();
            this.biDetectAllMap = new DevComponents.DotNetBar.ButtonItem();
            this.biStopDetectAll = new DevComponents.DotNetBar.ButtonItem();
            this.biAddRootArea = new DevComponents.DotNetBar.ButtonItem();
            this.stcMaps = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.modelTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stcMaps)).BeginInit();
            this.stcMaps.SuspendLayout();
            this.SuspendLayout();
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(60)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(247, 28);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 379);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 7;
            this.expandableSplitter1.TabStop = false;
            // 
            // modelTree
            // 
            this.modelTree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.modelTree.AllowDrop = true;
            this.modelTree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.modelTree.BackgroundStyle.Class = "TreeBorderKey";
            this.modelTree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.modelTree.CheckBoxVisible = false;
            this.modelTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.modelTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.modelTree.Location = new System.Drawing.Point(0, 28);
            this.modelTree.Name = "modelTree";
            this.modelTree.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node2});
            this.modelTree.NodesConnector = this.nodeConnector2;
            this.modelTree.NodeStyle = this.elementStyle2;
            this.modelTree.PathSeparator = ";";
            this.modelTree.SelectionPerCell = true;
            this.modelTree.Size = new System.Drawing.Size(247, 379);
            this.modelTree.Styles.Add(this.elementStyle2);
            this.modelTree.TabIndex = 6;
            this.modelTree.Text = "advTreeEx2";
            this.modelTree.NodeMouseUp += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.modelTree_NodeMouseUp);
            this.modelTree.NodeDoubleClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.modelTree_NodeDoubleClick);
            // 
            // node2
            // 
            this.node2.Expanded = true;
            this.node2.Name = "node2";
            this.node2.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node4,
            this.node5});
            this.node2.Text = "所有地图";
            // 
            // node4
            // 
            this.node4.Expanded = true;
            this.node4.Name = "node4";
            this.node4.Text = "地图1";
            // 
            // node5
            // 
            this.node5.Expanded = true;
            this.node5.Name = "node5";
            this.node5.Text = "地图2";
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle2
            // 
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biRefresh,
            this.biZoomPlus,
            this.biZoomMinus,
            this.biDetectCurMap,
            this.biStopCurrMap,
            this.biDetectAllMap,
            this.biStopDetectAll});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(732, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 2;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biRefresh
            // 
            this.biRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biRefresh.Image = global::SmartAccess.Properties.Resources.editor;
            this.biRefresh.Name = "biRefresh";
            this.biRefresh.Text = "刷新";
            this.biRefresh.Click += new System.EventHandler(this.biRefresh_Click);
            // 
            // biZoomPlus
            // 
            this.biZoomPlus.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biZoomPlus.Image = global::SmartAccess.Properties.Resources.editor;
            this.biZoomPlus.Name = "biZoomPlus";
            this.biZoomPlus.Text = "放大";
            this.biZoomPlus.Click += new System.EventHandler(this.biZoomPlus_Click);
            // 
            // biZoomMinus
            // 
            this.biZoomMinus.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biZoomMinus.Image = global::SmartAccess.Properties.Resources.editor;
            this.biZoomMinus.Name = "biZoomMinus";
            this.biZoomMinus.Text = "缩小";
            this.biZoomMinus.Click += new System.EventHandler(this.biZoomMinus_Click);
            // 
            // biDetectCurMap
            // 
            this.biDetectCurMap.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDetectCurMap.Image = global::SmartAccess.Properties.Resources.editor;
            this.biDetectCurMap.Name = "biDetectCurMap";
            this.biDetectCurMap.Text = "监控当前地图";
            this.biDetectCurMap.Click += new System.EventHandler(this.biDetectCurMap_Click);
            // 
            // biStopCurrMap
            // 
            this.biStopCurrMap.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biStopCurrMap.Image = global::SmartAccess.Properties.Resources.editor;
            this.biStopCurrMap.Name = "biStopCurrMap";
            this.biStopCurrMap.Text = "停止当前";
            this.biStopCurrMap.Click += new System.EventHandler(this.biStopCurrMap_Click);
            // 
            // biDetectAllMap
            // 
            this.biDetectAllMap.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDetectAllMap.Image = global::SmartAccess.Properties.Resources.editor;
            this.biDetectAllMap.Name = "biDetectAllMap";
            this.biDetectAllMap.Text = "监控所有地图";
            this.biDetectAllMap.Click += new System.EventHandler(this.biDetectAllMap_Click);
            // 
            // biStopDetectAll
            // 
            this.biStopDetectAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biStopDetectAll.Image = global::SmartAccess.Properties.Resources.editor;
            this.biStopDetectAll.Name = "biStopDetectAll";
            this.biStopDetectAll.Text = "停止所有";
            this.biStopDetectAll.Click += new System.EventHandler(this.biStopDetectAll_Click);
            // 
            // biAddRootArea
            // 
            this.biAddRootArea.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAddRootArea.ForeColor = System.Drawing.Color.White;
            this.biAddRootArea.Image = global::SmartAccess.Properties.Resources.editor;
            this.biAddRootArea.Name = "biAddRootArea";
            this.biAddRootArea.Text = "关闭";
            // 
            // stcMaps
            // 
            this.stcMaps.CloseButtonOnTabsVisible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.stcMaps.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.stcMaps.ControlBox.MenuBox.Name = "";
            this.stcMaps.ControlBox.Name = "";
            this.stcMaps.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.stcMaps.ControlBox.MenuBox,
            this.stcMaps.ControlBox.CloseBox});
            this.stcMaps.Controls.Add(this.superTabControlPanel1);
            this.stcMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stcMaps.Location = new System.Drawing.Point(253, 28);
            this.stcMaps.Name = "stcMaps";
            this.stcMaps.ReorderTabsEnabled = true;
            this.stcMaps.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.stcMaps.SelectedTabIndex = 0;
            this.stcMaps.Size = new System.Drawing.Size(479, 379);
            this.stcMaps.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stcMaps.TabIndex = 8;
            this.stcMaps.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1});
            this.stcMaps.Text = "superTabControl";
            this.stcMaps.TabItemClose += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs>(this.stcMaps_TabItemClose);
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(479, 349);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "地图1";
            // 
            // RealMapDetect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stcMaps);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.modelTree);
            this.Controls.Add(this.bar1);
            this.Name = "RealMapDetect";
            this.Size = new System.Drawing.Size(732, 407);
            this.Load += new System.EventHandler(this.RealMapDetect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modelTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stcMaps)).EndInit();
            this.stcMaps.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private Li.Controls.AdvTreeEx modelTree;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Node node4;
        private DevComponents.AdvTree.Node node5;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biAddRootArea;
        private DevComponents.DotNetBar.ButtonItem biZoomPlus;
        private DevComponents.DotNetBar.ButtonItem biZoomMinus;
        private DevComponents.DotNetBar.ButtonItem biRefresh;
        private DevComponents.DotNetBar.ButtonItem biDetectCurMap;
        private DevComponents.DotNetBar.ButtonItem biDetectAllMap;
        private DevComponents.DotNetBar.ButtonItem biStopDetectAll;
        private DevComponents.DotNetBar.SuperTabControl stcMaps;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.ButtonItem biStopCurrMap;
    }
}
