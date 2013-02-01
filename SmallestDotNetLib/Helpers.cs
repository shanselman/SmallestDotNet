using SmallestDotNetLib;
using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// A Class containing general purposes methods
/// </summary>
public class Helpers
{
    public static string GetUpdateInformation(string UserAgent, Version version)
    {


        bool net4 = false;
        string netInfoString = "";

        //Check mobile versions prior to .NET checking since some don't directly support .NET
        //Most mobile user agent strings contain "mobile", Chrome for android doesn't so check for Android here as well.
        if (UserAgent.Contains("Mobile") || UserAgent.Contains("Android"))
        {
            //iOS UA
            if (UserAgent.Contains("iPad"))
                return MessageForiOS("iPad");
            
            if (UserAgent.Contains("iPod"))
                return MessageForiOS("iPod");

            if (UserAgent.Contains("iPhone"))
                return MessageForiOS("iPhone");

            //Android UA
            if (UserAgent.Contains("Android"))
                return "It looks like you're running an Android device. There's no .NET Framework download from Microsoft for Android, but check out <a href=" + Constants.MonoForAndroidURL + ">Mono for Android</a> and write .NET apps for Android!";

            //Windows UA
            if (UserAgent.Contains("Windows Phone"))
                return "It looks like you're running Windows Phone. Windows Phone uses a special version of the .NET Framework, check out the <a href=" + Constants.WindowsPhoneSDKURL + "> Windows Phone SDKs</a> and start writing apps for Windows Phone!";

            if (UserAgent.Contains("Windows CE"))
                return "It looks like you're running a Windows CE or Windows Mobile device.  Windows CE uses the .NET Compact Framework, check out <a href=" + Constants.Version35CompactURL + "> .NET Compact</a> for more information.";

            //Unknown UA
            return "It looks like you're running a mobile device, but I can't see what browser your running.  If you are interested in writing .NET apps for mobile devices, check out one of the following:  <a href="
                + Constants.MonoForiOSURL + ">MonoTouch</a>, <a href=" + Constants.MonoForAndroidURL + ">Mono for Android</a>, <a href=" + Constants.WindowsPhoneSDKURL + ">Windows Phone SDK</a> or <a href=" + Constants.Version35CompactURL + ">.NET Compact Framework.</a>";
        }

        //We should check this first since we don't need to check .NET versions if they can't have .NET versions
        if (UserAgent.Contains("Mac"))
        {
            netInfoString = "It looks like you're running a Mac. There's no .NET Framework download from Microsoft for the Mac, but you might check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on a Mac.";
            return netInfoString;
        }
        if (UserAgent.Contains("nix"))
        {
            netInfoString = "It looks like you're running a Unix machine. There's no .NET Framework download from Microsoft for Unix, but you might check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on Unix.";
            return netInfoString;
        }

        net4 = (GetWindows8Message(UserAgent, ref netInfoString) || Get40Message(UserAgent, ref netInfoString));
        if (Helpers.Has35(UserAgent) || Helpers.Has35SP1C(UserAgent) || Helpers.Has35SP1E(UserAgent))
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
        }

        //need to see if windows 2000 has the latest version
        foreach (KeyValuePair<string, string> windowsVersion in Constants.OldWindows)
        {
            netInfoString += CheckDotNet3_5UnSupportedOs(UserAgent, windowsVersion.Key, windowsVersion.Value);
        }

        return netInfoString;
    }

    private static bool GetWindows8Message(string UserAgent, ref string userMessage)
    {
        if (Helpers.HasWindows8(UserAgent) || Helpers.Has45(UserAgent))
        {
            userMessage += String.Format(Constants.EarlyAdopter, "full install of .NET 4.5");
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

    private static string MessageForiOS(string deviceType)
    {
        return String.Format(@"It looks like you're running an {0}. There's no .NET Framework download from Microsoft for the {0}, 
                but check out <a href=" + Constants.MonoForiOSURL + ">MonoTouch</a> and write .NET apps for iOS!", deviceType);
    }

    private static string MessageForBrowser(string browser)
    {
        return String.Format(@"Looks like you're running {0}. That's totally cool, but I can't tell if you've got .NET installed from {0}. 
                Consider running this <a href=""https://github.com/downloads/shanselman/SmallestDotNet/CheckForDotNet45.exe"">little application</a>, just once, and we'll tell you what version of .NET you're running.", browser);
    }

    private static string UnknownBrowserMessage()
    {
        string explain = String.Format(Constants.WhyItIsSmall, 48);
        return String.Format(@"I can't see what browser you have. That's totally cool, but I can't tell if you've got .NET installed. 
                Consider running this <a href=""https://github.com/downloads/shanselman/SmallestDotNet/CheckForDotNet45.exe"">little application</a>, just once, and we'll tell you what version of .NET you're running.");
    }

    private static string DotNet1Message(bool hasDotNet4)
    {
        string explain = String.Format(Constants.WhyItIsSmall, "around 45-60");
        return String.Format("Looks like you've {3} got a <strong>pretty old version of .NET</strong>. You should make sure your computer is up to date by visiting {0} then downloading the {1} from Microsoft. {2}", Constants.WindowsUpdate, Constants.DotNetOnline, explain, hasDotNet4 ? "also" : "");
    }

    private static string DotNet2Message(bool hasDotNet4)
    {
        string explain = String.Format(Constants.WhyItIsSmall, "around 33");
        return String.Format(@"Looks like you {2} have <strong>.NET version 2.0</strong>. 
                     That's a fairly recent version of the .NET Framework, but you can upgrade fairly easily to the .NET 4.5 by downloading the 980 KB isntaller for {0}. {1}", Constants.DotNetOnline, explain, hasDotNet4 ? "also" : "");
    }

    private static string DotNet3Message(bool hasDotNet4)
    {
        string explain = String.Format(Constants.WhyItIsSmall, "only 10");
        return String.Format(@"Looks like you {2} have <strong>.NET version 3.0</strong>. 
                     That's a very recent version of the .NET Framework, but you can upgrade fairly easily to .NET 4.5 by downloading the 980 KB installer for {0}. {1}", Constants.DotNetOnline, explain, hasDotNet4 ? "also" : "");
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
    /// <param name="UserAgent">A User Agent String</param>
    /// <returns></returns>
    public static bool HasWindows8(String UserAgent)
    {
        return UserAgent.Contains(Constants.Windows8);
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
