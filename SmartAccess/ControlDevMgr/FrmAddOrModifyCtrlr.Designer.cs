namespace SmartAccess.ControlDevMgr
{
    partial class FrmAddOrModifyCtrlr
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
            this.components = new System.ComponentModel.Container();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tbCtrlName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbCtrlrSn = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.iiPort = new DevComponents.Editors.IntegerInput();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.tbDesc = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cboTreeArea = new DevComponents.DotNetBar.Controls.ComboTree();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.cbIsElevator = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbCtrlrEnable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ipCtrlr = new DevComponents.Editors.IpAddressInput();
            this.tabItemBase = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.doorReaderAttriGroup = new SmartAccess.ControlDevMgr.DoorReaderAttriGroup();
            this.doorNameAttriGroup = new SmartAccess.ControlDevMgr.DoorNameAttriGroup();
            this.labelX13 = new DevComponents.DotNetBar.LabelX();
            this.labelX12 = new DevComponents.DotNetBar.LabelX();
            this.labelX18 = new DevComponents.DotNetBar.LabelX();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.tabItemDoor = new DevComponents.DotNetBar.TabItem(this.components);
            this.btnOkAndUpload = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.iiPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipCtrlr)).BeginInit();
            this.tabControlPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(14, 15);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(115, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "控制器名称：";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbCtrlName
            // 
            // 
            // 
            // 
            this.tbCtrlName.Border.Class = "TextBoxBorder";
            this.tbCtrlName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbCtrlName.Location = new System.Drawing.Point(135, 16);
            this.tbCtrlName.Name = "tbCtrlName";
            this.tbCtrlName.Size = new System.Drawing.Size(170, 23);
            this.tbCtrlName.TabIndex = 0;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(14, 44);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(115, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "*产品序列号SN：";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbCtrlrSn
            // 
            // 
            // 
            // 
            this.tbCtrlrSn.Border.Class = "TextBoxBorder";
            this.tbCtrlrSn.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbCtrlrSn.Location = new System.Drawing.Point(135, 44);
            this.tbCtrlrSn.Name = "tbCtrlrSn";
            this.tbCtrlrSn.Size = new System.Drawing.Size(170, 23);
            this.tbCtrlrSn.TabIndex = 1;
            this.tbCtrlrSn.TextChanged += new System.EventHandler(this.tbCtrlrSn_TextChanged);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(14, 74);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(115, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "*控制器IP：";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // iiPort
            // 
            // 
            // 
            // 
            this.iiPort.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iiPort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iiPort.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iiPort.Location = new System.Drawing.Point(135, 102);
            this.iiPort.MaxValue = 65535;
            this.iiPort.MinValue = 0;
            this.iiPort.Name = "iiPort";
            this.iiPort.ShowUpDown = true;
            this.iiPort.Size = new System.Drawing.Size(170, 23);
            this.iiPort.TabIndex = 4;
            this.iiPort.Value = 60000;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(14, 102);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(115, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "控制器端口：";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(14, 131);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(115, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "控制器说明：";
            this.labelX5.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbDesc
            // 
            // 
            // 
            // 
            this.tbDesc.Border.Class = "TextBoxBorder";
            this.tbDesc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDesc.Location = new System.Drawing.Point(135, 132);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDesc.Size = new System.Drawing.Size(170, 78);
            this.tbDesc.TabIndex = 5;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(14, 218);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(115, 23);
            this.labelX6.TabIndex = 0;
            this.labelX6.Text = "所在区域：";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cboTreeArea
            // 
            this.cboTreeArea.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.cboTreeArea.BackgroundStyle.Class = "TextBoxBorder";
            this.cboTreeArea.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cboTreeArea.ButtonDropDown.Visible = true;
            this.cboTreeArea.DropDownHeight = 200;
            this.cboTreeArea.Location = new System.Drawing.Point(135, 218);
            this.cboTreeArea.Name = "cboTreeArea";
            this.cboTreeArea.Size = new System.Drawing.Size(170, 23);
            this.cboTreeArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboTreeArea.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(623, 383);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItemBase);
            this.tabControl1.Tabs.Add(this.tabItemDoor);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.cbIsElevator);
            this.tabControlPanel1.Controls.Add(this.cbCtrlrEnable);
            this.tabControlPanel1.Controls.Add(this.ipCtrlr);
            this.tabControlPanel1.Controls.Add(this.tbCtrlName);
            this.tabControlPanel1.Controls.Add(this.cboTreeArea);
            this.tabControlPanel1.Controls.Add(this.labelX1);
            this.tabControlPanel1.Controls.Add(this.iiPort);
            this.tabControlPanel1.Controls.Add(this.labelX2);
            this.tabControlPanel1.Controls.Add(this.tbDesc);
            this.tabControlPanel1.Controls.Add(this.labelX3);
            this.tabControlPanel1.Controls.Add(this.labelX4);
            this.tabControlPanel1.Controls.Add(this.tbCtrlrSn);
            this.tabControlPanel1.Controls.Add(this.labelX5);
            this.tabControlPanel1.Controls.Add(this.labelX6);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(623, 355);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItemBase;
            // 
            // cbIsElevator
            // 
            this.cbIsElevator.AutoSize = true;
            this.cbIsElevator.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbIsElevator.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbIsElevator.Location = new System.Drawing.Point(386, 44);
            this.cbIsElevator.Name = "cbIsElevator";
            this.cbIsElevator.Size = new System.Drawing.Size(88, 20);
            this.cbIsElevator.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbIsElevator.TabIndex = 7;
            this.cbIsElevator.Text = "电梯控制器";
            this.cbIsElevator.Visible = false;
            this.cbIsElevator.CheckedChanged += new System.EventHandler(this.cbIsElevator_CheckedChanged);
            // 
            // cbCtrlrEnable
            // 
            this.cbCtrlrEnable.AutoSize = true;
            this.cbCtrlrEnable.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbCtrlrEnable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbCtrlrEnable.Checked = true;
            this.cbCtrlrEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCtrlrEnable.CheckValue = "Y";
            this.cbCtrlrEnable.Location = new System.Drawing.Point(316, 44);
            this.cbCtrlrEnable.Name = "cbCtrlrEnable";
            this.cbCtrlrEnable.Size = new System.Drawing.Size(51, 20);
            this.cbCtrlrEnable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbCtrlrEnable.TabIndex = 2;
            this.cbCtrlrEnable.Text = "启用";
            // 
            // ipCtrlr
            // 
            this.ipCtrlr.AutoOverwrite = true;
            // 
            // 
            // 
            this.ipCtrlr.BackgroundStyle.Class = "DateTimeInputBackground";
            this.ipCtrlr.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ipCtrlr.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.ipCtrlr.ButtonFreeText.Visible = true;
            this.ipCtrlr.Location = new System.Drawing.Point(135, 73);
            this.ipCtrlr.Name = "ipCtrlr";
            this.ipCtrlr.Size = new System.Drawing.Size(170, 23);
            this.ipCtrlr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ipCtrlr.TabIndex = 3;
            // 
            // tabItemBase
            // 
            this.tabItemBase.AttachedControl = this.tabControlPanel1;
            this.tabItemBase.Name = "tabItemBase";
            this.tabItemBase.Text = "基本属性";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.doorReaderAttriGroup);
            this.tabControlPanel2.Controls.Add(this.doorNameAttriGroup);
            this.tabControlPanel2.Controls.Add(this.labelX13);
            this.tabControlPanel2.Controls.Add(this.labelX12);
            this.tabControlPanel2.Controls.Add(this.labelX18);
            this.tabControlPanel2.Controls.Add(this.labelX11);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(623, 355);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItemDoor;
            // 
            // doorReaderAttriGroup
            // 
            this.doorReaderAttriGroup.AutoScroll = true;
            this.doorReaderAttriGroup.BackColor = System.Drawing.Color.Transparent;
            this.doorReaderAttriGroup.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doorReaderAttriGroup.Location = new System.Drawing.Point(22, 193);
            this.doorReaderAttriGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.doorReaderAttriGroup.Name = "doorReaderAttriGroup";
            this.doorReaderAttriGroup.Size = new System.Drawing.Size(257, 146);
            this.doorReaderAttriGroup.TabIndex = 8;
            this.doorReaderAttriGroup.Visible = false;
            // 
            // doorNameAttriGroup
            // 
            this.doorNameAttriGroup.AutoScroll = true;
            this.doorNameAttriGroup.BackColor = System.Drawing.Color.Transparent;
            this.doorNameAttriGroup.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.doorNameAttriGroup.Location = new System.Drawing.Point(22, 25);
            this.doorNameAttriGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.doorNameAttriGroup.Name = "doorNameAttriGroup";
            this.doorNameAttriGroup.Size = new System.Drawing.Size(586, 145);
            this.doorNameAttriGroup.TabIndex = 7;
            // 
            // labelX13
            // 
            this.labelX13.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX13.Location = new System.Drawing.Point(447, 4);
            this.labelX13.Name = "labelX13";
            this.labelX13.Size = new System.Drawing.Size(83, 14);
            this.labelX13.TabIndex = 2;
            this.labelX13.Text = "开门延时(秒)";
            this.labelX13.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX12
            // 
            this.labelX12.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX12.Location = new System.Drawing.Point(347, 3);
            this.labelX12.Name = "labelX12";
            this.labelX12.Size = new System.Drawing.Size(55, 15);
            this.labelX12.TabIndex = 2;
            this.labelX12.Text = "控制方式";
            this.labelX12.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX18
            // 
            this.labelX18.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX18.Location = new System.Drawing.Point(109, 177);
            this.labelX18.Name = "labelX18";
            this.labelX18.Size = new System.Drawing.Size(72, 13);
            this.labelX18.TabIndex = 2;
            this.labelX18.Text = "读卡器性质";
            this.labelX18.TextAlignment = System.Drawing.StringAlignment.Far;
            this.labelX18.Visible = false;
            // 
            // labelX11
            // 
            this.labelX11.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Location = new System.Drawing.Point(109, 3);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(55, 15);
            this.labelX11.TabIndex = 2;
            this.labelX11.Text = "门名称";
            this.labelX11.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tabItemDoor
            // 
            this.tabItemDoor.AttachedControl = this.tabControlPanel2;
            this.tabItemDoor.Name = "tabItemDoor";
            this.tabItemDoor.Text = "控制器门属性";
            // 
            // btnOkAndUpload
            // 
            this.btnOkAndUpload.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOkAndUpload.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOkAndUpload.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOkAndUpload.Location = new System.Drawing.Point(233, 392);
            this.btnOkAndUpload.Name = "btnOkAndUpload";
            this.btnOkAndUpload.Size = new System.Drawing.Size(99, 33);
            this.btnOkAndUpload.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOkAndUpload.TabIndex = 0;
            this.btnOkAndUpload.Text = "确定并上传";
            this.btnOkAndUpload.Click += new System.EventHandler(this.btnOkAndUpload_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(338, 392);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 33);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(128, 392);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(99, 33);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmAddOrModifyCtrlr
            // 
            this.AcceptButton = this.btnOkAndUpload;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(623, 437);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnOkAndUpload);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddOrModifyCtrlr";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加或修改控制器";
            this.Load += new System.EventHandler(this.FrmAddOrModifyCtrlr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iiPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipCtrlr)).EndInit();
            this.tabControlPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCtrlName;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCtrlrSn;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.Editors.IntegerInput iiPort;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDesc;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.ComboTree cboTreeArea;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItemBase;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItemDoor;
        private DevComponents.DotNetBar.ButtonX btnOkAndUpload;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.LabelX labelX13;
        private DevComponents.DotNetBar.LabelX labelX12;
        private DevComponents.DotNetBar.LabelX labelX18;
        private DevComponents.Editors.IpAddressInput ipCtrlr;
        private DoorNameAttriGroup doorNameAttriGroup;
        private DoorReaderAttriGroup doorReaderAttriGroup;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbCtrlrEnable;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbIsElevator;
    }
}