namespace SmartAccess.ModelMgr
{
    partial class FrmVerModelEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVerModelEditor));
            this.designerControl = new FastReport.Design.StandardDesigner.DesignerControl();
            ((System.ComponentModel.ISupportInitialize)(this.designerControl)).BeginInit();
            this.SuspendLayout();
            // 
            // designerControl
            // 
            this.designerControl.AskSave = true;
            this.designerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designerControl.LayoutState = resources.GetString("designerControl.LayoutState");
            this.designerControl.Location = new System.Drawing.Point(0, 0);
            this.designerControl.Name = "designerControl";
            this.designerControl.Size = new System.Drawing.Size(829, 525);
            this.designerControl.TabIndex = 0;
            this.designerControl.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // FrmVerModelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 525);
            this.Controls.Add(this.designerControl);
            this.DoubleBuffered = true;
            this.Name = "FrmVerModelEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "证件模板新建/编辑";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmVerModelEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.designerControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastReport.Design.StandardDesigner.DesignerControl designerControl;

    }
}