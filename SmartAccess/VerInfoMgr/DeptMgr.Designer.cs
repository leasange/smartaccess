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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddSubDept = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModifyDept = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoveDept = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCobine = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.dgvUsers = new Li.Controls.DataGridViewEx();
            this.tbDeptName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbDeptNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.tbSelectDeptPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.btnAddPrivate = new DevComponents.DotNetBar.ButtonX();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new Li.Controls.DataGridViewLinkLabelColumn();
            this.biRefreshDept = new DevComponents.DotNetBar.ButtonItem();
            this.biAddDept = new DevComponents.DotNetBar.ButtonItem();
            this.biAddSubDept = new DevComponents.DotNetBar.ButtonItem();
            this.biModifyDept = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteDept = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteCurrent = new DevComponents.DotNetBar.ButtonItem();
            this.biDeleteAllDept = new DevComponents.DotNetBar.ButtonItem();
            this.biMoveDept = new DevComponents.DotNetBar.ButtonItem();
            this.biCombine = new DevComponents.DotNetBar.ButtonItem();
            this.biDownloadDeptModel = new DevComponents.DotNetBar.ButtonItem();
            this.biInput = new DevComponents.DotNetBar.ButtonItem();
            this.biOutput = new DevComponents.DotNetBar.ButtonItem();
            this.btnDeleteSelected = new DevComponents.DotNetBar.ButtonX();
            this.deptTree = new SmartAccess.VerInfoMgr.DeptTree();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
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
            this.biCombine,
            this.biDownloadDeptModel,
            this.biInput,
            this.biOutput});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1012, 29);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 2;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddSubDept,
            this.tsmiModifyDept,
            this.tsmiMoveDept,
            this.tsmiCobine,
            this.tsmiDeleteCurrent,
            this.tsmiDeleteAll});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(193, 136);
            // 
            // tsmiAddSubDept
            // 
            this.tsmiAddSubDept.Name = "tsmiAddSubDept";
            this.tsmiAddSubDept.Size = new System.Drawing.Size(192, 22);
            this.tsmiAddSubDept.Text = "添加下级部门";
            this.tsmiAddSubDept.Click += new System.EventHandler(this.tsmiAddSubDept_Click);
            // 
            // tsmiModifyDept
            // 
            this.tsmiModifyDept.Name = "tsmiModifyDept";
            this.tsmiModifyDept.Size = new System.Drawing.Size(192, 22);
            this.tsmiModifyDept.Text = "修改部门";
            this.tsmiModifyDept.Click += new System.EventHandler(this.tsmiModifyDept_Click);
            // 
            // tsmiMoveDept
            // 
            this.tsmiMoveDept.Name = "tsmiMoveDept";
            this.tsmiMoveDept.Size = new System.Drawing.Size(192, 22);
            this.tsmiMoveDept.Text = "移动部门";
            this.tsmiMoveDept.Click += new System.EventHandler(this.tsmiMoveDept_Click);
            // 
            // tsmiCobine
            // 
            this.tsmiCobine.Name = "tsmiCobine";
            this.tsmiCobine.Size = new System.Drawing.Size(192, 22);
            this.tsmiCobine.Text = "合并部门";
            this.tsmiCobine.Click += new System.EventHandler(this.biCombine_Click);
            // 
            // tsmiDeleteCurrent
            // 
            this.tsmiDeleteCurrent.Name = "tsmiDeleteCurrent";
            this.tsmiDeleteCurrent.Size = new System.Drawing.Size(192, 22);
            this.tsmiDeleteCurrent.Text = "删除部门(不包括下级)";
            this.tsmiDeleteCurrent.Click += new System.EventHandler(this.biDeleteCurrent_Click);
            // 
            // tsmiDeleteAll
            // 
            this.tsmiDeleteAll.Name = "tsmiDeleteAll";
            this.tsmiDeleteAll.Size = new System.Drawing.Size(192, 22);
            this.tsmiDeleteAll.Text = "删除部门(包括下级)";
            this.tsmiDeleteAll.Click += new System.EventHandler(this.biDeleteDept_Click);
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.btnDeleteSelected);
            this.panelEx2.Controls.Add(this.btnAddPrivate);
            this.panelEx2.Controls.Add(this.dgvUsers);
            this.panelEx2.Controls.Add(this.tbDeptName);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.tbDeptNo);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.tbSelectDeptPath);
            this.panelEx2.Controls.Add(this.labelX6);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(249, 29);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(763, 446);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 7;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvUsers.Location = new System.Drawing.Point(20, 117);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsers.RowTemplate.Height = 23;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(740, 326);
            this.dgvUsers.TabIndex = 2;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);
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
            // btnAddPrivate
            // 
            this.btnAddPrivate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddPrivate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddPrivate.Location = new System.Drawing.Point(111, 88);
            this.btnAddPrivate.Name = "btnAddPrivate";
            this.btnAddPrivate.Size = new System.Drawing.Size(75, 23);
            this.btnAddPrivate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddPrivate.TabIndex = 3;
            this.btnAddPrivate.Text = "添加/修改";
            this.btnAddPrivate.Click += new System.EventHandler(this.btnAddPrivate_Click);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "用户名";
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
            // Column4
            // 
            this.Column4.HeaderText = "操作";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SplitLinkSymbol = ",";
            // 
            // biRefreshDept
            // 
            this.biRefreshDept.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biRefreshDept.Image = global::SmartAccess.Properties.Resources.刷新;
            this.biRefreshDept.Name = "biRefreshDept";
            this.biRefreshDept.Text = "刷新";
            this.biRefreshDept.Click += new System.EventHandler(this.biRefreshDept_Click);
            // 
            // biAddDept
            // 
            this.biAddDept.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAddDept.Image = global::SmartAccess.Properties.Resources.增加部门;
            this.biAddDept.Name = "biAddDept";
            this.biAddDept.Text = "添加根级或同级部门";
            this.biAddDept.Tooltip = "添加根级或同级部门";
            this.biAddDept.Click += new System.EventHandler(this.biAddDept_Click);
            // 
            // biAddSubDept
            // 
            this.biAddSubDept.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biAddSubDept.Image = global::SmartAccess.Properties.Resources.添加下级部门;
            this.biAddSubDept.Name = "biAddSubDept";
            this.biAddSubDept.Text = "添加下级部门";
            this.biAddSubDept.Tooltip = "添加下级部门";
            this.biAddSubDept.Click += new System.EventHandler(this.biAddSubDept_Click);
            // 
            // biModifyDept
            // 
            this.biModifyDept.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biModifyDept.Image = global::SmartAccess.Properties.Resources.修改部门;
            this.biModifyDept.Name = "biModifyDept";
            this.biModifyDept.Text = "修改部门";
            this.biModifyDept.Tooltip = "修改选择部门";
            this.biModifyDept.Click += new System.EventHandler(this.biModifyDept_Click);
            // 
            // biDeleteDept
            // 
            this.biDeleteDept.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDeleteDept.Image = global::SmartAccess.Properties.Resources.删除;
            this.biDeleteDept.Name = "biDeleteDept";
            this.biDeleteDept.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biDeleteCurrent,
            this.biDeleteAllDept});
            this.biDeleteDept.Text = "删除部门";
            this.biDeleteDept.Tooltip = "删除选择部门";
            this.biDeleteDept.Click += new System.EventHandler(this.biDeleteDept_Click_1);
            // 
            // biDeleteCurrent
            // 
            this.biDeleteCurrent.Name = "biDeleteCurrent";
            this.biDeleteCurrent.Text = "删除部门(不包括下级)";
            this.biDeleteCurrent.Click += new System.EventHandler(this.biDeleteCurrent_Click);
            // 
            // biDeleteAllDept
            // 
            this.biDeleteAllDept.Name = "biDeleteAllDept";
            this.biDeleteAllDept.Text = "删除部门(包括下级)";
            this.biDeleteAllDept.Click += new System.EventHandler(this.biDeleteDept_Click);
            // 
            // biMoveDept
            // 
            this.biMoveDept.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biMoveDept.Image = global::SmartAccess.Properties.Resources.移动部门;
            this.biMoveDept.Name = "biMoveDept";
            this.biMoveDept.Text = "移动部门";
            this.biMoveDept.Click += new System.EventHandler(this.biMoveDept_Click);
            // 
            // biCombine
            // 
            this.biCombine.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biCombine.Image = global::SmartAccess.Properties.Resources.添加下级部门;
            this.biCombine.Name = "biCombine";
            this.biCombine.Text = "合并部门";
            this.biCombine.Tooltip = "合并部门";
            this.biCombine.Click += new System.EventHandler(this.biCombine_Click);
            // 
            // biDownloadDeptModel
            // 
            this.biDownloadDeptModel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biDownloadDeptModel.Image = global::SmartAccess.Properties.Resources.模板下载;
            this.biDownloadDeptModel.Name = "biDownloadDeptModel";
            this.biDownloadDeptModel.Text = "模板下载";
            this.biDownloadDeptModel.Click += new System.EventHandler(this.biDownloadDeptModel_Click);
            // 
            // biInput
            // 
            this.biInput.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biInput.Image = global::SmartAccess.Properties.Resources.导入;
            this.biInput.Name = "biInput";
            this.biInput.Text = "导入部门";
            this.biInput.Click += new System.EventHandler(this.biInput_Click);
            // 
            // biOutput
            // 
            this.biOutput.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.biOutput.Image = global::SmartAccess.Properties.Resources.导出;
            this.biOutput.Name = "biOutput";
            this.biOutput.Text = "导出所有部门";
            this.biOutput.Click += new System.EventHandler(this.biOutput_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteSelected.Location = new System.Drawing.Point(192, 88);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeleteSelected.TabIndex = 4;
            this.btnDeleteSelected.Text = "删除选择";
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // deptTree
            // 
            this.deptTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.deptTree.Location = new System.Drawing.Point(0, 29);
            this.deptTree.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.deptTree.Name = "deptTree";
            this.deptTree.Size = new System.Drawing.Size(249, 446);
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
            this.Size = new System.Drawing.Size(1012, 475);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem biAddDept;
        private DevComponents.DotNetBar.ButtonItem biModifyDept;
        private DevComponents.DotNetBar.ButtonItem biDeleteDept;
        private DevComponents.DotNetBar.ButtonItem biMoveDept;
        private DevComponents.DotNetBar.ButtonItem biInput;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddSubDept;
        private System.Windows.Forms.ToolStripMenuItem tsmiModifyDept;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveDept;
        private DevComponents.DotNetBar.ButtonItem biOutput;
        private DeptTree deptTree;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private Li.Controls.DataGridViewEx dgvUsers;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDeptName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDeptNo;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSelectDeptPath;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.ButtonItem biAddSubDept;
        private DevComponents.DotNetBar.ButtonItem biRefreshDept;
        private DevComponents.DotNetBar.ButtonItem biDownloadDeptModel;
        private DevComponents.DotNetBar.ButtonItem biCombine;
        private System.Windows.Forms.ToolStripMenuItem tsmiCobine;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCurrent;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteAll;
        private DevComponents.DotNetBar.ButtonItem biDeleteCurrent;
        private DevComponents.DotNetBar.ButtonItem biDeleteAllDept;
        private DevComponents.DotNetBar.ButtonX btnAddPrivate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Li.Controls.DataGridViewLinkLabelColumn Column4;
        private DevComponents.DotNetBar.ButtonX btnDeleteSelected;

    }
}
