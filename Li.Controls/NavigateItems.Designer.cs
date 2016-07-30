namespace Li.Controls
{
    partial class NavigateItems
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
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkStaffInfo = new System.Windows.Forms.LinkLabel();
            this.linkVerCodeInfo = new System.Windows.Forms.LinkLabel();
            this.linkDeptMgr = new System.Windows.Forms.LinkLabel();
            this.expandablePanelX1 = new Li.Controls.ExpandablePanelX();
            this.expandablePanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.AnimationTime = 120;
            this.expandablePanel1.AutoScroll = true;
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.panel2);
            this.expandablePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel1.ExpandOnTitleClick = true;
            this.expandablePanel1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(282, 162);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Center;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.Color = System.Drawing.Color.White;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 1;
            this.expandablePanel1.TitleHeight = 34;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.CenterLeft;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandablePanel1.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "证件信息管理";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.linkStaffInfo);
            this.panel2.Controls.Add(this.linkVerCodeInfo);
            this.panel2.Controls.Add(this.linkDeptMgr);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(282, 128);
            this.panel2.TabIndex = 2;
            // 
            // linkStaffInfo
            // 
            this.linkStaffInfo.BackColor = System.Drawing.Color.Transparent;
            this.linkStaffInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkStaffInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkStaffInfo.LinkArea = new System.Windows.Forms.LinkArea(6, 10);
            this.linkStaffInfo.LinkColor = System.Drawing.Color.DarkBlue;
            this.linkStaffInfo.Location = new System.Drawing.Point(51, 89);
            this.linkStaffInfo.Name = "linkStaffInfo";
            this.linkStaffInfo.Size = new System.Drawing.Size(148, 25);
            this.linkStaffInfo.TabIndex = 1;
            this.linkStaffInfo.TabStop = true;
            this.linkStaffInfo.Text = "      人员信息";
            this.linkStaffInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkStaffInfo.UseCompatibleTextRendering = true;
            // 
            // linkVerCodeInfo
            // 
            this.linkVerCodeInfo.BackColor = System.Drawing.Color.Transparent;
            this.linkVerCodeInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkVerCodeInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkVerCodeInfo.LinkArea = new System.Windows.Forms.LinkArea(6, 10);
            this.linkVerCodeInfo.LinkColor = System.Drawing.Color.DarkBlue;
            this.linkVerCodeInfo.Location = new System.Drawing.Point(51, 21);
            this.linkVerCodeInfo.Name = "linkVerCodeInfo";
            this.linkVerCodeInfo.Size = new System.Drawing.Size(148, 25);
            this.linkVerCodeInfo.TabIndex = 1;
            this.linkVerCodeInfo.TabStop = true;
            this.linkVerCodeInfo.Text = "      证件编码";
            this.linkVerCodeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkVerCodeInfo.UseCompatibleTextRendering = true;
            // 
            // linkDeptMgr
            // 
            this.linkDeptMgr.BackColor = System.Drawing.Color.Transparent;
            this.linkDeptMgr.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkDeptMgr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDeptMgr.LinkArea = new System.Windows.Forms.LinkArea(6, 10);
            this.linkDeptMgr.LinkColor = System.Drawing.Color.DarkBlue;
            this.linkDeptMgr.Location = new System.Drawing.Point(51, 55);
            this.linkDeptMgr.Name = "linkDeptMgr";
            this.linkDeptMgr.Size = new System.Drawing.Size(148, 25);
            this.linkDeptMgr.TabIndex = 1;
            this.linkDeptMgr.TabStop = true;
            this.linkDeptMgr.Text = "      部门管理";
            this.linkDeptMgr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDeptMgr.UseCompatibleTextRendering = true;
            // 
            // expandablePanelX1
            // 
            this.expandablePanelX1.AnimationTime = 120;
            this.expandablePanelX1.AutoScroll = true;
            this.expandablePanelX1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanelX1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanelX1.ExpandOnTitleClick = true;
            this.expandablePanelX1.Location = new System.Drawing.Point(0, 162);
            this.expandablePanelX1.Name = "expandablePanelX1";
            this.expandablePanelX1.Size = new System.Drawing.Size(282, 204);
            this.expandablePanelX1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelX1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanelX1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanelX1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanelX1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanelX1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanelX1.Style.GradientAngle = 90;
            this.expandablePanelX1.TabIndex = 2;
            this.expandablePanelX1.TitleHeight = 34;
            this.expandablePanelX1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanelX1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanelX1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanelX1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanelX1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanelX1.TitleStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expandablePanelX1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanelX1.TitleStyle.GradientAngle = 90;
            this.expandablePanelX1.TitleText = "Title Bar";
            // 
            // NavigateItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.expandablePanelX1);
            this.Controls.Add(this.expandablePanel1);
            this.Name = "NavigateItems";
            this.Size = new System.Drawing.Size(282, 448);
            this.expandablePanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkStaffInfo;
        private System.Windows.Forms.LinkLabel linkVerCodeInfo;
        private System.Windows.Forms.LinkLabel linkDeptMgr;
        private ExpandablePanelX expandablePanelX1;

    }
}
