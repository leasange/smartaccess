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
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmCtrlTaskEditor));
        private Maticsoft.Model.SMT_CTRLR_TASK _task = null;
        private bool _isview = false;
        public Maticsoft.Model.SMT_CTRLR_TASK Task
        {
            get { return _task; }
        }
        public FrmCtrlTaskEditor(Maticsoft.Model.SMT_CTRLR_TASK task=null,bool isview=false)
        {
            InitializeComponent();
            _task = task;
            _isview = isview;
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
                if (_isview)
                {
                    tbTaskName.ReadOnly = true;
                    this.Text = "查看定时任务";
                    tbTaskDesc.ReadOnly = true;
                    tbTaskNum.ReadOnly = true;
                    dtpStartDate.Enabled = false;
                    dtpEndDate.Enabled = false;
                    dtiTime.Enabled = false;
                    cboCtrlStyle.Enabled = false;
                    cbWeek1.Enabled = false;
                    cbWeek2.Enabled = false;
                    cbWeek3.Enabled = false;
                    cbWeek4.Enabled = false;
                    cbWeek5.Enabled = false;
                    cbWeek6.Enabled = false;
                    cbWeek7.Enabled = false;
                    btnOk.Visible = false;
                    btnCancel.Text = "关闭";
                }
            }
            else
            {
                this.Text = "添加定时任务";
                cboCtrlStyle.SelectedIndex = 0;
                dtiTime.Value = DateTime.Now;
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
                                doorTree.SetAllCheckState(true);
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
                                    if (doorIdd.Contains(((Maticsoft.Model.SMT_DOOR_INFO)item.Tag).ID))
                                    {
                                        item.Checked = true;
                                    }
                                }

                            }
                            ShowDoorText();
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
            if (_isview)
            {
                this.Close();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbTaskName.Text))
            {
                WinInfoHelper.ShowInfoWindow(this, "任务名称不能为空！");
                return;
            }
            string doorId = "-1";
            if (doorTree.Nodes[0].CheckState!= CheckState.Checked)
            {
                doorId = "";
                var nodes = doorTree.GetNodeList(true, typeof(Maticsoft.Model.SMT_DOOR_INFO));
                if (nodes.Count==0)
                {
                    WinInfoHelper.ShowInfoWindow(this, "未选择门禁！");
                    return;
                }
                foreach (var item in nodes)
                {
                    doorId += ((Maticsoft.Model.SMT_DOOR_INFO)item.Tag).ID+",";
                }
                doorId = doorId.TrimEnd(',');
            }
            if (_task==null)
            {
                _task = new Maticsoft.Model.SMT_CTRLR_TASK();
                _task.ID = -1;
            }
            _task.DOOR_ID = doorId;
            _task.TASK_NO = tbTaskNum.Text.Trim();
            _task.TASK_NAME = tbTaskName.Text.Trim();
            _task.TASK_DESC = tbTaskDesc.Text;
            _task.VALID_STARTDATE = dtpStartDate.Value.Date;
            _task.VALID_ENDDATE = dtpEndDate.Value.Date;
            _task.ACTION_TIME = new TimeSpan(dtiTime.Value.Hour, dtiTime.Value.Minute, dtiTime.Value.Second);
            _task.CTRL_STYLE = cboCtrlStyle.SelectedIndex;
            _task.MON_STATE = cbWeek1.Checked;
            _task.TUE_STATE = cbWeek2.Checked;
            _task.THI_STATE = cbWeek3.Checked;
            _task.WES_STATE = cbWeek4.Checked;
            _task.FRI_STATE = cbWeek5.Checked;
            _task.SAT_STATE = cbWeek6.Checked;
            _task.SUN_STATE = cbWeek7.Checked;
            _task.DOOR_NAMES = tbDoorDropDown.Text;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_CTRLR_TASK taskBll = new Maticsoft.BLL.SMT_CTRLR_TASK();
                    if (_task.ID == -1)
                    {
                        _task.ID = taskBll.Add(_task);
                    }
                    else
                    {
                        taskBll.Update(_task);
                    }
                    this.BeginInvoke(new Action(() =>
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }));
                }
                catch (Exception ex)
                {
                    log.Error("保存异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "保存任务异常：" + ex.Message);
                }
               
            });
            waiting.Show(this);
        }
        private void ShowDoorText()
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
        private void doorTree_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            if (e.Action == eTreeAction.Mouse)
            {
                ShowDoorText();
            }
        }
    }
}
