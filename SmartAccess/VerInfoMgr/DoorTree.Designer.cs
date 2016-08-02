namespace SmartAccess.VerInfoMgr
{
    partial class DoorTree
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
            this.advDoorTree = new Li.Controls.AdvTreeEx();
            this.node1 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.node2 = new DevComponents.AdvTree.Node();
            ((System.ComponentModel.ISupportInitialize)(this.advDoorTree)).BeginInit();
            this.SuspendLayout();
            // 
            // advDoorTree
            // 
            this.advDoorTree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advDoorTree.AllowDrop = true;
            this.advDoorTree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advDoorTree.BackgroundStyle.Class = "TreeBorderKey";
            this.advDoorTree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advDoorTree.CheckBoxVisible = false;
            this.advDoorTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advDoorTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.advDoorTree.Location = new System.Drawing.Point(0, 0);
            this.advDoorTree.Name = "advDoorTree";
            this.advDoorTree.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advDoorTree.NodesConnector = this.nodeConnector1;
            this.advDoorTree.NodeStyle = this.elementStyle1;
            this.advDoorTree.PathSeparator = ";";
            this.advDoorTree.SelectionPerCell = true;
            this.advDoorTree.Size = new System.Drawing.Size(237, 330);
            this.advDoorTree.Styles.Add(this.elementStyle1);
            this.advDoorTree.TabIndex = 0;
            this.advDoorTree.Text = "advTreeEx1";
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node2});
            this.node1.Text = "区域1";
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
            // node2
            // 
            this.node2.Expanded = true;
            this.node2.Name = "node2";
            this.node2.Text = "门1";
            // 
            // DoorTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.advDoorTree);
            this.Name = "DoorTree";
            this.Size = new System.Drawing.Size(237, 330);
            ((System.ComponentModel.ISupportInitialize)(this.advDoorTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Li.Controls.AdvTreeEx advDoorTree;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.Node node2;
    }
}
