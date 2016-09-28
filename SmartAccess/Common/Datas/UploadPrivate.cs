using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using SmartAccess.Common.WinInfo;
using System;
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
        public static bool Upload(
            Maticsoft.Model.SMT_STAFF_INFO staffInfo,
            out string errMsg,//上传日志
            List<Maticsoft.Model.SMT_STAFF_DOOR> staffDoors = null,
            List<Maticsoft.Model.SMT_STAFF_CARD> staffCards = null,
            List<Maticsoft.Model.SMT_DOOR_INFO> allDoors = null,
            List<Maticsoft.Model.SMT_CONTROLLER_INFO> ctrlrs=null)
        {
            FrmDetailInfo.Show();
            FrmDetailInfo.AddOneMsg(string.Format("开始上传“{0}”权限...",staffInfo.REAL_NAME));
            errMsg = "";
            if (staffCards == null)
            {
                Maticsoft.BLL.SMT_STAFF_CARD scBll = new Maticsoft.BLL.SMT_STAFF_CARD();
                staffCards = scBll.GetModelListWithCardNo("STAFF_ID=" + staffInfo.ID);
            }
            
            if (staffCards.Count == 0)
            {
                FrmDetailInfo.AddOneMsg(string.Format("警告：人员“{0}”没有授权的卡,上传结束！",staffInfo.REAL_NAME),progress:100);
                return true;
                //if (staffInfo.IS_DELETE||staffInfo.IS_FORBIDDEN||staffInfo.DELETE_CARD)
                //{
                //    return true;
                //}
               // errMsg = "上传失败，该人员没有授权的卡片！";
               // WinInfo.WinInfoHelper.ShowInfoWindow(null,"“"+staffInfo.REAL_NAME+ "”权限上传失败，该人员没有授权的卡片！");
                //return false;
            }
            string cds="";
            foreach (var item in staffCards)
	        {
		        cds+=item.CARD_NO+"；";
	        }
            FrmDetailInfo.AddOneMsg(string.Format("获取到“{0}”授权卡：{1}",staffInfo.REAL_NAME,cds.TrimEnd('；')));
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
            if (ctrlrs == null)
            {
                ctrlrs = GetUploadCtrlr();
            }
            if (ctrlrs.Count==0)
            {
                FrmDetailInfo.AddOneMsg(string.Format("警告：人员“{0}”上传时，未查到任何可用的控制器,上传结束！", staffInfo.REAL_NAME), 100,true);
                return true;
                //if (staffInfo.IS_DELETE || staffInfo.IS_FORBIDDEN || staffInfo.DELETE_CARD)
                //{
                //    return true;
                //}
               // errMsg = "上传失败，当前没有任何可用控制器！";
                //WinInfo.WinInfoHelper.ShowInfoWindow(null, "上传失败，当前没有任何可用控制器！");
                //return false;
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
                                        bool ret = access.DeleteAuthority(ctrlr, card.CARD_NO);
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
                FrmDetailInfo.AddOneMsg(string.Format("执行“{0}”的权限删除结束。",staffInfo.REAL_NAME), 100);
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
                decimal ctrlId=(decimal)doors[0].CTRL_ID;
                priCtrlIds.Add(ctrlId);
                var ctrl = ctrlrs.Find(m => m.ID == ctrlId);
                if (ctrl==null)//未找到控制器
                {
                    FrmDetailInfo.AddOneMsg(string.Format("警告：未找到“{0}”控制器：ID={1}", staffInfo.REAL_NAME, ctrlId),-1,true);
                    //errMsg += "\r\n控制器无效：CTRL_ID=" + ctrlId;
                    continue;
                }
                Dictionary<int, int> doorNumAuthorities = new Dictionary<int, int>();
                foreach (var d in doors)
                {
                    if (d.CTRL_DOOR_INDEX!=null&&d.CTRL_DOOR_INDEX>=0)
                    {
                        int num = 0;
                        if (d.IS_ENABLE)
                        {
                            var staffDoor = staffDoors.Find(m => m.DOOR_ID == d.ID);
                            if (staffDoor!=null)
                            {
                                num = staffDoor.TIME_NUM;
                            }
                        }
                        doorNumAuthorities.Add((int)d.CTRL_DOOR_INDEX, num);
                    }
                }
                percent += stp;
                if (doorNumAuthorities.Count>0)
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
                                        bool ret = access.AddOrModifyAuthority(c, card.CARD_NO, staffInfo.VALID_STARTTIME, staffInfo.VALID_ENDTIME, doorNumAuthorities);
                                        if (!ret)
                                        {
                                         //   amsg += "\r\n设置控制器的权限失败，控制器名称：" + ctrl.NAME;
                                            FrmDetailInfo.AddOneMsg(string.Format("上传“{0}”的权限失败：控制器：{1}，卡号：{2} ！", staffInfo.REAL_NAME, ctrl.NAME, card.CARD_NO), (int)percent,true);
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
                                FrmDetailInfo.AddOneMsg(string.Format("设置“{0}”的权限发生异常：控制器：{1}，异常信息：{2} ！", staffInfo.REAL_NAME, ctrl.NAME, ex.Message), (int)percent,true);
                               
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
                item.WaitOne(30000);
            }
            errMsg += amsg;
            List<ManualResetEvent> deventlist = new List<ManualResetEvent>();
            string dmsg = "";
            foreach (var item in ctrlrs)//删除未授权的权限
            {
                if (priCtrlIds.Exists(m=>m==item.ID))
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
                                    bool ret = access.DeleteAuthority(ctrlr, card.CARD_NO);
                                    if (!ret)
                                    {
                                        FrmDetailInfo.AddOneMsg(string.Format("删除“{0}”的权限失败：控制器：{1}，卡号：{2} ！", staffInfo.REAL_NAME, item.NAME, card.CARD_NO), (int)percent,true);
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
                            FrmDetailInfo.AddOneMsg(string.Format("删除“{0}”的权限发生异常：控制器：{1} ，异常信息：{2}。", staffInfo.REAL_NAME, item.NAME,ex.Message), (int)percent);
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
                item.WaitOne(30000);
            }
            errMsg += dmsg;
            errMsg = errMsg.Trim('\r', '\n');
            FrmDetailInfo.AddOneMsg(string.Format("上传“{0}”的权限结束。",staffInfo.REAL_NAME),100);
            return true;
        }
        public static bool UploadByCtrlr(Maticsoft.Model.SMT_CONTROLLER_INFO ctrlr,out string errMsg, List<Maticsoft.Model.SMT_DOOR_INFO> ctrlDoors=null,bool isOnlyCall=false)
        {
            if (isOnlyCall)
            {
                FrmDetailInfo.Show(false);
            }
            errMsg="";
            Controller cc = ControllerHelper.ToController(ctrlr);
            using (IAccessCore access = new WGAccess())
            {
                FrmDetailInfo.AddOneMsg(string.Format("清除控制器“{0}”的权限...",ctrlr.NAME));
                bool ret = access.ClearAuthority(cc);
                if (!ret)
                {
                    errMsg = "清除控制器的权限异常！";
                    FrmDetailInfo.AddOneMsg(string.Format("清除控制器的“{0}”的权限失败！", ctrlr.NAME),isRed:true);
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

            Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
            if (ctrlDoors==null)
            {
                ctrlDoors = doorBll.GetModelList("CTRL_ID=" + ctrlr.ID);
            }
            if (ctrlDoors.Count == 0)
            {
                errMsg = "控制器门为空！";
                FrmDetailInfo.AddOneMsg(string.Format("警告：控制器“{0}”没有门禁，结束该控制器权限上传。", ctrlr.NAME),isRed:true);
                return true;
            }
            FrmDetailInfo.AddOneMsg(string.Format("控制器“{0}”的门禁个数为：{1}。", ctrlr.NAME,ctrlDoors.Count));
            string str = "";
            foreach (var item in ctrlDoors)
            {
                str += item.ID + ",";
            }
            str = str.TrimEnd(',');
            Maticsoft.BLL.SMT_STAFF_DOOR staffDoorBLL = new Maticsoft.BLL.SMT_STAFF_DOOR();
            var staffDoors = staffDoorBLL.GetModelList("DOOR_ID in (" + str + ")");
            if (staffDoors.Count==0)
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
            Maticsoft.BLL.SMT_STAFF_INFO sbll = new Maticsoft.BLL.SMT_STAFF_INFO();
            var staffs = sbll.GetModelList("ID in (" + str + ")");

            if (staffs.Count==0)
            {
                //errMsg = "无授权人员！";
                FrmDetailInfo.AddOneMsg(string.Format("控制器“{0}”的门禁，没有人员授权，结束该控制器权限上传。", ctrlr.NAME));
                return true;
            }
            /*
            Maticsoft.BLL.SMT_STAFF_CARD scBll = new Maticsoft.BLL.SMT_STAFF_CARD();
            var scards = scBll.GetModelList("STAFF_ID in (" + str + ")");
            if (scards.Count==0)
            {
                return true;
            }
             */
            str = "";
            foreach (var item in staffs)
            {
                str += item.ID + ",";
            }
            str = str.TrimEnd(',');

            Maticsoft.BLL.SMT_CARD_INFO cBll = new Maticsoft.BLL.SMT_CARD_INFO();
            var cards = cBll.GetModelListByStaffIds(str);

            if (cards.Count==0)
            {
                errMsg = "无授权卡片！";
                FrmDetailInfo.AddOneMsg(string.Format("控制器“{0}”的门禁，没有授权的卡，结束该控制器权限上传。", ctrlr.NAME));
                return true;
            }

           // Controller cc = ControllerHelper.ToController(ctrlr);
            using (IAccessCore access=new WGAccess())
            {
                foreach (var item in cards)
                {
                    var staff= staffs.Find(m=>m.ID==item.STAFF_ID);
                    if (staff==null)
	                {
                        continue;
	                }
                    FrmDetailInfo.AddOneMsg(string.Format("开始上传，控制器“{0}”的人员“{1}”,卡号“{2}”权限...", ctrlr.NAME, staff.REAL_NAME, item.CARD_NO));
                    var doors= staffDoors.FindAll(m=>m.STAFF_ID==staff.ID);
                    Dictionary<int, int> aus = new Dictionary<int, int>();
                    foreach (var d in doors)
	                {
                        var di= ctrlDoors.Find(m=>m.ID==d.DOOR_ID);
                        if (di==null)
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
                    bool ret = access.AddOrModifyAuthority(cc, item.CARD_NO, staff.VALID_STARTTIME, staff.VALID_ENDTIME, aus);
                    if (!ret)
                    {
                        errMsg = "添加权限中断异常！卡号：" + item.CARD_NO;
                        FrmDetailInfo.AddOneMsg(string.Format("上传控制器“{0}”的人员“{1}”,卡号“{2}”权限异常，上传该控制器权限中断！", ctrlr.NAME, staff.REAL_NAME, item.CARD_NO),isRed:true);
                        return false;
                    }
                    else
                    {
                        FrmDetailInfo.AddOneMsg(string.Format("上传控制器“{0}”的人员“{1}”,卡号“{2}”权限成功。", ctrlr.NAME, staff.REAL_NAME, item.CARD_NO));
                    }
                }
                FrmDetailInfo.AddOneMsg(string.Format("上传控制器“{0}”的权限结束。", ctrlr.NAME));
            }
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
        public static bool DeletePrivateByCardNum(string cardNum,out string errMsg,List<Maticsoft.Model.SMT_STAFF_CARD> cards=null)
        {
            errMsg = "";
            if (cards==null)
            {
                Maticsoft.BLL.SMT_STAFF_CARD sbll = new Maticsoft.BLL.SMT_STAFF_CARD();//权限
                cards = sbll.GetModelListByCardNo(cardNum);
            }
            if (cards.Count==0)
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
                if (ctrls.Count==0)
                {
                    errMsg = "没有可用控制器！";
                    return false;
                }
                var doors = GetUploadAllDoors();
                if (doors.Count==0)
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
                FrmDetailInfo.AddOneMsg("没有可用的控制器，上传结束！",100);
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
                            FrmDetailInfo.AddOneMsg(string.Format("上传指定控制器“{0}”的权限结束.", item.NAME),(int)percent);
                        }
                        catch (Exception ex)
                        {
                            outMsg += "\r\n" + ex.Message;
                            FrmDetailInfo.AddOneMsg(string.Format("上传指定控制器“{0}”的权限异常，异常信息：{1}", item.NAME,ex.Message), (int)percent,true);
                        }
                        finally
                        {
                            reset.Set();
                        }
                    }));
            }
            foreach (var item in events)
            {
                item.WaitOne(60000);
            }
            errMsg = outMsg;
            FrmDetailInfo.AddOneMsg(string.Format("上传所有权限结束！"),100);
            return true;
        }

        public static AccessWatchService WatchService = new AccessWatchService();
    
    }
}
