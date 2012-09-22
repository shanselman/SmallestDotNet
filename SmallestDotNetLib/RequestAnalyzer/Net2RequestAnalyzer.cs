using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    public class Net2RequestAnalyzer : NetPre4RequestAnalyzer
    {
        public Net2RequestAnalyzer(Net4BetaRequestAnalyzer net4BetaRequestAnalyzer)
            : base(net4BetaRequestAnalyzer)
        {
        }

        public override string GetInfoString(System.Web.HttpRequestBase request)
        {
            if (this.Is40BetaInstalled(request))
            {
                this.Message = this.GetBetaInfoString(request);
            }

            Version version = request.Browser.ClrVersion;

            if (version != null && version.Major != 0)
            {
                string explain = string.Format(Constants.whyItIsSmallMessage, "around 33");

                this.Message += string.Format(@"Looks like you {2} have <strong>.NET version 2.0</strong>. 
                     That's a fairly recent version of the .NET Framework, but you can upgrade fairly easily to the newest version by downloading the 2.8 meg ""bootstrapper"" for {0}. {1}", Constants.htmlLinkToDotNet35Download, explain, this.Is40BetaInstalled(request) ? "also" : "");
            }

            return this.Message;
        }
    }
}
