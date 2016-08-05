using DevComponents.AdvTree;
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
    }
}
