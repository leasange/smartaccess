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

namespace SmartAccess.VerInfoMgr
{
    public partial class FrmAddOrModifyDept : DevComponents.DotNetBar.Office2007Form
    {
        private Maticsoft.Model.SMT_ORG_INFO _orgInfo = null;
        private decimal _parId = -1;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmAddOrModifyDept));
        public Maticsoft.Model.SMT_ORG_INFO OrgInfo
        {
            get { return _orgInfo; }
        }
        public FrmAddOrModifyDept(decimal parId)
        {
            InitializeComponent();
            this.Text = "添加部门";
            _parId = parId;
        }
        public FrmAddOrModifyDept(Maticsoft.Model.SMT_ORG_INFO orgInfo)
        {
            InitializeComponent();
            _orgInfo = orgInfo;
            this.Text = "修改部门:"+orgInfo.ORG_NAME;
            tbDeptNo.Text = orgInfo.ORG_CODE;
            tbDeptName.Text = orgInfo.ORG_NAME;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbDeptNo.Text))
            {
                WinInfoHelper.ShowInfoWindow(this, "部门编码不能为空！");
                tbDeptNo.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(tbDeptName.Text))
            {
                WinInfoHelper.ShowInfoWindow(this, "部门名称不能为空！");
                tbDeptName.Focus();
                return;
            }
            Maticsoft.Model.SMT_ORG_INFO info = new Maticsoft.Model.SMT_ORG_INFO();
            info.ORG_CODE = tbDeptNo.Text.Trim();
            info.ORG_NAME = tbDeptName.Text.Trim();
            Maticsoft.BLL.SMT_ORG_INFO bll = new Maticsoft.BLL.SMT_ORG_INFO();
            CtrlWaiting ctrlWaiting = new CtrlWaiting(() =>
            {
                bool ret = false;
                try
                {
                    if (_orgInfo == null)
                    {
                        info.ORDER_VALUE = 100;
                        info.PAR_ID = _parId;
                        DeptDataHelper.AddDept(info);
                        _orgInfo = info;
                        ret = true;
                    }
                    else
                    {
                        info.ID = _orgInfo.ID;
                        info.PAR_ID = _orgInfo.PAR_ID;
                        info.ORDER_VALUE = _orgInfo.ORDER_VALUE;
                        if (bll.Update(info))
                        {
                            _orgInfo.ORG_CODE = info.ORG_CODE;
                            _orgInfo.ORG_NAME = info.ORG_NAME;
                            ret = true;
                        }
                        else
                        {
                            WinInfoHelper.ShowInfoWindow(this, "更新部门失败,可能部门已被删除！");
                        }
                    }
                    if (ret)
                    {
                        this.Invoke(new Action(() =>
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }));
                    }
                }
                catch (Exception ex)
                {
                    log.Error("添加或保修改部门:", ex);
                    WinInfoHelper.ShowInfoWindow(this, "添加或修改部门失败：" + ex.Message);
                }
            });
            ctrlWaiting.Show(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
