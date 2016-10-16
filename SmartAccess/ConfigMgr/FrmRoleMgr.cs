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
    public partial class FrmRoleMgr : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmRoleMgr));
        public FrmRoleMgr()
        {
            InitializeComponent();
        }

        private void FrmRoleMgr_Load(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_ROLE_INFO roleBll = new Maticsoft.BLL.SMT_ROLE_INFO();
                    var models= roleBll.GetModelList("");
                    this.Invoke(new Action(() =>
                    {
                        foreach (var item in models)
                        {
                            AddModel(item);
                        }
                    }));
                }
                catch (Exception ex) 
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载角色异常：" + ex.Message);
                    log.Error("加载角色异常：", ex);
                }
            });
            waiting.Show(this,300);
        }

        private void AddModel(Maticsoft.Model.SMT_ROLE_INFO role)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvData,
                role.ROLE_NAME,
                role.ROLE_DESC,
                "设置/修改权限",
                "删除"
                );
            row.Tag=role;
            dgvData.Rows.Add(row);
        }
        private DataGridViewRow _selectRow = null;
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];

                _selectRow = row;
                Maticsoft.Model.SMT_ROLE_INFO role = (Maticsoft.Model.SMT_ROLE_INFO)row.Tag;

                tbRoleName.Text = role.ROLE_NAME;
                tbRoleDesc.Text = role.ROLE_DESC;

                if (e.ColumnIndex>=0)
                {
                    if (dgvData.Columns[e.ColumnIndex].Name=="ColPrivate")
                    {
                        DoSetPrivate();
                    }
                    else if (dgvData.Columns[e.ColumnIndex].Name=="ColDelete")
                    {
                        if (MessageBox.Show("确定删除该角色？","提示",MessageBoxButtons.OKCancel)==DialogResult.OK)
                        {
                            CtrlWaiting waiting = new CtrlWaiting(() =>
                            {
                                try
                                {
                                    Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_ROLE_FUN where ROLE_ID=" + role.ID);
                                    Maticsoft.BLL.SMT_ROLE_INFO roleInfo = new Maticsoft.BLL.SMT_ROLE_INFO();
                                    roleInfo.Delete(role.ID);
                                    SmtLog.InfoFormat("用户", "删除角色：ID={0},名称={1}", role.ID,role.ROLE_NAME);
                                    this.Invoke(new Action(() =>
                                    {
                                        dgvData.Rows.Remove(row);
                                        _selectRow = null;
                                        tbRoleName.Text = "";
                                        tbRoleDesc.Text = "";
                                    }));
                                }
                                catch (Exception ex)
                                {
                                    log.Error("删除角色异常：", ex);
                                    WinInfoHelper.ShowInfoWindow(this,"删除角色异常：" + ex.Message);
                                }
                            });
                            waiting.Show(this);
                        }
                    }
                }
            }
            
        }

        private void btnSetPrivate_Click(object sender, EventArgs e)
        {
            DoSetPrivate();
        }
        private void DoSetPrivate()
        {
            if (_selectRow != null)
            {
                Maticsoft.Model.SMT_ROLE_INFO role = (Maticsoft.Model.SMT_ROLE_INFO)_selectRow.Tag;
                FrmRoleFunSelector frmSelector = new FrmRoleFunSelector(role);
                if(frmSelector.ShowDialog(this)==DialogResult.OK)
                {

                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbRoleName.Text.Trim()=="")
            {
                WinInfoHelper.ShowInfoWindow(this, "角色名称不能为空！");
                return;
            }
            Maticsoft.Model.SMT_ROLE_INFO role = new Maticsoft.Model.SMT_ROLE_INFO();
            role.ROLE_NAME = tbRoleName.Text.Trim();
            role.ROLE_DESC = tbRoleName.Text.Trim();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_ROLE_INFO roleBll = new Maticsoft.BLL.SMT_ROLE_INFO();
                    role.ID = roleBll.Add(role);
                    SmtLog.InfoFormat("用户", "添加角色：ID={0}，名称={1}", role.ID, role.ROLE_NAME);
                    this.Invoke(new Action(() =>
                    {
                        AddModel(role);
                    }));
                }
                catch (Exception ex)
                {
                    log.Error("添加角色异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "添加角色异常：" + ex.Message);
                }
            });
            waiting.Show(this);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbRoleName.Text.Trim() == "")
            {
                WinInfoHelper.ShowInfoWindow(this, "角色名称不能为空！");
                return;
            }
            if (_selectRow != null && dgvData.Rows.Contains(_selectRow))
            {
                Maticsoft.Model.SMT_ROLE_INFO role = (Maticsoft.Model.SMT_ROLE_INFO)_selectRow.Tag;
                role.ROLE_NAME = tbRoleName.Text.Trim();
                role.ROLE_DESC = tbRoleDesc.Text.Trim();
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        Maticsoft.BLL.SMT_ROLE_INFO roleBll = new Maticsoft.BLL.SMT_ROLE_INFO();
                        roleBll.Update(role);
                        SmtLog.InfoFormat("用户", "更新角色：ID={0}，名称={1}", role.ID, role.ROLE_NAME);
                        this.Invoke(new Action(() =>
                        {
                            _selectRow.Cells[0].Value = role.ROLE_NAME;
                            _selectRow.Cells[1].Value = role.ROLE_DESC;
                        }));
                    }
                    catch (Exception ex)
                    {
                        log.Error("更新角色异常：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "更新角色异常：" + ex.Message);
                    }
                });
                waiting.Show(this);
            }
        }
    }
}
