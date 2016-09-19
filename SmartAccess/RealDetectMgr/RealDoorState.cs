using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using Li.Access.Core;
using System.Threading;

namespace SmartAccess.RealDetectMgr
{
    public partial class RealDoorState : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(RealDoorState));
        private List<Maticsoft.Model.SMT_CARD_INFO> _cards = new List<Maticsoft.Model.SMT_CARD_INFO>();
        private List<ListViewItem> _lastDetectDoorItems = new List<ListViewItem>();
        public RealDoorState()
        {
            InitializeComponent();
        }
        private void ControllerStateCallBack(Controller ctrlr, bool connected, ControllerState state, bool doorstate)
        {
            try
            {
                lock (this)
                {
                    this.Invoke(new Action(() =>
                    {
                        AddWatchData(ctrlr, connected, state, doorstate);
                    }));
                }
            }
            catch (Exception)
            {
            }

        }

        private void AddWatchData(Controller ctrlr, bool connected, ControllerState state, bool doorstate)
        {
            string cardNo = null;
            if (state != null)
            {
                cardNo = state.cardOrNoNumber;
                var card = _cards.Find(m => m.CARD_WG_NO == state.cardOrNoNumber);
                if (card != null)
                {
                    cardNo = card.CARD_NO;
                }
            }
            foreach (ListViewItem item in _lastDetectDoorItems)
            {
                Maticsoft.Model.SMT_DOOR_INFO door = (Maticsoft.Model.SMT_DOOR_INFO)item.Tag;
                if (door.IS_ENABLE && door.CTRL_ID != null && door.CTRL_DOOR_INDEX != null)
                {
                    if (ctrlr.id != (decimal)door.CTRL_ID)
                    {
                        continue;
                    }
                    if (!connected || state == null)
                    {
                        item.ImageIndex = connected ? 0 : 2;
                        DataGridViewRow row = new DataGridViewRow();
                        row.Tag = ctrlr;
                        row.CreateCells(dgvRealLog, DateTime.Now, door.DOOR_NAME, string.Format("控制器：IP={0},SN={1} {2}！", ctrlr.ip, ctrlr.sn, connected ? "连接成功" : "无法连接"));
                        dgvRealLog.Rows.Insert(0, row);
                    }
                    else if ((byte)door.CTRL_DOOR_INDEX == state.doorNum)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.Tag = state;
                        if (!doorstate)
                        {
                            row.CreateCells(dgvRealLog, state.recordTime, door.DOOR_NAME, string.Format("门禁:{0},卡号：{1},动作：{2}", door.DOOR_NAME, cardNo, AccessHelper.GetRecordReasonString(state.reasonNo)));
                        }
                        else
                        {
                            DateTime dt = DateTime.Now;
                            if (state.recordTime > dt)
                            {
                                dt = state.recordTime.AddSeconds(3);
                            }
                            row.CreateCells(dgvRealLog, dt, door.DOOR_NAME, string.Format("门禁:{0},卡号：{1},动作：门禁状态改变({2})", door.DOOR_NAME, cardNo, state.relayState[state.doorNum - 1] ? "开门" : "关门"));
                        }
                        dgvRealLog.Rows.Insert(0, row);
                        item.ImageIndex = state.relayState[state.doorNum - 1] ? 1 : 0;
                    }
                    else
                    {
                        item.ImageIndex = state.relayState[(byte)door.CTRL_DOOR_INDEX - 1] ? 1 : 0;

                    }
                }
            }
            foreach (DataGridViewRow item in dgvRealLog.SelectedRows)
            {
                item.Selected = false;
            }
            if (dgvRealLog.Rows.Count>0)
            {
                dgvRealLog.Rows[0].Selected = true;
            }
        }

        private void RealDoorState_Load(object sender, EventArgs e)
        {
            InitDoors();
        }

        protected override void DestroyHandle()
        {
            UploadPrivate.WatchService.ClearControllers(this.GetType().FullName);
            base.DestroyHandle();
        }

        private void InitDoors()
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    var doors = DoorDataHelper.GetDoors();
                    Maticsoft.BLL.SMT_CARD_INFO cardBll = new Maticsoft.BLL.SMT_CARD_INFO();
                    _cards = cardBll.GetModelList("");
                    this.Invoke(new Action(() =>
                    {
                        AddDoorsToView(doors);
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载门禁异常！"+ex.Message);
                    log.Error("加载门禁异常：", ex);
                }

            });
            waiting.Show(this,200);
        }
        private string GetDoorText(Maticsoft.Model.SMT_DOOR_INFO door)
        {
            string text = door.DOOR_NAME;
            if (!door.IS_ENABLE)
            {
                text += "(禁用)";
            }
            else
            {
                if (door.CTRL_STYLE==1)
                {
                    text += "(常开)";
                }
                else if (door.CTRL_STYLE==2)
                {
                    text += "(常关)";
                }
            }
            return text;
        }
        private void AddDoorsToView(List<Maticsoft.Model.SMT_DOOR_INFO> doors)
        {
            listDoors.Items.Clear();
            if (doors==null||doors.Count==0)
            {
                return;
            }
            foreach (var item in doors)
            {
                int index = item.OPEN_STATE;
                if (index<0||index>2)
                {
                    index = 0;
                }
                if (item.CTRL_STYLE==1)
                {
                    index = 1;
                }
                if (!item.IS_ENABLE)
                {
                    index = 3;
                }
                ListViewItem lvi = new ListViewItem(GetDoorText(item), index);
                lvi.Tag = item;
                lvi.ToolTipText = item.DOOR_NAME + "," + (item.IS_ENABLE ? "启用" : "未启用") + "";
                listDoors.Items.Add(lvi);
            }
        }

        private void biSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listDoors.Items)
            {
                item.Selected = true;
            }
        }

        private List<Maticsoft.Model.SMT_DOOR_INFO> GetSelectDoors()
        {
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = new List<Maticsoft.Model.SMT_DOOR_INFO>();
            if (listDoors.SelectedItems.Count == 0)
            {
                return doors;
            }
            
            foreach (ListViewItem item in listDoors.SelectedItems)
            {
                Maticsoft.Model.SMT_DOOR_INFO d = (Maticsoft.Model.SMT_DOOR_INFO)item.Tag;
                if (d.IS_ENABLE)
                {
                    doors.Add(d);
                }
            }
            return doors;
        }

        private List<decimal> GetSelectCtrlIDs(List<Maticsoft.Model.SMT_DOOR_INFO> doors)
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

        private List<Maticsoft.Model.SMT_CONTROLLER_INFO> GetSelectCtrls(List<decimal> ctrIds)
        {
            Maticsoft.BLL.SMT_CONTROLLER_INFO ctrlBll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
            var models = ctrlBll.GetModelList("ID in (" + string.Join(",", ctrIds.ToArray()) + ")");
            return models;
        }

        private void biRealDetect_Click(object sender, EventArgs e)
        {
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = GetSelectDoors();
            _lastDetectDoorItems.Clear();
            foreach (ListViewItem item in listDoors.SelectedItems)
            {
                Maticsoft.Model.SMT_DOOR_INFO d = (Maticsoft.Model.SMT_DOOR_INFO)item.Tag;
                if (d.IS_ENABLE)
                {
                    _lastDetectDoorItems.Add(item);
                }
            }
            if (doors.Count==0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择门禁！");
                return;
            }
            List<decimal> ctrIds = GetSelectCtrlIDs(doors);
          
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                var models = GetSelectCtrls(ctrIds);
                if (models.Count==0)
                {
                    WinInfoHelper.ShowInfoWindow(this,"未找到控制器！");
                    return;
                }
                foreach (var item in models)
	            {
                    UploadPrivate.WatchService.AddController(ControllerHelper.ToController(item), ControllerStateCallBack, this.GetType().FullName);
                }
                this.Invoke(new Action(() =>
                {
                    biRealDetect.Text = "实时监控中...";
                    biRealDetect.Enabled = false;
                }));
            });
            waiting.Show(this);
        }

        private void biStop_Click(object sender, EventArgs e)
        {
            UploadPrivate.WatchService.ClearControllers(this.GetType().FullName);
            biRealDetect.Text = "实时监控";
            biRealDetect.Enabled = true;
        }

        private void biDetectCtrlr_Click(object sender, EventArgs e)
        {
            dgvRealLog.ClearSelection();
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = GetSelectDoors();
            List<ListViewItem> items=new List<ListViewItem>();
            foreach (ListViewItem item in listDoors.SelectedItems)
	        {
                items.Add(item);
            }
           
            if (doors.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择门禁！");
                return;
            }
            List<decimal> ctrIds = GetSelectCtrlIDs(doors);
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                var models = GetSelectCtrls(ctrIds);
                if (models.Count == 0)
                {
                    WinInfoHelper.ShowInfoWindow(this, "未找到控制器！");
                    return;
                }
                List<ManualResetEvent> events = new List<ManualResetEvent>();
                foreach (var item in models)
                {
                    ManualResetEvent evt=new ManualResetEvent(false);
                    events.Add(evt);
                    ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                    {
                            Maticsoft.Model.SMT_CONTROLLER_INFO cinfo = item;
                            Controller c = ControllerHelper.ToController(item);
                            bool isconnect = false;
                         ControllerState state =null;
                            try
                            {
                                IAccessCore acc = new Li.Access.Core.WGAccesses.WGAccess();
                               state= acc.GetControllerState(c);
                                if (state==null)
                                {
                                    throw new Exception("通信不上");
                                }
                                isconnect = true;
                            }
                            catch(Exception ex)
                            {
                                isconnect = false;
                            }
                            finally
                            {
                                lock (items)
                                {
                                    this.Invoke(new Action(() =>
                                              {
                                                  foreach (var it in items)
                                                  {
                                                      Maticsoft.Model.SMT_DOOR_INFO door = (Maticsoft.Model.SMT_DOOR_INFO)it.Tag;
                                                      if (door.CTRL_ID == null || !door.IS_ENABLE)
                                                      {
                                                          continue;
                                                      }
                                                      if (door.CTRL_ID == c.id)
                                                      {
                                                          if (state==null||!isconnect)
                                                          {
                                                              it.ImageIndex = 2;
                                                          }
                                                          else
                                                          {
                                                              it.ImageIndex = state.relayState[(int)door.CTRL_DOOR_INDEX - 1] ? 1 : 0;
                                                          }
                                                          DateTime dt = DateTime.Now;
                                                          DataGridViewRow row = new DataGridViewRow();
                                                          row.CreateCells(dgvRealLog, dt, door.DOOR_NAME, string.Format("控制器通信{0}：IP={1},SN={2}", isconnect ? "正常" : "不上", cinfo.IP, cinfo.SN_NO));
                                                          dgvRealLog.Rows.Insert(0, row);
                                                          row.Selected = true;
                                                      }
                                                  }
                                              }));
                                }
                                evt.Set();
                            }
                        }));
                }
                foreach (var item in events)
                {
                    item.WaitOne(15000);
                }
            });
            waiting.Show(this);
        }

        private void biAdjustTime_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定校准选择门禁的时间？","提示",MessageBoxButtons.OKCancel)==DialogResult.Cancel)
            {
                return;
            }
            dgvRealLog.ClearSelection();
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = GetSelectDoors();
            List<ListViewItem> items = new List<ListViewItem>();
            foreach (ListViewItem item in listDoors.SelectedItems)
            {
                items.Add(item);
            }

            if (doors.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择门禁！");
                return;
            }
            List<decimal> ctrIds = GetSelectCtrlIDs(doors);
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                var models = GetSelectCtrls(ctrIds);
                if (models.Count == 0)
                {
                    WinInfoHelper.ShowInfoWindow(this, "未找到控制器！");
                    return;
                }
                List<ManualResetEvent> events = new List<ManualResetEvent>();
                foreach (var item in models)
                {
                    ManualResetEvent evt = new ManualResetEvent(false);
                    events.Add(evt);
                    ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                    {
                        Maticsoft.Model.SMT_CONTROLLER_INFO cinfo = item;
                        Controller c = ControllerHelper.ToController(item);
                        bool isconnect = false;
                        bool succeed = false;
                        try
                        {
                            IAccessCore acc = new Li.Access.Core.WGAccesses.WGAccess();
                            succeed = acc.SetControllerTime(c, DateTime.Now);
                            if (!succeed)
                            {
                                throw new Exception("通信不上");
                            }
                            isconnect = true;
                        }
                        catch (Exception ex)
                        {
                            isconnect = false;
                        }
                        finally
                        {
                            lock (items)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    foreach (var it in items)
                                    {
                                        Maticsoft.Model.SMT_DOOR_INFO door = (Maticsoft.Model.SMT_DOOR_INFO)it.Tag;
                                        if (door.CTRL_ID == null || !door.IS_ENABLE)
                                        {
                                            continue;
                                        }
                                        if (door.CTRL_ID == c.id)
                                        {
                                            it.ImageIndex = 2;
                                            DateTime dt = DateTime.Now;
                                            DataGridViewRow row = new DataGridViewRow();
                                            if (!isconnect)
                                            {
                                                row.CreateCells(dgvRealLog, dt, door.DOOR_NAME, string.Format("校准时间{0}，控制器通信{1}：IP={2},SN={3}", succeed ? "成功" : "失败", isconnect ? "正常" : "不上", cinfo.IP, cinfo.SN_NO));
                                            }
                                            else
                                            {
                                                row.CreateCells(dgvRealLog, dt, door.DOOR_NAME, string.Format("校准时间{0}", succeed ? "失败" : "成功"));
                                            }
                                            dgvRealLog.Rows.Insert(0, row);
                                            row.Selected = true;
                                        }
                                    }
                                }));
                            }
                            evt.Set();
                        }
                    }));
                }
                foreach (var item in events)
                {
                    item.WaitOne(15000);
                }
            });
            waiting.Show(this);
        }

        private void biClearInfo_Click(object sender, EventArgs e)
        {
            dgvRealLog.Rows.Clear();
        }

        private void tsmiDoorStateCfg_Click(object sender, EventArgs e)
        {
            var doors = GetSelectDoors();
            if (doors.Count==0)
            {
                foreach (ListViewItem item in listDoors.Items)
                {
                    item.Selected = true;
                }
            }
            doors = GetSelectDoors();
            FrmDoorStateCfg cfg = new FrmDoorStateCfg(doors,dgvRealLog);
            cfg.ShowDialog(this);
            if (cfg.IsChanged)
            {
                foreach (ListViewItem item in listDoors.SelectedItems)
                {
                    Maticsoft.Model.SMT_DOOR_INFO door = (Maticsoft.Model.SMT_DOOR_INFO)item.Tag;
                    item.Text = GetDoorText(door);
                    int index = door.OPEN_STATE;
                    if (index < 0 || index > 2)
                    {
                        index = 0;
                    }
                    if (door.CTRL_STYLE == 1)
                    {
                        index = 1;
                    }
                    if (!door.IS_ENABLE)
                    {
                        index = 3;
                    }
                    item.ImageIndex = index;
                }
            }
        }

        private void biSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFilterItem.Text))
            {
                WinInfoHelper.ShowInfoWindow(this, "请输入查询信息！");
            }
            string filter = tbFilterItem.Text.Trim();
            foreach (ListViewItem item in listDoors.Items)
            {
                if (item.Text.Contains(filter))
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }
        }

        private void biUploadSetting_Click(object sender, EventArgs e)
        {

        }
    }
}
