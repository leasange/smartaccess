using DevComponents.Editors;
using Li.Access.Core;
using SmartAccess.Common;
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
        private Dictionary<string, CardIssueModel> CardCardIssueModelDic = new Dictionary<string, CardIssueModel>();
        public FrmCardIssueSetting()
        {
            InitializeComponent();

            try
            {
                string str = SunCreate.Common.ConfigHelper.GetConfigString("CARD_ISSUE_DIC");
                if (!string.IsNullOrWhiteSpace(str))
                {
                    string[] temps = str.Split(';');
                    foreach (var item in temps)
                    {
                        if (string.IsNullOrWhiteSpace(item))
                        {
                            continue;
                        }
                        string[] kvs = item.Split(',');
                        string card = null;
                        CardIssueModel m = CardIssueModel.HY_EM800A;
                        foreach (var kv in kvs)
                        {
                            string[] tts = kv.Split('=');
                            if (tts.Length != 2)
                            {
                                continue;
                            }
                            string key = tts[0].Trim().ToUpper();
                            string val = tts[1].Trim();
                            switch (key)
                            {
                                case "CARD":
                                    card = val;
                                    break;
                                case "MODEL":
                                    Enum.TryParse<CardIssueModel>(val, out m);
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (card != null)
                        {
                            if (!CardCardIssueModelDic.ContainsKey(card))
                            {
                                CardCardIssueModelDic.Add(card, m);
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                 
            }
           
        }

        private void FrmCardIssueSetting_Load(object sender, EventArgs e)
        {
            if (CardCardIssueModelDic.Count>0)
            {
                foreach (var item in CardCardIssueModelDic)
                {
                    ComboItem cbo = new ComboItem();
                    cbo.Text = item.Key;
                    cbo.Tag = item.Value;
                    cboCardModel.Items.Add(cbo);
                }
            }
            cboCardModel.SelectedIndex = 0;

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
            SmtLog.Info("配置", "修改读卡器端口");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cboCardModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCardModel.SelectedIndex==0)
            {
                return;
            }
            else if (cboCardModel.SelectedIndex>0)
            {
                CardIssueModel model = (CardIssueModel)((ComboItem)cboCardModel.SelectedItem).Tag;
                foreach (ComboItem item in cboModel.Items)
                {
                    if ((CardIssueModel)((ComboItem)cboCardModel.SelectedItem).Tag == model)
                    {
                        cboModel.SelectedItem = item;
                        break;
                    }
                }
            }
        }
    }
}
