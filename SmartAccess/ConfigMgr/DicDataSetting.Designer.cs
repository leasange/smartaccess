namespace SmartAccess.ConfigMgr
{
    partial class DicDataSetting
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
            this.treeData = new Li.Controls.AdvTreeEx();
            this.node1 = new DevComponents.AdvTree.Node();
            this.node2 = new DevComponents.AdvTree.Node();
            this.node3 = new DevComponents.AdvTree.Node();
            this.node4 = new DevComponents.AdvTree.Node();
            this.node5 = new DevComponents.AdvTree.Node();
            this.node6 = new DevComponents.AdvTree.Node();
            this.node7 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tbDataKey = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbValue = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbDesc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.cbValue = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbName = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeData
            // 
            this.treeData.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.treeData.AllowDrop = true;
            this.treeData.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.treeData.BackgroundStyle.Class = "TreeBorderKey";
            this.treeData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeData.CheckBoxVisible = false;
            this.treeData.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeData.Location = new System.Drawing.Point(0, 0);
            this.treeData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeData.Name = "treeData";
            this.treeData.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1,
            this.node3,
            this.node6});
            this.treeData.NodesConnector = this.nodeConnector1;
            this.treeData.NodeStyle = this.elementStyle1;
            this.treeData.PathSeparator = ";";
            this.treeData.SelectionPerCell = true;
            this.treeData.Size = new System.Drawing.Size(252, 359);
            this.treeData.Styles.Add(this.elementStyle1);
            this.treeData.TabIndex = 0;
            this.treeData.Text = "advTreeEx1";
            this.treeData.NodeMouseUp += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.treeData_NodeMouseUp);
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node2});
            this.node1.TagString = "ALARM_INFO";
            this.node1.Text = "报警配置";
            // 
            // node2
            // 
            this.node2.Expanded = true;
            this.node2.Name = "node2";
            this.node2.TagString = "ALARM_SERVER";
            this.node2.Text = "报警服务器";
            // 
            // node3
            // 
            this.node3.Expanded = true;
            this.node3.Name = "node3";
            this.node3.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node4,
            this.node5});
            this.node3.TagString = "STAFF_TYPE";
            this.node3.Text = "访客类型";
            // 
            // node4
            // 
            this.node4.Expanded = true;
            this.node4.Name = "node4";
            this.node4.TagString = "STAFF";
            this.node4.Text = "内部员工";
            // 
            // node5
            // 
            this.node5.Expanded = true;
            this.node5.Name = "node5";
            this.node5.TagString = "VISITOR";
            this.node5.Text = "访客";
            // 
            // node6
            // 
            this.node6.Expanded = true;
            this.node6.Name = "node6";
            this.node6.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node7});
            this.node6.TagString = "SYSTEM_CONFIG";
            this.node6.Text = "系统参数";
            // 
            // node7
            // 
            this.node7.Expanded = true;
            this.node7.Name = "node7";
            this.node7.TagString = "AUTO_ACCESS";
            this.node7.Text = "自动授权开启状态";
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
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(269, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "参数标识：";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbDataKey
            // 
            this.tbDataKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbDataKey.Border.Class = "TextBoxBorder";
            this.tbDataKey.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDataKey.Location = new System.Drawing.Point(350, 4);
            this.tbDataKey.Name = "tbDataKey";
            this.tbDataKey.ReadOnly = true;
            this.tbDataKey.Size = new System.Drawing.Size(236, 23);
            this.tbDataKey.TabIndex = 2;
            // 
            // tbValue
            // 
            this.tbValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbValue.Border.Class = "TextBoxBorder";
            this.tbValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbValue.Location = new System.Drawing.Point(350, 57);
            this.tbValue.Name = "tbValue";
            this.tbValue.ReadOnly = true;
            this.tbValue.Size = new System.Drawing.Size(236, 23);
            this.tbValue.TabIndex = 4;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(269, 56);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "参数值：";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(269, 85);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "参数说明：";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbDesc
            // 
            this.tbDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbDesc.Border.Class = "TextBoxBorder";
            this.tbDesc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDesc.Location = new System.Drawing.Point(350, 86);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.ReadOnly = true;
            this.tbDesc.Size = new System.Drawing.Size(236, 243);
            this.tbDesc.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(511, 333);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbValue
            // 
            this.cbValue.AutoSize = true;
            // 
            // 
            // 
            this.cbValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbValue.Location = new System.Drawing.Point(350, 59);
            this.cbValue.Name = "cbValue";
            this.cbValue.Size = new System.Drawing.Size(112, 20);
            this.cbValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbValue.TabIndex = 6;
            this.cbValue.Text = "boolean值类型";
            this.cbValue.Visible = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(101, 48);
            // 
            // tsmiNew
            // 
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(100, 22);
            this.tsmiNew.Text = "新建";
            this.tsmiNew.Click += new System.EventHandler(this.tsmiNew_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(100, 22);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(269, 29);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "参数名称：";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbName.Border.Class = "TextBoxBorder";
            this.tbName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbName.Location = new System.Drawing.Point(350, 30);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(236, 23);
            this.tbName.TabIndex = 2;
            // 
            // DicDataSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbValue);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.tbDataKey);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.treeData);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DicDataSetting";
            this.Size = new System.Drawing.Size(599, 359);
            this.Load += new System.EventHandler(this.DicDataSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Li.Controls.AdvTreeEx treeData;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Node node3;
        private DevComponents.AdvTree.Node node4;
        private DevComponents.AdvTree.Node node5;
        private DevComponents.AdvTree.Node node6;
        private DevComponents.AdvTree.Node node7;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDataKey;
        private DevComponents.DotNetBar.Controls.TextBoxX tbValue;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDesc;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbValue;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbName;
    }
}
