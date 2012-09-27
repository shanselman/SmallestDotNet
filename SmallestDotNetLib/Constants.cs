using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Constants
/// </summary>
public static class Constants
{
    public const string DotNet35Url = "http://www.microsoft.com/downloads/details.aspx?FamilyId=AB99342F-5D1A-413D-8319-81DA479AB0D7&displaylang=en";
    public static readonly string DotNet35Online = String.Format("<a href=\"{0}\">.NET Framework 3.5 SP1</a>", DotNet35Url);
    public const string WindowsUpdate = "<a href=\"http://www.update.microsoft.com\">Windows Update</a>";
    public const string WhyItIsSmall = @" The .NET installer is smart enough to look at your system and automatically download the <strong>smallest upgrade package</strong> possible. 
                           For you, it'll probably be <strong>{0} megabytes total</strong>.";

    public const string EarlyAdopter = "Seems you're an early adopter! You've got a <strong>{0}</strong> on your machine. ";

    public static readonly Dictionary<string, string> OldWindows = new Dictionary<string, string>
    {
        {"Windows NT 5.0", "Windows 2000"},
        {"Windows 95", "Windows 95"},
        {"Windows 98", "Windows 98"}
    };

    public const string Version40Full = ".NET4.0E";
    public const string Version40Client = ".NET4.0C";
    public const string Version35SP1Full = ".NET CLR 3.5.30729";
    public const string Version35SP1Client = ".NET Client 3.5";
    public const string Version35Full = ".NET CLR 3.5.21022";
    public const string Version20Full = ".NET CLR 2.0";
    public const string Version11Full = ".NET CLR 1.1";
    public const string Version10Full = ".NET CLR 1.0";

}
