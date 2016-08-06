﻿using DevComponents.AdvTree;
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
    public partial class FrmAddOrModifyStaffPrivate : DevComponents.DotNetBar.Office2007Form
    {
        private Maticsoft.Model.SMT_STAFF_INFO staffInfo;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmAddOrModifyStaffPrivate));

        public FrmAddOrModifyStaffPrivate()
        {
            InitializeComponent();
        }

        public FrmAddOrModifyStaffPrivate(Maticsoft.Model.SMT_STAFF_INFO staffInfo)
        {
            InitializeComponent();
            this.staffInfo = staffInfo;
            this.Text = "当前授权对象：" + staffInfo.REAL_NAME;
        }
        private void FrmAddOrModifyStaffPrivate_Load(object sender, EventArgs e)
        {

        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            List<Node> nodes = new List<Node>();
            foreach (Node item in  this.doorTree.Tree.SelectedNodes)
            {
                nodes.Add(item);
            }

            nodes = this.doorTree.Tree.GetNodeList(nodes, typeof(Maticsoft.Model.SMT_DOOR_INFO));
            DoSelectDoors(nodes);
        }
        /// <summary>
        /// 执行选择门
        /// </summary>
        /// <param name="doors"></param>
        private void DoSelectDoors(List<Node> doors)
        {
            foreach (var item in doors)
            {
                Maticsoft.Model.SMT_DOOR_INFO door = (Maticsoft.Model.SMT_DOOR_INFO)item.Tag;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvSelectDoor, door.DOOR_NAME, door.AREA_NAME);
                row.Tag = item;
                dgvSelectDoor.Rows.Add(row);
                item.DataKey = item.Parent;
                item.Remove();
            }
        }

        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            List<Node> nodes = new List<Node>();
            foreach (Node item in this.doorTree.Tree.Nodes)
            {
                nodes.Add(item);
            }
            nodes = this.doorTree.Tree.GetNodeList(nodes, typeof(Maticsoft.Model.SMT_DOOR_INFO));
            DoSelectDoors(nodes);
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvSelectDoor.SelectedRows)
            {
                rows.Add(item);
            }
            DoUnSelect(rows);
        }
        private void DoUnSelect(List<DataGridViewRow> rows)
        {
            for (int i = rows.Count - 1; i >= 0; i--)
            {
                var item = rows[i];
                Node node = (Node)item.Tag;
                Node parent = (Node)node.DataKey;
                parent.Nodes.Insert(0, node);
                dgvSelectDoor.Rows.Remove(item);
            }
        }

        private void btnAllUnSelect_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow item in dgvSelectDoor.Rows)
            {
                rows.Add(item);
            }
            DoUnSelect(rows);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = GetSelect();
            DoSaveDoors(doors);
        }

        private void btnOkUpload_Click(object sender, EventArgs e)
        {
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = GetSelect();
            DoSaveDoors(doors,true);
        }
        private List<Maticsoft.Model.SMT_DOOR_INFO> GetSelect()
        {
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = new List<Maticsoft.Model.SMT_DOOR_INFO>();
            foreach (DataGridViewRow item in dgvSelectDoor.Rows)
            {
                Node node = (Node)item.Tag;
                Maticsoft.Model.SMT_DOOR_INFO door = (Maticsoft.Model.SMT_DOOR_INFO)node.Tag;
                doors.Add(door);
            }
            return doors;
        }
        private void DoSaveDoors(List<Maticsoft.Model.SMT_DOOR_INFO> doors, bool upload = false)
        {
            CtrlWaiting ctrlWaiting = new CtrlWaiting("正在保存...", () =>
             {
                 try
                 {
                     Maticsoft.BLL.SMT_STAFF_DOOR sdBLL = new Maticsoft.BLL.SMT_STAFF_DOOR();
                     var sdList = sdBLL.GetModelList("STAFF_ID=" + staffInfo.ID);
                     List<Maticsoft.Model.SMT_DOOR_INFO> tempDoors = new List<Maticsoft.Model.SMT_DOOR_INFO>();
                     tempDoors.AddRange(doors);
                     foreach (var item in sdList)
                     {
                         var sc = doors.Find(m => m.ID == item.DOOR_ID);
                         if (sc == null)//权限删除
                         {
                             sdBLL.Delete(item.STAFF_ID, item.DOOR_ID);//删除权限
                         }
                         else
                         {
                             tempDoors.Remove(sc);
                         }
                     }
                     foreach (var item in tempDoors)//添加的权限
                     {
                         Maticsoft.Model.SMT_STAFF_DOOR newSd = new Maticsoft.Model.SMT_STAFF_DOOR();
                         newSd.ADD_TIME = DateTime.Now;
                         newSd.DOOR_ID = item.ID;
                         newSd.IS_UPLOAD = false;
                         newSd.UPLOAD_TIME = DateTime.Now;
                         newSd.STAFF_ID = staffInfo.ID;
                         sdBLL.Add(newSd);
                     }
                     if (upload)
                     {
                         string errMsg;
                         bool ret = UploadPrivate.Upload(staffInfo, out errMsg);
                         if (ret && errMsg != "")
                         {
                             WinInfoHelper.ShowInfoWindow(this, "上传权限存在异常：" + errMsg);
                             log.Warn("上传权限存在异常:" + errMsg);
                             return;
                         }
                         else if(!ret)
                         {
                             return;
                         }
                     }
                     this.Invoke(new Action(() =>
                         {
                             this.DialogResult = DialogResult.OK;
                             this.Close();
                         }));
                 }
                 catch (System.Exception ex)
                 {
                     log.Error("保存异常：", ex);
                     WinInfoHelper.ShowInfoWindow(this, "保存异常：" + ex.Message);
                 }
             });
            ctrlWaiting.Show(this);
        }

    }
}
