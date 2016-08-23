using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;

namespace SmartAccess.VerInfoMgr
{
    /// <summary>
    /// 证件编码
    /// </summary>
    public partial class VerCodeInfo : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(VerCodeInfo));
        public VerCodeInfo()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbVerName.Text.Trim()=="")
            {
                WinInfoHelper.ShowInfoWindow(this, "证件名称不能为空！");
                tbVerName.Focus();
                return;
            }
            if (cboVerType.SelectedIndex<0)
            {
                WinInfoHelper.ShowInfoWindow(this, "证件类型不能为空！");
                cboVerType.Focus();
                return;
            }
            if (tbVerFormat.Text.Trim()=="")
            {
                WinInfoHelper.ShowInfoWindow(this, "编码格式不能为空！");
                tbVerFormat.Focus();
                return;
            }
            Maticsoft.Model.SMT_VER_FORMAT format = new Maticsoft.Model.SMT_VER_FORMAT()
            {
                VER_FORMAT = tbVerFormat.Text.Trim(),
                VER_NAME = tbVerName.Text.Trim(),
                VER_TYPE = cboVerType.SelectedIndex
            };
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_VER_FORMAT verformat = new Maticsoft.BLL.SMT_VER_FORMAT();
                    format.ID = verformat.Add(format);
                    this.Invoke(new Action(() =>
                    {
                    	DoAddToGrid(format);
                    }));
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "添加失败：" + ex.Message);
                    log.Error("添加失败：", ex);
                }
            });
            waiting.Show(this);
        }

        private void VerCodeInfo_Load(object sender, EventArgs e)
        {
            cboVerType.SelectedIndex = 0;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_VER_FORMAT verformat = new Maticsoft.BLL.SMT_VER_FORMAT();
                    var list = verformat.GetModelList("");
                    this.Invoke(new Action(() =>
                    {
                        foreach (var item in list)
                        {
                            DoAddToGrid(item);
                        }
                    }));
                }
                catch (System.Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载失败：" + ex.Message);
                    log.Error("加载失败：", ex);
                }
            });
            waiting.Show(this,300);
        }
        private void DoAddToGrid(Maticsoft.Model.SMT_VER_FORMAT format)
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            string strType = "其他";
            switch (format.VER_TYPE)
            {
                case 0:
                    strType = "工作证";
                    break;
                case 1:
                    strType = "身份证";
                    break;
                case 2:
                    strType = "驾驶证";
                    break;
                default:
                    break;
            }

            dgvr.CreateCells(dgvData,
                format.VER_NAME,
                strType,
                format.VER_FORMAT,
                "编辑",
                "删除"
                );
            dgvr.Tag = format;
            dgvData.Rows.Add(dgvr);
        }
    }
}
