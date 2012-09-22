using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    using System.Web;

    public class Windows2000RequestAnalyzer : RequestAnalyzer
    {
        public override string GetInfoString(HttpRequestBase request, string message = null)
        {
            if (request.UserAgent.Contains("Windows NT 5.0"))
            {
                message += String.Format("It looks like you're running Windows 2000. Sorry, but .NET 3.5 isn't supported on Windows 2000, but you can still run <a href=\"{0}\">NET Framework 2.0 SP1</a>", "http://www.microsoft.com/downloads/details.aspx?familyid=79BC3B77-E02C-4AD3-AACF-A7633F706BA5&displaylang=en");
            }

            return message;
        }
    }
}
