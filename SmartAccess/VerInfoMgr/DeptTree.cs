using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Li.Controls;

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
    }
}
