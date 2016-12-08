namespace SmartAccess.ConfigMgr
{
    partial class FrmAlarmSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvData = new Li.Controls.DataGridViewEx();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column4 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column5 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column6 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column7 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column8 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column9 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column10 = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem4 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem3 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.btnApply = new DevComponents.DotNetBar.ButtonX();
            this.iUnClosedTimeOut = new DevComponents.Editors.IntegerInput();
            this.tbForcePwd = new Li.Controls.TextBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOkUploaAll = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.alarmConnectPort1 = new SmartAccess.ConfigMgr.AlarmConnectPort();
            this.alarmConnectPort4 = new SmartAccess.ConfigMgr.AlarmConnectPort();
            this.alarmConnectPort3 = new SmartAccess.ConfigMgr.AlarmConnectPort();
            this.alarmConnectPort2 = new SmartAccess.ConfigMgr.AlarmConnectPort();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.groupPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.superTabControlPanel4.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iUnClosedTimeOut)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(1050, 232);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "控制器名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "控制器SN";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.Checked = true;
            this.Column3.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column3.CheckValue = "N";
            this.Column3.HeaderText = "胁迫开门";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column4
            // 
            this.Column4.Checked = true;
            this.Column4.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column4.CheckValue = "N";
            this.Column4.HeaderText = "超时未关";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column5
            // 
            this.Column5.Checked = true;
            this.Column5.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column5.CheckValue = "N";
            this.Column5.HeaderText = "强行闯入";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column6
            // 
            this.Column6.Checked = true;
            this.Column6.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column6.CheckValue = "N";
            this.Column6.HeaderText = "强行关门";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.Checked = true;
            this.Column7.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column7.CheckValue = "N";
            this.Column7.HeaderText = "无效刷卡";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.Checked = true;
            this.Column8.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column8.CheckValue = "N";
            this.Column8.HeaderText = "火警";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.Checked = true;
            this.Column9.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column9.CheckValue = "N";
            this.Column9.HeaderText = "防盗";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.Checked = true;
            this.Column10.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.Column10.CheckValue = "N";
            this.Column10.HeaderText = "胁迫刷卡";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "控制门";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupPanel);
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Controls.Add(this.btnOkUploaAll);
            this.panelEx1.Controls.Add(this.btnOk);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelEx1.Location = new System.Drawing.Point(0, 232);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1050, 284);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // groupPanel
            // 
            this.groupPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel.Controls.Add(this.superTabControl1);
            this.groupPanel.Controls.Add(this.btnApply);
            this.groupPanel.Controls.Add(this.iUnClosedTimeOut);
            this.groupPanel.Controls.Add(this.tbForcePwd);
            this.groupPanel.Controls.Add(this.labelX2);
            this.groupPanel.Controls.Add(this.labelX1);
            this.groupPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel.Location = new System.Drawing.Point(0, 0);
            this.groupPanel.Name = "groupPanel";
            this.groupPanel.Size = new System.Drawing.Size(1050, 223);
            // 
            // 
            // 
            this.groupPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel.Style.BackColorGradientAngle = 90;
            this.groupPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel.Style.BorderBottomWidth = 1;
            this.groupPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel.Style.BorderLeftWidth = 1;
            this.groupPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel.Style.BorderRightWidth = 1;
            this.groupPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel.Style.BorderTopWidth = 1;
            this.groupPanel.Style.CornerDiameter = 4;
            this.groupPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel.TabIndex = 5;
            // 
            // superTabControl1
            // 
            this.superTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.superTabControlPanel4);
            this.superTabControl1.Controls.Add(this.superTabControlPanel3);
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Location = new System.Drawing.Point(-3, 3);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 3;
            this.superTabControl1.Size = new System.Drawing.Size(805, 211);
            this.superTabControl1.TabFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 6;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.superTabItem2,
            this.superTabItem3,
            this.superTabItem4});
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.alarmConnectPort1);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 30);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(805, 181);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "1号扩展输出口";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Controls.Add(this.alarmConnectPort4);
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(805, 211);
            this.superTabControlPanel4.TabIndex = 4;
            this.superTabControlPanel4.TabItem = this.superTabItem4;
            // 
            // superTabItem4
            // 
            this.superTabItem4.AttachedControl = this.superTabControlPanel4;
            this.superTabItem4.GlobalItem = false;
            this.superTabItem4.Name = "superTabItem4";
            this.superTabItem4.Text = "4号扩展输出口";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.alarmConnectPort3);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(805, 211);
            this.superTabControlPanel3.TabIndex = 3;
            this.superTabControlPanel3.TabItem = this.superTabItem3;
            // 
            // superTabItem3
            // 
            this.superTabItem3.AttachedControl = this.superTabControlPanel3;
            this.superTabItem3.GlobalItem = false;
            this.superTabItem3.Name = "superTabItem3";
            this.superTabItem3.Text = "3号扩展输出口";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.alarmConnectPort2);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(805, 211);
            this.superTabControlPanel2.TabIndex = 2;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "2号扩展输出口";
            // 
            // btnApply
            // 
            this.btnApply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnApply.Location = new System.Drawing.Point(808, 128);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(160, 33);
            this.btnApply.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "应用";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // iUnClosedTimeOut
            // 
            this.iUnClosedTimeOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.iUnClosedTimeOut.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iUnClosedTimeOut.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iUnClosedTimeOut.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iUnClosedTimeOut.Location = new System.Drawing.Point(903, 33);
            this.iUnClosedTimeOut.Name = "iUnClosedTimeOut";
            this.iUnClosedTimeOut.ShowUpDown = true;
            this.iUnClosedTimeOut.Size = new System.Drawing.Size(100, 23);
            this.iUnClosedTimeOut.TabIndex = 2;
            this.iUnClosedTimeOut.Value = 25;
            // 
            // tbForcePwd
            // 
            this.tbForcePwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbForcePwd.Border.Class = "TextBoxBorder";
            this.tbForcePwd.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbForcePwd.Location = new System.Drawing.Point(903, 4);
            this.tbForcePwd.MaxLength = 6;
            this.tbForcePwd.Name = "tbForcePwd";
            this.tbForcePwd.NumberOnly = true;
            this.tbForcePwd.Size = new System.Drawing.Size(100, 23);
            this.tbForcePwd.TabIndex = 1;
            // 
            // labelX2
            // 
            this.labelX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(808, 33);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(89, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "开门超时(秒)";
            // 
            // labelX1
            // 
            this.labelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(808, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(61, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "胁迫密码";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(537, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 33);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            // 
            // btnOkUploaAll
            // 
            this.btnOkUploaAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOkUploaAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOkUploaAll.Location = new System.Drawing.Point(415, 235);
            this.btnOkUploaAll.Name = "btnOkUploaAll";
            this.btnOkUploaAll.Size = new System.Drawing.Size(116, 33);
            this.btnOkUploaAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOkUploaAll.TabIndex = 4;
            this.btnOkUploaAll.Text = "应用并上传";
            this.btnOkUploaAll.Click += new System.EventHandler(this.btnOkUploaAll_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(296, 235);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(113, 33);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // alarmConnectPort1
            // 
            this.alarmConnectPort1.AlarmConnect = null;
            this.alarmConnectPort1.BackColor = System.Drawing.Color.Transparent;
            this.alarmConnectPort1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alarmConnectPort1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alarmConnectPort1.Location = new System.Drawing.Point(0, 0);
            this.alarmConnectPort1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.alarmConnectPort1.Name = "alarmConnectPort1";
            this.alarmConnectPort1.Size = new System.Drawing.Size(805, 181);
            this.alarmConnectPort1.TabIndex = 1;
            this.alarmConnectPort1.Tag = "";
            // 
            // alarmConnectPort4
            // 
            this.alarmConnectPort4.AlarmConnect = null;
            this.alarmConnectPort4.BackColor = System.Drawing.Color.Transparent;
            this.alarmConnectPort4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alarmConnectPort4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alarmConnectPort4.Location = new System.Drawing.Point(0, 0);
            this.alarmConnectPort4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.alarmConnectPort4.Name = "alarmConnectPort4";
            this.alarmConnectPort4.Size = new System.Drawing.Size(805, 211);
            this.alarmConnectPort4.TabIndex = 2;
            // 
            // alarmConnectPort3
            // 
            this.alarmConnectPort3.AlarmConnect = null;
            this.alarmConnectPort3.BackColor = System.Drawing.Color.Transparent;
            this.alarmConnectPort3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alarmConnectPort3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alarmConnectPort3.Location = new System.Drawing.Point(0, 0);
            this.alarmConnectPort3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.alarmConnectPort3.Name = "alarmConnectPort3";
            this.alarmConnectPort3.Size = new System.Drawing.Size(805, 211);
            this.alarmConnectPort3.TabIndex = 2;
            // 
            // alarmConnectPort2
            // 
            this.alarmConnectPort2.AlarmConnect = null;
            this.alarmConnectPort2.BackColor = System.Drawing.Color.Transparent;
            this.alarmConnectPort2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alarmConnectPort2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.alarmConnectPort2.Location = new System.Drawing.Point(0, 0);
            this.alarmConnectPort2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.alarmConnectPort2.Name = "alarmConnectPort2";
            this.alarmConnectPort2.Size = new System.Drawing.Size(805, 211);
            this.alarmConnectPort2.TabIndex = 2;
            // 
            // FrmAlarmSetting
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1050, 516);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.dgvData);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAlarmSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "报警联动设置";
            this.Load += new System.EventHandler(this.FrmAlarmSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.groupPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel4.ResumeLayout(false);
            this.superTabControlPanel3.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iUnClosedTimeOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Li.Controls.DataGridViewEx dgvData;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private Li.Controls.TextBoxEx tbForcePwd;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.IntegerInput iUnClosedTimeOut;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel;
        private DevComponents.DotNetBar.ButtonX btnApply;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnOkUploaAll;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column3;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column4;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column5;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column6;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column7;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column8;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column9;
        private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem superTabItem3;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private DevComponents.DotNetBar.SuperTabItem superTabItem4;
        private AlarmConnectPort alarmConnectPort1;
        private AlarmConnectPort alarmConnectPort2;
        private AlarmConnectPort alarmConnectPort3;
        private AlarmConnectPort alarmConnectPort4;
    }
}