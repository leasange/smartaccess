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
    public partial class DoorNameAttriGroup : UserControl
    {
        public DoorNameAttriGroup()
        {
            InitializeComponent();
        }

        public void SetDatas(List<DoorNameAttriData> datas)
        {
            for (int i = this.Controls.Count-1; i >=0; i--)
            {
                DoorNameAttri doorAttri = (DoorNameAttri)this.Controls[i];
                if (this.Controls.Count-1-i<datas.Count)
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
        public List<DoorNameAttriData> GetDatas()
        {
            List<DoorNameAttriData> datas = new List<DoorNameAttriData>();
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                DoorNameAttri doorAttri = (DoorNameAttri)this.Controls[i];
                if (doorAttri.Tag != null && (int)doorAttri.Tag==1)
                {
                    DoorNameAttriData data = doorAttri.Data;
                    datas.Add(data);
                }
            }
            return datas;
        }
    }

    public class DoorNameAttriData
    {
        public int doorNo = 1;
        public string doorName="";
        public bool doorEnable=true;
        public int doorCtrlType = 0;//0,1,2
        public int doorSecond = 3;
        public bool visitor = true;
    }
}
