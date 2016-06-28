namespace Li.Controls
{
    partial class PageCtrl
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.plPage = new System.Windows.Forms.Panel();
            this.btnExportAll = new DevComponents.DotNetBar.ButtonX();
            this.btnExportCur = new DevComponents.DotNetBar.ButtonX();
            this.btnSetPage = new DevComponents.DotNetBar.ButtonX();
            this.btnLastPage = new DevComponents.DotNetBar.ButtonX();
            this.btnPrePage = new DevComponents.DotNetBar.ButtonX();
            this.btnNextPage = new DevComponents.DotNetBar.ButtonX();
            this.btnFirstPage = new DevComponents.DotNetBar.ButtonX();
            this.lbMsg = new DevComponents.DotNetBar.LabelX();
            this.tbPage = new Li.Controls.TextBoxEx();
            this.panelEx1.SuspendLayout();
            this.plPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.plPage);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(691, 32);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // plPage
            // 
            this.plPage.Controls.Add(this.tbPage);
            this.plPage.Controls.Add(this.btnExportAll);
            this.plPage.Controls.Add(this.btnExportCur);
            this.plPage.Controls.Add(this.btnSetPage);
            this.plPage.Controls.Add(this.btnLastPage);
            this.plPage.Controls.Add(this.btnPrePage);
            this.plPage.Controls.Add(this.btnNextPage);
            this.plPage.Controls.Add(this.btnFirstPage);
            this.plPage.Controls.Add(this.lbMsg);
            this.plPage.Location = new System.Drawing.Point(3, 0);
            this.plPage.Name = "plPage";
            this.plPage.Size = new System.Drawing.Size(685, 32);
            this.plPage.TabIndex = 1;
            // 
            // btnExportAll
            // 
            this.btnExportAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExportAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExportAll.Location = new System.Drawing.Point(578, 5);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(83, 23);
            this.btnExportAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExportAll.TabIndex = 1;
            this.btnExportAll.Text = "导出所有页";
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // btnExportCur
            // 
            this.btnExportCur.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExportCur.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExportCur.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExportCur.Location = new System.Drawing.Point(492, 5);
            this.btnExportCur.Name = "btnExportCur";
            this.btnExportCur.Size = new System.Drawing.Size(83, 23);
            this.btnExportCur.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExportCur.TabIndex = 1;
            this.btnExportCur.Text = "导出当前页";
            this.btnExportCur.Click += new System.EventHandler(this.btnExportCur_Click);
            // 
            // btnSetPage
            // 
            this.btnSetPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetPage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSetPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetPage.Location = new System.Drawing.Point(412, 5);
            this.btnSetPage.Name = "btnSetPage";
            this.btnSetPage.Size = new System.Drawing.Size(34, 23);
            this.btnSetPage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSetPage.TabIndex = 1;
            this.btnSetPage.Text = "跳转";
            this.btnSetPage.Click += new System.EventHandler(this.btnSetPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLastPage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLastPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLastPage.Location = new System.Drawing.Point(379, 5);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(27, 23);
            this.btnLastPage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLastPage.TabIndex = 1;
            this.btnLastPage.Text = ">|";
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnPrePage
            // 
            this.btnPrePage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrePage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPrePage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrePage.Location = new System.Drawing.Point(263, 5);
            this.btnPrePage.Name = "btnPrePage";
            this.btnPrePage.Size = new System.Drawing.Size(27, 23);
            this.btnPrePage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPrePage.TabIndex = 1;
            this.btnPrePage.Text = "<";
            this.btnPrePage.Click += new System.EventHandler(this.btnPrePage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNextPage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNextPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNextPage.Location = new System.Drawing.Point(349, 5);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(27, 23);
            this.btnNextPage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNextPage.TabIndex = 1;
            this.btnNextPage.Text = ">";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFirstPage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFirstPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFirstPage.Location = new System.Drawing.Point(234, 5);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(27, 23);
            this.btnFirstPage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFirstPage.TabIndex = 1;
            this.btnFirstPage.Text = "|<";
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // lbMsg
            // 
            // 
            // 
            // 
            this.lbMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbMsg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg.Location = new System.Drawing.Point(2, 8);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(227, 20);
            this.lbMsg.TabIndex = 0;
            this.lbMsg.Text = "共 0 条，每页 50 条，共 0 页";
            // 
            // tbPage
            // 
            // 
            // 
            // 
            this.tbPage.Border.Class = "TextBoxBorder";
            this.tbPage.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPage.Location = new System.Drawing.Point(296, 5);
            this.tbPage.Name = "tbPage";
            this.tbPage.NumberOnly = true;
            this.tbPage.Size = new System.Drawing.Size(47, 23);
            this.tbPage.TabIndex = 2;
            this.tbPage.Text = "1";
            this.tbPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PageCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx1);
            this.Name = "PageCtrl";
            this.Size = new System.Drawing.Size(691, 32);
            this.Resize += new System.EventHandler(this.PageCtrl_Resize);
            this.panelEx1.ResumeLayout(false);
            this.plPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX lbMsg;
        private System.Windows.Forms.Panel plPage;
        private Li.Controls.TextBoxEx tbPage;
        private DevComponents.DotNetBar.ButtonX btnLastPage;
        private DevComponents.DotNetBar.ButtonX btnPrePage;
        private DevComponents.DotNetBar.ButtonX btnNextPage;
        private DevComponents.DotNetBar.ButtonX btnFirstPage;
        private DevComponents.DotNetBar.ButtonX btnExportAll;
        private DevComponents.DotNetBar.ButtonX btnExportCur;
        private DevComponents.DotNetBar.ButtonX btnSetPage;
    }
}
