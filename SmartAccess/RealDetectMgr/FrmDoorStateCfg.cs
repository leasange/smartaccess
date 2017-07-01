using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.Datas;
using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using System.Threading;
using DevComponents.DotNetBar.Controls;

namespace SmartAccess.RealDetectMgr
{
    public partial class FrmDoorStateCfg : DevComponents.DotNetBar.Office2007Form
    {
        private List<Maticsoft.Model.SMT_DOOR_INFO> _doors = null;
        private DataGridViewX _dgvX = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmDoorStateCfg));
        public bool IsChanged=false;
        public FrmDoorStateCfg(List<Maticsoft.Model.SMT_DOOR_INFO> doors,DataGridViewX  dgv=null)
        {
            InitializeComponent();
            _doors = doors;
            this.Text = "设置门禁：数目->" +_doors.Count;
            _dgvX = dgv;
        }

        private void FrmDoorStateCfg_Load(object sender, EventArgs e)
        {
            if (_doors == null || _doors.Count == 0)
            {
                return;
            }
            iDelayTime.Value = _doors[0].CTRL_DELAY_TIME;
            switch (_doors[0].CTRL_STYLE)
            {
                case 0: rbOnline.Checked = true; break;
                case 1: rbAlwaysOpen.Checked = true; break;
                case 2: rbAlwaysClose.Checked = true; break;
                default: rbOnline.Checked = true; break;
            }
            foreach (var item in _doors)
            {
                cbIsAllowVisitor.Checked = cbIsAllowVisitor.Checked && item.IS_ALLOW_VISITOR;
            }
        }

        private List<decimal> GetCtrlIds()
        {
            var g = _doors.GroupBy(m => m.CTRL_ID);
            List<decimal> ctrlIds = new List<decimal>();
            foreach (var item in g)
            {
                decimal? id = item.ToList()[0].CTRL_ID;
                if (id == null)
                {
                    continue;
                }
                ctrlIds.Add((decimal)id);
            }
            return ctrlIds;
        }

        private void btnApplyState_Click(object sender, EventArgs e)
        {
            List<decimal> ids = GetCtrlIds();
            bool isAllowVisitor=cbIsAllowVisitor.Checked;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    List<decimal> visitorIds = new List<decimal>();
                    foreach (var item in _doors)
                    {
                        if (item.IS_ALLOW_VISITOR!=isAllowVisitor)
                        {
                            visitorIds.Add(item.ID);
                        }
                    }
                    if (visitorIds.Count>0)
                    {
                        Maticsoft.DBUtility.DbHelperSQL.Query("update SMT_DOOR_INFO set IS_ALLOW_VISITOR=" + (isAllowVisitor ? 1 : 0) + " where ID in (" + string.Join(",", visitorIds.ToArray()) + ")");
                        WinInfoHelper.ShowInfoWindow(this.Parent, "更新访客状态正常！");
                        foreach (var item in _doors)
                        {
                            item.IS_ALLOW_VISITOR = isAllowVisitor;
                        }
                    }

                    Maticsoft.BLL.SMT_CONTROLLER_INFO ctrlBLL = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
                    var ctrls = ctrlBLL.GetModelList("ID in (" + string.Join(",", ids) + ")");
                    DoorControlStyle style = DoorControlStyle.Online;
                    if (rbOnline.Checked)
                    {
                        style = DoorControlStyle.Online;
                    }
                    else if (rbAlwaysOpen.Checked)
                    {
                        style = DoorControlStyle.AlwaysOpen;
                    }
                    else if (rbAlwaysClose.Checked)
                    {
                        style = DoorControlStyle.AlwaysClose;
                    }
                    List<ManualResetEvent> resetEvents = new List<ManualResetEvent>();
                    foreach (var item in ctrls)
                    {
                        var doors = _doors.FindAll(m => m.CTRL_ID == item.ID);
                        if (doors.Count == 0)
                        {
                            continue;
                        }
                        ManualResetEvent evt = new ManualResetEvent(false);
                        resetEvents.Add(evt);
                        ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                        {
                            try
                            {
                                var c = ControllerHelper.ToController(item);
                                IAccessCore acc = new WGAccess();
                                foreach (var d in doors)
                                {
                                    if (d.CTRL_DOOR_INDEX == null)
                                    {
                                        continue;
                                    }
                                    string temp = "在线";
                                    switch (style)
                                    {
                                        case DoorControlStyle.Online:
                                            temp = "在线";
                                            break;
                                        case DoorControlStyle.AlwaysOpen:
                                            temp = "常开";
                                            break;
                                        case DoorControlStyle.AlwaysClose:
                                            temp = "常关";
                                            break;
                                        default:
                                            break;
                                    }
                                    bool ret = acc.SetDoorControlStyle(c, (int)d.CTRL_DOOR_INDEX, style, iDelayTime.Value);
                                    if (!ret)
                                    {
                                        this.Invoke(new Action(() =>
                                        {
	                                        if (_dgvX!=null)
	                                        {
	                                            DataGridViewRow row = new DataGridViewRow();
	                                            row.CreateCells(_dgvX, DateTime.Now, d.DOOR_NAME, "设置门禁失败！控制器IP=" + item.IP + ",SN=" + item.SN_NO + ",门禁：" + d.DOOR_NAME);
	                                            _dgvX.Rows.Insert(0, row);
	                                            row.Selected = true;
	                                        }
                                        }));
                                        WinInfoHelper.ShowInfoWindow(this.Parent, "设置门禁失败！控制器IP=" + item.IP + ",SN=" + item.SN_NO + ",门禁：" + d.DOOR_NAME);
                                        continue;
                                    }
                                    else
                                    {
                                        Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
                                        d.CTRL_DELAY_TIME = iDelayTime.Value;
                                        d.CTRL_STYLE = (int)style;
                                        doorBll.Update(d);
                                        IsChanged = true;
                                        this.Invoke(new Action(() =>
                                        {
                                            if (_dgvX != null)
                                            {
                                                DataGridViewRow row = new DataGridViewRow();
                                                row.CreateCells(_dgvX, DateTime.Now, d.DOOR_NAME, "设置门禁：" + d.DOOR_NAME + " " + temp + "状态,时间" + iDelayTime.Value + "秒成功！");
                                                _dgvX.Rows.Insert(0, row);
                                                row.Selected = true;
                                            }
                                        }));
                                        WinInfoHelper.ShowInfoWindow(this.Parent, "设置门禁：" + d.DOOR_NAME + " " + temp + "状态,时间" + iDelayTime.Value + "秒成功！");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                log.Error("设置门禁发生异常：", ex);
                                this.Invoke(new Action(() =>
                                {
                                    if (_dgvX != null)
                                    {
                                        DataGridViewRow row = new DataGridViewRow();
                                        row.CreateCells(_dgvX, DateTime.Now, "", "设置门禁发生异常！控制器IP=" + item.IP + ",SN=" + item.SN_NO + ",异常信息：" + ex.Message);
                                        _dgvX.Rows.Insert(0, row);
                                        row.Selected = true;
                                    }
                                }));
                                WinInfoHelper.ShowInfoWindow(this.Parent, "设置门禁发生异常！控制器IP=" + item.IP + ",SN=" + item.SN_NO + ",异常信息：" + ex.Message);
                            }
                            finally
                            {
                                evt.Set();
                            }
                        }));
                    }
                    foreach (var item in resetEvents)
                    {
                        item.WaitOne(15000);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("设置门禁发生异常1：", ex);
                    WinInfoHelper.ShowInfoWindow(this.Parent, "设置门禁发生异常!");
                }
                finally
                {
                    this.Invoke(new Action(() =>
                    {
                        this.Close();
                    }));
                }
            });
            waiting.Show(this);
        }
    }
}
