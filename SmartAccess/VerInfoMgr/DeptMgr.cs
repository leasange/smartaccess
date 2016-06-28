using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.VerInfoMgr
{
    /// <summary>
    /// 证件编码
    /// </summary>
    public partial class DeptMgr : UserControl
    {
        public DeptMgr()
        {
            InitializeComponent();
            this.deptTree.Tree.NodeMouseUp += deptTree_NodeMouseUp;
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
        }

        private void deptTree_NodeMouseUp(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Right)
            {
                ctxMenu.Show(Cursor.Position);
            }
        }
    }
}
