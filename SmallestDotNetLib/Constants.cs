using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Constants
/// </summary>
public static class Constants
{
    public const string dotnet35url = "http://www.microsoft.com/downloads/details.aspx?FamilyId=AB99342F-5D1A-413D-8319-81DA479AB0D7&displaylang=en";
    public static readonly string dotnet35online = String.Format("<a href=\"{0}\">.NET Framework 3.5 SP1</a>", dotnet35url);
    public const string windowsupdate = "<a href=\"http://www.windowsupdate.com\">Windows Update</a>";
    public const string whyitissmall = @" The .NET installer is smart enough to look at your system and automatically download the <strong>smallest upgrade package</strong> possible. 
                           For you, it'll probably be <strong>{0} megabytes total</strong>.";

    public const string earlyadopter = "Seems you're an early adopter! You've got a <strong>{0}</strong> on your machine. ";

    public static readonly Dictionary<string, string> oldwindows = new Dictionary<string, string>
    {
        {"Windows NT 5.0", "Windows 2000"},
        {"Windows 95", "Windows 95"},
        {"Windows 98", "Windows 98"}
    };
}
