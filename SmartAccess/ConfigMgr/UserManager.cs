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
    public partial class UserManager : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(UserManager));
        public UserManager()
        {
            InitializeComponent();
        }

        private void UserManager_Load(object sender, EventArgs e)
        {
            DoSearch(true);
        }
        private void DoSearch(bool searchCount=false)
        {
            Maticsoft.BLL.SMT_USER_INFO userBLL = new Maticsoft.BLL.SMT_USER_INFO();
            string strWhere = "IS_DELETE=0";
            if (searchCount)
            {
                pageDataGridView.Reset();
                string filter=tbFilter.Text.Trim();
                if (filter!="")
                {
                    strWhere += " and (USER_NAME like '%" + filter + "%' or REAL_NAME like '%" + filter + "%')";
                    pageDataGridView.SqlWhere = strWhere;
                }
            }
            if (pageDataGridView.SqlWhere==null)
            {
                pageDataGridView.SqlWhere = "";
            }

            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    if (searchCount)
                    {
                        int count = userBLL.GetRecordCount(pageDataGridView.SqlWhere);
                        if (count > 0)
                        {
                            this.Invoke(new Action(() =>
                            {
                                pageDataGridView.PageControl.TotalRecords = count;
                            }));
                        }
                        else return;
                    }

                    var users = userBLL.GetModelListByPageEx(pageDataGridView.SqlWhere, "USER_NAME", pageDataGridView.PageControl.StartIndex, pageDataGridView.PageControl.EndIndex);
                    this.Invoke(new Action(() =>
                    {
                        foreach (var item in users)
                        {
                            AddToGrid(item);
                        }
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "查询用户异常！"+ex.Message);
                    log.Error("查询用户异常：", ex);
                }
                
            });
            waiting.Show(this);
        }

        private void pageDataGridView1_PageControl_PageChanged(object sender, Li.Controls.PageEventArgs args)
        {
            DoSearch(false);
        }

        private void AddToGrid(Maticsoft.Model.SMT_USER_INFO user)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (string.IsNullOrWhiteSpace(user.ROLE_NAME))
            {
                user.ROLE_NAME = "设置角色";
            }
            row.CreateCells(dgvData,
                user.USER_NAME,
                user.IS_ENABLE?"启用":"禁用",
                user.REAL_NAME,
                user.DEPT_NAME,
                user.TELEPHONE,
                user.ADDRESS,
                user.EMAIL,
                user.QQ,
                user.ROLE_NAME
                );
            row.Tag = user;
            dgvData.Rows.Add(row);
        }

        private void biSearch_Click(object sender, EventArgs e)
        {
            DoSearch(true);
        }

        private void tbFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                DoSearch(true);
            }
        }

        private void biAddUser_Click(object sender, EventArgs e)
        {
            FrmEditorUser frmUser = new FrmEditorUser();
            if (frmUser.ShowDialog(this)==DialogResult.OK)
            {
                AddToGrid(frmUser.UserInfo);
            }
        }
        private DataGridViewRow GetSelectedRow()
        {
            if (dgvData.SelectedRows.Count>0)
            {
                return dgvData.SelectedRows[0];
            }
            else
            {
               if( dgvData.SelectedCells.Count>0)
               {
                  if( dgvData.SelectedCells[0].RowIndex>=0)
                  {
                      return dgvData.Rows[dgvData.SelectedCells[0].RowIndex];
                  }
               }
            }
            return null;
        }
        private void biEditUser_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow();
            if (row==null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择待编辑用户！");
            }
            else
            {
                Maticsoft.Model.SMT_USER_INFO userInfo = (Maticsoft.Model.SMT_USER_INFO)row.Tag;
                FrmEditorUser frmUser = new FrmEditorUser(userInfo);
                if (frmUser.ShowDialog(this) == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(userInfo.ROLE_NAME))
                    {
                        userInfo.ROLE_NAME = "设置角色";
                    }
                    row.Cells[0].Value = userInfo.USER_NAME;
                    row.Cells[1].Value = userInfo.IS_ENABLE ? "启用" : "禁用";
                    row.Cells[2].Value = userInfo.REAL_NAME;
                    row.Cells[3].Value = userInfo.DEPT_NAME;
                    row.Cells[4].Value = userInfo.TELEPHONE;
                    row.Cells[5].Value = userInfo.ADDRESS;
                    row.Cells[6].Value = userInfo.EMAIL;
                    row.Cells[7].Value = userInfo.QQ;
                    row.Cells[8].Value = userInfo.ROLE_NAME;
                }
            }
        }

        private void biDeleteUser_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow();
            if (row == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择待删除用户！");
            }
            else
            {
                Maticsoft.Model.SMT_USER_INFO userInfo = (Maticsoft.Model.SMT_USER_INFO)row.Tag;
                if (userInfo.USER_NAME=="admin")
                {
                    WinInfoHelper.ShowInfoWindow(this, "admin用户禁止删除！");
                    return;
                }
                if (MessageBox.Show("确定删除用户"+userInfo.USER_NAME+"?","提示",MessageBoxButtons.OKCancel)!=DialogResult.OK)
                {
                    return;
                }
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        Maticsoft.BLL.SMT_USER_INFO userBll = new Maticsoft.BLL.SMT_USER_INFO();
                        userInfo.IS_DELETE = true;
                        if (userInfo.REAL_NAME==null)
                        {
                            userInfo.REAL_NAME = "";
                        }
                        if (userInfo.ADDRESS==null)
                        {
                            userInfo.ADDRESS = "";
                        }
                        if (userInfo.EMAIL==null)
                        {
                            userInfo.EMAIL = "";
                        }
                        if (userInfo.KEY_VAL==null)
                        {
                            userInfo.KEY_VAL = "";
                        }
                        if (userInfo.QQ==null)
                        {
                            userInfo.QQ = "";
                        }
                        if (userInfo.TELEPHONE == null)
                        {
                            userInfo.TELEPHONE = "";
                        }
                        userBll.Update(userInfo);
                        SmtLog.InfoFormat("用户", "删除用户：用户名={0}", userInfo.USER_NAME);
                        this.Invoke(new Action(() =>
                        {
                            dgvData.Rows.Remove(row);
                        }));
                    }
                    catch (System.Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "删除用户异常："+ex.Message);
                        log.Error("删除用户异常：", ex);
                    }
                });
                waiting.Show(this);
            }
        }

        private void biRoleMgr_Click(object sender, EventArgs e)
        {
            FrmRoleMgr frmMgr = new FrmRoleMgr();
            frmMgr.ShowDialog(this);
        }

    }
}
