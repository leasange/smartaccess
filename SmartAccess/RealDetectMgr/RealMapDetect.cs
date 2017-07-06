using System;
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
            return mapCtrl;
        }

        private List<Maticsoft.Model.SMT_DOOR_INFO> GetDoors(MapCtrl mapCtrl)
        {
            Maticsoft.Model.SMT_MAP_INFO mapInfo = (Maticsoft.Model.SMT_MAP_INFO)mapCtrl.Tag;
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = new List<Maticsoft.Model.SMT_DOOR_INFO>();
            if (mapInfo.MAP_DOORS == null || mapInfo.MAP_DOORS.Count == 0)
            {
                return doors;
            }
            foreach (var item in mapInfo.MAP_DOORS)
            {
                if (!item.DOOR.IS_ENABLE || item.DOOR.CTRL_ID == null || item.DOOR.CTRL_DOOR_INDEX == null)
                {
                    continue;
                }

                if(DoorDataHelper.LastDoors!=null)
                {
                    if(DoorDataHelper.LastDoors.Exists(m=>m.ID==item.DOOR.ID))
                    {
                        doors.Add(item.DOOR);
                    }
                }
                else{
                     doors.Add(item.DOOR);
                }
            }
            return doors;
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
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = GetDoors(mapCtrl);
            if (doors.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "地图中门禁状态不可用！");
                return;
            }
            List<decimal> ctrlIds = GetCtrlIDs(doors);
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                var models = GetCtrls(ctrlIds);
                if (models.Count == 0)
                {
                    WinInfoHelper.ShowInfoWindow(this, "未找到控制器！");
                    return;
                }
                _detectedMaps.Add(mapCtrl);
                foreach (var model in models)
                {
                    UploadPrivate.WatchService.AddController(ControllerHelper.ToController(model), ControllerStateCallBack, this.GetType().FullName);
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
                    var doors = GetDoors(mapCtrl);
                    var ctrlIds = GetCtrlIDs(doors);
                    item.Text = mapCtrl.MapName;
                    foreach (var it in _detectedMaps)
                    {
                        if (it == item.AttachedControl.Controls[0])
                        {
                            continue;
                        }
                        var doorsFind = GetDoors((MapCtrl)it);
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
                            this.Invoke(new Action(() =>
                            {
                                AddWatchData(ctrlr, connected, state, doorstate,relaystate);
                            }));
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
        private void AddWatchData(Controller ctrlr, bool connected, ControllerState state, bool doorstate,bool relaystate)
        {
            foreach (MapCtrl item in _detectedMaps)
            {
                var doors = GetDoors(item);
                foreach (var door in doors)
                {
                    if ((decimal)door.CTRL_ID != ctrlr.id)
                    {
                        continue;
                    }
                    var doorRect = item.GetDoor(door.ID);
                    if (doorRect == null)
                    {
                        continue;
                    }
                    doorRect.IsOnline = connected;
                    if (state != null)
                    {
                        int doorIndex = (int)door.CTRL_DOOR_INDEX;
                        switch (doorIndex)
                        {
                            case 1:
                                doorRect.IsOpen = state.isOpenDoorOfLock1;
                                door.OPEN_STATE = state.isOpenDoorOfLock1 ? 1 : 0;
                                break;
                            case 2:
                                doorRect.IsOpen = state.isOpenDoorOfLock2;
                                door.OPEN_STATE = state.isOpenDoorOfLock2 ? 1 : 0;
                                break;
                            case 3:
                                doorRect.IsOpen = state.isOpenDoorOfLock3;
                                door.OPEN_STATE = state.isOpenDoorOfLock3 ? 1 : 0;
                                break;
                            case 4:
                                doorRect.IsOpen = state.isOpenDoorOfLock4;
                                door.OPEN_STATE = state.isOpenDoorOfLock4 ? 1 : 0;
                                break;
                            default:
                                break;
                        }
                        DoorDataHelper.UpdateDoorSync(door);
                    }
                    else if (!connected)
                    {
                        door.OPEN_STATE = 2;
                        DoorDataHelper.UpdateDoorSync(door);
                    }
                  
                }
                item.Invalidate();
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
