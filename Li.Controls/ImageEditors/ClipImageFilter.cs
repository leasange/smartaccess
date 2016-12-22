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
            Bitmap bitmap = null;
            if (_ratioRect == RectangleF.Empty)
            {
                bitmap = (Bitmap)inBitmap.Clone();
            }
            else
            {
                float left = _ratioRect.Left * inBitmap.Width;
                float top = _ratioRect.Top * inBitmap.Height;
                float w = _ratioRect.Width * inBitmap.Width;
                float h = _ratioRect.Height * inBitmap.Height;
                RectangleF rect = new RectangleF(left, top, w, h);
                if (rect.X<0)
                {
                    rect.Width += rect.X;
                    rect.X = 0;
                }
                if (rect.Y<0)
                {
                    rect.Height += rect.Y;
                    rect.Y = 0;
                }
                if (rect.X >= inBitmap.Width || rect.Y >= inBitmap.Height)
                {
                    return (Bitmap)inBitmap.Clone();
                }
                if (rect.X+rect.Width > inBitmap.Width)
                {
                    rect.Width = inBitmap.Width - rect.X;
                }
                if (rect.Y+rect.Height>inBitmap.Height)
                {
                    rect.Height = inBitmap.Height - rect.Y;
                }
                if (rect.Width<=2||rect.Height<=2)
                {
                    return (Bitmap)inBitmap.Clone();
                }
                bitmap = inBitmap.Clone(rect, inBitmap.PixelFormat);
            }

            if (disposeOrigin)
            {
                inBitmap.Dispose();
            }
            return bitmap;
        }
    }
}
