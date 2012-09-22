using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    using System.Web;

    public abstract class RequestAnalyzer : IRequestAnalyzer
    {
        public abstract string GetInfoString(HttpRequestBase request, string message = null);

        public string GetInfoString(string userAgent, Version browserVersion, string message = null)
        {
            var browserCapabilities = new RequestAnalyzerHttpBrowserCapabilities(browserVersion);

            return GetInfoString(new RequestAnalyzerHttpRequest(browserCapabilities, userAgent), message);
        }
    }
}
