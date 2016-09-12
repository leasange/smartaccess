using DevComponents.AdvTree;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ConfigMgr
{
    public partial class FrmEditMap : DevComponents.DotNetBar.Office2007Form
    {
        private Maticsoft.Model.SMT_MAP_INFO _mapInfo = null;
        private List<Node> _selectNodes = null;
        public FrmEditMap(Maticsoft.Model.SMT_MAP_INFO mapInfo=null)
        {
            InitializeComponent();
            mapCtrl.ClearDoors();
            _mapInfo = mapInfo;
            if (_mapInfo==null)
            {
                this.Text = "新建地图";
            }
            else
            {
                this.Text = "修改地图：" + _mapInfo.MAP_NAME;
                tbMapName.Text = _mapInfo.MAP_NAME;
            }
            doorTree.LoadEnded += doorTree_LoadEnded;
        }

        private void doorTree_LoadEnded(object sender, EventArgs e)
        {
            if (_mapInfo != null && _mapInfo.MAP_DOORS != null && _mapInfo.MAP_DOORS.Count > 0)
            {
                var nodes = this.doorTree.Tree.GetNodeList(typeof(Maticsoft.Model.SMT_DOOR_INFO));
                _selectNodes = nodes.FindAll(m =>
                {
                    Maticsoft.Model.SMT_DOOR_INFO di = (Maticsoft.Model.SMT_DOOR_INFO)m.Tag;
                    return _mapInfo.MAP_DOORS.Exists(n => n.DOOR_ID == di.ID);
                });
                foreach (var item in _selectNodes)
                {
                    item.DataKey = item.Parent;
                    item.Remove();
                }
            }
        }

        private void FrmEditMap_Load(object sender, EventArgs e)
        {
            if (_mapInfo!=null)
            {
                mapCtrl.LoadMapInfo(_mapInfo);
            }
            mapCtrl.DelayFullExtent();
        }
        private void mapCtrl_DragDrop(object sender, DragEventArgs e)
        {
            Node node = (Node)e.Data.GetData(typeof(Node));
            Maticsoft.Model.SMT_DOOR_INFO doorInfo = node.Tag as Maticsoft.Model.SMT_DOOR_INFO;
            if (doorInfo!=null)
            {
                mapCtrl.AddDoorInfo(doorInfo, mapCtrl.PointToClient(Cursor.Position));
            }
            if (_selectNodes==null)
            {
                _selectNodes = new List<Node>();
            }
            if (!_selectNodes.Contains(node))
            {
                node.DataKey = node.Parent;
                node.Remove();
                _selectNodes.Add(node);
            }
        }

        private void mapCtrl_DragEnter(object sender, DragEventArgs e)
        {
            Node node = e.Data.GetData(typeof(Node)) as Node;
            if (node != null && node.Tag is Maticsoft.Model.SMT_DOOR_INFO)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void biDeleteDoor_Click(object sender, EventArgs e)
        {
            var deletes = mapCtrl.DeleteSelectDoors();
            if (deletes.Count==0)
            {
                return;
            }
            if (_selectNodes==null||_selectNodes.Count==0)
            {
                return;
            }
            var nodes= _selectNodes.FindAll(m =>
                {
                    Maticsoft.Model.SMT_DOOR_INFO di = (Maticsoft.Model.SMT_DOOR_INFO)m.Tag;
                    return deletes.Exists(n => n.Id == di.ID);
                });
            foreach (var item in nodes)
            {
                _selectNodes.Remove(item);
                Node p = (Node)item.DataKey;
                p.Nodes.Add(item);
            }
        }

        private void biFullExtent_Click(object sender, EventArgs e)
        {
            mapCtrl.FullExtent();
        }

        private void mapCtrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                biDeleteDoor_Click(sender, e);
            }
        }
    }
}
