using System;
using System.Collections.Generic;

/// <summary>
/// A Place for the Strings
/// </summary>
public static class Constants
{
    public static readonly string DotNet = "4.6.1";
    public static readonly string DotNetOnline = String.Format("<a href=\"{0}\">.NET {1} Web</a>", Version461WebUrl, DotNet);
    public static readonly string DotNetOffline = String.Format("<a href=\"{0}\">.NET {1} Offline</a>", Version461OfflineUrl, DotNet);
    public const double DotNetOnlineMB = Version461WebMB;
    public const double DotNetOfflineMB = Version461OfflineMB;

    public const string WindowsUpdate = "<a href=\"http://www.update.microsoft.com\">Windows Update</a>";
    public const string WhyItIsSmall = @" The .NET installer is smart enough to look at your system and automatically download the <strong>smallest upgrade package</strong> possible. 
                           For you, it'll probably be <strong>around {0} megabytes total</strong>.";

    public const string InferredText = "You have at least <strong>{0}</strong> on your machine. We can only infer this as the user agent of your browser doesn't give us the version. Try the .Net Checker application to get more accurate version information.";
    public const string CheckerFound = "The .Net Checker application determined that you have <strong>{0}</strong> on your machine. ";
    public const string CheckerFoundNotExact = "The application was not able to determine the exact version you have. Please <a href=\"https://github.com/shanselman/SmallestDotNet/issues/\">log an issue</a> including this information: <strong>releaseKey={1}</strong> so we can get it exact in the future.";

    public static readonly Dictionary<string, string> OldWindows = new Dictionary<string, string>
    {
        {"Windows NT 5.0", "Windows 2000"},
        {"Windows 95", "Windows 95"},
        {"Windows 98", "Windows 98"}
    };

    /// <summary>
    /// The .Net versions (4.5 and above) keyed by the registry key value.
    /// </summary>
    public static readonly SortedDictionary<int, string> ReleaseVersions = new SortedDictionary<int, string>
                           {
                               { int.MinValue, "4.5" },
                               { 378389, "4.5" },
                               { 378675, "4.5.1" },
                               { 378758, "4.5.1" },
                               { 379893, "4.5.2" },
                               { 381029, "4.6 Preview" },
                               { 393273, "4.6 RC1" },
                               { 393292, "4.6 RC2" },
                               { 393295, "4.6" },
                               { 393297, "4.6" },
                               { 394254, "4.6.1" },
                               { 394271, "4.6.1" },
                           };

    public const string Windows8 = "Windows NT 6.2";
    public const string Windows81 = "Windows NT 6.3";
    public const string Windows10 = "Windows NT 10";

    public const string Version461Full = ".NET 4.6.1";
    public const string Version46Full = ".NET 4.6";
    public const string Version45Full = ".NET 4.5";
    public const string Version40Full = ".NET4.0E";
    public const string Version40Client = ".NET4.0C";
    public const string Version35SP1Full = ".NET CLR 3.5.30729";
    public const string Version35SP1Client = ".NET Client 3.5";
    public const string Version35Full = ".NET CLR 3.5";
    public const string Version30Full = ".NET CLR 3.0";
    public const string Version20Full = ".NET CLR 2.0";
    public const string Version11Full = ".NET CLR 1.1";
    public const string Version10Full = ".NET CLR 1.0";

    private const string Version461WebUrl = "https://www.microsoft.com/en-us/download/details.aspx?id=49981";
    private const string Version461OfflineUrl = "https://www.microsoft.com/en-us/download/details.aspx?id=49982";

    private const string Version46WebUrl = "http://go.microsoft.com/fwlink/?LinkId=528259";
    private const string Version46OfflineUrl = "http://go.microsoft.com/fwlink/?LinkId=528233";

    public const string Version11URL = "http://www.microsoft.com/downloads/details.aspx?FamilyID=a8f5654f-088e-40b2-bbdb-a83353618b38&DisplayLang=en";
    public const string Version20URL = "http://www.microsoft.com/downloads/details.aspx?familyid=5B2C0358-915B-4EB5-9B1D-10E506DA9D0F&displaylang=en";
    public const string Version30URL = "http://www.microsoft.com/downloads/details.aspx?FamilyId=10CC340B-F857-4A14-83F5-25634C3BF043&displaylang=en";
    public const string Version35SP1FullURL = "http://www.microsoft.com/en-us/download/details.aspx?id=22";
    public const string Version35SP1ClientURL = "http://www.microsoft.com/downloads/details.aspx?FamilyId=8CEA6CD1-15BC-4664-B27D-8CEBA808B28B&displaylang=en";
    public const string Version40FullURL = "http://www.microsoft.com/downloads/details.aspx?FamilyID=9f5e8774-c8dc-4ff6-8285-03a4c387c0db&displaylang=en";
    public const string Version40ClientURL = "http://www.microsoft.com/downloads/details.aspx?FamilyID=68a7173d-7ee5-4213-a06f-f2e943ec9249&displaylang=en";
    public const string Version45URL = "http://www.microsoft.com/en-us/download/details.aspx?id=30653";
    public const string Version46URL = "http://www.microsoft.com/en-us/download/details.aspx?id=30653";

    private const double Version461WebMB = 1.4;
    private const double Version461OfflineMB = 64.5;
    private const double Version46WebMB = 1.4;
    private const int Version46OfflineMB = 63;
    public const int Version3OfflineMB = 38;
    public const int Version2OfflineMB = 15;
    public const int Version1OfflineMB = 7;
}
