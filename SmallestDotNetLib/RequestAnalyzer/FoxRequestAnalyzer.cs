using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    using System.Web;
    public class FoxRequestAnalyzer : RequestAnalyzer
    {
        public override string GetInfoString(HttpRequestBase request, string message = null)
        {
            if (request.UserAgent.Contains("fox"))
            {
                return string.Format(@"Looks like you're running FireFox. That's totally cool, but if you've got a version of .NET earlier than 3.5 SP1, I can't tell if you've got .NET installed from FireFox. 
                   Consider visiting this site, just once, using Internet Explorer, which will tell me more about if your system has .NET on it or not. 
                  Alternatively, if you're running Windows, you can go <strong>download the 2.8 meg installer for {0}.</strong> 
                  Also, you might make sure your system is setup to get updates from {1} automatically. 
                  This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.htmlLinkToDotNet35Download, Constants.htmlLinkToWindowsUpdate);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
