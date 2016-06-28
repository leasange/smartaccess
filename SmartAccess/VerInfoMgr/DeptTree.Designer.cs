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
            ((System.ComponentModel.ISupportInitialize)(this.deptAdvTree)).BeginInit();
            this.SuspendLayout();
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
            this.deptAdvTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deptAdvTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deptAdvTree.Location = new System.Drawing.Point(0, 0);
            this.deptAdvTree.Name = "deptAdvTree";
            this.deptAdvTree.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.deptAdvTree.NodesConnector = this.nodeConnector1;
            this.deptAdvTree.NodeStyle = this.elementStyle1;
            this.deptAdvTree.PathSeparator = ";";
            this.deptAdvTree.SelectionPerCell = true;
            this.deptAdvTree.Size = new System.Drawing.Size(235, 443);
            this.deptAdvTree.Styles.Add(this.elementStyle1);
            this.deptAdvTree.TabIndex = 5;
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
            this.Name = "DeptTree";
            this.Size = new System.Drawing.Size(235, 443);
            ((System.ComponentModel.ISupportInitialize)(this.deptAdvTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
