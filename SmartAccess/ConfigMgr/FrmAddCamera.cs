using Li.Camera;
using SmartAccess.Common;
using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ConfigMgr
{
    public partial class FrmAddCamera : DevComponents.DotNetBar.Office2007Form
    {
        public Maticsoft.Model.SMT_CAMERA_INFO CAMERA = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmAddCamera));
        public FrmAddCamera()
        {
            InitializeComponent();
        }

        private void FrmAddCamera_Load(object sender, EventArgs e)
        {
            string[] models = Enum.GetNames(typeof(CameraModel));
            foreach (var item in models)
            {
                cbModel.Items.Add(item);
            }
            cbModel.SelectedIndex = 0;
            string[] captypes = Enum.GetNames(typeof(CapType));
            foreach (var item in captypes)
            {
                cbCapType.Items.Add(item);
            }
            cbCapType.SelectedIndex = 0;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbIp.Text.Trim() == "")
            {
                WinInfoHelper.ShowInfoWindow(this, "IP不能为空！");
                return;
            }

            CAMERA = new Maticsoft.Model.SMT_CAMERA_INFO();
            CAMERA.CAMERA_NAME = tbCameraName.Text.Trim();
            CAMERA.CAMERA_IP = tbIp.Text.Trim();
            CAMERA.CAMERA_PORT = iiPort.Value;
            CAMERA.CAMERA_USER = tbUser.Text.Trim();
            CAMERA.CAMERA_PWD = tbPwd.Text;
            CAMERA.CAMERA_MODEL = (string)cbModel.SelectedItem;
            CAMERA.CAMERA_CAP_TYPE = (string)cbCapType.SelectedItem;
            CAMERA.CAMERA_CAP_PORT = iiCapPort.Value;

            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_CAMERA_INFO cameraBll = new Maticsoft.BLL.SMT_CAMERA_INFO();
                    CAMERA.ID = -1;
                    CAMERA.ID = cameraBll.Add(CAMERA);
                    SmtLog.Info("配置", "配置摄像头：" + CAMERA.CAMERA_NAME + ",IP=" + CAMERA.CAMERA_IP);
                    this.BeginInvoke(new Action(() =>
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }));
                }
                catch (Exception ex)
                {
                    log.Error("添加摄像头失败：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "添加相机失败！" + ex.Message);
                }

            });
            waiting.Show(this);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnTestCap_Click(object sender, EventArgs e)
        {
            if (tbIp.Text.Trim() == "")
            {
                WinInfoHelper.ShowInfoWindow(this, "IP不能为空！");
                return;
            }
            if (picBox.Image!=null)
            {
                picBox.Image.Dispose();
                picBox.Image = null;
            }
            IPCamera ipcamera = new IPCamera();
            ipcamera.IP = tbIp.Text.Trim();
            ipcamera.Port = iiPort.Value;
            ipcamera.User = tbUser.Text.Trim();
            ipcamera.Password = tbPwd.Text;
            CameraModel model = CameraModel.None;
            Enum.TryParse<CameraModel>((string)cbModel.SelectedItem, out model);
            ipcamera.Model = model;
            ipcamera.CapturePort = iiCapPort.Value;
            CapType captype = CapType.Onvif;
            Enum.TryParse<CapType>((string)cbCapType.SelectedItem, out captype);
            ipcamera.CapType = captype;
            IIPCamera engine = ipcamera.GetEngine();
            if (engine != null)
            {
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        Image image = engine.CaptureImage();
                        if (image == null)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "截图失败！");
                            return;
                        }
                        this.Invoke(new Action(() =>
                        {
                            picBox.Image = image;
                        }));
                    }
                    catch (System.Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "截图失败！"+ex.Message);
                        log.Error("截图失败：", ex);
                    }
                });
                waiting.Show(this);
            }
        }
    }
}
