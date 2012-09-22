using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    using System.Web;

    public class Net4RequestAnalyzer : RequestAnalyzer
    {
        public override string GetInfoString(HttpRequestBase request, string message = null)
        {
            throw new NotImplementedException();
        }
    }
}
