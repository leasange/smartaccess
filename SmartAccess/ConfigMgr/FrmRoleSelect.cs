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
    public partial class FrmRoleSelect :DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmRoleSelect));
        public Maticsoft.Model.SMT_ROLE_INFO SELECT_ROLE = null;
        private Maticsoft.Model.SMT_USER_INFO _userInfo = null;
        public FrmRoleSelect(Maticsoft.Model.SMT_USER_INFO user)
        {
            InitializeComponent();
            _userInfo = user;
        }

        private void FrmRoleSelect_Load(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_ROLE_INFO roleBll = new Maticsoft.BLL.SMT_ROLE_INFO();
                    var models= roleBll.GetModelList("");
                    this.Invoke(new Action(() =>
                    {
                        this.advRoleTree.Nodes.Clear();
                        if (models.Count==0)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "没有获取到角色列表！");
                            return;
                        }
                        foreach (var item in models)
                        {
                            Node node = new Node(item.ROLE_NAME);
                            node.Tooltip = item.ROLE_DESC;
                            advRoleTree.Nodes.Add(node);
                            node.Tag = item;
                            if (item.ID == _userInfo.ROLE_ID)
                            {
                                advRoleTree.SelectedNode = node;
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
            if (advRoleTree.SelectedNode==null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择一个角色！");
                return;
            }
            SELECT_ROLE = (Maticsoft.Model.SMT_ROLE_INFO)advRoleTree.SelectedNode.Tag;
            DoSave();
        }

        private void advRoleTree_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            SELECT_ROLE = (Maticsoft.Model.SMT_ROLE_INFO)e.Node.Tag;
            DoSave();
        }
        private void DoSave()
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                decimal? old = _userInfo.ROLE_ID;
                try
                {
                    _userInfo.ROLE_ID = SELECT_ROLE.ID;
                    Maticsoft.BLL.SMT_USER_INFO userBll = new Maticsoft.BLL.SMT_USER_INFO();
                    userBll.Update(_userInfo);
                    SmtLog.InfoFormat("用户", "修改用户:{0},角色:{1}成功.", _userInfo.USER_NAME, _userInfo.ROLE_ID + ":" + SELECT_ROLE.ROLE_NAME);
                    this.Invoke(new Action(() =>
                    {
                        _userInfo.ROLE_NAME = SELECT_ROLE.ROLE_NAME+"(点击修改)";
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }));
                }
                catch (Exception ex)
                {
                    _userInfo.ROLE_ID = old;
                    WinInfoHelper.ShowInfoWindow(this, "保存失败:"+ex.Message);
                    log.Error("保存授权角色失败：", ex);
                }
            });
            waiting.Show(this);
        }
    }
}
