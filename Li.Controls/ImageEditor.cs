using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Li.Controls
{
    public partial class ImageEditor : UserControl
    {
        private Bitmap _baseImage = null;
        //显示的原始图片
        public System.Drawing.Bitmap BaseImage
        {
            get { return _baseImage; }
            set { _baseImage = value; }
        }

        private double _viewRatio = 1;//显示比例

        public ImageEditor()
        {
            InitializeComponent();
        }
    }
}
