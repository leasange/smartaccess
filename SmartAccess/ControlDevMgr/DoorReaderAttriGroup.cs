using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ControlDevMgr
{
    public partial class DoorReaderAttriGroup : UserControl
    {
        public DoorReaderAttriGroup()
        {
            InitializeComponent();
        }
        public void SetDatas(List<DoorReaderAttriData> datas)
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                DoorReaderAttri doorAttri = (DoorReaderAttri)this.Controls[i];
                if (this.Controls.Count - 1 - i < datas.Count)
                {
                    doorAttri.Data = datas[this.Controls.Count - 1 - i];
                    doorAttri.Visible = true;
                    doorAttri.Tag = 1;
                }
                else
                {
                    doorAttri.Visible = false;
                    doorAttri.Tag = 0;
                }
            }
        }
        public List<DoorReaderAttriData> GetDatas()
        {
            List<DoorReaderAttriData> datas = new List<DoorReaderAttriData>();
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                DoorReaderAttri doorAttri = (DoorReaderAttri)this.Controls[i];
                if (doorAttri.Tag != null && (int)doorAttri.Tag==1)
                {
                    DoorReaderAttriData data = doorAttri.Data;
                    datas.Add(data);
                }
            }
            return datas;
        }
    }
    public class DoorReaderAttriData
    {
        public int doorNo = 1;
        public bool isEnter1 = true;
        public bool isNoEnter = true;
        public bool isEnter = true;
        public bool isAttend = false;
    }
}
