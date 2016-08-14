using DevComponents.Editors;
using Li.Access.Core;
using SmartAccess.Common.Config;
using SmartAccess.Common.WinInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.ConfigMgr
{
    public partial class FrmCardIssueSetting : DevComponents.DotNetBar.Office2007Form
    {
        public FrmCardIssueSetting()
        {
            InitializeComponent();
        }

        private void FrmCardIssueSetting_Load(object sender, EventArgs e)
        {
            CardIssueConfig config = SysConfig.GetCardIssueConfig();
            if (config.comPort <= 10 && config.comPort > 0)
            {
                cboPort.SelectedIndex = config.comPort - 1;
            }
            Array arrayModel = Enum.GetValues(typeof(CardIssueModel));
            foreach (CardIssueModel item in arrayModel)
            {
                ComboItem cbo = new ComboItem();
                cbo.Text = item.ToString();
                cbo.Tag = item;
                cboModel.Items.Add(cbo);
                if (config.cardIssueModel==item)
                {
                    cboModel.SelectedItem = cbo; 
                }
            }
            Array arrayBaud = Enum.GetValues(typeof(ComBuad));
            foreach (ComBuad item in arrayBaud)
            {
                ComboItem cbo = new ComboItem();
                cbo.Text = item.ToString();
                cbo.Tag = item;
                cboBaud.Items.Add(cbo);
                if (config.comBuad == item)
                {
                    cboBaud.SelectedItem = cbo;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int port = cboPort.SelectedIndex + 1;
            if (port<=0)
            {
                WinInfoHelper.ShowInfoWindow(this, "端口不能为空！");
                cboPort.Focus();
                return;
            }
            if (cboModel.SelectedItem==null)
            {
                WinInfoHelper.ShowInfoWindow(this, "型号不能为空！");
                cboModel.Focus();
                return;
            }
            if (cboBaud.SelectedItem == null)
            {
                WinInfoHelper.ShowInfoWindow(this, "波特率不能为空！");
                cboBaud.Focus();
                return;
            }
            CardIssueConfig config = new CardIssueConfig();
            config.comPort = port;
            config.cardIssueModel = (CardIssueModel)((ComboItem)cboModel.SelectedItem).Tag;
            config.comBuad = (ComBuad)((ComboItem)cboBaud.SelectedItem).Tag;
            SysConfig.SetCardIssueConfig(config);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
