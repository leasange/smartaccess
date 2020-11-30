using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartAccess.Common.WinInfo;

namespace SmartAccess.ConfigMgr
{
    public partial class DicDataSetting : UserControl
    {
        private List<Maticsoft.Model.SMT_DATADICTIONARY_INFO> _dicModels = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(DicDataSetting));
        public DicDataSetting()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (treeData.SelectedNode.DataKey == null)
	        {
		         return;
	        }
            Maticsoft.Model.SMT_DATADICTIONARY_INFO dicm = (Maticsoft.Model.SMT_DATADICTIONARY_INFO)treeData.SelectedNode.DataKey;
            string old = dicm.DATA_VALUE;
            string oldname = dicm.DATA_NAME;
            string olddesc = dicm.DATA_CONTENT;
            if (tbValue.Visible)
            {
                dicm.DATA_VALUE = tbValue.Text;
            }
            else if(cbValue.Visible)
            {
                dicm.DATA_VALUE = cbValue.Checked.ToString();
            }
            if (!tbName.ReadOnly&&!string.IsNullOrWhiteSpace(tbName.Text))
            {
                dicm.DATA_NAME = tbName.Text.Trim();
            }
            if (!tbDesc.ReadOnly)
            {
                dicm.DATA_CONTENT = tbDesc.Text.Trim();                
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_DATADICTIONARY_INFO bll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                    bll.Update(dicm);
                    WinInfoHelper.ShowInfoWindow(this, "保存成功！");
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "保存失败：" + ex.Message);
                    dicm.DATA_VALUE = old;
                    dicm.DATA_NAME = oldname;
                    dicm.DATA_CONTENT = olddesc;
                    log.Error("保存失败", ex);
                }
            });
            waiting.Show(this);
        }
        private void DicDataSetting_Load(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_DATADICTIONARY_INFO dicBll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                    _dicModels  =  dicBll.GetModelList("");
                    this.Invoke(new Action(() =>
                        {
                            List<DevComponents.AdvTree.Node> remvs = new List<DevComponents.AdvTree.Node>();
                            foreach (DevComponents.AdvTree.Node root in treeData.Nodes)
                            {
                                int count = root.Nodes.Count;
                                foreach (DevComponents.AdvTree.Node item in root.Nodes)
                                {
                                    var model = _dicModels.Find(m => m.DATA_TYPE == root.TagString && m.DATA_KEY == item.TagString);
                                    if (model==null)
                                    {
                                        remvs.Add(item);
                                        count--;
                                    }
                                    else
                                    {
                                        item.DataKey = model;
                                        _dicModels.Remove(model);
                                    }
                                }
                                if (count==0)
                                {
                                    remvs.Add(root);
                                }
                            }
                            foreach (var item in remvs)
                            {
                                item.Remove();
                            }
                            foreach (var dicm in _dicModels)
                            {
                                DevComponents.AdvTree.Node rt = null;
                                DevComponents.AdvTree.Node it = null;
                                foreach (DevComponents.AdvTree.Node root in treeData.Nodes)
                                {
                                    if (root.TagString == dicm.DATA_TYPE)
                                    {
                                        rt = root;
                                        foreach (DevComponents.AdvTree.Node item in root.Nodes)
                                        {
                                            if (dicm.DATA_KEY == item.TagString)
                                            {
                                                it = item;
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                                if (rt==null)
                                {
                                    rt = new DevComponents.AdvTree.Node(dicm.DATA_TYPE);
                                    rt.TagString = dicm.DATA_TYPE;
                                }
                                if (it == null)
                                {
                                    it = new DevComponents.AdvTree.Node(dicm.DATA_NAME);
                                    it.TagString = dicm.DATA_KEY;
                                    it.DataKey = dicm;
                                    rt.Nodes.Add(it);
                                }
                            }
                        }));
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "加载异常：" + ex.Message);
                    log.Error("加载异常", ex);
                }
            });
            waiting.Show(this);
        }

        private void treeData_NodeMouseUp(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if ((e.Node.Level == 0 && e.Node.TagString == "STAFF_TYPE") ||
                    (e.Node.Level == 1 && 
                    ((Maticsoft.Model.SMT_DATADICTIONARY_INFO)e.Node.DataKey).DATA_TYPE == "STAFF_TYPE"&&
                    ((Maticsoft.Model.SMT_DATADICTIONARY_INFO)e.Node.DataKey).DATA_KEY!="STAFF"&&
                    ((Maticsoft.Model.SMT_DATADICTIONARY_INFO)e.Node.DataKey).DATA_KEY != "VISITOR"))
                {
                    if (e.Node.Level == 0)
                    {
                        tsmiNew.Enabled = true;
                        tsmiDelete.Enabled = false;
                    }
                    else
                    {
                        tsmiNew.Enabled = false;
                        tsmiDelete.Enabled = true;
                    }
                    contextMenuStrip.Tag = e.Node;
                    contextMenuStrip.Show(Cursor.Position);
                }
            }
            else
            {
                if (e.Node.DataKey == null)
                {
                    tbDataKey.Text = "";
                    tbDataKey.ReadOnly = true;
                    tbValue.Text = "";
                    tbValue.ReadOnly = true;
                    cbValue.Visible = false;
                    tbDesc.Text = "";
                    tbValue.ReadOnly = true;
                    tbName.ReadOnly = true;
                    tbName.Text = e.Node.Text;
                }
                else
                {
                    Maticsoft.Model.SMT_DATADICTIONARY_INFO dicm = (Maticsoft.Model.SMT_DATADICTIONARY_INFO)e.Node.DataKey;
                    tbDesc.Text = dicm.DATA_CONTENT;
                    tbDataKey.Text = dicm.DATA_KEY;
                    tbDataKey.ReadOnly = true;
                    tbName.Text = dicm.DATA_NAME;
                    tbValue.Text = dicm.DATA_VALUE;
                    tbDesc.ReadOnly = true;
                    if (dicm.DATA_TYPE == "ALARM_INFO" && dicm.DATA_KEY == "ALARM_SERVER")
                    {
                        tbValue.ReadOnly = false;
                        btnSave.Enabled = true;
                        tbName.ReadOnly = true;
                    }
                    else if (dicm.DATA_TYPE == "STAFF_TYPE")
                    {
                        if (dicm.DATA_KEY == "STAFF" || dicm.DATA_KEY == "VISITOR")
                        {
                            tbValue.ReadOnly = true;
                            btnSave.Enabled = false;
                            tbName.ReadOnly = true;
                            tbDesc.AppendText("【内置类型不可编辑！】");
                        }
                        else
                        {
                            tbValue.ReadOnly = true;
                            btnSave.Enabled = true;
                            tbName.ReadOnly = false;
                            tbDesc.ReadOnly = false;
                        }
                    }
                    else if(dicm.DATA_KEY== "ACS_REST_URL")
                    {
                        tbValue.ReadOnly = false;
                        tbValue.Visible = true;
                        cbValue.Visible = false;
                        tbName.ReadOnly = true;
                        tbDesc.ReadOnly = true;
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        tbValue.ReadOnly = true;
                        btnSave.Enabled = false;
                    }
                    bool res = false;
                    if (bool.TryParse(dicm.DATA_VALUE, out res))
                    {
                        tbValue.Visible = false;
                        cbValue.Visible = true;
                        cbValue.Text = dicm.DATA_NAME;
                        cbValue.Checked = res;
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        tbValue.Visible = true;
                        cbValue.Visible = false;
                    }
                }
            }
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            var selectNode = contextMenuStrip.Tag as DevComponents.AdvTree.Node;
            if (selectNode==null)
            {
                return;
            }
            FrmNewDicData frmDicData = null;
            if (selectNode.Level==0)
            {
                string dataType = selectNode.TagString;
                frmDicData = new FrmNewDicData(dataType);
                if (frmDicData.ShowDialog(this) == DialogResult.OK)
                {
                    var dataNode = new DevComponents.AdvTree.Node(frmDicData.DATA_INFO.DATA_NAME);
                    dataNode.TagString = frmDicData.DATA_INFO.DATA_KEY;
                    dataNode.DataKey = frmDicData.DATA_INFO;
                    selectNode.Nodes.Add(dataNode);
                }
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            var selectNode = contextMenuStrip.Tag as DevComponents.AdvTree.Node;
            if (selectNode == null)
            {
                return;
            }
            if (selectNode.Level == 1)
            {
                Maticsoft.Model.SMT_DATADICTIONARY_INFO dicm = (Maticsoft.Model.SMT_DATADICTIONARY_INFO)selectNode.DataKey;
                if (MessageBox.Show(this,"确定删除"+dicm.DATA_NAME+"?","提示",MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    CtrlWaiting waiting = new CtrlWaiting(() =>
                    {
                        try
                        {
                            Maticsoft.BLL.SMT_DATADICTIONARY_INFO bll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                            bll.Delete(dicm.DATA_TYPE, dicm.DATA_KEY);
                            this.Invoke(new Action(() =>
                                {
                                    try
                                    {
                                        selectNode.Remove();
                                        tbDataKey.Text = "";
                                        tbDesc.Text = "";
                                        tbName.Text = "";
                                        tbValue.Text = "";
                                    }
                                    catch (Exception)
                                    { 
                                    }
                                }));
                        }
                        catch (Exception ex)
                        {
                            WinInfoHelper.ShowInfoWindow(this, "删除失败：" + ex.Message);
                            log.Error("删除失败", ex);
                        }
                    });
                    waiting.Show(this);
                }
            }
        }
    }
}
