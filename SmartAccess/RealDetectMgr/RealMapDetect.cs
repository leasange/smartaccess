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
using SmartAccess.ConfigMgr;

namespace SmartAccess.RealDetectMgr
{
    public partial class RealMapDetect : UserControl
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(RealMapDetect));
        public RealMapDetect()
        {
            InitializeComponent();
        }

        private void RealMapDetect_Load(object sender, EventArgs e)
        {
            stcMaps.Tabs.Clear();
            Init();
        }
        private void Init()
        {
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
        private void AddTree(Maticsoft.Model.SMT_MAP_INFO mapInfo)
        {
            Node node = new Node(mapInfo.MAP_NAME);
            node.Tag = mapInfo;
            modelTree.Nodes[0].Nodes.Add(node);
        }

        private void biRefresh_Click(object sender, EventArgs e)
        {
            Init();
        }
        private void SelectMap(Maticsoft.Model.SMT_MAP_INFO mapInfo)
        {
            foreach (DevComponents.DotNetBar.SuperTabItem item in stcMaps.Tabs)
            {
                Maticsoft.Model.SMT_MAP_INFO map = (Maticsoft.Model.SMT_MAP_INFO)item.Tag;
                if (map.ID == mapInfo.ID)
                {
                    stcMaps.SelectedTab = item;
                }
            }
        }
        private MapCtrl GetSelectMapCtrl()
        {
            DevComponents.DotNetBar.SuperTabItem item = stcMaps.SelectedTab;
            if (item!=null)
            {
                return item.AttachedControl.Controls[0] as MapCtrl;
            }
            return null;
        }
        private MapCtrl OpenMap(Maticsoft.Model.SMT_MAP_INFO mapInfo)
        {
            foreach (DevComponents.DotNetBar.SuperTabItem item in stcMaps.Tabs)
            {
                Maticsoft.Model.SMT_MAP_INFO map=(Maticsoft.Model.SMT_MAP_INFO)item.Tag;
                if (map.ID==mapInfo.ID)
                {
                    stcMaps.SelectedTab = item;
                    return item.AttachedControl.Controls[0] as MapCtrl;
                }
            }
            MapCtrl mapCtrl = new MapCtrl();
            mapCtrl.Tag = mapInfo;
            mapCtrl.Dock = DockStyle.Fill;
            DevComponents.DotNetBar.SuperTabControlPanel stcPanel = new DevComponents.DotNetBar.SuperTabControlPanel();
            stcPanel.Controls.Add(mapCtrl);
            mapCtrl.LoadMapInfo(mapInfo);
            DevComponents.DotNetBar.SuperTabItem stcItem = new DevComponents.DotNetBar.SuperTabItem() ;
            stcItem.Text = mapInfo.MAP_NAME;
            stcItem.Tag = mapInfo;
            stcItem.AttachedControl = stcPanel;
            stcMaps.Controls.Add(stcPanel);
            stcMaps.Tabs.Add(stcItem);
            stcMaps.SelectedTab = stcItem;
            mapCtrl.DelayFullExtent();
            return mapCtrl;
        }

        private void modelTree_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Button== System.Windows.Forms.MouseButtons.Left)
            {
                Maticsoft.Model.SMT_MAP_INFO mapInfo = e.Node.Tag as Maticsoft.Model.SMT_MAP_INFO;
                if (mapInfo==null)
                {
                    return;
                }
                OpenMap(mapInfo);
            }
        }

        private void modelTree_NodeMouseUp(object sender, TreeNodeMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Maticsoft.Model.SMT_MAP_INFO mapInfo = e.Node.Tag as Maticsoft.Model.SMT_MAP_INFO;
                if (mapInfo == null)
                {
                    return;
                }
                SelectMap(mapInfo);
            }
        }

        private void biZoomPlus_Click(object sender, EventArgs e)
        {
            MapCtrl map = GetSelectMapCtrl();
            if (map!=null)
            {
                map.ZoomPlus();
            }
        }

        private void biZoomMinus_Click(object sender, EventArgs e)
        {
            MapCtrl map = GetSelectMapCtrl();
            if (map != null)
            {
                map.ZoomMinus();
            }
        }

        private void biDetectCurMap_Click(object sender, EventArgs e)
        {
            
        }
    }
}
