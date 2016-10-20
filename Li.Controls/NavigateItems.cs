using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Li.Controls
{
    public partial class NavigateItems : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExpandablePanelX ExpandedPanel
        {
            get
            {
                foreach (Control item in this.Controls)
                {
                    ExpandablePanelX expand = item as ExpandablePanelX;
                    if (expand!=null)
                    {
                        if (expand.Expanded)
                        {
                            return expand;
                        }
                    }
                }
                return null;
            }
            set
            {
                foreach (var item in this.Controls)
                {
                    ExpandablePanelX expand = item as ExpandablePanelX;
                    if (expand != null)
                    {
                        expand.Expanded = false;
                    }
                    
                    if (item==value)
                    {
                        expand.Expanded = true;
                    }
                }
            }
        }
        public List<ExpandablePanelX> Expands
        {
            get
            {
                List<ExpandablePanelX> list = new List<ExpandablePanelX>();
                foreach (Control item in this.Controls)
                {
                    ExpandablePanelX expand = item as ExpandablePanelX;
                    if (expand != null)
                    {
                        list.Insert(0,expand);
                    }
                }
                return list;
            }
        }
        public NavigateItems()
        {
            InitializeComponent();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateArray();
        }
        private void NavigateItems_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Dock = DockStyle.Top;
            ExpandablePanel expand = e.Control as ExpandablePanel;
            if (expand!=null)
            {
                expand.ExpandedChanging += expand_ExpandedChanging;
                expand.ExpandedChanged += expand_ExpandedChanged;
            }
        }

        void expand_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            if (!e.NewExpandedValue)
            {
                return;
            }
            ExpandablePanel expanel = (ExpandablePanel)sender;
            int visiblecount = 0;
            foreach (Control item in this.Controls)
            {
                if (item.Visible)
                {
                    visiblecount++;
                }
            }
            expanel.Height = this.Height - expanel.TitleHeight * (visiblecount - 1);
            expanel.Controls[0].Visible = true;
        }

        void expand_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!e.NewExpandedValue)
            {
                return;
            }
            foreach (Control item in this.Controls)
            {
                ExpandablePanel expanel = item as ExpandablePanel;
                if (expanel != null)
                {
                    if (expanel != sender)
                    {
                        expanel.Controls[0].Visible = false;
                        expanel.Expanded = false;
                    }
                }
            }
        }

        public ExpandablePanelX AddExpand(string title,Image image=null,object tag=null)
        {
            ExpandablePanelX panel = new ExpandablePanelX();
            panel.ClearItems();
            panel.TitleText = title;
            panel.TitleStyle.BackgroundImage = image;
            panel.TitleStyle.BackgroundImagePosition = eBackgroundImagePosition.CenterLeft;
            panel.Tag = tag;
            panel.Expanded = false;
            this.Controls.Add(panel);
            this.Controls.SetChildIndex(panel, 0);
            panel.VisibleChanged += panel_VisibleChanged;
           
            return panel;
        }

        void panel_VisibleChanged(object sender, EventArgs e)
        {
            UpdateArray();
        }
        public void ClearExpands()
        {
            this.Controls.Clear();
        }

        private void NavigateItems_Load(object sender, EventArgs e)
        {
            UpdateArray();
        }

        public void UpdateArray()
        {
            ExpandablePanel expand = this.ExpandedPanel;
            if (expand==null)
            {
                return;
            }

            int visiblecount = 0;
            foreach (Control item in this.Controls)
            {
                if (item.Visible)
                {
                    visiblecount++;
                }
                if (item!=expand)
                {
                    ExpandablePanel t = item as ExpandablePanel;
                    if (t!=null&&t.Expanded)
                    {
                        t.Expanded = false;
                    }
                }
            }
            expand.Height = this.Height - expand.TitleHeight * (visiblecount - 1);
            expand.Controls[0].Visible = true;
        }
    }
}
