namespace SmartAccess.ConfigMgr
{
    partial class AccessPasswordMgr
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
            this.superTabControl = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superPasswordMgr = new SmartAccess.ConfigMgr.SuperPasswordMgr();
            this.stiSuperPwd = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem4 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl)).BeginInit();
            this.superTabControl.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // superTabControl
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl.ControlBox.MenuBox.Name = "";
            this.superTabControl.ControlBox.Name = "";
            this.superTabControl.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl.ControlBox.MenuBox,
            this.superTabControl.ControlBox.CloseBox});
            this.superTabControl.Controls.Add(this.superTabControlPanel3);
            this.superTabControl.Controls.Add(this.superTabControlPanel1);
            this.superTabControl.Controls.Add(this.superTabControlPanel4);
            this.superTabControl.Controls.Add(this.superTabControlPanel2);
            this.superTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl.Location = new System.Drawing.Point(0, 0);
            this.superTabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.superTabControl.Name = "superTabControl";
            this.superTabControl.ReorderTabsEnabled = true;
            this.superTabControl.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl.SelectedTabIndex = 0;
            this.superTabControl.Size = new System.Drawing.Size(876, 486);
            this.superTabControl.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl.TabIndex = 0;
            this.superTabControl.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.superTabItem2,
            this.stiSuperPwd,
            this.superTabItem4});
            this.superTabControl.Text = "superTabControl1";
            this.superTabControl.TabIndexChanged += new System.EventHandler(this.superTabControl_TabIndexChanged);
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.superPasswordMgr);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(876, 458);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.stiSuperPwd;
            // 
            // superPasswordMgr
            // 
            this.superPasswordMgr.BackColor = System.Drawing.Color.Transparent;
            this.superPasswordMgr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superPasswordMgr.Location = new System.Drawing.Point(0, 0);
            this.superPasswordMgr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.superPasswordMgr.Name = "superPasswordMgr";
            this.superPasswordMgr.Size = new System.Drawing.Size(876, 458);
            this.superPasswordMgr.TabIndex = 0;
            // 
            // stiSuperPwd
            // 
            this.stiSuperPwd.AttachedControl = this.superTabControlPanel3;
            this.stiSuperPwd.GlobalItem = false;
            this.stiSuperPwd.Name = "stiSuperPwd";
            this.stiSuperPwd.Text = "超级通行密码";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(876, 458);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "刷卡+密码";
            this.superTabItem1.Visible = false;
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(876, 486);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.superTabItem4;
            // 
            // superTabItem4
            // 
            this.superTabItem4.AttachedControl = this.superTabControlPanel4;
            this.superTabItem4.GlobalItem = false;
            this.superTabItem4.Name = "superTabItem4";
            this.superTabItem4.Text = "卡号加密码开门";
            this.superTabItem4.Visible = false;
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(876, 486);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "用户密码";
            this.superTabItem2.Visible = false;
            // 
            // AccessPasswordMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.superTabControl);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AccessPasswordMgr";
            this.Size = new System.Drawing.Size(876, 486);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl)).EndInit();
            this.superTabControl.ResumeLayout(false);
            this.superTabControlPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl superTabControl;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem stiSuperPwd;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private DevComponents.DotNetBar.SuperTabItem superTabItem4;
        private SuperPasswordMgr superPasswordMgr;
    }
}
