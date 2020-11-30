using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.RealDetectMgr
{
    public partial class FrmMultiFaceVideo : DevComponents.DotNetBar.Office2007Form
    {
        private static FrmMultiFaceVideo _instance=null;
        public static FrmMultiFaceVideo Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new FrmMultiFaceVideo();
                }
                if (!_instance.Visible)
                {
                    _instance.Show(FrmMain.Instance);
                }
                return _instance;
            }
        }
        public FrmMultiFaceVideo()
        {
            InitializeComponent();
        }

        private void FrmMultiFaceVideo_FormClosed(object sender, FormClosedEventArgs e)
        {
            multiVideoCtrl.CloseAll();
        }

        public void PlayVideos(List<SMT_FACERECG_DEVICE> faceDevs)
        {
            //throw new NotImplementedException();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            multiVideoCtrl.MultiVideoType = MultiVideoType.One;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            multiVideoCtrl.MultiVideoType = MultiVideoType.Four;
        }
    }
}
