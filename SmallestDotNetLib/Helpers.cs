﻿using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Helpers
/// </summary>
public class Helpers
{
    public static string GetUpdateInformation(string UserAgent, Version version)
    {
        bool net4 = false;
        string netInfoString = "";

        net4 = CheckDotNet4Installed(UserAgent, ref netInfoString);


        if (version != null && version.Major != 0)
        {
            switch (version.Major)
            {
                case 1:
                    if (version.Minor == 0 || version.Minor == 1)
                        netInfoString += DotNet1Message(net4);
                    break;
                case 2:
                    netInfoString += DotNet2Message(net4);
                    break;
                case 3:
                    switch (version.Minor)
                    {
                        case 0:
                            netInfoString += DotNet3Message(net4);
                            break;
                        case 5:
                            netInfoString += DotNet3_5Message(version.Build, net4);
                            break;
                    }
                    break;
            }
        }
        else
        {
            if (UserAgent.Contains("fox"))
            {
                netInfoString += MessageForBrowser("Firefox");
            }
            else if (UserAgent.Contains("Chrome"))
            {
                netInfoString += MessageForBrowser("Chrome");
            }
            else if(UserAgent.Contains("Safari")) // Chrome also uses safari in the user agent so this check must come after
            {
                netInfoString += MessageForBrowser("Safari");
            }
            else
            {
                netInfoString += UnknownBrowserMessage();
            }
        }

        if (UserAgent.Contains("Mac"))
        {
            netInfoString += "It looks like you're running a Mac. There's no .NET Framework download from Microsoft for the Mac, but you might check out either <a href=\"http://www.microsoft.com/silverlight/resources/install.aspx\">Silverlight</a> which is a browser plugin that includes a small version of the .NET Framework. You could also check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on a Mac.";
        }

        if (UserAgent.Contains("nix"))
        {
            netInfoString += "It looks like you're running a Unix machine. There's no .NET Framework download from Microsoft for Unix, but you might check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on Unix.";
        }
        
        //need to see if windows 2000 has the latest version
        foreach (KeyValuePair<string, string> windowsVersion in Constants.oldwindows)
        {
            netInfoString += CheckDotNet3_5UnSupportedOs(UserAgent, windowsVersion.Key, windowsVersion.Value);
        }
        
        return netInfoString;
    }

    private static bool CheckDotNet4Installed(string UserAgent, ref string userMessage)
    {
        if (UserAgent.Contains(".NET4.0E"))
        {
            userMessage += String.Format(Constants.earlyadopter, "full install of .NET 4.0");
            return true;
        }
        else if (UserAgent.Contains(".NET4.0C"))
        {
            userMessage += String.Format(Constants.earlyadopter, ".NET 4.0 Client Profile");
            return true;
        }

        return false;
    }

    private static string MessageForBrowser(string browser)
    {
        return String.Format(@"Looks like you're running {2}. That's totally cool, but I can't tell if you've got .NET installed from {2}. 
                   Consider visiting this site, just once, using Internet Explorer, which will tell me more about if your system has .NET on it or not. 
                  Alternatively, if you're running Windows, you can go <strong>download the 2.8 meg installer for {0}.</strong> 
                  Also, you might make sure your system is setup to get updates from {1} automatically. 
                  This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.dotnet35online, Constants.windowsupdate, browser);
    }

    private static string UnknownBrowserMessage()
    {
        string explain = String.Format(Constants.whyitissmall, 60);
        return String.Format(@"I can't tell if you've got .NET installed. Perhaps you don't have .NET installed or perhaps 
                  your browser isn't letting me know. Consider visiting this site using Internet Explorer, which will tell me more about if your system has .NET on it or not. Alternatively, if you're running Windows, you can go <strong>download the 2.8 meg installer for {0}.</strong> {1}
                  Also, you might make sure your system is setup to get updates from {2} automatically. 
                  This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.dotnet35online, explain, Constants.windowsupdate);
    }

    private static string DotNet1Message(bool hasDotNet4)
    {
        string explain = String.Format(Constants.whyitissmall, "around 45-60");
        return String.Format("Looks like you've {3} got a <strong>pretty old version of .NET</strong>. You should make sure your computer is up to date by visiting {0} then downloading the {1} from Microsoft. {2}", Constants.windowsupdate, Constants.dotnet35online, explain, hasDotNet4 ? "also" : "");
    }

    private static string DotNet2Message(bool hasDotNet4)
    {
        string explain = String.Format(Constants.whyitissmall, "around 33");
        return String.Format(@"Looks like you {2} have <strong>.NET version 2.0</strong>. 
                     That's a fairly recent version of the .NET Framework, but you can upgrade fairly easily to the newest version by downloading the 2.8 meg ""bootstrapper"" for {0}. {1}", Constants.dotnet35online, explain, hasDotNet4 ? "also" : "");
    }

    private static string DotNet3Message(bool hasDotNet4)
    {
        string explain = String.Format(Constants.whyitissmall, "only 10");
        return String.Format(@"Looks like you {2} have <strong>.NET version 3.0</strong>. 
                     That's a very recent version of the .NET Framework, but you can upgrade fairly easily to the 3.5 version by downloading the 2.8 meg installer for {0}. {1}", Constants.dotnet35online, explain, hasDotNet4 ? "also" : "");
    }

    private static string DotNet3_5Message(int build, bool hasDotNet4)
    {
        switch (build)
        {
            case 21022: //RTM
                return String.Format("Looks like you {2} have <strong>.NET version 3.5</strong>. The latest version is 3.5 SP1. You can upgrade quickly with this small download for {0}. Also, you should make sure your system is setup to get updates from {1} automatically. This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.dotnet35online, Constants.windowsupdate, hasDotNet4 ? "also" : "");
            case 30729: //SP1
                return String.Format("Looks like you {1} have <strong>.NET version 3.5 SP1</strong>. That's the VERY latest .NET Framework. <strong>You don't need to do anything right now.</strong> However, you might make sure your system is setup to get updates from {0} automatically. This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.windowsupdate, hasDotNet4 ? "also" : "");
            default:
                return String.Format("Looks like you <i>might</i> {2} have a <em>beta</em> version of <strong>.NET version 3.5 SP1</strong>. Perhaps you're a programmer or you know one? You should probably uninstall that version and run the small setup program for {0}. Also, you might make sure your system is setup to get updates from {1} automatically. This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.dotnet35online, Constants.windowsupdate, hasDotNet4 ? "also" : "");
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

}