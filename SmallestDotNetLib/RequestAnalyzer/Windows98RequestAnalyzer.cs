﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    public class Windows98RequestAnalyzer : RequestAnalyzer
    {
        public override string GetInfoString(System.Web.HttpRequestBase request)
        {
            if (request.UserAgent.Contains("Windows 98"))
            {
                this.Message += string.Format("It looks like you're running Windows 98. Sorry, but .NET 3.5 isn't supported on Windows 98, but you can still run <a href=\"{0}\">NET Framework 2.0 SP1</a>", Constants.urlToDotNet2Sp1Download);
            }

            return this.Message;
        }        
    }
}
