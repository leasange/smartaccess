using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Li.Controls;
using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;

namespace SmartAccess.VerInfoMgr
{
    public partial class DeptTree : UserControl
    {
        public AdvTreeEx Tree
        {
            get {
                return this.deptAdvTree;
            }
        }
        public DeptTree()
        {
            InitializeComponent();
        }

        private void DeptTree_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                deptAdvTree.Nodes.Clear();
                LoadTree(300);
            }
        }

        private void LoadTree(int minseconds=0)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                var depts = DeptDataHelper.GetDepts(true);
                this.Invoke(new Action(() =>
                {
                    try
                    {
                        deptAdvTree.Nodes.Clear();
                        var nodes = DeptDataHelper.ToTree(depts);
                        deptAdvTree.Nodes.AddRange(nodes.ToArray());
                        foreach (DevComponents.AdvTree.Node item in deptAdvTree.Nodes)
                        {
                            item.Expand();
                        }
                    }
                    catch (Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "加载树异常：" + ex.Message);
                    }
                }));
            });
            waiting.Show(this, minseconds);
        }
        /// <summary>
        /// 刷新树
        /// </summary>
        public void RefreshTree()
        {
            LoadTree(0);
        }
    }
}
