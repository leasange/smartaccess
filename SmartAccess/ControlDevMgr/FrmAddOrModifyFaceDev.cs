using Li.Access.Core.FaceDevice;
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

namespace SmartAccess.ControlDevMgr
{
    public partial class FrmAddOrModifyFaceDev : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmAddOrModifyFaceDev));
        private Maticsoft.Model.SMT_FACERECG_DEVICE _dev;
        public Maticsoft.Model.SMT_FACERECG_DEVICE Device
        {
            get { return _dev; }
            set { _dev = value; }
        }
        public FrmAddOrModifyFaceDev()
        {
            InitializeComponent();
        }

        public FrmAddOrModifyFaceDev(Maticsoft.Model.SMT_FACERECG_DEVICE dev)
        {
            InitializeComponent();
            this._dev = dev;
            if (this._dev != null)
            {
                this.Text = "修改人脸识别设备";
            }
            else
            {
                this.Text = "添加人脸识别设备";
            }
        }

        private void FrmAddOrModifyFaceDev_Load(object sender, EventArgs e)
        {
            DoLoadDev();
            DoLoadArea();
        }

        private void DoLoadDev()
        {
            if (_dev != null)
            {
                tbName.Text = _dev.FACEDEV_NAME;
                cbIsEnable.Checked = _dev.FACEDEV_IS_ENABLE;
                tbDevSn.Text = _dev.FACEDEV_SN;
                ipDevIp.Value = _dev.FACEDEV_IP;
                iiDevCtrlPort.Value = _dev.FACEDEV_CTRL_PORT;
                iiDevHeartPort.Value = _dev.FACEDEV_HEART_PORT;
                iiDbPort.Value = _dev.FACEDEV_DB_PORT;
                tbDbName.Text = _dev.FACEDEV_DB_NAME;
                tbDbUserName.Text = _dev.FACEDEV_DB_USER;
                tbDbPassword.Text = _dev.FACEDEV_DB_PWD;
                cbVideoCount1.Checked = _dev.FVIDEO_RTSP_COUNT == 1;
                cbVideoCount3.Checked = !cbVideoCount1.Checked;
                tbRtsp1.Text = _dev.FVIDEO_RTSP;
                tbRtsp2.Text = _dev.FVIDEO_RTSP2;
                tbRtsp3.Text = _dev.FVIDEO_RTSP3;
                diFaceLevel.Value = _dev.FVIDEO_FACE_LEVEL == null ? 0.8 : (double)(decimal)_dev.FVIDEO_FACE_LEVEL;
                diRIO_X.Value = _dev.FVIDEO_RIO_X == null ? 0 : (double)(decimal)_dev.FVIDEO_RIO_X;
                diRIO_Y.Value = _dev.FVIDEO_RIO_Y == null ? 0 : (double)(decimal)_dev.FVIDEO_RIO_Y;
                diRIO_W.Value = _dev.FVIDEO_RIO_W == null ? 1 : (double)(decimal)_dev.FVIDEO_RIO_W;
                diRIO_H.Value = _dev.FVIDEO_RIO_H == null ? 1 : (double)(decimal)_dev.FVIDEO_RIO_H;
                cbModelSingle.Checked = _dev.FVIDEO_SINGLE == "Y" ? true : false;
                cbModelMulti.Checked = !cbModelSingle.Checked;
                tbDevTitle1.Text = _dev.FVIDEO_TITLE1;
                tbDevTitle2.Text = _dev.FVIDEO_TITLE2;
            }
        }

        private void DoLoadArea()
        {
            CtrlWaiting ctrlWaiting = new CtrlWaiting(() =>
            {
                var areas = AreaDataHelper.GetAreas();
                if (areas.Count > 0)
                {
                    this.Invoke(new Action(() =>
                    {
                        var nodes = AreaDataHelper.ToTree(areas);
                        nodes.Insert(0, new DevComponents.AdvTree.Node("--无--"));
                        cboTreeArea.Nodes.AddRange(nodes.ToArray());
                        foreach (var item in nodes)
                        {
                            item.Expand();
                        }
                        if (_dev != null  && _dev.AREA_ID >= 0)
                        {
                            DevComponents.AdvTree.Node node = FindNode((decimal)_dev.AREA_ID);
                            if (node != null)
                            {
                                cboTreeArea.SelectedNode = node;
                            }
                        }
                    }));
                }
            });
            ctrlWaiting.Show(this, 300);
        }
        public DevComponents.AdvTree.Node FindNode(decimal id)
        {
            return DoFindNode(cboTreeArea.Nodes, id);
        }
        private DevComponents.AdvTree.Node DoFindNode(DevComponents.AdvTree.NodeCollection nodes, decimal id)
        {
            foreach (DevComponents.AdvTree.Node item in nodes)
            {
                var area = item.Tag as Maticsoft.Model.SMT_CONTROLLER_ZONE;
                if (area != null && area.ID == id)
                {
                    return item;
                }
                else
                {
                    var nn = DoFindNode(item.Nodes, id);
                    if (nn != null)
                    {
                        return nn;
                    }
                }
            }
            return null;
        }


        private void cbVideoCount1_CheckedChanged(object sender, EventArgs e)
        {
            tbRtsp2.ReadOnly = cbVideoCount1.Checked;
            tbRtsp3.ReadOnly = cbVideoCount1.Checked;
        }
        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(ipDevIp.Value))
            {
                WinInfoHelper.ShowInfoWindow(this, "人员设备IP地址不能为空！");
                ipDevIp.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbDbName.Text))
            {
                WinInfoHelper.ShowInfoWindow(this, "数据库名称不能为空！");
                tbDbName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbDbUserName.Text))
            {
                WinInfoHelper.ShowInfoWindow(this, "数据库用户名不能为空！");
                tbDbUserName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(tbDbPassword.Text))
            {
                WinInfoHelper.ShowInfoWindow(this, "数据库密码不能为空！");
                tbDbPassword.Focus();
                return false;
            }
            return true;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Save(false);
        }

        private void Save(bool isupload)
        {
            if (!CheckInput())
            {
                return;
            }
            try
            {
                Maticsoft.Model.SMT_FACERECG_DEVICE devInfo = new Maticsoft.Model.SMT_FACERECG_DEVICE();
                if (_dev != null)
                {
                    devInfo.ID = _dev.ID;
                }
                else
                {
                    devInfo.ID = -1;
                }
                if (string.IsNullOrWhiteSpace(tbName.Text))
                {
                    devInfo.FACEDEV_NAME = ipDevIp.Value;
                }
                else
                {
                    devInfo.FACEDEV_NAME = tbName.Text;
                }

                devInfo.FACEDEV_IS_ENABLE = cbIsEnable.Checked;
                devInfo.FACEDEV_SN = tbDevSn.Text;
                devInfo.FACEDEV_IP = ipDevIp.Value;
                devInfo.FACEDEV_CTRL_PORT = iiDevCtrlPort.Value;
                devInfo.FACEDEV_HEART_PORT = iiDevHeartPort.Value;
                devInfo.FACEDEV_DB_PORT = iiDbPort.Value;
                devInfo.FACEDEV_DB_NAME = tbDbName.Text;
                devInfo.FACEDEV_DB_USER = tbDbUserName.Text;
                devInfo.FACEDEV_DB_PWD = tbDbPassword.Text;
                devInfo.FVIDEO_RTSP_COUNT = cbVideoCount1.Checked ? 1 : 3;
                devInfo.FVIDEO_RTSP = tbRtsp1.Text;
                devInfo.FVIDEO_RTSP2 = tbRtsp2.Text;
                devInfo.FVIDEO_RTSP3 = tbRtsp3.Text;
                devInfo.FVIDEO_FACE_LEVEL = (decimal)diFaceLevel.Value;
                devInfo.FVIDEO_RIO_X = (decimal)diRIO_X.Value;
                devInfo.FVIDEO_RIO_Y = (decimal)diRIO_Y.Value;
                devInfo.FVIDEO_RIO_W = (decimal)diRIO_W.Value;
                devInfo.FVIDEO_RIO_H = (decimal)diRIO_H.Value;
                devInfo.FVIDEO_SINGLE = cbModelSingle.Checked ? "Y" : "N";
                devInfo.FVIDEO_TITLE1 = tbDevTitle1.Text;
                devInfo.FVIDEO_TITLE2 = tbDevTitle2.Text;
                devInfo.AREA_ID = -1;
                if (cboTreeArea.SelectedNode != null && cboTreeArea.SelectedNode.Tag is Maticsoft.Model.SMT_CONTROLLER_ZONE)
                {
                    var area = cboTreeArea.SelectedNode.Tag as Maticsoft.Model.SMT_CONTROLLER_ZONE;
                    devInfo.AREA_ID = area.ID;
                    devInfo.AREA_NAME = area.ZONE_NAME;
                }

                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        Maticsoft.BLL.SMT_FACERECG_DEVICE bllDev = new Maticsoft.BLL.SMT_FACERECG_DEVICE();
                        if (devInfo.ID == -1)
                        {
                            devInfo.ID = bllDev.Add(devInfo);
                        }
                        else
                        {
                            bllDev.Update(devInfo);
                        }
                        _dev = devInfo;
                        if (isupload)
                        {
                            try
                            {
                                using(var faceRecg = FaceRecgHelper.ToFaceController(devInfo))
                                {
                                    var video = FaceRecgHelper.ToFaceVideo(devInfo);
                                    bool ret = faceRecg.SetVideo(video);
                                    if (!ret)
                                    {
                                        WinInfoHelper.ShowInfoWindow(null, "上传视频设置失败！");
                                    }
                                    else if (!devInfo.FACEDEV_IS_ENABLE)
                                    {
                                        faceRecg.ClearFaces();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                WinInfoHelper.ShowInfoWindow(null, "上传视频设置失败:" + ex.Message);
                            }
                        }

                        WinInfoHelper.ShowInfoWindow(null, "保存成功。");

                        this.BeginInvoke(new Action(() =>
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }));
                    }
                    catch (Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "保存异常：" + ex.Message);
                        log.Error("保存异常：" + ex.Message, ex);
                    }

                });
                waiting.Show(this);
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "保存异常：" + ex.Message);
                log.Error("保存异常：" + ex.Message, ex);
            }
        }

        private void btnReadVideoConfig_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    using (BSTFaceRecg bstRecg = new BSTFaceRecg())
                    {
                        bstRecg.InitConfig(ipDevIp.Value, iiDevCtrlPort.Value, iiDevHeartPort.Value, iiDbPort.Value, tbDbName.Text, tbDbUserName.Text, tbDbPassword.Text);
                        var video = bstRecg.GetVideo();
                        if (video == null)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "读取信息失败！");
                            return;
                        }
                        this.Invoke(new Action(() =>
                            {
                                double level = 0.8, x = 0, y = 0, w = 1, h = 1;
                                double.TryParse(video.Face_LEVEL, out level);
                                double.TryParse(video.RIO_X, out x);
                                double.TryParse(video.RIO_Y, out y);
                                double.TryParse(video.RIO_W, out w);
                                double.TryParse(video.RIO_H, out h);
                                diFaceLevel.Value = level;
                                diRIO_X.Value = x;
                                diRIO_Y.Value = y;
                                diRIO_W.Value = w;
                                diRIO_H.Value = h;
                                cbModelSingle.Checked = video.SINGLE == "Y";
                                cbModelMulti.Checked = !cbModelSingle.Checked;
                                tbDevTitle1.Text = video.TITLE1;
                                tbDevTitle2.Text = video.TITLE2;

                                if (video is BSTVideoRTSP)
                                {
                                    BSTVideoRTSP v = (BSTVideoRTSP)video;
                                    cbVideoCount1.Checked = true;
                                    tbRtsp1.Text = v.RTSP;
                                    tbRtsp2.Text = tbRtsp3.Text = "";
                                }
                                else if (video is BSTVideoRTSP3)
                                {
                                    BSTVideoRTSP3 v = (BSTVideoRTSP3)video;
                                    cbVideoCount1.Checked = false;
                                    cbVideoCount3.Checked = true;
                                    tbRtsp1.Text = v.RTSP1;
                                    tbRtsp2.Text = v.RTSP2;
                                    tbRtsp3.Text = v.RTSP3;
                                }
                            }));
                    }
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "读取信息异常：" + ex.Message);
                    log.Error("读取信息异常：" + ex.Message, ex);
                }

            });
            waiting.Show(this);
        }

        private void btnOkAndUpload_Click(object sender, EventArgs e)
        {
            Save(true);
        }
    }
}
