namespace TestAccessCtrler
{
    partial class FrmCardIssue
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbComPort = new System.Windows.Forms.ComboBox();
            this.btnOpenOrClose = new System.Windows.Forms.Button();
            this.btnReadNo = new System.Windows.Forms.Button();
            this.tbNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口";
            // 
            // cbComPort
            // 
            this.cbComPort.FormattingEnabled = true;
            this.cbComPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.cbComPort.Location = new System.Drawing.Point(47, 21);
            this.cbComPort.Name = "cbComPort";
            this.cbComPort.Size = new System.Drawing.Size(121, 20);
            this.cbComPort.TabIndex = 1;
            // 
            // btnOpenOrClose
            // 
            this.btnOpenOrClose.Location = new System.Drawing.Point(174, 21);
            this.btnOpenOrClose.Name = "btnOpenOrClose";
            this.btnOpenOrClose.Size = new System.Drawing.Size(75, 21);
            this.btnOpenOrClose.TabIndex = 2;
            this.btnOpenOrClose.Text = "打开";
            this.btnOpenOrClose.UseVisualStyleBackColor = true;
            this.btnOpenOrClose.Click += new System.EventHandler(this.btnOpenOrClose_Click);
            // 
            // btnReadNo
            // 
            this.btnReadNo.Location = new System.Drawing.Point(174, 71);
            this.btnReadNo.Name = "btnReadNo";
            this.btnReadNo.Size = new System.Drawing.Size(75, 23);
            this.btnReadNo.TabIndex = 3;
            this.btnReadNo.Text = "读取卡号";
            this.btnReadNo.UseVisualStyleBackColor = true;
            this.btnReadNo.Click += new System.EventHandler(this.btnReadNo_Click);
            // 
            // tbNo
            // 
            this.tbNo.Location = new System.Drawing.Point(47, 73);
            this.tbNo.Name = "tbNo";
            this.tbNo.Size = new System.Drawing.Size(121, 21);
            this.tbNo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "卡号";
            // 
            // FrmCardIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 261);
            this.Controls.Add(this.tbNo);
            this.Controls.Add(this.btnReadNo);
            this.Controls.Add(this.btnOpenOrClose);
            this.Controls.Add(this.cbComPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCardIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "发卡器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbComPort;
        private System.Windows.Forms.Button btnOpenOrClose;
        private System.Windows.Forms.Button btnReadNo;
        private System.Windows.Forms.TextBox tbNo;
        private System.Windows.Forms.Label label2;
    }
}