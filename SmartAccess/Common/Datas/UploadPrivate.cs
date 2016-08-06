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
                errMsg = "上传失败，该用户没有授权的卡片！";
                WinInfo.WinInfoHelper.ShowInfoWindow(null, "上传失败，该用户没有授权的卡片！");
                return false;
            }
            if (allDoors == null)
            {
                allDoors = GetUploadAllDoors();
            }
            if (allDoors.Count == 0)
            {
                errMsg = "上传失败，当前没有任何门！";
                WinInfo.WinInfoHelper.ShowInfoWindow(null, "上传失败，当前没有任何门！");
                return false;
            }
            if (ctrlrs == null)
            {
                ctrlrs = GetUploadCtrlr();
            }
            if (ctrlrs.Count==0)
            {
                errMsg = "上传失败，当前没有任何可用控制器！";
                WinInfo.WinInfoHelper.ShowInfoWindow(null, "上传失败，当前没有任何可用控制器！");
                return false;
            }
            if (staffInfo.IS_DELETE||staffInfo.IS_FORBIDDEN)//被删除、禁用或者挂失
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
                        doorNumAuthorities.Add((int)d.CTRL_DOOR_INDEX, true);
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
    }
}
