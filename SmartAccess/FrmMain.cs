using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SmartAccess.ConfigMgr;
using SmartAccess.Common;
using SmartAccess.Common.WinInfo;
using SmartAccess.Common.Datas;
using System.IO;
using SmartAccess.Common.Config;
using SmartAccess.Common.Database;
using Li.UdpMessageQueue;
using SmartAccess.RealDetectMgr;
using System.Reflection;

namespace SmartAccess
{
    public partial class FrmMain : DevComponents.DotNetBar.Office2007Form
    {
        public static FrmMain Instance;
        public static StyleManager StyleMgr;
        private log4net.ILog log = log4net.LogManager.GetLogger(typeof(FrmMain));
        private ConsumerClient consumerClient = null;
        public FrmMain()
        {
            InitializeComponent();
            Instance = this;
            CreateStyleItems();
            SmtLog.Info("系统", "进入系统");

            LoadSys();
        }

        private void LoadSys()
        {
            //加载logo
            string logo = Path.Combine(Application.StartupPath, "Images\\企业logo.png");
            if (File.Exists(logo))
            {
                try
                {
                    panelHeader.Style.BackgroundImage = Image.FromFile(logo);
                }
                catch (Exception ex)
                {
                    log.Error("企业LOGO加载失败！", ex);
                }
            }
            //加载欢迎
            string welcome = Path.Combine(Application.StartupPath, "Images\\欢迎.png");
            if (File.Exists(welcome))
            {
                try
                {
                    panelWelCome.Style.BackgroundImage = Image.FromFile(welcome);
                }
                catch (Exception ex)
                {
                    log.Error("欢迎LOGO加载失败！", ex);
                }
            }
            this.Text = SunCreate.Common.ConfigHelper.GetConfigString("SysName");
            lbTitle.Text = SunCreate.Common.ConfigHelper.GetConfigString("SysTitle");
            this.Text += " v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            panelWelCome.Text = SunCreate.Common.ConfigHelper.GetConfigString("SysWelcomeText");
        }

        private void CreateStyleItems()
        {
            string[] names = Enum.GetNames(typeof(eStyle));
            foreach (var item in names)
	        {
                var itm = new ButtonItem(item, item);
                biSelectStyle.SubItems.Add(itm);
                itm.Click += sti_Click;
	        }
           
        }

        void sti_Click(object sender, EventArgs e)
        {
            eStyle es = (eStyle)Enum.Parse(typeof(eStyle), ((ButtonItem)sender).Text);
            StyleMgr.ManagerStyle = es;
            SunCreate.Common.ConfigHelper.SetConfigValue("SysStyle", es.ToString());
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            /*CtrlWaiting waiting = new CtrlWaiting("权限加载中...",() =>
            {
                try
                {
                    PrivateMgr.LoadPrivates();
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "权限加载异常："+ex.Message);
                }
              
            });
            waiting.ShowDialog(this);*/
            try
            {
                tsslStateUser.Text = UserInfoHelper.UserInfo.USER_NAME;
                DatabaseConfigClass config = SysConfig.GetSqlServerServerConfig();
                if (config != null)
                {
                    tsmiServerIp.Text = config.serverName;
                }
            }
            catch (Exception ex)
            {
                log.Error("读取配置异常：", ex);
            }
            smtNavigate.Main = this;
            try
            {
                if (PrivateMgr.FUN_POINTS.Contains(SYS_FUN_POINT.REAL_ALARM_DETECT))
                {
                    Maticsoft.BLL.SMT_DATADICTIONARY_INFO dicBll = new Maticsoft.BLL.SMT_DATADICTIONARY_INFO();
                    var configs = dicBll.GetModelList("DATA_TYPE='ALARM_INFO' and DATA_KEY='ALARM_SERVER'");
                    if (configs.Count > 0)
                    {
                        log.Info("报警服务器地址为：" + configs[0].DATA_VALUE);
                        consumerClient = new ConsumerClient(configs[0].DATA_VALUE);
                        consumerClient.MessageRecieved += consumerClient_MessageRecieved;
                        consumerClient.Start();
                    }
                    else
                    {
                        log.Error("没有报警服务器地址,请在数据库中配置报警服务地址！其中 DATA_TYPE='ALARM_INFO' and DATA_KEY='ALARM_SERVER' DATA_VALUE为配置值，如：192.168.1.1:56010");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("报警接收初始化异常：", ex);
            }
        }

        private void consumerClient_MessageRecieved(MessageType msgType, string msg)
        {
            if (msgType== MessageType.ALARM)
            {
                try
                {
                    decimal alarmId = consumerClient.ParseMessage<decimal>(msg);
                    this.Invoke(new Action(() =>
                    {
                        smtNavigate.ShowRealAlarm();
                    }));
                   
                    if (AlarmRealDetect.Instace != null)
                    {
                        AlarmRealDetect.Instace.AddRealAlarm(alarmId);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("报警接收处理异常：", ex);
                }

            }
        }

        void expanel_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
        {
            if (!e.NewExpandedValue)
            {
                return;
            }
            foreach (Control item in splitContainer.Panel1.Controls)
            {
                ExpandablePanel expanel = item as ExpandablePanel;
                if (expanel != null)
                {
                    if (expanel != sender)
                    {
                        expanel.Controls[0].Visible = false;
                        expanel.Expanded = false;
                    }
                }
            }
        }

        private void expanel_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            if (!e.NewExpandedValue)
            {
                return;
            }
            ExpandablePanel expanel = (ExpandablePanel)sender;
            int visiblecount = 0;
            foreach (Control item in splitContainer.Panel1.Controls )
            {
                if (item.Visible)
                {
                    visiblecount++;
                }
            }
            expanel.Height = splitContainer.Panel1.Height - expanel.TitleHeight * (visiblecount - 1);
            expanel.Controls[0].Visible = true;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            if (CheckDoExitSystem())
            {
                DoExitSystem();
            }
        }
        private bool CheckDoExitSystem()
        {
            bool ret = DevComponents.DotNetBar.TaskDialog.Show("退出系统", eTaskDialogIcon.Help, "退出", "确定退出系统？", eTaskDialogButton.Ok | eTaskDialogButton.Cancel) == eTaskDialogResult.Ok;
            if (ret)
            {
                if (consumerClient != null)
                {
                    consumerClient.Stop();
                }
                SmtLog.Info("系统", "退出系统");
            }
            return ret;
        }
        //退出系统
        private void DoExitSystem()
        {
            Application.Exit();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = !CheckDoExitSystem();
            }
        }

        public bool CheckControl(Type ctrlType,bool isselect=true)
        {
            foreach (SuperTabItem item in this.superTabControl.Tabs)
            {
                if(item.AttachedControl.Controls[0].GetType()==ctrlType)
                {
                    if (isselect)
                    {
                        this.superTabControl.SelectedTab = item;
                    }
                    return true;
                }
            }
            return false;
        }
        public void AddControl(Control ctrl, string title, Image image = null)
        {
            // 
            // superTabItem
            // 
            SuperTabItem superTabItem = new SuperTabItem();
            SuperTabControlPanel superTabControlPanel = new SuperTabControlPanel();

            superTabItem.AttachedControl = superTabControlPanel;
            superTabItem.CloseButtonVisible = true;
            superTabItem.GlobalItem = false;
            if (image==null)
            {
                image = Properties.Resources.editor;
            }
            superTabItem.Image = image;
            superTabItem.Text = title;
            // 
            // superTabControlPanel
            // 
            ctrl.Dock = DockStyle.Fill;
            superTabControlPanel.Controls.Add(ctrl);
            superTabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            //superTabControlPanel.Location = new System.Drawing.Point(0, 28);
            //superTabControlPanel.Size = new System.Drawing.Size(764, 608);
            superTabControlPanel.TabItem = superTabItem;
            this.superTabControl.Controls.Add(superTabControlPanel);

            this.superTabControl.Tabs.Add(superTabItem);
            this.superTabControl.SelectedTab = superTabItem;
        }

        private void linkVerCodeInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(VerInfoMgr.VerCodeInfo)))
            {
                AddControl(new VerInfoMgr.VerCodeInfo(), "证件编码");
            }
           
        }

        private void linkDeptMgr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(VerInfoMgr.DeptMgr)))
            {
                AddControl(new VerInfoMgr.DeptMgr(), "部门管理",Properties.Resources.部门管理);
            }
        }

        private void linkStaffInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(VerInfoMgr.StaffInfoMgr)))
            {
                AddControl(new VerInfoMgr.StaffInfoMgr(), "人员信息",Properties.Resources.人员信息);
            }
            
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(InfoBatchMgr.StaffInfosInput)))
            {
                AddControl(new InfoBatchMgr.StaffInfosInput(), "人员批量导入");
            }
        }

        private void linkCardsPrint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(InfoBatchMgr.CardsPrint)))
            {
                AddControl(new InfoBatchMgr.CardsPrint(), "卡片批量打印");
            }
        }

        private void linkVerModel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(ModelMgr.VerModelMgr)))
            {
                AddControl(new ModelMgr.VerModelMgr(), "证件模板管理");
            }
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(InfoSearchMgr.AccessInOutRecordInfos)))
            {
                AddControl(new InfoSearchMgr.AccessInOutRecordInfos(), "门禁出入查询",Properties.Resources.门禁出入查询);
            }
        }

        private void linkRouteSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(InfoSearchMgr.StaffRouteInfo)))
            {
                AddControl(new InfoSearchMgr.StaffRouteInfo(), "人员轨迹查询");
            }
        }

        private void linkOprLogSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(InfoSearchMgr.OprLogsInfo)))
            {
                AddControl(new InfoSearchMgr.OprLogsInfo(), "操作日志查询");
            }
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(StatisticsMgr.AccessInOutRecordsStatistics)))
            {
                AddControl(new StatisticsMgr.AccessInOutRecordsStatistics(), "门禁出入统计");
            }
        }

        private void linkControlerMgr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(ControlDevMgr.ControllerMgr)))
            {
                AddControl(new ControlDevMgr.ControllerMgr(), "控制器管理",Properties.Resources.控制器管理);
            }
        }

        private void linkOneMangMgr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(ControlDevMgr.OneManyDoorMgr)))
            {
                AddControl(new ControlDevMgr.OneManyDoorMgr(), "一对多管理");
            }
        }

        private void linkCtrlState_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             
        }

        private void linkRealMap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(RealDetectMgr.RealMapDetect)))
            {
                AddControl(new RealDetectMgr.RealMapDetect(), "实时地图显示");
            }
        }

        private void linkRealState_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(RealDetectMgr.RealDoorState)))
            {
                AddControl(new RealDetectMgr.RealDoorState(), "实时状态显示");
            }
        }

        private void linkCtrlStyle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(RuleSetMrg.DoorRuleCtrlTask)))
            {
                AddControl(new RuleSetMrg.DoorRuleCtrlTask(), "控制定时任务");
            }
        }

        private void linkRuleSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        //电子地图配置
        private void linkMapEditor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(MapsMgr)))
            {
                AddControl(new MapsMgr(), "地图编辑");
            }
        }

        private void linkAccessPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(AccessPasswordMgr)))
            {
                AddControl(new AccessPasswordMgr(), "门禁密码管理");
            }
        }
        //出入时段管理
        private void linkInOutTimeSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(InOutTimeCfg)))
            {
                AddControl(new InOutTimeCfg(), "出入时段管理");
            }
        }

        private void linkDbBak_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkModifyUserPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmModifyUserPwd frmModifyUserPwd = new FrmModifyUserPwd();
            frmModifyUserPwd.ShowDialog(this);
        }

        private void linkUserUse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkProPrivi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(UserManager)))
            {
                AddControl(new UserManager(), "用户权限管理");
            }
        }

        private void linkChangeCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkCardInssue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCardIssueSetting frmCardSetting = new FrmCardIssueSetting();
            frmCardSetting.ShowDialog(this);
        }

        private void biLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定注销系统？","提示",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                try
                {
                    if (consumerClient!=null)
                    {
                        consumerClient.Stop();
                    }
                    this.Dispose();
                    FrmLogin.Login.Enabled = true;
                    FrmLogin.Login.Visible = true;
                    FrmLogin.Login.WindowState = FormWindowState.Normal;
                    FrmLogin.Login.BringToFront();
                    FrmLogin.Login.Refresh();
                }
                catch (Exception ex)
                {
                    WinInfoHelper.ShowInfoWindow(this, "注销异常:"+ex.Message);
                    log.Error("注销异常：", ex);
                }

            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            tsmiNowTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
