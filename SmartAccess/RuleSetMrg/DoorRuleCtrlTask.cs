using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;

namespace SmartAccess.RuleSetMrg
{
    public partial class DoorRuleCtrlTask : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(DoorRuleCtrlTask));
        public DoorRuleCtrlTask()
        {
            InitializeComponent();
        }
        //加载
        private void DoorRuleCtrlTask_Load(object sender, EventArgs e)
        {

        }
        private void Init()
        {
            this.dgvData.Rows.Clear();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_CTRLR_TASK tsBll = new Maticsoft.BLL.SMT_CTRLR_TASK();
                    var models = tsBll.GetModelList("");
                    this.Invoke(new Action(() =>
                    {
                        foreach (var item in models)
                        {
                            AddData(item);
                        }
                    }));
                }
                catch (Exception ex)
                {
                    log.Error("加载列表异常：" + ex.Message);
                    WinInfoHelper.ShowInfoWindow(this, "加载列表异常：" + ex.Message);
                }

            });
            waiting.Show(this);
        }
        private void AddData(Maticsoft.Model.SMT_CTRLR_TASK info)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvData,
                info.TASK_NO,
                info.TASK_NAME,
                info.VALID_STARTDATE.Date,
                info.VALID_ENDDATE.Date,
                info.ACTION_TIME,
                info.MON_STATE,
                info.TUE_STATE,
                info.THI_STATE,
                info.WES_STATE,
                info.FRI_STATE,
                info.SAT_STATE,
                info.SUN_STATE,
                info.DOOR_ID,//
                info.CTRL_STYLE,//
                info.TASK_DESC
                );
            row.Tag = info;
            dgvData.Rows.Add(row);
        }
        //刷新
        private void biRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }
        //新建
        private void biNew_Click(object sender, EventArgs e)
        {
            FrmCtrlTaskEditor taskEditor = new FrmCtrlTaskEditor();
            if(taskEditor.ShowDialog(this)==DialogResult.OK)
            {

            }
        }

    }
}
