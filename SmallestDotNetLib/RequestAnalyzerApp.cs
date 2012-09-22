using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib
{
    using System.Web;
    using SmallestDotNetLib.RequestAnalyzer;

    public class RequestAnalyzerApp
    {
        private readonly IEnumerable<IRequestAnalyzer> requestAnalyzers;

        public RequestAnalyzerApp(IEnumerable<IRequestAnalyzer> requestAnalyzers)
        {
            this.requestAnalyzers = requestAnalyzers;
        }

        public string GetUpdateInformation(HttpRequestBase request)
        {
            string message = string.Empty;

            foreach (var requestAnalyzer in this.requestAnalyzers)
            {
                message = requestAnalyzer.GetInfoString(request, message);
            }

            return message;
        }

        public string GetUpdateInformation(string userAgent, Version version)
        {
            return this.GetUpdateInformation(new RequestAnalyzerHttpRequest(new RequestAnalyzerHttpBrowserCapabilities(version), userAgent));
        }
    }
}