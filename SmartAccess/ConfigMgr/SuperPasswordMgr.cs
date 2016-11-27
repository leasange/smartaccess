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
using SmartKey;
using SmartAccess.Common.Datas;

namespace SmartAccess.ConfigMgr
{
    public partial class SuperPasswordMgr : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(AccessPasswordMgr));
        public SuperPasswordMgr()
        {
            InitializeComponent();
        }
        //刷新数据
        public void RefreshDatas()
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                Maticsoft.BLL.SMT_SUPER_PWD pwdBll = new Maticsoft.BLL.SMT_SUPER_PWD();
                var models = pwdBll.GetModelListEx("1=1");
                this.Invoke(new Action(() =>
                {
                	ShowDatas(models);
                }));
            });
            waiting.Show(this);
        }
        private void ShowDatas(List< Maticsoft.Model.SMT_SUPER_PWD> models)
        {
            try
            {
                dgvData.Rows.Clear();
                var g = models.GroupBy(m => m.SUPER_PWD);
                foreach (var item in g)
                {
                    var pms = item.ToList();
                    string str = "";
                    foreach (var pm in pms)
                    {
                        if ( pm.DOOR_INFO!=null)
                        {
                            str += pm.DOOR_INFO.DOOR_NAME + ";"; 
                        }
                        else
                        {
                            str += pm.DOOR_ID + ";";
                        }
                    }
                    DataGridViewRow row = new DataGridViewRow();
                    string pwd = pms[0].SUPER_PWD;
                    if (!cbVisiblePwd.Checked)
                    {
                        pwd = "******";
                    }
                    row.CreateCells(dgvData,
                        pwd,
                        str,
                        "删除"
                        );
                    row.Tag = pms;
                    dgvData.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "显示数据异常：" + ex.Message);
                log.Error("显示数据异常：", ex);
            }

        }

        #region 超级通行密码
        private bool _isCodeSetPwd = false;
        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (_isCodeSetPwd)
            {
                return;
            }
            if (tbPassword.Text.Length > 0)
            {
                string str = "";
                foreach (var item in tbPassword.Text)
                {
                    if (item >= '0' && item <= '9')//数字输入
                    {
                        str += item;
                    }
                }

                if (tbPassword.Text.Length != str.Length)
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
            foreach (DataGridViewRow item in dgvData.Rows)
            {
                List<Maticsoft.Model.SMT_SUPER_PWD> list = (List<Maticsoft.Model.SMT_SUPER_PWD>)item.Tag;
                string pwd = list[0].SUPER_PWD;
                if (!cbVisiblePwd.Checked)
                {
                    pwd = "******";
                }
                item.Cells[0].Value = pwd;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string pwd = this.tbPassword.Text.Trim();
            if (pwd == "")
            {
                WinInfoHelper.ShowInfoWindow(this, "密码为空！");
                return;
            }
            var doors = doorTree.Tree.GetNodeList(true, typeof(Maticsoft.Model.SMT_DOOR_INFO));
            if (doors.Count == 0)
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
                    if (addmodels.Count>0)
                    {
                         RefreshDatas();
                    }
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "添加超级通行密码异常！" + ex.Message);
                    log.Error("添加超级通行密码异常：", ex);
                }

            });
            ctrlWaiting.Show(this);

        }

        private void SuperPasswordMgr_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                RefreshDatas();
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex>=0&&e.RowIndex>=0)
            {
                if (dgvData.Columns[e.ColumnIndex].Name == "Col_Del")
                {
                    DeleteRows(new List<DataGridViewRow>() { dgvData.Rows[e.RowIndex]});
                }
            }
        }
        private void DeleteRows(List<DataGridViewRow> rows)
        {
            if (rows.Count==0)
            {
                return;
            }
            if (MessageBox.Show("确定删除超级密码？","提示",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                List<Maticsoft.Model.SMT_SUPER_PWD> pwds = new List<Maticsoft.Model.SMT_SUPER_PWD>();
                foreach (var item in rows)
                {
                    List<Maticsoft.Model.SMT_SUPER_PWD> models=(List<Maticsoft.Model.SMT_SUPER_PWD>)item.Tag;
                    pwds.AddRange(models);
                }
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        Maticsoft.BLL.SMT_SUPER_PWD pwdbll = new Maticsoft.BLL.SMT_SUPER_PWD();
                        foreach (var item in pwds)
                        {
                            pwdbll.Delete(item.ID);
                        }

                        Maticsoft.BLL.SMT_SUPER_PWD pwdBll = new Maticsoft.BLL.SMT_SUPER_PWD();
                        var models= pwdbll.GetModelList("");
                        try
                        {
                            UploadPrivate.UploadPwds(models);
                        }
                        catch (Exception ex)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "上传密码发生异常：" + ex.Message);
                            log.Error("上传密码发生异常：", ex);
                        }
                       

                        this.Invoke(new Action(() =>
                        {
                            foreach (var item in rows)
                            {
                                dgvData.Rows.Remove(item);
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "删除超级密码异常：" + ex.Message);
                        log.Error("删除超级密码异常：", ex);
                    }
                   
                });
                waiting.Show(this);
            }
        }

        private void biDeleteSelect_Click(object sender, EventArgs e)
        {
            var rows = GetSelectRows();
            if (rows.Count==0)
            {
                WinInfoHelper.ShowInfoWindow(this, "未选择任何行！");
                return;
            }
            DeleteRows(rows);
        }

        private void biRefresh_Click(object sender, EventArgs e)
        {
            RefreshDatas();
        }

        private List<DataGridViewRow> GetSelectRows()
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            if (dgvData.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow item in dgvData.SelectedRows)
                {
                    rows.Add(item);
                }
            }
            else if (dgvData.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell item in dgvData.SelectedCells)
                {
                    if (item.RowIndex >= 0)
                    {
                        if (rows.Contains(dgvData.Rows[item.RowIndex]))
                        {
                            continue;
                        }
                        rows.Add(dgvData.Rows[item.RowIndex]);
                    }
                }
            }
            return rows;
        }

        private List<Maticsoft.Model.SMT_SUPER_PWD> GetSelectPwds()
        {
            List<Maticsoft.Model.SMT_SUPER_PWD> pwds = new List<Maticsoft.Model.SMT_SUPER_PWD>();
            List<DataGridViewRow> rows = GetSelectRows();
            if (rows.Count>0)
            {
                foreach (var item in rows)
                {
                    pwds.AddRange((List<Maticsoft.Model.SMT_SUPER_PWD>)item.Tag);
                }
            }
            return pwds;
        }
        private List<Maticsoft.Model.SMT_SUPER_PWD> GetAllPwds()
        {
            List<Maticsoft.Model.SMT_SUPER_PWD> pwds = new List<Maticsoft.Model.SMT_SUPER_PWD>();
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvData.Rows)
            {
                rows.Add(item);
            }
            
            if (rows.Count > 0)
            {
                foreach (var item in rows)
                {
                    pwds.AddRange((List<Maticsoft.Model.SMT_SUPER_PWD>)item.Tag);
                }
            }
            return pwds;
        }

        private void DoUpload(List<Maticsoft.Model.SMT_SUPER_PWD> pwds)
        {
            if (pwds.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "未选择任何可上传密码！");
                return;
            }

            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    UploadPrivate.UploadPwds(pwds);
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "上传密码发生异常：" + ex.Message);
                    log.Error("上传密码发生异常1：", ex);
                }

            });
            waiting.Show(this);
        }
        private void biUpload_Click(object sender, EventArgs e)
        {
            List<Maticsoft.Model.SMT_SUPER_PWD> pwds = GetSelectPwds();
            DoUpload(pwds);
        }
       
        private void biUploadAll_Click(object sender, EventArgs e)
        {
            List<Maticsoft.Model.SMT_SUPER_PWD> pwds = GetAllPwds();
            DoUpload(pwds);
        }
    }
}
