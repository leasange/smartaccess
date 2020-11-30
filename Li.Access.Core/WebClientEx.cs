using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Li.Access.Core
{
    public class WebClientEx : WebClient
    {
        private CookieContainer _cookieContainer = new CookieContainer();

        public CookieContainer CookieContainer { get => _cookieContainer; set => _cookieContainer = value; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
                (request as HttpWebRequest).CookieContainer = this.CookieContainer;
            return request;
        }
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            var r = base.GetWebResponse(request);
            if (r is HttpWebResponse)
            {
                this.CookieContainer.Add((r as HttpWebResponse).Cookies);
            }
            return r;
        }
    }
}
