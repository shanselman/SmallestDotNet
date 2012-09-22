using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    using System.Web;

    public interface IRequestAnalyzer
    {
        string GetInfoString(HttpRequestBase request, string message = null);

        string GetInfoString(string userAgent, Version browserVersion, string message = null);
    }
}
