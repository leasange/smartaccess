using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAccess.Common.Datas
{
    /// <summary>
    /// 区域类
    /// </summary>
    public class AreaDataHelper
    {
        private static List<Maticsoft.Model.SMT_CONTROLLER_ZONE> _areas = null;
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(AreaDataHelper));
        /// <summary>
        /// 强制刷新区域
        /// </summary>
        public static void UpdateAreas()
        {
            try
            {
                _areas = null;
                Maticsoft.BLL.SMT_CONTROLLER_ZONE bll = new Maticsoft.BLL.SMT_CONTROLLER_ZONE();
                _areas = bll.GetModelList("1=1 order by ORDER_VALUE");
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(null,"获取区域列表异常:" + ex.Message);
                log.Error("获取区域列表异常：", ex);
            }
        }
        /// <summary>
        /// 获取区域列表
        /// </summary>
        /// <param name="refresh">是否刷新</param>
        /// <returns>区域列表</returns>
        public static List<Maticsoft.Model.SMT_CONTROLLER_ZONE> GetAreas(bool refresh = false)
        {
            if (_areas == null || refresh)
            {
                UpdateAreas();
            }
            if (_areas==null||_areas.Count==0)
            {
                return new List<Maticsoft.Model.SMT_CONTROLLER_ZONE>();
            }
            var temp = new List<Maticsoft.Model.SMT_CONTROLLER_ZONE>();
            temp.AddRange(_areas);
            return temp;
        }
        /// <summary>
        /// 创建树形节点
        /// </summary>
        /// <param name="area">区域</param>
        /// <returns>节点</returns>
        public static DevComponents.AdvTree.Node CreateNode(Maticsoft.Model.SMT_CONTROLLER_ZONE area)
        {
            DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node(area.ZONE_NAME);
            node.Tag = area;
            node.Image = Properties.Resources.house1818;
            node.Tooltip = area.ZONE_DESC;
            return node;
        }
        public static void UpdateNode(DevComponents.AdvTree.Node node,Maticsoft.Model.SMT_CONTROLLER_ZONE area)
        {
            if (node==null)
            {
                return;
            }
            node.Text = area.ZONE_NAME;
            node.Tag = area;
            node.Image = Properties.Resources.house1818;
            node.Tooltip = area.ZONE_DESC;
        }
        /// <summary>
        /// 递归创建下级节点
        /// </summary>
        /// <param name="root">当前节点</param>
        /// <param name="areas">区域列表</param>
        private static void GetSubTree(DevComponents.AdvTree.Node root,List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE rootarea = (Maticsoft.Model.SMT_CONTROLLER_ZONE)root.Tag;
            List<Maticsoft.Model.SMT_CONTROLLER_ZONE> subAreas= areas.FindAll(m => m.PAR_ID == rootarea.ID);
            subAreas.ForEach(m => areas.Remove(m));
            foreach (var item in subAreas)
            {
                DevComponents.AdvTree.Node node= CreateNode(item);
                GetSubTree(node, areas);
                root.Nodes.Add(node);
            }
        }

        public static List<DevComponents.AdvTree.Node> ToTree(List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas)
        {
            List<DevComponents.AdvTree.Node> tree = new List<DevComponents.AdvTree.Node>();
            if (areas == null || areas.Count == 0)
            {
                return tree;
            }
            else
            {
                List<Maticsoft.Model.SMT_CONTROLLER_ZONE> remvs = new List<Maticsoft.Model.SMT_CONTROLLER_ZONE>();
                //寻找根节点
                for (int i = 0; i < areas.Count; i++)
                {
                    decimal? dec = areas[i].PAR_ID;
                    if (dec == null)
                    {
                        tree.Add(CreateNode(areas[i]));
                        remvs.Add(areas[i]);
                    }
                    if (areas.Exists(m =>
                    {
                        if (m == areas[i])
                        {
                            return false;
                        }
                        if (m.ID == (decimal)dec)
                        {
                            return true;
                        }
                        return false;
                    }))
                    {
                        continue;
                    }
                    tree.Add(CreateNode(areas[i]));
                    remvs.Add(areas[i]);
                }
                remvs.ForEach(m => areas.Remove(m));
                foreach (var root in tree)
                {
                    GetSubTree(root, areas);
                }
            }
            return tree;
        }

        public static bool UpdateArea(Maticsoft.Model.SMT_CONTROLLER_ZONE Area)
        {
            Maticsoft.BLL.SMT_CONTROLLER_ZONE bll = new Maticsoft.BLL.SMT_CONTROLLER_ZONE();
            bool ret= bll.Update(Area);
            var area= _areas.Find(m => m.ID == Area.ID);
            if (area!=null&&area!=Area)
            {
                _areas.Remove(area);
                _areas.Add(Area);
            }
            else if (area==null)
            {
                _areas.Add(Area);
            }
            return ret;
        }
        public static decimal AddArea(Maticsoft.Model.SMT_CONTROLLER_ZONE Area)
        {
            Maticsoft.BLL.SMT_CONTROLLER_ZONE bll = new Maticsoft.BLL.SMT_CONTROLLER_ZONE();

            Area.ID = bll.Add(Area);
            _areas.Add(Area);
            return Area.ID;
        }

        public static void DeleteAreas(List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas)
        {
            Maticsoft.BLL.SMT_CONTROLLER_ZONE bll = new Maticsoft.BLL.SMT_CONTROLLER_ZONE();
            string ids = "";
            foreach (var item in areas)
            {
                ids += item.ID + ",";
            }
            ids = ids.TrimEnd(',');
            bll.DeleteList(ids);
            areas.ForEach(m =>
                {
                    var temp = _areas.Find(n => n.ID == m.ID);
                    if (temp!=null)
                    {
                        _areas.Remove(temp);
                    }
                });
        }
    }
}
