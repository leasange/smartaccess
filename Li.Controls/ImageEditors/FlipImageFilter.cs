using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Li.Controls.ImageEditors
{
    /// <summary>
    /// 翻转图片类
    /// </summary>
    public class FlipImageFilter:IImageFilter
    {
        private string _name = "翻转";
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
        private bool _isflipX = true;//是否水平翻转
        /// <summary>
        /// 是否水平翻转
        /// </summary>
        public bool IsflipX
        {
            get { return _isflipX; }
            set { _isflipX = value; }
        }
        /// <summary>
        /// 翻转
        /// </summary>
        /// <param name="isflipX">是否垂直翻转</param>
        public FlipImageFilter(bool isflipX)//度数
        {
            _isflipX = isflipX;
        }

        public System.Drawing.Bitmap Proccess(System.Drawing.Bitmap inBitmap, bool disposeOrigin)
        {
            if (inBitmap == null)
            {
                return null;
            }
            Bitmap bitmap = (Bitmap)inBitmap.Clone();
            if (_isflipX)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            }
            else
            {
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
            }
            if (disposeOrigin)
            {
                inBitmap.Dispose();
            }
            return bitmap;
        }

        /// <summary>
        /// 以逆时针为方向对图像进行旋转
        /// </summary>
        /// <param name="b">位图流</param>
        /// <param name="angle">旋转角度[0,360](前台给的)</param>
        /// <returns></returns>
        private static Bitmap Rotate(Bitmap b, float angle)
        {
            angle = angle % 360;
            //弧度转换
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));
            //目标位图
            Bitmap dsImage = new Bitmap(W, H);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //计算偏移量
            Point Offset = new Point((W - w) / 2, (H - h) / 2);
            //构造图像显示区域：让图像的中心与窗口的中心点一致
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);
            //恢复图像在水平和垂直方向的平移
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);
            //重至绘图的所有变换
            g.ResetTransform();
            g.Save();
            g.Dispose();
            //dsImage.Save("yuancd.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            return dsImage;
        }
    }
}
