using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace Li.Controls
{
    public partial class ExpandablePanelX : DevComponents.DotNetBar.ExpandablePanel
    {
        public ExpandablePanelX()
        {
            InitializeComponent();

            AddItem("测试1");
            AddItem("测试2");
            AddItem("测试3");
        }
        public LinkLabel AddItem(string text, Image image = null)
        {
            LinkLabel linkLable = new LinkLabel();
            linkLable.AutoSize = true;
            linkLable.BackColor = System.Drawing.Color.Transparent;
            linkLable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            linkLable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            linkLable.LinkArea = new System.Windows.Forms.LinkArea(6, text.Length);
            linkLable.LinkColor = System.Drawing.Color.DarkBlue;
           // linkLable.Location = new System.Drawing.Point(51, 89);
           // linkLable.Name = "linkStaffInfo";
            //linkLable.Size = new System.Drawing.Size(148, 25);
            //linkLable.TabIndex = 1;
            //linkLable.TabStop = true;
            linkLable.Text = "      " + text;
            linkLable.Image = image;
            linkLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            linkLable.UseCompatibleTextRendering = true;
            this.panel.Controls.Add(linkLable);
            UpdatePosition();
            return linkLable;
        }
        public void ClearItems()
        {
            this.panel.Controls.Clear();
        }
        public List<LinkLabel> GetItems()
        {
            List<LinkLabel> list = new List<LinkLabel>();
            foreach (var item in this.panel.Controls)
            {
                var ll = item as LinkLabel;
                if (ll!=null)
                {
                    list.Add(ll);
                }
            }
            return list;
        }
        private void UpdatePosition()
        {
            for (int i = 0; i < this.panel.Controls.Count; i++)
            {
                Control ctrl = (Control)this.panel.Controls[i];
                ctrl.Location = new Point(51, (ctrl.Height + 10) * i + 20);
            }
        }
    }
}
