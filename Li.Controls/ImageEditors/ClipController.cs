using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Li.Controls.ImageEditors
{
    public partial class ClipController : UserControl
    {
        private float _boundWidth = 2f;
        public ClipController()
        {
            InitializeComponent();
            UpdateRegion();
        }
        private void UpdateRegion()
        {
            if (this.Region != null)
            {
                this.Region.Dispose();
            }
            Region r1 = new Region(new RectangleF(0, 0, this.Width, this.Height));
            Region r2 = new Region(new RectangleF(_boundWidth, _boundWidth, this.Width - _boundWidth * 2, this.Height - _boundWidth * 2));
            Region r3 = new System.Drawing.Region(new RectangleF(this.Width / 2f - 3, this.Height / 2f - 3, 6, 6));
            r2.Exclude(r3);
            r3.Dispose();
            r1.Exclude(r2);
            this.Region = r1;
            r2.Dispose();

        }
        private void ClipController_SizeChanged(object sender, EventArgs e)
        {
            UpdateRegion();
        }
    }
}
