using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Li.Controls.ImageEditors.Covers
{
    /// <summary>
    /// 剪切控制句柄
    /// </summary>
    public class ClipCoverController
    {
        public bool ClipState = false;
        private PicturePanel _picPanel = null;
        private RectangleF _clipBounds = RectangleF.Empty;
        
        public void InitClip(PicturePanel picPanel)
        {
            FinitClip();
            _picPanel = picPanel;
            _picPanel.MouseMove+=_picPanel_MouseMove;
            _picPanel.Paint += _picPanel_Paint;
            _picPanel.MouseDown += _picPanel_MouseDown;
            _picPanel.MouseUp += _picPanel_MouseUp;
        }

        public void FinitClip()
        {
            if (_picPanel != null)
            {
                _picPanel.MouseMove -= _picPanel_MouseMove;
                _picPanel.Paint -= _picPanel_Paint;
                _picPanel.MouseDown -= _picPanel_MouseDown;
                _picPanel.MouseUp -= _picPanel_MouseUp;
            }
        }

        private void _picPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (!ClipState)
            {
                return;
            }
            RectangleF bounds = GetBounds();
            Region r1 = new Region(bounds);
            Region r2 = new Region(new RectangleF(0, 0, _picPanel.Width, _picPanel.Height));
            r2.Exclude(r1);
            r1.Dispose();
            using (Brush b = new SolidBrush(Color.FromArgb(200, Color.Gray)))
            {
                e.Graphics.FillRegion(b, r2);
                using (Pen p = new Pen(Color.FromArgb(150, Color.Black), 2))
                {
                    bounds.Inflate(-2, -2);
                    e.Graphics.DrawRectangle(p, new Rectangle((int)bounds.X, (int)bounds.Y, (int)bounds.Width, (int)bounds.Height));
                }
                using (Brush b1 = new SolidBrush(Color.Yellow))
                {
                    Region r = GetBarRegion(GetBounds());
                    e.Graphics.FillRegion(b1, r);
                }

            }
            r2.Dispose();
        }

        private void _picPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!ClipState)
            {
                return;
            }
            
        }
        private void _picPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!ClipState)
            {
                return;
            }

        }
        private void _picPanel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!ClipState)
            {
                return;
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
            Region r = new Region(new RectangleF(rect.Left, rect.Top, 25, 25));
            Region r1 = new Region(new RectangleF(rect.Left + 5, rect.Top + 5, 25 - 5, 25 - 5));
            r.Exclude(r1);
            r1.Dispose();

            return r;
        }

        public void BeginClip(RectangleF rect)
        {
            if (_picPanel != null && _picPanel.Visible)
            {
                if (ClipState)
                {
                    return;
                }
                ClipState = true;
                _clipBounds = rect;
            }
        }
        public RectangleF EndClip()
        {
            ClipState = false;
            if (_picPanel != null)
            {
                _picPanel.Invalidate();
            }
            RectangleF rect = _clipBounds;
            _clipBounds = RectangleF.Empty;
            return rect;
        }
        public void CancelClip()
        {
            ClipState = false;
            if (_picPanel!=null)
            {
                _picPanel.Invalidate();
            }
            _clipBounds = RectangleF.Empty;
        }
    }
}
