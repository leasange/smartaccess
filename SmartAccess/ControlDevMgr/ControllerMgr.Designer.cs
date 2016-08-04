namespace SmartAccess.ControlDevMgr
{
    partial class ControllerMgr
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biAddRootArea = new DevComponents.DotNetBar.ButtonItem();
            this.btnAddCtrlr = new DevComponents.DotNetBar.ButtonItem();
            this.biModifyCtrlr = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteCtrlr = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.tbCtrlrFilter = new DevComponents.DotNetBar.TextBoxItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.biAddArea = new DevComponents.DotNetBar.ButtonItem();
            this.biAddSubArea = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteArea = new DevComponents.DotNetBar.ButtonItem();
            this.biModifyArea = new DevComponents.DotNetBar.ButtonItem();
            this.advTreeArea = new Li.Controls.AdvTreeEx();
            this.node1 = new DevComponents.AdvTree.Node();
            this.node2 = new DevComponents.AdvTree.Node();
            this.node5 = new DevComponents.AdvTree.Node();
            this.node3 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.dgvCtrlr = new Li.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_XG = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Col_SC = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtrlr)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biAddRootArea,
            this.btnAddCtrlr,
            this.biModifyCtrlr,
            this.biDeleteCtrlr,
            this.buttonItem4,
            this.buttonItem5,
            this.buttonItem6,
            this.tbCtrlrFilter});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.RoundCorners = false;
            this.bar1.Size = new System.Drawing.Size(710, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 1;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biAddRootArea
            // 
            this.biAddRootArea.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAddRootArea.Image = global::SmartAccess.Properties.Resources.editor;
            this.biAddRootArea.Name = "biAddRootArea";
            this.biAddRootArea.Text = "搜索控制器";
            this.biAddRootArea.Click += new System.EventHandler(this.biAddRootArea_Click);
            // 
            // btnAddCtrlr
            // 
            this.btnAddCtrlr.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAddCtrlr.Image = global::SmartAccess.Properties.Resources.editor;
            this.btnAddCtrlr.Name = "btnAddCtrlr";
            this.btnAddCtrlr.Text = "添加控制器";
            this.btnAddCtrlr.Click += new System.EventHandler(this.btnAddCtrlr_Click);
            // 
            // biModifyCtrlr
            // 
            this.biModifyCtrlr.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biModifyCtrlr.Image = global::SmartAccess.Properties.Resources.editor;
            this.biModifyCtrlr.Name = "biModifyCtrlr";
            this.biModifyCtrlr.Text = "修改控制器";
            // 
            // biDeleteCtrlr
            // 
            this.biDeleteCtrlr.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDeleteCtrlr.Image = global::SmartAccess.Properties.Resources.editor;
            this.biDeleteCtrlr.Name = "biDeleteCtrlr";
            this.biDeleteCtrlr.Text = "删除控制器";
            // 
            // buttonItem4
            // 
            this.buttonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem4.Image = global::SmartAccess.Properties.Resources.editor;
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.Text = "打印";
            // 
            // buttonItem5
            // 
            this.buttonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem5.Image = global::SmartAccess.Properties.Resources.editor;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "导出";
            // 
            // buttonItem6
            // 
            this.buttonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem6.Image = global::SmartAccess.Properties.Resources.editor;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Text = "查找";
            // 
            // tbCtrlrFilter
            // 
            this.tbCtrlrFilter.Name = "tbCtrlrFilter";
            this.tbCtrlrFilter.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.advTreeArea);
            this.splitContainer1.Panel1.Controls.Add(this.bar2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCtrlr);
            this.splitContainer1.Panel2.Controls.Add(this.bar1);
            this.splitContainer1.Size = new System.Drawing.Size(1014, 457);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 3;
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biAddArea,
            this.biAddSubArea,
            this.biDeleteArea,
            this.biModifyArea});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.RoundCorners = false;
            this.bar2.Size = new System.Drawing.Size(300, 28);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 2;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar1";
            // 
            // biAddArea
            // 
            this.biAddArea.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAddArea.Image = global::SmartAccess.Properties.Resources.editor;
            this.biAddArea.Name = "biAddArea";
            this.biAddArea.Text = "添加区域";
            this.biAddArea.Tooltip = "添加相同级别区域";
            this.biAddArea.Click += new System.EventHandler(this.biAddArea_Click);
            // 
            // biAddSubArea
            // 
            this.biAddSubArea.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAddSubArea.Image = global::SmartAccess.Properties.Resources.editor;
            this.biAddSubArea.Name = "biAddSubArea";
            this.biAddSubArea.Text = "添加下级";
            this.biAddSubArea.Tooltip = "添加下级区域";
            this.biAddSubArea.Click += new System.EventHandler(this.biAddSubArea_Click);
            // 
            // biDeleteArea
            // 
            this.biDeleteArea.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDeleteArea.Image = global::SmartAccess.Properties.Resources.editor;
            this.biDeleteArea.Name = "biDeleteArea";
            this.biDeleteArea.Text = "删除";
            this.biDeleteArea.Tooltip = "删除选择区域";
            this.biDeleteArea.Click += new System.EventHandler(this.biDeleteArea_Click);
            // 
            // biModifyArea
            // 
            this.biModifyArea.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biModifyArea.Image = global::SmartAccess.Properties.Resources.editor;
            this.biModifyArea.Name = "biModifyArea";
            this.biModifyArea.Text = "修改";
            this.biModifyArea.Tooltip = "修改选择区域";
            // 
            // advTreeArea
            // 
            this.advTreeArea.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeArea.AllowDrop = true;
            this.advTreeArea.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeArea.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeArea.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeArea.CheckBoxVisible = false;
            this.advTreeArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTreeArea.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.advTreeArea.Location = new System.Drawing.Point(0, 28);
            this.advTreeArea.Name = "advTreeArea";
            this.advTreeArea.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advTreeArea.NodesConnector = this.nodeConnector1;
            this.advTreeArea.NodeStyle = this.elementStyle1;
            this.advTreeArea.PathSeparator = ";";
            this.advTreeArea.SelectionPerCell = true;
            this.advTreeArea.Size = new System.Drawing.Size(300, 429);
            this.advTreeArea.Styles.Add(this.elementStyle1);
            this.advTreeArea.TabIndex = 3;
            this.advTreeArea.Text = "advTreeEx1";
            this.advTreeArea.AfterNodeSelect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.advTreeArea_AfterNodeSelect);
            this.advTreeArea.NodeMouseDown += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advTreeArea_NodeMouseDown);
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node2,
            this.node3});
            this.node1.Text = "所有区域";
            // 
            // node2
            // 
            this.node2.Expanded = true;
            this.node2.Name = "node2";
            this.node2.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node5});
            this.node2.Text = "区域23啊";
            // 
            // node5
            // 
            this.node5.Expanded = true;
            this.node5.Name = "node5";
            this.node5.Text = "区域等待";
            // 
            // node3
            // 
            this.node3.Expanded = true;
            this.node3.Name = "node3";
            this.node3.Text = "区域1嗯嗯";
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
            // dgvCtrlr
            // 
            this.dgvCtrlr.AllowUserToAddRows = false;
            this.dgvCtrlr.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCtrlr.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCtrlr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Col_XG,
            this.Col_SC});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCtrlr.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCtrlr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCtrlr.EnableHeadersVisualStyles = false;
            this.dgvCtrlr.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvCtrlr.Location = new System.Drawing.Point(0, 28);
            this.dgvCtrlr.Name = "dgvCtrlr";
            this.dgvCtrlr.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCtrlr.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCtrlr.RowTemplate.Height = 23;
            this.dgvCtrlr.Size = new System.Drawing.Size(710, 429);
            this.dgvCtrlr.TabIndex = 3;
            this.dgvCtrlr.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCtrlr_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "控制器名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 93;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "产品序列号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 93;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "启用状态";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 62;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "IP";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "PORT";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 46;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "所在区域";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 62;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "说明";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "所控制的门";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Col_XG
            // 
            this.Col_XG.HeaderText = "修改";
            this.Col_XG.Name = "Col_XG";
            this.Col_XG.ReadOnly = true;
            this.Col_XG.Width = 38;
            // 
            // Col_SC
            // 
            this.Col_SC.HeaderText = "删除";
            this.Col_SC.Name = "Col_SC";
            this.Col_SC.ReadOnly = true;
            this.Col_SC.Width = 38;
            // 
            // ControllerMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ControllerMgr";
            this.Size = new System.Drawing.Size(1014, 457);
            this.Load += new System.EventHandler(this.ControlerMgr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCtrlr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biAddRootArea;
        private DevComponents.DotNetBar.ButtonItem btnAddCtrlr;
        private DevComponents.DotNetBar.ButtonItem biModifyCtrlr;
        private DevComponents.DotNetBar.ButtonItem biDeleteCtrlr;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Li.Controls.AdvTreeEx advTreeArea;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.AdvTree.Node node5;
        private DevComponents.AdvTree.Node node3;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem biAddSubArea;
        private DevComponents.DotNetBar.ButtonItem biDeleteArea;
        private DevComponents.DotNetBar.ButtonItem biAddArea;
        private DevComponents.DotNetBar.ButtonItem biModifyArea;
        private Li.Controls.DataGridViewEx dgvCtrlr;
        private DevComponents.DotNetBar.TextBoxItem tbCtrlrFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewLinkColumn Col_XG;
        private System.Windows.Forms.DataGridViewLinkColumn Col_SC;
    }
}
