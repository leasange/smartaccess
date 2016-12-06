namespace SmartAccess.ConfigMgr
{
    partial class AlarmConnectPort
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
            this.cbPortEnable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanelDoors = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cbDoor4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbDoor3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbDoor2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbDoor1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cbRelay = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbFire = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbInvalidCard = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbForceClose = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbForceAccess = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbUnClosed = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbEnbForcePwd = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.iFixedTime = new DevComponents.Editors.IntegerInput();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cbFixedTime = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbKeepState = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.plItems = new DevComponents.DotNetBar.PanelEx();
            this.groupPanelDoors.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iFixedTime)).BeginInit();
            this.groupPanel3.SuspendLayout();
            this.plItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPortEnable
            // 
            this.cbPortEnable.AutoSize = true;
            // 
            // 
            // 
            this.cbPortEnable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbPortEnable.Location = new System.Drawing.Point(17, 4);
            this.cbPortEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbPortEnable.Name = "cbPortEnable";
            this.cbPortEnable.Size = new System.Drawing.Size(51, 20);
            this.cbPortEnable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbPortEnable.TabIndex = 0;
            this.cbPortEnable.Text = "启动";
            this.cbPortEnable.CheckedChanged += new System.EventHandler(this.cbPortEnable_CheckedChanged);
            // 
            // groupPanelDoors
            // 
            this.groupPanelDoors.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanelDoors.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanelDoors.Controls.Add(this.cbDoor4);
            this.groupPanelDoors.Controls.Add(this.cbDoor3);
            this.groupPanelDoors.Controls.Add(this.cbDoor2);
            this.groupPanelDoors.Controls.Add(this.cbDoor1);
            this.groupPanelDoors.Location = new System.Drawing.Point(8, 11);
            this.groupPanelDoors.Name = "groupPanelDoors";
            this.groupPanelDoors.Size = new System.Drawing.Size(167, 135);
            // 
            // 
            // 
            this.groupPanelDoors.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanelDoors.Style.BackColorGradientAngle = 90;
            this.groupPanelDoors.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanelDoors.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelDoors.Style.BorderBottomWidth = 1;
            this.groupPanelDoors.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanelDoors.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelDoors.Style.BorderLeftWidth = 1;
            this.groupPanelDoors.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelDoors.Style.BorderRightWidth = 1;
            this.groupPanelDoors.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanelDoors.Style.BorderTopWidth = 1;
            this.groupPanelDoors.Style.CornerDiameter = 4;
            this.groupPanelDoors.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanelDoors.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanelDoors.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanelDoors.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanelDoors.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanelDoors.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanelDoors.TabIndex = 1;
            this.groupPanelDoors.Text = "触发源";
            // 
            // cbDoor4
            // 
            this.cbDoor4.AutoSize = true;
            this.cbDoor4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbDoor4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbDoor4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbDoor4.Location = new System.Drawing.Point(3, 82);
            this.cbDoor4.Name = "cbDoor4";
            this.cbDoor4.Size = new System.Drawing.Size(34, 20);
            this.cbDoor4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDoor4.TabIndex = 1;
            this.cbDoor4.Text = "4";
            this.cbDoor4.Visible = false;
            // 
            // cbDoor3
            // 
            this.cbDoor3.AutoSize = true;
            this.cbDoor3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbDoor3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbDoor3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbDoor3.Location = new System.Drawing.Point(3, 56);
            this.cbDoor3.Name = "cbDoor3";
            this.cbDoor3.Size = new System.Drawing.Size(34, 20);
            this.cbDoor3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDoor3.TabIndex = 0;
            this.cbDoor3.Text = "3";
            this.cbDoor3.Visible = false;
            // 
            // cbDoor2
            // 
            this.cbDoor2.AutoSize = true;
            this.cbDoor2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbDoor2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbDoor2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbDoor2.Location = new System.Drawing.Point(3, 30);
            this.cbDoor2.Name = "cbDoor2";
            this.cbDoor2.Size = new System.Drawing.Size(34, 20);
            this.cbDoor2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDoor2.TabIndex = 0;
            this.cbDoor2.Text = "2";
            this.cbDoor2.Visible = false;
            // 
            // cbDoor1
            // 
            this.cbDoor1.AutoSize = true;
            this.cbDoor1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbDoor1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbDoor1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbDoor1.Location = new System.Drawing.Point(3, 6);
            this.cbDoor1.Name = "cbDoor1";
            this.cbDoor1.Size = new System.Drawing.Size(34, 20);
            this.cbDoor1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDoor1.TabIndex = 0;
            this.cbDoor1.Text = "1";
            this.cbDoor1.Visible = false;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.cbRelay);
            this.groupPanel2.Controls.Add(this.cbFire);
            this.groupPanel2.Controls.Add(this.cbInvalidCard);
            this.groupPanel2.Controls.Add(this.cbForceClose);
            this.groupPanel2.Controls.Add(this.cbForceAccess);
            this.groupPanel2.Controls.Add(this.cbUnClosed);
            this.groupPanel2.Controls.Add(this.cbEnbForcePwd);
            this.groupPanel2.Location = new System.Drawing.Point(184, 11);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(238, 135);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "触发事件";
            // 
            // cbRelay
            // 
            this.cbRelay.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbRelay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbRelay.Location = new System.Drawing.Point(14, 82);
            this.cbRelay.Name = "cbRelay";
            this.cbRelay.Size = new System.Drawing.Size(138, 23);
            this.cbRelay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbRelay.TabIndex = 0;
            this.cbRelay.Text = "门继电器动作联动";
            // 
            // cbFire
            // 
            this.cbFire.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbFire.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbFire.Location = new System.Drawing.Point(135, 55);
            this.cbFire.Name = "cbFire";
            this.cbFire.Size = new System.Drawing.Size(100, 23);
            this.cbFire.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbFire.TabIndex = 0;
            this.cbFire.Text = "火警";
            // 
            // cbInvalidCard
            // 
            this.cbInvalidCard.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbInvalidCard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbInvalidCard.Location = new System.Drawing.Point(135, 28);
            this.cbInvalidCard.Name = "cbInvalidCard";
            this.cbInvalidCard.Size = new System.Drawing.Size(100, 23);
            this.cbInvalidCard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbInvalidCard.TabIndex = 0;
            this.cbInvalidCard.Text = "无效刷卡";
            // 
            // cbForceClose
            // 
            this.cbForceClose.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbForceClose.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbForceClose.Location = new System.Drawing.Point(135, 3);
            this.cbForceClose.Name = "cbForceClose";
            this.cbForceClose.Size = new System.Drawing.Size(100, 23);
            this.cbForceClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbForceClose.TabIndex = 0;
            this.cbForceClose.Text = "强行锁门";
            // 
            // cbForceAccess
            // 
            this.cbForceAccess.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbForceAccess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbForceAccess.Location = new System.Drawing.Point(14, 55);
            this.cbForceAccess.Name = "cbForceAccess";
            this.cbForceAccess.Size = new System.Drawing.Size(100, 23);
            this.cbForceAccess.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbForceAccess.TabIndex = 0;
            this.cbForceAccess.Text = "强行闯入";
            // 
            // cbUnClosed
            // 
            this.cbUnClosed.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbUnClosed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbUnClosed.Location = new System.Drawing.Point(14, 28);
            this.cbUnClosed.Name = "cbUnClosed";
            this.cbUnClosed.Size = new System.Drawing.Size(100, 23);
            this.cbUnClosed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbUnClosed.TabIndex = 0;
            this.cbUnClosed.Text = "门长时未关";
            // 
            // cbEnbForcePwd
            // 
            this.cbEnbForcePwd.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbEnbForcePwd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbEnbForcePwd.Location = new System.Drawing.Point(14, 3);
            this.cbEnbForcePwd.Name = "cbEnbForcePwd";
            this.cbEnbForcePwd.Size = new System.Drawing.Size(100, 23);
            this.cbEnbForcePwd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbEnbForcePwd.TabIndex = 0;
            this.cbEnbForcePwd.Text = "胁迫报警";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(428, 113);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "固定延时(秒)";
            // 
            // iFixedTime
            // 
            // 
            // 
            // 
            this.iFixedTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iFixedTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iFixedTime.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iFixedTime.Location = new System.Drawing.Point(509, 113);
            this.iFixedTime.MaxValue = 255;
            this.iFixedTime.MinValue = 0;
            this.iFixedTime.Name = "iFixedTime";
            this.iFixedTime.ShowUpDown = true;
            this.iFixedTime.Size = new System.Drawing.Size(56, 23);
            this.iFixedTime.TabIndex = 3;
            this.iFixedTime.Value = 10;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.cbFixedTime);
            this.groupPanel3.Controls.Add(this.cbKeepState);
            this.groupPanel3.Location = new System.Drawing.Point(428, 11);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(175, 96);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 1;
            this.groupPanel3.Text = "联动选项";
            // 
            // cbFixedTime
            // 
            this.cbFixedTime.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbFixedTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbFixedTime.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbFixedTime.Location = new System.Drawing.Point(3, 30);
            this.cbFixedTime.Name = "cbFixedTime";
            this.cbFixedTime.Size = new System.Drawing.Size(172, 23);
            this.cbFixedTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbFixedTime.TabIndex = 0;
            this.cbFixedTime.Text = "门动作后, 只输出固定延时";
            // 
            // cbKeepState
            // 
            this.cbKeepState.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbKeepState.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbKeepState.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbKeepState.Checked = true;
            this.cbKeepState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeepState.CheckValue = "Y";
            this.cbKeepState.Location = new System.Drawing.Point(3, 2);
            this.cbKeepState.Name = "cbKeepState";
            this.cbKeepState.Size = new System.Drawing.Size(134, 23);
            this.cbKeepState.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbKeepState.TabIndex = 0;
            this.cbKeepState.Text = "保持状态一致";
            // 
            // plItems
            // 
            this.plItems.CanvasColor = System.Drawing.SystemColors.Control;
            this.plItems.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.plItems.Controls.Add(this.groupPanel2);
            this.plItems.Controls.Add(this.iFixedTime);
            this.plItems.Controls.Add(this.labelX1);
            this.plItems.Controls.Add(this.groupPanel3);
            this.plItems.Controls.Add(this.groupPanelDoors);
            this.plItems.Enabled = false;
            this.plItems.Location = new System.Drawing.Point(17, 26);
            this.plItems.Name = "plItems";
            this.plItems.Size = new System.Drawing.Size(633, 148);
            this.plItems.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.plItems.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.plItems.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.plItems.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.plItems.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.plItems.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.plItems.Style.GradientAngle = 90;
            this.plItems.TabIndex = 4;
            this.plItems.Text = "panelEx1";
            // 
            // AlarmConnectPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plItems);
            this.Controls.Add(this.cbPortEnable);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AlarmConnectPort";
            this.Size = new System.Drawing.Size(662, 174);
            this.groupPanelDoors.ResumeLayout(false);
            this.groupPanelDoors.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iFixedTime)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.plItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CheckBoxX cbPortEnable;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanelDoors;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IntegerInput iFixedTime;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbKeepState;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbFixedTime;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbDoor3;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbDoor2;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbDoor1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbDoor4;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbEnbForcePwd;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbUnClosed;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbForceAccess;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbForceClose;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbInvalidCard;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbFire;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbRelay;
        private DevComponents.DotNetBar.PanelEx plItems;
    }
}
