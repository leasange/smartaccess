using Li.Access.Core;
using Li.Access.Core.BJTWHCardIssue;
using Li.Access.Core.CardIssue;
using SmartAccess.Common.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartAccess.VerInfoMgr
{
    public class USBInCardIssueDevice : ICardIssueDevice
    {
        public void OpenCom(int port, ComBuad baud)
        {
            return;
        }

        public bool IsOpen()
        {
            return true;
        }

        public void Close()
        {
            
        }

        public byte[] ReadCard()
        {
            string str = ReadCardX();
            if (str==null)
            {
                return null;
            }
            return DataHelper.ToBytesFromHexString(str);
        }

        public string ReadCardX()
        {
            string cardNo = "";
            Application.OpenForms[0].Invoke(new Action(() =>
                {
                    FrmUSBInput input = new FrmUSBInput();
                    if(input.ShowDialog()==DialogResult.OK)
                    {
                        cardNo = input.CardNo;
                    }
                }));
            if (cardNo=="")
            {
                return null;
            }
            else
            {
                return cardNo;
            }
        }

        public void Dispose()
        {
            
        }
    }

    public class CardIssueDeviceHelper
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(CardIssueDeviceHelper));
        private static ICardIssueDevice GetDevice(out  CardIssueConfig config)
        {
            config = SysConfig.GetCardIssueConfig();
            ICardIssueDevice issDevice = null;
            switch (config.cardIssueModel)
            {
                case CardIssueModel.HY_EM800A:
                    issDevice = new MF800ACardIssueDevice();
                    break;
                case CardIssueModel.USB_INTCARD:
                    issDevice = new USBInCardIssueDevice();
                    break;
                case CardIssueModel.USB_COM_CARD:
                    issDevice = new USBComCardIssue();
                    break;
            }
            return issDevice;
        }
        public static bool ReadCard(out string num, out string wgNum, out string errorMsg)
        {
            num = null;
            wgNum = null;
            errorMsg = null;
            CardIssueConfig config;
            ICardIssueDevice issDevice = CardIssueDeviceHelper.GetDevice(out config);
            if (issDevice == null)
            {
                errorMsg = "未成功初始化读卡器，请检查读卡器配置！";
                return false;
            }
            using (issDevice)
            {
                try
                {
                    issDevice.OpenCom(config.comPort, config.comBuad);
                    num = issDevice.ReadCardX();
                    issDevice.Close();
                    if (num == null)
                    {
                        errorMsg = "未读取到卡号！";
                        return false;
                    }
                    else
                    {
                        wgNum = num;
                        if (config.cardIssueModel == CardIssueModel.HY_EM800A)
                        {
                            wgNum = DataHelper.ToWGAccessCardNo(num);
                        }
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    errorMsg = "读取卡号异常：" + ex.Message;
                    log.Error("读取卡号异常：", ex);
                    return false;
                }
            }
        }
    }
}
