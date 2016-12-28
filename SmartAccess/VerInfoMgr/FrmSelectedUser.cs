using DevComponents.AdvTree;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.VerInfoMgr
{
    public partial class FrmSelectedUser : DevComponents.DotNetBar.Office2007Form
    {
        private List<decimal> _selectUserIds;
        private decimal _orgId = -1;
        public List<Maticsoft.Model.SMT_DEPT_USER> SelectedUsers;
        public FrmSelectedUser(List<decimal> selectUserIds,decimal orgId)
        {
            InitializeComponent();
            _selectUserIds = selectUserIds;
            _orgId = orgId;
        }

        private void FrmSelectedUser_Load(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_USER_INFO userBll = new Maticsoft.BLL.SMT_USER_INFO();
                    var models = userBll.GetModelList("IS_DELETE!=1");
                    this.Invoke(new Action(() =>
                    {
                        foreach (var item in models)
                        {
                            Node node = new Node(item.USER_NAME + "[" + item.REAL_NAME + "]");
                            node.Tag = item;
                            advTree.Nodes[0].Nodes.Add(node);
                            if (_selectUserIds.Contains(item.ID))
                            {
                                node.Checked = true;
                            }
                        }
                        advTree.Nodes[0].ExpandAll();

                    }));
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载用户异常！" + ex.Message);
                }
            });
            waiting.Show(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<Node> nodes = advTree.GetNodeList(true, typeof(Maticsoft.Model.SMT_USER_INFO));
            SelectedUsers = new List<Maticsoft.Model.SMT_DEPT_USER>();
            foreach (var item in nodes)
            {
                Maticsoft.Model.SMT_USER_INFO user = (Maticsoft.Model.SMT_USER_INFO)item.Tag;
                Maticsoft.Model.SMT_DEPT_USER du = new Maticsoft.Model.SMT_DEPT_USER();
                du.DEPT_ID = _orgId;
                du.USER_ID = user.ID;
                du.USER_INFO = user;
                SelectedUsers.Add(du);
            }
            Maticsoft.BLL.SMT_DEPT_USER duBll = new Maticsoft.BLL.SMT_DEPT_USER();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    foreach (var item in SelectedUsers)
                    {
                        if (_selectUserIds.Contains(item.USER_ID))
                        {
                            continue;
                        }
                        else
                        {
                            duBll.Add(item);
                        }
                    }
                    this.BeginInvoke(new Action(() =>
                        {
                            this.DialogResult = DialogResult.OK;
                        }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "保存异常！" + ex.Message);
                }
               
            });
            waiting.Show(this);
        }
    }
}
