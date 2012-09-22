using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    public class Net4RequestAnalyzer : RequestAnalyzer
    {
        public override string GetInfoString(System.Web.HttpRequestBase request)
        {
            throw new NotImplementedException();
        }
    }
}
