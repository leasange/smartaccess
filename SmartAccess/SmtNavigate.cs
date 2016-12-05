using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Li.Controls;
using System.Reflection;

namespace SmartAccess
{
    public partial class SmtNavigate : UserControl
    {
        private List<ExpandItem> MenuItems = new List<ExpandItem>();
        public FrmMain Main = null;
        public SmtNavigate()
        {
            InitializeComponent();
            navigateItems.ClearExpands();

            ExpandItem verMgr = new ExpandItem("证件信息管理", Properties.Resources.证件管理, SYS_FUN_POINT.VER_INFO_MGR);
            verMgr.Items.AddRange(new ExpandItem[]
                {
                    new ExpandItem("证件编码", Properties.Resources.证件管理, SYS_FUN_POINT.VER_CODE,typeof(VerInfoMgr.VerCodeInfo)),
                    new ExpandItem("证件模板", Properties.Resources.dkq_2525, SYS_FUN_POINT.VER_MODEL,typeof(ModelMgr.VerModelMgr)),
                    new ExpandItem("部门管理", Properties.Resources.部门管理, SYS_FUN_POINT.DEPT_MGR,typeof(VerInfoMgr.DeptMgr)),
                    new ExpandItem("人员信息", Properties.Resources.人员信息, SYS_FUN_POINT.STAFF_MGR,typeof(VerInfoMgr.StaffInfoMgr))
                });
            MenuItems.Add(verMgr);
            /*
            ExpandItem modelMgr = new ExpandItem("模板设定管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.MODEL_INFO_MGR);
            modelMgr.Items.AddRange(new ExpandItem[]
                {
                    new ExpandItem("证件模板", Properties.Resources.dkq_2525, SYS_FUN_POINT.VER_MODEL,typeof(ModelMgr.VerModelMgr))
                });
            MenuItems.Add(modelMgr);
            */

            ExpandItem infoSearchMgr = new ExpandItem("信息系统查询", Properties.Resources.dkq_2525, SYS_FUN_POINT.SEARCH_INFO_MGR);
            infoSearchMgr.Items.AddRange(new ExpandItem[]
                {
                    new ExpandItem("门禁出入查询", Properties.Resources.门禁出入查询, SYS_FUN_POINT.ACCESS_RECORD,typeof(InfoSearchMgr.AccessInOutRecordInfos)),
                    new ExpandItem("人员轨迹查询", Properties.Resources.dkq_2525,SYS_FUN_POINT.STAFF_ROUTE,typeof(InfoSearchMgr.StaffRouteInfo)),
                    new ExpandItem("操作日志查询", Properties.Resources.dkq_2525, SYS_FUN_POINT.LOG_INFO,typeof(InfoSearchMgr.OprLogsInfo))
                });
            MenuItems.Add(infoSearchMgr);

            ExpandItem staMgr = new ExpandItem("报表统计管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.REPORT_INFO_MGR);
            staMgr.Items.AddRange(new ExpandItem[]
                {
                    new ExpandItem("门禁出入统计", Properties.Resources.dkq_2525, SYS_FUN_POINT.ACCESS_RECORD_STA,typeof(StatisticsMgr.AccessInOutRecordsStatistics))
                });
            MenuItems.Add(staMgr);

            ExpandItem ctrlMgr = new ExpandItem("控制设备管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.CTRLR_INFO_MGR);
            ctrlMgr.Items.AddRange(new ExpandItem[]
                {
                     new ExpandItem("控制器管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.CTRLR_INFO,typeof(ControlDevMgr.ControllerMgr)),
                     //new ExpandItem("一卡多门管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.,),
                    // new ExpandItem("控制访问约束", Properties.Resources.dkq_2525, SYS_FUN_POINT., ItemClicked)
                });
            MenuItems.Add(ctrlMgr);

            ExpandItem realMgr = new ExpandItem("实时监控管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.REAL_DETECT_MGR);
            realMgr.Items.AddRange(new ExpandItem[]
                {
                    new ExpandItem("实时地图显示", Properties.Resources.dkq_2525, SYS_FUN_POINT.REAL_MAP, typeof(RealDetectMgr.RealMapDetect)),
                    new ExpandItem("实时状态显示", Properties.Resources.dkq_2525, SYS_FUN_POINT.REAL_ACCESS_STATE, typeof(RealDetectMgr.RealDoorState))
                 });
            MenuItems.Add(realMgr);

            ExpandItem ruleMgr = new ExpandItem("规则设定管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.RULE_INFO_MGR);
            ruleMgr.Items.AddRange(new ExpandItem[]
                {
                    new ExpandItem("控制定时任务", Properties.Resources.dkq_2525, SYS_FUN_POINT.CTRLR_TASK, typeof(RuleSetMrg.DoorRuleCtrlTask)),
                    //expand.AddItem("一般规则设定", Properties.Resources.dkq_2525, null, ItemClicked)
                });
            MenuItems.Add(ruleMgr);

            ExpandItem configMgr = new ExpandItem("系统配置管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.SYS_CONFIG_MGR);
            configMgr.Items.AddRange(new ExpandItem[]
                {
                    new ExpandItem("地图编辑配置", Properties.Resources.dkq_2525, SYS_FUN_POINT.MAP_CONFIG, typeof(ConfigMgr.MapsMgr)),
                    new ExpandItem("发卡配置管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.CARD_CONFIG, typeof(SmartAccess.ConfigMgr.FrmCardIssueSetting)),
                    new ExpandItem("门禁密码管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.ACCESS_PASSWORD_CONFIG, typeof(SmartAccess.ConfigMgr.AccessPasswordMgr)),
                    new ExpandItem("出入时段管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.INOUT_TIME_CONFIG, typeof(SmartAccess.ConfigMgr.InOutTimeCfg)),
                    new ExpandItem("报警联动设定", Properties.Resources.dkq_2525, SYS_FUN_POINT.ALARM_CONNECT_SETTING, typeof(SmartAccess.ConfigMgr.FrmAlarmSetting)),
                    new ExpandItem("数据备份管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.DATABASE_BACK_CONFIG, null),
                    new ExpandItem("修改用户密码", Properties.Resources.dkq_2525, SYS_FUN_POINT.MODIFY_PWD_CONFIG, typeof(SmartAccess.ConfigMgr.FrmModifyUserPwd)),
                    new ExpandItem("系统使用说明", Properties.Resources.dkq_2525, SYS_FUN_POINT.SYS_README_CONFIG, null),
                    new ExpandItem("用户权限管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.USER_PRIVATE_CONFIG, typeof(SmartAccess.ConfigMgr.UserManager))
             });
            MenuItems.Add(configMgr);
// 
// 
//             CreateVerMgr();
//             CreateModelMgr();
//             CreateSearchMgr();
//             CreateReportMgr();
//             CreateCtrlrMgr();
//             CreateRealDectMgr();
//             CreateRuleMgr();
//             CreateConfigMgr();
            foreach (ExpandItem expand in MenuItems)
            {
                ExpandablePanelX panel = CreateExpand(expand);
                if (panel==null)
                {
                    continue;
                }
                foreach (var item in expand.Items)
                {
                    CreateSubItem(panel, item);
                }
            }
            var list = navigateItems.Expands;
            if (list.Count>0)
            {
                navigateItems.ExpandedPanel = list[0]; 
            }           
        }
        private ExpandablePanelX CreateExpand(ExpandItem expand)
        {
            if (!HasPrivate(expand.funPoint))
            {
                return null;
            }
            var ntime = navigateItems.AddExpand(expand.name, expand.image, expand.funPoint);
            return ntime;
        }
        private void CreateSubItem(ExpandablePanelX expand, ExpandItem item)
        {
            if (!HasPrivate(item.funPoint))
            {
                return;
            }
            expand.AddItem(item.name, item.image, item, ItemClicked);
        }

        public bool HasPrivate(SYS_FUN_POINT funPoint)
        {
            if (DesignMode)
            {
                return true;
            }
            return PrivateMgr.FUN_POINTS.Contains(funPoint);
        }

        private void ShowItem(ExpandItem item)
        {
            if (item.controlType!=null)
            {
                Control ctrl = Activator.CreateInstance(item.controlType) as Control;
                if (ctrl!=null)
                {
                    if (Main != null)
                    {
                        if (ctrl is Form)
                        {
                            Form frm = (Form)ctrl;
                            frm.ShowDialog(this);
                        }
                        else
                        {
                            if (!Main.CheckControl(item.controlType))
                            {
                                Main.AddControl(ctrl, item.name,item.image);
                            }
                        }
                    }
                }
            }
        }

        public void CreateVerMgr()
        {
            var expand = navigateItems.AddExpand("证件信息管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.VER_INFO_MGR);
            var vercode = expand.AddItem("证件编码", Properties.Resources.dkq_2525, SYS_FUN_POINT.VER_CODE, ItemClicked);
            var deptmgr = expand.AddItem("部门管理", Properties.Resources.dkq_2525, SYS_FUN_POINT.DEPT_MGR, ItemClicked);
            var staffInfo = expand.AddItem("人员信息", Properties.Resources.dkq_2525, SYS_FUN_POINT.STAFF_MGR, ItemClicked);
            expand.Expanded = true;
        }
//         public void CreateInfoBatchMgr()
//         {
//             var expand = navigateItems.AddExpand("信息批量处理", Properties.Resources.dkq_2525);
//             var vercode = expand.AddItem("证件编码", Properties.Resources.dkq_2525, null, ItemClicked);
//             var deptmgr = expand.AddItem("部门管理", Properties.Resources.dkq_2525, null, ItemClicked);
//             var staffInfo = expand.AddItem("人员信息", Properties.Resources.dkq_2525, null, ItemClicked);
//         }
        public void CreateModelMgr()
        {
            var expand = navigateItems.AddExpand("模板设定管理", Properties.Resources.dkq_2525);
            expand.AddItem("证件模板", Properties.Resources.dkq_2525, null, ItemClicked);
        }
        public void CreateSearchMgr()
        {
            var expand = navigateItems.AddExpand("信息系统查询", Properties.Resources.dkq_2525);
            expand.AddItem("门禁出入查询", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.AddItem("人员轨迹查询", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.AddItem("操作日志查询", Properties.Resources.dkq_2525, null, ItemClicked);
        }
        public void CreateReportMgr()
        {
            var expand = navigateItems.AddExpand("报表统计管理", Properties.Resources.dkq_2525);
            expand.AddItem("门禁出入统计", Properties.Resources.dkq_2525, null, ItemClicked);
        }
        public void CreateCtrlrMgr()
        {
            var expand = navigateItems.AddExpand("控制设备管理", Properties.Resources.dkq_2525);
            expand.AddItem("控制器管理", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.AddItem("一卡多门管理", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.AddItem("控制访问约束", Properties.Resources.dkq_2525, null, ItemClicked);
        }
        public void CreateRealDectMgr()
        {
            var expand = navigateItems.AddExpand("实时监控管理", Properties.Resources.dkq_2525);
            expand.AddItem("实时地图显示", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.AddItem("实时状态显示", Properties.Resources.dkq_2525, null, ItemClicked);
        }
        public void CreateRuleMgr()
        {
            var expand = navigateItems.AddExpand("规则设定管理", Properties.Resources.dkq_2525);
            expand.AddItem("控制定时任务", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.AddItem("一般规则设定", Properties.Resources.dkq_2525, null, ItemClicked);
        }
        public void CreateConfigMgr()
        {
            var expand = navigateItems.AddExpand("系统配置管理", Properties.Resources.dkq_2525);
            expand.AddItem("地图编辑配置", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.AddItem("发卡配置管理", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.AddItem("门禁密码管理", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.AddItem("出入时段管理", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.AddItem("数据备份管理", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.AddItem("修改用户密码", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.AddItem("系统使用说明", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.AddItem("用户权限管理", Properties.Resources.dkq_2525, null, ItemClicked);
            //expand.AddItem("更换卡片介质", Properties.Resources.dkq_2525, null, ItemClicked);
        }
        private void ItemClicked(object sender,EventArgs args)
        {
            LinkLabel ll=(LinkLabel)sender;
            ShowItem((ExpandItem)ll.Tag);
        }
    }
    public class ExpandItem
    {
        public string name;
        public Image image;
        public SYS_FUN_POINT funPoint;
        public Type controlType;
        public List<ExpandItem> Items = new List<ExpandItem>();
        public ExpandItem(string name, Image image, SYS_FUN_POINT funPoint, Type controlType=null)
        {
            this.name = name;
            this.image = image;
            this.funPoint = funPoint;
            this.controlType = controlType;
        }
    }
}
