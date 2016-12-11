using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Li.Controls.ImageEditors
{
    /// <summary>
    /// 剪切图片类
    /// </summary>
    public class ClipImageFilter:IImageFilter
    {
        private string _name = "剪切";
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        private RectangleF _ratioRect = RectangleF.Empty;
        public System.Drawing.RectangleF RatioRect
        {
            get { return _ratioRect; }
            set { _ratioRect = value; }
        }
        public ClipImageFilter(System.Drawing.RectangleF ratioRect)
        {
            _ratioRect = ratioRect;
        }

        public System.Drawing.Bitmap Proccess(System.Drawing.Bitmap inBitmap, bool disposeOrigin)
        {
            if (inBitmap == null)
            {
                return null;
            }
            try
            {
                if (_ratioRect == RectangleF.Empty)
                {
                    Bitmap bitmap = (Bitmap)inBitmap.Clone();
                    return bitmap;
                }
                float left = _ratioRect.Left * inBitmap.Width;
                float top = _ratioRect.Top * inBitmap.Height;
                float w = _ratioRect.Width * inBitmap.Width;
                float h = _ratioRect.Height * inBitmap.Height;
                RectangleF rect = new RectangleF(left, top, w, h);
                Bitmap bm = inBitmap.Clone(rect, inBitmap.PixelFormat);
                return bm;
            }
            finally
            {
                if (disposeOrigin)
                {
                    inBitmap.Dispose();
                }
            }
            
        }
    }
}
