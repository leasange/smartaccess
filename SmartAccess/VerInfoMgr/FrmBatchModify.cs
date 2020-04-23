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

namespace SmartAccess.VerInfoMgr
{
    public partial class FrmBatchModify : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmBatchModify));
        private List<Maticsoft.Model.SMT_DATADICTIONARY_INFO> staffTypes = null;
        public FrmBatchModify()
        {
            InitializeComponent();
        }

        private void FrmPrivateCopy_Load(object sender, EventArgs e)
        {
            LoadDeptsTree();
        }

        private void LoadDeptsTree()
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    var depts = DeptDataHelper.GetDepts(false);
                    Maticsoft.BLL.SMT_DATADICTIONARY_INFO dicBll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                    staffTypes =  dicBll.GetModelList("DATA_TYPE='STAFF_TYPE'");
                    this.Invoke(new Action(() =>
                    {
                        try
                        {
                            this.cbTreeDept.Nodes.Clear();
                            var nodes = DeptDataHelper.ToTree(depts);
                            DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node("未知部门");
                            nodes.Insert(0, node);
                            this.cbTreeDept.Nodes.AddRange(nodes.ToArray());
                            foreach (DevComponents.AdvTree.Node item in this.cbTreeDept.Nodes)
                            {
                                item.Expand();
                            }
                            if (staffTypes!=null&&staffTypes.Count>0)
                            {
                                foreach (var sft in staffTypes)
                                {
                                    DevComponents.Editors.ComboItem item = new DevComponents.Editors.ComboItem(sft.DATA_NAME);
                                    item.Tag = sft;
                                    cbStaffType.Items.Add(item);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "加载部门异常：" + ex.Message);
                            log.Error("加载部门异常1:", ex);
                        }
                    }));
                }
                catch (Exception exx)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载部门异常：" + exx.Message);
                    log.Error("加载部门异常2:", exx);
                }
            });
            waiting.Show(this, 300);
        }

        private void cbTreeDept_SelectionChanged(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            Maticsoft.Model.SMT_ORG_INFO orgInfo = e.Node.Tag as Maticsoft.Model.SMT_ORG_INFO;
            if (orgInfo==null)
            {
                orgInfo = new Maticsoft.Model.SMT_ORG_INFO();
                orgInfo.ID = -1;
            }
            if (orgInfo!=null)
            {
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        Maticsoft.BLL.SMT_STAFF_INFO staffBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                        string strWhere = "ORG_ID=" + orgInfo.ID;
                        if (orgInfo.ID==-1)
                        {
                            strWhere += " or ORG_ID is null";
                        }
                        var staffInfos = staffBll.GetModelList("(" + strWhere + ") and IS_DELETE=0");

                        if (orgInfo.ID != -1)
                        {
                            Maticsoft.BLL.SMT_ORG_INFO orgBll = new Maticsoft.BLL.SMT_ORG_INFO();
                            var orgS = orgBll.GetModelList("PAR_ID=" + orgInfo.ID);
                            foreach (var org in orgS)
                            {
                                var subInfos = staffBll.GetModelList("ORG_ID=" + org.ID + " and IS_DELETE=0");
                                staffInfos.AddRange(subInfos);
                            }
                        }
                      

                        this.Invoke(new Action(() =>
                        {
                            DoShowInfos(staffInfos);
                        }));
                    }
                    catch (Exception ex)
                    {
                        log.Error("获取人员异常：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "获取人员异常:" + ex.Message);
                    }
                });
                waiting.Show(this);
            }
        }
        private string GetStaffName(string staffKey)
        {
            var val = staffTypes.Find(m => m.DATA_KEY == staffKey);
            if (val!=null)
            {
                return val.DATA_NAME;
            }
            return staffKey;
        }
        private void DoShowInfos(List<Maticsoft.Model.SMT_STAFF_INFO> staffInfos)
        {
            dgvStaffs.Rows.Clear();
            foreach (var item in staffInfos)
            {
                bool find = false;
                foreach (DataGridViewRow select in dgvSelected.Rows)//判断是否已选择
                {
                    Maticsoft.Model.SMT_STAFF_INFO s = (Maticsoft.Model.SMT_STAFF_INFO)select.Tag;
                    if (s.ID == item.ID)
                    {
                        find = true;
                        break;
                    }
                }
                if (find)
                {
                    continue;
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvStaffs,
                    item.STAFF_NO,
                    item.REAL_NAME,
                    GetStaffName(item.STAFF_TYPE),
                    item.VALID_ENDTIME.ToString("yyyy-MM-dd"),
                    item.IS_FORBIDDEN?"禁用":"正常"
                    );
                row.Tag = item;
                dgvStaffs.Rows.Add(row);
            }
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> dgvrs = new List<DataGridViewRow>();
            while (dgvStaffs.Rows.Count>0)
            {
                dgvrs.Add(dgvStaffs.Rows[0]);
                dgvStaffs.Rows.RemoveAt(0);
            }
            if (dgvrs.Count==0)
            {
                return;
            }
            dgvSelected.Rows.AddRange(dgvrs.ToArray());
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvStaffs.SelectedRows.Count==0)
            {
                return;
            }
            List<DataGridViewRow> dgvrs = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvStaffs.SelectedRows)
            {
                dgvrs.Add(item);
            }
            foreach (var item in dgvrs)
            {
                dgvStaffs.Rows.Remove(item);
            }
            dgvSelected.Rows.AddRange(dgvrs.ToArray());
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            if (dgvSelected.SelectedRows.Count == 0)
            {
                return;
            }
            List<DataGridViewRow> dgvrs = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvSelected.SelectedRows)
            {
                dgvrs.Add(item);
            }
            foreach (var item in dgvrs)
            {
                dgvSelected.Rows.Remove(item);
            }
            dgvStaffs.Rows.AddRange(dgvrs.ToArray());
        }

        private void btnAllUnSelect_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> dgvrs = new List<DataGridViewRow>();
            while (dgvSelected.Rows.Count > 0)
            {
                dgvrs.Add(dgvSelected.Rows[0]);
                dgvSelected.Rows.RemoveAt(0);
            }
            if (dgvrs.Count==0)
            {
                return;
            }
            dgvStaffs.Rows.AddRange(dgvrs.ToArray());
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void btnOkUpload_Click(object sender, EventArgs e)
        {
            DoSave(true);
        }
        private void DoSave(bool isupload=false)
        {
            if (dgvSelected.Rows.Count==0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请至少选一个人员！");
                return;
            }
            if (cbIsValidValid.Checked &&
                (
                (dtValidStart.LockUpdateChecked && dtValidStart.IsEmpty) ||
                (dtValidEnd.LockUpdateChecked && dtValidEnd.IsEmpty)
                )
                )
            {
                WinInfoHelper.ShowInfoWindow(this, "请设置选择有效的开始或结束时间！");
                return;
            }
            bool isvaliddatechanged = false;
            if (cbIsValidValid.Checked &&
                (
                (dtValidStart.LockUpdateChecked&&!dtValidStart.IsEmpty)||(dtValidEnd.LockUpdateChecked&&!dtValidEnd.IsEmpty)
                )
                )
            {
                isvaliddatechanged = true;
            }
            if (isvaliddatechanged)
            {
                if (cbIsValidValid.Checked && dtValidStart.LockUpdateChecked && dtValidEnd.LockUpdateChecked && dtValidStart.Value > dtValidEnd.Value)
                {
                    WinInfoHelper.ShowInfoWindow(this, "结束时间不能小于开始时间！");
                    return;
                }
            }
            string staffType = null;
            if (chStaffType.Checked)
            {
                if (cbStaffType.SelectedItem == null)
                {
                    WinInfoHelper.ShowInfoWindow(this, "请选择人员类型！");
                    return;
                }
                staffType = ((Maticsoft.Model.SMT_DATADICTIONARY_INFO)((DevComponents.Editors.ComboItem)cbStaffType.SelectedItem).Tag).DATA_TYPE;
            }
            if (!isvaliddatechanged && !chStaffType.Checked && !cbisForbidden.Checked)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择要修改的信息！");
                return;
            }
            
            List<Maticsoft.Model.SMT_STAFF_INFO> staffInfos = new List<Maticsoft.Model.SMT_STAFF_INFO>();
            foreach (DataGridViewRow item in dgvSelected.Rows)
            {
                staffInfos.Add((Maticsoft.Model.SMT_STAFF_INFO)item.Tag);
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                Maticsoft.BLL.SMT_STAFF_INFO staffBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                try
                {
                    foreach (var item in staffInfos)
                    {
                        if (isvaliddatechanged)
                        {
                            if (dtValidStart.LockUpdateChecked&&!dtValidStart.IsEmpty)
                            {
                                item.VALID_STARTTIME = dtValidStart.Value.Date;
                            }
                            if (dtValidEnd.LockUpdateChecked && !dtValidEnd.IsEmpty)
                            {
                                item.VALID_ENDTIME = dtValidEnd.Value.Date + new TimeSpan(23, 59, 59);
                            }
                        }
                        if (chStaffType.Checked)
                        {
                            item.STAFF_TYPE = staffType;
                        }
                        if (cbisForbidden.Checked)
                        {
                            item.IS_FORBIDDEN = !cbNormal.Checked;
                        }
                        staffBll.Update(item);
                    }
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "保存异常：" + ex.Message);
                    log.Error("保存异常：", ex);
                    return;
                }
                if (isupload)
                {
                    string errMsg = "";
                    bool ret = UploadPrivate.Upload(staffInfos, out  errMsg);
                    if (!ret || !string.IsNullOrWhiteSpace(errMsg))
                    {
                        WinInfoHelper.ShowInfoWindow(this, "保存成功，部分权限上传异常：" + errMsg);
                    }
                }
                this.Invoke(new Action(() =>
                    {
                        this.Close();
                    }));
            });
            waiting.Show(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbIsValidValid_CheckedChanged(object sender, EventArgs e)
        {
            plValidate.Enabled = cbIsValidValid.Checked;
        }

        private void cbisForbidden_CheckedChanged(object sender, EventArgs e)
        {
            plForbidden.Enabled = cbisForbidden.Checked;
        }

        private void chStaffType_CheckedChanged(object sender, EventArgs e)
        {
            cbStaffType.Enabled = chStaffType.Checked;
        }
    }
}
