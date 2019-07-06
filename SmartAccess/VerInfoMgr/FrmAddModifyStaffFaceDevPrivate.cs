using DevComponents.AdvTree;
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

namespace SmartAccess.VerInfoMgr
{
    public partial class FrmAddModifyStaffFaceDevPrivate : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmAddModifyStaffFaceDevPrivate));
        private List<Maticsoft.Model.SMT_FACERECG_DEVICE> _faceDevices = null;
        private Maticsoft.Model.SMT_STAFF_INFO _staffInfo;
        private bool _imageChanged=false;
        public FrmAddModifyStaffFaceDevPrivate(Maticsoft.Model.SMT_STAFF_INFO staff, bool imageChanged)
        {
            InitializeComponent();
            _staffInfo = staff;
            _imageChanged = imageChanged;
        }

        private void FrmAddModifyStaffFaceDevPrivate_Load(object sender, EventArgs e)
        {
            if (_staffInfo!=null)
            {
                this.TitleText = "开始添加“" + _staffInfo.REAL_NAME + "”人脸设备权限";
                this.dtpStart.Value = _staffInfo.VALID_STARTTIME;
                this.dtpEnd.Value = _staffInfo.VALID_ENDTIME;
            }

            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_FACERECG_DEVICE faceBll = new Maticsoft.BLL.SMT_FACERECG_DEVICE();
                    _faceDevices = faceBll.GetModelList("");
                    var areas = AreaDataHelper.GetAreas();
                    this.Invoke(new Action(() =>
                    {
                        var nodes = AreaDataHelper.ToTree(areas);
                        var faceDevs = _faceDevices.ToList();
                        foreach (var item in nodes)
                        {
                            DoCreateAreaDevice(item, faceDevs);
                        }

                        for (int i = faceDevs.Count - 1; i >= 0; i--)
                        {
                            var item = faceDevs[i];
                            Node devNode = new Node("<font color='blue'>" + item.FACEDEV_NAME + "</font>");
                            devNode.Image = Properties.Resources.editor;
                            devNode.Tag = item;
                            nodes.Insert(0, devNode);
                        }
                        Node root = new Node("所有人脸识别设备");
                        root.Image = Properties.Resources.house1818;
                        root.Nodes.AddRange(nodes.ToArray());
                        nodes.Clear();
                        nodes.Add(root);


                        advTree.Nodes.Clear();
                        advTree.Nodes.AddRange(nodes.ToArray());
                        advTree.ExpandAll();
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载人脸设备列表异常！" + ex.Message);
                    log.Error("加载人脸设备列表异常:", ex);
                }
            });
            waiting.Show(this);

        }

        private void DoCreateAreaDevice(Node areaNode, List<Maticsoft.Model.SMT_FACERECG_DEVICE> devs)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE zone = areaNode.Tag as Maticsoft.Model.SMT_CONTROLLER_ZONE;
            if (zone != null)
            {
                var fdev = devs.FindAll(m => m.AREA_ID == zone.ID);
                for (int i = fdev.Count - 1; i >= 0; i--)
                {
                    var item = fdev[i];
                    Node doorNode = new Node("<font color='blue'>" + item.FACEDEV_NAME + "</font>");
                    doorNode.Tag = item;
                    doorNode.Image = Properties.Resources.door1818;
                    areaNode.Nodes.Insert(0, doorNode);
                    devs.Remove(item);
                }
            }
            foreach (Node item in areaNode.Nodes)
            {
                DoCreateAreaDevice(item, devs);
            }
        }
        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            CommonClass.FilterTree(advTree, tbFilter.Text.Trim());
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            List<Node> nodes = new List<Node>();
            foreach (Node item in this.advTree.SelectedNodes)
            {
                nodes.Add(item);
            }

            nodes = this.advTree.GetNodeList(nodes, typeof(Maticsoft.Model.SMT_FACERECG_DEVICE));
            DoSelectDevices(nodes);
        }
        /// <summary>
        /// 执行选择设备
        /// </summary>
        /// <param name="doors"></param>
        private void DoSelectDevices(List<Node> doors)
        {
            foreach (var item in doors)
            {
                Maticsoft.Model.SMT_FACERECG_DEVICE device = (Maticsoft.Model.SMT_FACERECG_DEVICE)item.Tag;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvSelectDevice, device.FACEDEV_NAME, device.AREA_NAME);
                row.Tag = item;
                dgvSelectDevice.Rows.Add(row);
                item.DataKey = item.Parent;
                item.Remove();
            }
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            List<Node> nodes = new List<Node>();
            foreach (Node item in this.advTree.Nodes)
            {
                nodes.Add(item);
            }
            nodes = this.advTree.GetNodeList(nodes, typeof(Maticsoft.Model.SMT_FACERECG_DEVICE));
            DoSelectDevices(nodes);
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvSelectDevice.SelectedRows)
            {
                rows.Add(item);
            }
            DoUnSelect(rows);
        }
        private void DoUnSelect(List<DataGridViewRow> rows)
        {
            for (int i = rows.Count - 1; i >= 0; i--)
            {
                var item = rows[i];
                Node node = (Node)item.Tag;
                Node parent = (Node)node.DataKey;
                parent.Nodes.Insert(0, node);
                dgvSelectDevice.Rows.Remove(item);
            }
        }

        private void btnAllUnSelect_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvSelectDevice.Rows)
            {
                rows.Add(item);
            }
            DoUnSelect(rows);
        }
        private List<Maticsoft.Model.SMT_FACERECG_DEVICE> GetSelect()
        {
            List<Maticsoft.Model.SMT_FACERECG_DEVICE> devs = new List<Maticsoft.Model.SMT_FACERECG_DEVICE>();
            foreach (DataGridViewRow item in dgvSelectDevice.Rows)
            {
                Node node = (Node)item.Tag;
                Maticsoft.Model.SMT_FACERECG_DEVICE dev = (Maticsoft.Model.SMT_FACERECG_DEVICE)node.Tag;
                devs.Add(dev);
            }
            return devs;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            List<Maticsoft.Model.SMT_FACERECG_DEVICE> devs = GetSelect();
            DoSaveDevices(devs);
        }
        private void DoSaveDevices(List<Maticsoft.Model.SMT_FACERECG_DEVICE> devices, bool upload = false)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
            {
                WinInfoHelper.ShowInfoWindow(this, "起始时间不能小于结束时间！");
                return;
            }

            CtrlWaiting ctrlWaiting = new CtrlWaiting("正在保存...", () =>
            {
                try
                {
                    Maticsoft.BLL.SMT_STAFF_FACEDEV sfBLL = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
                    var sfList = sfBLL.GetModelList("STAFF_ID=" + _staffInfo.ID);
                    List<Maticsoft.Model.SMT_FACERECG_DEVICE> tempDevs = new List<Maticsoft.Model.SMT_FACERECG_DEVICE>();
                    tempDevs.AddRange(devices);
                    List<Maticsoft.Model.SMT_STAFF_FACEDEV> addPrivates = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
                    List<Maticsoft.Model.SMT_STAFF_FACEDEV> updatePrivates = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
                    List<Maticsoft.Model.SMT_STAFF_FACEDEV> delPrivates = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
                    foreach (var item in sfList)
                    {
                        var sc = devices.Find(m => m.ID == item.FACEDEV_ID);
                        if (sc == null)//不存在，则权限删除
                        {
                            delPrivates.Add(item);
                           // sfBLL.Delete(item.STAFF_ID, item.FACEDEV_ID);//删除权限
                        }
                        else
                        {
                            item.START_VALID_TIME = dtpStart.Value.Date;
                            item.END_VALID_TIME = dtpEnd.Value.Date + new TimeSpan(23, 59, 59);
                            if (_staffInfo.VALID_STARTTIME.Date > item.START_VALID_TIME.Date)
                            {
                                item.START_VALID_TIME = _staffInfo.VALID_STARTTIME.Date;
                            }
                            if (_staffInfo.VALID_ENDTIME.Date < item.END_VALID_TIME.Date)
                            {
                                item.END_VALID_TIME = _staffInfo.VALID_ENDTIME.Date + new TimeSpan(23, 59, 59);
                            }
                            sfBLL.Update(item);
                            tempDevs.Remove(sc);
                            if (!item.IS_UPLOAD)
                            {
                                addPrivates.Add(item);
                            }
                            else
                            {
                                if (_imageChanged)
                                {
                                    addPrivates.Add(item);
                                }
                                else
                                {
                                    updatePrivates.Add(item);
                                }
                            }
                        }
                    }
                    foreach (var item in tempDevs)//添加的权限
                    {
                        Maticsoft.Model.SMT_STAFF_FACEDEV newSd = new Maticsoft.Model.SMT_STAFF_FACEDEV();
                        newSd.ADD_TIME = DateTime.Now;
                        newSd.FACEDEV_ID = item.ID;
                        newSd.IS_UPLOAD = false;
                        newSd.UPLOAD_TIME = DateTime.Now;
                        newSd.STAFF_ID = _staffInfo.ID;
                        newSd.STAFF_DEV_ID = Guid.NewGuid().ToString("N");
                        newSd.START_VALID_TIME = dtpStart.Value.Date;
                        newSd.END_VALID_TIME = dtpEnd.Value.Date + new TimeSpan(23, 59, 59);
                        if (_staffInfo.VALID_STARTTIME.Date>newSd.START_VALID_TIME.Date)
                        {
                            newSd.START_VALID_TIME = _staffInfo.VALID_STARTTIME.Date;
                        }
                        if (_staffInfo.VALID_ENDTIME.Date<newSd.END_VALID_TIME.Date)
                        {
                            newSd.END_VALID_TIME=_staffInfo.VALID_ENDTIME.Date + new TimeSpan(23, 59, 59);
                        }
                        sfBLL.Add(newSd);
                        addPrivates.Add(newSd);
                    }
                    if (upload)
                    {
                        string errMsg;
                        if (delPrivates.Count>0)
                        {
                            var delResults = UploadPrivate.DeleteFace(delPrivates, out errMsg);
                            if (delResults != null && delResults.Count > 0)
                            {
                                foreach (var item in delResults)
                                {
                                    Maticsoft.BLL.SMT_STAFF_FACEDEV bll = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
                                    bll.Delete(item.STAFF_ID, item.FACEDEV_ID);
                                }
                            }
                        }
                        errMsg = "";
                        if (addPrivates.Count>0||updatePrivates.Count>0)
                        {
                            SmartAccess.Common.Datas.UploadPrivate.CancelObject cancelObject = new UploadPrivate.CancelObject();
                            bool ret = UploadPrivate.UploadFace(cancelObject, addPrivates, updatePrivates, out errMsg);
                            if (ret && errMsg != "")
                            {
                                WinInfoHelper.ShowInfoWindow(this, "上传权限存在异常：" + errMsg);
                                log.Warn("上传权限存在异常:" + errMsg);
                                return;
                            }
                        }
                        WinInfoHelper.ShowInfoWindow(null, "上传权限结束！");
                    }
                    this.Invoke(new Action(() =>
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }));
                }
                catch (System.Exception ex)
                {
                    log.Error("保存异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "保存异常：" + ex.Message);
                }
            });
            ctrlWaiting.Show(this);
        }

        private void btnOkUpload_Click(object sender, EventArgs e)
        {
            List<Maticsoft.Model.SMT_FACERECG_DEVICE> devs = GetSelect();
            DoSaveDevices(devs,true);
        }
    }
}
