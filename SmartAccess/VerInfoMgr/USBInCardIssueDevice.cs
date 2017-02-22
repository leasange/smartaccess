using Li.Access.Core;
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
}
