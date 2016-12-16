namespace TestAccessCtrler
{
    partial class FrmUdpBroadcastTest
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
            this.btnSend = new System.Windows.Forms.Button();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.btnOpenServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(50, 38);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbMsg
            // 
            this.tbMsg.Location = new System.Drawing.Point(50, 88);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.Size = new System.Drawing.Size(270, 145);
            this.tbMsg.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "收到消息";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(50, 11);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(224, 21);
            this.tbServer.TabIndex = 3;
            this.tbServer.Text = "127.0.0.1:56010";
            // 
            // btnOpenServer
            // 
            this.btnOpenServer.Location = new System.Drawing.Point(280, 9);
            this.btnOpenServer.Name = "btnOpenServer";
            this.btnOpenServer.Size = new System.Drawing.Size(75, 23);
            this.btnOpenServer.TabIndex = 4;
            this.btnOpenServer.Text = "连接服务";
            this.btnOpenServer.UseVisualStyleBackColor = true;
            this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
            // 
            // FrmUdpBroadcastTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 279);
            this.Controls.Add(this.btnOpenServer);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMsg);
            this.Controls.Add(this.btnSend);
            this.Name = "FrmUdpBroadcastTest";
            this.Text = "FrmUdpBroadcastTest";
            this.Load += new System.EventHandler(this.FrmUdpBroadcastTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Button btnOpenServer;
    }
}