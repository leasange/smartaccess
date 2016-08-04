namespace SmartAccess.ControlDevMgr
{
    partial class DoorReaderAttri
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
            this.lbNo = new DevComponents.DotNetBar.LabelX();
            this.cbIsEnter = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbIsAttend = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.SuspendLayout();
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
            this.lbNo.Size = new System.Drawing.Size(117, 26);
            this.lbNo.TabIndex = 6;
            this.lbNo.Text = "1号门进门 读卡器：";
            this.lbNo.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cbIsEnter
            // 
            // 
            // 
            // 
            this.cbIsEnter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbIsEnter.Checked = true;
            this.cbIsEnter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsEnter.CheckValue = "Y";
            this.cbIsEnter.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbIsEnter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbIsEnter.Location = new System.Drawing.Point(117, 0);
            this.cbIsEnter.Name = "cbIsEnter";
            this.cbIsEnter.Size = new System.Drawing.Size(48, 26);
            this.cbIsEnter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbIsEnter.TabIndex = 9;
            this.cbIsEnter.Text = "进门";
            // 
            // cbIsAttend
            // 
            // 
            // 
            // 
            this.cbIsAttend.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbIsAttend.Checked = true;
            this.cbIsAttend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsAttend.CheckValue = "Y";
            this.cbIsAttend.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbIsAttend.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbIsAttend.Location = new System.Drawing.Point(165, 0);
            this.cbIsAttend.Name = "cbIsAttend";
            this.cbIsAttend.Size = new System.Drawing.Size(70, 26);
            this.cbIsAttend.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbIsAttend.TabIndex = 10;
            this.cbIsAttend.Text = "作考勤";
            // 
            // DoorReaderAttri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbIsAttend);
            this.Controls.Add(this.cbIsEnter);
            this.Controls.Add(this.lbNo);
            this.Name = "DoorReaderAttri";
            this.Size = new System.Drawing.Size(297, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lbNo;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbIsEnter;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbIsAttend;
    }
}
