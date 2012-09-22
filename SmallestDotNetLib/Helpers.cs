using System;
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
                    switch (version.Minor)
                    {
                        case 0:
                        case 1:
                            {
                                string explain = String.Format(Constants.whyitissmall, "around 45-60");
                                netInfoString += String.Format("Looks like you've {3} got a <strong>pretty old version of .NET</strong>. You should make sure your computer is up to date by visiting {0} then downloading the {1} from Microsoft. {2}", Constants.windowsupdate, Constants.dotnet35online, explain, net4 ? "also" : "");
                            }
                            break;
                    }
                    break;
                case 2:
                    {
                        string explain = String.Format(Constants.whyitissmall, "around 33");
                        netInfoString += String.Format(@"Looks like you {2} have <strong>.NET version 2.0</strong>. 
                     That's a fairly recent version of the .NET Framework, but you can upgrade fairly easily to the newest version by downloading the 2.8 meg ""bootstrapper"" for {0}. {1}", Constants.dotnet35online, explain, net4 ? "also" : "");
                    }
                    break;
                case 3:
                    switch (version.Minor)
                    {
                        case 0:
                            {
                                string explain = String.Format(Constants.whyitissmall, "only 10");
                                netInfoString += String.Format(@"Looks like you {2} have <strong>.NET version 3.0</strong>. 
                     That's a very recent version of the .NET Framework, but you can upgrade fairly easily to the 3.5 version by downloading the 2.8 meg installer for {0}. {1}", Constants.dotnet35online, explain, net4 ? "also" : "");
                            }
                            break;
                        case 5:
                            switch (version.Build)
                            {
                                case 21022: //RTM
                                    netInfoString += String.Format("Looks like you {2} have <strong>.NET version 3.5</strong>. The latest version is 3.5 SP1. You can upgrade quickly with this small download for {0}. Also, you should make sure your system is setup to get updates from {1} automatically. This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.dotnet35online, Constants.windowsupdate, net4 ? "also" : "");
                                    break;
                                case 30729: //SP1
                                    netInfoString += String.Format("Looks like you {1} have <strong>.NET version 3.5 SP1</strong>. That's the VERY latest .NET Framework. <strong>You don't need to do anything right now.</strong> However, you might make sure your system is setup to get updates from {0} automatically. This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.windowsupdate, net4 ? "also" : "");
                                    break;
                                default:
                                    netInfoString += String.Format("Looks like you <i>might</i> {2} have a <em>beta</em> version of <strong>.NET version 3.5 SP1</strong>. Perhaps you're a programmer or you know one? You should probably uninstall that version and run the small setup program for {0}. Also, you might make sure your system is setup to get updates from {1} automatically. This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.dotnet35online, Constants.windowsupdate, net4 ? "also" : "");
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }
        else
        {
            if (UserAgent.Contains("fox"))
            {
                MessageForBrowser("Firefox");
            }
            else if (UserAgent.Contains("Chrome"))
            {
                MessageForBrowser("Chrome");
            }
            else if(UserAgent.Contains("Safari")) // Chrome also uses safari in the user agent so this check must come after
            {
                MessageForBrowser("Safari");
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
        CheckDotNet3_5UnSupportedOs(UserAgent, "Windows NT 5.0", "Windows 2000", ref netInfoString);
        CheckDotNet3_5UnSupportedOs(UserAgent, "Windows 98", "Windows 98", ref netInfoString);
        CheckDotNet3_5UnSupportedOs(UserAgent, "Windows 95", "Windows 95", ref netInfoString);
        
        return netInfoString;
    }

    private static bool CheckDotNet4Installed(ref string userMessage)
    {
        if (UserAgent.Contains(".NET4.0E"))
        {
            userMessage += String.Format("Seems you're an early adopter! You've got a <strong>full install of .NET 4.0</strong> on your machine. ");
            return true;
        }
        else if (UserAgent.Contains(".NET4.0C"))
        {
            userMessage += String.Format("Seems you're an early adopter! You've got the <strong>.NET 4.0 Client Profile</strong> on your machine. ");
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

    private static void CheckDotNet3_5UnSupportedOs(string UserAgent, string agent, string friendlyName, ref string userMessage)
    {
        if (UserAgent.Contains(agent))
        {
            userMessage += String.Format("It looks like you're running {1}. Sorry, but .NET 3.5 isn't supported on {1}, but you can still run <a href=\"{0}\">NET Framework 2.0 SP1</a>", "http://www.microsoft.com/downloads/details.aspx?familyid=79BC3B77-E02C-4AD3-AACF-A7633F706BA5&displaylang=en", friendlyName);
        }
    }

}