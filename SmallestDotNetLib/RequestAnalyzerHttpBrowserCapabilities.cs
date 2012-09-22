using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib
{
    using System.Web;

    internal class RequestAnalyzerHttpBrowserCapabilities : HttpBrowserCapabilitiesBase
    {
        private readonly Version version;

        internal RequestAnalyzerHttpBrowserCapabilities(Version version)
        {
            this.version = version;
        }

        public override Version ClrVersion
        {
            get
            {
                return this.version;
            }
        }
    }
}
