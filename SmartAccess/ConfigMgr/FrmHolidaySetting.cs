using SmartAccess.Common;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ConfigMgr
{
    public partial class FrmHolidaySetting : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmHolidaySetting));
        public FrmHolidaySetting()
        {
            InitializeComponent();
        }

        private void FrmHolidaySetting_Load(object sender, EventArgs e)
        {
            cboHolidayType.SelectedIndex = 0;
            dtpEndDate.Value = DateTime.Now.AddDays(1);
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                Maticsoft.BLL.SMT_WEEKEX_INFO weekBll = new Maticsoft.BLL.SMT_WEEKEX_INFO();
                var models = weekBll.GetModelList("");
                this.Invoke(new Action(() =>
                {
                    foreach (var item in models)
                    {
                        AddToGrid(item);
                    }
                }));
            });
            waiting.Show(this);
        }
        private void AddToGrid(Maticsoft.Model.SMT_WEEKEX_INFO info)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvData,
                info.WEEKEX_ON_DUTY ? "上班[允许开门]" : "假期[不能开门]",
                info.WEEKEX_START_DATE,
                info.WEEKEX_END_DATE,
                info.WEEKEX_DESC,
                "删除"
                );
            row.Tag = info;
            dgvData.Rows.Add(row);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime dtStart = DateTime.Parse(dtpStartDate.Value.ToString("yyyy-MM-dd HH:mm:00"));
            DateTime dtEnd = DateTime.Parse(dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:00"));
            if (dtStart > dtEnd)
            {
                WinInfoHelper.ShowInfoWindow(this, "开始时间大于结束时间！");
                return;
            }
            Maticsoft.Model.SMT_WEEKEX_INFO info = new Maticsoft.Model.SMT_WEEKEX_INFO();
            info.WEEKEX_ON_DUTY = cboHolidayType.SelectedIndex == 1;
            info.WEEKEX_START_DATE = dtStart;
            info.WEEKEX_END_DATE = dtEnd;
            info.WEEKEX_DESC = tbDesc.Text.Trim();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_WEEKEX_INFO wbll = new Maticsoft.BLL.SMT_WEEKEX_INFO();
                    info.ID = wbll.Add(info);
                    SmtLog.InfoFormat("设置", "添加假期约束：{0},开始时间：{1},结束时间：{2},描述：{3}", info.WEEKEX_ON_DUTY ? "上班[允许开门]" : "假期[不能开门]", info.WEEKEX_START_DATE, info.WEEKEX_END_DATE, info.WEEKEX_DESC);
                    this.Invoke(new Action(() =>
                    {
                        AddToGrid(info);
                    }));
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "添加假期约束异常：" + ex.Message);
                    log.Error("添加假期约束异常：", ex);
                }
            });
            waiting.Show(this);
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex>=0&&e.RowIndex>=0)
            {
                if (dgvData.Columns[e.ColumnIndex].Name=="ColDelete")
                {
                    Maticsoft.Model.SMT_WEEKEX_INFO info = (Maticsoft.Model.SMT_WEEKEX_INFO)dgvData.Rows[e.RowIndex].Tag;
                    if (MessageBox.Show("确定删除该假期约束？","提示",MessageBoxButtons.OKCancel)==DialogResult.OK)
                    {
                        CtrlWaiting waiting = new CtrlWaiting(() =>
                        {
                            try
                            {
                                Maticsoft.BLL.SMT_WEEKEX_INFO wbll = new Maticsoft.BLL.SMT_WEEKEX_INFO();
                                wbll.Delete(info.ID);
                                SmtLog.InfoFormat("设置", "删除假期约束：{0},开始时间：{1},结束时间：{2},描述：{3}", info.WEEKEX_ON_DUTY ? "上班[允许开门]" : "假期[不能开门]", info.WEEKEX_START_DATE, info.WEEKEX_END_DATE, info.WEEKEX_DESC);
                                this.Invoke(new Action(() =>
                                {
                                    dgvData.Rows.Remove(dgvData.Rows[e.RowIndex]);
                                }));
                            }
                            catch (System.Exception ex)
                            {
                                WinInfoHelper.ShowInfoWindow(this, "删除假期约束异常：" + ex.Message);
                                log.Error("删除假期约束异常：", ex);
                            }
                        });
                        waiting.Show(this);
                    }
                }
            }
        }
    }
}
