using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Li.Controls.ImageEditors;
using Li.Controls.ImageEditors.Covers;

namespace Li.Controls
{
    public partial class ImageEditor : UserControl
    {
        private EditorState _editorState = EditorState.None;
        private static int _staW = 3;
        private static int _staH = 4;
        private Bitmap _baseImage = null;
        //显示的原始图片
        public System.Drawing.Bitmap BaseImage
        {
            get { return _baseImage; }
            set
            {
                if (_baseImage != null)
                {
                    _baseImage.Dispose();
                    _baseImage = null;
                }
                _viewMultiple = 1;
                if (value == null)
                {
                    UpdateResultImage();
                }
                else if (_baseImage != value)
                {
                    _baseImage = (Bitmap)value.Clone();
                    UpdateResultImage();
                }
            }
        }
        private Bitmap _resultImage = null;//处理结果
        public System.Drawing.Bitmap ResultImage
        {
            get { return _resultImage; }
        }
        private double _viewMultiple = 1;//显示倍数
        public double ViewMultiple
        {
            get { return _viewMultiple; }
            set 
            {
                DoSetViewMultiple(value, true);
            }
        }
        private void DoSetViewMultiple(double val,bool updateBar)
        {
            if (pictureBox.ClipConver.ClipState)
            {
                return;
            }
            double min = 0.01d;
            double max = 10;
            int w = 100;
            int h = 200;
            if (_baseImage!=null)
            {
                w = _baseImage.Width;
                h = _baseImage.Height;
            }
            if (_resultImage!=null)
            {
                w = _resultImage.Width;
                h = _resultImage.Height;
            }
            min = 1d / w;
            max = 30;
            if (val <= min)
            {
                return;
            }
            else if (val > max)
            {
                return;
            }
            _viewMultiple = val;
            if (updateBar)
            {
                viewSizeSlider.Tag = "1";
                viewSizeSlider.Value = (int)(_viewMultiple / (10 - 0.01) * 100);
                viewSizeSlider.Tag = null;
            }
            UpdateViewSize();
        }
        public bool StateVisible
        {
            get
            {
                return this.plState.Visible;
            }
            set
            {
                this.plState.Visible = value;
            }
        }

        public bool ProccessBarVisible
        {
            get
            {
                return this.barProccess.Visible;
            }
            set
            {
                this.barProccess.Visible = value;
            }
        }

        private List<IImageFilter> _filters = new List<IImageFilter>();
        public ImageEditor()
        {
            InitializeComponent();
            pictureBox.MouseWheel += pictureBox_MouseWheel;
            pictureBox.ClipConver.EndClipEvent += ClipConver_EndClipEvent;
            tbClipWidth.Text = _staW.ToString();
            tbClipHeight.Text = _staH.ToString();
        }

        private void ClipConver_EndClipEvent(RectangleF radio)
        {
            ClipImageFilter clip = new ClipImageFilter(radio);
            AddFilter(clip);
        }

        private void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            this.OnMouseWheel(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            var p = plImageBack.PointToClient(Cursor.Position);
            if (!new Rectangle(0,0,plImageBack.Width,plImageBack.Height).Contains(p))
            {
                return;
            }
            viewSizeSlider.Tag = "1";
            if (e.Delta>0)
            {
                this.ViewMultiple = this.ViewMultiple * 1.1;
            }
            else
            {
                this.ViewMultiple = this.ViewMultiple / 1.1;
            }
            base.OnMouseWheel(e);
        }
        /// <summary>
        /// 更新显示大小
        /// </summary>
        public void UpdateViewSize()
        {
            if (_resultImage==null)
            {
                pictureBox.Visible = false;
                pictureBox.Size = new Size(plImageBack.Width - 5, plImageBack.Height - 5);
                lbImageState.Text = "宽:0 高:0 显示比例:" + (int)(_viewMultiple*100) + "%";
            }
            else
            {
                pictureBox.Visible = true;
                double dw = _resultImage.Width * _viewMultiple;
                double dh = _resultImage.Height * _viewMultiple;
                
                double x = plImageBack.Width / 2f - dw / 2f;
                double y = plImageBack.Height / 2f - dh / 2f;
                if (x>0&&y>0)
                {
                    pictureBox.SetBounds((int)x, (int)y, (int)dw, (int)dh);
                }
                else
                {
                    plImageBack.SuspendLayout();
                    plImageBack.AutoScroll = false;
                    if (x>0)
                    {
                        pictureBox.SetBounds((int)x, pictureBox.Top, (int)dw, (int)dh);
                    }
                    else if (y>0)
                    {
                         pictureBox.SetBounds(pictureBox.Left, (int)y, (int)dw, (int)dh);
                    }
                    else  pictureBox.SetBounds(0, 0, (int)dw, (int)dh);
                    plImageBack.AutoScroll = true;
                    plImageBack.ResumeLayout();
                }

                lbImageState.Text = "宽:" + _resultImage.Width + " 高:" + _resultImage.Height + " 显示比例:" + (int)(_viewMultiple * 100) + "%";
            }
        }
        /// <summary>
        /// 更新处理结果
        /// </summary>
        public void UpdateResultImage()
        {
            try
            {
                if (_resultImage != null)
                {
                    _resultImage.Dispose();
                    _resultImage = null;
                    pictureBox.Image = null;
                }
                if (_baseImage == null)
                {
                    return;
                }
                _resultImage = (Bitmap)_baseImage.Clone();
                foreach (var item in _filters)
                {
                    if (_resultImage == null)
                    {
                        break;
                    }
                    _resultImage = item.Proccess(_resultImage, true);
                }
            }
            finally
            {
                pictureBox.Image = _resultImage;
                UpdateViewSize();
            }
        }
        public void AddFilter(IImageFilter filter)
        {
            if (_baseImage==null)
            {
                return;
            }
            if (filter==null)
            {
                return;
            }
            if (_resultImage==null)
            {
                _resultImage = (Bitmap)_baseImage.Clone();
            }
            _resultImage = filter.Proccess(_resultImage, true);
            _filters.Add(filter);
            pictureBox.Image = _resultImage;
            UpdateViewSize();
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (_baseImage != null)
            {
                _baseImage.Dispose();
                _baseImage = null;
            }
            if (_resultImage != null)
            {
                pictureBox.Image = null;
                _resultImage.Dispose();
                _resultImage = null;
            }
            
            base.OnHandleDestroyed(e);
        }

        private void ImageEditor_Load(object sender, EventArgs e)
        {
            cbClipItem.SelectedIndex = 0;
            UpdateResultImage();
        }
        /// <summary>
        /// 执行剪切动作
        /// </summary>
        public void DoClipAction()
        {
            ClipModel model = ClipModel.Auto;
            SizeF size = SizeF.Empty;
            if (cbClipItem.SelectedIndex==1)
            {
                model = ClipModel.FixedRatio;
                int w = 3;
                if (!int.TryParse(tbClipWidth.Text, out w))
                {
                    w = 3;
                }
                if (w<=0)
                {
                    w = 3;
                }
                tbClipWidth.Text = w.ToString();
                int h = 4;
                if (!int.TryParse(tbClipHeight.Text,out h))
                {
                    h = 4;
                }
                if (h<=0)
                {
                    h = 4;
                }
                tbClipHeight.Text = h.ToString();
                pictureBox.ClipConver.BeginClip(new SizeF(w,h),model);
            }
            else
            {
                pictureBox.ClipConver.BeginClip(SizeF.Empty);
            }
            UpdateResultImage();
        }
        /// <summary>
        /// 执行打开动作
        /// </summary>
        public void DoOpenAction()
        {
            if (openImageDlg.ShowDialog(this)==DialogResult.OK)
            {
                try
                {
                    Bitmap bitmap = (Bitmap)Bitmap.FromFile(openImageDlg.FileName);
                    _filters.Clear();
                    this.BaseImage = (Bitmap)bitmap.Clone();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开图片异常！\r\n"+ex.Message);
                }

            }
        }

        private void biClip_Click(object sender, EventArgs e)
        {
            DoClipAction();
        }

        private void cbClipItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbClipWidth.Enabled = cbClipItem.SelectedIndex != 0;
            tbClipHeight.Enabled = cbClipItem.SelectedIndex != 0;
        }

        private void biOpen_Click(object sender, EventArgs e)
        {
            DoOpenAction();
        }

        private void ImageEditor_SizeChanged(object sender, EventArgs e)
        {
            UpdateViewSize();
        }

        private void viewSizeSlider_ValueChanged(object sender, EventArgs e)
        {
            if ( viewSizeSlider.Tag==null)
            {
                this.ViewMultiple = 0.01 + viewSizeSlider.Value / (double)viewSizeSlider.Maximum * (10 - 0.01);
            }
        }

        private void lbReset100_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ViewMultiple = 1;
        }

        private void llReset50_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ViewMultiple = 0.5;
        }

        private void llReset200_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ViewMultiple = 2;
        }
    }
}
