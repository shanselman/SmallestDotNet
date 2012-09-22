using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    public class Net3RequestAnalyzer : NetPre4RequestAnalyzer
    {
        public Net3RequestAnalyzer(Net4BetaRequestAnalyzer net4BetaRequestAnalyzer)
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
                switch (version.Minor)
                {
                    case 0:
                        {
                            string formatOfNetInfoString = @"Looks like you {2} have <strong>.NET version 3.0</strong>. 
                That's a very recent version of the .NET Framework, but you can upgrade fairly easily to the 3.5 version by downloading the 2.8 meg installer for {0}. {1}";

                            string explain = string.Format(Constants.whyItIsSmallMessage, "only 10");
                            this.Message += string.Format(formatOfNetInfoString, Constants.htmlLinkToDotNet35Download, explain, this.Is40BetaInstalled(request) ? "also" : "");
                        }
                        break;
                    case 5:
                        switch (version.Build)
                        {
                            case 21022: //RTM
                                this.Message += string.Format("Looks like you {2} have <strong>.NET version 3.5</strong>. The latest version is 3.5 SP1. You can upgrade quickly with this small download for {0}. Also, you should make sure your system is setup to get updates from {1} automatically. This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.htmlLinkToDotNet35Download, Constants.htmlLinkToWindowsUpdate, this.Is40BetaInstalled(request) ? "also" : "");
                                break;
                            case 30729: //SP1
                                this.Message += string.Format("Looks like you {1} have <strong>.NET version 3.5 SP1</strong>. That's the VERY latest .NET Framework. <strong>You don't need to do anything right now.</strong> However, you might make sure your system is setup to get updates from {0} automatically. This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.htmlLinkToWindowsUpdate, this.Is40BetaInstalled(request) ? "also" : "");
                                break;
                            default:
                                this.Message += string.Format("Looks like you <i>might</i> {2} have a <em>beta</em> version of <strong>.NET version 3.5 SP1</strong>. Perhaps you're a programmer or you know one? You should probably uninstall that version and run the small setup program for {0}. Also, you might make sure your system is setup to get updates from {1} automatically. This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.htmlLinkToDotNet35Download, Constants.htmlLinkToWindowsUpdate, this.Is40BetaInstalled(request) ? "also" : "");
                                break;
                        }
                        break;
                }                
            }

            return this.Message;
        }
    }
}
