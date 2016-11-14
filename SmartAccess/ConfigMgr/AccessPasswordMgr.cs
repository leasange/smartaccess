using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;
using SmartAccess.Common;

namespace SmartAccess.ConfigMgr
{
    public partial class AccessPasswordMgr : UserControl
    {
        private log4net.ILog log=log4net.LogManager.GetLogger(typeof(AccessPasswordMgr));
        public AccessPasswordMgr()
        {
            InitializeComponent();
        }


        #region 超级通行密码
        private bool _isCodeSetPwd = false;
        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (_isCodeSetPwd)
            {
                return;
            }
            if (tbPassword.Text.Length>0)
            {
                string str = "";
                foreach (var item in tbPassword.Text)
                {
                    if (item>='0'&&item<='9')//数字输入
                    {
                        str += item;
                    }
                }
               
                if (tbPassword.Text.Length!=str.Length)
                {
                    int c = tbPassword.SelectionStart;
                    _isCodeSetPwd = true;
                    tbPassword.Text = str;
                    tbPassword.SelectionStart = c - 1;
                    _isCodeSetPwd = false;
                }
            }
        }
        #endregion

        private void cbVisiblePwd_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = cbVisiblePwd.Checked ? '\0' : '*';
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string pwd = this.tbPassword.Text.Trim();
            if (pwd=="")
            {
                WinInfoHelper.ShowInfoWindow(this, "密码为空！");
                return;
            }
            var doors = doorTree.Tree.GetNodeList(true, typeof(Maticsoft.Model.SMT_DOOR_INFO));
            if (doors.Count==0)
            {
                WinInfoHelper.ShowInfoWindow(this, "未选择任何门禁！");
                return;
            }
            List<decimal> doorIds = new List<decimal>();
            foreach (var item in doors)
            {
                doorIds.Add(((Maticsoft.Model.SMT_DOOR_INFO)item.Tag).ID);
            }
            CtrlWaiting ctrlWaiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_SUPER_PWD pwdBll = new Maticsoft.BLL.SMT_SUPER_PWD();
                    List<Maticsoft.Model.SMT_SUPER_PWD> models = pwdBll.GetModelList("SUPER_PWD='" + pwd + "'");
                    List<Maticsoft.Model.SMT_SUPER_PWD> addmodels = new List<Maticsoft.Model.SMT_SUPER_PWD>();
                    foreach (var item in doorIds)
                    {
                        if (!models.Exists(m => m.DOOR_ID == item))
                        {
                            Maticsoft.Model.SMT_SUPER_PWD model = new Maticsoft.Model.SMT_SUPER_PWD()
                            {
                                DOOR_ID = item,
                                SUPER_PWD = pwd
                            };
                            model.ID = pwdBll.Add(model);
                            addmodels.Add(model);
                            SmtLog.InfoFormat("配置", "添加超级通行密码：门禁Id={0}", item);
                        }
                    }

                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "添加超级通行密码异常！" + ex.Message);
                    log.Error("添加超级通行密码异常：",ex);
                }

            });
            ctrlWaiting.Show(this);

        }

        private void superTabControl_TabIndexChanged(object sender, EventArgs e)
        {
            if (superTabControl.SelectedTab == stiSuperPwd && stiSuperPwd.Tag==null)
	        {
                stiSuperPwd.Tag = "True";
                RefreshDatas();
	        }
        }
        //刷新数据
        private void RefreshDatas()
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                Maticsoft.BLL.SMT_SUPER_PWD pwdBll = new Maticsoft.BLL.SMT_SUPER_PWD();
                var models = pwdBll.GetModelList("1=1");
                var g = models.GroupBy(m => m.SUPER_PWD);
                foreach (var item in g)
                {
                    var pms = item.ToList();
                    
                }
            });
            waiting.Show(this);
        }
    }
}
