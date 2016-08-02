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
            GetImage();
        }

        /// <summary>
        /// 获取视频驱动并开启视频
        /// </summary>
        private void OpenVideo()
        {
            try
            {
                _cameraChoice.UpdateDeviceList();
                if (_cameraChoice.Devices.Count==0)
                {
                    WinInfoHelper.ShowInfoWindow(this, "无摄像头！");
                    return;
                }
                CloseView();
                cameraControl.SetCamera(_cameraChoice.Devices[0].Mon, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        /// <summary>
        /// 截取图象
        /// </summary>
        private void GetImage()
        {
            try
            {
                if (pictureBox2.Image!=null)
                {
                    pictureBox2.Image.Dispose();
                    pictureBox2.Image = null;
                }
                pictureBox2.Image = cameraControl.SnapshotOutputImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 关闭视频流
        /// </summary>
        private void CloseView()
        {
            try
            {
                cameraControl.CloseCamera();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
 
    }
}
