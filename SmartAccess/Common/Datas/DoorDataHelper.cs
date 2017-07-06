using DevComponents.AdvTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SmartAccess.Common.Datas
{
    public class DoorDataHelper
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(DoorDataHelper));

        public static List<Maticsoft.Model.SMT_DOOR_INFO> LastDoors = null;

        public static List<Node> ToTree(List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas,List<Maticsoft.Model.SMT_DOOR_INFO> doors)
        {
            var nodes = AreaDataHelper.ToTree(areas);
            CreateDoorTree(nodes, doors);
            return nodes;
        }
        public static List<Maticsoft.Model.SMT_DOOR_INFO> GetDoors()
        {
            Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
            if (UserInfoHelper.UserInfo.USER_NAME == "admin" ||
                PrivateMgr.FUN_POINTS.Contains(SYS_FUN_POINT.USER_PRIVATE_CONFIG))
            {
                LastDoors = doorBll.GetModelListWithArea("");
                return LastDoors;
            }
            else
            {
                if (UserInfoHelper.UserInfo.ROLE_ID == null)
                {
                    return new List<Maticsoft.Model.SMT_DOOR_INFO>();
                }
                string strWhere = "ID IN (SELECT FUN_ID FROM SMT_ROLE_FUN WHERE ROLE_TYPE=3 and ROLE_ID=" + UserInfoHelper.UserInfo.ROLE_ID + ")";
                LastDoors= doorBll.GetModelListWithArea(strWhere);
                return LastDoors;
            }

        }
        public static List<Maticsoft.Model.SMT_DOOR_INFO> GetDoors(string ctrlId)
        {
            Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
            return doorBll.GetModelList("CTRL_ID=" + ctrlId);
        }

        public static void UpdateDoorSync(Maticsoft.Model.SMT_DOOR_INFO door)
        {
            if (door!=null)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                    {
                        try
                        {
                            Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
                            doorBll.Update(door);
                        }
                        catch (Exception ex)
                        {
                            log.Error("更新门禁异常：", ex);
                        }
                    }));
            }
        }

        private static void CreateDoorTree(List<Node> nodes, List<Maticsoft.Model.SMT_DOOR_INFO> doors)
        {
            foreach (var item in nodes)
            {
                DoCreateNodes(item, doors);
            }
            for (int i = doors.Count - 1; i >= 0; i--)
            {
                var item = doors[i];
                Node doorNode = new Node("<font color='blue'>" + item.DOOR_NAME + "</font>");
                doorNode.Image = Properties.Resources.door1818;
                doorNode.Tag = item;
                nodes.Insert(0, doorNode);
            }
            Node root = new Node("所有的门");
            root.Image = Properties.Resources.house1818;
            root.Nodes.AddRange(nodes.ToArray());
            nodes.Clear();
            nodes.Add(root);
        }
        private static void DoCreateNodes(Node node, List<Maticsoft.Model.SMT_DOOR_INFO> doors)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE zone = node.Tag as Maticsoft.Model.SMT_CONTROLLER_ZONE;
            if (zone != null)
            {
                var fdoors = doors.FindAll(m => m.AREA_ID == zone.ID);
                for (int i = fdoors.Count - 1; i >= 0; i--)
                {
                    var item = fdoors[i];
                    Node doorNode = new Node("<font color='blue'>" + item.DOOR_NAME + "</font>");
                    doorNode.Tag = item;
                    doorNode.Image = Properties.Resources.door1818;
                    node.Nodes.Insert(0, doorNode);
                    doors.Remove(item);
                }
                //node.Text += " (" + fdoors.Count + ")";
            }
            foreach (Node item in node.Nodes)
            {
                DoCreateNodes(item, doors);
            }
        }
    }
}
