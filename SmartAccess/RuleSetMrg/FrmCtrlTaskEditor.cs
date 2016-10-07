using DevComponents.AdvTree;
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

namespace SmartAccess.RuleSetMrg
{
    public partial class FrmCtrlTaskEditor :DevComponents.DotNetBar.Office2007Form
    {
        private Maticsoft.Model.SMT_CTRLR_TASK _task = null;
        public Maticsoft.Model.SMT_CTRLR_TASK Task
        {
            get { return _task; }
        }
        public FrmCtrlTaskEditor(Maticsoft.Model.SMT_CTRLR_TASK task=null)
        {
            InitializeComponent();
            _task = task;
        }

        private void FrmCtrlTaskEditor_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            if (_task!=null)
            {
                this.Text = "编辑定时任务";
                tbTaskName.Text = _task.TASK_NAME;
                tbTaskDesc.Text = _task.TASK_DESC;
                tbTaskNum.Text = _task.TASK_NO;
                dtpStartDate.Value = _task.VALID_STARTDATE;
                dtpEndDate.Value = _task.VALID_ENDDATE;
                dtiTime.Value = DateTime.Now.Date + _task.ACTION_TIME;
                if (_task.CTRL_STYLE >= 0 && _task.CTRL_STYLE <= 12)
                {
                    cboCtrlStyle.SelectedIndex = _task.CTRL_STYLE;
                }
                cbWeek1.Checked = _task.MON_STATE;
                cbWeek2.Checked = _task.TUE_STATE;
                cbWeek3.Checked = _task.THI_STATE;
                cbWeek4.Checked = _task.WES_STATE;
                cbWeek5.Checked = _task.FRI_STATE;
                cbWeek6.Checked = _task.SAT_STATE;
                cbWeek7.Checked = _task.SUN_STATE;
            }
            else
            {
                this.Text = "添加定时任务";
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                var doors = DoorDataHelper.GetDoors();
                var areas = AreaDataHelper.GetAreas();

                this.Invoke(new Action(() =>
                {
                    var doorNodes = DoorDataHelper.ToTree(areas, doors);
                    //cboDoorTree.Nodes.Add(new Node("--所有门禁--"));
                    doorTree.Nodes.Clear();
                    doorTree.Nodes.AddRange(doorNodes.ToArray());

                    if (_task!=null&&doorTree.Nodes.Count>0)
                    {
                        if (!string.IsNullOrWhiteSpace(_task.DOOR_ID))
                        {
                            if (_task.DOOR_ID == "-1")
                            {
                                doorTree.Nodes[0].Checked = true;
                            }
                            else
                            {
                                string[] doorIds = _task.DOOR_ID.Split(',');
                                List<decimal> doorIdd = new List<decimal>();
                                foreach (var id in doorIds)
                                {
                                    decimal dd;
                                    if(decimal.TryParse(id,out dd))
                                    {
                                        doorIdd.Add(decimal.Parse(id));
                                    }
                                }
                                var nodes= doorTree.GetNodeList(typeof(Maticsoft.Model.SMT_DOOR_INFO));
                                foreach (var item in nodes)
                                {
                                    
                                }
                            }
                        }
                    }

                    foreach (Node item in doorTree.Nodes)
                    {
                        item.ExpandAll();
                    }
                }));


            });
            waiting.Show(this, 300);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void doorTree_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            if (e.Action == eTreeAction.Mouse)
            {
                var nodes = doorTree.GetNodeList(true, typeof(Maticsoft.Model.SMT_DOOR_INFO));
                string str = "";
                foreach (var item in nodes)
                {
                    Maticsoft.Model.SMT_DOOR_INFO door = (Maticsoft.Model.SMT_DOOR_INFO)item.Tag;
                    str += door.DOOR_NAME + "；";
                }
                tbDoorDropDown.Text = str;
            }
        }
    }
}
