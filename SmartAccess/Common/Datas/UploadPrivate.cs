using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using System;
using System.Collections.Generic;
using System.Linq;
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
            errMsg = "";
            if (staffCards == null)
            {
                Maticsoft.BLL.SMT_STAFF_CARD scBll = new Maticsoft.BLL.SMT_STAFF_CARD();
                staffCards = scBll.GetModelListWithCardNo("STAFF_ID=" + staffInfo.ID);
            }
            if (staffCards.Count == 0)
            {
                if (staffInfo.IS_DELETE||staffInfo.IS_FORBIDDEN||staffInfo.DELETE_CARD)
                {
                    return true;
                }
                errMsg = "上传失败，该人员没有授权的卡片！";
               // WinInfo.WinInfoHelper.ShowInfoWindow(null,"“"+staffInfo.REAL_NAME+ "”权限上传失败，该人员没有授权的卡片！");
                return false;
            }
            if (allDoors == null)
            {
                allDoors = GetUploadAllDoors();
            }
            if (allDoors.Count == 0)
            {
                if (staffInfo.IS_DELETE || staffInfo.IS_FORBIDDEN || staffInfo.DELETE_CARD)
                {
                    return true;
                }
                errMsg = "上传失败，当前没有任何门！";
               // WinInfo.WinInfoHelper.ShowInfoWindow(null, "“" + staffInfo.REAL_NAME + "”权限上传失败，当前没有任何可用门禁！");
                return false;
            }
            if (ctrlrs == null)
            {
                ctrlrs = GetUploadCtrlr();
            }
            if (ctrlrs.Count==0)
            {
                if (staffInfo.IS_DELETE || staffInfo.IS_FORBIDDEN || staffInfo.DELETE_CARD)
                {
                    return true;
                }
                errMsg = "上传失败，当前没有任何可用控制器！";
                //WinInfo.WinInfoHelper.ShowInfoWindow(null, "上传失败，当前没有任何可用控制器！");
                return false;
            }
            if (staffInfo.IS_DELETE || staffInfo.IS_FORBIDDEN || staffInfo.DELETE_CARD)//被删除、禁用或者挂失、销卡
            {
                List<ManualResetEvent> eventlist = new List<ManualResetEvent>();
                string msg = "";
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
                                        if (!ret)
                                        {
                                            msg += "\r\n删除控制器的权限失败，控制器名称：" + item.NAME;
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
            foreach (var item in priGroup)
            {
                var doors = item.ToList();
                decimal ctrlId=(decimal)doors[0].CTRL_ID;
                priCtrlIds.Add(ctrlId);
                var ctrl = ctrlrs.Find(m => m.ID == ctrlId);
                if (ctrl==null)//未找到控制器
                {
                    errMsg += "\r\n控制器无效：CTRL_ID=" + ctrlId;
                    continue;
                }
                Dictionary<int, bool> doorNumAuthorities = new Dictionary<int, bool>();
                foreach (var d in doors)
                {
                    if (d.CTRL_DOOR_INDEX!=null&&d.CTRL_DOOR_INDEX>=0)
                    {
                        doorNumAuthorities.Add((int)d.CTRL_DOOR_INDEX, d.IS_ENABLE);
                    }
                }
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
                                            amsg += "\r\n设置控制器的权限失败，控制器名称：" + ctrl.NAME;
                                        }
                                        else
                                        {
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
                            }
                            catch (Exception ex)
                            {
                                amsg += "\r\n设置控制器的权限失败，控制器名称：" + ctrl.NAME + ";异常信息：" + ex.Message;
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
                                        dmsg += "\r\n删除控制器的权限失败，控制器名称：" + item.NAME;
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
                deventlist.Add(reset);
            }
            foreach (var item in deventlist)
            {
                item.WaitOne(30000);
            }
            errMsg += dmsg;
            errMsg = errMsg.Trim('\r', '\n');
            return true;
        }
        public static bool UploadByCtrlr(Maticsoft.Model.SMT_CONTROLLER_INFO ctrlr,out string errMsg, List<Maticsoft.Model.SMT_DOOR_INFO> ctrlDoors=null)
        {
            errMsg="";
            Controller cc = ControllerHelper.ToController(ctrlr);
            using (IAccessCore access = new WGAccess())
            {
                bool ret = access.ClearAuthority(cc);
                if (!ret)
                {
                    errMsg = "清除控制器的权限异常！";
                    return false;
                }
                if (!ctrlr.IS_ENABLE)
                {
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
                return true;
            }
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
                errMsg = "无授权人员！";
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
                    var doors= staffDoors.FindAll(m=>m.STAFF_ID==staff.ID);
                    Dictionary<int,bool> aus=new Dictionary<int,bool>();
                    foreach (var d in doors)
	                {
                        var di= ctrlDoors.Find(m=>m.ID==d.DOOR_ID);
                        if (di==null)
	                    {
		                     continue;
	                    }
                        aus.Add((int)di.CTRL_DOOR_INDEX, di.IS_ENABLE);
	                }
                    bool ret = access.AddOrModifyAuthority(cc, item.CARD_NO, staff.VALID_STARTTIME, staff.VALID_ENDTIME, aus);
                    if (!ret)
                    {
                        errMsg = "添加权限中断异常！卡号：" + item.CARD_NO;
                        return false;
                    }
                }
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
            var ctrls = GetUploadCtrlr();
            if (ctrls.Count == 0)
            {
                errMsg = "没有可用控制器！";
                return false;
            }
            List<ManualResetEvent> events = new List<ManualResetEvent>();
            foreach (var item in ctrls)
            {
                ManualResetEvent reset = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                    {
                        try
                        {
                            string tmsg = "";
                            UploadByCtrlr(item, out tmsg);
                            if (tmsg != "")
                            {
                                outMsg += "\r\n" + tmsg;
                            }
                        }
                        catch (Exception ex)
                        {
                            outMsg += "\r\n" + ex.Message;
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
            return true;
        }
    }
}
