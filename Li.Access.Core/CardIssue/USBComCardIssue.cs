using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace Li.Access.Core.CardIssue
{
    public class USBComCardIssue : ICardIssueDevice
    {
        private SerialPort serialPort = null;
        private string lastRead = null;
        public void Close()
        {
            if (serialPort!=null)
            {
                serialPort.Close();
                serialPort.Dispose();
                serialPort = null;
            }
        }

        public void Dispose()
        {
            Close();
        }

        public bool IsOpen()
        {
            if (serialPort!=null)
            {
                return serialPort.IsOpen;
            }
            return false;
        }

        public void OpenCom(int port, ComBuad baud)
        {
            if (serialPort != null)
            {
                serialPort.Close();
                serialPort.Dispose();
                serialPort = null;
            }
            serialPort = new SerialPort("COM" + port, (int)baud);
            serialPort.ReadTimeout = 2000;
            serialPort.Open();
            serialPort.DataReceived += SerialPort_DataReceived;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                lastRead = serialPort.ReadLine();
            }
            catch (Exception)
            {
                
            }
        }

        public byte[] ReadCard()
        {
            lastRead = null;
            int count = 100;
            while (lastRead == null && count >= 0)
            {
                Thread.Sleep(100);
                count--;
            }
            if (lastRead==null)
            {
                return null;
            }
            lastRead = lastRead.Trim(' ', '\r', '\n');
            uint ret = 0;
            if(uint.TryParse(lastRead, out ret))
            {
                return DataHelper.ToBytesFromUint(ret);
            }
            return null;
        }

        public string ReadCardX()
        {
            byte[] bts = ReadCard();
            return DataHelper.GetHexString(bts, 0, bts.Length);
        }
    }
}
