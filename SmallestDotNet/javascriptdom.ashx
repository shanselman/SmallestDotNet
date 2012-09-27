<%@ WebHandler Language="C#" Class="SmallestDotNet" %>

using System;
using System.Web;
using SmallestDotNetLib;

public class SmallestDotNet : IHttpHandler
{

    private bool firstVersionWritten = false;


    public void WriteLatest(int major, int minor, string profile, int? sp)
    {
        dr(JsonVersions.WriteLatestVersion(major, minor, profile, sp));
    }

    public void WriteVersion(int major, int minor, string profile, int? sp)
    {
        if (firstVersionWritten) dr(",");
        firstVersionWritten = true;
        dr(JsonVersions.WriteVersion(major, minor, profile, sp));
    }


    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/javascript";

        dr("SmallestDotNet = {};");

        dr(JsonVersions.WriteLatestVersions(context.Request.UserAgent));

        dr(@"SmallestDotNet.allVersions =
        [");

        dr(JsonVersions.WriteAllVersions(context.Request.UserAgent));

        dr(@"];");


        //Download links
        dr(JsonVersions.WriteDownloads(context.Request.UserAgent).Trim());



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
