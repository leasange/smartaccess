using DevComponents.AdvTree;
using SmartAccess.Common;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ConfigMgr
{
    public partial class FrmEditMap : DevComponents.DotNetBar.Office2007Form
    {
        private Maticsoft.Model.SMT_MAP_INFO _mapInfo = null;
        public bool IsChanged = false;
        public Maticsoft.Model.SMT_MAP_INFO MapInfo
        {
            get { return _mapInfo; }
            set { _mapInfo = value; }
        }
        private List<Node> _selectNodes = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmEditMap));
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
        private void DoDeletes(List<DoorRectangle> deletes)
        {
            if (deletes.Count == 0)
            {
                return;
            }
            if (_selectNodes == null || _selectNodes.Count == 0)
            {
                return;
            }
            var nodes = _selectNodes.FindAll(m =>
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

        private void biDeleteDoor_Click(object sender, EventArgs e)
        {
            var deletes = mapCtrl.DeleteSelectDoors();
            DoDeletes(deletes);
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

        private void biSelectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                try
                {
                    Image image = Image.FromFile(file);
                    mapCtrl.MapImage = (Image)image.Clone();
                    image.Dispose();
                }
                catch (Exception ex)
                {
                    log.Error("打开地图图片异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "打开图片异常！" + ex.Message);
                }
            }
        }

        private void biSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMapName.Text))
            {
                WinInfoHelper.ShowInfoWindow(this, "地图名称不能为空！");
                tbMapName.Focus();
                return;
            }
            if (_mapInfo==null)
            {
                _mapInfo = new Maticsoft.Model.SMT_MAP_INFO();
                _mapInfo.CREATE_TIME = DateTime.Now;
                _mapInfo.ID = -1;
            }
            if (mapCtrl.MapImage!=null)
            {
                MemoryStream ms = new MemoryStream();
                mapCtrl.MapImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                _mapInfo.MAP_IMAGE = ms.GetBuffer();
                ms.Dispose();
            }
            else
            {
                _mapInfo.MAP_IMAGE = new byte[0];
            }
            _mapInfo.MAP_NAME = tbMapName.Text.Trim();
            _mapInfo.GROUP_ID = -1;
            var doors = mapCtrl.GetDoors();
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_MAP_INFO mapBll = new Maticsoft.BLL.SMT_MAP_INFO();
                    Maticsoft.BLL.SMT_MAP_DOOR mdBll = new Maticsoft.BLL.SMT_MAP_DOOR();
                    List<Maticsoft.Model.SMT_MAP_DOOR> mds = new List<Maticsoft.Model.SMT_MAP_DOOR>();
                    foreach (var item in doors)
                    {
                        Maticsoft.Model.SMT_MAP_DOOR md = new Maticsoft.Model.SMT_MAP_DOOR();
                        md.DOOR_ID = item.Id;
                        md.MAP_ID = _mapInfo.ID;
                        md.LOCATION_X = (decimal)item.RatioX;
                        md.LOCATION_Y = (decimal)item.RatioY;
                        md.WIDTH = (decimal)item.RatioWidth;
                        md.HEIGHT = (decimal)item.RatioHeight;
                        mds.Add(md);
                    }
                    if (_mapInfo.ID == -1)
                    {
                        _mapInfo.ID = mapBll.Add(_mapInfo);
                        SmtLog.Info("配置", "添加地图：" + _mapInfo.MAP_NAME);
                    }
                    else
                    {
                        mapBll.Update(_mapInfo);
                        SmtLog.Info("配置", "更新地图：" + _mapInfo.MAP_NAME);
                        var olds = mdBll.GetModelList("MAP_ID=" + _mapInfo.ID);
                        foreach (var old in olds)
                        {
                            mdBll.Delete(old.MAP_ID, old.DOOR_ID);
                        }
                    }
                    foreach (var md in mds)
                    {
                        md.MAP_ID = _mapInfo.ID;
                        mdBll.Add(md);
                        _selectNodes.Find(m =>
                            {
                                if (((Maticsoft.Model.SMT_DOOR_INFO)m.Tag).ID == md.DOOR_ID)
                                {
                                    md.DOOR = (Maticsoft.Model.SMT_DOOR_INFO)m.Tag;
                                    return true;
                                }
                                return false;
                            });
                    }
                    _mapInfo.MAP_DOORS = mds;

                    IsChanged = true;
                    this.Invoke(new Action(() =>
                    {
                        this.Text = "修改地图：" + tbMapName.Text;
                    }));
                    WinInfoHelper.ShowInfoWindow(this, "保存地图成功！");
                }
                catch (Exception ex)
                {
                    log.Error("保存地图异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "保存异常！" + ex.Message);
                }

            });
            waiting.Show(this);
        }

        private void biClearDoors_Click(object sender, EventArgs e)
        {
            var doors = mapCtrl.GetDoors();
            var list = new List<DoorRectangle>();
            list.AddRange(doors);
            mapCtrl.ClearDoors();
            DoDeletes(list);
        }

        private void biClearImage_Click(object sender, EventArgs e)
        {
            if (mapCtrl.MapImage!=null)
            {
                mapCtrl.MapImage = null;
            }
        }
    }
}
