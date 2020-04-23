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
    public partial class FrmNewDicData : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmNewDicData));
        private string _dataType = null;
        public Maticsoft.Model.SMT_DATADICTIONARY_INFO DATA_INFO;
        public FrmNewDicData(string dataType)
        {
            InitializeComponent();
            this._dataType = dataType;
        }
        public FrmNewDicData(Maticsoft.Model.SMT_DATADICTIONARY_INFO info)
        {
            InitializeComponent();
            this.DATA_INFO = info;
        }
        private void FrmNewDicData_Load(object sender, EventArgs e)
        {
            if (this._dataType!=null&&this._dataType=="STAFF_TYPE")
            {
                this.Text = "新建人员类型";
                this.cbValue.Visible = false;
                this.tbValue.Visible = true;
                this.tbValue.ReadOnly = true;
            }
            else if (this.DATA_INFO != null && this.DATA_INFO.DATA_TYPE == "STAFF_TYPE")
            {
                this.Text = "修改人员类型";
                this.cbValue.Visible = false;
                this.tbValue.Visible = true;
                this.tbDataKey.ReadOnly = true;
                this.tbValue.Text = this.DATA_INFO.DATA_VALUE;
                this.tbName.Text = this.DATA_INFO.DATA_NAME;
                this.tbDesc.Text = this.DATA_INFO.DATA_CONTENT;
                this.tbValue.ReadOnly = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbDataKey.Text))
            {
                MessageBox.Show("参数标识不能为空！");
                return;
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.Model.SMT_DATADICTIONARY_INFO info = new Maticsoft.Model.SMT_DATADICTIONARY_INFO();
                    if (this.DATA_INFO != null)
                    {
                        info.DATA_TYPE = this.DATA_INFO.DATA_TYPE;
                    }
                    else
                    {
                        info.DATA_TYPE = this._dataType;
                    }
                    info.DATA_KEY = this.tbDataKey.Text.Trim();
                    info.DATA_NAME = this.tbName.Text.Trim();
                    if (info.DATA_TYPE=="STAFF_TYPE")
                    {
                        info.DATA_VALUE = info.DATA_KEY;
                    }
                    else
                    {
                        info.DATA_VALUE = this.tbValue.Text.Trim();
                    }
                    info.DATA_CONTENT = this.tbDesc.Text.Trim();
                    Maticsoft.BLL.SMT_DATADICTIONARY_INFO bll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                    if (this.DATA_INFO != null)
                    {
                        bll.Update(info);
                    }
                    else
                    {
                        bll.Add(info);
                    }
                    this.DialogResult = DialogResult.OK;
                    DATA_INFO = info;
                    this.Close();
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "保存失败：" + ex.Message);
                    log.Error("保存失败", ex);
                }
            });
            waiting.Show(this);
        }
    }
}
