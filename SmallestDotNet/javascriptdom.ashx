<%@ WebHandler Language="C#" Class="SmallestDotNet" %>

using System;
using System.Web;
using SmallestDotNetLib;

public class SmallestDotNet : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/javascript";

        WriteToResponse("SmallestDotNet = {};");

        WriteToResponse(JsonVersions.WriteLatestVersions(context.Request.UserAgent));
        
        WriteToResponse(JsonVersions.WriteAllVersions(context.Request.UserAgent));

        WriteToResponse(JsonVersions.WriteDownloads().Trim());


        if (context.Request.UserAgent.Contains("Mac") || context.Request.UserAgent.Contains("nix"))
        {
            WriteToResponse(@"
                SmallestDotNet = {};
                SmallestDotNet.latestVersion = null;
                SmallestDotNet.allVersions = [];
                ");
        }

    }

    private static void WriteToResponse(string s)
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
