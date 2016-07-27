namespace SmartAccess.VerInfoMgr
{
    partial class DeptMgr
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeptMgr));
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biAddDept = new DevComponents.DotNetBar.ButtonItem();
            this.biAddSubDept = new DevComponents.DotNetBar.ButtonItem();
            this.biModifyDept = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteDept = new DevComponents.DotNetBar.ButtonItem();
            this.biMoveDept = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加下级部门ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改部门ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移动部门ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.dataGridViewEx1 = new Li.Controls.DataGridViewEx();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxX4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX5 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX6 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.deptTree = new SmartAccess.VerInfoMgr.DeptTree();
            this.biRefreshDept = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biRefreshDept,
            this.biAddDept,
            this.biAddSubDept,
            this.biModifyDept,
            this.biDeleteDept,
            this.biMoveDept,
            this.buttonItem5,
            this.buttonItem6});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(943, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 2;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // biAddDept
            // 
            this.biAddDept.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAddDept.ForeColor = System.Drawing.Color.White;
            this.biAddDept.Image = ((System.Drawing.Image)(resources.GetObject("biAddDept.Image")));
            this.biAddDept.Name = "biAddDept";
            this.biAddDept.Text = "添加部门";
            this.biAddDept.Tooltip = "添加跟级或同级部门";
            this.biAddDept.Click += new System.EventHandler(this.biAddDept_Click);
            // 
            // biAddSubDept
            // 
            this.biAddSubDept.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAddSubDept.ForeColor = System.Drawing.Color.White;
            this.biAddSubDept.Image = ((System.Drawing.Image)(resources.GetObject("biAddSubDept.Image")));
            this.biAddSubDept.Name = "biAddSubDept";
            this.biAddSubDept.Text = "添加下级部门";
            this.biAddSubDept.Tooltip = "添加下级部门";
            this.biAddSubDept.Click += new System.EventHandler(this.biAddSubDept_Click);
            // 
            // biModifyDept
            // 
            this.biModifyDept.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biModifyDept.ForeColor = System.Drawing.Color.White;
            this.biModifyDept.Image = ((System.Drawing.Image)(resources.GetObject("biModifyDept.Image")));
            this.biModifyDept.Name = "biModifyDept";
            this.biModifyDept.Text = "修改部门";
            this.biModifyDept.Tooltip = "修改选择部门";
            this.biModifyDept.Click += new System.EventHandler(this.biModifyDept_Click);
            // 
            // biDeleteDept
            // 
            this.biDeleteDept.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDeleteDept.ForeColor = System.Drawing.Color.White;
            this.biDeleteDept.Image = ((System.Drawing.Image)(resources.GetObject("biDeleteDept.Image")));
            this.biDeleteDept.Name = "biDeleteDept";
            this.biDeleteDept.Text = "删除部门";
            this.biDeleteDept.Tooltip = "删除选择部门";
            this.biDeleteDept.Click += new System.EventHandler(this.biDeleteDept_Click);
            // 
            // biMoveDept
            // 
            this.biMoveDept.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biMoveDept.ForeColor = System.Drawing.Color.White;
            this.biMoveDept.Image = ((System.Drawing.Image)(resources.GetObject("biMoveDept.Image")));
            this.biMoveDept.Name = "biMoveDept";
            this.biMoveDept.Text = "移动部门";
            // 
            // buttonItem5
            // 
            this.buttonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem5.ForeColor = System.Drawing.Color.White;
            this.buttonItem5.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem5.Image")));
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "导入所有部门";
            // 
            // buttonItem6
            // 
            this.buttonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem6.ForeColor = System.Drawing.Color.White;
            this.buttonItem6.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem6.Image")));
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Text = "导出所有部门";
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加下级部门ToolStripMenuItem,
            this.修改部门ToolStripMenuItem,
            this.移动部门ToolStripMenuItem});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(149, 70);
            // 
            // 添加下级部门ToolStripMenuItem
            // 
            this.添加下级部门ToolStripMenuItem.Name = "添加下级部门ToolStripMenuItem";
            this.添加下级部门ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加下级部门ToolStripMenuItem.Text = "添加下级部门";
            // 
            // 修改部门ToolStripMenuItem
            // 
            this.修改部门ToolStripMenuItem.Name = "修改部门ToolStripMenuItem";
            this.修改部门ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.修改部门ToolStripMenuItem.Text = "修改部门";
            // 
            // 移动部门ToolStripMenuItem
            // 
            this.移动部门ToolStripMenuItem.Name = "移动部门ToolStripMenuItem";
            this.移动部门ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.移动部门ToolStripMenuItem.Text = "移动部门";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.dataGridViewEx1);
            this.panelEx2.Controls.Add(this.textBoxX4);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.textBoxX5);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.textBoxX6);
            this.panelEx2.Controls.Add(this.labelX6);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(249, 28);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(694, 447);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 7;
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEx1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewEx1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.dataGridViewEx1.Location = new System.Drawing.Point(20, 117);
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowTemplate.Height = 23;
            this.dataGridViewEx1.Size = new System.Drawing.Size(671, 327);
            this.dataGridViewEx1.TabIndex = 2;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "人员编号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "姓名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "所属部门";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // textBoxX4
            // 
            // 
            // 
            // 
            this.textBoxX4.Border.Class = "TextBoxBorder";
            this.textBoxX4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX4.Location = new System.Drawing.Point(335, 47);
            this.textBoxX4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxX4.Name = "textBoxX4";
            this.textBoxX4.ReadOnly = true;
            this.textBoxX4.Size = new System.Drawing.Size(197, 23);
            this.textBoxX4.TabIndex = 1;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(20, 87);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(85, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "权限操作人";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(268, 47);
            this.labelX4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(65, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "部门名称";
            // 
            // textBoxX5
            // 
            // 
            // 
            // 
            this.textBoxX5.Border.Class = "TextBoxBorder";
            this.textBoxX5.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX5.Location = new System.Drawing.Point(94, 47);
            this.textBoxX5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxX5.Name = "textBoxX5";
            this.textBoxX5.ReadOnly = true;
            this.textBoxX5.Size = new System.Drawing.Size(161, 23);
            this.textBoxX5.TabIndex = 1;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(20, 47);
            this.labelX5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(63, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "部门编码";
            // 
            // textBoxX6
            // 
            // 
            // 
            // 
            this.textBoxX6.Border.Class = "TextBoxBorder";
            this.textBoxX6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX6.Location = new System.Drawing.Point(94, 13);
            this.textBoxX6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxX6.Name = "textBoxX6";
            this.textBoxX6.ReadOnly = true;
            this.textBoxX6.Size = new System.Drawing.Size(438, 23);
            this.textBoxX6.TabIndex = 1;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX6.Location = new System.Drawing.Point(20, 13);
            this.labelX6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(71, 23);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "选定部门";
            // 
            // deptTree
            // 
            this.deptTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.deptTree.Location = new System.Drawing.Point(0, 28);
            this.deptTree.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.deptTree.Name = "deptTree";
            this.deptTree.Size = new System.Drawing.Size(249, 447);
            this.deptTree.TabIndex = 6;
            // 
            // biRefreshDept
            // 
            this.biRefreshDept.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biRefreshDept.ForeColor = System.Drawing.Color.White;
            this.biRefreshDept.Image = ((System.Drawing.Image)(resources.GetObject("biRefreshDept.Image")));
            this.biRefreshDept.Name = "biRefreshDept";
            this.biRefreshDept.Text = "刷新";
            this.biRefreshDept.Click += new System.EventHandler(this.biRefreshDept_Click);
            // 
            // DeptMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.deptTree);
            this.Controls.Add(this.bar1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DeptMgr";
            this.Size = new System.Drawing.Size(943, 475);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biAddDept;
        private DevComponents.DotNetBar.ButtonItem biModifyDept;
        private DevComponents.DotNetBar.ButtonItem biDeleteDept;
        private DevComponents.DotNetBar.ButtonItem biMoveDept;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem 添加下级部门ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改部门ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移动部门ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DeptTree deptTree;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private Li.Controls.DataGridViewEx dataGridViewEx1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX4;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX5;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX6;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.ButtonItem biAddSubDept;
        private DevComponents.DotNetBar.ButtonItem biRefreshDept;

    }
}
