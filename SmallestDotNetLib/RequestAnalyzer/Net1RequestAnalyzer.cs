using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    public class Net1RequestAnalyzer : NetPre4RequestAnalyzer
    {
        public Net1RequestAnalyzer(Net4BetaRequestAnalyzer net4BetaRequestAnalyzer)
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

            string netInfoString = string.Empty;

            switch (version.Minor)
            {
                case 0:
                case 1:
                    {
                        string explain = string.Format(Constants.whyItIsSmallMessage, "around 45-60");
                        this.Message += string.Format("Looks like you've {3} got a <strong>pretty old version of .NET</strong>. You should make sure your computer is up to date by visiting {0} then downloading the {1} from Microsoft. {2}", Constants.htmlLinkToWindowsUpdate, Constants.htmlLinkToDotNet35Download, explain, this.Is40BetaInstalled(request) ? "also" : "");
                    }
                    break;
            }

            return netInfoString;
        }
    }
}
