using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Li.Controls.ImageEditors.Covers;

namespace Li.Controls.ImageEditors
{
    public partial class PicturePanel : UserControl
    {
        private ClipCoverController _clipConver = new ClipCoverController();
        public ClipCoverController ClipConver
        {
            get { return _clipConver; }
        }
        public Image Image
        {
            get
            {
                return this.BackgroundImage;
            }
            set
            {
                this.BackgroundImage = value;
            }
        }
        public PicturePanel()
        {
            InitializeComponent();
            _clipConver.InitClip(this);
        }
    }
}
