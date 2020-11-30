﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;
using DevComponents.AdvTree;
using SmartAccess.ConfigMgr;
using SmartAccess.Common.Datas;
using DevComponents.DotNetBar;
using Li.Access.Core;
using System.Threading;
using System.IO;
using Li.Access.Core.FaceDevice;

namespace SmartAccess.RealDetectMgr
{
    public partial class RealMapDetect : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(RealMapDetect));
        private List<MapCtrl> _detectedMaps = new List<MapCtrl>();
        public RealMapDetect()
        {
            InitializeComponent();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            UploadPrivate.WatchService.ClearControllers(this.GetType().FullName);
            base.OnHandleDestroyed(e);
        }

        private void RealMapDetect_Load(object sender, EventArgs e)
        {
            stcMaps.Tabs.Clear();
            Init();
        }
        private void Init()
        {
            modelTree.Nodes[0].Nodes.Clear();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_MAP_INFO mapBll = new Maticsoft.BLL.SMT_MAP_INFO();
                    var maps = mapBll.GetModelListWithDoors("1=1");
                    this.Invoke(new Action(() =>
                    {
                        foreach (var item in maps)
                        {
                            AddTree(item);
                        }
                        modelTree.ExpandAll();
                    }));
                    try
                    {
                        if (DoorDataHelper.LastDoors == null)
                        {
                            DoorDataHelper.GetDoors();
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error("初始化门禁异常：", ex);
                    }

                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载地图列表异常：" + ex.Message);
                    log.Error("加载地图列表异常：", ex);
                }

            });
            waiting.Show(this);
        }
        private void AddTree(Maticsoft.Model.SMT_MAP_INFO mapInfo)
        {
            Node node = new Node(mapInfo.MAP_NAME);
            node.Tag = mapInfo;
            modelTree.Nodes[0].Nodes.Add(node);
        }

        private void biRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }
        private void SelectMap(Maticsoft.Model.SMT_MAP_INFO mapInfo)
        {
            foreach (DevComponents.DotNetBar.SuperTabItem item in stcMaps.Tabs)
            {
                Maticsoft.Model.SMT_MAP_INFO map = (Maticsoft.Model.SMT_MAP_INFO)item.Tag;
                if (map.ID == mapInfo.ID)
                {
                    stcMaps.SelectedTab = item;
                }
            }
        }
        private MapCtrl GetSelectMapCtrl()
        {
            DevComponents.DotNetBar.SuperTabItem item = stcMaps.SelectedTab;
            if (item != null && item.AttachedControl.Controls.Count>0)
            {
                return item.AttachedControl.Controls[0] as MapCtrl;
            }
            return null;
        }
        private MapCtrl OpenMap(Maticsoft.Model.SMT_MAP_INFO mapInfo)
        {
            foreach (DevComponents.DotNetBar.SuperTabItem item in stcMaps.Tabs)
            {
                Maticsoft.Model.SMT_MAP_INFO map=(Maticsoft.Model.SMT_MAP_INFO)item.Tag;
                if (map.ID==mapInfo.ID)
                {
                    stcMaps.SelectedTab = item;
                    return item.AttachedControl.Controls[0] as MapCtrl;
                }
            }
            MapCtrl mapCtrl = new MapCtrl();
            mapCtrl.Tag = mapInfo;
            mapCtrl.Dock = DockStyle.Fill;
            DevComponents.DotNetBar.SuperTabControlPanel stcPanel = new DevComponents.DotNetBar.SuperTabControlPanel();
            stcPanel.Controls.Add(mapCtrl);
            mapCtrl.LoadMapInfo(mapInfo);
            DevComponents.DotNetBar.SuperTabItem stcItem = new DevComponents.DotNetBar.SuperTabItem() ;
            stcItem.Text = mapInfo.MAP_NAME;
            stcItem.Tag = mapInfo;
            stcItem.AttachedControl = stcPanel;
            stcMaps.Controls.Add(stcPanel);
            stcMaps.Tabs.Add(stcItem);
            stcMaps.SelectedTab = stcItem;
            mapCtrl.DelayFullExtent();
            mapCtrl.Font = new Font("微软雅黑", 9);
            return mapCtrl;
        }

        private void GetDoors(MapCtrl mapCtrl, out List<Maticsoft.Model.SMT_DOOR_INFO> doors,out  List<Maticsoft.Model.SMT_FACERECG_DEVICE> faceDevs)
        {
            Maticsoft.Model.SMT_MAP_INFO mapInfo = (Maticsoft.Model.SMT_MAP_INFO)mapCtrl.Tag;
            doors = new List<Maticsoft.Model.SMT_DOOR_INFO>();
            faceDevs = new List<Maticsoft.Model.SMT_FACERECG_DEVICE>();
            if (mapInfo.MAP_DOORS == null || mapInfo.MAP_DOORS.Count == 0)
            {
                return;
            }
            foreach (var item in mapInfo.MAP_DOORS)
            {
                if ( item.DOOR_TYPE==1)
                {
                    if (!item.DOOR.IS_ENABLE || item.DOOR.CTRL_ID == null || item.DOOR.CTRL_DOOR_INDEX == null)
                    {
                        continue;
                    }
                    if (DoorDataHelper.LastDoors != null)
                    {
                        if (DoorDataHelper.LastDoors.Exists(m => m.ID == item.DOOR.ID))
                        {
                            doors.Add(item.DOOR);
                        }
                    }
                    else
                    {
                        doors.Add(item.DOOR);
                    }
                }
                else if (item.DOOR_TYPE==2)
                {
                    if (!item.FACE.FACEDEV_IS_ENABLE)
                    {
                        continue;
                    }
                    var faces = FaceRecgHelper.GetList("", false, false);
                    if (faces != null)
                    {
                        if (faces.Exists(m => m.ID == item.FACE.ID))
                        {
                            faceDevs.Add(item.FACE);
                        }
                    }
                    else
                    {
                        faceDevs.Add(item.FACE);
                    }
                }
            }
        }

        private List<decimal> GetCtrlIDs(List<Maticsoft.Model.SMT_DOOR_INFO> doors)
        {
            var g = doors.GroupBy(m => m.CTRL_ID);
            List<decimal> ctrIds = new List<decimal>();
            foreach (var item in g)
            {
                if (item.ToArray()[0].CTRL_ID == null)
                {
                    continue;
                }
                decimal ctrlId = (decimal)item.ToArray()[0].CTRL_ID;
                ctrIds.Add(ctrlId);
            }
            return ctrIds;
        }
        private List<Maticsoft.Model.SMT_CONTROLLER_INFO> GetCtrls(List<decimal> ctrIds)
        {
            Maticsoft.BLL.SMT_CONTROLLER_INFO ctrlBll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
            var models = ctrlBll.GetModelList("ID in (" + string.Join(",", ctrIds.ToArray()) + ")");
            return models;
        }
        private void modelTree_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Left)
            {
                Maticsoft.Model.SMT_MAP_INFO mapInfo = e.Node.Tag as Maticsoft.Model.SMT_MAP_INFO;
                if (mapInfo==null)
                {
                    return;
                }
                OpenMap(mapInfo);
            }
        }

        private void modelTree_NodeMouseUp(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Maticsoft.Model.SMT_MAP_INFO mapInfo = e.Node.Tag as Maticsoft.Model.SMT_MAP_INFO;
                if (mapInfo == null)
                {
                    return;
                }
                SelectMap(mapInfo);
            }
        }

        private void biZoomPlus_Click(object sender, EventArgs e)
        {
            MapCtrl map = GetSelectMapCtrl();
            if (map!=null)
            {
                map.ZoomPlus();
            }
        }

        private void biZoomMinus_Click(object sender, EventArgs e)
        {
            MapCtrl map = GetSelectMapCtrl();
            if (map != null)
            {
                map.ZoomMinus();
            }
        }

        private void biDetectCurMap_Click(object sender, EventArgs e)
        {
            if (stcMaps.SelectedTab == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "未有地图被选中！");
                return;
            }
            DoDetectMap(stcMaps.SelectedTab);
        }

        private void DoDetectMap(SuperTabItem tabItem)
        {
            if (tabItem==null||tabItem.AttachedControl ==null || tabItem.AttachedControl.Controls.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "没有地图打开！");
                return;
            }
            MapCtrl mapCtrl = tabItem.AttachedControl.Controls[0] as MapCtrl;
            if (mapCtrl==null)
            {
                WinInfoHelper.ShowInfoWindow(this, "地图无效！名称：" + tabItem.Text);
                return;
            }
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = null;
            List<Maticsoft.Model.SMT_FACERECG_DEVICE> faces = null;
            GetDoors(mapCtrl, out doors, out faces);
            if (doors.Count == 0 && faces.Count==0)
            {
                WinInfoHelper.ShowInfoWindow(this, "地图中门禁以及人脸设备状态不可用！");
                return;
            }
            
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                if (doors.Count>0)
                {
                    List<decimal> ctrlIds = GetCtrlIDs(doors);
                    var models = GetCtrls(ctrlIds);
                    if (models.Count > 0)
                    {
                        _detectedMaps.Add(mapCtrl);
                        foreach (var model in models)
                        {
                            UploadPrivate.WatchService.AddController(ControllerHelper.ToController(model), ControllerStateCallBack, this.GetType().FullName);
                        }
                    }
                    else
                    {
                        WinInfoHelper.ShowInfoWindow(this, "未找到控制器！");
                    }
                }
                if (faces.Count > 0)
                {
                    //开始人脸设备实时监控
                    int count = 0;
                    foreach (var item in faces)
                    {
                        if (!item.FACEDEV_IS_ENABLE)
                        {
                            continue;
                        }
                        count++;
                        FaceDeviceModel faceDeviceModel = FaceDeviceModel.BST;
                        Enum.TryParse<FaceDeviceModel>(item.FACEDEV_MODE, out faceDeviceModel);
                        UploadPrivate.FaceWatchService.AddController(new FaceDeviceClass() { _id = item.ID, _sn = item.FACEDEV_SN, _ip = item.FACEDEV_IP,_faceDeviceModel=faceDeviceModel, _dbName = item.FACEDEV_DB_NAME, _dbPort = item.FACEDEV_DB_PORT, _dbPwd = item.FACEDEV_DB_PWD, _dbUser = item.FACEDEV_DB_USER, _heartPort = item.FACEDEV_HEART_PORT, _port = item.FACEDEV_CTRL_PORT }, FaceStateCallback, this.GetType().FullName);
                    }
                }

                this.Invoke(new Action(() =>
                {
                    tabItem.Text = mapCtrl.MapName + "<监控中>";
                }));
                WinInfoHelper.ShowInfoWindow(this, "成功开启监控！地图名称：" + mapCtrl.MapName);

            });
            waiting.Show(this);   
        }
        
        private void CloseDetect(SuperTabItem tabItem)
        {
            lock (_detectedMaps)
            {
                SuperTabItem item = tabItem;
                if (_detectedMaps.Contains(item.AttachedControl.Controls[0]))
                {
                    MapCtrl mapCtrl = (MapCtrl)item.AttachedControl.Controls[0];
                    _detectedMaps.Remove(mapCtrl);
                    List<Maticsoft.Model.SMT_DOOR_INFO> doors;
                    List<Maticsoft.Model.SMT_FACERECG_DEVICE> faces;
                    GetDoors(mapCtrl,out doors,out faces);
                    var ctrlIds = GetCtrlIDs(doors);
                    item.Text = mapCtrl.MapName;
                    foreach (var it in _detectedMaps)
                    {
                        if (it == item.AttachedControl.Controls[0])
                        {
                            continue;
                        }
                        List<Maticsoft.Model.SMT_DOOR_INFO> doorsFind;
                        List<Maticsoft.Model.SMT_FACERECG_DEVICE> facesFind;
                        GetDoors((MapCtrl)it, out doorsFind, out facesFind);
                        var ctrlIdsFind = GetCtrlIDs(doorsFind);
                        List<decimal> finds = new List<decimal>();
                        foreach (var id in ctrlIds)
                        {
                            if (ctrlIdsFind.Contains(id))
                            {
                                finds.Add(id);
                            }
                        }
                        foreach (var id in finds)
                        {
                            ctrlIds.Remove(id);
                        }
                    }
                    
                    ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                        {
                            foreach (var id in ctrlIds)
                            {
                                UploadPrivate.WatchService.RemoveControllerById(id, this.GetType().FullName);
                            }
                            foreach (var face in faces)
                            {
                                UploadPrivate.FaceWatchService.RemoveControllerById(face.ID, this.GetType().FullName);
                            }
                        }));
                }
            }
        }
        private void stcMaps_TabItemClose(object sender, DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs e)
        {
            CloseDetect((SuperTabItem)e.Tab);
        }
        private void ControllerStateCallBack(Li.Access.Core.Controller ctrlr, bool connected, Li.Access.Core.ControllerState state, bool doorstate,bool relaystate)
        {
            lock (_detectedMaps)
            {
                List<MapCtrl> disposeds = new List<MapCtrl>();
                foreach (var item in _detectedMaps)
                {
                    if (item.IsDisposed)
                    {
                        disposeds.Add(item);
                    }
                    else
                    {
                        try
                        {
                            AddWatchData(ctrlr, connected, state, doorstate, relaystate);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                foreach (var item in disposeds)
                {
                    _detectedMaps.Remove(item);
                }
            }
        }
        private List<Maticsoft.Model.SMT_CARD_INFO> _cards = null;

        private void FaceStateCallback(FaceDeviceClass dev, bool connected, FaceRecgRecord log)
        {
            try
            {
                try
                {
                    if (log != null && dev._faceDeviceModel == FaceDeviceModel.FY && !string.IsNullOrWhiteSpace(log.staffDevId))
                    {
                        Maticsoft.BLL.SMT_STAFF_FACEDEV ssfBll = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
                        var models = ssfBll.GetModelList("STAFF_DEV_ID = '" + log.staffDevId + "'");
                        if (models.Count > 0)
                        {
                            var staffId = models[0].STAFF_ID;
                            Maticsoft.BLL.SMT_STAFF_INFO stfBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                            var staffInfo = stfBll.GetModel(staffId);
                            if (staffInfo != null)
                            {
                                log.photoImage = staffInfo.PHOTO;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.log.Error("获取照片异常：", ex);
                }
                
                lock (this)
                {
                    AddFaceWatchData(dev, connected, log);
                }
            }
            catch (Exception)
            {
            }
        }

        private void AddFaceWatchData(FaceDeviceClass dev, bool connected, FaceRecgRecord log)
        {
            this.Invoke(new Action(() =>
            {
                foreach (var item in _detectedMaps)
                {
                    List<Maticsoft.Model.SMT_DOOR_INFO> doors;
                    List<Maticsoft.Model.SMT_FACERECG_DEVICE> faces;
                    GetDoors(item, out doors, out faces);
                    if (faces.Count==0)
                    {
                        continue;
                    }
                    foreach (var face in faces)
                    {
                        if (!face.FACEDEV_IS_ENABLE)
                        {
                            continue;
                        }
                        if (face.ID!=dev._id)
                        {
                            continue;
                        }

                        DateTime dt = DateTime.Now;
                        string desc = "";
                        if (log != null)
                        {
                            desc = "人脸识别：" + log.compareVal;

                            dt = log.time;
                        }
                        else
                        {
                            desc = "人脸识别设备：" + (connected ? "上线" : "掉线");
                        }
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgvRealLog, dt, face.FACEDEV_NAME + "(人脸)", desc);
                        dgvRealLog.Rows.Insert(0, row);
                        row.Tag = new object[] { face, log, dt };
                        ShowFaceStaffInfo(face, log);
                        while (dgvRealLog.Rows.Count > 2000)
                        {
                            dgvRealLog.Rows.RemoveAt(dgvRealLog.Rows.Count - 1);
                        }
                    }
                }
                foreach (DataGridViewRow item in dgvRealLog.SelectedRows)
                {
                    item.Selected = false;
                }
                if (dgvRealLog.Rows.Count > 0)
                {
                    dgvRealLog.Rows[0].Selected = true;
                }
            }));
        }

        private void ShowFaceStaffInfo(Maticsoft.Model.SMT_FACERECG_DEVICE dev, FaceRecgRecord slog)
        {
            if (slog == null)
            {
                return;
            }
            try
            {
                if (picBox.Image != null)
                {
                    picBox.Image.Dispose();
                    picBox.Image = null;
                }
                if (picBox2.Image != null)
                {
                    picBox2.Image.Dispose();
                    picBox2.Image = null;
                }
                if (slog.photoImage != null && slog.photoImage.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(slog.photoImage);
                    Image bitmap = Image.FromStream(ms);
                    picBox.Image = bitmap;
                }
                if (slog.videoImage != null && slog.videoImage.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(slog.videoImage);
                    Image bitmap = Image.FromStream(ms);
                    picBox2.Image = bitmap;
                }
                lbStaffName.Text = slog.realName + "(" + slog.cardNo + ")";
                lbDeptName.Text = slog.deptName;
                lbTime.Text = slog.time.ToString("yyyy-MM-dd HH:mm:ss");
                lbDoorName.Text = dev.FACEDEV_NAME + "(人脸)";
                lbAction.Text = "人脸识别";
                lbLevel.Text = (slog.compareVal * 100).ToString(".00") + "%";
            }
            catch (Exception ex)
            {
                log.Error("显示人脸信息异常：", ex);
            }

        }
        private void AddWatchData(Controller ctrlr, bool connected, ControllerState state, bool doorstate, bool relaystate)
        {
            string cardNo = null;
            if (state != null)
            {
                if (_cards == null)
                {
                    Maticsoft.BLL.SMT_CARD_INFO cardBll = new Maticsoft.BLL.SMT_CARD_INFO();
                    _cards = cardBll.GetModelList("");
                }
                cardNo = state.cardOrNoNumber;
                var card = _cards.Find(m => m.CARD_WG_NO == state.cardOrNoNumber);
                if (card != null)
                {
                    cardNo = card.CARD_NO;
                }
                else
                {
                    Maticsoft.BLL.SMT_CARD_INFO cardBll = new Maticsoft.BLL.SMT_CARD_INFO();
                    var c = cardBll.GetModelList("CARD_WG_NO='" + state.cardOrNoNumber + "'");
                    if (c.Count > 0)
                    {
                        _cards.Add(c[0]);
                        cardNo = c[0].CARD_NO;
                    }
                }
            }
            string staffname = "未知";
            string orgname = "未知";
            Maticsoft.Model.SMT_STAFF_INFO sinfo = null;
            if (cardNo != null)
            {
                try
                {
                    Maticsoft.BLL.SMT_STAFF_INFO siBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                    var ds = siBll.GetListByCardNum(cardNo);
                    var list = siBll.DataTableToListWithDept(ds.Tables[0]);
                    if (list.Count > 0)
                    {
                        staffname = list[0].REAL_NAME;
                        orgname = list[0].ORG_NAME;
                        sinfo = list[0];
                    }
                }
                catch (Exception ex)
                {
                    log.Error("读取职员异常：", ex);
                }

            }
            this.Invoke(new Action(() =>
            {
                foreach (MapCtrl item in _detectedMaps)
                {
                    List<Maticsoft.Model.SMT_DOOR_INFO> doors;
                    List<Maticsoft.Model.SMT_FACERECG_DEVICE> faces;
                    GetDoors(item, out doors, out faces);
                    foreach (var door in doors)
                    {
                        if ((decimal)door.CTRL_ID != ctrlr.id)
                        {
                            continue;
                        }
                        var doorRect = item.GetDoor(door.ID,1);
                        if (doorRect == null)
                        {
                            continue;
                        }
                        doorRect.IsOnline = connected;

                        int doorIndex = (int)door.CTRL_DOOR_INDEX;
                        bool doorLock = false;
                        if (state != null)
                        {
                            //更新状态
                            switch (doorIndex)
                            {
                                case 1:
                                    doorLock = state.isOpenDoorOfLock1;
                                    break;
                                case 2:
                                    doorLock = state.isOpenDoorOfLock2;
                                    break;
                                case 3:
                                    doorLock = state.isOpenDoorOfLock3;
                                    break;
                                case 4:
                                    doorLock = state.isOpenDoorOfLock4;
                                    break;
                                default:
                                    break;
                            }

                            //更新状态
                            doorRect.IsOpen = doorLock;
                            door.OPEN_STATE = doorLock ? 1 : 0;
                            DoorDataHelper.UpdateDoorSync(door);
                        }
                        if ((!connected || state == null) && !doorstate)
                        {
                            door.OPEN_STATE = 2;
                            doorRect.IsOnline = false;
                            DoorDataHelper.UpdateDoorSync(door);
                            //item.ImageIndex = connected ? 0 : 2;
                            /*DataGridViewRow row = new DataGridViewRow();
                            row.Tag = ctrlr;
                            row.CreateCells(dgvRealLog, DateTime.Now, door.DOOR_NAME, string.Format("控制器：IP={0},SN={1} {2}！", ctrlr.ip, ctrlr.sn, connected ? "连接成功" : "无法连接"));
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                            dgvRealLog.Rows.Insert(0, row);*/
                        }
                        else if ((byte)door.CTRL_DOOR_INDEX == state.doorNum)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.Tag = state;
                            if (!relaystate)
                            {
                                string actionname = AccessHelper.GetRecordReasonString(state.reasonNo);
                                if (!doorLock)
                                {
                                    actionname += "，锁状态：关";
                                }
                                else
                                {
                                    actionname += "，锁状态：开";
                                }
                                if (doorstate)
                                {
                                    row.CreateCells(dgvRealLog, state.recordTime, door.DOOR_NAME + (state.isEnterDoor ? "-进门" : "-出门"), string.Format("人员:{0}，部门:{1},门禁:{2},卡号：{3},动作：{4}", staffname, orgname, door.DOOR_NAME, cardNo, actionname));
                                    dgvRealLog.Rows.Insert(0, row);
                                    row.Tag = new object[] { sinfo, state };
                                    ShowStaffInfo(row, row.Tag as object[]);
                                    while (dgvRealLog.Rows.Count > 2000)
                                    {
                                        dgvRealLog.Rows.RemoveAt(dgvRealLog.Rows.Count - 1);
                                    }
                                }
                            }
                        }
                    }
                    item.Invalidate();
                }
            }));
        }
        private void ShowStaffInfo(DataGridViewRow row, object[] infos)
        {
            if (infos == null)
            {
                return;
            }
            try
            {
                if (picBox.Image != null)
                {
                    picBox.Image.Dispose();
                    picBox.Image = null;
                }
                Maticsoft.Model.SMT_STAFF_INFO sinfo = infos[0] as Maticsoft.Model.SMT_STAFF_INFO;
                ControllerState state = infos[1] as ControllerState;
                if (sinfo.PHOTO != null && sinfo.PHOTO.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(sinfo.PHOTO);
                    Image bitmap = Image.FromStream(ms);
                    picBox.Image = bitmap;
                }
                if (sinfo != null)
                {
                    lbStaffName.Text = sinfo.REAL_NAME;
                    lbDeptName.Text = sinfo.ORG_NAME;
                }
                else
                {
                    lbStaffName.Text = "----";
                    lbDeptName.Text = "----";
                }
                if (state != null)
                {
                    lbTime.Text = state.recordTime.ToString("yyyy-MM-dd HH:mm:ss ddd");
                    if (row.Cells[1].Value != null)
                    {
                        lbDoorName.Text = (string)row.Cells[1].Value;
                    }
                    else
                    {
                        lbDoorName.Text = "----";
                    }
                    lbAction.Text = AccessHelper.GetRecordReasonString(state.reasonNo).Replace(":", "\r\n");
                }
                else
                {
                    lbTime.Text = ((DateTime)row.Cells[0].Value).ToString("yyyy-MM-dd HH:mm:ss ddd");
                    lbDoorName.Text = "----";
                    lbAction.Text = "----";
                }
            }
            catch (Exception ex)
            {
                log.Error("显示信息异常：", ex);
            }

        }
        private void biStopCurrMap_Click(object sender, EventArgs e)
        {
            if (stcMaps.SelectedTab == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "未有地图被选中！");
                return;
            }
            CloseDetect(stcMaps.SelectedTab);
        }

        private void biDetectAllMap_Click(object sender, EventArgs e)
        {
            foreach (SuperTabItem item in stcMaps.Tabs)
            {
                DoDetectMap(item);
            }
        }

        private void biStopDetectAll_Click(object sender, EventArgs e)
        {
            foreach (SuperTabItem item in stcMaps.Tabs)
            {
                CloseDetect(item);
            }
        }
    }
}
