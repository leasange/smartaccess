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
    public partial class PicView : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(PicView));
        private List<Image> _images = new List<Image>();
        private int _index = 0;
        public PicView()
        {
            InitializeComponent();
        }

        private void DisposeImages()
        {
            picBox.Image = null;
            foreach (var item in _images)
            {
                item.Dispose();
            }
            _images.Clear();
        }
        public void SetImages(params Image[] images)
        {
            DisposeImages();
           
            if (images != null && images.Length>0)
            {
                _images.AddRange(images);
            }
            lbiCount.Text = "共" + _images.Count + "张";
            _index = 0;
            UpdateImage();
        }

        public void SetImages(params string[] urlImages)
        {
            DisposeImages();
           
            _index = 0;
            foreach (var item in urlImages)
            {
                WebImageReader.ReadImageAsync(item, ImageCallBack);
            }
        }
        private void ImageCallBack(Image image, Exception ex)
        {
            if (image!=null)
            {
                _images.Add(image);
                this.Invoke(new Action(() =>
                    {
                        lbiCount.Text = "共" + _images.Count + "张";
                        UpdateImage();
                    }));
            }
            else
            {
                log.Error("加载图片失败：", ex);
            }
        }
        private void UpdateImage()
        {
            if (_index>=0&&_index<=_images.Count-1)
            {
                picBox.Image = _images[_index];
            }
            else
            {
                picBox.Image = null;
            }
            lbiCurrent.Text = (_index + 1).ToString();
        }

        private void btiSave_Click(object sender, EventArgs e)
        {
            if (picBox.Image == null)
            {
                return;
            }
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    string fileName = saveFileDialog.FileName;
                    Bitmap bitmap = new Bitmap(picBox.Image.Width, picBox.Image.Height);
                    Graphics g = Graphics.FromImage(bitmap);
                    g.DrawImage(picBox.Image, 0, 0, picBox.Image.Width, picBox.Image.Height);
                    g.Dispose();
                    bitmap.Save(fileName);
                    bitmap.Dispose();
                }
                catch (System.Exception ex)
                {
                    log.Error("保存失败：", ex);
                    MessageBox.Show("保存失败：" + ex.Message);
                }
            }
        }

        private void btiPre_Click(object sender, EventArgs e)
        {
            if (_images.Count>0)
            {
                _index--;
                if (_index<0)
                {
                    _index = _images.Count - 1;
                }
                UpdateImage();
            }
        }

        private void btiNext_Click(object sender, EventArgs e)
        {
            if (_images.Count > 0)
            {
                _index++;
                if (_index > _images.Count-1)
                {
                    _index = 0;
                }
                UpdateImage();
            }
        }

        private void biEdit_Click(object sender, EventArgs e)
        {
            if (picBox.Image == null)
            {
                return;
            }
            FrmImageEditor imageEditor = new FrmImageEditor();
            imageEditor.LoadImage((Bitmap)picBox.Image);
            imageEditor.ShowDialog(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
