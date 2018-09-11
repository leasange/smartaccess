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

        private void DoSearch(string staffname,string staffno,string staffdept)
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
                strWhere += " and STAFF_NO='" + staffno + "'";
            }
            if (!string.IsNullOrWhiteSpace(staffdept))
            {
                 strWhere += " and ORG_NAME like '%" + staffdept + "%'";
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
                    string strphone="无";
                    if ( item.PHOTO==null|| item.PHOTO.Length==0 )
	                {
		                strphone="无";
	                }else{
                        strphone="照片";
                    }
                    row.CreateCells(dgvStaffs,
                        item.STAFF_NO,
                        item.REAL_NAME,
                        item.ORG_NAME,
                        item.FACEDEV_NAME,
                        item.IS_FORBIDDEN?"已禁用":"正常",
                        item.START_VALID_TIME.ToString("yyyy-MM-dd") + "-" + item.END_VALID_TIME.ToString("yyyy-MM-dd"),
                        strphone,
                        "删除",
                        "授权",
                        item.IS_UPLOAD ?"重上传":"上传");
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
            DoSearch(tbName.Text, tbStaffNo.Text, tbDeptName.Text);
        }

        private void biClear_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbStaffNo.Text = "";
            tbDeptName.Text = "";
        }
    }
}
