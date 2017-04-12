using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;
///
///黑名单管理
///
namespace SmartAccess.ConfigMgr
{
    public partial class FaceBlackListMgr : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FaceBlackListMgr));
        public FaceBlackListMgr()
        {
            InitializeComponent();
        }

        private void FaceBlackListMgr_Load(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.IMS_FACE_BLACKLIST blBll = new Maticsoft.BLL.IMS_FACE_BLACKLIST();
                    var models = blBll.GetModelList("");
                    this.Invoke(new Action(() =>
                    {
                        listFaces.Items.Clear();
                        foreach (var item in models)
                        {
                            ListViewItem lvi = new ListViewItem(item.Name);
                            lvi.Tag = item;
                            lvi.ImageKey = "loading";
                            listFaces.Items.Add(lvi);
                        }
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载人脸黑名单异常：" + ex.Message);
                    log.Error("加载人脸黑名单异常", ex);
                }
            });
            waiting.Show(this);
        }
        private void biAdd_Click(object sender, EventArgs e)
        {

        }

    }
}
