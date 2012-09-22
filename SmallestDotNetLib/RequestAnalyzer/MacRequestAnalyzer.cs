using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    public class MacRequestAnalyzer : RequestAnalyzer
    {
        public override string GetInfoString(System.Web.HttpRequestBase request)
        {
            if (request.UserAgent.Contains("Mac"))
            {
                return  "It looks like you're running a Mac. There's no .NET Framework download from Microsoft for the Mac, but you might check out either <a href=\"http://www.microsoft.com/silverlight/resources/install.aspx\">Silverlight</a> which is a browser plugin that includes a small version of the .NET Framework. You could also check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on a Mac.";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
