namespace SmartAccess.VerInfoMgr
{
    partial class DeptTree
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
            this.cmsDept = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.tbFilter = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.deptAdvTree = new Li.Controls.AdvTreeEx();
            this.node1 = new DevComponents.AdvTree.Node();
            this.node2 = new DevComponents.AdvTree.Node();
            this.node3 = new DevComponents.AdvTree.Node();
            this.node4 = new DevComponents.AdvTree.Node();
            this.node5 = new DevComponents.AdvTree.Node();
            this.node6 = new DevComponents.AdvTree.Node();
            this.node7 = new DevComponents.AdvTree.Node();
            this.node8 = new DevComponents.AdvTree.Node();
            this.node9 = new DevComponents.AdvTree.Node();
            this.node10 = new DevComponents.AdvTree.Node();
            this.node11 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.cmsDept.SuspendLayout();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deptAdvTree)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsDept
            // 
            this.cmsDept.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefresh});
            this.cmsDept.Name = "cmsDept";
            this.cmsDept.Size = new System.Drawing.Size(101, 26);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(100, 22);
            this.tsmiRefresh.Text = "刷新";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.tbFilter);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(235, 27);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 6;
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbFilter.Border.Class = "TextBoxBorder";
            this.tbFilter.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbFilter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbFilter.Location = new System.Drawing.Point(32, 2);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(200, 23);
            this.tbFilter.TabIndex = 2;
            this.tbFilter.WatermarkText = "输入关键字或拼音首字符";
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(38, 27);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "过滤";
            // 
            // deptAdvTree
            // 
            this.deptAdvTree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.deptAdvTree.AllowDrop = true;
            this.deptAdvTree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.deptAdvTree.BackgroundStyle.Class = "TreeBorderKey";
            this.deptAdvTree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.deptAdvTree.CheckBoxVisible = false;
            this.deptAdvTree.ContextMenuStrip = this.cmsDept;
            this.deptAdvTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deptAdvTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deptAdvTree.Location = new System.Drawing.Point(0, 27);
            this.deptAdvTree.Name = "deptAdvTree";
            this.deptAdvTree.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.deptAdvTree.NodesConnector = this.nodeConnector1;
            this.deptAdvTree.NodeStyle = this.elementStyle1;
            this.deptAdvTree.PathSeparator = ";";
            this.deptAdvTree.SelectionPerCell = true;
            this.deptAdvTree.Size = new System.Drawing.Size(235, 416);
            this.deptAdvTree.Styles.Add(this.elementStyle1);
            this.deptAdvTree.TabIndex = 7;
            this.deptAdvTree.Text = "advTreeEx1";
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Image = global::SmartAccess.Properties.Resources.editor;
            this.node1.Name = "node1";
            this.node1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node2,
            this.node3,
            this.node4,
            this.node5,
            this.node6,
            this.node7});
            this.node1.Text = "XX公司";
            // 
            // node2
            // 
            this.node2.Expanded = true;
            this.node2.Image = global::SmartAccess.Properties.Resources.editor;
            this.node2.Name = "node2";
            this.node2.Text = "财务部门";
            // 
            // node3
            // 
            this.node3.Expanded = true;
            this.node3.Image = global::SmartAccess.Properties.Resources.editor;
            this.node3.Name = "node3";
            this.node3.Text = "人事部门";
            // 
            // node4
            // 
            this.node4.Expanded = true;
            this.node4.Image = global::SmartAccess.Properties.Resources.editor;
            this.node4.Name = "node4";
            this.node4.Text = "综合办公室";
            // 
            // node5
            // 
            this.node5.Expanded = true;
            this.node5.Image = global::SmartAccess.Properties.Resources.editor;
            this.node5.Name = "node5";
            this.node5.Text = "安保部门";
            // 
            // node6
            // 
            this.node6.Expanded = true;
            this.node6.Image = global::SmartAccess.Properties.Resources.editor;
            this.node6.Name = "node6";
            this.node6.Text = "客服部门";
            // 
            // node7
            // 
            this.node7.Expanded = true;
            this.node7.Image = global::SmartAccess.Properties.Resources.editor;
            this.node7.Name = "node7";
            this.node7.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node8,
            this.node9,
            this.node10,
            this.node11});
            this.node7.Text = "技术中心";
            // 
            // node8
            // 
            this.node8.Expanded = true;
            this.node8.Name = "node8";
            this.node8.Text = "总体室";
            // 
            // node9
            // 
            this.node9.Expanded = true;
            this.node9.Name = "node9";
            this.node9.Text = "科发室";
            // 
            // node10
            // 
            this.node10.Expanded = true;
            this.node10.Name = "node10";
            this.node10.Text = "应用软件室";
            // 
            // node11
            // 
            this.node11.Expanded = true;
            this.node11.Name = "node11";
            this.node11.Text = "系统软件室";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // DeptTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deptAdvTree);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DeptTree";
            this.Size = new System.Drawing.Size(235, 443);
            this.Load += new System.EventHandler(this.DeptTree_Load);
            this.cmsDept.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deptAdvTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsDept;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbFilter;
        private DevComponents.DotNetBar.LabelX labelX1;
        private Li.Controls.AdvTreeEx deptAdvTree;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Node node3;
        private DevComponents.AdvTree.Node node4;
        private DevComponents.AdvTree.Node node5;
        private DevComponents.AdvTree.Node node6;
        private DevComponents.AdvTree.Node node7;
        private DevComponents.AdvTree.Node node8;
        private DevComponents.AdvTree.Node node9;
        private DevComponents.AdvTree.Node node10;
        private DevComponents.AdvTree.Node node11;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
    }
}
