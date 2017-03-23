using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;

namespace SmartAccess.ConfigMgr
{
    public partial class DoorCameraSetting : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmAddCamera));
        public DoorCameraSetting()
        {
            InitializeComponent();
        }

        private void DoorCameraSetting_Load(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_CAMERA_INFO cameraBll = new Maticsoft.BLL.SMT_CAMERA_INFO();
                    var cameras = cameraBll.GetModelList("");
                    this.Invoke(new Action(() =>
                    {
                        foreach (var item in cameras)
                        {
                            AddToGridCamera(item);
                        }
                    }));

                    var ds= Maticsoft.DBUtility.DbHelperSQL.Query("SELECT T.*,SCI.CAMERA_NAME,SCI.CAMERA_IP FROM (select SDC.*,SDI.DOOR_NAME from SMT_DOOR_CAMERA SDC INNER JOIN SMT_DOOR_INFO SDI ON SDC.DOOR_ID=SDI.ID) T INNER JOIN SMT_CAMERA_INFO SCI ON T.CAMERA_ID=SCI.ID");
                    var dt = ds.Tables[0];
                    this.Invoke(new Action(() =>
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            AddToGridDoorCamera(dr);
                        }
                    }));

                    Maticsoft.BLL.SMT_DATADICTIONARY_INFO diBll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                    var imageServer = diBll.GetModel("CAMERA_INFO", "IMAGE_SERVER");
                    if (imageServer != null)
                    {
                        this.Invoke(new Action(() =>
                       {
                           tbPicUrl.Text = imageServer.DATA_VALUE;
                       }));
                    }
                }
                catch (Exception ex)
                {
                    log.Error("加载数据异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "加载数据异常：" + ex.Message);
                }
            });
            waiting.Show(this, 100);
        }

        private void biAddCamera_Click(object sender, EventArgs e)
        {
            FrmAddCamera frmAddCamera = new FrmAddCamera();
            if (frmAddCamera.ShowDialog(this) == DialogResult.OK)
            {
                AddToGridCamera(frmAddCamera.CAMERA);
                frmAddCamera.CAMERA = null;
            }
        }
        private void AddToGridCamera(Maticsoft.Model.SMT_CAMERA_INFO camera)
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            dgvr.CreateCells(dgvCamera,
                camera.CAMERA_NAME,
                camera.CAMERA_IP,
                camera.CAMERA_PORT,
                camera.CAMERA_USER,
                "******",
                camera.CAMERA_CAP_PORT,
                camera.CAMERA_CAP_TYPE,
                "删除"
                );
            dgvr.Tag = camera;
            dgvCamera.Rows.Add(dgvr);
        }
        private class DoorCamera
        {
            public decimal DOOR_ID;
            public decimal CAMERA_ID;
        }
        private void AddToGridDoorCamera(DataRow dr)
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            dgvr.CreateCells(dgvDoorCamera,
                dr["DOOR_NAME"],
                dr["CAMERA_NAME"]+"["+dr["CAMERA_IP"]+"]",
                (bool)dr["ENABLE_CAP"],
                "删除"
                );
            DoorCamera dc = new DoorCamera()
            {
                DOOR_ID = (decimal)dr["DOOR_ID"],
                CAMERA_ID = (decimal)dr["CAMERA_ID"]
            };
            dgvr.Tag = dc;
            dgvDoorCamera.Rows.Add(dgvr);
        }
        private void AddToGridDoorCamera(Maticsoft.Model.SMT_DOOR_INFO door,Maticsoft.Model.SMT_CAMERA_INFO camera,bool enable)
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            dgvr.CreateCells(dgvDoorCamera,
                door.DOOR_NAME,
                camera.CAMERA_NAME + "[" + camera.CAMERA_IP + "]",
                enable,
                "删除"
                );
            DoorCamera dc = new DoorCamera()
            {
                DOOR_ID = door.ID,
                CAMERA_ID = camera.ID
            };
            dgvr.Tag = dc;
            dgvDoorCamera.Rows.Add(dgvr);
        }
        private void dgvCamera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvCamera.Columns[e.ColumnIndex].Name == "Col_Delete")
                {
                    if (MessageBox.Show("确定删除该摄像头？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Maticsoft.Model.SMT_CAMERA_INFO camera = (Maticsoft.Model.SMT_CAMERA_INFO)dgvCamera.Rows[e.RowIndex].Tag;
                        CtrlWaiting waiting = new CtrlWaiting(() =>
                        {
                            try
                            {
                                Maticsoft.BLL.SMT_CAMERA_INFO cameraBll = new Maticsoft.BLL.SMT_CAMERA_INFO();
                                cameraBll.Delete(camera.ID);
                                Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from smt_door_camera where camera_id=" + camera.ID);
                                this.Invoke(new Action(() =>
                                {
                                    dgvCamera.Rows.Remove(dgvCamera.Rows[e.RowIndex]);
                                }));
                            }
                            catch (Exception ex)
                            {
                                log.Error("删除摄像头异常：", ex);
                                WinInfoHelper.ShowInfoWindow(this, "删除摄像头异常！" + ex.Message);
                            }
                        });
                        waiting.Show(this);
                    }
                }
            }
        }

        private void biAddDoorCamera_Click(object sender, EventArgs e)
        {
            var node = this.doorTree.Tree.SelectedNode;
            if (node==null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择门禁！");
                return;
            }
            if (node.Tag is Maticsoft.Model.SMT_DOOR_INFO)
            {
                Maticsoft.Model.SMT_DOOR_INFO door = (Maticsoft.Model.SMT_DOOR_INFO)node.Tag;
                var rows = dgvCamera.SelectedRows;
                if (rows.Count == 0)
                {
                    WinInfoHelper.ShowInfoWindow(this, "请选择摄像头！");
                    return;
                }
                List<Maticsoft.Model.SMT_CAMERA_INFO> cameras = new List<Maticsoft.Model.SMT_CAMERA_INFO>();
                foreach (DataGridViewRow row in rows)
                {
                    Maticsoft.Model.SMT_CAMERA_INFO cameraInfo = (Maticsoft.Model.SMT_CAMERA_INFO)row.Tag;
                    cameras.Add(cameraInfo);
                }
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        foreach (var camera in cameras)
                        {
                            Maticsoft.BLL.SMT_DOOR_CAMERA dcBll = new Maticsoft.BLL.SMT_DOOR_CAMERA();
                            var dcModel = dcBll.GetModel(door.ID, camera.ID);
                            if (dcModel == null)
                            {
                                dcModel = new Maticsoft.Model.SMT_DOOR_CAMERA();
                                dcModel.DOOR_ID = door.ID;
                                dcModel.CAMERA_ID = camera.ID;
                                dcModel.ENABLE_CAP = cbEnableCap.Checked;
                                dcBll.Add(dcModel);
                                this.Invoke(new Action(() =>
                                {
                                    AddToGridDoorCamera(door, camera, dcModel.ENABLE_CAP);
                                }));
                            }
                            else
                            {
                                if ( dcModel.ENABLE_CAP!=cbEnableCap.Checked)
                                {
                                    dcModel.ENABLE_CAP = cbEnableCap.Checked;
                                    dcBll.Update(dcModel);
                                    this.Invoke(new Action(() =>
                                    {
                                        foreach (DataGridViewRow row in this.dgvDoorCamera.Rows)
                                        {
                                            DoorCamera dc = (DoorCamera)row.Tag;
                                            if (dc.DOOR_ID==door.ID&&dc.CAMERA_ID==camera.ID)
                                            {
                                                row.Cells[2].Value = dcModel.ENABLE_CAP;
                                                break;
                                            }
                                        }
                                    }));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("添加关系异常：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "添加门禁相机关系异常：" + ex.Message);
                    }
                });
                waiting.Show(this);
            }
            else
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择门禁节点！");
            }
        }

        private void dgvDoorCamera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                if (e.ColumnIndex==3)//删除
                {
                    if (MessageBox.Show("确定删除该关联关系？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        DoorCamera dc = (DoorCamera)dgvDoorCamera.Rows[e.RowIndex].Tag;
                        CtrlWaiting waiting = new CtrlWaiting(() =>
                        {
                            try
                            {
                                Maticsoft.BLL.SMT_DOOR_CAMERA dcBll = new Maticsoft.BLL.SMT_DOOR_CAMERA();
                                dcBll.Delete(dc.DOOR_ID, dc.CAMERA_ID);
                                this.Invoke(new Action(() =>
                                {
                                    dgvDoorCamera.Rows.Remove(dgvDoorCamera.Rows[e.RowIndex]);
                                }));
                            }
                            catch (Exception ex)
                            {
                                log.Error("删除门禁相机关系异常：", ex);
                                WinInfoHelper.ShowInfoWindow(this, "删除门禁相机关系异常：" + ex.Message);
                            }
                        });
                        waiting.Show(this);
                    }
                    
                }
            }
        }

        private void dgvDoorCamera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                {
                    bool enable = (bool)dgvDoorCamera.Rows[e.RowIndex].Cells[2].Value;
                    DoorCamera dc = (DoorCamera)dgvDoorCamera.Rows[e.RowIndex].Tag;
                    CtrlWaiting waiting = new CtrlWaiting(() =>
                    {
                        try
                        {
                            Maticsoft.BLL.SMT_DOOR_CAMERA dcBll = new Maticsoft.BLL.SMT_DOOR_CAMERA();
                            Maticsoft.Model.SMT_DOOR_CAMERA dcModel = new Maticsoft.Model.SMT_DOOR_CAMERA()
                            {
                                DOOR_ID = dc.DOOR_ID,
                                CAMERA_ID = dc.CAMERA_ID,
                                ENABLE_CAP = !enable
                            };
                            dcBll.Update(dcModel);
                            this.Invoke(new Action(() =>
                            {
                                dgvDoorCamera.Rows[e.RowIndex].Cells[2].Value = dcModel.ENABLE_CAP;
                            }));
                        }
                        catch (System.Exception ex)
                        {
                            log.Error("更新门禁相机关系异常：", ex);
                            WinInfoHelper.ShowInfoWindow(this, "更新门禁相机关系异常：" + ex.Message);
                        }

                    });
                    waiting.Show(this);
                }
            }
        }

        private void biSave_Click(object sender, EventArgs e)
        {
            string str = tbPicUrl.Text.Trim();
            if (str == "")
            {
                WinInfoHelper.ShowInfoWindow(this, "图片服务地址不能为空！");
                return;
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_DATADICTIONARY_INFO diBll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                    var imageServer = diBll.GetModel("CAMERA_INFO", "IMAGE_SERVER");
                    if (imageServer==null)
                    {
                        imageServer = new Maticsoft.Model.SMT_DATADICTIONARY_INFO();
                        imageServer.DATA_TYPE = "CAMERA_INFO";
                        imageServer.DATA_KEY = "IMAGE_SERVER";
                        imageServer.DATA_VALUE = str;
                        imageServer.DATA_NAME = "抓图访问服务地址";
                        imageServer.DATA_CONTENT = "摄像头抓图时服务访问的地址";
                        diBll.Add(imageServer);
                    }
                    else
                    {
                        imageServer.DATA_VALUE = str;
                        diBll.Update(imageServer);
                    }
                    WinInfoHelper.ShowInfoWindow(this, "保存成功！");
                }
                catch (Exception ex)
                {
                    log.Error("保存抓图访问服务地址异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "保存抓图访问服务地址异常：" + ex.Message);
                }
            });
            waiting.Show(this);
        }
    }
}
