using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    using System.Web;

    public class Net4BetaRequestAnalyzer : RequestAnalyzer
    {
        public bool Is40BetaInstalled(System.Web.HttpRequestBase request)
        {
            string[] identifiers = { ".NET4.0E", ".NET4.0C" };

            return identifiers.Any(i => request.UserAgent.Contains(i));
        }

        public override string GetInfoString(HttpRequestBase request, string message = null)
        {
            if (request.UserAgent.Contains(".NET4.0E"))
            {
                return string.Format("Seem you're an early adopter! You've got a <strong>full install of .NET 4.0</strong> on your machine. ");
            }
            else if (request.UserAgent.Contains(".NET4.0C"))
            {
                return string.Format("Seem you're an early adopter! You've got the <strong>.NET 4.0 Client Profile</strong> on your machine. ");
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
