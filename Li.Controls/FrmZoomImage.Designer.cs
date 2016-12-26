namespace Li.Controls
{
    partial class FrmZoomImage
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.gpGroup = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.iiHeight = new DevComponents.Editors.IntegerInput();
            this.iiWidth = new DevComponents.Editors.IntegerInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbFixedRatio = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.gpGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iiHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iiWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(17, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(41, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "宽度";
            // 
            // gpGroup
            // 
            this.gpGroup.CanvasColor = System.Drawing.SystemColors.Control;
            this.gpGroup.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpGroup.Controls.Add(this.iiHeight);
            this.gpGroup.Controls.Add(this.iiWidth);
            this.gpGroup.Controls.Add(this.cbFixedRatio);
            this.gpGroup.Controls.Add(this.labelX2);
            this.gpGroup.Controls.Add(this.labelX4);
            this.gpGroup.Controls.Add(this.labelX3);
            this.gpGroup.Controls.Add(this.labelX1);
            this.gpGroup.DrawTitleBox = false;
            this.gpGroup.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpGroup.Location = new System.Drawing.Point(12, 12);
            this.gpGroup.Name = "gpGroup";
            this.gpGroup.Size = new System.Drawing.Size(270, 120);
            // 
            // 
            // 
            this.gpGroup.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpGroup.Style.BackColorGradientAngle = 90;
            this.gpGroup.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpGroup.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpGroup.Style.BorderBottomWidth = 1;
            this.gpGroup.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpGroup.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpGroup.Style.BorderLeftWidth = 1;
            this.gpGroup.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpGroup.Style.BorderRightWidth = 1;
            this.gpGroup.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpGroup.Style.BorderTopWidth = 1;
            this.gpGroup.Style.CornerDiameter = 4;
            this.gpGroup.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpGroup.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gpGroup.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpGroup.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.gpGroup.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gpGroup.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpGroup.TabIndex = 1;
            this.gpGroup.Text = "原始图片大小:";
            // 
            // iiHeight
            // 
            // 
            // 
            // 
            this.iiHeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iiHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iiHeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iiHeight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iiHeight.Location = new System.Drawing.Point(64, 30);
            this.iiHeight.MaxValue = 100000;
            this.iiHeight.MinValue = 1;
            this.iiHeight.Name = "iiHeight";
            this.iiHeight.ShowUpDown = true;
            this.iiHeight.Size = new System.Drawing.Size(125, 23);
            this.iiHeight.TabIndex = 1;
            this.iiHeight.Value = 1;
            this.iiHeight.ValueChanged += new System.EventHandler(this.iiHeight_ValueChanged);
            // 
            // iiWidth
            // 
            // 
            // 
            // 
            this.iiWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iiWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iiWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iiWidth.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.iiWidth.Location = new System.Drawing.Point(64, 3);
            this.iiWidth.MaxValue = 100000;
            this.iiWidth.MinValue = 1;
            this.iiWidth.Name = "iiWidth";
            this.iiWidth.ShowUpDown = true;
            this.iiWidth.Size = new System.Drawing.Size(125, 23);
            this.iiWidth.TabIndex = 0;
            this.iiWidth.Value = 1;
            this.iiWidth.ValueChanged += new System.EventHandler(this.iiWidth_ValueChanged);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(17, 32);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(41, 23);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "高度";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(195, 30);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(41, 23);
            this.labelX4.TabIndex = 0;
            this.labelX4.Text = "像素";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(195, 3);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(41, 23);
            this.labelX3.TabIndex = 0;
            this.labelX3.Text = "像素";
            // 
            // cbFixedRatio
            // 
            this.cbFixedRatio.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cbFixedRatio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbFixedRatio.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbFixedRatio.Location = new System.Drawing.Point(64, 67);
            this.cbFixedRatio.Name = "cbFixedRatio";
            this.cbFixedRatio.Size = new System.Drawing.Size(100, 23);
            this.cbFixedRatio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbFixedRatio.TabIndex = 2;
            this.cbFixedRatio.Text = "约束比例";
            this.cbFixedRatio.CheckedChanged += new System.EventHandler(this.cbFixedRatio_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(59, 148);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(156, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            // 
            // FrmZoomImage
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(292, 183);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gpGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmZoomImage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "缩放图片";
            this.Load += new System.EventHandler(this.FrmZoomImage_Load);
            this.gpGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iiHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iiWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.GroupPanel gpGroup;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.Editors.IntegerInput iiHeight;
        private DevComponents.Editors.IntegerInput iiWidth;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbFixedRatio;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}