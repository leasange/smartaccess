using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Li.Controls.ImageEditors
{
    public partial class PicturePanel : UserControl
    {
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
        }
    }
}
