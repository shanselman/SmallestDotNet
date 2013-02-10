using System;
using System.Collections.Generic;

namespace SmallestDotNetLib
{
    /// <summary>
    /// A Class containing general purposes methods
    /// </summary>
    public class Helpers
    {
        public static string GetUpdateInformation(string userAgentString, Version version)
        {
            var userAgent = new UserAgentReader(userAgentString);
            string netInfoString = "";

            //We should check this first since we don't need to check .NET versions if they can't have .NET versions
            if (userAgent.HasMac)
            {
                netInfoString = "It looks like you're running a Mac or an iPhone. There's no .NET Framework download from Microsoft for the Mac, but you might check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on a Mac. For your iPhone, check out <a href=\"http://xamarin.com/monotouch\">MonoTouch</a> and write .NET apps for iOS!";
                return netInfoString;
            }
            if (userAgent.HasUnix)
            {
                netInfoString = "It looks like you're running a Unix machine. There's no .NET Framework download from Microsoft for Unix, but you might check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on Unix.";
                return netInfoString;
            }

            bool net4 = (GetWindows8Message(userAgentString, ref netInfoString) || Get40Message(userAgentString, ref netInfoString));
            if (userAgent.HasDotNet35X)
            {
                netInfoString += DotNet3_5Message((userAgent.HasDotNet35SP1Client || userAgent.HasDotNet35SP1Full), net4);
            }
            else if (userAgent.HasDotNet30)
            {
                netInfoString += DotNet3Message(net4);
            }
            else if (userAgent.HasDotNet20)
            {
                netInfoString += DotNet2Message(net4);
            }
            else if (userAgent.HasDotNet11 || userAgent.HasDotNet10)
            {
                netInfoString += DotNet1Message(net4);
            }
            else if (!net4)
            {
                if (userAgentString.Contains("fox"))
                {
                    netInfoString += MessageForBrowser("Firefox");
                }
                else if (userAgentString.Contains("Chrome"))
                {
                    netInfoString += MessageForBrowser("Chrome");
                }
                else if (userAgentString.Contains("Safari")) // Chrome also uses safari in the user agent so this check must come after
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
                netInfoString += CheckDotNet3_5UnSupportedOs(userAgentString, windowsVersion.Key, windowsVersion.Value);
            }

            return netInfoString;
        }

        private static bool GetWindows8Message(string UserAgent, ref string userMessage)
        {
            var userAgent = new UserAgentReader(UserAgent);
            if (userAgent.HasWindows8 || userAgent.HasDotNet45)
            {
                userMessage += String.Format(Constants.EarlyAdopter, "full install of .NET 4.5");
                return true;
            }

            return false;
        }

        private static bool Get40Message(string UserAgent, ref string userMessage)
        {
            var userAgentChecker = new UserAgentReader(UserAgent);
            var whichVersion = "";
            var ret = false;
            if (userAgentChecker.HasDotNet40Full)
            {
                whichVersion = ".NET 4.0";
                ret = true;
            }
            else if (userAgentChecker.HasDotNet40Client)
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
    }
}