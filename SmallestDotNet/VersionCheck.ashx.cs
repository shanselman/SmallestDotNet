using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallestDotNet
{
    /// <summary>
    /// Summary description for VersionCheck
    /// </summary>
    public class VersionCheck : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.RequestType == "GET")
            {
                var userAgent = context.Request["userAgent"];
                context.Response.ContentType = "text/plain";
                context.Response.Write(Helpers.GetUpdateInformation(userAgent).Text);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}