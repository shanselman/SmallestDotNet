using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib
{
    using System.Web;

    internal class RequestAnalyzerHttpRequest : HttpRequestBase
    {
        private readonly string userAgent;

        private readonly HttpBrowserCapabilitiesBase browser;

        public RequestAnalyzerHttpRequest(HttpBrowserCapabilitiesBase browser, string userAgent)
        {
            this.browser = browser;

            this.userAgent = userAgent;
        }

        public override string UserAgent
        {
            get
            {
                return this.userAgent;
            }
        }

        public override HttpBrowserCapabilitiesBase Browser
        {
            get
            {
                return this.browser;
            }
        }
    }
}
