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

        private static List<Maticsoft.Model.SMT_ORG_INFO> _allDepts = null;


        public static List<Maticsoft.Model.SMT_ORG_INFO> FindAllParent(decimal orgId)
        {
            var list = new List<Maticsoft.Model.SMT_ORG_INFO>();
            if (_allDepts==null||_allDepts.Count==0)
            {
                return list;
            }
            var org = _allDepts.Find(m => m.ID == orgId);
            if (org==null)
            {
                return list;
            }
            var t = org;
            do
            {

                var par = _allDepts.Find(m => m.ID == t.PAR_ID);
                if (par != null && !list.Contains(par))
                {
                    list.Add(par);
                    t = par;
                }
                else break;

            } while (true);
            return list;
        }

        /// <summary>
        /// 强制刷新部门
        /// </summary>
        public static void UpdateDepts()
        {
            try
            {
                _depts = null;
                _allDepts = null;
                Maticsoft.BLL.SMT_ORG_INFO bll = new Maticsoft.BLL.SMT_ORG_INFO();

                if (UserInfoHelper.UserInfo.USER_NAME == "admin" || PrivateMgr.FUN_POINTS.Contains(SYS_FUN_POINT.USER_PRIVATE_CONFIG) || PrivateMgr.FUN_POINTS.Contains(SYS_FUN_POINT.DEPT_MGR))
                {
                    log.Debug("管理员加载部门...");
                    _depts = bll.GetModelList("1=1 order by ORDER_VALUE");
                    if (_allDepts == null)
                    {
                        _allDepts = new List<Maticsoft.Model.SMT_ORG_INFO>();
                    }
                    _allDepts.Clear();
                    _allDepts.AddRange(_depts);
                }
                else
                {
                    log.Debug("普通用户加载部门...");
                    _allDepts = bll.GetModelList("1=1 order by ORDER_VALUE");

                    Maticsoft.BLL.SMT_ROLE_FUN rbll = new Maticsoft.BLL.SMT_ROLE_FUN();
                    var funs = rbll.GetModelList("ROLE_TYPE=2 and ROLE_ID=" + UserInfoHelper.UserInfo.ROLE_ID);// _depts = bll.GetModelList("id in (select RF.FUN_ID from SMT_ROLE_FUN RF where RF.ROLE_TYPE=2 and RF.ROLE_ID=" + UserInfoHelper.UserInfo.ROLE_ID + ")  order by ORDER_VALUE");
                    _depts = _allDepts.FindAll(m => funs.Exists(n => n.FUN_ID == m.ID));
                }

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
        public static DevComponents.AdvTree.Node CreateNode(Maticsoft.Model.SMT_ORG_INFO dept, List<Maticsoft.Model.SMT_ORG_INFO> parDepts)
        {
            DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node(dept.ORG_NAME + " [" + dept.ORG_CODE + "]");
            node.Tag = dept;
            node.Image = Properties.Resources.添加下级部门;
            node.Tooltip = dept.ORG_NAME + " [" + dept.ORG_CODE+"]";
            if (parDepts!=null&&parDepts.Count > 0)
            {
                if (parDepts.Contains(dept))
                {
                    node.Text = "<i><font color=\"#444444\">" + node.Text + "</font></i>";
                    node.Tooltip = "<font color=\"red\">" + node.Tooltip + " 【不可选节点】</font>";
                    node.DataKey = "0";
                }
                else
                {
                    node.DataKey = "1";
                }
            }

            return node;
        }
        /// <summary>
        /// 递归创建下级节点
        /// </summary>
        /// <param name="root">当前节点</param>
        /// <param name="depts">区域列表</param>
        private static void GetSubTree(DevComponents.AdvTree.Node root, List<Maticsoft.Model.SMT_ORG_INFO> depts, List<Maticsoft.Model.SMT_ORG_INFO> parDepts)
        {
            Maticsoft.Model.SMT_ORG_INFO rootarea = (Maticsoft.Model.SMT_ORG_INFO)root.Tag;
            List<Maticsoft.Model.SMT_ORG_INFO> subAreas= depts.FindAll(m => m.PAR_ID == rootarea.ID);
            subAreas.ForEach(m => depts.Remove(m));
            foreach (var item in subAreas)
            {
                DevComponents.AdvTree.Node node = CreateNode(item, parDepts);
                GetSubTree(node, depts, parDepts);
                root.Nodes.Add(node);
            }
        }

        public static List<DevComponents.AdvTree.Node> ToTree(List<Maticsoft.Model.SMT_ORG_INFO> depts)
        {
            var allDepts = _allDepts;
            List<DevComponents.AdvTree.Node> tree = new List<DevComponents.AdvTree.Node>();
            if (depts == null || depts.Count == 0)
            {
                return tree;
            }

            var treedepts = depts.ToList();

            List<Maticsoft.Model.SMT_ORG_INFO> parDepts = new List<Maticsoft.Model.SMT_ORG_INFO>();
            if (allDepts != null && depts.Count < allDepts.Count)
            {
                List<Maticsoft.Model.SMT_ORG_INFO> tempAll = allDepts.ToList();
                foreach (var item in depts)
                {
                    var t = item;
                    do
                    {
                        var parDept = tempAll.Find(m => m.ID == t.PAR_ID);
                        if (parDept != null)
                        {
                            if (!treedepts.Contains(parDept))
                            {
                                parDepts.Add(parDept);
                                tempAll.Remove(parDept);
                            }
                            else break;
                        }
                        else
                        {
                            break;
                        }
                        t = parDept;
                    } while (true);
                  
                }
            }

            treedepts.AddRange(parDepts);

            List<Maticsoft.Model.SMT_ORG_INFO> remvs = new List<Maticsoft.Model.SMT_ORG_INFO>();
            //寻找根节点
            for (int i = 0; i < treedepts.Count; i++)
            {
                decimal dec = treedepts[i].PAR_ID;
                /*if (dec == null)
                {
                    tree.Add(CreateNode(treedepts[i]));
                    remvs.Add(treedepts[i]);
                }*/
                if (treedepts.Exists(m =>
                {
                    if (m == treedepts[i])
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
                tree.Add(CreateNode(treedepts[i], parDepts));
                remvs.Add(treedepts[i]);
            }
            remvs.ForEach(m => treedepts.Remove(m));
            foreach (var root in tree)
            {
                GetSubTree(root, treedepts, parDepts);
            }
            return tree;
        }


        public static decimal AddDept(Maticsoft.Model.SMT_ORG_INFO dept)
        {
            Maticsoft.BLL.SMT_ORG_INFO bll = new Maticsoft.BLL.SMT_ORG_INFO();

            dept.ID = bll.Add(dept);
            if (_depts!=null)
            {
               _depts.Add(dept);
            }
            if (_allDepts!=null)
            {
                _allDepts.Add(dept);
            }
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
            _allDepts = null;
        }


    }
}
