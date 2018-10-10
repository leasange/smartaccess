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
    public partial class FrmAddFaceDevPrivate : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmAddFaceDevPrivate));
        private List<Maticsoft.Model.SMT_FACERECG_DEVICE> _selectDevices = null;
        private List<decimal> _selectDeviceIds = null;
        private List<decimal> _inprivateStaffIds = new List<decimal>();
        private List<Maticsoft.Model.SMT_STAFF_INFO> _inprivateStaffInfos = new List<Maticsoft.Model.SMT_STAFF_INFO>();
        private DateTime? _selectMaxDate = null;
        public FrmAddFaceDevPrivate(List<Maticsoft.Model.SMT_FACERECG_DEVICE> devices)
        {
            InitializeComponent();
            lbSelectDevices.Text = "";
            _selectDeviceIds = new List<decimal>();
            foreach (var item in devices)
            {
                lbSelectDevices.Text += item.FACEDEV_NAME + "；";
                _selectDeviceIds.Add(item.ID);
            }
            _selectDevices = devices;
            dtpStart.Value = DateTime.Now.Date;
            dtpEnd.Value = dtpStart.Value.AddYears(10);
        }

        private void DoLoadReadPrivates()
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_STAFF_FACEDEV sfBll = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
                    List<Maticsoft.Model.SMT_STAFF_FACEDEV> list = sfBll.GetModelList("FACEDEV_ID in (" + string.Join(",", _selectDeviceIds) + ")");
                    var g = list.GroupBy(m => m.STAFF_ID);
                    foreach (var item in g)
                    {
                        if (item.Count() == _selectDeviceIds.Count)
                        {
                            _inprivateStaffIds.Add(item.Key);
                        }
                    }
                    if (_inprivateStaffIds.Count > 0)
                    {
                        Maticsoft.BLL.SMT_STAFF_INFO staffBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                        _inprivateStaffInfos = staffBll.GetSimpleModelList("ID in (" + string.Join(",", _inprivateStaffIds.ToArray()) + ")");
                        if (_inprivateStaffInfos.Count>0)
                        {
                            var depts = DeptDataHelper.GetDepts(false);
                            foreach (var item in _inprivateStaffInfos)
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
                                foreach (var item in _inprivateStaffInfos)
                                {
                                    DataGridViewRow row = new DataGridViewRow();
                                    row.CreateCells(dgvStaffs,
                                        item.STAFF_NO,
                                        item.REAL_NAME,
                                        item.ORG_NAME + "[" + item.ORG_CODE + "]",
                                        item.VALID_ENDTIME.ToString("yyyy-MM-dd")
                                        );
                                    row.Tag = item;
                                    dgvSelected.Rows.Add(row);
                                    if (_selectMaxDate == null)
                                    {
                                        _selectMaxDate = item.VALID_ENDTIME;
                                    }
                                    else
                                    {
                                        if (item.VALID_ENDTIME > _selectMaxDate)
                                        {
                                            _selectMaxDate = item.VALID_ENDTIME;
                                        }
                                    }
                                   
                                }
                                if (_selectMaxDate != null)
                                {
                                    dtpEnd.Value = (DateTime)_selectMaxDate;
                                }
                            	
                            }));
                        }
                        
                    }

                }
                catch (Exception ex)
                {
                    log.Error("加载已授权人员异常:" + ex.Message, ex);
                    WinInfoHelper.ShowInfoWindow(this, "加载已授权人员异常:"+ex.Message);
                }

            });
            waiting.Show(this);
        }

        private void cbTreeDept_SelectionChanged(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            Maticsoft.Model.SMT_ORG_INFO orgInfo = e.Node.Tag as Maticsoft.Model.SMT_ORG_INFO;
            if (orgInfo == null)
            {
                orgInfo = new Maticsoft.Model.SMT_ORG_INFO();
                orgInfo.ID = -1;
            }
            if (orgInfo != null)
            {
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        Maticsoft.BLL.SMT_STAFF_INFO staffBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                        string strWhere ="";
                        List<Maticsoft.Model.SMT_STAFF_INFO> staffInfos = null;
                        if (orgInfo.ID == -1)
                        {
                            strWhere += "ORG_ID=-1 or ORG_ID is null";
                            staffInfos = staffBll.GetSimpleModelList("(" + strWhere + ") and IS_DELETE=0");
                        }
                        else
                        {
                            staffInfos = staffBll.GetModelListByParOrgId(orgInfo.ID);
                        }
                        /*staffInfos.RemoveAll(m =>
                        {
                            return _inprivateStaffIds.Contains(m.ID);
                        });*/
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
                    item.ORG_NAME+"["+item.ORG_CODE+"]",
                    item.VALID_ENDTIME.ToString("yyyy-MM-dd")
                    );
                row.Tag = item;
                dgvStaffs.Rows.Add(row);
            }
        }

        private void FrmAddFaceDevPrivate_Load(object sender, EventArgs e)
        {
            LoadDeptsTree();
            DoLoadReadPrivates();
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

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> dgvrs = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvStaffs.Rows)
            {
                Maticsoft.Model.SMT_STAFF_INFO info = (Maticsoft.Model.SMT_STAFF_INFO)item.Tag;
                if (_selectMaxDate == null)
                {
                    _selectMaxDate = info.VALID_ENDTIME;
                }
                else
                {
                    if (_selectMaxDate < info.VALID_ENDTIME)
                    {
                        _selectMaxDate = info.VALID_ENDTIME;
                    }
                }
                dgvrs.Add(item);
            }
            if (_selectMaxDate != null)
            {
                dtpEnd.Value = (DateTime)_selectMaxDate;
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
            if (dgvStaffs.SelectedRows.Count == 0)
            {
                return;
            }
            List<DataGridViewRow> dgvrs = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvStaffs.SelectedRows)
            {
                Maticsoft.Model.SMT_STAFF_INFO info = (Maticsoft.Model.SMT_STAFF_INFO)item.Tag;
                if (_selectMaxDate==null)
                {
                    _selectMaxDate = info.VALID_ENDTIME;
                }
                else
                {
                    if (_selectMaxDate<info.VALID_ENDTIME)
                    {
                        _selectMaxDate = info.VALID_ENDTIME;
                    }
                }
                dgvrs.Add(item);
            }
            if (_selectMaxDate!=null)
            {
                dtpEnd.Value = (DateTime)_selectMaxDate;
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

        private void DoSave(bool isupload = false,bool isAllUpload=false)
        {
            if (dgvSelected.Rows.Count == 0)
            {
                if (_inprivateStaffInfos.Count==0)
                {
                    WinInfoHelper.ShowInfoWindow(this, "请至少选一个授权的人员！");
                    return;
                }
            }
            var hasPrivates = _inprivateStaffInfos.ToList();
            List<Maticsoft.Model.SMT_STAFF_INFO> staffInfos = new List<Maticsoft.Model.SMT_STAFF_INFO>();
            foreach (DataGridViewRow item in dgvSelected.Rows)
            {
                staffInfos.Add((Maticsoft.Model.SMT_STAFF_INFO)item.Tag);
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                Maticsoft.BLL.SMT_STAFF_FACEDEV sfbll = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
                List<Maticsoft.Model.SMT_STAFF_FACEDEV> addmodels = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
                List<Maticsoft.Model.SMT_STAFF_FACEDEV> updatemodels = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
                List<Maticsoft.Model.SMT_STAFF_FACEDEV> deletemodels = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
                try
                {
                    foreach (var staff in staffInfos)
                    {
                        foreach (var dev in _selectDevices)
                        {
                           var model = sfbll.GetModel(staff.ID, dev.ID);
                           if (model==null)
                           {
                               model = new Maticsoft.Model.SMT_STAFF_FACEDEV();
                               model.ADD_TIME = DateTime.Now;
                               model.END_VALID_TIME = dtpEnd.Value.Date.AddDays(1);
                               model.FACEDEV_ID = dev.ID;
                               model.IS_UPLOAD = false;
                               model.STAFF_DEV_ID = Guid.NewGuid().ToString("N");
                               model.STAFF_ID = staff.ID;
                               model.START_VALID_TIME = dtpStart.Value.Date;
                               model.UPLOAD_TIME = DateTime.Now;
                               sfbll.Add(model);
                           }
                           else
                           {
                               hasPrivates.RemoveAll(m => m.ID == model.STAFF_ID);
                               
                               model.START_VALID_TIME = dtpStart.Value.Date;
                               model.END_VALID_TIME = dtpEnd.Value.Date.AddDays(1);
                               if (string.IsNullOrWhiteSpace(model.STAFF_DEV_ID))
                               {
                                   model.STAFF_DEV_ID = Guid.NewGuid().ToString("N");
                               }
                               sfbll.Update(model);
                           }
                           model.STAFF_INFO = staff;
                           model.FACERECG_DEVICE = dev;
                           if (model.IS_UPLOAD && isAllUpload)
                           {
                               updatemodels.Add(model);
                           }
                           else
                           {
                               addmodels.Add(model);
                           }
                        }
                    }
                    foreach (var item in hasPrivates)
                    {
                        foreach (var dev in _selectDevices)
                        {
                            var model = sfbll.GetModel(item.ID, dev.ID);
                            if (model!=null)
                            {
                                deletemodels.Add(model);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "保存异常：" + ex.Message);
                    log.Error("保存异常：", ex);
                    return;
                }
                if (deletemodels.Count>0)
                { 
                    string errMsg = "";
                    var delre = UploadPrivate.DeleteFace(deletemodels, out errMsg);
                    if (delre!=null&&delre.Count>0)
                    {
                        foreach (var item in delre)
                        {
                            sfbll.Delete(item.STAFF_ID,item.FACEDEV_ID);
                        }
                    }
                }
                if (isupload)
                {
                    string errMsg = "";
                    bool ret = UploadPrivate.UploadFace(addmodels,updatemodels,out  errMsg);
                    if (!ret || !string.IsNullOrWhiteSpace(errMsg))
                    {
                        WinInfoHelper.ShowInfoWindow(this, "保存成功，部分权限上传异常：" + errMsg);
                    }
                }
                this.Invoke(new Action(() =>
                {
                    this.DialogResult = DialogResult.OK;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void btnOkUpload_Click(object sender, EventArgs e)
        {
            DoSave(true);
        }

        private void btnAllUpload_Click(object sender, EventArgs e)
        {
            DoSave(true,true);
        }

    }
}
