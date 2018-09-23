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
    public partial class FrmPrivateCopy : DevComponents.DotNetBar.Office2007Form
    {
        private Maticsoft.Model.SMT_STAFF_INFO _staffInfo = null;
        private List<Maticsoft.Model.SMT_STAFF_DOOR> _staffDoors = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmPrivateCopy));
        public FrmPrivateCopy(Maticsoft.Model.SMT_STAFF_INFO staffInfo,List<Maticsoft.Model.SMT_STAFF_DOOR> doors)
        {
            InitializeComponent();
            _staffInfo = staffInfo;
            _staffDoors = doors;
            this.Text = "当前被复制权限人员：" + _staffInfo.REAL_NAME;
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
                        string strWhere = "";
                        List<Maticsoft.Model.SMT_STAFF_INFO> staffInfos = null;
                        if (orgInfo.ID == -1)
                        {
                            strWhere += "ORG_ID=-1 or ORG_ID is null";
                            staffInfos = staffBll.GetModelList("(" + strWhere + ") and IS_DELETE=0");
                        }
                        else
                        {
                            // Maticsoft.BLL.SMT_ORG_INFO orgBll = new Maticsoft.BLL.SMT_ORG_INFO();
                            // var orgS = orgBll.GetModelList("PAR_ID=" + orgInfo.ID);
                            // foreach (var org in orgS)
                            // {
                            //var subInfos = staffBll.GetModelList("ORG_ID=" + org.ID + " and IS_DELETE=0");
                            staffInfos = staffBll.GetModelListByParOrgId(orgInfo.ID);
                            //  }
                        }
                        var depts = DeptDataHelper.GetDepts(false);
                        foreach (var item in staffInfos)
                        {
                            var dept = depts.Find(m => m.ID == item.ORG_ID);
                            if (dept != null)
                            {
                                item.ORG_NAME = dept.ORG_NAME;
                                item.ORG_CODE = dept.ORG_CODE;
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
                    item.ORG_NAME+"["+item.ORG_CODE+"]"
                    );
                row.Tag = item;
                dgvStaffs.Rows.Add(row);
            }
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> dgvrs = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvStaffs.Rows)
            {
                dgvrs.Add(item);
            }
            dgvStaffs.Rows.Clear();
            if (dgvrs.Count == 0)
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
            foreach (DataGridViewRow row in dgvSelected.Rows)
            {
                dgvrs.Add(row);
            }
            dgvSelected.Rows.Clear();
            if (dgvrs.Count == 0)
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
                WinInfoHelper.ShowInfoWindow(this, "请至少选一个待复制的人员！");
                return;
            }
            List<Maticsoft.Model.SMT_STAFF_INFO> staffInfos = new List<Maticsoft.Model.SMT_STAFF_INFO>();
            foreach (DataGridViewRow item in dgvSelected.Rows)
            {
                staffInfos.Add((Maticsoft.Model.SMT_STAFF_INFO)item.Tag);
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                Maticsoft.BLL.SMT_STAFF_DOOR sdbll = new Maticsoft.BLL.SMT_STAFF_DOOR();
                try
                {
                    foreach (var item in staffInfos)
                    {
                        var olddoors = sdbll.GetModelList("STAFF_ID=" + item.ID);
                        var notexist = olddoors.FindAll(m =>
                        {
                            return !_staffDoors.Exists(n => n.DOOR_ID == m.DOOR_ID);
                        });
                        foreach (var old in notexist)
                        {
                            sdbll.Delete(old.STAFF_ID, old.DOOR_ID);
                            olddoors.Remove(old);
                        }
                        notexist = _staffDoors.FindAll(m =>
                        {
                            return !olddoors.Exists(n => n.DOOR_ID == m.DOOR_ID);
                        });
                        foreach (var newdoor in notexist)
                        {
                            sdbll.Add(new Maticsoft.Model.SMT_STAFF_DOOR()
                            {
                                ADD_TIME = DateTime.Now,
                                IS_UPLOAD = false,
                                STAFF_ID = item.ID,
                                UPLOAD_TIME = DateTime.Now,
                                DOOR_ID = newdoor.DOOR_ID,
                                TIME_NUM = newdoor.TIME_NUM
                            });
                        }
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
    }
}
