using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.Datas;
using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using SmartAccess.Common.WinInfo;
using Li.Controls.Excel;
using SmartAccess.Common;
using Li.Access.Core.FaceDevice;

namespace SmartAccess.ControlDevMgr
{
    public partial class FaceDeviceMgr : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FaceDeviceMgr));
        public FaceDeviceMgr()
        {
            InitializeComponent();
        }
        private void FaceDeviceMgr_Load(object sender, EventArgs e)
        {
            Init();
        }
        private void Init(int time=300)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    List<Maticsoft.Model.SMT_FACERECG_DEVICE> devs = FaceRecgHelper.GetList("1=1", true);//获取所有控制器
                    List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas = AreaDataHelper.GetAreas(true);//获取所有区域
                    this.Invoke(new Action(() =>
                        {
                            ShowAreas(areas);
                            ShowDevs(devs);
                        }));
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载异常：" + ex.Message);
                    log.Error("加载异常：", ex);
                }
            });
            waiting.Show(this, time);
        }
        private void DoLoadCtrlrs(List<decimal> areaIds)
        {
            List<Maticsoft.Model.SMT_FACERECG_DEVICE> devs = FaceRecgHelper.GetList(areaIds);

        }
        private void ShowAreas(List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas)
        {
            var tree=  AreaDataHelper.ToTree(areas);
            advTreeArea.Nodes[0].Nodes.Clear();
            advTreeArea.Nodes[0].Nodes.AddRange(tree.ToArray());
            advTreeArea.ExpandAll();
        }

        private void ShowDevs(List<Maticsoft.Model.SMT_FACERECG_DEVICE> ctrls, string filter = null)
        {
            if (ctrls == null)
            {
                return;
            }
            dgvCtrlr.Rows.Clear();
            foreach (var item in ctrls)
            {
                AddRow(item, filter);
            }
        }
        private void AddRow(Maticsoft.Model.SMT_FACERECG_DEVICE dev, string filter = null)
        {
            if (!string.IsNullOrWhiteSpace(filter))
            {
                string str = dev.FACEDEV_NAME + " " + dev.FACEDEV_SN + " " + dev.FACEDEV_IP + " " + dev.AREA_NAME;
                if (!str.Contains(filter.Trim()))
                {
                    return;
                }
            }
            string videoState = "无视频";
            if (dev.FVIDEO_RTSP_COUNT != null)
            {
                if(dev.FVIDEO_RTSP_COUNT==1&&!string.IsNullOrWhiteSpace(dev.FVIDEO_RTSP))
                {
                    videoState = "单路视频";
                }
                else if (dev.FVIDEO_RTSP_COUNT==3&&
                    !string.IsNullOrWhiteSpace(dev.FVIDEO_RTSP))
                {
                    videoState = "三路视频";
                }
            }
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvCtrlr,
                dev.FACEDEV_NAME,
                dev.FACEDEV_SN,
                dev.FACEDEV_IS_ENABLE?"启用":"禁用",
                dev.FACEDEV_IP,
                dev.FACEDEV_CTRL_PORT,
                dev.AREA_NAME,
                videoState,
                "修改",
                "删除"
                );
            row.Tag = dev;
            dgvCtrlr.Rows.Add(row);
        }
        private void UpdateRow(DataGridViewRow row, Maticsoft.Model.SMT_FACERECG_DEVICE dev)
        {
            if (dev==null)
            {
                return;
            }

            string videoState = "无视频";
            if (dev.FVIDEO_RTSP_COUNT != null)
            {
                if (dev.FVIDEO_RTSP_COUNT == 1 && !string.IsNullOrWhiteSpace(dev.FVIDEO_RTSP))
                {
                    videoState = "单路视频";
                }
                else if (dev.FVIDEO_RTSP_COUNT == 3 &&
                    !string.IsNullOrWhiteSpace(dev.FVIDEO_RTSP))
                {
                    videoState = "三路视频";
                }
            }

            row.Cells[0].Value = dev.FACEDEV_NAME;
            row.Cells[1].Value = dev.FACEDEV_SN;
            row.Cells[2].Value = dev.FACEDEV_IS_ENABLE ? "启用" : "禁用";
            row.Cells[3].Value = dev.FACEDEV_IP;
            row.Cells[4].Value = dev.FACEDEV_CTRL_PORT;
            row.Cells[5].Value = dev.AREA_NAME;
            row.Cells[6].Value = videoState;
            row.Tag = dev;
        }
        private Maticsoft.Model.SMT_CONTROLLER_ZONE GetSelectArea()
        {
            if(advTreeArea.SelectedNode!=null)
            {
               return advTreeArea.SelectedNode.Tag as Maticsoft.Model.SMT_CONTROLLER_ZONE;
            }
            return null;
        }
        private List<Maticsoft.Model.SMT_CONTROLLER_ZONE> GetSelectWithSubAreas()
        {
            List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas = new List<Maticsoft.Model.SMT_CONTROLLER_ZONE>();
            if (advTreeArea.SelectedNode!=null&&advTreeArea.SelectedNode.Tag is Maticsoft.Model.SMT_CONTROLLER_ZONE)
            {
                areas.Add((Maticsoft.Model.SMT_CONTROLLER_ZONE)advTreeArea.SelectedNode.Tag);
                GetSubAreas(advTreeArea.SelectedNode, ref areas);
            }
            return areas;
        }
        private void GetSubAreas(DevComponents.AdvTree.Node node,ref List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas)
        {
            foreach (DevComponents.AdvTree.Node item in node.Nodes)
            {
                areas.Add((Maticsoft.Model.SMT_CONTROLLER_ZONE)item.Tag);
                GetSubAreas(item, ref areas);
            }
        }


        private void DoLoadByArea(List<Maticsoft.Model.SMT_CONTROLLER_ZONE>  areas,string filter=null)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    string strWhere = "1=1";
                    if (areas != null &&areas.Count>0)
                    {
                        strWhere = "AREA_ID in (";
                        foreach (var item in areas)
                        {
                            strWhere += item.ID + ",";
                        }
                        strWhere = strWhere.TrimEnd(',');
                        strWhere += ")";
                    }
                    List<Maticsoft.Model.SMT_FACERECG_DEVICE> ctrls = FaceRecgHelper.GetList(strWhere, true);//获取所有人脸设备
                    this.Invoke(new Action(() =>
                    {
                        ShowDevs(ctrls, filter);
                    }));
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载人脸识别设备异常：" + ex.Message);
                    log.Error("加载人脸识别设备异常：", ex);
                }
            });
            waiting.Show(this);
        }
        private void advTreeArea_NodeMouseDown(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Left)
            {
                if (e.Node.Tag ==null)
                {
                    DoLoadByArea(null);
                }
                else DoLoadByArea(GetSubAreas(e.Node));
            }
        }
        private List<Maticsoft.Model.SMT_CONTROLLER_ZONE> GetSubAreas(DevComponents.AdvTree.Node node)
        {
            List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas = new List<Maticsoft.Model.SMT_CONTROLLER_ZONE>();
            if (node.Tag is Maticsoft.Model.SMT_CONTROLLER_ZONE)
            {
                areas.Add((Maticsoft.Model.SMT_CONTROLLER_ZONE)node.Tag);
            }
            foreach (DevComponents.AdvTree.Node item in node.Nodes)
            {
                areas.AddRange(GetSubAreas(item));
            }
            return areas;
        }
        private void advTreeArea_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            if (e.Node==null)
            {
                return;
            }
            if (e.Node.Level==0)
            {
                biDeleteArea.Enabled = false;
                biModifyArea.Enabled = false;
            }
            else
            {
                biDeleteArea.Enabled = true;
                biModifyArea.Enabled = true;
            }
        }

        private void biAddArea_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE area = GetSelectArea();
            FrmControlAreaEditor areaEditor = new FrmControlAreaEditor();
            areaEditor.IsAdd = true;
            if (area!=null)
            {
                areaEditor.ParentAreaID = area.PAR_ID;
            }
            else
            {
                areaEditor.ParentAreaID = 0;
            }
            if(areaEditor.ShowDialog(this)== DialogResult.OK)
            {
                Maticsoft.Model.SMT_CONTROLLER_ZONE areaAdded = areaEditor.Area;
                DevComponents.AdvTree.Node node = AreaDataHelper.CreateNode(areaAdded);
                if (advTreeArea.SelectedNode==null||advTreeArea.SelectedNode.Level==0)
                {
                    advTreeArea.Nodes[0].Nodes.Add(node);
                }
                else
                {
                    advTreeArea.SelectedNode.Parent.Nodes.Add(node);
                    
                }
                node.Parent.Expand();
            }
        }

        private void biAddSubArea_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE area = GetSelectArea();
            FrmControlAreaEditor areaEditor = new FrmControlAreaEditor();
            areaEditor.IsAdd = true;
            if (area != null)
            {
                areaEditor.ParentAreaID = area.ID;
            }
            else
            {
                areaEditor.ParentAreaID = 0;
            }
            if (areaEditor.ShowDialog(this) == DialogResult.OK)
            {
                Maticsoft.Model.SMT_CONTROLLER_ZONE areaAdded = areaEditor.Area;
                DevComponents.AdvTree.Node node = AreaDataHelper.CreateNode(areaAdded);
                if (advTreeArea.SelectedNode == null || advTreeArea.SelectedNode.Level == 0)
                {
                    advTreeArea.Nodes[0].Nodes.Add(node);
                }
                else
                {
                    advTreeArea.SelectedNode.Nodes.Add(node);
                }
                node.Parent.Expand();
            }
        }

        private void biDeleteArea_Click(object sender, EventArgs e)
        {
            List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas = GetSelectWithSubAreas();
            if (areas.Count>0)
            {
                if (MessageBox.Show("确定删除当前区域及其下级区域？","提示",MessageBoxButtons.OKCancel)== DialogResult.OK)
                {
                    AreaDataHelper.DeleteAreas(areas);
                    advTreeArea.SelectedNode.Remove();
                }
            }
        }
        private void btnAddCtrlr_Click(object sender, EventArgs e)
        {
            FrmAddOrModifyFaceDev frmModify = new FrmAddOrModifyFaceDev();
            if (frmModify.ShowDialog(this) == DialogResult.OK)
            {
                AddRow(frmModify.Device);
            }
        }

        private void dgvCtrlr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0&&e.ColumnIndex>=0)
            {
                if (dgvCtrlr.Columns[e.ColumnIndex].Name=="Col_XG")//修改
                {
                    DoModify(dgvCtrlr.Rows[e.RowIndex]);
                }
                else if (dgvCtrlr.Columns[e.ColumnIndex].Name=="Col_SC")//删除
                {
                    DoDelete(dgvCtrlr.Rows[e.RowIndex]);
                }
            }
        }
        private void DoModify(DataGridViewRow row)
        {
            Maticsoft.Model.SMT_FACERECG_DEVICE dev = (Maticsoft.Model.SMT_FACERECG_DEVICE)row.Tag;
            FrmAddOrModifyFaceDev frmModify = new FrmAddOrModifyFaceDev(dev);
            if(frmModify.ShowDialog(this)==DialogResult.OK)
            {
                UpdateRow(row, frmModify.Device);
            }
        }
        private void DoDelete(DataGridViewRow row)
        {
            if (MessageBox.Show("确定删除该控制器？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                CtrlWaiting ctrlWaiting = new CtrlWaiting("正在删除中...", () =>
                {
                    try
                    {
                        Maticsoft.Model.SMT_FACERECG_DEVICE dev = (Maticsoft.Model.SMT_FACERECG_DEVICE)row.Tag;
                        DialogResult dr= DialogResult.No;
                        this.Invoke(new Action(() =>
                        {
                            dr = MessageBox.Show("是否清除该人脸识别设备权限？", "提示", MessageBoxButtons.YesNo);
                        }));
                        if (dr==DialogResult.Yes)
                        {
                            BSTFaceRecg c = FaceRecgHelper.ToFaceController(dev);
                            c.ClearFaces();
                        }
                        Maticsoft.BLL.SMT_FACERECG_DEVICE ctrlBll = new Maticsoft.BLL.SMT_FACERECG_DEVICE();
                        ctrlBll.Delete(dev.ID);
                        //置门关联控制器为空
                        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from SMT_STAFF_FACEDEV where FACEDEV_ID=" + dev.ID);
                        SmtLog.Info("设备", "人脸识别设备删除：" + dev.FACEDEV_IP + "," + dev.FACEDEV_NAME);
                        this.Invoke(new Action(() =>
                            {
                                dgvCtrlr.Rows.Remove(row);
                            }));
                    }
                    catch (System.Exception ex)
                    {
                        log.Error("删除人脸识别设备异常：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "删除失败：" + ex.Message);
                    }

                });
                ctrlWaiting.Show(this);
            }
        }

        private void biDeleteCtrlr_Click(object sender, EventArgs e)
        {
            if(dgvCtrlr.SelectedCells.Count>0)
            {
                if(dgvCtrlr.SelectedCells[0].RowIndex>=0)
                {
                    DataGridViewRow row = dgvCtrlr.Rows[dgvCtrlr.SelectedCells[0].RowIndex];
                    DoDelete(row);
                }
            }
        }

        private void biRefresh_Click(object sender, EventArgs e)
        {
            Init(0);
        }

        private void biSearch_Click(object sender, EventArgs e)
        {
            DoLoadByArea(null, tbCtrlrFilter.Text.Trim());
        }

        private void tbCtrlrFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                 DoLoadByArea(null, tbCtrlrFilter.Text.Trim());
            }
        }

        private void biExport_Click(object sender, EventArgs e)
        {
            ExportHelper.ExportEx(dgvCtrlr, "人脸识别设备.xls", "人脸识别设备");
        }
        private DataGridViewRow GetSelectRow()
        {
            if (dgvCtrlr.SelectedRows.Count>0)
            {
                return dgvCtrlr.SelectedRows[0];
            }
            else if (dgvCtrlr.SelectedCells.Count>0)
            {
                return dgvCtrlr.Rows[dgvCtrlr.SelectedCells[0].RowIndex];
            }
            return null;
        }
        private void dgvCtrlr_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Right)
            {
                if (e.RowIndex>=0)
                {
                    //cmsCtrl.Show(Cursor.Position);
                }
            }
        }
        private void biModifyArea_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE area = GetSelectArea();
            FrmControlAreaEditor areaEditor = new FrmControlAreaEditor(area);
            if (area != null)
            {
                areaEditor.ParentAreaID = area.PAR_ID;
            }
            else
            {
                areaEditor.ParentAreaID = 0;
            }
            if (areaEditor.ShowDialog(this) == DialogResult.OK)
            {
                Maticsoft.Model.SMT_CONTROLLER_ZONE update = areaEditor.Area;
                AreaDataHelper.UpdateNode(advTreeArea.SelectedNode, update);
            }
        }
    }
}
