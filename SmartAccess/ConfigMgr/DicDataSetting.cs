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
            if (tbValue.Visible)
            {
                dicm.DATA_VALUE = tbValue.Text;
            }
            else if(cbValue.Visible)
            {
                dicm.DATA_VALUE = cbValue.Checked.ToString();
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
                                    if (rt.TagString == dicm.DATA_TYPE)
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
            if (e.Node.DataKey == null)
            {
                tbDataKey.Text = "";
                tbDataKey.ReadOnly = true;
                tbValue.Text = "";
                tbValue.ReadOnly = true;
                cbValue.Visible=false;
                tbDesc.Text = "";
                tbValue.ReadOnly = true;
            }
            else
            {
                Maticsoft.Model.SMT_DATADICTIONARY_INFO dicm = (Maticsoft.Model.SMT_DATADICTIONARY_INFO)e.Node.DataKey;
                tbDesc.Text = dicm.DATA_CONTENT;
                tbDataKey.Text = dicm.DATA_KEY;
                tbDataKey.ReadOnly = true;

                tbValue.Text = dicm.DATA_VALUE;
                if (dicm.DATA_TYPE == "ALARM_INFO" && dicm.DATA_KEY == "ALARM_SERVER")
                {
                    tbValue.ReadOnly = false;
                    btnSave.Enabled = true;
                }
                else
                {
                    tbValue.ReadOnly = true;
                    btnSave.Enabled = false;
                }
                bool res=false;
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
}
