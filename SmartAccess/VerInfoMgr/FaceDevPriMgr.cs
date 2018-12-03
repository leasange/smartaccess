using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using DevComponents.AdvTree;

namespace SmartAccess.VerInfoMgr
{
    public partial class FaceDevPriMgr : UserControl
    {
        private List<Maticsoft.Model.SMT_FACERECG_DEVICE> _faceDevices = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FaceDevPriMgr));
        private List<Maticsoft.Model.SMT_FACERECG_DEVICE> _selectDevices=null;
        public FaceDevPriMgr()
        {
            InitializeComponent();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            CommonClass.FilterTree(advTree, tbFilter.Text.Trim());
        }

        private void FaceDevPriMgr_Load(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_FACERECG_DEVICE faceBll = new Maticsoft.BLL.SMT_FACERECG_DEVICE();
                    _faceDevices = faceBll.GetModelList("");
                    var areas = AreaDataHelper.GetAreas();
                    this.Invoke(new Action(() =>
                    {
                        var nodes = AreaDataHelper.ToTree(areas);
                        var faceDevs=_faceDevices.ToList();
                        foreach (var item in nodes)
	                    {
		                    DoCreateAreaDevice(item,faceDevs);
	                    }

                        for (int i = faceDevs.Count - 1; i >= 0; i--)
                        {
                            var item = faceDevs[i];
                            Node devNode = new Node("<font color='blue'>" + item.FACEDEV_NAME + "</font>");
                            devNode.Image = Properties.Resources.editor;
                            devNode.Tag = item;
                            nodes.Insert(0, devNode);
                        }
                        Node root = new Node("所有人脸识别设备");
                        root.Image = Properties.Resources.house1818;
                        root.Nodes.AddRange(nodes.ToArray());
                        nodes.Clear();
                        nodes.Add(root);


                        advTree.Nodes.Clear();
                        advTree.Nodes.AddRange(nodes.ToArray());
                        advTree.ExpandAll();
                    }));

                    DoSearch(null, null, null);
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载人脸设备列表异常！"+ex.Message);
                    log.Error("加载人脸设备列表异常:", ex);
                }
            });
            waiting.Show(this);
        }

        private void DoCreateAreaDevice(Node areaNode,List<Maticsoft.Model.SMT_FACERECG_DEVICE> devs)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE zone = areaNode.Tag as Maticsoft.Model.SMT_CONTROLLER_ZONE;
            if (zone != null)
            {
                var fdev = devs.FindAll(m => m.AREA_ID == zone.ID);
                for (int i = fdev.Count - 1; i >= 0; i--)
                {
                    var item = fdev[i];
                    Node doorNode = new Node("<font color='blue'>" + item.FACEDEV_NAME + "</font>");
                    doorNode.Tag = item;
                    doorNode.Image = Properties.Resources.door1818;
                    areaNode.Nodes.Insert(0, doorNode);
                    devs.Remove(item);
                }
            }
            foreach (Node item in areaNode.Nodes)
            {
                DoCreateAreaDevice(item, devs);
            }
        }

        private void biAddPrivate_Click(object sender, EventArgs e)
        {
            if (_selectDevices==null||_selectDevices.Count==0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请至少选择一个人脸设备！");
                return;
            }
            FrmAddFaceDevPrivate frmAddFaceDevPrivate = new FrmAddFaceDevPrivate(_selectDevices);
           DialogResult dr = frmAddFaceDevPrivate.ShowDialog(this);
           if (dr== DialogResult.OK)
           {
               DoSearch(null, null, null);
           }
        }

        private void advTree_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            _selectDevices = advTree.GetTypeList<Maticsoft.Model.SMT_FACERECG_DEVICE>(CheckState.Checked);
            DoSearch(null, null, null);
        }

        private void DoSearch(string staffname,string staffno,string staffdept,bool bunUpload=false)
        {
            string selectdeviceIds = null;
            if (_selectDevices!=null&&_selectDevices.Count>0)
            {
                foreach (var item in _selectDevices)
                {
                    selectdeviceIds += item.ID + ",";
                }
                selectdeviceIds = selectdeviceIds.TrimEnd(',');
            }
            string strWhere = "1=1";
            if (!string.IsNullOrWhiteSpace(selectdeviceIds))
            {
                strWhere += " and FACEDEV_ID in (" + selectdeviceIds + ")";
            }
            if (!string.IsNullOrWhiteSpace(staffname))
            {
                strWhere += " and REAL_NAME like '%" + staffname + "%'";
            }
            if (!string.IsNullOrWhiteSpace(staffno))
            {
                strWhere += " and STAFF_NO like '%" + staffno + "%'";
            }
            if (!string.IsNullOrWhiteSpace(staffdept))
            {
                 strWhere += " and ORG_NAME like '%" + staffdept + "%'";
            }
            if (bunUpload)
            {
                strWhere += " and IS_UPLOAD !=1";
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_STAFF_FACEDEV bll = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
                    int count = bll.GetRecordCountEx(strWhere);
                    this.Invoke(new Action(() =>
                    {
                        pageDataGridView.PageControl.TotalRecords = count;
                        pageDataGridView.PageControl.CurrentPage = 1;
                        pageDataGridView.PageControl.Tag = strWhere;
                        dgvStaffs.Rows.Clear();
                    }));
                    if (count > 0)
                    {
                        doSearch(strWhere, pageDataGridView.PageControl.StartIndex, pageDataGridView.PageControl.EndIndex);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("查询授权记录异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "查询授权信息异常：" + ex.Message);
                }

            });
            waiting.Show(this);
        }
        private void doSearch(string strWhere, int startIndex, int endIndex)
        {
            Maticsoft.BLL.SMT_STAFF_FACEDEV bll = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
            var models = bll.GetModelListEx(strWhere, startIndex, endIndex);
            this.Invoke(new Action(() =>
            {
                dgvStaffs.Rows.Clear();
                foreach (var item in models)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    string state = "";
                    Color color = row.DefaultCellStyle.BackColor;
                    if (item.IS_FORBIDDEN)
                    {
                        state = "已禁用";
                        color = Color.LightGray;
                    }
                    else if (item.IS_UPLOAD)
                    {
                        state = "已上传";
                    }
                    else
                    {
                        if (item.PHOTO == null || item.PHOTO.Length == 0)
                        {
                            state = "未上传（无照片）";
                            color = Color.FromArgb(0xEE, 0x00, 0x00);
                        }
                        else
                        {
                            state = "未上传";
                            color = Color.FromArgb(0xEE, 0x40, 0x00);
                        }
                    }
                    row.CreateCells(dgvStaffs,
                        item.FACEDEV_NAME,
                        item.STAFF_NO,
                        item.REAL_NAME,
                        item.ORG_NAME,
                        state,
                        item.START_VALID_TIME.ToString("yyyy-MM-dd") + "-" + item.END_VALID_TIME.ToString("yyyy-MM-dd"),
                        "修改",
                        "删除",
                        item.IS_UPLOAD ?"重上传":"上传");
                    row.Tag = item;
                    row.DefaultCellStyle.ForeColor = color;
                    dgvStaffs.Rows.Add(row);
                }
            }));
        }

        private void pageDataGridView_PageControl_PageChanged(object sender, Li.Controls.PageEventArgs args)
        {
            if (pageDataGridView.PageControl.Tag!=null)
            {
                doSearch(pageDataGridView.PageControl.Tag.ToString(), args.StartIndex, args.EndIndex);
            }
        }

        private void biDoSearch_Click(object sender, EventArgs e)
        {
            DoSearch(tbName.Text, tbStaffNo.Text, tbDeptName.Text,cbUnUpload.Checked);
        }

        private void biClear_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbStaffNo.Text = "";
            tbDeptName.Text = "";
            cbUnUpload.Checked = false;
        }
        private List<Maticsoft.Model.SMT_STAFF_FACEDEV> GetSelectStaffs(out List<DataGridViewRow> rows)
        {
            rows = null;
            if (this.dgvStaffs.SelectedRows.Count==0)
            {
                return null;
            }
            List<Maticsoft.Model.SMT_STAFF_FACEDEV> list = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
            rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in this.dgvStaffs.SelectedRows)
            {
                Maticsoft.Model.SMT_STAFF_FACEDEV sfdModel = (Maticsoft.Model.SMT_STAFF_FACEDEV)row.Tag;
                list.Add(sfdModel);
                rows.Add(row);
            }
            return list;
        }
        private void biUploadSelect_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows;
            var list = GetSelectStaffs(out rows);
            if (list==null||list.Count==0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择至少选择一个授权人员！");
                return;
            }
            DoUpload(list,false, false,rows.ToArray());
        }

        private void DoUpload( List<Maticsoft.Model.SMT_STAFF_FACEDEV>  list,bool bforce,bool bcancel,params DataGridViewRow[] rows)
        {
            List<Maticsoft.Model.SMT_STAFF_FACEDEV> addmodels = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
            List<Maticsoft.Model.SMT_STAFF_FACEDEV> updatemodels = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
            List<Maticsoft.Model.SMT_STAFF_FACEDEV> deletemodels = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>();
            foreach (var item in list)
            {
                if (bcancel && item.IS_UPLOAD)
                {
                    deletemodels.Add(item);
                }
                else
                {
                    if (item.IS_UPLOAD)
                    {
                        updatemodels.Add(item);
                    }
                    else
                    {
                        addmodels.Add(item);
                    }
                }
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                string errMsg = "";
                bool ret = false;
                List<Maticsoft.Model.SMT_STAFF_FACEDEV> dels = null;
                if (bcancel&&deletemodels.Count>0)
                {
                   dels = UploadPrivate.DeleteFace(deletemodels, out errMsg);
                   if (!string.IsNullOrWhiteSpace(errMsg))
                   {
                       WinInfoHelper.ShowInfoWindow(this, "权限删除存在异常：" + errMsg);
                   }
                }
                else
                {
                    SmartAccess.Common.Datas.UploadPrivate.CancelObject cancelObject = new UploadPrivate.CancelObject(); 
                    if (bforce)
                    {
                        ret = UploadPrivate.UploadFace(cancelObject, list, null, out  errMsg);
                    }
                    else
                    {
                        ret = UploadPrivate.UploadFace(cancelObject, addmodels, updatemodels, out  errMsg);
                    }
                    if (!ret || !string.IsNullOrWhiteSpace(errMsg))
                    {
                        WinInfoHelper.ShowInfoWindow(this, "权限上传存在异常：" + errMsg);
                    }
                }
                
                if (rows != null && rows.Length > 0)
                {
                    this.Invoke(new Action(() =>
                        {
                            foreach (var row in rows)
                            {
                                Maticsoft.Model.SMT_STAFF_FACEDEV item = (Maticsoft.Model.SMT_STAFF_FACEDEV)row.Tag;
                                string state = "";
                                if (item.IS_FORBIDDEN)
                                {
                                    state = "已禁用";
                                }
                                else if (item.IS_UPLOAD)
                                {
                                    state = "已上传";
                                }
                                else
                                {
                                    if (item.PHOTO == null || item.PHOTO.Length == 0)
                                    {
                                        state = "未上传（无照片）";
                                    }
                                    else
                                    {
                                        state = "未上传";
                                    }
                                }
                                row.Cells[4].Value = state;
                                row.Cells[8].Value = item.IS_UPLOAD ? "重上传" : "上传";
                            }
                        }));
                }
                else
                {
                    DoSearch(null, null, null);
                }
            });
            waiting.Show(this);
        }

        private void biOneKeyUpload_Click(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_STAFF_FACEDEV bll = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
                    var models = bll.GetModelListEx("", 1, -1);
                    DoUpload(models,false,false);
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "上传发生异常：" + ex.Message);
                }
            });
            waiting.Show(this);
        }

        private void biDeleteSelect_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows;
            var list = GetSelectStaffs(out rows);
            if (list == null || list.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "至少选择一个待删除的授权！");
                return;
            }
            doDelete(list,true);
        }

        private void doDelete(List<Maticsoft.Model.SMT_STAFF_FACEDEV> list, bool research,params DataGridViewRow[] rows)
        {
            if (DialogResult.Cancel==MessageBox.Show("确定删除选择"+list.Count+"项的授权？","确认",MessageBoxButtons.OKCancel))
            {
                return;
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                string errMsg = "";
                try
                {
                    var sdfs = UploadPrivate.DeleteFace(list, out errMsg);
                    if (sdfs != null && sdfs.Count > 0)
                    {
                        foreach (var item in sdfs)
                        {
                            Maticsoft.BLL.SMT_STAFF_FACEDEV bll = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
                            bll.Delete(item.STAFF_ID, item.FACEDEV_ID);
                        }
                        if (research)
                        {
                            DoSearch(null, null, null);
                        }
                        else if (rows != null)
                        {
                            this.Invoke(new Action(() =>
                             {
                                 try
                                 {
                                     foreach (var item in rows)
                                     {
                                         dgvStaffs.Rows.Remove(item);
                                     }
                                 }
                                 catch (Exception)
                                 {
                                      
                                 }

                             }));
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "删除存在异常：" + ex.Message + "," + errMsg);
                }
            });
            waiting.Show(this);
        }
        private void dgvStaffs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row=dgvStaffs.Rows[e.RowIndex];
                Maticsoft.Model.SMT_STAFF_FACEDEV ffd = (Maticsoft.Model.SMT_STAFF_FACEDEV)row.Tag;
                List<Maticsoft.Model.SMT_STAFF_FACEDEV> list = new List<Maticsoft.Model.SMT_STAFF_FACEDEV>() { ffd };
                if (dgvStaffs.Columns[e.ColumnIndex].Name == "Col_DELETE")
                {
                    doDelete(list, false, row);
                }
                else if (dgvStaffs.Columns[e.ColumnIndex].Name == "Col_Modify")
                {
                    try
                    {
                        FrmStaffInfo staffInfo = new FrmStaffInfo(ffd);
                        staffInfo.ShowDialog(this);
                        row.Cells[1].Value = staffInfo.StaffInfo.STAFF_NO;
                        row.Cells[2].Value = staffInfo.StaffInfo.REAL_NAME;
                        row.Cells[3].Value = staffInfo.StaffInfo.ORG_NAME;
                        
                        string state = "";
                        if (staffInfo.StaffInfo.PHOTO == null || staffInfo.StaffInfo.PHOTO.Length == 0)
                        {
                            state = "未上传（无照片）";
                        }
                        else
                        {
                            state = "未上传";
                        }
                        row.Cells[4].Value = state;
                    }
                    catch (Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "修改发生异常:" + ex.Message);
                    }
                }
                else if (dgvStaffs.Columns[e.ColumnIndex].Name == "Col_SC")
                {
                    DoUpload(list,true,false,row);
                }
            }
        }

        private void tbName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                biDoSearch_Click(null, null);
            }
        }

        private void biForceUpload_Click(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_STAFF_FACEDEV bll = new Maticsoft.BLL.SMT_STAFF_FACEDEV();
                    var models = bll.GetModelListEx("", 1, -1);
                    DoUpload(models,true,false);
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "上传发生异常：" + ex.Message);
                }
            });
            waiting.Show(this);
        }

        private void biCancelUpload_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows;
            var list = GetSelectStaffs(out rows);
            if (list == null || list.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择至少选择一个授权人员！");
                return;
            }
            DoUpload(list, false,true, rows.ToArray());
        }

        private void biRegister_Click(object sender, EventArgs e)
        {
            FrmStaffInfo staffInfo = new FrmStaffInfo(true);
            staffInfo.ShowDialog(this);
            if (staffInfo.HasChanged)
            {
                DoSearch(null, null, null);
            }
        }
    }
}
