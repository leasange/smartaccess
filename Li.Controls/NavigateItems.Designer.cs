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
            this.expandablePanelX1 = new Li.Controls.ExpandablePanelX();
            this.SuspendLayout();
            // 
            // expandablePanelX1
            // 
            this.expandablePanelX1.AnimationTime = 120;
            this.expandablePanelX1.AutoScroll = true;
            this.expandablePanelX1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanelX1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanelX1.ExpandOnTitleClick = true;
            this.expandablePanelX1.Location = new System.Drawing.Point(0, 0);
            this.expandablePanelX1.Name = "expandablePanelX1";
            this.expandablePanelX1.Size = new System.Drawing.Size(282, 171);
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
            this.expandablePanelX1.TitleStyle.BackgroundImage = global::Li.Controls.Properties.Resources.部门管理;
            this.expandablePanelX1.TitleStyle.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.CenterLeft;
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
            this.DoubleBuffered = true;
            this.Name = "NavigateItems";
            this.Size = new System.Drawing.Size(282, 448);
            this.Load += new System.EventHandler(this.NavigateItems_Load);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.NavigateItems_ControlAdded);
            this.ResumeLayout(false);

        }

        #endregion

        private ExpandablePanelX expandablePanelX1;

    }
}
