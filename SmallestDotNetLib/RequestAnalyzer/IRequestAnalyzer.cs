﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib.RequestAnalyzer
{
    using System.Web;

    public interface IRequestAnalyzer
    {
        void InitializeMessage(string message);

        string Message { get; }

        string GetInfoString(HttpRequestBase request);
    }
}
