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
    public partial class FrmCombineDept : DevComponents.DotNetBar.Office2007Form
    {
        private Maticsoft.Model.SMT_ORG_INFO _info = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmMoveDept));
        public FrmCombineDept(Maticsoft.Model.SMT_ORG_INFO info)
        {
            InitializeComponent();
            _info = info;
            this.Text = "合并部门：" + _info.ORG_NAME;
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
                WinInfoHelper.ShowInfoWindow(this, "请选择部门要合并到的部门！");
                return;
            }
            Maticsoft.Model.SMT_ORG_INFO dept = (Maticsoft.Model.SMT_ORG_INFO)node.Tag;
            if (dept.ID == _info.ID)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择不同的部门！");
                return;
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    int count= Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update SMT_STAFF_INFO set ORG_ID=" + dept.ID + " where ORG_ID=" + _info.ID);
                    DeptDataHelper.DeleteDepts(new List<Maticsoft.Model.SMT_ORG_INFO>() { _info });
                    WinInfoHelper.ShowInfoWindow(null, string.Format("已移动部门“{0}”所有人员：{1}个至部门“{2}”下，并删除部门“{3}”", _info.ORG_NAME, count, dept.ORG_NAME, _info.ORG_NAME));
                    this.DialogResult = DialogResult.OK;
                    this.BeginInvoke(new Action(() =>
                    {
                        this.Close();
                    }));
                }
                catch (Exception ex)
                {
                    log.Error("合并部门异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "合并部门异常：" + ex.Message);
                }
            });
            waiting.Show(this);
        }
    }
}
