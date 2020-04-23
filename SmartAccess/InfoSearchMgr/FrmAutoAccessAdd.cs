using SmartAccess.Common.Datas;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SmartAccess.InfoSearchMgr
{
    public partial class FrmAutoAccessAdd : DevComponents.DotNetBar.Office2007Form
    {
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmAutoAccessAdd));
        public FrmAutoAccessAdd()
        {
            InitializeComponent();
            advMemTree.Nodes.Clear();
            tbNum.Text =DateTime.Now.ToString("AS-yyyy-MM-dd-HH-mm-ss-fff"); //Guid.NewGuid().ToString("N");
            dtpEnd.Value = DateTime.Now.AddHours(12);
            doorTree.IsVisitor = true;
        }

        void Tree_NodeMouseUp(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Node.Tag == null || e.Node.HasChildNodes)
            {
                return;
            }
            Maticsoft.Model.SMT_DATADICTIONARY_INFO dic = e.Node.Tag as Maticsoft.Model.SMT_DATADICTIONARY_INFO;
            if (dic == null)
            {
                return;
            }
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_STAFF_INFO siBll = new Maticsoft.BLL.SMT_STAFF_INFO();
                    var staffs = siBll.GetModelList("IS_DELETE=0 and IS_FORBIDDEN=0 and STAFF_TYPE ='" + dic.DATA_VALUE + "'");
                    if (staffs.Count > 0)
                    {
                        this.Invoke(new Action(() =>
                        {
                            try
                            {
                                foreach (var item in staffs)
                                {
                                    DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node(item.REAL_NAME);
                                    node.Tag = item;
                                    e.Node.Nodes.Add(node);
                                }
                                e.Node.Expand();

                            }
                            catch (Exception)
                            {
                            }

                        }));
                    }
                }
                catch (Exception ex)
                {
                    log.Error("加载失败：", ex);
                }
            });
            waiting.Show(this);
        }

        private void tbMemFilter_TextChanged(object sender, EventArgs e)
        {
            CommonClass.FilterTree(advMemTree, tbMemFilter.Text.Trim());
        }

        private void FrmAutoAccessAdd_Load(object sender, EventArgs e)
        {
            CtrlWaiting waiting = new CtrlWaiting(() =>
            {
                try
                {
                    Maticsoft.BLL.SMT_DATADICTIONARY_INFO dicBll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                    var staffTypes = dicBll.GetModelList("DATA_TYPE='STAFF_TYPE' and DATA_KEY!='STAFF'");
                    this.Invoke(new Action(() =>
                    {
                        foreach (var item in staffTypes)
                        {
                            DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node(item.DATA_NAME);
                            node.Tag = item;
                            advMemTree.Nodes.Add(node);
                        }
                    }));
                }
                catch (System.Exception ex)
                {
                    log.Error("加载失败：", ex);
                }
            });
            waiting.Show(this);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string num = tbNum.Text.Trim();
            if (string.IsNullOrWhiteSpace(num))
            {
                MessageBox.Show("编号作为唯一标识，不能为空！");
                return;
            }
            if (dtpStart.Value > dtpEnd.Value || dtpEnd.Value <= DateTime.Now)
            {
                MessageBox.Show("起止时间选择无效！");
                return;
            }

            var memNodes = advMemTree.GetNodeList(true, typeof(Maticsoft.Model.SMT_STAFF_INFO));
            if (memNodes.Count == 0)
            {
                MessageBox.Show("未选择人员！");
                return;
            }
            List<Maticsoft.Model.SMT_STAFF_INFO> staffs = new List<Maticsoft.Model.SMT_STAFF_INFO>();
            foreach (var memNode in memNodes)
            {
                staffs.Add(memNode.Tag as Maticsoft.Model.SMT_STAFF_INFO);
            }
            var doorNodes = doorTree.Tree.GetNodeList(true, typeof(Maticsoft.Model.SMT_DOOR_INFO));
            if (doorNodes.Count == 0)
            {
                MessageBox.Show("未选择门！");
                return;
            }
            List<Maticsoft.Model.SMT_DOOR_INFO> doors = new List<Maticsoft.Model.SMT_DOOR_INFO>();
            foreach (var doorNode in doorNodes)
            {
                doors.Add(doorNode.Tag as Maticsoft.Model.SMT_DOOR_INFO);
            }
            Maticsoft.BLL.SMT_AUTO_ACCESS autoAccessBll = new Maticsoft.BLL.SMT_AUTO_ACCESS();
            CtrlWaiting waiting = new CtrlWaiting(() =>
             {
                 try
                 {
                     foreach (var staff in staffs)
                     {
                         foreach (var door in doors)
                         {
                             Maticsoft.Model.SMT_AUTO_ACCESS asModel = new Maticsoft.Model.SMT_AUTO_ACCESS();
                             asModel.ID = -1;
                             asModel.ACC_ADD_TIME = DateTime.Now;
                             asModel.ACC_APP_ID = num;
                             asModel.ACC_APP_NAME = tbTitle.Text.Trim();
                             asModel.ACC_DOOR_ID = door.ID;
                             asModel.ACC_END_TIME = dtpEnd.Value;
                             asModel.ACC_FROM_SYS = "SMART_ACCESS";
                             asModel.ACC_STAFF_ID = staff.ID;
                             asModel.ACC_START_TIME = dtpStart.Value;
                             asModel.ACC_STATE = 0;
                             asModel.ACC_STATE_TIME = DateTime.Now;
                             autoAccessBll.Add(asModel);
                         }
                     }
                     Thread.Sleep(2000);
                     this.Invoke(new Action(() =>
                     {
                         this.DialogResult = DialogResult.OK;
                         this.Close();
                     }));
                 }
                 catch (System.Exception ex)
                 {
                     log.Error("添加自动授权发生异常：" + ex.Message, ex);
                     WinInfoHelper.ShowInfoWindow(this, "添加自动授权发生异常，异常信息：" + ex.Message);
                 }
             });
            waiting.Show(this);
        }
    }
}
