using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Li.SmartAcsServer.PrivateService
{
    public class AutoAccessTaskService
    {

        private static AutoAccessTaskService _instance = null;
        public static AutoAccessTaskService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AutoAccessTaskService();
                }
                return _instance;
            }
        }
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(AutoAccessTaskService));
        private System.Timers.Timer timerCheckAutoAccessState = new System.Timers.Timer(10000);
        private System.Timers.Timer timerGetAutoAccessData = new System.Timers.Timer(5000);
        private bool serverState = false;
        protected AutoAccessTaskService()
        {
            timerCheckAutoAccessState.Elapsed += timerCheckAutoAccessState_Elapsed;
            timerGetAutoAccessData.Elapsed += timerGetAutoAccessData_Elapsed;
        }
        private Controller ToController(Maticsoft.Model.SMT_CONTROLLER_INFO ctrl)
        {
            Controller ctl = new Controller();
            ctl.id = ctrl.ID;
            ctl.sn = ctrl.SN_NO;
            ctl.ip = ctrl.IP;
            ctl.port = ctrl.PORT == null ? 60000 : (int)ctrl.PORT;
            if (ctl.port <= 0 || ctl.port > 65535)
            {
                ctl.port = 60000;
            }
            ctl.mac = ctrl.MAC;
            ctl.mask = ctrl.MASK;
            ctl.model = ctrl.CTRLR_MODEL;
            ctl.gateway = ctrl.GATEWAY;
            return ctl;
        }
        public void Start()
        {
            log.Info("启动自动授权服务...");
            timerCheckAutoAccessState.Start();
        }
        private void timerCheckAutoAccessState_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                Maticsoft.BLL.SMT_DATADICTIONARY_INFO dicBll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                var model = dicBll.GetModel("SYSTEM_CONFIG", "AUTO_ACCESS");
                if (model != null)
                {
                    serverState = bool.Parse(model.DATA_VALUE);
                    if (timerGetAutoAccessData.Enabled != serverState)
                    {
                        timerGetAutoAccessData.Enabled = serverState;
                        log.Info("自动授权服务:" + (serverState ? "启动" : "停止"));
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("读取自动授权状态异常：" + ex.Message);
            }

        }
        class AutoCtrler
        {
            public Maticsoft.Model.SMT_AUTO_ACCESS_RECORD record;
            public Maticsoft.Model.SMT_DOOR_INFO door;
            public List<Maticsoft.Model.SMT_STAFF_CARD> cards;
        }
        private void timerGetAutoAccessData_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //记录状态：0 等待授权，9 取消授权
            try
            {
                log.Info("开始读取自动授权信息...");
                timerGetAutoAccessData.Stop();
                Maticsoft.BLL.SMT_AUTO_ACCESS accBll = new Maticsoft.BLL.SMT_AUTO_ACCESS();
                Maticsoft.BLL.SMT_AUTO_ACCESS_RECORD accrBll = new Maticsoft.BLL.SMT_AUTO_ACCESS_RECORD();
                Maticsoft.BLL.SMT_STAFF_DOOR staffdoorBll = new Maticsoft.BLL.SMT_STAFF_DOOR();
                Maticsoft.BLL.SMT_CONTROLLER_INFO ctrlBll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
                Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
                Maticsoft.BLL.SMT_STAFF_CARD scardBll = new Maticsoft.BLL.SMT_STAFF_CARD();

                //获取临时授权列表
                var accList = accBll.GetModelList("");
                //取消授权
                List<Maticsoft.Model.SMT_AUTO_ACCESS> cancelAccList = new List<Maticsoft.Model.SMT_AUTO_ACCESS>();

                accList.RemoveAll(m =>
                {
                    if (m.ACC_STATE == (int)AccessState.RequestCancel)
                    {
                        cancelAccList.Add(m);
                        return true;
                    }
                    return false;
                });

                if (cancelAccList.Count > 0)
                {//删除临时表数据
                    var dcList = new List<Maticsoft.Model.SMT_AUTO_ACCESS>();
                    cancelAccList.ForEach(cm =>
                        {
                            var find = accList.Find(m =>
                             m.ACC_APP_ID == cm.ACC_APP_ID &&
                             m.ACC_DOOR_ID == cm.ACC_DOOR_ID &&
                             m.ACC_STAFF_ID == cm.ACC_STAFF_ID &&
                             m.ACC_FROM_SYS == cm.ACC_FROM_SYS &&
                             m.ACC_STATE == (int)AccessState.Init);//查找同一条记录
                            if (find != null)
                            {
                                accBll.DeleteList(cm.ID + "," + find.ID);
                                accList.Remove(find);
                                dcList.Add(cm);
                                accrBll.Add(new Maticsoft.Model.SMT_AUTO_ACCESS_RECORD()
                                {//添加取消记录
                                    ACC_FROM_SYS = cm.ACC_FROM_SYS,
                                    ACC_APP_ID = cm.ACC_APP_ID,
                                    ACC_APP_NAME = cm.ACC_APP_NAME,
                                    ACC_STAFF_ID = cm.ACC_STAFF_ID,
                                    ACC_DOOR_ID = cm.ACC_DOOR_ID,
                                    ACC_START_TIME = cm.ACC_START_TIME,
                                    ACC_END_TIME = cm.ACC_END_TIME,
                                    ACC_ADD_TIME = cm.ACC_ADD_TIME,
                                    ACC_STATE_TIME = DateTime.Now,
                                    ACC_STATE = (int)AccessState.Canceled
                                });
                            }
                        });
                    dcList.ForEach(m => cancelAccList.Remove(m));
                }
                //保存已授权需取消权限的对象
                List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD> delRecords = new List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD>();

                //请求删除的对象进行处理
                if (cancelAccList.Count > 0)
                {//删除记录表数据
                    cancelAccList.ForEach(m =>
                    {
                        var accrModels = accrBll.GetModelList(
                              "ACC_FROM_SYS='" + m.ACC_FROM_SYS + "' and " +
                              "ACC_APP_ID='" + m.ACC_APP_ID + "' and " +
                              "ACC_STAFF_ID=" + m.ACC_STAFF_ID + " and " +
                              "ACC_DOOR_ID=" + m.ACC_DOOR_ID
                              );
                        if (accrModels != null && accrModels.Count > 0)
                        {
                            var accrModel = accrModels[0];

                            if (accrModels.Count > 1)
                            {//删除无用数据,防止多条记录
                                string ids = "";
                                for (int i = 1; i < accrModels.Count; i++)
                                {
                                    ids += accrModels[i].ID + ",";
                                }
                                ids = ids.TrimEnd(',');
                                accrBll.DeleteList(ids);
                            }

                            if (accrModel.ACC_STATE != (int)AccessState.Private)
                            {
                                accrModel.ACC_STATE = (int)AccessState.Canceled;
                                accrModel.ACC_STATE_TIME = DateTime.Now;
                                accrBll.Update(accrModel);
                            }
                            else
                            {
                                delRecords.Add(accrModel);
                            }
                        }
                        accBll.Delete(m.ID);
                    });
                }

                if (accList.Count > 0)
                {//建立授权
                    DateTime now = DateTime.Now;
                    accList.ForEach(m =>
                    {
                        if (m.ACC_END_TIME <= now)
                        {
                            log.Warn(m.ACC_FROM_SYS + "," + m.ACC_APP_ID + "," + m.ACC_STAFF_ID + "," + m.ACC_DOOR_ID + " 无效自动授权对象，时间已过期！");
                        }
                        else
                        {
                            accrBll.Add(new Maticsoft.Model.SMT_AUTO_ACCESS_RECORD()
                            {
                                ACC_FROM_SYS = m.ACC_FROM_SYS,
                                ACC_APP_ID = m.ACC_APP_ID,
                                ACC_APP_NAME = m.ACC_APP_NAME,
                                ACC_STAFF_ID = m.ACC_STAFF_ID,
                                ACC_DOOR_ID = m.ACC_DOOR_ID,
                                ACC_START_TIME = m.ACC_START_TIME,
                                ACC_END_TIME = m.ACC_END_TIME,
                                ACC_ADD_TIME = m.ACC_ADD_TIME,
                                ACC_STATE_TIME = DateTime.Now,
                                ACC_STATE = (int)AccessState.Init
                            });
                        }

                        accBll.Delete(m.ID);
                    });
                }

                var accrPrivateList = accrBll.GetModelList("ACC_STATE=1 and ACC_END_TIME <= DateAdd(mi,-1,convert(varchar,getdate(),120))");//获取已授权，但过期的门禁
                accrPrivateList.ForEach(m =>
                    {
                        m.ACC_STATE = (int)AccessState.PrivateExpire;
                    });

                //获取5min钟内的数据
                var accrList = accrBll.GetModelList("ACC_STATE=0 and ACC_START_TIME <= DateAdd(mi,5,convert(varchar,getdate(),120))");//获取所有待授权的对象

                List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD> accrAllList = new List<Maticsoft.Model.SMT_AUTO_ACCESS_RECORD>(delRecords);
                accrAllList.AddRange(accrPrivateList);
                accrAllList.AddRange(accrList);

                if (accrAllList.Count == 0)
                {
                    return;
                }

                var accDoorIdGroups = accrAllList.GroupBy(m => m.ACC_DOOR_ID);
                string doorIds = "";
                foreach (var g in accDoorIdGroups)
                {
                    doorIds += g.Key + ",";
                }
                doorIds = doorIds.TrimEnd(',');

                var doors = doorBll.GetModelList("ID in (" + doorIds + ")");
                List<Maticsoft.Model.SMT_CONTROLLER_INFO> ctrls = new List<Maticsoft.Model.SMT_CONTROLLER_INFO>();
                if (doors.Count != 0)
                {
                    var ctrlsGroup = doors.GroupBy(m => m.CTRL_ID);
                    string ctrlIds = "";
                    foreach (var g in ctrlsGroup)
                    {
                        ctrlIds += g.Key + ",";
                    }
                    ctrlIds = ctrlIds.TrimEnd(',');
                    ctrls = ctrlBll.GetModelList("ID in (" + ctrlIds + ")");
                }
                if (doors.Count == 0 || ctrls.Count == 0)
                {
                    //无效数据
                    accrAllList.ForEach(m =>
                        {
                            if (m.ACC_STATE == (int)AccessState.Private)
                            {
                                m.ACC_STATE = (int)AccessState.Canceled;
                                staffdoorBll.Delete(m.ACC_STAFF_ID, m.ACC_DOOR_ID);
                            }
                            else if (m.ACC_STATE == (int)AccessState.PrivateExpire)
                            {
                                staffdoorBll.Delete(m.ACC_STAFF_ID, m.ACC_DOOR_ID);
                            }
                            else
                            {
                                m.ACC_STATE = (int)AccessState.PrivateError;
                            }
                            m.ACC_STATE_TIME = DateTime.Now;
                            accrBll.Update(m);
                        });
                    return;
                }

                Dictionary<Controller, List<AutoCtrler>> ctrlerDic = new Dictionary<Controller, List<AutoCtrler>>();

                accrAllList.ForEach(m =>
                {
                    var door = doors.Find(d => d.ID == m.ACC_DOOR_ID);
                    var cards = new List<Maticsoft.Model.SMT_STAFF_CARD>();
                    Maticsoft.Model.SMT_CONTROLLER_INFO ctrl = null;
                    if (door != null)
                    {
                        cards = scardBll.GetModelListWithCardNo("STAFF_ID=" + m.ACC_STAFF_ID);
                        if (cards.Count > 0)
                        {
                            ctrl = ctrls.Find(c => c.ID == door.CTRL_ID);
                        }
                    }
                    if (door == null || cards.Count == 0 || ctrl == null)
                    {
                        if (m.ACC_STATE == (int)AccessState.Private)
                        {
                            m.ACC_STATE = (int)AccessState.Canceled;
                            staffdoorBll.Delete(m.ACC_STAFF_ID, m.ACC_DOOR_ID);
                        }
                        else if (m.ACC_STATE == (int)AccessState.PrivateExpire)
                        {
                            staffdoorBll.Delete(m.ACC_STAFF_ID, m.ACC_DOOR_ID);
                        }
                        else
                        {
                            m.ACC_STATE = (int)AccessState.PrivateError;
                        }
                        m.ACC_STATE_TIME = DateTime.Now;
                        accrBll.Update(m);
                        return;
                    }
                    Controller ctl = ToController(ctrl);
                    if (!ctrlerDic.ContainsKey(ctl))
                    {
                        var list = new List<AutoCtrler>();
                        list.Add(new AutoCtrler()
                        {
                            record = m,
                            door = door,
                            cards = cards

                        });
                        ctrlerDic.Add(ctl, list);
                    }
                    else
                    {
                        ctrlerDic[ctl].Add(new AutoCtrler()
                        {
                            record = m,
                            door = door,
                            cards = cards

                        });
                    }
                });

                //开始执行处理
                List<ManualResetEvent> evts = new List<ManualResetEvent>();
                foreach (var kv in ctrlerDic)
                {
                    ManualResetEvent evt = new ManualResetEvent(false);
                    evts.Add(evt);
                    Thread th = new Thread(new ThreadStart(() =>
                    {
                        try
                        {
                            var ctrl = kv.Key;
                            var acList = kv.Value;

                            bool exp = false;
                            using (IAccessCore access = new WGAccess())
                            {
                                //所有都是一个控制器
                                var gStaff = acList.GroupBy(m => m.record.ACC_STAFF_ID);//对人进行分组
                                foreach (var gs in gStaff)
                                {
                                    List<AutoCtrler> acs = gs.ToList();//同一个人，一个控制器
                                    Dictionary<int, int> doorAuths = new Dictionary<int, int>();
                                    List<AutoCtrler> priateAutos = new List<AutoCtrler>();
                                    List<AutoCtrler> uprivateAutos = new List<AutoCtrler>();
                                    acs.ForEach(m =>
                                    {
                                        if (m.record.ACC_STATE == (int)AccessState.Init)
                                        {//存在需要授权
                                            if (!doorAuths.ContainsKey((int)m.door.CTRL_DOOR_INDEX))
                                            {
                                                doorAuths.Add((int)m.door.CTRL_DOOR_INDEX, 1);
                                            }
                                            priateAutos.Add(m);
                                        }
                                        else
                                        {
                                            uprivateAutos.Add(m);
                                        }
                                    });

                                    if (uprivateAutos.Count > 0)
                                    {//先删除权限
                                        foreach (var card in acs[0].cards)
                                        {
                                            try
                                            {
                                                if (!exp)
                                                    access.DeleteAuthority(ctrl, card.CARD_WG_NO);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error("删除权限时发生异常：ctrl.ip=" + ctrl.ip + "," + ex.Message, ex);
                                                exp = true;
                                            }

                                        }
                                        uprivateAutos.ForEach(m =>
                                            {
                                                if (m.record.ACC_STATE == (int)AccessState.Private)
                                                {
                                                    m.record.ACC_STATE = (int)AccessState.Canceled;
                                                    staffdoorBll.Delete(m.record.ACC_STAFF_ID, m.record.ACC_DOOR_ID);
                                                }
                                                else if (m.record.ACC_STATE == (int)AccessState.PrivateExpire)
                                                {
                                                    staffdoorBll.Delete(m.record.ACC_STAFF_ID, m.record.ACC_DOOR_ID);
                                                }
                                                m.record.ACC_STATE_TIME = DateTime.Now;
                                                accrBll.Update(m.record);
                                            });
                                    }
                                    if (priateAutos.Count > 0)
                                    {
                                        bool bRet = false;
                                        foreach (var card in priateAutos[0].cards)
                                        {
                                            try
                                            {
                                                if (!exp)
                                                {
                                                   bool ret =  access.AddOrModifyAuthority(ctrl, card.CARD_WG_NO, priateAutos[0].record.ACC_START_TIME, priateAutos[0].record.ACC_END_TIME, doorAuths);
                                                   if (ret)
                                                   {
                                                       bRet = true;
                                                   }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error("添加权限时发生异常：ctrl.ip=" + ctrl.ip + "," + ex.Message, ex);
                                                exp = true;
                                            }
                                        }
                                        priateAutos.ForEach(m =>
                                        {
                                            if (m.record.ACC_STATE == (int)AccessState.Init)
                                            {
                                                if (bRet)
                                                {
                                                    m.record.ACC_STATE = (int)AccessState.Private;
                                                }
                                                else
                                                {
                                                    m.record.ACC_STATE = (int)AccessState.PrivateError;
                                                }
                                                var sd = staffdoorBll.GetModel(m.record.ACC_STAFF_ID, m.record.ACC_DOOR_ID);
                                                if (sd == null)
                                                {
                                                    sd = new Maticsoft.Model.SMT_STAFF_DOOR()
                                                    {
                                                        ADD_TIME = DateTime.Now,
                                                        IS_UPLOAD = true,
                                                        DOOR_ID = m.record.ACC_DOOR_ID,
                                                        STAFF_ID = m.record.ACC_STAFF_ID,
                                                        TIME_NUM = 1,
                                                        UPLOAD_TIME = DateTime.Now
                                                    };
                                                    staffdoorBll.Add(sd);
                                                }
                                                else
                                                {
                                                    sd.IS_UPLOAD = true;
                                                    sd.UPLOAD_TIME = DateTime.Now;
                                                    sd.TIME_NUM = 1;
                                                    staffdoorBll.Update(sd);
                                                }
                                            }
                                            m.record.ACC_STATE_TIME = DateTime.Now;
                                            accrBll.Update(m.record);
                                        });
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error("权限处理时发生异常:" + ex.Message, ex);
                        }
                        finally
                        {
                            evt.Set();
                        }
                    }));
                    th.Start();
                    foreach (var evt1 in evts)
                    {
                        evt1.WaitOne(60000 * 15);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("处理记录异常：" + ex.Message);
            }
            finally
            {
                timerGetAutoAccessData.Enabled = serverState;
                log.Info("读取自动授权记录结束！");
            }
        }
    }
}
