using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Li.Controls.ImageEditors.Covers
{
    public delegate void EndClipEventHandle(RectangleF radio);
    /// <summary>
    /// 剪切控制句柄
    /// </summary>
    public class ClipCoverController
    {
        public bool ClipState = false;
        private PicturePanel _picPanel = null;
        private RectangleF _clipBounds = RectangleF.Empty;
        private static Cursor _clipCursor = null;
        private SizeF _sizeF = SizeF.Empty;
        private ClipModel _clipModel = ClipModel.Auto;
        public event EndClipEventHandle EndClipEvent = null;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr LoadCursorFromFile(string fileName);
        public static Cursor getCursorFromResource(byte[] resource)
        {
            byte[] b = resource;
            FileStream fileStream = new FileStream("cursorData.dat", FileMode.Create);
            fileStream.Write(b, 0, b.Length);
            fileStream.Close();
            Cursor cur = new Cursor(LoadCursorFromFile("cursorData.dat"));
            return cur;
        }

        static ClipCoverController()
        {
           // MemoryStream ms = new MemoryStream(Properties.Resources.cursor_default);
            _clipCursor = getCursorFromResource(Properties.Resources.cursor_default);
            //ms.Dispose();
        }
        public void InitClip(PicturePanel picPanel)
        {
            FinitClip();
            _picPanel = picPanel;
            _picPanel.MouseMove+=_picPanel_MouseMove;
            _picPanel.Paint += _picPanel_Paint;
            _picPanel.MouseDown += _picPanel_MouseDown;
            _picPanel.MouseUp += _picPanel_MouseUp;
            _picPanel.MouseDoubleClick += _picPanel_MouseDoubleClick;
        }
        public void FinitClip()
        {
            if (_picPanel != null)
            {
                _picPanel.MouseMove -= _picPanel_MouseMove;
                _picPanel.Paint -= _picPanel_Paint;
                _picPanel.MouseDown -= _picPanel_MouseDown;
                _picPanel.MouseUp -= _picPanel_MouseUp;
                _picPanel.MouseDoubleClick -= _picPanel_MouseDoubleClick;
            }
        }

        private void _picPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (!ClipState)
            {
                return;
            }
            RectangleF bounds = GetBounds();
            float dw = 2;

            //内圈
            RectangleF rect = new RectangleF(bounds.Left + dw, bounds.Top + dw, bounds.Width - 2 * dw, bounds.Height - 2 * dw);
            Region r1 = new Region(rect);
            //边圈
            Region r2 = new Region(new RectangleF(0, 0, _picPanel.Width, _picPanel.Height));
            r2.Exclude(r1);
            r1.Dispose();
            using (Brush b = new SolidBrush(Color.FromArgb(80, Color.LightGray)))
            {
                e.Graphics.FillRegion(b, r2);
                using (Pen p = new Pen(Color.FromArgb(150, Color.Black), 2))
                {
                    e.Graphics.DrawRectangle(p, new Rectangle((int)bounds.X, (int)bounds.Y, (int)(bounds.Width - dw), (int)(bounds.Height - dw)));
                }
                using (Brush b1 = new SolidBrush(Color.DarkRed))
                {
                    Region r = GetBarRegion(bounds);
                    e.Graphics.FillRegion(b1, r);
                    r.Dispose();
                }

            }
            r2.Dispose();
        }
        private Point lastMousePoint = Point.Empty;
        private void _picPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!ClipState)
            {
                return;
            }
            if (e.Button== System.Windows.Forms.MouseButtons.Left)
            {
                lastMousePoint = _picPanel.PointToClient(Cursor.Position);
            }
        }
        private void _picPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!ClipState)
            {
                return;
            }
            if (e.Button==MouseButtons.None&&_picPanel.Cursor!=_clipCursor)
            {
                var p= _picPanel.PointToClient(Cursor.Position);
                RectangleF rect = new RectangleF(_clipBounds.Left + 4, _clipBounds.Top + 4, _clipBounds.Width - 8, _clipBounds.Height - 8);
                if (rect.Contains(p))
                {
                    _picPanel.Cursor = Cursors.SizeAll;
                }
                else
                {
                    _picPanel.Cursor = Cursors.Default;
                }
            }
            if (e.Button== MouseButtons.Left)
            {
                var p = _picPanel.PointToClient(Cursor.Position);
                if (_picPanel.Cursor==_clipCursor)
                {
                    int x = p.X < lastMousePoint.X ? p.X : lastMousePoint.X;
                    int y = p.Y < lastMousePoint.Y ? p.Y : lastMousePoint.Y;
                    int w = Math.Abs(p.X - lastMousePoint.X);
                    int h = Math.Abs(p.Y - lastMousePoint.Y);
                    if (_clipModel == ClipModel.FixedRatio)
                    {
                        h = (int)(_sizeF.Height / _sizeF.Width * w);
                    }
                    _clipBounds = new RectangleF(x, y, w, h);
                }
                else if (_picPanel.Cursor==Cursors.SizeAll)
                {
                    int dw = p.X - lastMousePoint.X;
                    int dh = p.Y - lastMousePoint.Y;
                    _clipBounds.X = _clipBounds.X + dw;
                    _clipBounds.Y = _clipBounds.Y + dh;
                    lastMousePoint = p;
                }
                _picPanel.Refresh();
            }
        }
        private void _picPanel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!ClipState)
            {
                return;
            }
            if (e.Button== MouseButtons.Left)
	        {
                _picPanel.Cursor = Cursors.Default;
	        }
            else if (e.Button== MouseButtons.Right)
            {
                CancelClip();
            }
           
        }
        private void _picPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!ClipState)
            {
                return;
            }
            RectangleF rect = EndClip();
            if (EndClipEvent!=null)
            {
                EndClipEvent(rect);
            }
        }
        private RectangleF GetBounds()
        {
            RectangleF bounds = _clipBounds;
            if (_clipBounds == RectangleF.Empty)
            {
                bounds = new RectangleF(0, 0, _picPanel.Width, _picPanel.Height);
            }
            return bounds;
        }
        private Region GetBarRegion(RectangleF rect)
        {
            if (rect.Width<25||rect.Height<25)
            {
                var temp = new Region();
                temp.MakeEmpty();
                return temp;
            }
            Region r = new Region(new RectangleF(rect.Left, rect.Top, 25, 25));
            Region r1 = new Region(new RectangleF(rect.Left + 5, rect.Top + 5, 25 - 5, 25 - 5));
            r.Exclude(r1);
            r1.Dispose();

            r1 = new Region(new RectangleF(rect.Left + rect.Width / 2 - 12.5f, rect.Top, 25, 5));
            r.Union(r1);
            r1.Dispose();

            r1 = new Region(new RectangleF(rect.Right - 25, rect.Top, 25, 25));
            var r2 = new Region(new RectangleF(rect.Right - 25, rect.Top + 5, 20, 20));
            r1.Exclude(r2);
            r2.Dispose();
            r.Union(r1);
            r1.Dispose();

            r1 = new Region(new RectangleF(rect.Right-5, rect.Top + rect.Height / 2 - 12.5f, 5, 25));
            r.Union(r1);
            r1.Dispose();

            r1 = new Region(new RectangleF(rect.Right - 25, rect.Bottom - 25, 25, 25));
            r2 = new Region(new RectangleF(rect.Right - 25, rect.Bottom - 25, 20, 20));
            r1.Exclude(r2);
            r2.Dispose();
            r.Union(r1);
            r1.Dispose();

            r1 = new Region(new RectangleF(rect.Left + rect.Width / 2 - 12.5f, rect.Bottom - 5, 25, 5));
            r.Union(r1);
            r1.Dispose();

            r1 = new Region(new RectangleF(rect.Left, rect.Bottom - 25, 25, 25));
            r2 = new Region(new RectangleF(rect.Left+5, rect.Bottom - 25, 20, 20));
            r1.Exclude(r2);
            r2.Dispose();
            r.Union(r1);
            r1.Dispose();

            r1 = new Region(new RectangleF(rect.Left, rect.Top + rect.Height / 2 - 12.5f, 5, 25));
            r.Union(r1);
            r1.Dispose();

            return r;
        }

        public void BeginClip(SizeF size,ClipModel clipModel= ClipModel.Auto)
        {
            if (_picPanel != null && _picPanel.Visible)
            {
                if (ClipState)
                {
                    return;
                }
                ClipState = true;
                _clipBounds = RectangleF.Empty;
                _picPanel.Cursor = _clipCursor;
                _sizeF = size;
                _clipModel = clipModel;
            }
        }
        public RectangleF EndClip()
        {
            try
            {
                if (_clipBounds == Rectangle.Empty)
                {
                    return RectangleF.Empty;
                }
                float x = _clipBounds.Left / _picPanel.Width;
                float y = _clipBounds.Top / _picPanel.Height;
                float w = _clipBounds.Width / _picPanel.Width;
                float h = _clipBounds.Height / _picPanel.Height;
                return new RectangleF(x, y, w, h);
            }
            finally
            {
                CancelClip();
            }
        }
        public void CancelClip()
        {
            ClipState = false;
            if (_picPanel!=null)
            {
                _picPanel.Invalidate();
            }
            _clipBounds = RectangleF.Empty;
            _picPanel.Cursor = Cursors.Default;
        }
    }
    public enum ClipModel
    {
        Auto,//自动
        FixedRatio,//固定比例
    }
}
