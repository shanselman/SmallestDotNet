using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    using System.Web;

    public class NixRequestAnalyzer : RequestAnalyzer
    {
        public override string GetInfoString(HttpRequestBase request, string message = null)
        {
            if (request.UserAgent.Contains("nix"))
            {
                return "It looks like you're running a Unix machine. There's no .NET Framework download from Microsoft for Unix, but you might check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on Unix.";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
