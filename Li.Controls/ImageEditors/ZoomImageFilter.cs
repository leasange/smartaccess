using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Li.Controls.ImageEditors
{
    /// <summary>
    /// 缩放图片类
    /// </summary>
    public class ZoomImageFilter:IImageFilter
    {
        private string _name = "缩放";
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
        private SizeF _zoomToSize = SizeF.Empty;
        public System.Drawing.SizeF ZoomToSize 
        {
            get { return _zoomToSize; }
            set { _zoomToSize = value; }
        }
        public ZoomImageFilter(System.Drawing.SizeF zoomToSize)
        {
            _zoomToSize = zoomToSize;
        }

        public System.Drawing.Bitmap Proccess(System.Drawing.Bitmap inBitmap, bool disposeOrigin)
        {
            if (inBitmap == null)
            {
                return null;
            }
            Bitmap bitmap = null;
            if (_zoomToSize==SizeF.Empty)
            {
                bitmap = (Bitmap)inBitmap.Clone();
            }
            else
            {
                bitmap = new Bitmap(inBitmap, (int)_zoomToSize.Width, (int)_zoomToSize.Height);
            }
            if (disposeOrigin)
            {
                inBitmap.Dispose();
            }
            return bitmap;
        }
    }
}
