<%@ WebHandler Language="C#" Class="SmallestDotNet" %>

using System;
using System.Web;


public class SmallestDotNet : IHttpHandler {

    private bool firstVersionWritten = false;
    
    public static bool Has40E(HttpContext context)
    {
        return context.Request.UserAgent.Contains(".NET4.0E");
    }

    public static bool Has40C(HttpContext context)
    {
        return context.Request.UserAgent.Contains(".NET4.0C");
    }

    public static bool Has35SP1E(HttpContext context)
    {
        return context.Request.UserAgent.Contains(".NET CLR 3.5.30729");
    }

    public static bool Has35SP1C(HttpContext context)
    {
        return context.Request.UserAgent.Contains(".NET Client 3.5");
    }

    public static bool Has35(HttpContext context)
    {
        return context.Request.UserAgent.Contains(".NET CLR 3.5.21022");
    }

    public static bool Has20(HttpContext context)
    {
        return context.Request.UserAgent.Contains(".NET CLR 2.0");
    }

    public static bool Has11(HttpContext context)
    {
        return context.Request.UserAgent.Contains(".NET CLR 1.1");
    }

    public static bool Has10(HttpContext context)
    {
        return context.Request.UserAgent.Contains(".NET CLR 1.0");
    }

    public void WriteLatest(HttpContext context, int major, int minor, string profile, int? sp)
    {
        dr(String.Format(@"SmallestDotNet.latestVersion = {{
                major: {0},
                minor: {1},
                profile: ""{2}"",
                servicePack: {3}                
        }};",major, minor, profile, sp.HasValue ? sp.ToString() : "null"));
    }
    public void WriteVersion(HttpContext context, int major, int minor, string profile, int? sp)
    {
        if (firstVersionWritten) dr(",");
        firstVersionWritten = true;
        dr(String.Format(@"{{
                major: {0},
                minor: {1},
                profile: ""{2}"",
                servicePack: {3}                
        }}", major, minor, profile, sp.HasValue ? sp.ToString() : "null"));
    }
    
        
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/javascript";
        Version version = context.Request.Browser.ClrVersion;
        string retVal = String.Empty;

        dr("SmallestDotNet = {};");
        
        bool net4 = false;

        if (Has40E(context))
            WriteLatest(context, 4, 0, "full", null);
        else if (Has40C(context))
            WriteLatest(context, 4, 0, "client", null);
        else if (Has35SP1E(context))
            WriteLatest(context, 3, 5, "full", 1);
        else if (Has35SP1C(context))
            WriteLatest(context, 3, 5, "client", 1);
        else if (Has35(context))
            WriteLatest(context, 3, 5, "full", null);
        else if (Has20(context))
            WriteLatest(context, 2, 0, "full", null);
        else if (Has11(context))
            WriteLatest(context, 1, 1, "full", null);
        else if (Has10(context))
            WriteLatest(context, 1, 0, "full", null);
        else
            dr("SmallestDotNet.latestVersion = null;"); 

        dr(@"SmallestDotNet.allVersions =
        [");
        
        if(Has40E(context))
            WriteVersion(context, 4, 0, "full", null);
        if(Has40C(context))
            WriteVersion(context, 4, 0, "client", null);

        if (Has35SP1E(context))
            WriteVersion(context, 3, 5, "full", 1);
        
        if (Has35SP1C(context))
            WriteVersion(context, 3, 5, "client", 1);

        if (Has35(context))
            WriteVersion(context, 3, 5, "full", null);

        if (Has20(context))
            WriteVersion(context, 2, 0, "full", null);

        if (Has11(context))
            WriteVersion(context, 1, 1, "full", null);

        if (Has10(context))
            WriteVersion(context, 1, 0, "full", null);

        dr(@"];");


        //Download links
        dr(@"
                SmallestDotNet.downloadableVersions =
                [{
                        major: 4,
                        minor: 0,
                        profile: 'client',
                        servicePack: null,
                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyID=68a7173d-7ee5-4213-a06f-f2e943ec9249&displaylang=en'                                        
                },{
                        major: 4,
                        minor: 0,
                        profile: 'full',
                        servicePack: null,
                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyID=9f5e8774-c8dc-4ff6-8285-03a4c387c0db&displaylang=en'                                        
                },{
                        major: 3,
                        minor: 5,
                        profile: 'client',
                        servicePack: 1,
                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyId=8CEA6CD1-15BC-4664-B27D-8CEBA808B28B&displaylang=en'                        
                },{
                        major: 3,
                        minor: 5,
                        profile: 'full',
                        servicePack: 1,               
                        url: 'http://go.microsoft.com/fwlink/?LinkId=124150'                                        
                },{
                        major: 3,
                        minor: 0,
                        profile: 'full',
                        servicePack: 1,
                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyId=10CC340B-F857-4A14-83F5-25634C3BF043&displaylang=en'                                        
                },{
                        major: 2,
                        minor: 0,
                        profile: 'full',
                        servicePack: 2,
                        url: 'http://www.microsoft.com/downloads/details.aspx?familyid=5B2C0358-915B-4EB5-9B1D-10E506DA9D0F&displaylang=en'                                        
                },{
                        major: 1,
                        minor: 1,
                        profile: 'full',
                        servicePack: 1,
                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyID=a8f5654f-088e-40b2-bbdb-a83353618b38&DisplayLang=en'                                        
                }];
                ");         

        
        
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

    public bool IsReusable {
        get {
            return false;
        }
    }

}
