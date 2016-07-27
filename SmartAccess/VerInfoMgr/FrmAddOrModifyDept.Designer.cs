namespace SmartAccess.VerInfoMgr
{
    partial class FrmAddOrModifyDept
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
            this.tbDeptNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbDeptName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(25, 14);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(59, 33);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "部门编码";
            // 
            // tbDeptNo
            // 
            // 
            // 
            // 
            this.tbDeptNo.Border.Class = "TextBoxBorder";
            this.tbDeptNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDeptNo.Location = new System.Drawing.Point(90, 19);
            this.tbDeptNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDeptNo.MaxLength = 100;
            this.tbDeptNo.Name = "tbDeptNo";
            this.tbDeptNo.Size = new System.Drawing.Size(218, 23);
            this.tbDeptNo.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(25, 55);
            this.labelX2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(59, 33);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "部门名称";
            // 
            // tbDeptName
            // 
            // 
            // 
            // 
            this.tbDeptName.Border.Class = "TextBoxBorder";
            this.tbDeptName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDeptName.Location = new System.Drawing.Point(90, 60);
            this.tbDeptName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDeptName.MaxLength = 50;
            this.tbDeptName.Name = "tbDeptName";
            this.tbDeptName.Size = new System.Drawing.Size(218, 23);
            this.tbDeptName.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(90, 105);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 33);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(189, 105);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 33);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmAddOrModifyDept
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(334, 150);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbDeptName);
            this.Controls.Add(this.tbDeptNo);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddOrModifyDept";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加或者修改部门";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDeptNo;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDeptName;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}