using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.Datas;
using Li.Access.Core;
using Li.Access.Core.WGAccesses;
using SmartAccess.Common.WinInfo;

namespace SmartAccess.ControlDevMgr
{
    public partial class ControllerMgr : UserControl
    {
        public ControllerMgr()
        {
            InitializeComponent();
        }
        private void Init()
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                List<Maticsoft.Model.SMT_CONTROLLER_INFO> ctrls = ControllerHelper.GetList("1=1",true);//获取所有控制器
                List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas = AreaDataHelper.GetAreas(true);//获取所有区域
                this.Invoke(new Action(()=>
                    {
                        ShowAreas(areas);
                        ShowCtrls(ctrls);
                    }));
            });
            waiting.Show(this,500);
        }
        private void DoLoadCtrlrs(List<decimal> areaIds)
        {
            List<Maticsoft.Model.SMT_CONTROLLER_INFO> ctrls = ControllerHelper.GetList(areaIds);

        }
        private void ShowAreas(List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas)
        {
            var tree=  AreaDataHelper.ToTree(areas);
            advTreeArea.Nodes[0].Nodes.Clear();
            advTreeArea.Nodes[0].Nodes.AddRange(tree.ToArray());
            advTreeArea.ExpandAll();
        }
 
        private void ShowCtrls(List<Maticsoft.Model.SMT_CONTROLLER_INFO> ctrls)
        {
            if (ctrls == null)
            {
                return;
            }
            dgvCtrlr.Rows.Clear();
            foreach (var item in ctrls)
            {
                DataGridViewRow row = new DataGridViewRow();
                string doors = "";
                if (item.DOOR_INFOS!=null&&item.DOOR_INFOS.Count>0)
                {
                    foreach (var door in item.DOOR_INFOS)
                    {
                        doors += door.DOOR_NAME + ";";
                    }
                }
                row.CreateCells(dgvCtrlr,
                    item.NAME,
                    item.SN_NO,
                    item.IS_ENABLE,
                    item.IP,
                    item.PORT,
                    item.AREA_NAME,
                    item.CTRLR_DESC,
                    doors//所控制的门
                    );
                dgvCtrlr.Rows.Add(row);
            }
        }

        private Maticsoft.Model.SMT_CONTROLLER_ZONE GetSelectArea()
        {
            if(advTreeArea.SelectedNode!=null)
            {
               return advTreeArea.SelectedNode.Tag as Maticsoft.Model.SMT_CONTROLLER_ZONE;
            }
            return null;
        }
        private List<Maticsoft.Model.SMT_CONTROLLER_ZONE> GetSelectWithSubAreas()
        {
            List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas = new List<Maticsoft.Model.SMT_CONTROLLER_ZONE>();
            if (advTreeArea.SelectedNode!=null&&advTreeArea.SelectedNode.Tag is Maticsoft.Model.SMT_CONTROLLER_ZONE)
            {
                areas.Add((Maticsoft.Model.SMT_CONTROLLER_ZONE)advTreeArea.SelectedNode.Tag);
                GetSubAreas(advTreeArea.SelectedNode, ref areas);
            }
            return areas;
        }
        private void GetSubAreas(DevComponents.AdvTree.Node node,ref List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas)
        {
            foreach (DevComponents.AdvTree.Node item in node.Nodes)
            {
                areas.Add((Maticsoft.Model.SMT_CONTROLLER_ZONE)item.Tag);
                GetSubAreas(item, ref areas);
            }
        }
        private void ControlerMgr_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void advTreeArea_NodeMouseDown(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {

        }

        private void advTreeArea_AfterNodeSelect(object sender, DevComponents.AdvTree.AdvTreeNodeEventArgs e)
        {
            if (e.Node==null)
            {
                return;
            }
            if (e.Node.Level==0)
            {
                biDeleteArea.Enabled = false;
                biModifyArea.Enabled = false;
            }
            else
            {
                biDeleteArea.Enabled = true;
                biModifyArea.Enabled = true;
            }
        }

        private void biAddArea_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE area = GetSelectArea();
            FrmControlAreaEditor areaEditor = new FrmControlAreaEditor();
            areaEditor.IsAdd = true;
            if (area!=null)
            {
                areaEditor.ParentAreaID = area.PAR_ID;
            }
            else
            {
                areaEditor.ParentAreaID = 0;
            }
            if(areaEditor.ShowDialog(this)== DialogResult.OK)
            {
                Maticsoft.Model.SMT_CONTROLLER_ZONE areaAdded = areaEditor.Area;
                DevComponents.AdvTree.Node node = AreaDataHelper.CreateNode(areaAdded);
                if (advTreeArea.SelectedNode==null||advTreeArea.SelectedNode.Level==0)
                {
                    advTreeArea.Nodes[0].Nodes.Add(node);
                }
                else
                {
                    advTreeArea.SelectedNode.Parent.Nodes.Add(node);
                    
                }
                node.Parent.Expand();
            }
        }

        private void biAddSubArea_Click(object sender, EventArgs e)
        {
            Maticsoft.Model.SMT_CONTROLLER_ZONE area = GetSelectArea();
            FrmControlAreaEditor areaEditor = new FrmControlAreaEditor();
            areaEditor.IsAdd = true;
            if (area != null)
            {
                areaEditor.ParentAreaID = area.ID;
            }
            else
            {
                areaEditor.ParentAreaID = 0;
            }
            if (areaEditor.ShowDialog(this) == DialogResult.OK)
            {
                Maticsoft.Model.SMT_CONTROLLER_ZONE areaAdded = areaEditor.Area;
                DevComponents.AdvTree.Node node = AreaDataHelper.CreateNode(areaAdded);
                if (advTreeArea.SelectedNode == null || advTreeArea.SelectedNode.Level == 0)
                {
                    advTreeArea.Nodes[0].Nodes.Add(node);
                }
                else
                {
                    advTreeArea.SelectedNode.Nodes.Add(node);
                }
                node.Parent.Expand();
            }
        }

        private void biDeleteArea_Click(object sender, EventArgs e)
        {
            List<Maticsoft.Model.SMT_CONTROLLER_ZONE> areas = GetSelectWithSubAreas();
            if (areas.Count>0)
            {
                if (MessageBox.Show("确定删除当前区域及其下级区域？","提示",MessageBoxButtons.OKCancel)== DialogResult.OK)
                {
                    AreaDataHelper.DeleteAreas(areas);
                    advTreeArea.SelectedNode.Remove();
                }
            }
        }

        private void biAddRootArea_Click(object sender, EventArgs e)
        {
            FrmSearchController search = new FrmSearchController();
            search.ShowDialog(this);
        }

        private void btnAddCtrlr_Click(object sender, EventArgs e)
        {
            
        }
    }
}
