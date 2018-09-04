using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using DevComponents.AdvTree;

namespace SmartAccess.VerInfoMgr
{
    public partial class FaceDevPriMgr : UserControl
    {
        private List<Maticsoft.Model.SMT_FACERECG_DEVICE> _faceDevices = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FaceDevPriMgr));
        public FaceDevPriMgr()
        {
            InitializeComponent();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            CommonClass.FilterTree(advTree, tbFilter.Text.Trim());
        }

        private void FaceDevPriMgr_Load(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_FACERECG_DEVICE faceBll = new Maticsoft.BLL.SMT_FACERECG_DEVICE();
                    _faceDevices = faceBll.GetModelList("");
                    var areas = AreaDataHelper.GetAreas();
                    this.Invoke(new Action(() =>
                    {
                        var nodes = AreaDataHelper.ToTree(areas);
                        var faceDevs=_faceDevices.ToList();
                        foreach (var item in nodes)
	                    {
		                    DoCreateAreaDevice(item,faceDevs);
	                    }

                        for (int i = faceDevs.Count - 1; i >= 0; i--)
                        {
                            var item = faceDevs[i];
                            Node devNode = new Node("<font color='blue'>" + item.FACEDEV_NAME + "</font>");
                            devNode.Image = Properties.Resources.editor;
                            devNode.Tag = item;
                            nodes.Insert(0, devNode);
                        }
                        Node root = new Node("所有人脸识别设备");
                        root.Image = Properties.Resources.house1818;
                        root.Nodes.AddRange(nodes.ToArray());
                        nodes.Clear();
                        nodes.Add(root);


                        advTree.Nodes.Clear();
                        advTree.Nodes.AddRange(nodes.ToArray());
                        advTree.ExpandAll();
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载人脸设备列表异常！"+ex.Message);
                    log.Error("加载人脸设备列表异常:", ex);
                }
            });
            waiting.Show(this);
        }

        private void DoCreateAreaDevice(Node areaNode,List<Maticsoft.Model.SMT_FACERECG_DEVICE> devs)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE zone = areaNode.Tag as Maticsoft.Model.SMT_CONTROLLER_ZONE;
            if (zone != null)
            {
                var fdev = devs.FindAll(m => m.AREA_ID == zone.ID);
                for (int i = fdev.Count - 1; i >= 0; i--)
                {
                    var item = fdev[i];
                    Node doorNode = new Node("<font color='blue'>" + item.FACEDEV_NAME + "</font>");
                    doorNode.Tag = item;
                    doorNode.Image = Properties.Resources.door1818;
                    areaNode.Nodes.Insert(0, doorNode);
                    devs.Remove(item);
                }
            }
            foreach (Node item in areaNode.Nodes)
            {
                DoCreateAreaDevice(item, devs);
            }
        }

        private void biAddPrivate_Click(object sender, EventArgs e)
        {
            FrmAddFaceDevPrivate frmAddFaceDevPrivate = new FrmAddFaceDevPrivate();
            frmAddFaceDevPrivate.ShowDialog(this);
        }

    }
}
