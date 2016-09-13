using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;
using DevComponents.AdvTree;

namespace SmartAccess.ConfigMgr
{
    public partial class MapsMgr : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(MapsMgr));
        public MapsMgr()
        {
            InitializeComponent();
        }

        private void biNewMap_Click(object sender, EventArgs e)
        {
            FrmEditMap editMap = new FrmEditMap();
            editMap.ShowDialog(this);
            if (editMap.IsChanged)
            {
                AddTree(editMap.MapInfo);
            }
        }

        private void AddTree(Maticsoft.Model.SMT_MAP_INFO mapInfo)
        {
            Node node = new Node(mapInfo.MAP_NAME);
            node.Tag = mapInfo;
            modelTree.Nodes[0].Nodes.Add(node);
        }

        private void MapsMgr_Load(object sender, EventArgs e)
        {
            Init();
        }


        private void Init()
        {
            mapCtrl.ClearDoors();
            modelTree.Nodes[0].Nodes.Clear();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_MAP_INFO mapBll = new Maticsoft.BLL.SMT_MAP_INFO();
                    var maps = mapBll.GetModelListWithDoors("1=1");
                    this.Invoke(new Action(() =>
                    {
                        foreach (var item in maps)
                        {
                            AddTree(item);
                        }
                        modelTree.ExpandAll();
                    }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载地图列表异常：" + ex.Message);
                    log.Error("加载地图列表异常：", ex);
                }

            });
            waiting.Show(this);
        }

        public Maticsoft.Model.SMT_MAP_INFO GetSelectMap()
        {
            if (modelTree.SelectedNode != null & modelTree.SelectedNode.Tag is Maticsoft.Model.SMT_MAP_INFO)
            {
                return modelTree.SelectedNode.Tag as Maticsoft.Model.SMT_MAP_INFO;
            }
            return null;
        }

        private void biModifyMap_Click(object sender, EventArgs e)
        {
            var map = GetSelectMap();
            if (map!=null)
            {
                FrmEditMap editMap = new FrmEditMap(map);
                editMap.ShowDialog(this);
                if (editMap.IsChanged)
                {
                    mapCtrl.LoadMapInfo(editMap.MapInfo);
                    mapCtrl.FullExtent();
                }
            }
        }

        private void biRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void modelTree_NodeMouseUp(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Left)
            {
                var map = e.Node.Tag as Maticsoft.Model.SMT_MAP_INFO;
                mapCtrl.LoadMapInfo(map);
                mapCtrl.FullExtent();
            }
        }

        private void biFullExtent_Click(object sender, EventArgs e)
        {
            mapCtrl.FullExtent();
        }

        private void biDeleteMap_Click(object sender, EventArgs e)
        {
            var map = GetSelectMap();
            if (map==null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择要删除的地图！");
            }
            if (MessageBox.Show("确定删除选择地图？","提示",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        Maticsoft.BLL.SMT_MAP_DOOR mdbll = new Maticsoft.BLL.SMT_MAP_DOOR();
                        foreach (var item in map.MAP_DOORS)
                        {
                            mdbll.Delete(item.MAP_ID, item.DOOR_ID);
                        }
                        Maticsoft.BLL.SMT_MAP_INFO mapBll = new Maticsoft.BLL.SMT_MAP_INFO();
                        mapBll.Delete(map.ID);
                        this.Invoke(new Action(() =>
                        {
                            modelTree.SelectedNode.Remove();
                            mapCtrl.LoadMapInfo(null);
                        }));
                    }
                    catch (Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "删除地图异常：" + ex.Message);
                        log.Error("删除地图异常：", ex);
                    }
                });
                waiting.Show(this);
            }
        }
    }
}
