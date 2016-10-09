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
            _roleInfo = role;
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
                       this.Invoke(new Action(() =>
                       {
                           var nodes = ToTree(models);
                           advPrivate.Nodes.Clear();
                           advPrivate.Nodes.AddRange(nodes.ToArray());
                           advPrivate.ExpandAll();
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
                DevComponents.AdvTree.Node node = CreateNode(item);
                GetSubTree(node, funs);
                root.Nodes.Add(node);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
