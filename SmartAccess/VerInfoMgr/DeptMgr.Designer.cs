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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeptMgr));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.biRefreshDept = new DevComponents.DotNetBar.ButtonItem();
            this.biAddDept = new DevComponents.DotNetBar.ButtonItem();
            this.biAddSubDept = new DevComponents.DotNetBar.ButtonItem();
            this.biModifyDept = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteDept = new DevComponents.DotNetBar.ButtonItem();
            this.biMoveDept = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddSubDept = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModifyDept = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoveDept = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.dataGridViewEx1 = new Li.Controls.DataGridViewEx();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbDeptName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbDeptNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.tbSelectDeptPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.deptTree = new SmartAccess.VerInfoMgr.DeptTree();
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
            // biRefreshDept
            // 
            this.biRefreshDept.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biRefreshDept.ForeColor = System.Drawing.Color.White;
            this.biRefreshDept.Image = ((System.Drawing.Image)(resources.GetObject("biRefreshDept.Image")));
            this.biRefreshDept.Name = "biRefreshDept";
            this.biRefreshDept.Text = "刷新";
            this.biRefreshDept.Click += new System.EventHandler(this.biRefreshDept_Click);
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
            this.biMoveDept.Click += new System.EventHandler(this.biMoveDept_Click);
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
            this.tsmiAddSubDept,
            this.tsmiModifyDept,
            this.tsmiMoveDept});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(149, 70);
            // 
            // tsmiAddSubDept
            // 
            this.tsmiAddSubDept.Name = "tsmiAddSubDept";
            this.tsmiAddSubDept.Size = new System.Drawing.Size(148, 22);
            this.tsmiAddSubDept.Text = "添加下级部门";
            this.tsmiAddSubDept.Click += new System.EventHandler(this.tsmiAddSubDept_Click);
            // 
            // tsmiModifyDept
            // 
            this.tsmiModifyDept.Name = "tsmiModifyDept";
            this.tsmiModifyDept.Size = new System.Drawing.Size(148, 22);
            this.tsmiModifyDept.Text = "修改部门";
            this.tsmiModifyDept.Click += new System.EventHandler(this.tsmiModifyDept_Click);
            // 
            // tsmiMoveDept
            // 
            this.tsmiMoveDept.Name = "tsmiMoveDept";
            this.tsmiMoveDept.Size = new System.Drawing.Size(148, 22);
            this.tsmiMoveDept.Text = "移动部门";
            this.tsmiMoveDept.Click += new System.EventHandler(this.tsmiMoveDept_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.dataGridViewEx1);
            this.panelEx2.Controls.Add(this.tbDeptName);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.tbDeptNo);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.tbSelectDeptPath);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewEx1.EnableHeadersVisualStyles = false;
            this.dataGridViewEx1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.dataGridViewEx1.Location = new System.Drawing.Point(20, 117);
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEx1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
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
            // tbDeptName
            // 
            // 
            // 
            // 
            this.tbDeptName.Border.Class = "TextBoxBorder";
            this.tbDeptName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDeptName.Location = new System.Drawing.Point(335, 47);
            this.tbDeptName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDeptName.Name = "tbDeptName";
            this.tbDeptName.ReadOnly = true;
            this.tbDeptName.Size = new System.Drawing.Size(197, 23);
            this.tbDeptName.TabIndex = 1;
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
            // tbDeptNo
            // 
            // 
            // 
            // 
            this.tbDeptNo.Border.Class = "TextBoxBorder";
            this.tbDeptNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDeptNo.Location = new System.Drawing.Point(94, 47);
            this.tbDeptNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDeptNo.Name = "tbDeptNo";
            this.tbDeptNo.ReadOnly = true;
            this.tbDeptNo.Size = new System.Drawing.Size(161, 23);
            this.tbDeptNo.TabIndex = 1;
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
            // tbSelectDeptPath
            // 
            // 
            // 
            // 
            this.tbSelectDeptPath.Border.Class = "TextBoxBorder";
            this.tbSelectDeptPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbSelectDeptPath.Location = new System.Drawing.Point(94, 13);
            this.tbSelectDeptPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSelectDeptPath.Name = "tbSelectDeptPath";
            this.tbSelectDeptPath.ReadOnly = true;
            this.tbSelectDeptPath.Size = new System.Drawing.Size(438, 23);
            this.tbSelectDeptPath.TabIndex = 1;
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
        private System.Windows.Forms.ToolStripMenuItem tsmiAddSubDept;
        private System.Windows.Forms.ToolStripMenuItem tsmiModifyDept;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveDept;
        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DeptTree deptTree;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private Li.Controls.DataGridViewEx dataGridViewEx1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDeptName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDeptNo;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSelectDeptPath;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.ButtonItem biAddSubDept;
        private DevComponents.DotNetBar.ButtonItem biRefreshDept;

    }
}
