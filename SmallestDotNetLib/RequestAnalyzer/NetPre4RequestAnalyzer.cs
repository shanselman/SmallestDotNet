using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    using System.Web;

    public abstract class NetPre4RequestAnalyzer : RequestAnalyzer
    {
        private readonly Net4BetaRequestAnalyzer net4BetaRequestAnalyzer;

        public NetPre4RequestAnalyzer(Net4BetaRequestAnalyzer net4BetaRequestAnalyzer)
        {
            this.net4BetaRequestAnalyzer = net4BetaRequestAnalyzer;
        }

        protected bool Is40BetaInstalled(HttpRequestBase request)
        {
            return this.net4BetaRequestAnalyzer.Is40BetaInstalled(request);
        }

        protected string GetBetaInfoString(HttpRequestBase request)
        {
            return this.net4BetaRequestAnalyzer.GetInfoString(request);
        }
    }
}
