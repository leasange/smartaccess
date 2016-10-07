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
using System.IO;
using SmartAccess.Common.Datas;

namespace SmartAccess.ModelMgr
{
    public partial class VerModelMgr : UserControl
    {
        private FastReport.Report _report = null;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(VerModelMgr));
        private Maticsoft.Model.SMT_VERMODEL_INFO _lastSelectModel = null;
        public VerModelMgr()
        {
            InitializeComponent();
        }

        private void biNewVerModel_Click(object sender, EventArgs e)
        {
            FrmVerModelEditor newModel = null;
            if (modelTree.SelectedNode.Tag is FileInfo)
            {
                newModel = new FrmVerModelEditor(modelTree.SelectedNode.Tag as FileInfo);
            }
            else
            {
                newModel = new FrmVerModelEditor();
            }
            newModel.ShowDialog(this);
            if (newModel.IsChanged)
            {
                InitTree();
            }
        }

        private Maticsoft.Model.SMT_VERMODEL_INFO GetSelectModel()
        {
            if (modelTree.SelectedNode==null||modelTree.SelectedNode.Tag==null)
	        { 
		        return null;
            }
            Maticsoft.Model.SMT_VERMODEL_INFO model = modelTree.SelectedNode.Tag as Maticsoft.Model.SMT_VERMODEL_INFO;
            return model; 
        }

        private void biModifyModel_Click(object sender, EventArgs e)
        {
            var model = GetSelectModel();
            if (model==null)
            {
                WinInfoHelper.ShowInfoWindow(this, "选择修改的模板！");
                return;
            }
            FrmVerModelEditor modifyModel = new FrmVerModelEditor(model);
            modifyModel.ShowDialog(this);
            if (modifyModel.IsChanged)
            {
                InitTree();
            }
        }

        private void VerModelMgr_Load(object sender, EventArgs e)
        {
            FastReport.Utils.Config.Root.FindItem("Language").SetProp("Name", "Chinese (Simplified)");
            FastReport.Utils.Config.Root.FindItem("Language").SetProp("Folder", Path.Combine(Application.StartupPath, "Localization"));
            _report = new FastReport.Report();
            _report.Preview = previewControl;
            InitTree();
        }
        //初始化树
        private void InitTree()
        {
            modelTree.Nodes[0].Nodes.Clear();
            try
            {
                string path = Path.Combine(Application.StartupPath, "vermodes");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    string[] files = Directory.GetFiles(path, "*.fpx");
                    foreach (var item in files)
                    {
                        FileInfo fi = new FileInfo(item);
                        Node node = new Node(fi.Name);
                        node.Tag = fi;
                        modelTree.Nodes[0].Nodes.Add(node);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("获取示例模板异常：", ex);
            }

            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                InternalInitTree();
            });
            waiting.Show(this,300);
        }
        private void InternalInitTree()
        {
            try
            {
                Maticsoft.BLL.SMT_VERMODEL_INFO bll = new Maticsoft.BLL.SMT_VERMODEL_INFO();
                var list = bll.GetModelList("");
                this.Invoke(new Action(() =>
                {
                    ShowModels(list);
                }));
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "获取模板列表异常：" + ex.Message);
                log.Error("获取模板列表异常：", ex);
            }
        }
        private void ShowModels(List<Maticsoft.Model.SMT_VERMODEL_INFO> infos)
        {
            modelTree.Nodes[1].Nodes.Clear();
            foreach (var item in infos)
            {
                Node model = new Node(item.VERM_NAME);
                model.Tag = item;
                modelTree.Nodes[1].Nodes.Add(model);
                if (_lastSelectModel!=null&&_lastSelectModel.ID==item.ID)
                {
                    _lastSelectModel = item;
                    modelTree.SelectedNode = model;
                }
            }
            if (_lastSelectModel==null)
            {
                _report.Clear();
                _report.Prepare();
                _report.ShowPrepared();
            }
            modelTree.ExpandAll();
        }

        private void biRefresh_Click(object sender, EventArgs e)
        {
            InitTree();
        }

        private void modelTree_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            if (e.Node.Tag is Maticsoft.Model.SMT_VERMODEL_INFO)
            {
                Maticsoft.Model.SMT_VERMODEL_INFO model = e.Node.Tag as Maticsoft.Model.SMT_VERMODEL_INFO;
                if (model != null)
                {
                    _lastSelectModel = model;
                    ShowModelReportPreview(_lastSelectModel);
                }
            }
            else if(e.Node.Tag is FileInfo)//示例模板
            {
                try
                {
                    var dt = StaffDataHelper.GetTestReportDataTable();
                    FileInfo fi = (FileInfo)e.Node.Tag;
                    _report.Load(fi.FullName);
                    _report.RegisterData(dt, dt.TableName);
                    _report.AutoFillDataSet = true;
                    _report.Prepare();
                    _report.ShowPrepared();
                }
                catch (Exception ex)
                {
                    log.Error("预览示例模板异常：", ex);
                    WinInfoHelper.ShowInfoWindow(this, "预览示例模板异常：" + ex.Message);
                }
            }
        }
        private void ShowModelReportPreview(Maticsoft.Model.SMT_VERMODEL_INFO model)
        {
            try
            {
                byte[] content = model.VERM_CONTENT;
                MemoryStream ms = new MemoryStream(content);
                _report.Load(ms);
                ms.Dispose();
                var dt = StaffDataHelper.GetTestReportDataTable();
                _report.RegisterData(dt, dt.TableName);
                _report.AutoFillDataSet = true;
                _report.Prepare();
                _report.ShowPrepared();
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "预览模板异常：" + ex.Message);
                log.Error("预览模板异常：", ex);
            }

        }

        private void biDeleteModel_Click(object sender, EventArgs e)
        {
            var model = GetSelectModel();
            if (model==null)
            {
                WinInfoHelper.ShowInfoWindow(this, "请选择删除的模板！");
            }
            else
            {
                if (MessageBox.Show("确定删除“"+model.VERM_NAME+"”模板？","提示",MessageBoxButtons.OKCancel)==DialogResult.OK)
                {
                    CtrlWaiting waiting = new CtrlWaiting(() =>
                    {
                        try
                        {
                            Maticsoft.BLL.SMT_VERMODEL_INFO bll = new Maticsoft.BLL.SMT_VERMODEL_INFO();
                            bll.Delete(model.ID);
                            _lastSelectModel = null;
                            InternalInitTree();
                        }
                        catch (Exception ex)
                        {
                            log.Error("删除模板异常：" + ex.Message);
                            WinInfoHelper.ShowInfoWindow(this, "删除模板异常：" + ex.Message);
                        }

                    });
                    waiting.Show(this);
                }
            }
        }

        private void biExportModel_Click(object sender, EventArgs e)
        {
            var model = GetSelectModel();
            if (model!=null)
            {
                saveFileDialog.FileName = model.VERM_NAME;
                if (saveFileDialog.ShowDialog(this)==DialogResult.OK)
	            {
                    _report.Save(saveFileDialog.FileName);
	            }
            }
        }
    }
}
