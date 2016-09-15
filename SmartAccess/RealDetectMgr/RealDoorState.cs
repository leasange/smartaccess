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

namespace SmartAccess.RealDetectMgr
{
    public partial class RealDoorState : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(RealDoorState));
        private List<Maticsoft.Model.SMT_CARD_INFO> _cards = new List<Maticsoft.Model.SMT_CARD_INFO>();
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
            string cardNo = state.cardOrNoNumber;
            if (state!=null)
            {
               var card=  _cards.Find(m => m.CARD_WG_NO == state.cardOrNoNumber);
               if (card!=null)
               {
                   cardNo = card.CARD_NO;
               }
            }
            bool isadd = false;
            foreach (ListViewItem item in listDoors.Items)
            {
                Maticsoft.Model.SMT_DOOR_INFO door = (Maticsoft.Model.SMT_DOOR_INFO)item.Tag;
                if (door.IS_ENABLE&&door.CTRL_ID!=null&&door.CTRL_DOOR_INDEX!=null)
                {
                    if (ctrlr.id!=(decimal)door.CTRL_ID)
                    {
                        continue;
                    }
                    if (!connected||(connected&&state==null))
                    {
                        item.ImageIndex = connected ? 0 : 2;
                        if (!isadd)
                        {
                            isadd = true;
                            DataGridViewRow row = new DataGridViewRow();
                            row.Tag = ctrlr;
                            row.CreateCells(dgvRealLog, DateTime.Now, "控制器：" + ctrlr.ip, string.Format("控制器：IP={0},SN={1} {2}！", ctrlr.ip, ctrlr.sn, connected?"连接成功":"无法连接"));
                            dgvRealLog.Rows.Insert(0, row);
                        }
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
                            DateTime dt=DateTime.Now;
                            if (state.recordTime>dt)
	                        {
		                        dt=state.recordTime.AddSeconds(3);
	                        }
                            row.CreateCells(dgvRealLog, dt, door.DOOR_NAME, string.Format("门禁:{0},卡号：{1},动作：门禁状态改变({2})", door.DOOR_NAME, cardNo, state.relayState[state.doorNum - 1]?"开门":"关门"));
                        }
                        dgvRealLog.Rows.Insert(0, row);
                        item.ImageIndex = state.relayState[state.doorNum - 1] ? 1 : 0;
//                         switch (state.doorNum)
//                         {
//                             case 1: item.ImageIndex = state.isOpenDoorOfLock1 ? 1 : 0;
//                                 break;
//                             case 2:  item.ImageIndex = state.isOpenDoorOfLock2 ? 1 : 0;
//                                 break;
//                             case 3: item.ImageIndex = state.isOpenDoorOfLock3 ? 1 : 0;
//                                 break;
//                             case 4: item.ImageIndex = state.isOpenDoorOfLock4 ? 1 : 0;
//                                 break;
//                             default:
//                                 break;
//                         }
                    }
                    else
                    {
                        item.ImageIndex = state.relayState[(byte)door.CTRL_DOOR_INDEX - 1] ? 1 : 0;
                       
                    }
                }
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
                if (!item.IS_ENABLE)
                {
                    index = 3;
                }
                ListViewItem lvi = new ListViewItem(item.DOOR_NAME, index);
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
        
        private void biRealDetect_Click(object sender, EventArgs e)
        {
            if ( listDoors.SelectedItems.Count==0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择门禁！");
                return;
            }
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = new List<Maticsoft.Model.SMT_DOOR_INFO>();
            foreach (ListViewItem item in listDoors.SelectedItems)
            {
                Maticsoft.Model.SMT_DOOR_INFO d = (Maticsoft.Model.SMT_DOOR_INFO)item.Tag;
                if (d.IS_ENABLE)
                {
                    doors.Add(d);
                }
            }
            var g = doors.GroupBy(m => m.CTRL_ID);
            List<decimal> ctrIds = new List<decimal>();
            foreach (var item in g)
            {
                if (item.ToArray()[0].CTRL_ID==null)
                {
                    continue;
                }
                decimal ctrlId = (decimal)item.ToArray()[0].CTRL_ID;
                ctrIds.Add(ctrlId);
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                Maticsoft.BLL.SMT_CONTROLLER_INFO ctrlBll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
                var models= ctrlBll.GetModelList("ID in ("+ string.Join(",",ctrIds.ToArray()) +")");
                if (models.Count==0)
                {
                    WinInfoHelper.ShowInfoWindow(this,"没有控制器！");
                }
                foreach (var item in models)
	            {
                    UploadPrivate.WatchService.AddController(ControllerHelper.ToController(item), ControllerStateCallBack, this.GetType().FullName);
                }
            });
            waiting.Show(this);
        }
    }
}
