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

namespace SmartAccess.VerInfoMgr
{
    public partial class FrmRolesSelector :DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmRolesSelector));
        private List<decimal> _selectedids = null;
        private decimal _orgId = 0;
        public List<Maticsoft.Model.SMT_ROLE_INFO> SelectRoles { get; set; }
        public FrmRolesSelector(List<decimal> selectedids,decimal orgId)
        {
            InitializeComponent();
            _selectedids = selectedids;
            _orgId = orgId;
        }

        private void FrmRolesSelector_Load(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_ROLE_INFO roleBll = new Maticsoft.BLL.SMT_ROLE_INFO();
                    var models= roleBll.GetModelList("");
                    this.Invoke(new Action(() =>
                    {
                        this.advRoleTree.Nodes[0].Nodes.Clear();
                        if (models.Count==0)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "没有获取到角色列表！");
                            return;
                        }
                        foreach (var item in models)
                        {
                            Node node = new Node(item.ROLE_NAME);
                            node.Tooltip = item.ROLE_DESC;
                            advRoleTree.Nodes[0].Nodes.Add(node);
                            node.Tag = item;
                            if (_selectedids != null && _selectedids.Count>0)
                            {
                                if (_selectedids.Contains(item.ID))
                                {
                                    node.Checked = true;
                                }
                            }
                        }
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载角色列表异常："+ex.Message);
                    log.Error("加载角色列表异常：", ex);
                }
            });
            waiting.Show(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void DoSave()
        {
            SelectRoles = advRoleTree.GetTypeList<Maticsoft.Model.SMT_ROLE_INFO>(new List<CheckState> { CheckState.Checked });

            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_ROLE_FUN roleBll = new Maticsoft.BLL.SMT_ROLE_FUN();
                    Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_ROLE_FUN  where FUN_ID=" + _orgId + " and ROLE_TYPE=2");
                    foreach (var item in SelectRoles)
                    {
                        roleBll.Add(new Maticsoft.Model.SMT_ROLE_FUN()
                        {
                            ROLE_ID=item.ID,
                            ROLE_TYPE=2,
                            FUN_ID=_orgId
                        });
                    }

                    this.Invoke(new Action(() =>
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "保存失败:"+ex.Message);
                    log.Error("保存授权角色失败：", ex);
                }
            });
            waiting.Show(this);
        }

    }
}
