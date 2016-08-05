using Camera_NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;

namespace SmartAccess.VerInfoMgr
{
    public partial class FrmGetPicture : DevComponents.DotNetBar.Office2007Form
    {
        private CameraChoice _cameraChoice = new CameraChoice();
        private int _capIndex = 0;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmGetPicture));
        public bool HasChanged = false;
        public Image SelectImage
        {
            get
            {
                return picImage.Image;
            }
            set
            {
                if (picImage.Image!=null)
                {
                    picImage.Image.Dispose();
                    picImage.Image = null;
                }
                if (value!=null)
                {
                    picImage.Image = (Image)value.Clone();
                }
            }
        }
        public FrmGetPicture()
        {
            InitializeComponent();
        }

        private void biOpenCamera_Click(object sender, EventArgs e)
        {
            OpenVideo();
        }

        private void biCaptureVideo_Click(object sender, EventArgs e)
        {
            if (!cameraControl.CameraCreated)
            {
                WinInfoHelper.ShowInfoWindow(this, "请打开摄像头！");
                return;
            }
            _capIndex = 0;
            GetImage();
            _capIndex++;
            timerCapture.Start();
        }

        /// <summary>
        /// 获取视频驱动并开启视频
        /// </summary>
        private void OpenVideo()
        {
            try
            {
                if (cameraControl.CameraCreated)
                {
                    CloseView();
                    biOpenCamera.Text = "打开摄像头";
                    return;
                }
                if (cboCameraList.SelectedIndex<0)
                {
                    WinInfoHelper.ShowInfoWindow(this, "请选择摄像头！");
                    return;
                }
                if (_cameraChoice.Devices.Count==0)
                {
                    WinInfoHelper.ShowInfoWindow(this, "无摄像头！");
                    return;
                }
                CloseView();
                cameraControl.SetCamera(_cameraChoice.Devices[cboCameraList.SelectedIndex].Mon, null);
                biOpenCamera.Text = "关闭摄像头";
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "打开相机异常：" + ex.Message);
                log.Error("打开相机异常：", ex);
            }
        }


        /// <summary>
        /// 截取图象
        /// </summary>
        private void GetImage()
        {
            try
            {
                if (!cameraControl.CameraCreated)
                {
                    WinInfoHelper.ShowInfoWindow(this, "请先打开摄像头！");
                    return;
                }
                PictureBox picbox = null;
                switch (_capIndex)
                {
                    case 0:
                        picbox = picBox1;
                        break;
                    case 1:
                        picbox = picBox2;
                        break;
                    case 2:
                        picbox = picBox3;
                        break;
                    case 3:
                        picbox = picBox4;
                        break;
                    case 4:
                        picbox = picBox5;
                        break;
                    default:
                        picbox = picBox1;
                        break;
                }
                if (picbox.Image != null)
                {
                    picbox.Image.Dispose();
                    picbox.Image = null;
                }
                picbox.Image = cameraControl.SnapshotOutputImage();
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "拍照异常：" + ex.Message);
                log.Error("拍照异常：", ex);
            }
        }
        /// <summary>
        /// 关闭视频流
        /// </summary>
        private void CloseView()
        {
            try
            {
                if (cameraControl.CameraCreated)
                {
                    cameraControl.CloseCamera();
                }
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "关闭摄像头异常：" + ex.Message);
                log.Error("关闭摄像头异常：", ex);
            }
        }

        private void timerCapture_Tick(object sender, EventArgs e)
        {
            GetImage();
            if (_capIndex>=4)
            {
                timerCapture.Stop();
                _capIndex = 0;
                return;
            }
            _capIndex++;
        }

        private void picBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            if (box.Image != null)
            {
                if (picImage.Image!=null)
                {
                    picImage.Image.Dispose();
                    picImage.Image = null;
                }
                picImage.Image = (Image)box.Image.Clone();
                HasChanged = true;
            }
        }

        private void cameraControl_DoubleClick(object sender, EventArgs e)
        {
            GetImage();
            _capIndex++;
            if (_capIndex>=5)
            {
                _capIndex = 0;
            }
        }

        private void FrmGetPicture_Load(object sender, EventArgs e)
        {
            _cameraChoice.UpdateDeviceList();
            foreach (var item in _cameraChoice.Devices)
            {
                cboCameraList.Items.Add(item.Name);
            }
            if ( cboCameraList.Items.Count>0)
            {
                cboCameraList.SelectedIndex = 0;
            }
        }

        private void FrmGetPicture_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseView();
            if (picBox1.Image!=null)
            {
                picBox1.Image.Dispose();
                picBox1.Image = null;
            }
            if (picBox2.Image != null)
            {
                picBox2.Image.Dispose();
                picBox2.Image = null;
            }
            if (picBox3.Image != null)
            {
                picBox3.Image.Dispose();
                picBox3.Image = null;
            }
            if (picBox4.Image != null)
            {
                picBox4.Image.Dispose();
                picBox4.Image = null;
            }
            if (picBox5.Image != null)
            {
                picBox5.Image.Dispose();
                picBox5.Image = null;
            }
        }

        private void biSave_Click(object sender, EventArgs e)
        {
            if (picImage.Image==null)
            {
                WinInfoHelper.ShowInfoWindow(this, "未有选择图片可以保存！");
                return;
            }
            try
            {
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    picImage.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "保存异常！"+ex.Message);
                log.Error("保存图片异常：", ex);
                return;
            }

        }

        private void biOpenLocalPic_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this)== DialogResult.OK)
            {
                try
                {
                    Image image = Image.FromFile(openFileDialog.FileName);
                    if (picImage.Image!=null)
                    {
                        picImage.Image.Dispose();
                        picImage.Image = null;
                    }
                    picImage.Image = (Image)image.Clone();
                    HasChanged = true;
                    image.Dispose();
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "打开图片异常：" + ex.Message);
                    log.Error("打开图片异常：", ex);
                }

            }
        }

        private void biOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void biClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
 
    }
}
