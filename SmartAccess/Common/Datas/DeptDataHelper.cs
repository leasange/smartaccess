using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartAccess.Common.Datas
{
    /// <summary>
    /// 部门类
    /// </summary>
    public class DeptDataHelper
    {
        private static List<Maticsoft.Model.SMT_ORG_INFO> _depts = null;
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(AreaDataHelper));
        /// <summary>
        /// 强制刷新区域
        /// </summary>
        public static void UpdateDepts()
        {
            try
            {
                _depts = null;
                Maticsoft.BLL.SMT_ORG_INFO bll = new Maticsoft.BLL.SMT_ORG_INFO();
                _depts = bll.GetModelList("1=1 order by ORDER_VALUE");
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(null,"获取区域列表异常:" + ex.Message);
                log.Error("获取区域列表异常：", ex);
            }
        }
        public static void UpdateDept(Maticsoft.Model.SMT_ORG_INFO model)
        {
            Maticsoft.BLL.SMT_ORG_INFO bll = new Maticsoft.BLL.SMT_ORG_INFO();
            bll.Update(model);
            if (_depts!=null)
            {
                Maticsoft.Model.SMT_ORG_INFO ff = _depts.Find(m => m.ID == model.ID);
                if (ff != null)
                {
                    ff.PAR_ID = model.PAR_ID;
                    ff.ORG_CODE = model.ORG_CODE;
                    ff.ORDER_VALUE = model.ORDER_VALUE;
                    ff.ORG_NAME = model.ORG_NAME;
                }
            }
        }
        /// <summary>
        /// 获取区域列表
        /// </summary>
        /// <param name="refresh">是否刷新</param>
        /// <returns>区域列表</returns>
        public static List<Maticsoft.Model.SMT_ORG_INFO> GetDepts(bool refresh = false)
        {
            if (_depts == null || refresh)
            {
                UpdateDepts();
            }
            if (_depts==null||_depts.Count==0)
            {
                return new List<Maticsoft.Model.SMT_ORG_INFO>();
            }
            var temp = new List<Maticsoft.Model.SMT_ORG_INFO>();
            temp.AddRange(_depts);
            return temp;
        }
        /// <summary>
        /// 创建树形节点
        /// </summary>
        /// <param name="dept">区域</param>
        /// <returns>节点</returns>
        public static DevComponents.AdvTree.Node CreateNode(Maticsoft.Model.SMT_ORG_INFO dept)
        {
            DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node(dept.ORG_NAME + " [" + dept.ORG_CODE + "]");
            node.Tag = dept;
            node.Image = Properties.Resources.添加下级部门;
            node.Tooltip = dept.ORG_NAME + " [" + dept.ORG_CODE+"]";
            return node;
        }
        /// <summary>
        /// 递归创建下级节点
        /// </summary>
        /// <param name="root">当前节点</param>
        /// <param name="depts">区域列表</param>
        private static void GetSubTree(DevComponents.AdvTree.Node root,List<Maticsoft.Model.SMT_ORG_INFO> depts)
        {
            Maticsoft.Model.SMT_ORG_INFO rootarea = (Maticsoft.Model.SMT_ORG_INFO)root.Tag;
            List<Maticsoft.Model.SMT_ORG_INFO> subAreas= depts.FindAll(m => m.PAR_ID == rootarea.ID);
            subAreas.ForEach(m => depts.Remove(m));
            foreach (var item in subAreas)
            {
                DevComponents.AdvTree.Node node= CreateNode(item);
                GetSubTree(node, depts);
                root.Nodes.Add(node);
            }
        }

        public static List<DevComponents.AdvTree.Node> ToTree(List<Maticsoft.Model.SMT_ORG_INFO> depts)
        {
            List<DevComponents.AdvTree.Node> tree = new List<DevComponents.AdvTree.Node>();
            if (depts == null || depts.Count == 0)
            {
                return tree;
            }
            else
            {
                List<Maticsoft.Model.SMT_ORG_INFO> remvs = new List<Maticsoft.Model.SMT_ORG_INFO>();
                //寻找根节点
                for (int i = 0; i < depts.Count; i++)
                {
                    decimal? dec = depts[i].PAR_ID;
                    if (dec == null)
                    {
                        tree.Add(CreateNode(depts[i]));
                        remvs.Add(depts[i]);
                    }
                    if (depts.Exists(m =>
                    {
                        if (m == depts[i])
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
                    tree.Add(CreateNode(depts[i]));
                    remvs.Add(depts[i]);
                }
                remvs.ForEach(m => depts.Remove(m));
                foreach (var root in tree)
                {
                    GetSubTree(root, depts);
                }
            }
            return tree;
        }


        public static decimal AddDept(Maticsoft.Model.SMT_ORG_INFO dept)
        {
            Maticsoft.BLL.SMT_ORG_INFO bll = new Maticsoft.BLL.SMT_ORG_INFO();

            dept.ID = bll.Add(dept);
            _depts.Add(dept);
            return dept.ID;
        }

        public static Maticsoft.Model.SMT_ORG_INFO GetDeptByCode(string deptCode)
        {
            Maticsoft.BLL.SMT_ORG_INFO bll = new Maticsoft.BLL.SMT_ORG_INFO();
            var c = bll.GetModelList("ORG_CODE='" + deptCode + "'");
            if (c.Count > 0)
            {
                return c[0];
            }
            return null;
        }

        public static void DeleteDepts(List<Maticsoft.Model.SMT_ORG_INFO> depts)
        {
            Maticsoft.BLL.SMT_ORG_INFO bll = new Maticsoft.BLL.SMT_ORG_INFO();
            string ids = "";
            foreach (var item in depts)
            {
                ids += item.ID + ",";
            }
            ids = ids.TrimEnd(',');
            bll.DeleteList(ids);
            _depts = null;
        }


    }
}
