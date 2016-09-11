using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SmartAccess.ModelMgr
{
    public partial class FrmVerModelEditor : DevComponents.DotNetBar.Office2007Form
    {
        private Maticsoft.Model.SMT_VERMODEL_INFO _model = null;
        private string _name = "";
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmVerModelEditor));
        public bool IsChanged = false;
        public FrmVerModelEditor(Maticsoft.Model.SMT_VERMODEL_INFO model=null)
        {
            InitializeComponent();
            _model = model;
        }

        private void FrmVerModelEditor_Load(object sender, EventArgs e)
        {
            designerControl.cmdSave.CustomAction += cmdSave_CustomAction;
            designerControl.cmdSaveAs.CustomAction += cmdSaveAs_CustomAction;
            designerControl.MainMenu.miFileOpen.Visible = false;
            designerControl.MainMenu.miFileNew.Visible = false;
            FastReport.DevComponents.DotNetBar.ButtonItem miRename = new FastReport.DevComponents.DotNetBar.ButtonItem("修改名称", "修改名称");
            miRename.Click += miRename_Click;
            designerControl.MainMenu.Items.Insert(0, miRename);
            designerControl.cmdOpen.CustomAction += cmdOpen_CustomAction;
            designerControl.cmdNew.CustomAction += cmdNew_CustomAction;
            // designerControl.cmdNewPage.CustomAction += cmdNewPage_CustomAction;
            FastReport.Report report = new FastReport.Report();
           
            if (_model == null)
            {
                this.Text = "新建模板：未命名";
            }
            else
            {
                this.Text = "编辑模板：" + _model.VERM_NAME;
                MemoryStream ms = new MemoryStream(_model.VERM_CONTENT);
                report.Load(ms);
            }
            var dt = StaffDataHelper.GetTestReportDataTable();
            report.RegisterData(dt, dt.TableName);
            designerControl.Report = report;

            foreach (FastReport.Data.DataSourceBase item in report.Dictionary.DataSources)
            {
                item.Enabled = true;
            }

            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 250;
            t.Tick += delegate(object sender1, EventArgs e1)
            {
                t.Stop();
                SendKeys.Send("{ENTER}");
            };
            t.Start();
            designerControl.cmdChooseData.Invoke();
            designerControl.RefreshLayout();
        }

        void cmdNewPage_CustomAction(object sender, EventArgs e)
        {
            return;
        }

        private void cmdNew_CustomAction(object sender, EventArgs e)
        {
            return;
        }

        private void miRename_Click(object sender, EventArgs e)
        {
            FrmInputModelName frmName = new FrmInputModelName(_name);
            if (frmName.ShowDialog(this)==DialogResult.OK)
            {
                _name = frmName.ModelName;
                if (_model==null)
                {
                    NewModel();
                }
                else
                {
                    this.Text = "编辑模板：" + _name;
                }
            }
        }

        void cmdOpen_CustomAction(object sender, EventArgs e)
        {
            return;
        }



        //保存
        private void cmdSave_CustomAction(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            DoSave(_model);

        }
        //另存为
        private void cmdSaveAs_CustomAction(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            DoSaveAs();
        }

        private void DoSave(Maticsoft.Model.SMT_VERMODEL_INFO  model)
        {
            if (model == null)
            {
                DoSaveAs();
            }
            else
            {
                //保存
                model.VERM_NAME = _name;
                MemoryStream ms = new MemoryStream();
                designerControl.Report.Save(ms);
                model.VERM_CONTENT = ms.GetBuffer();
                model.VERM_MODIFYTIME = DateTime.Now;
                model.VERM_ADDUSERID = -1;

                CtrlWaiting waiting = new CtrlWaiting(() =>
                {
                    try
                    {
                        Maticsoft.BLL.SMT_VERMODEL_INFO bll = new Maticsoft.BLL.SMT_VERMODEL_INFO();
                        if (model.ID == -1)
                        {
                            model.ID = bll.Add(model);
                        }
                        else
                        {
                            bll.Update(model);
                        }
                        IsChanged = true;
                        WinInfoHelper.ShowInfoWindow(this, "保存成功！");
                    }
                    catch (System.Exception ex)
                    {
                        WinInfoHelper.ShowInfoWindow(this, "保存异常：" + ex.Message);
                        log.Error("保存模板异常：", ex);
                    }
                });
                waiting.Show(this);
            }
        }
        private void NewModel()
        {
            this.Text = "新建模板：" + _name;
            _model = new Maticsoft.Model.SMT_VERMODEL_INFO();
            _model.VERM_NAME = _name;
            _model.VERM_ADDTIME = DateTime.Now;
            _model.ID = -1;
        }
        private void DoSaveAs()
        {
            FrmInputModelName frmName = new FrmInputModelName("");
            if (frmName.ShowDialog(this) == DialogResult.OK)
            {
                _name = frmName.ModelName;
                NewModel();
                DoSave(_model);
            }
        }
    }
}
