<%@ WebHandler Language="C#" Class="SmallestDotNet" %>

using System;
using System.Web;

public class SmallestDotNet : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        dr("<span class=\"smallerdotnet\">");
        context.Response.ContentType = "text/javascript";
        Version version = context.Request.Browser.ClrVersion;
        string retVal = String.Empty;

        bool net4 = false;

        if (context.Request.UserAgent.Contains(".NET4.0E"))
        {
            retVal += String.Format(@"Seems you\'re an early adopter! You\'ve got a <strong>full install of .NET 4.0</strong> on your machine. ");
            net4 = true;
        }
        else if (context.Request.UserAgent.Contains(".NET4.0C"))
        {
            retVal += String.Format(@"Seems you\'re an early adopter! You\'ve got the <strong>.NET 4.0 Client Profile</strong> on your machine. ");
            net4 = true;
        }
        
        if (version != null && version.Major != 0)
        {
            switch (version.Major)
            {
                case 1:
                    switch (version.Minor)
                    {
                        case 0:
                        case 1:
                            {
                                retVal += String.Format("Detected 1.x .NET Framework. Update to {0}, about a 45-60 meg download.", Constants.dotnet35online);
                            }
                            break;
                    }
                    break;
                case 2:
                    {
                        retVal += String.Format("Detected 2.0 .NET Framework. Update to {0}, about a 30 meg download.", Constants.dotnet35online);
                    }
                    break;
                case 3:
                    switch (version.Minor)
                    {
                        case 0:
                            {
                                retVal += String.Format("Detected 3.0 .NET Framework. Update to {0}, just a 10 meg download.", Constants.dotnet35online);
                            }
                            break;
                        case 5:
                            switch (version.Build)
                            {
                                case 21022: //RTM
                                    retVal += String.Format("Detected 3.5 .NET Framework. Update to {0}, only a 10 meg download.", Constants.dotnet35online);
                                    break;
                                case 30729: //SP1
                                    retVal += String.Format("Detected 3.5 SP1 .NET Framework. No update needed.");
                                    break;
                                default:
                                    retVal += String.Format("Detected BETA of 3.5 .NET Framework! Uninstall and upgrade to {0}.", Constants.dotnet35online);
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }
        else
        {
            if (context.Request.UserAgent.Contains("fox"))
            {
                retVal += String.Format("Detected FireFox. Add {0}, only a ~10 meg download.", Constants.dotnet35online);
            }
            else
            {
                retVal += String.Format(@"Can\'t detect .NET Framework. Download {0}, only a ~2.8 meg download.", Constants.dotnet35online);
            }

        }
        if (context.Request.UserAgent.Contains("Mac"))
        {
            retVal += "Detected a Mac. No .NET Framework available!";
        }

        if (context.Request.UserAgent.Contains("nix"))
        {
            retVal += "Detected a Linux machine. No .NET Framework available!";
        }

        //need to see if windows 2000 has the latest version
        if (context.Request.UserAgent.Contains("Windows NT 5.0"))
        {
            retVal += String.Format("Detected Windows 2000. Sorry, .NET 3.5 isn't supported on Windows 2000, but you can still run <a href=\"{0}\">NET Framework 2.0 SP1</a>", "http://www.microsoft.com/downloads/details.aspx?familyid=79BC3B77-E02C-4AD3-AACF-A7633F706BA5&displaylang=en");
        }

        //need to see if windows 2000 has the latest version
        if (context.Request.UserAgent.Contains("Windows 95"))
        {
            retVal += String.Format("Detected Windows 95. Sorry, .NET 3.5 isn't supported on Windows 95, but you can still run <a href=\"{0}\">NET Framework 2.0 SP1</a>", "http://www.microsoft.com/downloads/details.aspx?familyid=79BC3B77-E02C-4AD3-AACF-A7633F706BA5&displaylang=en");
        }

        //need to see if windows 2000 has the latest version
        if (context.Request.UserAgent.Contains("Windows 98"))
        {
            retVal += String.Format("Detected Windows 98. Sorry, .NET 3.5 isn't supported on Windows 98, but you can still run <a href=\"{0}\">NET Framework 2.0 SP1</a>", "http://www.microsoft.com/downloads/details.aspx?familyid=79BC3B77-E02C-4AD3-AACF-A7633F706BA5&displaylang=en");
        }




        dr(retVal);
        dr("</span>");

    }

    private void dr(string s)
    {
        HttpResponse r = HttpContext.Current.Response;
        r.Write(String.Format("document.write('{0}')\r\n",s));
   }

    public bool IsReusable {
        get {
            return false;
        }
    }

}