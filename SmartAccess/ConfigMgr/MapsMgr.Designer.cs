namespace SmartAccess.ConfigMgr
{
    partial class MapsMgr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapsMgr));
            this.biNewMap = new DevComponents.DotNetBar.ButtonItem();
            this.biModifyMap = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteMap = new DevComponents.DotNetBar.ButtonItem();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.modelTree = new Li.Controls.AdvTreeEx();
            this.node2 = new DevComponents.AdvTree.Node();
            this.node4 = new DevComponents.AdvTree.Node();
            this.node5 = new DevComponents.AdvTree.Node();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.mapCtrl = new SmartAccess.ConfigMgr.MapCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelTree)).BeginInit();
            this.SuspendLayout();
            // 
            // biNewMap
            // 
            this.biNewMap.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biNewMap.Name = "biNewMap";
            this.biNewMap.Text = "新建地图";
            this.biNewMap.Click += new System.EventHandler(this.biNewMap_Click);
            // 
            // biModifyMap
            // 
            this.biModifyMap.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biModifyMap.Name = "biModifyMap";
            this.biModifyMap.Text = "编辑地图";
            // 
            // biDeleteMap
            // 
            this.biDeleteMap.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDeleteMap.Name = "biDeleteMap";
            this.biDeleteMap.Text = "删除地图";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biRefresh,
            this.biNewMap,
            this.biModifyMap,
            this.biDeleteMap});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(709, 29);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 3;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biRefresh
            // 
            this.biRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biRefresh.Image = global::SmartAccess.Properties.Resources.刷新;
            this.biRefresh.Name = "biRefresh";
            this.biRefresh.Text = "刷新";
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
            this.modelTree.Location = new System.Drawing.Point(0, 29);
            this.modelTree.Name = "modelTree";
            this.modelTree.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node2});
            this.modelTree.NodesConnector = this.nodeConnector2;
            this.modelTree.NodeStyle = this.elementStyle2;
            this.modelTree.PathSeparator = ";";
            this.modelTree.SelectionPerCell = true;
            this.modelTree.Size = new System.Drawing.Size(247, 329);
            this.modelTree.Styles.Add(this.elementStyle2);
            this.modelTree.TabIndex = 4;
            this.modelTree.Text = "advTreeEx2";
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
            this.expandableSplitter1.Location = new System.Drawing.Point(247, 29);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(6, 329);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 5;
            this.expandableSplitter1.TabStop = false;
            // 
            // mapCtrl
            // 
            this.mapCtrl.BackColor = System.Drawing.Color.White;
            this.mapCtrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mapCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapCtrl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mapCtrl.IsEditMode = true;
            this.mapCtrl.Location = new System.Drawing.Point(253, 29);
            this.mapCtrl.MapImage = null;
            this.mapCtrl.MapRect = ((System.Drawing.RectangleF)(resources.GetObject("mapCtrl.MapRect")));
            this.mapCtrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mapCtrl.Name = "mapCtrl";
            this.mapCtrl.Size = new System.Drawing.Size(456, 329);
            this.mapCtrl.TabIndex = 6;
            this.mapCtrl.TextBoundColor = System.Drawing.Color.White;
            // 
            // MapsMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapCtrl);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.modelTree);
            this.Controls.Add(this.bar1);
            this.Name = "MapsMgr";
            this.Size = new System.Drawing.Size(709, 358);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem biRefresh;
        private DevComponents.DotNetBar.ButtonItem biNewMap;
        private DevComponents.DotNetBar.ButtonItem biModifyMap;
        private DevComponents.DotNetBar.ButtonItem biDeleteMap;
        private DevComponents.DotNetBar.Bar bar1;
        private Li.Controls.AdvTreeEx modelTree;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Node node4;
        private DevComponents.AdvTree.Node node5;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private MapCtrl mapCtrl;

    }
}
