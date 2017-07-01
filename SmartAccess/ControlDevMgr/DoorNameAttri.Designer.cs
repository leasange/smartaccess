namespace SmartAccess.ControlDevMgr
{
    partial class DoorNameAttri
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
            this.cbEnable = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.tbDoorName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lbNo = new DevComponents.DotNetBar.LabelX();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbType1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbType2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbType3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.iiTime = new DevComponents.Editors.IntegerInput();
            this.cbIsAllowVisitor = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iiTime)).BeginInit();
            this.SuspendLayout();
            // 
            // cbEnable
            // 
            // 
            // 
            // 
            this.cbEnable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbEnable.Checked = true;
            this.cbEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnable.CheckValue = "Y";
            this.cbEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbEnable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbEnable.Location = new System.Drawing.Point(173, 0);
            this.cbEnable.Name = "cbEnable";
            this.cbEnable.Size = new System.Drawing.Size(56, 25);
            this.cbEnable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbEnable.TabIndex = 8;
            this.cbEnable.Text = "启用";
            // 
            // tbDoorName
            // 
            // 
            // 
            // 
            this.tbDoorName.Border.Class = "TextBoxBorder";
            this.tbDoorName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDoorName.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbDoorName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDoorName.Location = new System.Drawing.Point(55, 0);
            this.tbDoorName.Name = "tbDoorName";
            this.tbDoorName.Size = new System.Drawing.Size(118, 23);
            this.tbDoorName.TabIndex = 7;
            // 
            // lbNo
            // 
            this.lbNo.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lbNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbNo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbNo.Location = new System.Drawing.Point(0, 0);
            this.lbNo.Name = "lbNo";
            this.lbNo.Size = new System.Drawing.Size(55, 25);
            this.lbNo.TabIndex = 6;
            this.lbNo.Text = "1号门：";
            this.lbNo.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.cbType1);
            this.panel7.Controls.Add(this.cbType2);
            this.panel7.Controls.Add(this.cbType3);
            this.panel7.Controls.Add(this.iiTime);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(229, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(279, 25);
            this.panel7.TabIndex = 9;
            // 
            // cbType1
            // 
            // 
            // 
            // 
            this.cbType1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbType1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbType1.Checked = true;
            this.cbType1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbType1.CheckValue = "Y";
            this.cbType1.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbType1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbType1.Location = new System.Drawing.Point(47, 0);
            this.cbType1.Name = "cbType1";
            this.cbType1.Size = new System.Drawing.Size(58, 25);
            this.cbType1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbType1.TabIndex = 5;
            this.cbType1.Text = "在线";
            // 
            // cbType2
            // 
            // 
            // 
            // 
            this.cbType2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbType2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbType2.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbType2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbType2.Location = new System.Drawing.Point(105, 0);
            this.cbType2.Name = "cbType2";
            this.cbType2.Size = new System.Drawing.Size(58, 25);
            this.cbType2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbType2.TabIndex = 4;
            this.cbType2.Text = "常开";
            // 
            // cbType3
            // 
            // 
            // 
            // 
            this.cbType3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbType3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbType3.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbType3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbType3.Location = new System.Drawing.Point(163, 0);
            this.cbType3.Name = "cbType3";
            this.cbType3.Size = new System.Drawing.Size(58, 25);
            this.cbType3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbType3.TabIndex = 3;
            this.cbType3.Text = "常闭";
            // 
            // iiTime
            // 
            // 
            // 
            // 
            this.iiTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iiTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iiTime.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iiTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.iiTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iiTime.Location = new System.Drawing.Point(221, 0);
            this.iiTime.MaxValue = 100;
            this.iiTime.MinValue = 1;
            this.iiTime.Name = "iiTime";
            this.iiTime.ShowUpDown = true;
            this.iiTime.Size = new System.Drawing.Size(58, 23);
            this.iiTime.TabIndex = 1;
            this.iiTime.Value = 3;
            // 
            // cbIsAllowVisitor
            // 
            // 
            // 
            // 
            this.cbIsAllowVisitor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbIsAllowVisitor.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbIsAllowVisitor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbIsAllowVisitor.Location = new System.Drawing.Point(508, 0);
            this.cbIsAllowVisitor.Name = "cbIsAllowVisitor";
            this.cbIsAllowVisitor.Size = new System.Drawing.Size(79, 25);
            this.cbIsAllowVisitor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbIsAllowVisitor.TabIndex = 10;
            this.cbIsAllowVisitor.Text = "访客接入";
            // 
            // DoorNameAttri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbIsAllowVisitor);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.cbEnable);
            this.Controls.Add(this.tbDoorName);
            this.Controls.Add(this.lbNo);
            this.Name = "DoorNameAttri";
            this.Size = new System.Drawing.Size(608, 25);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iiTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CheckBoxX cbEnable;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDoorName;
        private DevComponents.DotNetBar.LabelX lbNo;
        private System.Windows.Forms.Panel panel7;
        private DevComponents.Editors.IntegerInput iiTime;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbType1;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbType2;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbType3;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbIsAllowVisitor;
    }
}
