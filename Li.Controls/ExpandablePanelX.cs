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
        }
        public LinkLabel AddItem(string text, Image image = null,object tag=null, EventHandler click=null)
        {
            LinkLabel linkLable = new LinkLabel();
            linkLable.AutoSize = true;
            linkLable.BackColor = System.Drawing.Color.Transparent;
            linkLable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            linkLable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            linkLable.LinkArea = new System.Windows.Forms.LinkArea(7, text.Length);
            linkLable.LinkColor = System.Drawing.Color.DarkBlue;
            linkLable.Text = "       " + text;
            linkLable.Image = image;
            linkLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            linkLable.UseCompatibleTextRendering = true;
            linkLable.Tag = tag;
            this.panel.Controls.Add(linkLable);
            if (click!=null)
            {
                linkLable.Click += click;
            }
            UpdatePosition();
            linkLable.VisibleChanged += linkLable_VisibleChanged;
            return linkLable;
        }

        void linkLable_VisibleChanged(object sender, EventArgs e)
        {
            UpdatePosition();
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
            this.panel.AutoScroll = false;
            List<Control> ctrls = new List<Control>();
            foreach (Control item in this.panel.Controls)
            {
                if (item.Visible)
                {
                    ctrls.Add(item);
                }
            }
            for (int i = 0; i < ctrls.Count; i++)
            {
                Control ctrl = ctrls[i];
                ctrl.Location = new Point(51, (ctrl.Height + 10) * i + 20);
            }
            this.panel.AutoScroll = true;
        }

        private void panel_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate();
        }
    }
}
