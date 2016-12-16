using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Li.UdpMessageQueue
{
    public class BrokerClient
    {
        private DateTime lastHeart = DateTime.Now;
        private string clientId = null;

        public string ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }
        public DateTime LastHeart
        {
            get { return lastHeart; }
            set { lastHeart = value; }
        }
        private IPEndPoint clientPoint = null;

        public IPEndPoint ClientPoint
        {
            get { return clientPoint; }
            set { clientPoint = value; }
        }
        public BrokerClient(IPEndPoint clientPoint, string clientId)
        {
            this.clientPoint = clientPoint;
            this.clientId = clientId;
        }

    }
}
