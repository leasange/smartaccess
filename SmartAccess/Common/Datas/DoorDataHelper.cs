using DevComponents.AdvTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAccess.Common.Datas
{
    public class DoorDataHelper
    {
        public static List<Node> ToTree(List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas,List<Maticsoft.Model.SMT_DOOR_INFO> doors)
        {
            var nodes = AreaDataHelper.ToTree(areas);
            CreateDoorTree(nodes, doors);
            return nodes;
        }
        public static List<Maticsoft.Model.SMT_DOOR_INFO> GetDoors()
        {
            Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
            return doorBll.GetModelListWithArea("");
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
                doorNode.Tag = item;
                nodes.Insert(0, doorNode);
            }
            Node root = new Node("所有的门");
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
                    node.Nodes.Insert(0, doorNode);
                    doors.Remove(item);
                }
                node.Text += " (" + fdoors.Count + ")";
            }
            foreach (Node item in node.Nodes)
            {
                DoCreateNodes(item, doors);
            }
        }
    }
}
