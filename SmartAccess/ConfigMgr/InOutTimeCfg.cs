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
using System.Threading;
using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using SmartAccess.Common;

namespace SmartAccess.ConfigMgr
{
    public partial class InOutTimeCfg : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(InOutTimeCfg));
        public InOutTimeCfg()
        {
            InitializeComponent();
        }
        

        private void biNew_Click(object sender, EventArgs e)
        {
            FrmInOutTimeEditor editor = new FrmInOutTimeEditor();
            if (editor.ShowDialog(this)==DialogResult.OK)
            {
                AddData(editor.TimeScaleInfo);
            }
        }

        private void biModify_Click(object sender, EventArgs e)
        {
            if(dgvData.SelectedRows.Count>0)
            {
                DataGridViewRow row=dgvData.SelectedRows[0];
                FrmInOutTimeEditor editor = new FrmInOutTimeEditor((Maticsoft.Model.SMT_TIMESCALE_INFO)row.Tag);
                if (editor.ShowDialog(this) == DialogResult.OK)
                {
                    var info = editor.TimeScaleInfo;
                    row.Cells[0].Value = info.TIME_NO;
                    row.Cells[1].Value = info.TIME_NAME;
                    row.Cells[2].Value = info.TIME_WEEK_DAY1;
                    row.Cells[3].Value = info.TIME_WEEK_DAY2;
                    row.Cells[4].Value = info.TIME_WEEK_DAY3;
                    row.Cells[5].Value = info.TIME_WEEK_DAY4;
                    row.Cells[6].Value = info.TIME_WEEK_DAY5;
                    row.Cells[7].Value = info.TIME_WEEK_DAY6;
                    row.Cells[8].Value = info.TIME_WEEK_DAY7;
                    row.Cells[9].Value = info.TIME_RANGE_START1;
                    row.Cells[10].Value = info.TIME_RANGE_END1;
                    row.Cells[11].Value = info.TIME_RANGE_START2;
                    row.Cells[12].Value = info.TIME_RANGE_END2;
                    row.Cells[13].Value = info.TIME_RANGE_START3;
                    row.Cells[14].Value = info.TIME_RANGE_END3;
                    row.Cells[15].Value = info.TIME_NEXT_NO;
                    row.Cells[16].Value = info.TIME_DATE_START.Date.ToString("yyyy-MM-dd");
                    row.Cells[17].Value = info.TIME_DATE_END.ToString("yyyy-MM-dd");
                }
            }
            else
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择编辑对象！");
            }
        }

        private void biWeekEX_Click(object sender, EventArgs e)
        {
            FrmHolidaySetting setting = new FrmHolidaySetting();
            setting.ShowDialog(this);
        }

        private void InOutTimeCfg_Load(object sender, EventArgs e)
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
                    Maticsoft.BLL.SMT_TIMESCALE_INFO tsBll = new Maticsoft.BLL.SMT_TIMESCALE_INFO();
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
                    log.Error("加载列表异常："+ex.Message);
                    WinInfoHelper.ShowInfoWindow(this, "加载列表异常：" + ex.Message);
                }
               
            });
            waiting.Show(this);
        }
        private void AddData(Maticsoft.Model.SMT_TIMESCALE_INFO info)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvData,
                info.TIME_NO,
                info.TIME_NAME,
                info.TIME_WEEK_DAY1,
                info.TIME_WEEK_DAY2,
                info.TIME_WEEK_DAY3,
                info.TIME_WEEK_DAY4,
                info.TIME_WEEK_DAY5,
                info.TIME_WEEK_DAY6,
                info.TIME_WEEK_DAY7,
                info.TIME_RANGE_START1,
                info.TIME_RANGE_END1,
                info.TIME_RANGE_START2,
                info.TIME_RANGE_END2,
                info.TIME_RANGE_START3,
                info.TIME_RANGE_END3,
                info.TIME_NEXT_NO,
                info.TIME_DATE_START.Date.ToString("yyyy-MM-dd"),
                info.TIME_DATE_END.ToString("yyyy-MM-dd")
                );
            row.Tag = info;
            dgvData.Rows.Add(row);
        }

        private void biDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("确定删除选择对象？","提示",MessageBoxButtons.OKCancel)== DialogResult.OK)
                {
                    List<Maticsoft.Model.SMT_TIMESCALE_INFO> mscs=new List<Maticsoft.Model.SMT_TIMESCALE_INFO>();
                    List<DataGridViewRow> rows = new List<DataGridViewRow>();
                    foreach (DataGridViewRow item in dgvData.SelectedRows)
	                {
                        mscs.Add((Maticsoft.Model.SMT_TIMESCALE_INFO)item.Tag);
                        rows.Add(item);
	                }
                    CtrlWaiting waiting = new CtrlWaiting(() =>
                    {
                        try
                        {
                            Maticsoft.BLL.SMT_TIMESCALE_INFO scBll = new Maticsoft.BLL.SMT_TIMESCALE_INFO();
                            foreach (var item in mscs)
                            {
                                scBll.Delete(item.ID);
                                SmtLog.InfoFormat("配置", "删除定时任务，编号：{0},名称：{1}", item.TIME_NO, item.TIME_NAME);
                            }
                            this.Invoke(new Action(() =>
                            {
                                foreach (var item in rows)
                                {
                                    dgvData.Rows.Remove(item);
                                }
                                DoUpload();
                            }));
                        }
                        catch (Exception ex)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "删除对象异常：" + ex.Message);
                            log.Error("删除对象异常：", ex);
                        }

                    });
                    waiting.Show(this);
                }
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            biModify_Click(sender, e);
        }

        private void biRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void biView_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvData.SelectedRows[0];
                FrmInOutTimeEditor editor = new FrmInOutTimeEditor((Maticsoft.Model.SMT_TIMESCALE_INFO)row.Tag, true);
                editor.ShowDialog(this);
            }
            else 
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择查看的时区！");
            }
        }
        private void DoUpload()
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                var ctrls = ControllerHelper.GetList("1=1");
                if (ctrls.Count == 0)
                {
                    WinInfoHelper.ShowInfoWindow(this, "没有控制器！");
                    return;
                }
                Maticsoft.BLL.SMT_TIMESCALE_INFO tsBll = new Maticsoft.BLL.SMT_TIMESCALE_INFO();
                var models = tsBll.GetModelList("");
                Maticsoft.BLL.SMT_WEEKEX_INFO wbll = new Maticsoft.BLL.SMT_WEEKEX_INFO();
                var weekexs = wbll.GetModelList("");

                SmtLog.Info("设置", "上传时间段设置");
                FrmDetailInfo.Show(false);
                FrmDetailInfo.AddOneMsg(string.Format("开始上传控制器时段：控制器数={0},时段数={1} ...", ctrls.Count, models.Count));
                List<ManualResetEvent> eventList = new List<ManualResetEvent>();
                foreach (var item in ctrls)
                {
                    ManualResetEvent evt = new ManualResetEvent(false);
                    eventList.Add(evt);
                    ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                    {
                        try
                        {
                            var ctrl = ControllerHelper.ToController(item);
                            using (IAccessCore acc = new WGAccess())
                            {
                                if (acc.ClearTimeScales(ctrl))
                                {
                                    FrmDetailInfo.AddOneMsg(string.Format("清除控制器时间段成功：SN={0},IP={1}，开始上传控制器时间段...", ctrl.sn, ctrl.ip));
                                    foreach (var model in models)
                                    {
                                        var m = TimeScaleHelper.ToTimeScale(model);
                                        bool ret = acc.SetTimeScales(ctrl, m);
                                        if (!ret)
                                        {
                                            FrmDetailInfo.AddOneMsg(string.Format("上传控制器时间段失败：时段号={0},控制器IP={1}", model.TIME_NO, ctrl.ip), isRed: true);
                                        }
                                        else
                                        {
                                            FrmDetailInfo.AddOneMsg(string.Format("上传控制器时间段成功：时段号={0},控制器IP={1}", model.TIME_NO, ctrl.ip));
                                        }
                                    }
                                }
                                else
                                {
                                    FrmDetailInfo.AddOneMsg(string.Format("清除控制器时间段失败：SN={0},IP={1}，结束该控制器上传...", ctrl.sn, ctrl.ip), isRed: true);
                                }

                                if (acc.SetHoliday(ctrl, new HolidayPrm()
                                {
                                    IsClear = true,
                                    startDate = DateTime.Now,
                                    endDate = DateTime.Now.AddDays(1)
                                }))
                                {
                                    FrmDetailInfo.AddOneMsg(string.Format("清除控制器假期约束成功：SN={0},IP={1}，开始上传假期约束...", ctrl.sn, ctrl.ip));
                                    foreach (var w in weekexs)
                                    {
                                        bool ret = acc.SetHoliday(ctrl, new HolidayPrm()
                                        {
                                            IsClear = false,
                                            IsOnDuty = w.WEEKEX_ON_DUTY,
                                            startDate = w.WEEKEX_START_DATE,
                                            endDate = w.WEEKEX_END_DATE
                                        });
                                        if (!ret)
                                        {
                                            FrmDetailInfo.AddOneMsg(string.Format("上传控制器假期约束失败：约束={0},起止时间={1}~{2},控制器IP={3}", w.WEEKEX_ON_DUTY ? "上班" : "假期", w.WEEKEX_START_DATE, w.WEEKEX_END_DATE, ctrl.ip), isRed: true);
                                        }
                                        else
                                        {
                                            FrmDetailInfo.AddOneMsg(string.Format("上传控制器假期约束成功：约束={0},起止时间={1}~{2},控制器IP={3}", w.WEEKEX_ON_DUTY ? "上班" : "假期", w.WEEKEX_START_DATE, w.WEEKEX_END_DATE, ctrl.ip));
                                        }
                                    }
                                }
                                else
                                {
                                    FrmDetailInfo.AddOneMsg(string.Format("清除控制器假期约束失败：SN={0},IP={1}", ctrl.sn, ctrl.ip), isRed: true);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            FrmDetailInfo.AddOneMsg(string.Format("上传控制器时间段失败：SN={0},IP={1}，异常信息：{2},结束该控制器上传...", item.SN_NO, item.IP, ex.Message), isRed: true);
                            log.Error("上传控制器时间段失败，", ex);
                            SmtLog.ErrorFormat("设置", "上传控制器时间段失败：SN={0},IP={1}，异常信息：{2},结束该控制器上传...", item.SN_NO, item.IP, ex.Message);
                        }
                        finally
                        {
                            evt.Set();
                        }
                    }));
                }
                foreach (var item in eventList)
                {
                    item.WaitOne(60000);
                }
                FrmDetailInfo.AddOneMsg("结束控制器时段上传！");
            });
            waiting.Show(this);
        }

        private void biUploadTimeNo_Click(object sender, EventArgs e)
        {
            DoUpload();
        }
    }
}
