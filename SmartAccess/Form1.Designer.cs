namespace SmartAccess
{
    partial class Form1
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
            this.smtNavigate1 = new SmartAccess.SmtNavigate();
            this.SuspendLayout();
            // 
            // smtNavigate1
            // 
            this.smtNavigate1.Location = new System.Drawing.Point(71, 12);
            this.smtNavigate1.Name = "smtNavigate1";
            this.smtNavigate1.Size = new System.Drawing.Size(268, 407);
            this.smtNavigate1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 452);
            this.Controls.Add(this.smtNavigate1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private SmtNavigate smtNavigate1;

    }
}