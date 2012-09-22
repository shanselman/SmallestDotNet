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
                var netVersions = userAgent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Where(s => s.Contains(".NET CLR"));
                Version version = GetNetVersion(netVersions);
                context.Response.ContentType = "text/plain";
                context.Response.Write(Helpers.GetUpdateInformation(userAgent, version));
            }
        }


        private Version GetNetVersion(IEnumerable<string> versions)
        {
            //I think were only looking for CLR versions
            if (versions.Any())
            {
                var versionNumbers = new List<string>();
                versions.ToList().ForEach(v =>
                {
                    var number = v.Split(new string[] { ".NET CLR" }, StringSplitOptions.None)[1].Trim();
                    versionNumbers.Add(number);

                });

                versionNumbers = versionNumbers.OrderByDescending(x => x).ToList();
                Version ret = Version.Parse(versionNumbers.First());

                return ret;
            }

            return null;
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