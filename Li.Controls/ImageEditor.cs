using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Li.Controls.ImageEditors;

namespace Li.Controls
{
    public partial class ImageEditor : UserControl
    {
        private EditorState _editorState = EditorState.None;
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
            if (val <= 0.01d)
            {
                return;
            }
            else if (val > 10)
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
            
        }

        private void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            this.OnMouseWheel(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            viewSizeSlider.Tag = "1";
            if (e.Delta>0)
            {
                this.ViewMultiple = this.ViewMultiple * 1.1;
            }
            else
            {
                this.ViewMultiple = this.ViewMultiple / 1.1;
            }
        }
        /// <summary>
        /// 更新显示大小
        /// </summary>
        public void UpdateViewSize()
        {
            if (_resultImage==null)
            {
                pictureBox.Size = new Size(plImageBack.Width - 5, plImageBack.Height - 5);
                lbImageState.Text = "宽:0 高:0 显示比例:" + (int)(_viewMultiple*100) + "%";
            }
            else
            {
                double dw = _resultImage.Width * _viewMultiple;
                double dh = _resultImage.Height * _viewMultiple;
                pictureBox.Size = new Size((int)dw, (int)dh);
                lbImageState.Text = "宽:" + _resultImage.Width + " 高:" + _resultImage.Height+ " 显示比例:" + (int)(_viewMultiple * 100) + "%";
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
    }
}
