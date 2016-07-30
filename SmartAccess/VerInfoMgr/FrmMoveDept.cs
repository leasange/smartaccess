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
    public partial class FrmMoveDept : DevComponents.DotNetBar.Office2007Form
    {
        private Maticsoft.Model.SMT_ORG_INFO _info = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmMoveDept));
        public FrmMoveDept(Maticsoft.Model.SMT_ORG_INFO info)
        {
            InitializeComponent();
            _info = info;
            this.Text = "移动部门：" + _info.ORG_NAME;
        }
        private void FrmMoveDept_Load(object sender, EventArgs e)
        {
            try
            {
                var depts = DeptDataHelper.GetDepts();
                var nodes = DeptDataHelper.ToTree(depts);
                comDeptTree.Nodes.AddRange(nodes.ToArray());
                foreach (DevComponents.AdvTree.Node item in comDeptTree.Nodes)
                {
                    item.Expand();
                }
            }
            catch (Exception ex)
            {
                log.Error("加载异常：", ex);
                WinInfoHelper.ShowInfoWindow(this, "加载异常！");
                return;
            }

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            var node = comDeptTree.SelectedNode;
            if (node==null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择要移至的部门！");
                return;
            }
            Maticsoft.Model.SMT_ORG_INFO dept = (Maticsoft.Model.SMT_ORG_INFO)node.Tag;
            if (dept.ID == _info.PAR_ID || dept.ID == _info.ID)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择不同的上级部门！");
                return;
            }
            decimal parId = _info.PAR_ID;
            _info.PAR_ID = dept.ID;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    DeptDataHelper.UpdateDept(_info);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    log.Error("移动部门异常：", ex);
                    _info.PAR_ID = parId;
                    WinInfoHelper.ShowInfoWindow(this, "移动部门异常："+ex.Message);
                }
            });
            waiting.Show(this);
        }
    }
}
