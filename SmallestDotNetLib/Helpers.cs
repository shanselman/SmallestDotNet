using System;
using System.Collections.Generic;
using System.Linq;
using SmallestDotNetLib;

/// <summary>
/// A Class containing general purposes methods
/// </summary>
public class Helpers
{
    public static UpdateInformationResponse GetUpdateInformation(string userAgent)
    {
        return GetUpdateInformation(userAgent, null, 0);
    }

    public static UpdateInformationResponse GetUpdateInformation(string UserAgent, string realVersion, int releaseKey)
    {
        bool net4 = false;
        string netInfoString = "";
        var response = new UpdateInformationResponse();

        // We should check this first since we don't need to check .NET versions if they can't have .NET versions
        // Check for windows phone first as it may contain 'Mac' in User Agent
        if (UserAgent.Contains("Windows Phone"))
        {
            response.Text = "It looks like you're running a Windows Phone, awesome! There's no .NET Framework download for the Windows phone, but you might check out <a href=\"https://dev.windows.com/\"/>the Windows Dev Center</a> or <a href=\"http://www.windowsphone.com/store/\"/>the Windows Phone Store</a>";
            return response;
        }
        if (UserAgent.Contains("Mac"))
        {
            response.Text = "It looks like you're running a Mac or an iPhone. There's no .NET Framework download from Microsoft for the Mac, but you might check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on a Mac. For your mobile devices, check out <a href=\"http://xamarin.com/platform\">Xamarin</a> and write .NET apps for iOS and Android!";
            return response;
        }
        if (UserAgent.Contains("nix"))
        {
            response.Text = "It looks like you're running a Unix machine. There's no .NET Framework download from Microsoft for Unix, but you might check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on Unix.";
            return response;
        }

        response.CanRunCheckApp = true;
        response.VersionCanBeDetermined = true;

        net4 = GetWindows8Or10Message(UserAgent, ref netInfoString) || Get40Message(UserAgent, ref netInfoString);
        if (!string.IsNullOrEmpty(realVersion) || releaseKey != 0)
        {
            netInfoString = GetRealVersionMessage(ref realVersion, releaseKey);
        }
        else if (Helpers.Has35(UserAgent) || Helpers.Has35SP1C(UserAgent) || Helpers.Has35SP1E(UserAgent))
        {
            netInfoString += DotNet3_5Message((Helpers.Has35SP1C(UserAgent) || Helpers.Has35SP1E(UserAgent)), net4);
        }
        else if (Helpers.Has30(UserAgent))
        {
            netInfoString += DotNet3Message(net4);
        }
        else if (Helpers.Has20(UserAgent))
        {
            netInfoString += DotNet2Message(net4);
        }
        else if (Helpers.Has11(UserAgent) || Helpers.Has10(UserAgent))
        {
            netInfoString += DotNet1Message(net4);
        }
        else if (!net4)
        {
            if (UserAgent.Contains("fox"))
            {
                netInfoString += MessageForBrowser("Firefox");
            }
            else if (UserAgent.Contains("Chrome"))
            {
                netInfoString += MessageForBrowser("Chrome");
            }
            else if (UserAgent.Contains("Safari")) // Chrome also uses safari in the user agent so this check must come after
            {
                netInfoString += MessageForBrowser("Safari");
            }
            else
            {
                netInfoString += UnknownBrowserMessage();
            }

            response.VersionCanBeDetermined = false;
        }

        if (response.VersionCanBeDetermined)
        {
            response.VersionIsLatest = Helpers.CheckVersionLatest(realVersion, ref netInfoString);                 
        }

        //need to see if windows 2000 has the latest version
        foreach (KeyValuePair<string, string> windowsVersion in Constants.OldWindows)
        {
            netInfoString += CheckDotNet3_5UnSupportedOs(UserAgent, windowsVersion.Key, windowsVersion.Value);
        }

        response.Text = netInfoString;
        return response;
    }

      /// <summary>
    /// Gets the .Net version based on release key.
    /// </summary>
    /// <param name="releaseKey">The release key found in registry.</param>
    /// <param name="exact">if set to <c>true</c> then an exact match was found; otherwise the return value will contain "X.Y or greater".</param>
    /// <returns>Version number text e.g. "4.5.1"</returns>
    private static string GetDotnetVersionFromReleaseKey(int releaseKey, out bool exact)
    {
        string version;
        if (Constants.ReleaseVersions.TryGetValue(releaseKey, out version))
        {
            exact = true;
            return version;
        }

        exact = false;
        var releaseVersion = Constants.ReleaseVersions.Last(kvp => kvp.Key < releaseKey);
        return releaseVersion.Value + " or greater";
    }

    /// <summary>
    /// Gets a message based on the "real" version as determined by the .Net Checker application.
    /// </summary>
    /// <param name="realVersion">The real version.</param>
    /// <param name="releaseKey">The release key.</param>
    /// <returns>A message like "The .Net Checker application determined that you've got X.Y on your machine."</returns>
    private static string GetRealVersionMessage(ref string realVersion, int releaseKey)
    {
        bool exact = true;
        if (releaseKey != 0)
        {
            realVersion = GetDotnetVersionFromReleaseKey(releaseKey, out exact);
        }

        return exact
            ? string.Format(Constants.CheckerFound, realVersion)
            : string.Format(Constants.CheckerFound + Constants.CheckerFoundNotExact, realVersion, releaseKey);
    }

    /// <summary>
    /// Gets a message for the Windows 8 OS.
    /// </summary>
    /// <param name="userAgent">The user agent.</param>
    /// <param name="userMessage">The user message.</param>
    /// <returns>True if the user agent has </returns>
    private static bool GetWindows8Or10Message(string userAgent, ref string userMessage)
    {
        bool hasWindows10 = Helpers.HasWindows10(userAgent);
        if (Helpers.HasWindows8(userAgent) || hasWindows10)
        {
            var version = hasWindows10 ? "4.6" : "4.5";
            userMessage += string.Format(Constants.InferredText, version);
            return true;
        }

        return false;
    }

    private static bool Get40Message(string UserAgent, ref string userMessage)
    {

        var whichVersion = "";
        var ret = false;
        if (Helpers.Has40E(UserAgent))
        {
            whichVersion = ".NET 4.0";
            ret = true;
        }
        else if (Helpers.Has40C(UserAgent))
        {
            whichVersion = ".NET 4.0 Client Profile";
            ret = true;
        }        

        if (ret)
        {
            userMessage += String.Format(@"You have {0}, this is a recent version of .NET. Download an installer for the newest version <strong>{1}</strong>.", whichVersion, Constants.DotNetOnline);
        }

        return ret;
    }

    private static string MessageForBrowser(string browser)
    {
        return String.Format(@"Looks like you're running {0}. That's totally cool, but I can't tell if you've got .NET installed from {0}. 
                Consider running this <a href=""https://github.com/downloads/shanselman/SmallestDotNet/CheckForDotNet45.exe"">little application</a>, just once, and we'll tell you what version of .NET you're running.", browser);
    }

    private static string UnknownBrowserMessage()
    {
        string explain = String.Format(Constants.WhyItIsSmall, Constants.DotNetOfflineMB);
        return String.Format(@"I can't see what browser you have. That's totally cool, but I can't tell if you've got .NET installed. 
                Consider running this <a href=""https://github.com/downloads/shanselman/SmallestDotNet/CheckForDotNet45.exe"">little application</a>, just once, and we'll tell you what version of .NET you're running.");
    }

    private static string DotNet1Message(bool hasDotNet4)
    {
        string explain = String.Format(Constants.WhyItIsSmall, Constants.DotNetOfflineMB - Constants.Version1OfflineMB);
        return String.Format("Looks like you've {3} got a <strong>pretty old version of .NET</strong>. You should make sure your computer is up to date by visiting {0} then downloading the {1} from Microsoft. {2}", Constants.WindowsUpdate, Constants.DotNetOnline, explain, hasDotNet4 ? "also" : "");
    }

    private static string DotNet2Message(bool hasDotNet4)
    {
        string explain = String.Format(Constants.WhyItIsSmall, Constants.DotNetOfflineMB - Constants.Version2OfflineMB);
        return String.Format(@"Looks like you {2} have <strong>.NET version 2.0</strong>. 
          That's a fairly recent version of the .NET Framework, but you can upgrade fairly easily to the .NET {4} by downloading the {3} MB isntaller for {0}. {1}", Constants.DotNetOnline, explain, hasDotNet4 ? "also" : "", Constants.DotNetOnlineMB, Constants.DotNet);
    }

    private static string DotNet3Message(bool hasDotNet4)
    {
        string explain = String.Format(Constants.WhyItIsSmall, Constants.DotNetOfflineMB - Constants.Version3OfflineMB);
        return String.Format(@"Looks like you {2} have <strong>.NET version 3.0</strong>. 
          That's a very recent version of the .NET Framework, but you can upgrade fairly easily to .NET {4} by downloading the {3} MB installer for {0}. {1}", Constants.DotNetOnline, explain, hasDotNet4 ? "also" : "", Constants.DotNetOnlineMB, Constants.DotNet);
    }

    private static string DotNet3_5Message(bool hasSp1, bool hasDotNet4)
    {

        if (!hasDotNet4)
        {
            return String.Format(@"You have .NET 3.5{0}, this is a recent version of .NET. Download an installer for the newest version <strong>{1}</strong>.", hasSp1 ? " Service Pack 1" : "", Constants.DotNetOnline);
        }

        return "";
    }

    private static string CheckDotNet3_5UnSupportedOs(string UserAgent, string agent, string friendlyName)
    {
        if (UserAgent.Contains(agent))
        {
            return String.Format("It looks like you're running {1}. Sorry, but .NET 3.5 isn't supported on {1}, but you can still run <a href=\"{0}\">NET Framework 2.0 SP1</a>", "http://www.microsoft.com/downloads/details.aspx?familyid=79BC3B77-E02C-4AD3-AACF-A7633F706BA5&displaylang=en", friendlyName);
        }

        return "";
    }

    private static bool CheckVersionLatest(string realVersion, ref string netInfoString)
    {
        if (realVersion != null && realVersion.Contains(Constants.DotNet))
        {
            netInfoString += String.Format(@"You have {0}, this is a recent version of .NET. Download an installer for the newest version <strong>{1}</strong>.", Constants.DotNet, Constants.DotNetOnline);
            return true;
        }
        return false;
    }

    public static bool Has45(String UserAgent)
    {
        return UserAgent.StartsWith("4.5");
    }

    public static string GetJsonPayload(String UserAgent)
    {
        var OperatingSystem = OperatingSystems.GetOperatingSystem(UserAgent);
        if (OperatingSystem.LatestCLRVersion != null)
        {
            var Browser = BrowserSupport.GetBrowser(UserAgent);

            if (Browser.CanGetCLRVersion)
            {
                var parsedVersions = new CLRVersions(UserAgent);

                var LatestVersion = parsedVersions.GetLatestVersion();

                var UpToDate = (LatestVersion == OperatingSystem.LatestCLRVersion);
            }
        }

        return "Not Implemented";
    }

    /// <summary>
    /// Determines if the User Agent String indicates Windows 8
    /// </summary>
    /// <param name="userAgent">A User Agent String</param>
    /// <returns>True if user agent contains "Windows NT 6.2" or "Windows NT 6.3"</returns>
    public static bool HasWindows8(String userAgent)
    {
        // User Agent from Win 8.1 IE11:
        //  Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; LCJB; rv:11.0) like Gecko
        // User Agent from Windows 10 build 10074 IE11:
        // "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; Touch; MALCJS; rv:11.0) like Gecko";
        return userAgent.Contains(Constants.Windows8) || 
            (userAgent.Contains(Constants.Windows81) && !userAgent.Contains("MALCJS"));
    }

    /// <summary>
    /// Determines if the User Agent String indicates Windows 8
    /// </summary>
    /// <param name="userAgent">A User Agent String</param>
    /// <returns>True if user agent contains "Windows NT 10"</returns>
    public static bool HasWindows10(string userAgent)
    {
        // User Agent from Win 8.1 IE11:
        //  Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; LCJB; rv:11.0) like Gecko
        // User Agent from Windows 10 build 10074 IE11:
        // "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; Touch; MALCJS; rv:11.0) like Gecko";
        return userAgent.Contains(Constants.Windows10)
            || (userAgent.Contains(Constants.Windows81) && userAgent.Contains("MALCJS"));
    }

    /// <summary>
    /// Determines if the User Agent String indicates .NET 4.0 Full
    /// </summary>
    /// <param name="UserAgent">A User Agent String</param>
    /// <returns></returns>
    public static bool Has40E(String UserAgent)
    {
        return UserAgent.Contains(Constants.Version40Full) || UserAgent.StartsWith("4.0");
    }

    /// <summary>
    /// Determines if the User Agent String indicates .NET 40 Client
    /// </summary>
    /// <param name="UserAgent">A User Agent String</param>
    /// <returns></returns>
    public static bool Has40C(String UserAgent)
    {
        return UserAgent.Contains(Constants.Version40Client) || UserAgent.StartsWith("4.0");
    }
        
    /// <summary>
    /// Determines if the User Agent String indicates .NET 3.5 SP1 Full
    /// </summary>
    /// <param name="UserAgent">A User Agent String</param>
    /// <returns></returns>
    public static bool Has35SP1E(String UserAgent)
    {
        return UserAgent.Contains(Constants.Version35SP1Full);
    }

    /// <summary>
    /// Determines if the User Agent String indicates .NET 3.5 SP1 Client
    /// </summary>
    /// <param name="UserAgent">A User Agent String</param>
    /// <returns></returns>
    public static bool Has35SP1C(String UserAgent)
    {
        return UserAgent.Contains(Constants.Version35SP1Client);
    }

    /// <summary>
    /// Determines if the User Agent String indicates .NET 3.5
    /// </summary>
    /// <param name="UserAgent">A User Agent String</param>
    /// <returns></returns>
    public static bool Has35(String UserAgent)
    {
        return UserAgent.Contains(Constants.Version35Full);
    }

    /// <summary>
    /// Determines if the User Agent String indicates .NET 3.0
    /// </summary>
    /// <param name="UserAgent">A User Agent String</param>
    /// <returns></returns>
    public static bool Has30(String UserAgent)
    {
        return UserAgent.Contains(Constants.Version30Full);
    }

    /// <summary>
    /// Determines if the User Agent String indicates .NET 2.0
    /// </summary>
    /// <param name="UserAgent">A User Agent String</param>
    /// <returns></returns>
    public static bool Has20(String UserAgent)
    {
        return UserAgent.Contains(Constants.Version20Full);
    }

    /// <summary>
    /// Determines if the User Agent String indicates .NET 1.1
    /// </summary>
    /// <param name="UserAgent">A User Agent String</param>
    /// <returns></returns>
    public static bool Has11(String UserAgent)
    {
        return UserAgent.Contains(Constants.Version11Full);
    }

    /// <summary>
    /// Determines if the User Agent String indicates .NET 1.0
    /// </summary>
    /// <param name="UserAgent">A User Agent String</param>
    /// <returns></returns>
    public static bool Has10(String UserAgent)
    {
        return UserAgent.Contains(Constants.Version10Full);
    }    
}
