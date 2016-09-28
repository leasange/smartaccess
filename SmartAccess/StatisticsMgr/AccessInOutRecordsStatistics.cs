using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;
using SmartAccess.Common.Datas;
using DevComponents.AdvTree;

namespace SmartAccess.StatisticsMgr
{
    public partial class AccessInOutRecordsStatistics : UserControl
    {
        public AccessInOutRecordsStatistics()
        {
            InitializeComponent();
        }

        private void AccessInOutRecordsStatistics_Load(object sender, EventArgs e)
        {
            Init();
        }
        private void Init()
        {
            dtpStart.Value = DateTime.Now.Date;
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                var doors = DoorDataHelper.GetDoors();
                var areas = AreaDataHelper.GetAreas();

                this.Invoke(new Action(() =>
                {
                    var doorNodes = DoorDataHelper.ToTree(areas, doors);

                    cboDoorTree.Nodes.AddRange(doorNodes.ToArray());

                    foreach (Node item in cboDoorTree.Nodes)
                    {
                        item.ExpandAll();
                    }
                }));


            });
            waiting.Show(this, 300);
        }
    }
}
