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
using Li.Controls;

namespace SmartAccess.VerInfoMgr
{
    public partial class FaceDevTree : UserControl
    {
        public bool CheckBoxVisible
        {
            get
            {
                return this.advTree.CheckBoxVisible;
            }
            set
            {
                this.advTree.CheckBoxVisible = value;
            }
        }
        public AdvTreeEx Tree
        {
            get
            {
                return this.advTree;
            }
        }

        private event EventHandler _loadEnded = null;
        private bool _isloaded = false;

        public bool IsLoaded
        {
            get
            {
                return _isloaded;
            }
        }

        public event EventHandler LoadEnded
        {
            add
            {
                lock (this)
                {
                    _loadEnded += value;
                    if (_isloaded)
                    {
                        _loadEnded(this, new EventArgs());
                    }
                }
            }
            remove
            {
                _loadEnded -= value;
            }
        }

        private List<Maticsoft.Model.SMT_FACERECG_DEVICE> _faceDevices = null;
        public FaceDevTree()
        {
            InitializeComponent();
        }
        public static bool IsDesignMode()
        {
            bool returnFlag = false;

#if DEBUG
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                returnFlag = true;
            }
            else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
            {
                returnFlag = true;
            }
#endif
            return returnFlag;
        }
        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            CommonClass.FilterTree(advTree, tbFilter.Text.Trim());
        }

        private void FaceDevTree_Load(object sender, EventArgs e)
        {
            if (!IsDesignMode())
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
                            var faceDevs = _faceDevices.ToList();
                            foreach (var item in nodes)
                            {
                                DoCreateAreaDevice(item, faceDevs);
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

                            lock (this)
                            {
                                _isloaded = true;
                                if (_loadEnded != null)
                                {
                                    _loadEnded(this, e);
                                }
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "加载人脸设备列表异常！" + ex.Message);
                    }
                });
                waiting.Show(this);
            }
        }

        private void DoCreateAreaDevice(Node areaNode, List<Maticsoft.Model.SMT_FACERECG_DEVICE> devs)
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

    }
}
