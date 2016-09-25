using DevComponents.DotNetBar.Controls;
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
    public partial class FrmInOutTimeEditor : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmInOutTimeEditor));
        private Maticsoft.Model.SMT_TIMESCALE_INFO _timeScaleInfo = null;
        public Maticsoft.Model.SMT_TIMESCALE_INFO TimeScaleInfo
        {
            get { return _timeScaleInfo; }
            set { _timeScaleInfo = value; }
        }
        public FrmInOutTimeEditor(Maticsoft.Model.SMT_TIMESCALE_INFO tsInfo = null, bool isread = false)
        {
            InitializeComponent();
            _timeScaleInfo = tsInfo;
            if (tsInfo != null && isread)
            {
                this.Text = "查看时区信息";
                btnOk.Visible = false;
                btnCancel.Text = "关闭";
                tbName.ReadOnly = true;
                dtpStartDate.IsInputReadOnly = true;
                dtpEndDate.IsInputReadOnly = true;
                cbTimeNo.Enabled = false;
                cbNextTimeNo.Enabled = false;
                foreach (Control item in groupPanel1.Controls)
                {
                    item.Enabled = false;
                }
                foreach (Control item in groupPanel2.Controls)
                {
                    if (item is DevComponents.Editors.DateTimeAdv.DateTimeInput)
                    {
                        ((DevComponents.Editors.DateTimeAdv.DateTimeInput)item).IsInputReadOnly = true;
                    }
                }
            }
            else if (tsInfo != null)
            {
                this.Text = "编辑时区信息";
            }
            else
            {
                this.Text = "新建时区信息";
            }
        }

        private void FrmInOutTimeEditor_Load(object sender, EventArgs e)
        {
            cbNextTimeNo.Items.Add(0);
            cbNextTimeNo.Items.Add(1);
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddDays(30);
            dtiTimeAreaStart1.Value = DateTime.Parse("2016-1-1 00:00:00");
            dtiTimeAreaEnd1.Value = DateTime.Parse("2016-1-1 23:59:59");
            dtiTimeAreaStart2.Value = DateTime.Parse("2016-1-1 00:00:00");
            dtiTimeAreaEnd2.Value = DateTime.Parse("2016-1-1 00:00:00");
            dtiTimeAreaStart3.Value = DateTime.Parse("2016-1-1 00:00:00");
            dtiTimeAreaEnd3.Value = DateTime.Parse("2016-1-1 00:00:00");

            for (int i = 2; i <= 254; i++)
            {
                cbTimeNo.Items.Add(i);
                cbNextTimeNo.Items.Add(i);
            }
            cbNextTimeNo.SelectedItem = 1;
            if (_timeScaleInfo != null)
            {
                tbName.Text = _timeScaleInfo.TIME_NAME;
                dtpStartDate.Value = _timeScaleInfo.TIME_DATE_START;
                dtpEndDate.Value = _timeScaleInfo.TIME_DATE_END;
                if (_timeScaleInfo.TIME_NO >= 2 && _timeScaleInfo.TIME_NO <= 254)
                {
                    cbTimeNo.SelectedItem = _timeScaleInfo.TIME_NO;
                }
                if (_timeScaleInfo.TIME_NEXT_NO >= 0 && _timeScaleInfo.TIME_NEXT_NO <= 254)
                {
                    cbNextTimeNo.SelectedItem = _timeScaleInfo.TIME_NEXT_NO;
                }
                cbWeek1.Checked = _timeScaleInfo.TIME_WEEK_DAY1;
                cbWeek2.Checked = _timeScaleInfo.TIME_WEEK_DAY2;
                cbWeek3.Checked = _timeScaleInfo.TIME_WEEK_DAY3;
                cbWeek4.Checked = _timeScaleInfo.TIME_WEEK_DAY4;
                cbWeek5.Checked = _timeScaleInfo.TIME_WEEK_DAY5;
                cbWeek6.Checked = _timeScaleInfo.TIME_WEEK_DAY6;
                cbWeek7.Checked = _timeScaleInfo.TIME_WEEK_DAY7;

                dtiTimeAreaStart1.Value = DateTime.Now.Date + _timeScaleInfo.TIME_RANGE_START1;
                dtiTimeAreaEnd1.Value = DateTime.Now.Date + _timeScaleInfo.TIME_RANGE_END1;
                dtiTimeAreaStart2.Value = DateTime.Now.Date + _timeScaleInfo.TIME_RANGE_START2;
                dtiTimeAreaEnd2.Value = DateTime.Now.Date + _timeScaleInfo.TIME_RANGE_END2;
                dtiTimeAreaStart3.Value = DateTime.Now.Date + _timeScaleInfo.TIME_RANGE_START3;
                dtiTimeAreaEnd3.Value = DateTime.Now.Date + _timeScaleInfo.TIME_RANGE_END3;
            }
        }

        private bool CheckInput()
        {
            if (cbTimeNo.SelectedItem == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "时区不能为空！");
                return false;
            }
            if (dtpStartDate.ValueObject == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "开始日期不能为空！");
                return false;
            }
            if (dtpEndDate.ValueObject == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "结束日期不能为空！");
                return false;
            }
            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }
            if (_timeScaleInfo == null)
            {
                _timeScaleInfo = new Maticsoft.Model.SMT_TIMESCALE_INFO();
                _timeScaleInfo.ID = -1;
            }
            _timeScaleInfo.TIME_NAME = tbName.Text.Trim();
            _timeScaleInfo.TIME_NO = (int)cbTimeNo.SelectedItem;
            _timeScaleInfo.TIME_NEXT_NO = (int)cbNextTimeNo.SelectedItem;
            _timeScaleInfo.TIME_DATE_START = dtpStartDate.Value.Date;
            _timeScaleInfo.TIME_DATE_END = dtpEndDate.Value.Date;
            _timeScaleInfo.TIME_WEEK_DAY1 = cbWeek1.Checked;
            _timeScaleInfo.TIME_WEEK_DAY2 = cbWeek2.Checked;
            _timeScaleInfo.TIME_WEEK_DAY3 = cbWeek3.Checked;
            _timeScaleInfo.TIME_WEEK_DAY4 = cbWeek4.Checked;
            _timeScaleInfo.TIME_WEEK_DAY5 = cbWeek5.Checked;
            _timeScaleInfo.TIME_WEEK_DAY6 = cbWeek6.Checked;
            _timeScaleInfo.TIME_WEEK_DAY7 = cbWeek7.Checked;
            _timeScaleInfo.TIME_RANGE_START1 = dtiTimeAreaStart1.Value.TimeOfDay;
            _timeScaleInfo.TIME_RANGE_END1 = dtiTimeAreaEnd1.Value.TimeOfDay;
            _timeScaleInfo.TIME_RANGE_START2 = dtiTimeAreaStart2.Value.TimeOfDay;
            _timeScaleInfo.TIME_RANGE_END2 = dtiTimeAreaEnd2.Value.TimeOfDay;
            _timeScaleInfo.TIME_RANGE_START3 = dtiTimeAreaStart3.Value.TimeOfDay;
            _timeScaleInfo.TIME_RANGE_END3 = dtiTimeAreaEnd3.Value.TimeOfDay;
            CtrlWaiting waiting = new CtrlWaiting(() =>
             {
                 try
                 {
                     Maticsoft.BLL.SMT_TIMESCALE_INFO scBll = new Maticsoft.BLL.SMT_TIMESCALE_INFO();
                     if (_timeScaleInfo.ID == -1)
                     {
                         var ss = scBll.GetModelList("TIME_NO=" + _timeScaleInfo.TIME_NO);
                         if (ss.Count > 0)
                         {
                             WinInfoHelper.ShowInfoWindow(this, "已存在同一时区的规则！");
                             return;
                         }
                         _timeScaleInfo.ID = scBll.Add(_timeScaleInfo);
                     }
                     else
                     {
                         scBll.Update(_timeScaleInfo);
                     }
                     this.Invoke(new Action(() =>
                     {
                         this.DialogResult = System.Windows.Forms.DialogResult.OK;
                         this.Close();
                     }));
                 }
                 catch (Exception ex)
                 {
                     WinInfoHelper.ShowInfoWindow(this, "保存异常：" + ex.Message);
                     log.Error("保存异常：", ex);
                 }

             });
            waiting.Show(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
