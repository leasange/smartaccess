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
        private bool _isLoaded = false;
        private decimal _visibleId = -1;
        public event EventHandler TreeLoaded = null;
        public AdvTreeEx Tree
        {
            get {
                return this.deptAdvTree;
            }
        }
        public bool IsLoaded
        {
            get
            {
                return _isLoaded;
            }
        }
        public DeptTree()
        {
            InitializeComponent();
            deptAdvTree.PathSeparator = "/";

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
                        _isLoaded = true;
                        if (_visibleId >= 0)
                        {
                            var node = FindNode(_visibleId);

                            if (node != null)
                            {
                                deptAdvTree.SelectedNode = node;
                                if (node.Parent != null)
                                {
                                    node.Parent.Expand();
                                    node.EnsureVisible();
                                }
                            }
                        }

                        if (TreeLoaded!=null)
                        {
                            TreeLoaded.BeginInvoke(this, new EventArgs(), null,null);
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

        public DevComponents.AdvTree.Node FindNode(decimal id)
        {
            return DoFindNode(deptAdvTree.Nodes, id);
        }
        private DevComponents.AdvTree.Node DoFindNode(DevComponents.AdvTree.NodeCollection nodes, decimal id)
        {
            foreach (DevComponents.AdvTree.Node item in nodes)
            {
                var dept = (Maticsoft.Model.SMT_ORG_INFO)item.Tag;
                if (dept.ID == id)
                {
                    return item;
                }
                else
                {
                    var nn = DoFindNode(item.Nodes, id);
                    if (nn!=null)
                    {
                        return nn;
                    }
                }
            }
            return null;
        }

        public void EnsureVisible(decimal id)
        {
            _visibleId = id;
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            deptAdvTree.Nodes.Clear();
            LoadTree();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            CommonClass.FilterTree(deptAdvTree, tbFilter.Text.Trim());
        }
    }
}
