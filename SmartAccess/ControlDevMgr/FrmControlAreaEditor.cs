using SmartAccess.Common;
using SmartAccess.Common.Database;
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

namespace SmartAccess.ControlDevMgr
{
    public partial class FrmControlAreaEditor : DevComponents.DotNetBar.Office2007Form
    {
        public FrmControlAreaEditor()
        {
            InitializeComponent();
        }
        public FrmControlAreaEditor(Maticsoft.Model.SMT_CONTROLLER_ZONE  area)
        {
            InitializeComponent();
            Area = area;
            IsAdd = false;
        }
        public bool IsAdd { get; set; }

        public decimal? ParentAreaID { get; set; }

        public Maticsoft.Model.SMT_CONTROLLER_ZONE Area { get; set; }
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmControlAreaEditor));
        private void FrmControlAreaEditor_Load(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                this.Text = "添加区域";
            }
            else
            {
                this.Text = "修改区域";
                if (Area!=null)
                {
                    tbAreaName.Text = Area.ZONE_NAME;
                    tbAreaDesc.Text = Area.ZONE_DESC;
                }
            }
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAreaName.Text))
	        {
                MessageBox.Show("区域名称不能为空！");
                tbAreaName.Focus();
                return;
	        }
            try
            {
                if (Area==null)
                {
                    Area = new Maticsoft.Model.SMT_CONTROLLER_ZONE();
                    Area.ID = -1;
                    Area.PAR_ID = ParentAreaID == null ? 0 : (decimal)ParentAreaID;
                    Area.ORDER_VALUE = 100;
                }
                Area.ZONE_NAME = tbAreaName.Text.Trim();
                Area.ZONE_DESC = tbAreaDesc.Text.Trim();
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        if (Area.ID == -1)
                        {
                            Area.ID = AreaDataHelper.AddArea(Area);
                            SmtLog.Info("区域", "添加区域：" + Area.ZONE_NAME);
                        }
                        else
                        {
                            AreaDataHelper.UpdateArea(Area);
                            SmtLog.Info("区域", "更新区域：" + Area.ZONE_NAME);
                        }
                        this.BeginInvoke(new Action(() =>
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }));

                    }
                    catch (Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "保存区域异常：" + ex.Message);
                        log.Error("保存区域异常：", ex);
                    }

                });
                waiting.Show(this);
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "保存区域异常：" + ex.Message);
                log.Error("保存区域异常：", ex);
            }

        }
    }
}
