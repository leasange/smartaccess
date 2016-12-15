using Li.UdpBroadcastMessage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestAccessCtrler
{
    public partial class FrmUdpBroadcastTest : Form
    {
        private BroadcastServer server = null;
        private BroadcastClient client = null;
        class ALARM_INFO
        {
            public string Test="dddd";
        }
        public FrmUdpBroadcastTest()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            server.SendMessageAsync<ALARM_INFO>(new ALARM_INFO());
        }

        private void FrmUdpBroadcastTest_Load(object sender, EventArgs e)
        {
            server = new BroadcastServer();
            client = new BroadcastClient();
            client.MessageRecieved += client_MessageRecieved;
            client.Start();
        }

        void client_MessageRecieved(MessageType msgType, string msg)
        {
            if (msgType== MessageType.ALARM)
            {
                this.Invoke(new Action(() =>
                {
                    tbMsg.AppendText("接收到报警消息：" + msg+"\r\n");
                    ALARM_INFO info = client.ParseMessage<ALARM_INFO>(msg);
                    MessageBox.Show(info.Test);
                }));
            }
        }
    }
}
