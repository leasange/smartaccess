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
using Li.Controls;

namespace SmartAccess.VerInfoMgr
{
    public partial class DoorTree : UserControl
    {
        public AdvTreeEx Tree
        {
            get
            {
                return this.advDoorTree;
            }
        }
        private event EventHandler _loadEnded= null;
        private bool _isloaded = false;
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

        public DoorTree()
        {
            InitializeComponent();
        }

        private void DoorTree_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                CtrlWaiting ctrlWaiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        Maticsoft.BLL.SMT_DOOR_INFO doorBll = new Maticsoft.BLL.SMT_DOOR_INFO();
                        var doors = doorBll.GetModelListWithArea("");
                        var areas = AreaDataHelper.GetAreas();
                        this.Invoke(new Action(() =>
                            {
                                var nodes = AreaDataHelper.ToTree(areas);
                                CreateDoorTree(nodes, doors);
                                advDoorTree.Nodes.Clear();
                                advDoorTree.Nodes.AddRange(nodes.ToArray());
                                advDoorTree.ExpandAll();
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
                        WinInfoHelper.ShowInfoWindow(this, "门禁列表加载异常：" + ex.Message);
                        this.Invoke(new Action(() =>
                          {
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
                });
                ctrlWaiting.Show(this, 300);
            }
        }
        private void CreateDoorTree(List<Node> nodes, List<Maticsoft.Model.SMT_DOOR_INFO> doors)
        {
            foreach (var item in nodes)
            {
                DoCreateNodes(item, doors);
            }
            for (int i = doors.Count - 1; i >= 0; i--)
            {
                var item = doors[i];
                Node doorNode = new Node("<font color='blue'>" + item.DOOR_NAME + "</font>");
                doorNode.Tag = item;
                nodes.Insert(0, doorNode);
            }
            Node root = new Node("所有的门");
            root.Nodes.AddRange(nodes.ToArray());
            nodes.Clear();
            nodes.Add(root);
        }
        private void DoCreateNodes(Node node, List<Maticsoft.Model.SMT_DOOR_INFO> doors)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE zone = node.Tag as Maticsoft.Model.SMT_CONTROLLER_ZONE;
            if (zone!=null)
            {
                var fdoors = doors.FindAll(m => m.AREA_ID == zone.ID);
                for (int i = fdoors.Count - 1; i >= 0; i--)
                {
                    var item = fdoors[i];
                    Node doorNode = new Node("<font color='blue'>" + item.DOOR_NAME + "</font>");
                    doorNode.Tag = item;
                    node.Nodes.Insert(0, doorNode);
                    doors.Remove(item);
                }
                node.Text += " (" + fdoors.Count + ")";
            }
            foreach (Node item in node.Nodes)
            {
                DoCreateNodes(item, doors);
            }
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            CommonClass.FilterTree(advDoorTree, tbFilter.Text.Trim());
        }
    }
}
