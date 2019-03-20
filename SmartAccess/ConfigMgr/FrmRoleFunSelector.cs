using DevComponents.AdvTree;
using SmartAccess.Common;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ConfigMgr
{
    public partial class FrmRoleFunSelector : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmRoleFunSelector));
        private Maticsoft.Model.SMT_ROLE_INFO _roleInfo = null;
        public FrmRoleFunSelector(Maticsoft.Model.SMT_ROLE_INFO role)
        {
            InitializeComponent();
            superTabControl1.SelectedTab = superTabItem1;
            _roleInfo = role;
            deptTree.Tree.CheckBoxVisible = true;
            deptTree.TreeLoaded += deptTree_TreeLoaded;
            doorTree.Tree.CheckBoxVisible = true;
            doorTree.LoadEnded += doorTree_LoadEnded;
            faceDevTree.CheckBoxVisible = true;
            faceDevTree.LoadEnded += faceDevTree_LoadEnded;
        }

        void faceDevTree_LoadEnded(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                if (_roleInfo != null && _roleInfo.ROLE_FUNS != null)
                {
                    DoSelectFaceFuns();
                }
            }));
        }

        void doorTree_LoadEnded(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
                          {
                              if (_roleInfo != null && _roleInfo.ROLE_FUNS != null)
                              {
                                  DoSelectDoorFuns();
                              }
                          }));
        }

        private void deptTree_TreeLoaded(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
                            {
                                if (_roleInfo != null && _roleInfo.ROLE_FUNS != null)
                                {
                                    DoSelectDeptFuns();
                                }
                            }));
        }

        private void FrmRoleFunSelector_Load(object sender, EventArgs e)
        {
            if (_roleInfo!=null)
            {
               CtrlWaiting waiting = new CtrlWaiting(() =>
               {
                   try
                   {
                       Maticsoft.BLL.SMT_FUN_MENUPOINT funmPBll = new Maticsoft.BLL.SMT_FUN_MENUPOINT();
                       var models = funmPBll.GetModelList("");
                       Maticsoft.BLL.SMT_ROLE_FUN rolefunBll = new Maticsoft.BLL.SMT_ROLE_FUN();
                       _roleInfo.ROLE_FUNS = rolefunBll.GetModelList("ROLE_ID=" + _roleInfo.ID);
                       this.Invoke(new Action(() =>
                       {
                           var nodes = ToTree(models);
                           advPrivate.Nodes.Clear();
                           advPrivate.Nodes.AddRange(nodes.ToArray());
                           advPrivate.ExpandAll();
                           if (_roleInfo.ROLE_FUNS.Count == 0)
                           {
                               return;
                           }

                           DoSelectMenuFuns();

                           if (deptTree.IsLoaded)
                           {
                                DoSelectDeptFuns();
                           }

                           if (doorTree.IsLoaded)
                           {
                                DoSelectDoorFuns();
                           }

                           if (faceDevTree.IsLoaded)
                           {
                               DoSelectFaceFuns();
                           }
                       }));
                   }
                   catch (Exception ex)
                   {
                       WinInfoHelper.ShowInfoWindow(this, "加载权限异常：" + ex.Message);
                       log.Error("加载权限异常：", ex);
                   }
               });
               waiting.Show(this,300);
            }
        }
        //执行菜单选择
        private void DoSelectMenuFuns()
        {
            List<Maticsoft.Model.SMT_ROLE_FUN> funs = _roleInfo.ROLE_FUNS.FindAll(m => m.ROLE_TYPE == 1);
            foreach (Node item in advPrivate.Nodes)
            {
                DoCheckedMenu(item, funs);
            }
        }

        //执行菜单选择
        private void DoCheckedMenu(Node node, List<Maticsoft.Model.SMT_ROLE_FUN> funs)
        {
            Maticsoft.Model.SMT_FUN_MENUPOINT fun = node.Tag as Maticsoft.Model.SMT_FUN_MENUPOINT;
            if (fun==null)
            {
                if (node.Nodes.Count > 0)
                {
                    foreach (Node item in node.Nodes)
                    {
                        DoCheckedMenu(item, funs);
                    }
                }
            }
            else
            {
                if (funs.Exists(m => m.FUN_ID == fun.ID))
                {
                    if (node.Nodes.Count > 0)
                    {
                        node.CheckState = CheckState.Indeterminate;
                        foreach (Node item in node.Nodes)
                        {
                            DoCheckedMenu(item, funs);
                        }
                    }
                    else
                    {
                        node.Checked = true;
                    }
                }
            }
        }

        //执行部门选择
        private void DoSelectDeptFuns()
        {
            List<Maticsoft.Model.SMT_ROLE_FUN> funs = _roleInfo.ROLE_FUNS.FindAll(m => m.ROLE_TYPE == 2);
            foreach (Node item in deptTree.Tree.Nodes)
            {
                DoCheckedDept(item, funs);
            }
        }
        private void DoCheckedDept(Node node, List<Maticsoft.Model.SMT_ROLE_FUN> funs)
        {
            Maticsoft.Model.SMT_ORG_INFO fun = node.Tag as Maticsoft.Model.SMT_ORG_INFO;
            if (fun == null)
            {
                if (node.Nodes.Count > 0)
                {
                    foreach (Node item in node.Nodes)
                    {
                        DoCheckedDept(item, funs);
                    }
                }
            }
            else
            {
                if (funs.Exists(m => m.FUN_ID == fun.ID))
                {
                    node.Checked = true;
                    node.EnsureVisible();
                }
                else
                {
                    foreach (Node item in node.Nodes)
                    {
                        DoCheckedDept(item, funs);
                    }
                }
            }
        }

        //执行门禁选择
        private void DoSelectDoorFuns()
        {
            List<Maticsoft.Model.SMT_ROLE_FUN> funs = _roleInfo.ROLE_FUNS.FindAll(m => m.ROLE_TYPE == 3);
            foreach (Node item in doorTree.Tree.Nodes)
            {
                DoCheckedDoor(item, funs);
            }
        }
        private void DoSelectFaceFuns()
        {
            List<Maticsoft.Model.SMT_ROLE_FUN> funs = _roleInfo.ROLE_FUNS.FindAll(m => m.ROLE_TYPE == 4);
            foreach (Node item in faceDevTree.Tree.Nodes)
            {
                DoCheckedFace(item, funs);
            }
        }
        private void DoCheckedFace(Node node, List<Maticsoft.Model.SMT_ROLE_FUN> funs)
        {
            Maticsoft.Model.SMT_FACERECG_DEVICE fun = node.Tag as Maticsoft.Model.SMT_FACERECG_DEVICE;
            if (fun == null)
            {
                if (node.Nodes.Count > 0)
                {
                    foreach (Node item in node.Nodes)
                    {
                        DoCheckedFace(item, funs);
                    }
                }
            }
            else
            {
                if (funs.Exists(m => m.FUN_ID == fun.ID))
                {
                    node.Checked = true;
                    node.EnsureVisible();
                }
                else
                {
                    foreach (Node item in node.Nodes)
                    {
                        DoCheckedFace(item, funs);
                    }
                }
            }
        }
        private void DoCheckedDoor(Node node, List<Maticsoft.Model.SMT_ROLE_FUN> funs)
        {
            Maticsoft.Model.SMT_DOOR_INFO fun = node.Tag as Maticsoft.Model.SMT_DOOR_INFO;
            if (fun == null)
            {
                if (node.Nodes.Count > 0)
                {
                    foreach (Node item in node.Nodes)
                    {
                        DoCheckedDoor(item, funs);
                    }
                }
            }
            else
            {
                if (funs.Exists(m => m.FUN_ID == fun.ID))
                {
                    node.Checked = true;
                    node.EnsureVisible();
                }
                else
                {
                    foreach (Node item in node.Nodes)
                    {
                        DoCheckedDoor(item, funs);
                    }
                }
            }
        }

        public List<DevComponents.AdvTree.Node> ToTree(List<Maticsoft.Model.SMT_FUN_MENUPOINT> funs)
        {
            List<DevComponents.AdvTree.Node> tree = new List<DevComponents.AdvTree.Node>();
            if (funs == null || funs.Count == 0)
            {
                return tree;
            }
            else
            {
                List<Maticsoft.Model.SMT_FUN_MENUPOINT> remvs = new List<Maticsoft.Model.SMT_FUN_MENUPOINT>();
                //寻找根节点
                for (int i = 0; i < funs.Count; i++)
                {
                    decimal? dec = funs[i].PAR_ID;
                  

                    if (dec == null)
                    {
                        tree.Add(CreateNode(funs[i]));
                        remvs.Add(funs[i]);
                    }
                    if (funs.Exists(m =>
                    {
                        if (m == funs[i])
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
                    tree.Add(CreateNode(funs[i]));
                    remvs.Add(funs[i]);
                }
                remvs.ForEach(m => funs.Remove(m));
                foreach (var root in tree)
                {
                    GetSubTree(root, funs);
                }
            }
            return tree;
        }
        public DevComponents.AdvTree.Node CreateNode(Maticsoft.Model.SMT_FUN_MENUPOINT fun)
        {
            DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node(fun.FUN_NAME + " [" + fun.FUN_CODE + "]");
            node.Tag = fun;
            node.Tooltip = fun.FUN_NAME + " [" + fun.FUN_CODE + "]";
            return node;
        }
        private void GetSubTree(DevComponents.AdvTree.Node root, List<Maticsoft.Model.SMT_FUN_MENUPOINT> funs)
        {
            Maticsoft.Model.SMT_FUN_MENUPOINT rootarea = (Maticsoft.Model.SMT_FUN_MENUPOINT)root.Tag;
            List<Maticsoft.Model.SMT_FUN_MENUPOINT> subAreas = funs.FindAll(m => m.PAR_ID == rootarea.ID);
            subAreas.ForEach(m => funs.Remove(m));
            foreach (var item in subAreas)
            {
                SYS_FUN_POINT point;
                if (Enum.TryParse<SYS_FUN_POINT>(item.FUN_CODE, out point))
                {
                    if (point == SYS_FUN_POINT.USER_PRIVATE_CONFIG)
                    {
                        continue;
                    }
                }
                DevComponents.AdvTree.Node node = CreateNode(item);
                GetSubTree(node, funs);
                root.Nodes.Add(node);
            }
        }


        private List<T> GetSelectModels<T>(Li.Controls.AdvTreeEx tree,params CheckState[] states)
        {
            List<Node> selectNodes = tree.GetNodeList(states.ToList(), typeof(T));
            List<T> funs = new List<T>();
            foreach (Node item in selectNodes)
            {
                funs.Add((T)item.Tag);
            }
            return funs;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //读取菜单权限
            List<Maticsoft.Model.SMT_FUN_MENUPOINT> funs = GetSelectModels<Maticsoft.Model.SMT_FUN_MENUPOINT>(advPrivate, CheckState.Indeterminate, CheckState.Checked);
            
            //读取部门菜单
            List<Maticsoft.Model.SMT_ORG_INFO> orgs = null;
            if (deptTree.IsLoaded)
            {
                orgs = GetSelectModels<Maticsoft.Model.SMT_ORG_INFO>(deptTree.Tree,CheckState.Checked);
            }
            //读取门参数
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = null;
            if (doorTree.IsLoaded)
            {
                doors = GetSelectModels<Maticsoft.Model.SMT_DOOR_INFO>(doorTree.Tree, CheckState.Checked);
            }

            //读取人脸参数
            List<Maticsoft.Model.SMT_FACERECG_DEVICE> faces = null;
            if (faceDevTree.IsLoaded)
            {
                faces = GetSelectModels<Maticsoft.Model.SMT_FACERECG_DEVICE>(faceDevTree.Tree, CheckState.Checked);
            }

            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_ROLE_FUN rolefunBll = new Maticsoft.BLL.SMT_ROLE_FUN();
                    Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_ROLE_FUN where ROLE_ID=" + _roleInfo.ID+" and (ROLE_TYPE=1 or ROLE_TYPE is null)");
                    
                    if (funs.Count > 0)
                    {
                        foreach (var item in funs)
                        {
                            Maticsoft.Model.SMT_ROLE_FUN rf = new Maticsoft.Model.SMT_ROLE_FUN();
                            rf.ROLE_ID = _roleInfo.ID;
                            rf.FUN_ID = item.ID;
                            rf.ROLE_TYPE = 1;
                            rolefunBll.Add(rf);
                        }
                    }
                    SmtLog.InfoFormat("用户", "更新角色：{0}菜单权限，个数：{1}.", _roleInfo.ROLE_NAME, funs.Count);

                    if (orgs!=null)
                    {
                        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_ROLE_FUN where ROLE_ID=" + _roleInfo.ID + " and ROLE_TYPE=2");
                        foreach (var item in orgs)
                        {
                            Maticsoft.Model.SMT_ROLE_FUN rf = new Maticsoft.Model.SMT_ROLE_FUN();
                            rf.ROLE_ID = _roleInfo.ID;
                            rf.FUN_ID = item.ID;
                            rf.ROLE_TYPE = 2;
                            rolefunBll.Add(rf);
                        }
                        SmtLog.InfoFormat("用户", "更新角色：{0}部门权限，个数：{1}.", _roleInfo.ROLE_NAME, orgs.Count);
                    }
                   

                    if (doors != null)
                    {
                        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_ROLE_FUN where ROLE_ID=" + _roleInfo.ID + " and ROLE_TYPE=3");
                        foreach (var item in doors)
                        {
                            Maticsoft.Model.SMT_ROLE_FUN rf = new Maticsoft.Model.SMT_ROLE_FUN();
                            rf.ROLE_ID = _roleInfo.ID;
                            rf.FUN_ID = item.ID;
                            rf.ROLE_TYPE = 3;
                            rolefunBll.Add(rf);
                        }
                        SmtLog.InfoFormat("用户", "更新角色：{0}门禁权限，个数：{1}.", _roleInfo.ROLE_NAME, doors.Count);
                    }

                    if (faces != null)
                    {
                        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_ROLE_FUN where ROLE_ID=" + _roleInfo.ID + " and ROLE_TYPE=4");
                        foreach (var item in faces)
                        {
                            Maticsoft.Model.SMT_ROLE_FUN rf = new Maticsoft.Model.SMT_ROLE_FUN();
                            rf.ROLE_ID = _roleInfo.ID;
                            rf.FUN_ID = item.ID;
                            rf.ROLE_TYPE = 4;
                            rolefunBll.Add(rf);
                        }
                        SmtLog.InfoFormat("用户", "更新角色：{0}人脸设备权限，个数：{1}.", _roleInfo.ROLE_NAME, faces.Count);
                    }

                    this.Invoke(new Action(() =>
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "更新角色权限失败：" + ex.Message);
                    log.Error("更新角色权限失败：", ex);
                }
            });
            waiting.Show(this);
        }
    }
}
