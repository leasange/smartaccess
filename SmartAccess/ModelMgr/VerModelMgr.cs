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
            FrmVerModelEditor newModel = new FrmVerModelEditor();
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
            BindingDataSet(_report);
            InitTree();
        }
        //初始化树
        private void InitTree()
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
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
            });
            waiting.Show(this);
        }
        private void ShowModels(List<Maticsoft.Model.SMT_VERMODEL_INFO> infos)
        {
            modelTree.Nodes[0].Nodes.Clear();
            foreach (var item in infos)
            {
                Node model = new Node(item.VERM_NAME);
                model.Tag = item;
                modelTree.Nodes[0].Nodes.Add(model);
                if (_lastSelectModel!=null&&_lastSelectModel.ID==item.ID)
                {
                    _lastSelectModel = item;
                    modelTree.SelectedNode = model;
                }
            }
            modelTree.ExpandAll();
        }

        private void biRefresh_Click(object sender, EventArgs e)
        {
            InitTree();
        }

        private void modelTree_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            Maticsoft.Model.SMT_VERMODEL_INFO model = e.Node.Tag as Maticsoft.Model.SMT_VERMODEL_INFO;
            if (model!=null)
            {
                _lastSelectModel = model;
                ShowModelReportPreview(_lastSelectModel);
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
                _report.Prepare();
                _report.ShowPrepared();
            }
            catch (Exception ex)
            {
                WinInfoHelper.ShowInfoWindow(this, "预览模板异常：" + ex.Message);
                log.Error("预览模板异常：", ex);
            }

        }
        public static void BindingDataSet(FastReport.Report report)
        {
            DataSet ds = new DataSet("人员信息");

            DataTable staff = ds.Tables.Add("人员表");
            staff.Columns.AddRange(new DataColumn[]{
            new DataColumn("部门ID",typeof(int)),
            new DataColumn("姓名",typeof(string)),
            new DataColumn("照片",typeof(Image))
            });
            DataRow staffRow = staff.NewRow();
            staffRow[0] = 0;
            staffRow[1] = "张三";
            staff.Rows.Add(staffRow);

            DataTable dept = ds.Tables.Add("部门表");
            dept.Columns.AddRange(new DataColumn[]{
            new DataColumn("部门ID",typeof(int)),
            new DataColumn("部门编号",typeof(string)),
            new DataColumn("部门名称",typeof(string))
            });
            DataRow deptRow = dept.NewRow();
            deptRow[0] = 0;
            deptRow[1] = "020202";
            deptRow[1] = "财务部";
            dept.Rows.Add(deptRow);


            ds.Relations.Add("关联部门信息", dept.Columns["部门ID"], staff.Columns["部门ID"]);
            report.RegisterData(ds);
            report.AutoFillDataSet = true;
        }
    }
}
