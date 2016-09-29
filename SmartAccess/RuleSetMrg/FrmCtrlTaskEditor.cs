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
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

    }
}
