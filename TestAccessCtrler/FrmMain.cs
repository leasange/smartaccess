using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestAccessCtrler
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IAccessCore access = new WGAccess();
            List<Controller> ctrls = access.SearchController();
            dataGridView1.Rows.Clear();
            foreach (var item in ctrls)
            {
                string door = "";
                switch (item.doorType)
                {
                    case ControllerDoorType.OneDoorTwoDirections:
                        door = "单门双向";
                        break;
                    case ControllerDoorType.TwoDoorsTwoDirections:
                        door = "双门双向";
                        break;
                    case ControllerDoorType.FourDoorsOneDirection:
                        door = "四门单向";
                        break;
                    default:
                        break;
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1,
                    item.sn,
                    door,
                    item.ip,
                    item.mask,
                    item.gateway,
                    item.mac,
                    item.driverVersion,
                    item.driverReleaseTime,
                    "确定修改",
                    "获取状态"
                    );
                row.Tag = item;
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                Controller ctrl = (Controller)row.Tag;
                if (this.dataGridView1.ColumnCount == e.ColumnIndex + 2)//修改IP
                {
                    if (MessageBox.Show("确定修改设备地址？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        ctrl.ip = row.Cells[2].Value.ToString();
                        ctrl.mask = row.Cells[3].Value.ToString();
                        ctrl.gateway = row.Cells[4].Value.ToString();
                        IAccessCore access = new WGAccess();
                        access.SetControllerIP(ctrl);
                    }
                }
                else if (this.dataGridView1.ColumnCount == e.ColumnIndex + 1)//获取控制器状态
                {
                    IAccessCore access = new WGAccess();
                    ControllerState state = access.GetControllerState(ctrl);
                    MessageBox.Show(state.lastRecordIndex+" "+state.reasonNo.ToString());
                }
            }
        }
        private Controller GetSelectedController()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                return dataGridView1.SelectedRows[0].Tag as Controller;
            }
            else if (dataGridView1.SelectedCells.Count>0&&dataGridView1.SelectedCells[0].RowIndex>=0)
            {
                return dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Tag as Controller;
            }
            else
            {
                MessageBox.Show("请选择行！");
            }
            return null;
        }
        private void btnGetTime_Click(object sender, EventArgs e)
        {
            Controller ctrl = GetSelectedController();
            if (ctrl==null)
            {
                return;
            }
            IAccessCore access = new WGAccess();
            DateTime dt = access.GetControllerTime(ctrl);
            dateTimePicker1.Value = dt;
        }

        private void btnSetTime_Click(object sender, EventArgs e)
        {
            Controller ctrl = GetSelectedController();
            if (ctrl == null)
            {
                return;
            }
            IAccessCore access = new WGAccess();
            bool ret = access.SetControllerTime(ctrl,dateTimePicker1.Value);
            MessageBox.Show("设置" + (ret ? "成功！" : "失败"));
        }

        private void btnReadRecord_Click(object sender, EventArgs e)
        {
            Controller ctrl = GetSelectedController();
            if (ctrl == null)
            {
                return;
            }
            IAccessCore access = new WGAccess();
            ControllerState state = access.GetControllerRecord(ctrl, 0);
            MessageBox.Show("记录：index=" + state.lastRecordIndex + " reasonNo=" + state.reasonNo+" time="+state.recordTime);
        }

        private void btnGetReadedIndex_Click(object sender, EventArgs e)
        {
            Controller ctrl = GetSelectedController();
            if (ctrl == null)
            {
                return;
            }
            IAccessCore access = new WGAccess();
            long index = access.GetControllerReadedIndex(ctrl);
            MessageBox.Show("已读记录：index=" + index);
        }
        private IAccessCore totalAccess = new WGAccess();
        private void btnReadNextRecord_Click(object sender, EventArgs e)
        {
            Controller ctrl = GetSelectedController();
            if (ctrl == null)
            {
                return;
            }
            if (totalAccess.BeginReadRecord(ctrl))
            {
                ControllerState record = totalAccess.ReadNextRecord();
                if (record==null||record.recordType== RecordType.NoRecord)
                {
                    totalAccess.EndReadRecord();
                    MessageBox.Show("读取完毕！");
                }
                else
                {
                    MessageBox.Show("记录：index=" + record.lastRecordIndex + " reasonNo=" + record.reasonNo + " time=" + record.recordTime);
                }
            }
        }

        private void btnOpenRemoteDoor_Click(object sender, EventArgs e)
        {
            Controller ctrl = GetSelectedController();
            if (ctrl == null)
            {
                return;
            }
            IAccessCore access = new WGAccess();
            bool ret = access.OpenRemoteControllerDoor(ctrl, (int)iintValue.Value);
            MessageBox.Show("远程开门" + (ret ? "成功" : "失败"));
        }

        private void btnAddAuth_Click(object sender, EventArgs e)
        {
            Controller ctrl = GetSelectedController();
            if (ctrl == null)
            {
                return;
            }
            IAccessCore access = new WGAccess();
           Dictionary<int,bool>  dic= new Dictionary<int,bool>();
            dic.Add(1,true);
            dic.Add(2,true);

//             bool ret = access.AddOrModifyAuthority(ctrl, (long)iintValue.Value,
//                 DateTime.Now, DateTime.Now.AddDays(10), dic
//                 );
//             MessageBox.Show("设置权限" + (ret ? "成功" : "失败"));
        }

        private void btnResetRecord_Click(object sender, EventArgs e)
        {
            IAccessCore access = new WGAccess();
             Controller ctrl = GetSelectedController();
            if (ctrl == null)
            {
                return;
            }
            access.SetControllerReadedIndex(ctrl, 0);
        }
    }
}
