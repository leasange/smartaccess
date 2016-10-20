using DevComponents.Editors;
using SmartAccess.Common;
using SmartAccess.Common.Datas;
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
    public partial class FrmEditorUser : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmEditorUser));
        private Maticsoft.Model.SMT_USER_INFO _userInfo = null;
        public Maticsoft.Model.SMT_USER_INFO UserInfo
        {
            get { return _userInfo; }
        }
        public FrmEditorUser( Maticsoft.Model.SMT_USER_INFO  userInfo=null)
        {
            InitializeComponent();
            _userInfo = userInfo;
        }

        private void FrmEditorUser_Load(object sender, EventArgs e)
        {
            Init();
        }
        private void Init()
        {
            if (_userInfo != null)
            {
                this.Text = "编辑用户";
                if (_userInfo.USER_NAME=="admin")
                {
                    tbUserName.ReadOnly = true;
                    cboRole.Enabled = false;
                }
                tbUserName.Text = _userInfo.USER_NAME;
                tbPwd.Text = _userInfo.PASS_WORD;
                tbRealName.Text = _userInfo.REAL_NAME;
                cbEnable.Checked = _userInfo.IS_ENABLE;
                tbTel.Text = _userInfo.TELEPHONE;
                tbAddress.Text = _userInfo.ADDRESS;
                tbEmail.Text = _userInfo.EMAIL;
                tbQQ.Text = _userInfo.QQ;
            }
            else
            {
                this.Text = "新建用户";
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    var depts = DeptDataHelper.GetDepts(true);
                    this.Invoke(new Action(() =>
                    {
                    	var nodes = DeptDataHelper.ToTree(depts);
                        cbtDept.Nodes.AddRange(nodes.ToArray());
                        foreach (DevComponents.AdvTree.Node item in cbtDept.Nodes)
                        {
                            item.ExpandAll();
                        }
                        if (_userInfo!=null&&_userInfo.ORG_ID != null)
                        {
                            decimal id = (decimal)_userInfo.ORG_ID;
                            if (id >= 0)
                            {
                                var node = FindNode(id);

                                if (node != null)
                                {
                                    cbtDept.SelectedNode = node;
                                }
                            }
                        }
                        
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载部门异常！" + ex.Message);
                    log.Error("加载部门异常：", ex);
                }

            });
            waiting.Show(this,300);

            CtrlWaiting waiting1 = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_ROLE_INFO roleBll = new Maticsoft.BLL.SMT_ROLE_INFO();
                    var models = roleBll.GetModelList("");
                    this.Invoke(new Action(() =>
                    {
                        foreach (var item in models)
                        {
                            ComboItem cbi = new ComboItem(item.ROLE_NAME);
                            cbi.Tag = item;
                            cboRole.Items.Add(cbi);
                            if (_userInfo != null && _userInfo.ROLE_ID != null && _userInfo.ROLE_ID == item.ID)
                            {
                                cboRole.SelectedItem = cbi;
                            }
                        }
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载角色异常！" + ex.Message);
                    log.Error("加载角色异常：", ex);
                }
                
            });
            waiting1.Show(this, 300);
        }
        public DevComponents.AdvTree.Node FindNode(decimal id)
        {
            return DoFindNode(cbtDept.Nodes, id);
        }
        private DevComponents.AdvTree.Node DoFindNode(DevComponents.AdvTree.NodeCollection nodes, decimal id)
        {
            foreach (DevComponents.AdvTree.Node item in nodes)
            {
                var dept = (Maticsoft.Model.SMT_ORG_INFO)item.Tag;
                if (dept.ID == id)
                {
                    return item;
                }
                else
                {
                    var nn = DoFindNode(item.Nodes, id);
                    if (nn != null)
                    {
                        return nn;
                    }
                }
            }
            return null;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text.Trim()=="")
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (_userInfo==null)
            {
                _userInfo = new Maticsoft.Model.SMT_USER_INFO();
                _userInfo.ID = -1;
            }
            string oldUser = _userInfo.USER_NAME;
            _userInfo.USER_NAME = tbUserName.Text.Trim();
            _userInfo.PASS_WORD = tbPwd.Text;
            if (_userInfo.PASS_WORD=="123456")
	        {
                _userInfo.PASS_WORD = "e10adc3949ba59abbe56e057f20f883e";
	        }
            _userInfo.REAL_NAME = tbRealName.Text.Trim();
            _userInfo.IS_ENABLE = cbEnable.Checked;
            _userInfo.TELEPHONE = tbTel.Text.Trim();
            _userInfo.ADDRESS = tbAddress.Text.Trim();
            _userInfo.EMAIL = tbEmail.Text.Trim();
            _userInfo.QQ = tbQQ.Text.Trim();
            _userInfo.KEY_VAL = "";
            _userInfo.IS_DELETE = false;
            if (cboRole.SelectedItem!=null)
            {
                ComboItem cboItem = (ComboItem)cboRole.SelectedItem;
                Maticsoft.Model.SMT_ROLE_INFO roleInfo = (Maticsoft.Model.SMT_ROLE_INFO)cboItem.Tag;
                _userInfo.ROLE_ID = roleInfo.ID;
                _userInfo.ROLE_NAME = roleInfo.ROLE_NAME;
            }
            else
            {
                _userInfo.ROLE_ID = -1;
            }
            if (cbtDept.SelectedNode!=null)
            {
                Maticsoft.Model.SMT_ORG_INFO orgInfo = (Maticsoft.Model.SMT_ORG_INFO)cbtDept.SelectedNode.Tag;
                _userInfo.ORG_ID = orgInfo.ID;
                _userInfo.DEPT_NAME = orgInfo.ORG_NAME;
            }
            else
            {
                _userInfo.ORG_ID = -1;
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_USER_INFO userBll = new Maticsoft.BLL.SMT_USER_INFO();
                    if (_userInfo.ID==-1)
                    {
                        userBll.Add(_userInfo);
                        SmtLog.InfoFormat("用户","添加用户：用户名={0}，状态={1}", _userInfo.USER_NAME, _userInfo.IS_ENABLE);
                    }
                    else
                    {
                        userBll.Update(_userInfo);
                        SmtLog.InfoFormat("用户","更新用户：用户名={0}，状态={1},原始用户名={2}", _userInfo.USER_NAME,_userInfo.IS_ENABLE,oldUser);
                    }
                    this.BeginInvoke(new Action(() =>
                     {
                         this.DialogResult = DialogResult.OK;
                         this.Close();
                     }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "保存用户异常：" + ex.Message);
                    log.Error("保存用户异常：", ex);
                }
            });
            waiting.Show(this);
        }

        private void btnResetPwd_Click(object sender, EventArgs e)
        {
            if (_userInfo!=null)
            {
                tbPwd.Text = "123456";
            }
        }

    }
}
