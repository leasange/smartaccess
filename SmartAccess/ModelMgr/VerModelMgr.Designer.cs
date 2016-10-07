namespace SmartAccess.ModelMgr
{
    partial class VerModelMgr
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
            this.advTreeEx1 = new Li.Controls.AdvTreeEx();
            this.node1 = new DevComponents.AdvTree.Node();
            this.node3 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biRefresh = new DevComponents.DotNetBar.ButtonItem();
            this.biNewVerModel = new DevComponents.DotNetBar.ButtonItem();
            this.biModifyModel = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteModel = new DevComponents.DotNetBar.ButtonItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.modelTree = new Li.Controls.AdvTreeEx();
            this.node2 = new DevComponents.AdvTree.Node();
            this.node4 = new DevComponents.AdvTree.Node();
            this.node5 = new DevComponents.AdvTree.Node();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.previewControl = new FastReport.Preview.PreviewControl();
            this.node6 = new DevComponents.AdvTree.Node();
            this.biExportModel = new DevComponents.DotNetBar.ButtonItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelTree)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // advTreeEx1
            // 
            this.advTreeEx1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeEx1.AllowDrop = true;
            this.advTreeEx1.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeEx1.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeEx1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeEx1.CheckBoxVisible = false;
            this.advTreeEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTreeEx1.Location = new System.Drawing.Point(0, 0);
            this.advTreeEx1.Name = "advTreeEx1";
            this.advTreeEx1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advTreeEx1.NodesConnector = this.nodeConnector1;
            this.advTreeEx1.NodeStyle = this.elementStyle1;
            this.advTreeEx1.PathSeparator = ";";
            this.advTreeEx1.SelectionPerCell = true;
            this.advTreeEx1.Size = new System.Drawing.Size(213, 280);
            this.advTreeEx1.Styles.Add(this.elementStyle1);
            this.advTreeEx1.TabIndex = 0;
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node3});
            this.node1.Text = "所有证件模板";
            // 
            // node3
            // 
            this.node3.Expanded = true;
            this.node3.Name = "node3";
            this.node3.Text = "证件模板2";
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
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biRefresh,
            this.biNewVerModel,
            this.biModifyModel,
            this.biDeleteModel,
            this.biExportModel});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(785, 29);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biRefresh
            // 
            this.biRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biRefresh.Image = global::SmartAccess.Properties.Resources.刷新;
            this.biRefresh.Name = "biRefresh";
            this.biRefresh.Text = "刷新";
            this.biRefresh.Click += new System.EventHandler(this.biRefresh_Click);
            // 
            // biNewVerModel
            // 
            this.biNewVerModel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biNewVerModel.Name = "biNewVerModel";
            this.biNewVerModel.Text = "新建模板";
            this.biNewVerModel.Click += new System.EventHandler(this.biNewVerModel_Click);
            // 
            // biModifyModel
            // 
            this.biModifyModel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biModifyModel.Name = "biModifyModel";
            this.biModifyModel.Text = "编辑模板";
            this.biModifyModel.Click += new System.EventHandler(this.biModifyModel_Click);
            // 
            // biDeleteModel
            // 
            this.biDeleteModel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDeleteModel.Name = "biDeleteModel";
            this.biDeleteModel.Text = "删除模板";
            this.biDeleteModel.Click += new System.EventHandler(this.biDeleteModel_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 29);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.modelTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelEx1);
            this.splitContainer1.Size = new System.Drawing.Size(785, 408);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.TabIndex = 2;
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
            this.modelTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelTree.Location = new System.Drawing.Point(0, 0);
            this.modelTree.Name = "modelTree";
            this.modelTree.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node6,
            this.node2});
            this.modelTree.NodesConnector = this.nodeConnector2;
            this.modelTree.NodeStyle = this.elementStyle2;
            this.modelTree.PathSeparator = ";";
            this.modelTree.SelectionPerCell = true;
            this.modelTree.Size = new System.Drawing.Size(247, 408);
            this.modelTree.Styles.Add(this.elementStyle2);
            this.modelTree.TabIndex = 0;
            this.modelTree.Text = "advTreeEx2";
            this.modelTree.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.modelTree_AfterNodeSelect);
            // 
            // node2
            // 
            this.node2.Expanded = true;
            this.node2.Name = "node2";
            this.node2.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node4,
            this.node5});
            this.node2.Text = "所有证件模板";
            // 
            // node4
            // 
            this.node4.Expanded = true;
            this.node4.Name = "node4";
            this.node4.Text = "证件模板1";
            // 
            // node5
            // 
            this.node5.Expanded = true;
            this.node5.Name = "node5";
            this.node5.Text = "证件模板2";
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
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.previewControl);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(534, 408);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 3;
            // 
            // previewControl
            // 
            this.previewControl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl.Buttons = ((FastReport.PreviewButtons)((((((FastReport.PreviewButtons.Print | FastReport.PreviewButtons.Save) 
            | FastReport.PreviewButtons.Zoom) 
            | FastReport.PreviewButtons.Outline) 
            | FastReport.PreviewButtons.PageSetup) 
            | FastReport.PreviewButtons.Navigator)));
            this.previewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl.Font = new System.Drawing.Font("宋体", 9F);
            this.previewControl.Location = new System.Drawing.Point(0, 0);
            this.previewControl.Name = "previewControl";
            this.previewControl.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl.Size = new System.Drawing.Size(534, 408);
            this.previewControl.TabIndex = 0;
            this.previewControl.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // node6
            // 
            this.node6.Name = "node6";
            this.node6.Text = "示例模板";
            // 
            // biExportModel
            // 
            this.biExportModel.Name = "biExportModel";
            this.biExportModel.Text = "保存成模板文件";
            this.biExportModel.Click += new System.EventHandler(this.biExportModel_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "模板文件(*.fpx)|*.fpx";
            this.saveFileDialog.Title = "模板";
            // 
            // VerModelMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.bar1);
            this.Name = "VerModelMgr";
            this.Size = new System.Drawing.Size(785, 437);
            this.Load += new System.EventHandler(this.VerModelMgr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advTreeEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.modelTree)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Li.Controls.AdvTreeEx advTreeEx1;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.AdvTree.Node node3;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biModifyModel;
        private DevComponents.DotNetBar.ButtonItem biDeleteModel;
        private DevComponents.DotNetBar.ButtonItem biNewVerModel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Li.Controls.AdvTreeEx modelTree;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Node node4;
        private DevComponents.AdvTree.Node node5;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private FastReport.Preview.PreviewControl previewControl;
        private DevComponents.DotNetBar.ButtonItem biRefresh;
        private DevComponents.AdvTree.Node node6;
        private DevComponents.DotNetBar.ButtonItem biExportModel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;

    }
}
