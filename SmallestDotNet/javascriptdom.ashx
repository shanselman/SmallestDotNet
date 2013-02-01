<%@ WebHandler Language="C#" Class="SmallestDotNet" %>

using System;
using System.Web;
using SmallestDotNetLib;

public class SmallestDotNet : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/javascript";

        dr("SmallestDotNet = {};");

        dr(JsonVersions.WriteLatestVersions(context.Request.UserAgent));
        
        dr(JsonVersions.WriteAllVersions(context.Request.UserAgent));

        dr(JsonVersions.WriteDownloads().Trim());


        if (context.Request.UserAgent.Contains("Mac") || context.Request.UserAgent.Contains("nix"))
        {
            dr(@"
                SmallestDotNet = {};
                SmallestDotNet.latestVersion = null;
                SmallestDotNet.allVersions = [];
                ");
        }

    }

    private static void dr(string s)
    {
        HttpResponse r = HttpContext.Current.Response;
        r.Write(s);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
