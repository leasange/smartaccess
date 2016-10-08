using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;
using SmartAccess.Common.Datas;

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
            Init();
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
                    Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
                    foreach (var item in models)
                    {
                        if (item.DOOR_ID=="-1")
                        {
                            item.DOOR_NAMES = "所有门禁";
                        }
                        else
                        {
                            try
                            {
                                var doors = doorBll.GetModelList("ID in (" + item.DOOR_ID + ")");
                                foreach (var d in doors)
                                {
                                    item.DOOR_NAMES += d.DOOR_NAME + "；";
                                }
                            }
                            catch (Exception ex)
                            {
                                log.Error("出现异常：", ex);
                                item.DOOR_NAMES = item.DOOR_ID;
                            }

                        }
                        this.Invoke(new Action(() =>
                        {
                            AddData(item);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    log.Error("加载列表异常：" + ex.Message);
                    WinInfoHelper.ShowInfoWindow(this, "加载列表异常：" + ex.Message);
                }

            });
            waiting.Show(this,300);
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
                info.DOOR_NAMES,//
                info.STR_CTRL_STYLE,//
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
            if (taskEditor.ShowDialog(this) == DialogResult.OK)
            {
                AddData(taskEditor.Task);
            }
        }
        private void biModify_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                FrmCtrlTaskEditor taskEditor = new FrmCtrlTaskEditor((Maticsoft.Model.SMT_CTRLR_TASK)dgvData.SelectedRows[0].Tag);
                if (taskEditor.ShowDialog(this) == DialogResult.OK)
                {
                    DataGridViewRow row = dgvData.SelectedRows[0];
                    var info = taskEditor.Task;
                    row.Cells[0].Value = info.TASK_NO;
                    row.Cells[1].Value = info.TASK_NAME;
                    row.Cells[2].Value = info.VALID_STARTDATE.Date;
                    row.Cells[3].Value = info.VALID_ENDDATE.Date;
                    row.Cells[4].Value = info.ACTION_TIME;
                    row.Cells[5].Value = info.MON_STATE;
                    row.Cells[6].Value = info.TUE_STATE;
                    row.Cells[7].Value = info.THI_STATE;
                    row.Cells[8].Value = info.WES_STATE;
                    row.Cells[9].Value = info.FRI_STATE;
                    row.Cells[10].Value = info.SAT_STATE;
                    row.Cells[11].Value = info.SUN_STATE;
                    row.Cells[12].Value = info.DOOR_NAMES;//
                    row.Cells[13].Value = info.STR_CTRL_STYLE;//
                    row.Cells[14].Value = info.TASK_DESC;
                }
            }
            else
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择一条任务修改！");
            }
        }

        private void biDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确定删除选择任务？","提示",MessageBoxButtons.OKCancel)==DialogResult.Cancel)
                {
                    return;
                }
                List<Maticsoft.Model.SMT_CTRLR_TASK> tasks = new List<Maticsoft.Model.SMT_CTRLR_TASK>();
                List<DataGridViewRow> rows = new List<DataGridViewRow>();
                foreach (DataGridViewRow item in dgvData.SelectedRows)
                {
                    tasks.Add((Maticsoft.Model.SMT_CTRLR_TASK)item.Tag);
                    rows.Add(item);
                }
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        Maticsoft.BLL.SMT_CTRLR_TASK taskBll = new Maticsoft.BLL.SMT_CTRLR_TASK();
                        string ids = "";
                        foreach (var item in tasks)
                        {
                            ids += item.ID + ",";
                        }
                        ids = ids.TrimEnd(',');
                        taskBll.DeleteList(ids);
                        this.Invoke(new Action(() =>
                        {
                            foreach (var item in rows)
                            {
                                dgvData.Rows.Remove(item);
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        log.Error("删除任务异常：", ex);
                        WinInfoHelper.ShowInfoWindow(this, "删除任务异常！" + ex.Message);
                    }
                });
                waiting.Show(this);
            }
        }

        private void biView_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                FrmCtrlTaskEditor taskEditor = new FrmCtrlTaskEditor((Maticsoft.Model.SMT_CTRLR_TASK)dgvData.SelectedRows[0].Tag,true);
                taskEditor.ShowDialog(this);
            }
        }

        private void biUpload_Click(object sender, EventArgs e)
        {
            List<Maticsoft.Model.SMT_CTRLR_TASK> tasks = new List<Maticsoft.Model.SMT_CTRLR_TASK>();
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                tasks.Add((Maticsoft.Model.SMT_CTRLR_TASK)row.Tag);
            }
            if (tasks.Count == 0)
            {
                WinInfoHelper.ShowInfoWindow(this, "没有定时任务待上传！");
                return;
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    UploadPrivate.UploadTimeTasks(tasks);
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "上传定时任务发生异常："+ex.Message);
                    log.Error("上传定时任务发生异常：", ex);
                }
                
            });
            waiting.Show(this);
        }

        private void dgvData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                FrmCtrlTaskEditor taskEditor = new FrmCtrlTaskEditor((Maticsoft.Model.SMT_CTRLR_TASK)dgvData.Rows[e.RowIndex].Tag, true);
                taskEditor.ShowDialog(this);
            }
        }
    }
}
