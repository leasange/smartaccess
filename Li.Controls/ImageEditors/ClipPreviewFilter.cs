using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Li.Controls.ImageEditors
{
    /// <summary>
    /// 截图预览类
    /// </summary>
    public class ClipPreviewFilter:IImageFilter
    {
        private RectangleF _clipBounds = RectangleF.Empty;
        public RectangleF ClipBounds
        {
            get 
            {
                return _clipBounds;
            }
            set
            {
                _clipBounds = value;
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Drawing.Bitmap Proccess(System.Drawing.Bitmap inBitmap, bool disposeOrigin)
        {
            if (inBitmap==null)
            {
                return null;
            }
            Bitmap bitmap = (Bitmap)inBitmap.Clone();
            if (disposeOrigin)
            {
                inBitmap.Dispose();
            }
            if (_clipBounds== RectangleF.Empty)
            {
                _clipBounds = new RectangleF(0,0,bitmap.Width, bitmap.Height);
            }
            using (Graphics g=Graphics.FromImage(bitmap))
            {
                Region r1 = new Region(_clipBounds);
                Region r2 = new Region(new RectangleF(0, 0, bitmap.Width, bitmap.Height));
                r2.Exclude(r1);
                r1.Dispose();
                using (Brush b = new SolidBrush(Color.FromArgb(200, Color.Gray)))
                {
                    g.FillRegion(b, r2);
                    using (Pen p=new Pen(Color.FromArgb(230,Color.Black),2))
                    {
                        _clipBounds.Inflate(-2, -2);
                        g.DrawRectangle(p, new Rectangle((int)_clipBounds.X,(int)_clipBounds.Y,(int)_clipBounds.Width,(int)_clipBounds.Height));
                    }
                    using (Brush b1=new SolidBrush(Color.Black))
                    {
                        Region r = GetBarRegion();
                        g.FillRegion(b1, r);
                    }
                   
                }
                r2.Dispose();
            }
            return bitmap;
        }
        private Region GetBarRegion()
        {
            Region r = new Region(new RectangleF(_clipBounds.Left, _clipBounds.Top, 25, 25));
            Region r1 = new Region(new RectangleF(_clipBounds.Left + 5, _clipBounds.Top + 5, 25 - 5, 25 - 5));
            r.Exclude(r1);
            r1.Dispose();

            return r;
        }
    }
}
