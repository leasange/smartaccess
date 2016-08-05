﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace SmartAccess
{
    public partial class FrmMain : DevComponents.DotNetBar.Office2007Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ExpandablePanel fexpanel = splitContainer.Panel1.Controls[splitContainer.Panel1.Controls.Count-1] as ExpandablePanel;
            foreach (Control item in splitContainer.Panel1.Controls)
            {
                ExpandablePanel expanel = item as ExpandablePanel;
                if (expanel != null)
                {
                    expanel.ExpandedChanging += expanel_ExpandedChanging;
                    expanel.ExpandedChanged += expanel_ExpandedChanged;
                }
            }
            fexpanel.Expanded = false;
            fexpanel.Expanded = true;
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
            expanel.Height = splitContainer.Panel1.Height - expanel.TitleHeight * (splitContainer.Panel1.Controls.Count - 1);
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
            return DevComponents.DotNetBar.TaskDialog.Show("退出系统", eTaskDialogIcon.Help, "退出", "确定退出系统？", eTaskDialogButton.Ok | eTaskDialogButton.Cancel) == eTaskDialogResult.Ok;
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

        private bool CheckControl(Type ctrlType)
        {
            foreach (SuperTabItem item in this.superTabControl.Tabs)
            {
                if(item.AttachedControl.Controls[0].GetType()==ctrlType)
                {
                    this.superTabControl.SelectedTab = item;
                    return true;
                }
            }
            return false;
        }
        private void AddControl(Control ctrl,string title)
        {
            // 
            // superTabItem
            // 
            SuperTabItem superTabItem = new SuperTabItem();
            SuperTabControlPanel superTabControlPanel = new SuperTabControlPanel();

            superTabItem.AttachedControl = superTabControlPanel;
            superTabItem.CloseButtonVisible = true;
            superTabItem.GlobalItem = false;
            superTabItem.Image = Properties.Resources.editor;
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
                AddControl(new VerInfoMgr.DeptMgr(), "部门管理");
            }
        }

        private void linkStaffInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!CheckControl(typeof(VerInfoMgr.StaffInfoMgr)))
            {
                AddControl(new VerInfoMgr.StaffInfoMgr(), "人员信息");
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
                AddControl(new InfoSearchMgr.AccessInOutRecordInfos(), "门禁出入查询");
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
                AddControl(new ControlDevMgr.ControllerMgr(), "搜索控制管理");
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
            if (!CheckControl(typeof(ControlDevMgr.ControlState)))
            {
                AddControl(new ControlDevMgr.ControlState(), "控制访问约束");
            }
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
            if (!CheckControl(typeof(RuleSetMrg.DoorRuleCtrlSet)))
            {
                AddControl(new RuleSetMrg.DoorRuleCtrlSet(), "控制方式设定");
            }
        }

        private void linkRuleSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkMapEditor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkAccessPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkInOutTimeSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkDbBak_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkModifyUserPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkUserUse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkProPrivi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkChangeCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
