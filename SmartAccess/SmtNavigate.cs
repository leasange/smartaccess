using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess
{
    public partial class SmtNavigate : UserControl
    {
        public SmtNavigate()
        {
            InitializeComponent();
            navigateItems.ClearExpands();
            CreateVerMgr();
            CreateModelMgr();
            CreateSearchMgr();
            CreateReportMgr();
            CreateCtrlrMgr();
            CreateRealDectMgr();
            CreateRuleMgr();
            CreateConfigMgr();
        }
        public void CreateVerMgr()
        {
            var expand = navigateItems.AddExpand("证件信息管理", Properties.Resources.dkq_2525);
            var vercode = expand.AddItem("证件编码", Properties.Resources.dkq_2525,null, ItemClicked);
            var deptmgr = expand.AddItem("部门管理", Properties.Resources.dkq_2525, null, ItemClicked);
            var staffInfo = expand.AddItem("人员信息", Properties.Resources.dkq_2525, null, ItemClicked);
            expand.Expanded = true;
        }
        public void CreateInfoBatchMgr()
        {
            var expand = navigateItems.AddExpand("信息批量处理", Properties.Resources.dkq_2525);
            var vercode = expand.AddItem("证件编码", Properties.Resources.dkq_2525, null, ItemClicked);
            var deptmgr = expand.AddItem("部门管理", Properties.Resources.dkq_2525, null, ItemClicked);
            var staffInfo = expand.AddItem("人员信息", Properties.Resources.dkq_2525, null, ItemClicked);
        }
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

        }
    }
}
