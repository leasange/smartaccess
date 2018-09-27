using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace SmartAccess.Common.Datas
{

    /// <summary>
    /// 上传权限
    /// </summary>
    public class UploadPrivate
    {
        static UploadPrivate()
        {
            ThreadPool.SetMaxThreads(100, 100);
        }
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(UploadPrivate));
        public static bool Upload(
            Maticsoft.Model.SMT_STAFF_INFO staffInfo,
            out string errMsg,//上传日志
            List<Maticsoft.Model.SMT_STAFF_DOOR> staffDoors = null,
            List<Maticsoft.Model.SMT_STAFF_CARD> staffCards = null,
            List<Maticsoft.Model.SMT_DOOR_INFO> allDoors = null,
            List<Maticsoft.Model.SMT_CONTROLLER_INFO> ctrlrs = null, bool isShowDetail = true)
        {
            if (isShowDetail)
            {
                FrmDetailInfo.Show();
            }
            else
            {
                FrmDetailInfo.Close();
            }

            FrmDetailInfo.AddOneMsg(string.Format("开始上传“{0}”权限...", staffInfo.REAL_NAME));
            errMsg = "";
            if (staffCards == null)
            {
                Maticsoft.BLL.SMT_STAFF_CARD scBll = new Maticsoft.BLL.SMT_STAFF_CARD();
                staffCards = scBll.GetModelListWithCardNo("STAFF_ID=" + staffInfo.ID);
            }

            if (staffCards.Count == 0)
            {
                FrmDetailInfo.AddOneMsg(string.Format("警告：人员“{0}”没有授权的卡,上传结束！", staffInfo.REAL_NAME), progress: 100);
                return true;
                //if (staffInfo.IS_DELETE||staffInfo.IS_FORBIDDEN||staffInfo.DELETE_CARD)
                //{
                //    return true;
                //}
                // errMsg = "上传失败，该人员没有授权的卡片！";
                // WinInfo.WinInfoHelper.ShowInfoWindow(null,"“"+staffInfo.REAL_NAME+ "”权限上传失败，该人员没有授权的卡片！");
                //return false;
            }
            string cds = "";
            foreach (var item in staffCards)
            {
                cds += item.CARD_NO + "；";
            }
            FrmDetailInfo.AddOneMsg(string.Format("获取到“{0}”授权卡：{1}", staffInfo.REAL_NAME, cds.TrimEnd('；')));
            if (FrmDetailInfo.IsClosed() && isShowDetail)
            {
                errMsg = "中断上传！";
                return false;
            }
            if (allDoors == null)
            {
                allDoors = GetUploadAllDoors();
            }
            if (allDoors.Count == 0)
            {
                FrmDetailInfo.AddOneMsg(string.Format("警告：人员“{0}”没有授权的门禁,上传结束！", staffInfo.REAL_NAME), 100, true);
                return true;
                // if (staffInfo.IS_DELETE || staffInfo.IS_FORBIDDEN || staffInfo.DELETE_CARD)
                //  {
                //      return true;
                //  }
                //  errMsg = "上传失败，当前没有任何门！";
                // WinInfo.WinInfoHelper.ShowInfoWindow(null, "“" + staffInfo.REAL_NAME + "”权限上传失败，当前没有任何可用门禁！");
                //  return false;
            }
            FrmDetailInfo.AddOneMsg(string.Format("获取到“{0}”授权门禁数：{1}", staffInfo.REAL_NAME, allDoors.Count));
            if (FrmDetailInfo.IsClosed() && isShowDetail)
            {
                errMsg = "中断上传！";
                return false;
            }
            if (ctrlrs == null)
            {
                ctrlrs = GetUploadCtrlr();
            }
            if (ctrlrs.Count == 0)
            {
                FrmDetailInfo.AddOneMsg(string.Format("警告：人员“{0}”上传时，未查到任何可用的控制器,上传结束！", staffInfo.REAL_NAME), 100, true);
                return true;
            }
            FrmDetailInfo.AddOneMsg(string.Format("获取到“{0}”授权控制器数：{1}", staffInfo.REAL_NAME, ctrlrs.Count));

            if (staffInfo.IS_DELETE || staffInfo.IS_FORBIDDEN || staffInfo.DELETE_CARD)//被删除、禁用或者挂失、销卡
            {
                FrmDetailInfo.AddOneMsg(string.Format("开始执行删除“{0}”的权限...", staffInfo.REAL_NAME));

                List<ManualResetEvent> eventlist = new List<ManualResetEvent>();
                string msg = "";
                int total = ctrlrs.Count * staffCards.Count;
                float step = 100f / total;
                float precent = 0;
                foreach (var item in ctrlrs)
                {
                    var ctrlr = ControllerHelper.ToController(item);
                    ManualResetEvent reset = new ManualResetEvent(false);
                    ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                        {
                            try
                            {
                                using (IAccessCore access = new WGAccess())
                                {
                                    foreach (var card in staffCards)
                                    {
                                        if (FrmDetailInfo.IsClosed() && isShowDetail)
                                        {
                                            msg = "中断上传！";
                                            return;
                                        }
                                        bool ret = access.DeleteAuthority(ctrlr, card.CARD_WG_NO);
                                        precent += step;
                                        if (!ret)
                                        {
                                            FrmDetailInfo.AddOneMsg(string.Format("删除“{0}”的一个权限失败，控制器：{1}，卡号：{2}", staffInfo.REAL_NAME, item.NAME, card.CARD_NO), (int)precent, true);
                                            //msg += "\r\n删除控制器的权限失败，控制器名称：" + item.NAME;
                                        }
                                        else
                                        {
                                            FrmDetailInfo.AddOneMsg(string.Format("删除“{0}”的一个权限成功，控制器：{1}，卡号：{2}", staffInfo.REAL_NAME, item.NAME, card.CARD_NO), progress: (int)precent);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                            finally
                            {
                                reset.Set();
                            }

                        }));
                    eventlist.Add(reset);
                }
                foreach (var item in eventlist)
                {
                    item.WaitOne(30000);
                }
                errMsg += msg;
                FrmDetailInfo.AddOneMsg(string.Format("执行“{0}”的权限删除结束。", staffInfo.REAL_NAME), 100);
                return true;
            }

            if (staffDoors == null)
            {
                Maticsoft.BLL.SMT_STAFF_DOOR sdBll = new Maticsoft.BLL.SMT_STAFF_DOOR();
                staffDoors = sdBll.GetModelList("STAFF_ID=" + staffInfo.ID);
            }
            var priDoors = allDoors.FindAll(m =>
                 {
                     return staffDoors.Exists(n => n.DOOR_ID == m.ID);
                 });
            var priGroup = priDoors.GroupBy(m => m.CTRL_ID);//所有有权限的门
            var allGroup = allDoors.GroupBy(m => m.CTRL_ID);
            List<decimal> priCtrlIds = new List<decimal>();//所有有权限的控制器

            List<ManualResetEvent> aeventlist = new List<ManualResetEvent>();
            string amsg = "";
            FrmDetailInfo.AddOneMsg(string.Format("执行更新/上传“{0}”的权限...", staffInfo.REAL_NAME));

            float stp = 100f / ctrlrs.Count;
            float percent = 0;
            foreach (var item in priGroup)
            {
                var doors = item.ToList();
                decimal ctrlId = (decimal)doors[0].CTRL_ID;
                priCtrlIds.Add(ctrlId);
                var ctrl = ctrlrs.Find(m => m.ID == ctrlId);
                if (ctrl == null)//未找到控制器
                {
                    FrmDetailInfo.AddOneMsg(string.Format("警告：未找到“{0}”控制器：ID={1}", staffInfo.REAL_NAME, ctrlId), -1, true);
                    //errMsg += "\r\n控制器无效：CTRL_ID=" + ctrlId;
                    continue;
                }
                Dictionary<int, int> doorNumAuthorities = new Dictionary<int, int>();
                foreach (var d in doors)
                {
                    if (d.CTRL_DOOR_INDEX != null && d.CTRL_DOOR_INDEX >= 0)
                    {
                        int num = 0;
                        if (d.IS_ENABLE)
                        {
                            var staffDoor = staffDoors.Find(m => m.DOOR_ID == d.ID);
                            if (staffDoor != null)
                            {
                                num = staffDoor.TIME_NUM;
                            }
                        }
                        doorNumAuthorities.Add((int)d.CTRL_DOOR_INDEX, num);
                    }
                }
                percent += stp;
                if (doorNumAuthorities.Count > 0)
                {
                    Controller c = ControllerHelper.ToController(ctrl);
                    ManualResetEvent reset = new ManualResetEvent(false);
                    ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                        {
                            try
                            {
                                using (IAccessCore access = new WGAccess())
                                {
                                    foreach (var card in staffCards)
                                    {
                                        if (FrmDetailInfo.IsClosed() && isShowDetail)
                                        {
                                            amsg = "中断上传！";
                                            return;
                                        }
                                        bool ret = access.AddOrModifyAuthority(c, card.CARD_WG_NO, staffInfo.VALID_STARTTIME, staffInfo.VALID_ENDTIME, doorNumAuthorities);
                                        if (!ret)
                                        {
                                            //   amsg += "\r\n设置控制器的权限失败，控制器名称：" + ctrl.NAME;
                                            FrmDetailInfo.AddOneMsg(string.Format("上传“{0}”的权限失败：控制器：{1}，卡号：{2} ！", staffInfo.REAL_NAME, ctrl.NAME, card.CARD_NO), (int)percent, true);
                                        }
                                        else
                                        {
                                            FrmDetailInfo.AddOneMsg(string.Format("上传“{0}”的权限成功：控制器：{1}，卡号：{2} 。", staffInfo.REAL_NAME, ctrl.NAME, card.CARD_NO), (int)percent);
                                            Maticsoft.BLL.SMT_STAFF_DOOR sdBll = new Maticsoft.BLL.SMT_STAFF_DOOR();
                                            var findscs = staffDoors.FindAll(m =>
                                            {
                                                return doors.Exists(n => n.ID == m.DOOR_ID);
                                            });
                                            foreach (var sd in findscs)
                                            {
                                                sd.IS_UPLOAD = true;
                                                sd.UPLOAD_TIME = DateTime.Now;
                                                sdBll.Update(sd);
                                            }
                                        }
                                    }
                                }
                                FrmDetailInfo.AddOneMsg(string.Format("上传“{0}”的控制器“{1}”权限结束。", staffInfo.REAL_NAME, ctrl.NAME), (int)percent);
                            }
                            catch (Exception ex)
                            {
                                // amsg += "\r\n设置控制器的权限失败，控制器名称：" + ctrl.NAME + ";异常信息：" + ex.Message;
                                FrmDetailInfo.AddOneMsg(string.Format("设置“{0}”的权限发生异常：控制器：{1}，异常信息：{2} ！", staffInfo.REAL_NAME, ctrl.NAME, ex.Message), (int)percent, true);

                            }
                            finally
                            {
                                reset.Set();
                            }
                        }));
                    aeventlist.Add(reset);
                }
            }

            foreach (var item in aeventlist)
            {
                item.WaitOne(60000);
            }
            errMsg += amsg;
            List<ManualResetEvent> deventlist = new List<ManualResetEvent>();
            string dmsg = "";
            foreach (var item in ctrlrs)//删除未授权的权限
            {
                if (priCtrlIds.Exists(m => m == item.ID))
                {
                    continue;
                }
                percent += stp;
                var ctrlr = ControllerHelper.ToController(item);
                ManualResetEvent reset = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                    {
                        try
                        {
                            using (IAccessCore access = new WGAccess())
                            {
                                foreach (var card in staffCards)
                                {
                                    if (FrmDetailInfo.IsClosed() && isShowDetail)
                                    {
                                        dmsg = "中断上传！";
                                        return;
                                    }
                                    bool ret = access.DeleteAuthority(ctrlr, card.CARD_WG_NO);
                                    if (!ret)
                                    {
                                        FrmDetailInfo.AddOneMsg(string.Format("删除“{0}”的权限失败：控制器：{1}，卡号：{2} ！", staffInfo.REAL_NAME, item.NAME, card.CARD_NO), (int)percent, true);
                                        // dmsg += "\r\n删除控制器的权限失败，控制器名称：" + item.NAME;
                                    }
                                    else
                                    {
                                        FrmDetailInfo.AddOneMsg(string.Format("删除“{0}”的权限成功：控制器：{1}，卡号：{2} 。", staffInfo.REAL_NAME, item.NAME, card.CARD_NO), (int)percent);
                                    }
                                }
                            }
                            FrmDetailInfo.AddOneMsg(string.Format("删除“{0}”的权限结束：控制器：{1} 。", staffInfo.REAL_NAME, item.NAME), (int)percent);
                        }
                        catch (Exception ex)
                        {
                            FrmDetailInfo.AddOneMsg(string.Format("删除“{0}”的权限发生异常：控制器：{1} ，异常信息：{2}。", staffInfo.REAL_NAME, item.NAME, ex.Message), (int)percent);
                        }
                        finally
                        {
                            reset.Set();
                        }

                    }));
                deventlist.Add(reset);
            }
            foreach (var item in deventlist)
            {
                item.WaitOne(60000);
            }
            errMsg += dmsg;
            errMsg = errMsg.Trim('\r', '\n');
            FrmDetailInfo.AddOneMsg(string.Format("上传“{0}”的权限结束。", staffInfo.REAL_NAME), 100);
            return true;
        }
        //根据控制器上传权限
        public static bool UploadByCtrlr(Maticsoft.Model.SMT_CONTROLLER_INFO ctrlr, out string errMsg, List<Maticsoft.Model.SMT_DOOR_INFO> ctrlDoors = null, bool isOnlyCall = false)
        {
            if (isOnlyCall)
            {
                FrmDetailInfo.Show(false);
            }
            errMsg = "";
            Controller cc = ControllerHelper.ToController(ctrlr);
            using (IAccessCore access = new WGAccess())
            {
                FrmDetailInfo.AddOneMsg(string.Format("清除控制器“{0}”的权限...", ctrlr.NAME));
                bool ret = access.ClearAuthority(cc);
                if (!ret)
                {
                    errMsg = "清除控制器的权限异常！";
                    FrmDetailInfo.AddOneMsg(string.Format("清除控制器的“{0}”的权限失败！", ctrlr.NAME), isRed: true);
                    return false;
                }
                else
                {
                    FrmDetailInfo.AddOneMsg(string.Format("清除控制器的“{0}”的权限成功。", ctrlr.NAME));
                }
                if (!ctrlr.IS_ENABLE)
                {
                    FrmDetailInfo.AddOneMsg(string.Format("控制器“{0}”未启用，结束该控制器权限上传。", ctrlr.NAME));
                    return ret;
                }
            }
            if (FrmDetailInfo.IsClosed())
            {
                errMsg = "控制器：" + cc.ip + "上传中断！";
                return false;
            }
            Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
            if (ctrlDoors == null)
            {
                ctrlDoors = doorBll.GetModelList("CTRL_ID=" + ctrlr.ID);
            }
            if (ctrlDoors.Count == 0)
            {
                errMsg = "控制器门为空！";
                FrmDetailInfo.AddOneMsg(string.Format("警告：控制器“{0}”没有门禁，结束该控制器权限上传。", ctrlr.NAME), isRed: true);
                return true;
            }
            FrmDetailInfo.AddOneMsg(string.Format("控制器“{0}”的门禁个数为：{1}。", ctrlr.NAME, ctrlDoors.Count));
            if (FrmDetailInfo.IsClosed())
            {
                errMsg = "控制器：" + cc.ip + "上传中断！";
                return false;
            }
            string str = "";
            foreach (var item in ctrlDoors)
            {
                str += item.ID + ",";
            }
            str = str.TrimEnd(',');
            Maticsoft.BLL.SMT_STAFF_DOOR staffDoorBLL = new Maticsoft.BLL.SMT_STAFF_DOOR();
            var staffDoors = staffDoorBLL.GetModelList("DOOR_ID in (" + str + ")");
            if (staffDoors.Count == 0)
            {
                // errMsg = "无授权门禁！";
                FrmDetailInfo.AddOneMsg(string.Format("控制器“{0}”的门禁，没有人员授权，结束该控制器权限上传。", ctrlr.NAME));
                return true;
            }
            str = "";
            foreach (var item in staffDoors)
            {
                str += item.STAFF_ID + ",";
            }
            str = str.TrimEnd(',');
            if (FrmDetailInfo.IsClosed())
            {
                errMsg = "控制器：" + cc.ip + "上传中断！";
                return false;
            }
            Maticsoft.BLL.SMT_STAFF_INFO sbll = new Maticsoft.BLL.SMT_STAFF_INFO();
            var staffs = sbll.GetModelList("ID in (" + str + ")");

            if (staffs.Count == 0)
            {
                //errMsg = "无授权人员！";
                FrmDetailInfo.AddOneMsg(string.Format("控制器“{0}”的门禁，没有人员授权，结束该控制器权限上传。", ctrlr.NAME));
                return true;
            }
            str = "";
            foreach (var item in staffs)
            {
                str += item.ID + ",";
            }
            str = str.TrimEnd(',');

            if (FrmDetailInfo.IsClosed())
            {
                errMsg = "控制器：" + cc.ip + "上传中断！";
                return false;
            }
            Maticsoft.BLL.SMT_CARD_INFO cBll = new Maticsoft.BLL.SMT_CARD_INFO();
            var cards = cBll.GetModelListByStaffIds(str);

            if (cards.Count == 0)
            {
                errMsg = "无授权卡片！";
                FrmDetailInfo.AddOneMsg(string.Format("控制器“{0}”的门禁，没有授权的卡，结束该控制器权限上传。", ctrlr.NAME));
                return true;
            }

            FrmDetailInfo.AddOneMsg("开始上传控制器：" + cc.ip + "的权限...");
            using (IAccessCore access = new WGAccess())
            {
                foreach (var item in cards)
                {
                    if (FrmDetailInfo.IsClosed())
                    {
                        errMsg = "控制器：" + cc.ip + "上传中断！";
                        return false;
                    }
                    var staff = staffs.Find(m => m.ID == item.STAFF_ID);
                    if (staff == null)
                    {
                        continue;
                    }
                    // FrmDetailInfo.AddOneMsg(string.Format("开始上传，控制器“{0}”的人员“{1}”,卡号“{2}”权限...", ctrlr.NAME, staff.REAL_NAME, item.CARD_NO));
                    var doors = staffDoors.FindAll(m => m.STAFF_ID == item.STAFF_ID);
                    Dictionary<int, int> aus = new Dictionary<int, int>();
                    foreach (var d in doors)
                    {
                        var di = ctrlDoors.Find(m => m.ID == d.DOOR_ID);
                        if (di == null)
                        {
                            continue;
                        }
                        int num = 0;
                        if (di.IS_ENABLE)
                        {
                            num = d.TIME_NUM;
                        }
                        aus.Add((int)di.CTRL_DOOR_INDEX, num);
                    }
                    bool ret = false;
                    ret = access.AddOrModifyAuthority(cc, item.CARD_WG_NO, staff.VALID_STARTTIME, staff.VALID_ENDTIME, aus);
                    if (!ret)
                    {
                        errMsg = "添加权限中断异常！卡号：" + item.CARD_NO;
                        FrmDetailInfo.AddOneMsg(string.Format("上传控制器“{0}”的人员“{1}”,卡号“{2}”权限异常，上传该控制器权限中断！", ctrlr.NAME, staff.REAL_NAME, item.CARD_NO), isRed: true);
                        return false;
                    }
                    // else
                    //{
                    //FrmDetailInfo.AddOneMsg(string.Format("上传控制器“{0}”的人员“{1}”,卡号“{2}”权限成功。", ctrlr.NAME, staff.REAL_NAME, item.CARD_NO));
                    //}
                }
            }
            FrmDetailInfo.AddOneMsg(string.Format("上传控制器“{0}”的权限结束。", ctrlr.NAME));
            return true;
        }

        public static List<Maticsoft.Model.SMT_CONTROLLER_INFO> GetUploadCtrlr()
        {
            Maticsoft.BLL.SMT_CONTROLLER_INFO ctrlBll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
            var ctrlrs = ctrlBll.GetModelList("IS_ENABLE=1");//启用的控制器
            return ctrlrs;
        }
        public static List<Maticsoft.Model.SMT_DOOR_INFO> GetUploadAllDoors()
        {
            Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
            var allDoors = doorBll.GetModelList("CTRL_ID>=0");
            return allDoors;
        }
        /// <summary>
        /// 通过卡号删除权限
        /// </summary>
        /// <param name="cardNum">卡号</param>
        public static bool DeletePrivateByCardNum(string cardNum, out string errMsg, List<Maticsoft.Model.SMT_STAFF_CARD> cards = null)
        {
            errMsg = "";
            if (cards == null)
            {
                Maticsoft.BLL.SMT_STAFF_CARD sbll = new Maticsoft.BLL.SMT_STAFF_CARD();//权限
                cards = sbll.GetModelListByCardNo(cardNum);
            }
            if (cards.Count == 0)
            {
                return true;
            }
            Maticsoft.BLL.SMT_STAFF_INFO staffBll = new Maticsoft.BLL.SMT_STAFF_INFO();
            var staffInfo = staffBll.GetModel(cards[0].STAFF_ID);
            return Upload(staffInfo, out errMsg, null, cards);
        }

        public static bool Upload(List<Maticsoft.Model.SMT_STAFF_INFO> staffInfos, out string errMsg)
        {
            errMsg = "";
            try
            {
                var ctrls = GetUploadCtrlr();
                if (ctrls.Count == 0)
                {
                    errMsg = "没有可用控制器！";
                    return false;
                }
                var doors = GetUploadAllDoors();
                if (doors.Count == 0)
                {
                    errMsg = "没有可用门禁！";
                    return false;
                }
                bool ret = true;
                foreach (var item in staffInfos)
                {
                    string terrMsg = "";
                    bool temp = Upload(item, out terrMsg, allDoors: doors, ctrlrs: ctrls);
                    ret = ret && temp;
                    if (string.IsNullOrWhiteSpace(errMsg))
                    {
                        errMsg = terrMsg;
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        public static bool UploadAllPrivate(out string errMsg)
        {
            string outMsg = "";
            errMsg = "";
            FrmDetailInfo.Show();
            FrmDetailInfo.AddOneMsg("开始上传所有权限...");
            var ctrls = GetUploadCtrlr();
            if (ctrls.Count == 0)
            {
                errMsg = "没有可用控制器！";
                FrmDetailInfo.AddOneMsg("没有可用的控制器，上传结束！", 100);
                return false;
            }
            List<ManualResetEvent> events = new List<ManualResetEvent>();
            float step = 100f / ctrls.Count;
            float percent = 0;
            foreach (var item in ctrls)
            {
                ManualResetEvent reset = new ManualResetEvent(false);
                events.Add(reset);
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    try
                    {
                        percent += step;
                        string tmsg = "";
                        UploadByCtrlr(item, out tmsg);
                        if (tmsg != "")
                        {
                            outMsg += "\r\n" + tmsg;
                        }
                        FrmDetailInfo.AddOneMsg(null, (int)percent);
                    }
                    catch (Exception ex)
                    {
                        outMsg += "\r\n" + ex.Message;
                        FrmDetailInfo.AddOneMsg(string.Format("上传指定控制器“{0}”的权限异常，异常信息：{1}", item.NAME, ex.Message), (int)percent, true);
                    }
                    finally
                    {
                        reset.Set();
                    }
                }));
            }
            foreach (var item in events)
            {
                item.WaitOne();
            }
            errMsg = outMsg;
            FrmDetailInfo.AddOneMsg(string.Format("上传所有权限结束！"), 100);
            return true;
        }

        public static AccessWatchService WatchService = new AccessWatchService();
        public static BstFaceWatchService FaceWatchService = new BstFaceWatchService();
        public static void UploadTimeTasks(List<Maticsoft.Model.SMT_CTRLR_TASK> tasks)
        {
            FrmDetailInfo.Show(false);
            FrmDetailInfo.AddOneMsg(string.Format("开始上传定时任务,任务数目：{0} ....", tasks.Count));
            var ctrls = ControllerHelper.GetList("1=1");
            if (ctrls.Count == 0)
            {
                FrmDetailInfo.AddOneMsg("没有获取到控制器,上传结束！", isRed: true);
                return;
            }
            var doors = GetUploadAllDoors();
            if (doors.Count == 0)
            {
                FrmDetailInfo.AddOneMsg("没有获取到控制器，上传结束！", isRed: true);
                return;
            }
            var groupDoors = doors.GroupBy(m => (decimal)m.CTRL_ID);
            Dictionary<Controller, List<TimeTask>> ctasks = new Dictionary<Controller, List<TimeTask>>();//控制器定时任务列表
            foreach (var item in tasks)
            {
                IEnumerable<System.Linq.IGrouping<decimal, Maticsoft.Model.SMT_DOOR_INFO>> group = groupDoors;//所有门禁
                if (item.DOOR_ID != "-1")
                {
                    var doorIds = item.DOOR_ID.Split(',');
                    List<decimal> ids = new List<decimal>();
                    foreach (var di in doorIds)
                    {
                        decimal d = -1;
                        if (decimal.TryParse(di, out d))
                        {
                            ids.Add(d);
                        }
                    }
                    var tdoors = doors.FindAll(m => ids.Contains(m.ID));
                    group = tdoors.GroupBy(m => (decimal)m.CTRL_ID);
                }
                foreach (var gd in group)
                {
                    var list = gd.ToList();
                    Controller c = null;
                    List<TimeTask> vtasks = null;
                    foreach (var ct in ctasks)
                    {
                        if (ct.Key.id == list[0].CTRL_ID)
                        {
                            c = ct.Key;
                            vtasks = ct.Value;
                            break;
                        }
                    }
                    if (c == null)
                    {
                        var ctrl = ctrls.Find(m => m.ID == list[0].CTRL_ID);
                        if (ctrl == null)
                        {
                            FrmDetailInfo.AddOneMsg(string.Format("没有获取到控制器：ID={0}", list[0].CTRL_ID), isRed: true);
                            continue;
                        }
                        c = ControllerHelper.ToController(ctrl);
                        vtasks = new List<TimeTask>();
                        ctasks.Add(c, vtasks);
                    }
                    TimeTask tt = new TimeTask()
                    {
                        actionTime = item.ACTION_TIME,
                        cardCount = 2,
                        ctrlStyle = (byte)item.CTRL_STYLE,
                        no = item.TASK_NO,
                        startDate = item.VALID_STARTDATE,
                        endDate = item.VALID_ENDDATE
                    };
                    tt.weekDaysEnable[0] = item.MON_STATE;
                    tt.weekDaysEnable[1] = item.TUE_STATE;
                    tt.weekDaysEnable[2] = item.THI_STATE;
                    tt.weekDaysEnable[3] = item.WES_STATE;
                    tt.weekDaysEnable[4] = item.FRI_STATE;
                    tt.weekDaysEnable[5] = item.SAT_STATE;
                    tt.weekDaysEnable[6] = item.SUN_STATE;

                    foreach (var dr in list)//遍历门
                    {
                        if (dr.CTRL_DOOR_INDEX == null)
                        {
                            continue;
                        }
                        tt.doorIndexs.Add((byte)(int)dr.CTRL_DOOR_INDEX);
                    }
                    vtasks.Add(tt);
                }
            }
            List<ManualResetEvent> evts = new List<ManualResetEvent>();
            foreach (var item in ctasks)
            {
                ManualResetEvent evt = new ManualResetEvent(false);
                evts.Add(evt);
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                    {
                        try
                        {
                            IAccessCore access = new WGAccess();
                            FrmDetailInfo.AddOneMsg(string.Format("开始清除控制器SN={0} 定时任务...", item.Key.sn));
                            if (!access.ClearTimeTask(item.Key))
                            {
                                FrmDetailInfo.AddOneMsg(string.Format("清空控制器定时任务失败：ID={0},IP={1},SN={2},终止该控制器定时任务上传！", item.Key.id, item.Key.ip, item.Key.sn), isRed: true);
                                return;
                            }
                            FrmDetailInfo.AddOneMsg(string.Format("清除控制器SN={0} 定时任务成功.", item.Key.sn));
                            FrmDetailInfo.AddOneMsg(string.Format("开始上传控制器SN={0} 定时任务...", item.Key.sn));
                            foreach (var t in item.Value)
                            {
                                bool ret = access.AddTimeTask(item.Key, t);
                                if (!ret)
                                {
                                    FrmDetailInfo.AddOneMsg(string.Format("上传控制器SN={0} 定时任务：NO={1} 异常！", item.Key.sn, t.no), isRed: true);
                                }
                                else
                                {
                                    FrmDetailInfo.AddOneMsg(string.Format("上传控制器SN={0} 定时任务：NO={1} 成功！", item.Key.sn, t.no));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            FrmDetailInfo.AddOneMsg(string.Format("上传控制器SN={0} 的定时任务异常：{1}", item.Key.sn, ex.Message));
                        }
                        finally
                        {
                            evt.Set();
                        }
                    }));
            }
            foreach (var item in evts)
            {
                item.WaitOne(40000);
            }
            FrmDetailInfo.AddOneMsg("上传定时任务结束！");
        }

        public static void DeleteTimeTasks(List<Maticsoft.Model.SMT_CTRLR_TASK> tasks)
        {
            var ctrls = ControllerHelper.GetList("1=1");
            if (ctrls.Count == 0)
            {
                return;
            }
            var doors = GetUploadAllDoors();
            if (doors.Count == 0)
            {
                return;
            }
            var groupDoors = doors.GroupBy(m => (decimal)m.CTRL_ID);
            Dictionary<Controller, List<TimeTask>> ctasks = new Dictionary<Controller, List<TimeTask>>();//控制器定时任务列表
            foreach (var item in tasks)
            {
                IEnumerable<System.Linq.IGrouping<decimal, Maticsoft.Model.SMT_DOOR_INFO>> group = groupDoors;//所有门禁
                if (item.DOOR_ID != "-1")
                {
                    var doorIds = item.DOOR_ID.Split(',');
                    List<decimal> ids = new List<decimal>();
                    foreach (var di in doorIds)
                    {
                        decimal d = -1;
                        if (decimal.TryParse(di, out d))
                        {
                            ids.Add(d);
                        }
                    }
                    var tdoors = doors.FindAll(m => ids.Contains(m.ID));
                    group = tdoors.GroupBy(m => (decimal)m.CTRL_ID);
                }
                foreach (var gd in group)
                {
                    var list = gd.ToList();
                    Controller c = null;
                    List<TimeTask> vtasks = null;
                    foreach (var ct in ctasks)
                    {
                        if (ct.Key.id == list[0].CTRL_ID)
                        {
                            c = ct.Key;
                            vtasks = ct.Value;
                            break;
                        }
                    }
                    if (c == null)
                    {
                        var ctrl = ctrls.Find(m => m.ID == list[0].CTRL_ID);
                        if (ctrl == null)
                        {
                            continue;
                        }
                        c = ControllerHelper.ToController(ctrl);
                        vtasks = new List<TimeTask>();
                        ctasks.Add(c, vtasks);
                    }
                    TimeTask tt = new TimeTask()
                    {
                        actionTime = item.ACTION_TIME,
                        cardCount = 2,
                        ctrlStyle = (byte)item.CTRL_STYLE,
                        no = item.TASK_NO,
                        startDate = item.VALID_STARTDATE,
                        endDate = item.VALID_ENDDATE
                    };
                    tt.weekDaysEnable[0] = item.MON_STATE;
                    tt.weekDaysEnable[1] = item.TUE_STATE;
                    tt.weekDaysEnable[2] = item.THI_STATE;
                    tt.weekDaysEnable[3] = item.WES_STATE;
                    tt.weekDaysEnable[4] = item.FRI_STATE;
                    tt.weekDaysEnable[5] = item.SAT_STATE;
                    tt.weekDaysEnable[6] = item.SUN_STATE;

                    foreach (var dr in list)//遍历门
                    {
                        if (dr.CTRL_DOOR_INDEX == null)
                        {
                            continue;
                        }
                        tt.doorIndexs.Add((byte)(int)dr.CTRL_DOOR_INDEX);
                    }
                    vtasks.Add(tt);
                }
            }
            List<ManualResetEvent> evts = new List<ManualResetEvent>();
            foreach (var item in ctasks)
            {
                ManualResetEvent evt = new ManualResetEvent(false);
                evts.Add(evt);
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    try
                    {
                        IAccessCore access = new WGAccess();
                        if (!access.ClearTimeTask(item.Key))
                        {
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        evt.Set();
                    }
                }));
            }
            foreach (var item in evts)
            {
                item.WaitOne(40000);
            }
        }

        public static void UploadPwds(List<Maticsoft.Model.SMT_SUPER_PWD> pwds)
        {
            FrmDetailInfo.Show(false);
            FrmDetailInfo.AddOneMsg("开始上传密码...");
            var doors = GetUploadAllDoors();
            var ctrls = GetUploadCtrlr();
            FrmDetailInfo.AddOneMsg("获取控制器数目：" + ctrls.Count + ",门禁数目：" + doors.Count);
            List<ManualResetEvent> evts = new List<ManualResetEvent>();
            foreach (var item in ctrls)
            {
                ManualResetEvent evt = new ManualResetEvent(false);
                evts.Add(evt);
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    try
                    {
                        var thdoors = doors.FindAll(m => m.CTRL_ID == item.ID);
                        var c = ControllerHelper.ToController(item);
                        using (IAccessCore access = new WGAccess())
                        {
                            foreach (var d in thdoors)
                            {
                                var thpwds = pwds.FindAll(m => m.DOOR_ID == d.ID);
                                List<string> listpwd = new List<string>();
                                foreach (var thpwd in thpwds)
                                {
                                    listpwd.Add(thpwd.SUPER_PWD);
                                }
                                FrmDetailInfo.AddOneMsg("开始上传控制器：" + item.NAME + ",IP:" + item.IP + "门号：" + d.CTRL_DOOR_INDEX + " 密码上传数目：" + listpwd.Count);
                                bool ret = access.SetSuperPwds(c, (int)d.CTRL_DOOR_INDEX, listpwd);
                                if (!ret)
                                {
                                    FrmDetailInfo.AddOneMsg("控制器：" + item.NAME + ",IP:" + item.IP + "门号：" + d.CTRL_DOOR_INDEX + " 密码上传失败！", isRed: true);
                                }
                                else
                                {
                                    FrmDetailInfo.AddOneMsg("控制器：" + item.NAME + ",IP:" + item.IP + "门号：" + d.CTRL_DOOR_INDEX + " 密码上传成功！");
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        FrmDetailInfo.AddOneMsg("控制器" + item.NAME + ",IP:" + item.IP + " 密码上传异常，" + ex.Message, isRed: true);
                    }
                    finally
                    {
                        evt.Set();
                    }
                }));
            }
            foreach (var item in evts)
            {
                item.WaitOne(20000);
            }
            FrmDetailInfo.AddOneMsg("上传结束！");
        }

        public static void UploadAlarmSetting(List<Maticsoft.Model.SMT_ALARM_SETTING> settings = null)
        {
            FrmDetailInfo.Show(false);
            FrmDetailInfo.AddOneMsg("开始上传报警设置...");
            try
            {
                if (settings == null)
                {
                    Maticsoft.BLL.SMT_ALARM_SETTING setbll = new Maticsoft.BLL.SMT_ALARM_SETTING();
                    settings = setbll.GetModelList("");
                }
                FrmDetailInfo.AddOneMsg("获取报警设置数目：" + settings.Count);
                if (settings.Count == 0)
                {
                    FrmDetailInfo.AddOneMsg("无报警设置，上传结束！");
                    return;
                }
                Maticsoft.BLL.SMT_CONTROLLER_INFO ctrlBll = new Maticsoft.BLL.SMT_CONTROLLER_INFO();

                foreach (var item in settings)
                {
                    if (item.CONTROLLER_INFO == null)
                    {
                        item.CONTROLLER_INFO = ctrlBll.GetModel(item.CTRL_ID);
                    }
                }

                List<ManualResetEvent> evts = new List<ManualResetEvent>();
                foreach (var item in settings)
                {
                    if (item.CONTROLLER_INFO == null)
                    {
                        FrmDetailInfo.AddOneMsg("报警设置所属控制器ID=" + item.CTRL_ID + ",不存在！", isRed: true);
                        continue;
                    }
                    Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
                    var doors = doorBll.GetModelList("CTRL_ID=" + item.CTRL_ID);
                    if (doors.Count == 0)
                    {
                        FrmDetailInfo.AddOneMsg("报警设置所属控制器 " + item.CONTROLLER_INFO.NAME + ",不存在对应门禁", isRed: true);
                        continue;
                    }
                    ManualResetEvent evt = new ManualResetEvent(false);
                    evts.Add(evt);
                    ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                        {
                            try
                            {
                                FrmDetailInfo.AddOneMsg("开始上传控制器 " + item.CONTROLLER_INFO.NAME + " 报警设置...");
                                Controller c = ControllerHelper.ToController(item.CONTROLLER_INFO);
                                AlarmParamsSetting ast = new AlarmParamsSetting();
                                ast.EnableFire = item.ENABLE_FIRE;
                                ast.EnableForceAccess = item.ENABLE_FORCE_ACCESS;
                                ast.EnableForceCloseDoor = item.ENABLE_FORCE_CLOSE;
                                ast.EnableForcePwdAlarm = item.ENABLE_FORCE_PWD;
                                ast.EnableForceWithCard = item.ENABLE_FORCE_CARD;
                                ast.EnableInvalidCard = item.ENABLE_INVALID_CARD;
                                ast.EnableSteal = item.ENABLE_STEAL;
                                ast.EnableUnClosed = item.ENABLE_CLOSED_TIMEOUT;
                                ast.IForcePwd = item.CTRL_FORCE_PWD;

                                using (IAccessCore access = new WGAccess())
                                {
                                    bool ret = access.SetAlarmParamsSetting(c, ast);
                                    if (!ret)
                                    {
                                        FrmDetailInfo.AddOneMsg("上传控制器 " + item.CONTROLLER_INFO.NAME + " 报警设置失败！", isRed: true);
                                    }
                                    else
                                    {
                                        FrmDetailInfo.AddOneMsg("上传控制器 " + item.CONTROLLER_INFO.NAME + " 报警设置成功.开始上传报警触发设置...");
                                        Maticsoft.BLL.SMT_ALARM_CONNECT acBll = new Maticsoft.BLL.SMT_ALARM_CONNECT();
                                        List<Maticsoft.Model.SMT_ALARM_CONNECT> asModels = acBll.GetModelList("CTRL_ID=" + item.CTRL_ID);
                                        for (int i = 0; i < 4; i++)
                                        {
                                            var model = asModels.Find(m => m.OUT_PORT == i + 1);
                                            AlarmConnectPortSetting cps = new AlarmConnectPortSetting();
                                            if (model == null)
                                            {
                                                model = new Maticsoft.Model.SMT_ALARM_CONNECT();
                                                model.DOOR_ID = -1;
                                                model.OUT_PORT = i + 1;
                                                continue;
                                            }
                                            var door = doors.Find(m => m.ID == model.DOOR_ID);
                                            cps.ActionDoorIndex = door == null || door.CTRL_DOOR_INDEX == null ? 0 : (int)door.CTRL_DOOR_INDEX;
                                            cps.ConnectItem = (AlarmConnectItem)model.ENB_CONNECT_ITEM;
                                            cps.DoorRelayActionEvent = model.ENB_RELAY_EVENT;
                                            cps.FireEvent = model.ENB_FIRE_EVENT;
                                            cps.FixedDelayTime = model.ENB_FIXED_TIME;
                                            cps.ForceAccessEvent = model.ENB_FORCE_ACCESS_EVENT;
                                            cps.ForceLockDoorEvent = model.ENB_FORCE_CLOSE_EVENT;
                                            cps.ForcePwdEvent = model.ENB_FORCE_PWD_EVENT;
                                            cps.IConnectPort = model.OUT_PORT;
                                            cps.InvalidCardEvent = model.ENB_INVALID_CARD_EVENT;
                                            cps.UnClosedTimeEvent = model.ENB_UNCLOSED_EVENT;
                                            ret = access.SetAlarmConnectPortSetting(c, cps);
                                            if (!ret)
                                            {
                                                FrmDetailInfo.AddOneMsg("上传控制器 " + item.CONTROLLER_INFO.NAME + " 报警触发端口 " + cps.IConnectPort + " 事件设置失败！", isRed: true);
                                            }
                                            else
                                            {
                                                FrmDetailInfo.AddOneMsg("上传控制器 " + item.CONTROLLER_INFO.NAME + " 报警触发端口 " + cps.IConnectPort + " 事件设置成功.");
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                FrmDetailInfo.AddOneMsg("上传控制器 " + item.CONTROLLER_INFO.NAME + " 报警设置异常失败：" + ex.Message, isRed: true);
                            }
                            finally
                            {
                                evt.Set();
                            }

                        }));
                }

                foreach (var evt in evts)
                {
                    evt.WaitOne(50000);
                }
            }
            catch (Exception ex)
            {
                FrmDetailInfo.AddOneMsg("上传异常结束：" + ex.Message, isRed: true);
                return;
            }
            FrmDetailInfo.AddOneMsg("上传结束!");
        }
        //远程开门
        public static void RemoteOpenDoors(List<Maticsoft.Model.SMT_DOOR_INFO> doors)
        {
            var ctrlIds = GetCtrlIds(doors);
            FrmDetailInfo.Show(false);
            FrmDetailInfo.AddOneMsg("开始远程开门...");
            try
            {
                Maticsoft.BLL.SMT_CONTROLLER_INFO ctrlBLL = new Maticsoft.BLL.SMT_CONTROLLER_INFO();
                var ctrls = ctrlBLL.GetModelList("ID in (" + string.Join(",", ctrlIds) + ")");

                List<ManualResetEvent> resetEvents = new List<ManualResetEvent>();
                foreach (var item in ctrls)
                {
                    var drs = doors.FindAll(m => m.CTRL_ID == item.ID);
                    if (drs.Count == 0)
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
                            foreach (var d in drs)
                            {
                                if (d.CTRL_DOOR_INDEX == null)
                                {
                                    continue;
                                }
                                bool ret = acc.OpenRemoteControllerDoor(c, (int)d.CTRL_DOOR_INDEX);
                                if (!ret)
                                {
                                    FrmDetailInfo.AddOneMsg("远程开门失败！门禁：" + d.DOOR_NAME, isRed: true);
                                    continue;
                                }
                                else
                                {
                                    FrmDetailInfo.AddOneMsg("远程开门成功！门禁：" + d.DOOR_NAME);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            FrmDetailInfo.AddOneMsg("远程开门异常！控制器：" + item.NAME + ",异常信息：" + ex.Message, isRed: true);
                        }
                        finally
                        {
                            evt.Set();
                        }
                    }));
                }
                foreach (var item in resetEvents)
                {
                    item.WaitOne(30000);
                }
            }
            catch (Exception ex)
            {
                FrmDetailInfo.AddOneMsg("远程开门发生异常!" + ex.Message, isRed: true);
            }
            FrmDetailInfo.AddOneMsg("远程开门结束！");
        }
        private static List<decimal> GetCtrlIds(List<Maticsoft.Model.SMT_DOOR_INFO> doors)
        {
            var g = doors.GroupBy(m => m.CTRL_ID);
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

        public static bool UploadFace(List<Maticsoft.Model.SMT_STAFF_FACEDEV> addmodels, List<Maticsoft.Model.SMT_STAFF_FACEDEV> updatemodels, out string errMsg)
        {
            errMsg = null;
            FrmDetailInfo.Show(false);
            FrmDetailInfo.AddOneMsg("开始上传人脸权限...");
            if (addmodels!=null&&addmodels.Count > 0)
            {
                FrmDetailInfo.AddOneMsg("开始添加或更新人脸" + addmodels.Count + "个...");
                var g = addmodels.GroupBy(m => m.FACEDEV_ID);
                int count = g.Count();
                List<ManualResetEvent> resets = new List<ManualResetEvent>();
                string tempMsgs = "";
                foreach (var item in g)
                {
                    ManualResetEvent reset = new ManualResetEvent(false);
                    resets.Add(reset);
                    ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                    {
                            var models = item.ToList();
                            try
                            {
                                if (models[0].FACERECG_DEVICE == null)
                                {
                                    var devs = FaceRecgHelper.GetList("", false, false);
                                    models[0].FACERECG_DEVICE = devs.Find(m => m.ID == models[0].FACEDEV_ID);
                                }
                                if (models[0].FACERECG_DEVICE==null)
                                {
                                    tempMsgs += "不存在人脸设备，设备可能已经删除！";
                                    return;
                                }
                                using (var faceCtrler = FaceRecgHelper.ToFaceController(models[0].FACERECG_DEVICE))
                                {
                                    if (!models[0].FACERECG_DEVICE.FACEDEV_IS_ENABLE)
                                    {
                                        FrmDetailInfo.AddOneMsg("设备:"+models[0].FACERECG_DEVICE.AREA_NAME+" 被禁用状态,设备权限被清除...");
                                        bool bret =faceCtrler.ClearFaces();
                                        if (!bret)
                                        {
                                            tempMsgs += "设备:" + models[0].FACERECG_DEVICE.AREA_NAME + " 权限被清除" + (bret ? "成功" : "失败");
                                        }
                                        FrmDetailInfo.AddOneMsg("设备:" + models[0].FACERECG_DEVICE.AREA_NAME + " 权限被清除" + (bret ? "成功" : "失败") + "！", isRed: !bret);
                                        return;
                                    }

                                    List<Maticsoft.Model.BST.staff_update> updates = new List<Maticsoft.Model.BST.staff_update>();
                                    List<string> deleteprivates = new List<string>();
                                    List<Maticsoft.Model.SMT_STAFF_FACEDEV> delModels=new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
                                    Maticsoft.BLL.SMT_STAFF_INFO sbll=new Maticsoft.BLL.SMT_STAFF_INFO();
                                    foreach (var model in models)
                                    {
                                        model.STAFF_INFO = sbll.GetModelWithDept(model.STAFF_ID);
                                        if (model.STAFF_INFO==null)
                                        {
                                            tempMsgs += "不存在人员ID：" + model.STAFF_ID;
                                            continue;
                                        }
                                        if (model.STAFF_INFO.IS_DELETE||model.STAFF_INFO.IS_FORBIDDEN)
                                        {
                                            deleteprivates.Add(model.STAFF_DEV_ID);
                                            delModels.Add(model);
                                            continue;
                                        }
                                        if (model.STAFF_INFO.PHOTO == null || model.STAFF_INFO.PHOTO.Length == 0)
                                        {
                                            FrmDetailInfo.AddOneMsg("警告:" + model.STAFF_INFO.REAL_NAME + " 没有头像,无需更新", isRed: true);
                                            continue;
                                        }
                                        Maticsoft.Model.BST.staff_update update = new Maticsoft.Model.BST.staff_update();
                                        if (string.IsNullOrWhiteSpace(model.STAFF_DEV_ID))
                                        {
                                            model.STAFF_DEV_ID = Guid.NewGuid().ToString("N");
                                        }
                                        update.id = model.STAFF_DEV_ID;
                                        update.authority = "B";
                                        update.image = model.STAFF_INFO.PHOTO;
                                        update.name = model.STAFF_INFO.REAL_NAME;
                                        update.data_keepon1 = model.STAFF_INFO.STAFF_NO;
                                        update.data_keepon2 = model.STAFF_INFO.ORG_NAME;
                                        update.data_keepon3 = model.STAFF_INFO.SKIIL_LEVEL;
                                        update.data_keepon4 = model.STAFF_INFO.STAFF_TYPE == "VISITOR"?"访客":"内部员工";
                                        update.data_keepon5 = "";
                                        DateTime dtStart = model.STAFF_INFO.VALID_STARTTIME.Date;
                                        if (model.START_VALID_TIME.Date > model.STAFF_INFO.VALID_STARTTIME.Date)
                                        {
                                            dtStart = model.START_VALID_TIME.Date;
                                        }
                                        DateTime dtEnd = model.STAFF_INFO.VALID_ENDTIME.Date;
                                        if (model.END_VALID_TIME.Date < model.STAFF_INFO.VALID_ENDTIME.Date)
                                        {
                                            dtEnd = model.END_VALID_TIME.Date.AddDays(1);
                                        }
                                        update.date_begin = dtStart.ToString("yyyy-MM-dd HH:mm:ss");
                                        update.date_end = dtEnd.ToString("yyyy-MM-dd HH:mm:ss");
                                        updates.Add(update);
                                    }
                                    string tempMsg = "";
                                    FrmDetailInfo.AddOneMsg("开始添加或更新人脸信息,数目"+updates.Count+"个，请等待...");
                                    bool ret = faceCtrler.AddOrModifyFaces(out tempMsg, updates.ToArray());
                                  
                                    if (!ret || !string.IsNullOrWhiteSpace(tempMsg))
                                    {
                                        tempMsgs += tempMsg + ";";
                                        FrmDetailInfo.AddOneMsg(tempMsg, isRed: true);
                                    }
                                    if (!ret)
                                    {
                                        FrmDetailInfo.AddOneMsg("设备：" + models[0].FACERECG_DEVICE.FACEDEV_NAME + ",添加发生错误", isRed: true);
                                    }
                                    else
                                    {
                                        int  failcount=0;
                                        foreach (var ud in updates)
                                        {
                                            if (!ud.Update_Result)
                                            {
                                                failcount++;
                                                FrmDetailInfo.AddOneMsg("“" + ud.name + "”权限上传：" + (ud.Update_Result ? "成功" : "失败"), isRed: !ud.Update_Result);
                                            }
                                        }
                                        FrmDetailInfo.AddOneMsg("成功上传权限数目：" + (updates.Count - failcount));
                                    }
                                    if (deleteprivates.Count>0)
                                    {
                                        try
                                        {
                                            FrmDetailInfo.AddOneMsg("删除人脸信息,数目" + deleteprivates.Count + "个，请等待...");
                                            ret = faceCtrler.DeleteFaces(deleteprivates,true);
                                            if (ret)
                                            {
                                                Maticsoft.BLL.SMT_STAFF_FACEDEV bll = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
                                                foreach (var dm in delModels)
                                                {
                                                    bll.Delete(dm.STAFF_ID, dm.FACEDEV_ID);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            FrmDetailInfo.AddOneMsg("设备：" + models[0].FACERECG_DEVICE.FACEDEV_NAME + ",删除人员发生错误", isRed: true);
                                        }
                                     
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                FrmDetailInfo.AddOneMsg("设备：" + models[0].FACERECG_DEVICE.FACEDEV_NAME + ",添加发生错误:"+ex.Message, isRed: true);
                                log.Error("设备：" + models[0].FACERECG_DEVICE.FACEDEV_NAME + ",添加发生错误:" + ex.Message, ex);
                            }
                            finally
                            {
                                reset.Set();
                            }
                        }));
                }
                foreach (var item in resets)
                {
                    item.WaitOne();
                }
                errMsg += tempMsgs;
            }
            if (updatemodels!=null&&updatemodels.Count > 0)
            {
                FrmDetailInfo.AddOneMsg("开始更新人脸" + updatemodels.Count + "个...");
                var g = updatemodels.GroupBy(m => m.FACEDEV_ID);
                int count = g.Count();
                List<ManualResetEvent> resets = new List<ManualResetEvent>();
                string tempMsgs = "";
                foreach (var item in g)
                {
                    ManualResetEvent reset = new ManualResetEvent(false);
                    resets.Add(reset);
                    ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                        {
                            try
                            {

                                var models = item.ToList(); 
                                if (models[0].FACERECG_DEVICE == null)
                                {
                                    var devs = FaceRecgHelper.GetList("", false, false);
                                    models[0].FACERECG_DEVICE = devs.Find(m => m.ID == models[0].FACEDEV_ID);
                                }
                                if (models[0].FACERECG_DEVICE == null)
                                {
                                    tempMsgs += "不存在人脸设备，设备可能已经删除！";
                                    return;
                                }

                                using (var faceCtrler = FaceRecgHelper.ToFaceController(models[0].FACERECG_DEVICE))
                                {
                                    if (!models[0].FACERECG_DEVICE.FACEDEV_IS_ENABLE)
                                    {
                                        FrmDetailInfo.AddOneMsg("设备:" + models[0].FACERECG_DEVICE.AREA_NAME + " 被禁用状态,设备权限被清除...");
                                        bool bret = faceCtrler.ClearFaces();
                                        if (!bret)
                                        {
                                            tempMsgs += "设备:" + models[0].FACERECG_DEVICE.AREA_NAME + " 权限被清除" + (bret ? "成功" : "失败");
                                        }
                                        FrmDetailInfo.AddOneMsg("设备:" + models[0].FACERECG_DEVICE.AREA_NAME + " 权限被清除" + (bret ? "成功" : "失败") + "！", isRed: !bret);
                                        return;
                                    }

                                    List<Maticsoft.Model.BST.staff_data> datas = new List<Maticsoft.Model.BST.staff_data>();
                                    Maticsoft.BLL.SMT_STAFF_INFO sbll = new Maticsoft.BLL.SMT_STAFF_INFO();
                                    List<string> deleteprivates = new List<string>();
                                    List<Maticsoft.Model.SMT_STAFF_FACEDEV> delModels = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
                                    foreach (var model in models)
                                    {
                                        model.STAFF_INFO = sbll.GetModelWithDept(model.STAFF_ID);
                                        if (model.STAFF_INFO == null)
                                        {
                                            tempMsgs += "不存在人员ID：" + model.STAFF_ID;
                                            continue;
                                        }
                                        if (model.STAFF_INFO.IS_DELETE || model.STAFF_INFO.IS_FORBIDDEN)
                                        {
                                            deleteprivates.Add(model.STAFF_DEV_ID);
                                            delModels.Add(model);
                                            continue;
                                        }
                                        Maticsoft.Model.BST.staff_data data = new Maticsoft.Model.BST.staff_data();
                                        data.id = model.STAFF_DEV_ID;
                                        data.name = model.STAFF_INFO.REAL_NAME;
                                        data.data_keepon1 = model.STAFF_INFO.STAFF_NO;
                                        data.data_keepon2 = model.STAFF_INFO.ORG_NAME;
                                        data.data_keepon3 = model.STAFF_INFO.SKIIL_LEVEL;
                                        data.data_keepon4 = "";
                                        data.data_keepon5 = "";
                                        DateTime dtStart = model.STAFF_INFO.VALID_STARTTIME.Date;
                                        if (model.START_VALID_TIME.Date > model.STAFF_INFO.VALID_STARTTIME.Date)
                                        {
                                            dtStart = model.START_VALID_TIME.Date;
                                        }
                                        DateTime dtEnd = model.STAFF_INFO.VALID_ENDTIME.Date;
                                        if (model.END_VALID_TIME.Date < model.STAFF_INFO.VALID_ENDTIME.Date)
                                        {
                                            dtEnd = model.END_VALID_TIME.Date.AddDays(1);
                                        }
                                        data.date_begin = dtStart.ToString("yyyy-MM-dd HH:mm:ss");
                                        data.date_end = dtEnd.ToString("yyyy-MM-dd HH:mm:ss");
                                        datas.Add(data);
                                    }
                                    string tempMsg = "";
                                    FrmDetailInfo.AddOneMsg("开始更新人脸信息,数目" + datas.Count + "个，请等待...");
                                    bool ret = faceCtrler.ModifyTextInfo(out tempMsg, datas.ToArray());
                                    
                                    if (!ret || !string.IsNullOrWhiteSpace(tempMsg))
                                    {
                                        tempMsgs += tempMsg + ";";
                                        FrmDetailInfo.AddOneMsg(tempMsg, isRed: true);
                                    }
                                    if (!ret)
                                    {
                                        FrmDetailInfo.AddOneMsg("设备：" + models[0].FACERECG_DEVICE.FACEDEV_NAME + ",更新发生错误", isRed: true);
                                    }
                                    if (deleteprivates.Count > 0)
                                    {
                                        try
                                        {
                                            FrmDetailInfo.AddOneMsg("开始删除人脸信息,数目" + deleteprivates.Count + "个，请等待...");
                                            ret = faceCtrler.DeleteFaces(deleteprivates,true);
                                            if (ret)
                                            {
                                                Maticsoft.BLL.SMT_STAFF_FACEDEV bll = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
                                                foreach (var dm in delModels)
                                                {
                                                    bll.Delete(dm.STAFF_ID, dm.FACEDEV_ID);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            FrmDetailInfo.AddOneMsg("设备：" + models[0].FACERECG_DEVICE.FACEDEV_NAME + ",删除人员发生错误", isRed: true);
                                        }

                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                            finally
                            {
                                reset.Set();
                            }
                        }));
                }
                foreach (var item in resets)
                {
                    item.WaitOne();
                }
                errMsg += tempMsgs;
            }
            FrmDetailInfo.AddOneMsg("设置结束！");
            return true;
        }
        public static List<Maticsoft.Model.SMT_STAFF_FACEDEV> DeleteFace(List<Maticsoft.Model.SMT_STAFF_FACEDEV> deletemodels, out string errMsg)
        {
            List<Maticsoft.Model.SMT_STAFF_FACEDEV> sfds = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
            errMsg = null;
            FrmDetailInfo.Show(false);
            FrmDetailInfo.AddOneMsg("开始删除人脸权限...");
            if (deletemodels != null && deletemodels.Count > 0)
            {
                FrmDetailInfo.AddOneMsg("开始删除或删除人脸" + deletemodels.Count + "个...");
                var g = deletemodels.GroupBy(m => m.FACEDEV_ID);
                int count = g.Count();
                List<ManualResetEvent> resets = new List<ManualResetEvent>();
                string tempMsgs = "";
                foreach (var item in g)
                {
                    ManualResetEvent reset = new ManualResetEvent(false);
                    resets.Add(reset);
                    ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                    {
                        var models = item.ToList();
                        try
                        {
                            if (models[0].FACERECG_DEVICE == null)
                            {
                                var devs = FaceRecgHelper.GetList("", false, false);
                                models[0].FACERECG_DEVICE = devs.Find(m => m.ID == models[0].FACEDEV_ID);
                            }
                            if (models[0].FACERECG_DEVICE == null)
                            {
                                tempMsgs += "不存在人脸设备，设备可能已经删除！";
                                return;
                            }

                            using (var faceCtrler = FaceRecgHelper.ToFaceController(models[0].FACERECG_DEVICE))
                            {
                                if (!models[0].FACERECG_DEVICE.FACEDEV_IS_ENABLE)
                                {
                                    FrmDetailInfo.AddOneMsg("设备:" + models[0].FACERECG_DEVICE.AREA_NAME + " 被禁用状态,设备权限被清除...");
                                    bool bret = faceCtrler.ClearFaces();
                                    if (!bret)
                                    {
                                        tempMsgs += "设备:" + models[0].FACERECG_DEVICE.AREA_NAME + " 权限被清除" + (bret ? "成功" : "失败");
                                    }
                                    FrmDetailInfo.AddOneMsg("设备:" + models[0].FACERECG_DEVICE.AREA_NAME + " 权限被清除" + (bret ? "成功" : "失败") + "！", isRed: !bret);
                                    if (bret)
                                    {
                                        lock (sfds)
                                        {
                                            sfds.AddRange(models);
                                        }
                                    }
                                    return;
                                }

                                List<string> ids=new List<string>();
                                foreach (var model in models)
                                {
                                    ids.Add(model.STAFF_DEV_ID);
                                }
                                string tempMsg = "";
                                bool ret = faceCtrler.DeleteFaces(ids,true);
                                if (!string.IsNullOrWhiteSpace(tempMsg))
                                {
                                    tempMsgs += tempMsg + ";";
                                    FrmDetailInfo.AddOneMsg(tempMsg, isRed: true);
                                }
                                if (!ret)
                                {
                                    FrmDetailInfo.AddOneMsg("设备：" + models[0].FACERECG_DEVICE.FACEDEV_NAME + ",删除发生错误", isRed: true);
                                }
                                else
                                {
                                    FrmDetailInfo.AddOneMsg("设备：" + models[0].FACERECG_DEVICE.FACEDEV_NAME + ",删除权限成功!");
                                    lock (sfds)
                                    {
                                        sfds.AddRange(models);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            FrmDetailInfo.AddOneMsg("设备：" + models[0].FACERECG_DEVICE.FACEDEV_NAME + ",删除发生错误:" + ex.Message, isRed: true);
                        }
                        finally
                        {
                            reset.Set();
                        }
                    }));
                }
                foreach (var item in resets)
                {
                    item.WaitOne();
                }
                errMsg += tempMsgs;
            }
            return sfds;
        }
    }
}
