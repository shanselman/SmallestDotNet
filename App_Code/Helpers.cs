using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Helpers
/// </summary>
public class Helpers
{
    public static string GetUpdateInformation(HttpRequest request)
    {
        bool net4 = false;
        string netInfoString = "";

        if (request.UserAgent.Contains(".NET4.0E"))
        {
            netInfoString += String.Format("Seem you're an early adopter! You've got a <strong>full install of .NET 4.0</strong> on your machine. ");
            net4 = true;
        }
        else if (request.UserAgent.Contains(".NET4.0C"))
        {
            netInfoString += String.Format("Seem you're an early adopter! You've got the <strong>.NET 4.0 Client Profile</strong> on your machine. ");
            net4 = true;
        }


        Version version = request.Browser.ClrVersion;
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
            if (request.UserAgent.Contains("fox"))
            {
                netInfoString += String.Format(@"Looks like you're running FireFox. That's totally cool, but if you've got a version of .NET earlier than 3.5 SP1, I can't tell if you've got .NET installed from FireFox. 
                   Consider visiting this site, just once, using Internet Explorer, which will tell me more about if your system has .NET on it or not. 
                  Alternatively, if you're running Windows, you can go <strong>download the 2.8 meg installer for {0}.</strong> 
                  Also, you might make sure your system is setup to get updates from {1} automatically. 
                  This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.dotnet35online, Constants.windowsupdate);
            }
            else
            {
                string explain = String.Format(Constants.whyitissmall, 60);
                netInfoString += String.Format(@"I can't tell if you've got .NET installed. Perhaps you don't have .NET installed or perhaps 
                  your browser isn't letting me know. Consider visiting this site using Internet Explorer, which will tell me more about if your system has .NET on it or not. Alternatively, if you're running Windows, you can go <strong>download the 2.8 meg installer for {0}.</strong> {1}
                  Also, you might make sure your system is setup to get updates from {2} automatically. 
                  This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.dotnet35online, explain, Constants.windowsupdate);
            }

        }

        if (request.UserAgent.Contains("Mac"))
        {
            netInfoString += "It looks like you're running a Mac. There's no .NET Framework download from Microsoft for the Mac, but you might check out either <a href=\"http://www.microsoft.com/silverlight/resources/install.aspx\">Silverlight</a> which is a browser plugin that includes a small version of the .NET Framework. You could also check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on a Mac.";
        }

        if (request.UserAgent.Contains("nix"))
        {
            netInfoString += "It looks like you're running a Unix machine. There's no .NET Framework download from Microsoft for Unix, but you might check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on Unix.";
        }


        //need to see if windows 2000 has the latest version
        if (request.UserAgent.Contains("Windows NT 5.0"))
        {
            netInfoString += String.Format("It looks like you're running Windows 2000. Sorry, but .NET 3.5 isn't supported on Windows 2000, but you can still run <a href=\"{0}\">NET Framework 2.0 SP1</a>", "http://www.microsoft.com/downloads/details.aspx?familyid=79BC3B77-E02C-4AD3-AACF-A7633F706BA5&displaylang=en");
        }

        if (request.UserAgent.Contains("Windows 98"))
        {
            netInfoString += String.Format("It looks like you're running Windows 98. Sorry, but .NET 3.5 isn't supported on Windows 98, but you can still run <a href=\"{0}\">NET Framework 2.0 SP1</a>", "http://www.microsoft.com/downloads/details.aspx?familyid=79BC3B77-E02C-4AD3-AACF-A7633F706BA5&displaylang=en");
        }

        if (request.UserAgent.Contains("Windows 95"))
        {
            netInfoString += String.Format("It looks like you're running Windows 95. Sorry, but .NET 3.5 isn't supported on Windows 95, but you can still run <a href=\"{0}\">NET Framework 2.0 SP1</a>", "http://www.microsoft.com/downloads/details.aspx?familyid=79BC3B77-E02C-4AD3-AACF-A7633F706BA5&displaylang=en");
        }

        return netInfoString;
    }

}