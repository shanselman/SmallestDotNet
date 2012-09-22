using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    public abstract class RequestAnalyzer : IRequestAnalyzer
    {
        public string Message { get; set; }

        public abstract string GetInfoString(System.Web.HttpRequestBase request);

        public void InitializeMessage(string message)
        {
            this.Message = message;
        }
    }
}
