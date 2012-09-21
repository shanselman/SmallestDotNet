using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
       string whyitissmall = @" The .NET installer is smart enough to look at your system and automatically download the <strong>smallest upgrade package</strong> possible. 
                           For you, it'll probably be <strong>{0} megabytes total</strong>.";

       getdotnet.HRef = Constants.dotnet35url;
       userResult.Text = "";

       bool net4 = false;

       if (Request.UserAgent.Contains(".NET4.0E"))
       {
           userResult.Text += String.Format("Seem you're an early adopter! You've got a <strong>full install of .NET 4.0</strong> on your machine. ");
           net4 = true;
       }
       else if (Request.UserAgent.Contains(".NET4.0C"))
       {
           userResult.Text += String.Format("Seem you're an early adopter! You've got the <strong>.NET 4.0 Client Profile</strong> on your machine. ");
           net4 = true;
       }


       Version version = Request.Browser.ClrVersion;
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
                         string explain = String.Format(whyitissmall, "around 45-60");
                          userResult.Text += String.Format("Looks like you've {3} got a <strong>pretty old version of .NET</strong>. You should make sure your computer is up to date by visiting {0} then downloading the {1} from Microsoft. {2}", Constants.windowsupdate, Constants.dotnet35online, explain, net4 ? "also" : "");
                      }
                      break;
                }
                break;
             case 2:
                {
                   string explain = String.Format(whyitissmall, "around 33");
                   userResult.Text += String.Format(@"Looks like you {2} have <strong>.NET version 2.0</strong>. 
                     That's a fairly recent version of the .NET Framework, but you can upgrade fairly easily to the newest version by downloading the 2.8 meg ""bootstrapper"" for {0}. {1}", Constants.dotnet35online, explain, net4 ? "also" : "");
                }
                break;
             case 3:
                switch (version.Minor)
                {
                   case 0:
                      {
                         string explain = String.Format(whyitissmall, "only 10");
                         userResult.Text += String.Format(@"Looks like you {2} have <strong>.NET version 3.0</strong>. 
                     That's a very recent version of the .NET Framework, but you can upgrade fairly easily to the 3.5 version by downloading the 2.8 meg installer for {0}. {1}", Constants.dotnet35online, explain, net4 ? "also" : "");
                      }
                      break;
                   case 5:
                      switch (version.Build)
                      {
                         case 21022: //RTM
                              userResult.Text += String.Format("Looks like you {2} have <strong>.NET version 3.5</strong>. The latest version is 3.5 SP1. You can upgrade quickly with this small download for {0}. Also, you should make sure your system is setup to get updates from {1} automatically. This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.dotnet35online, Constants.windowsupdate, net4 ? "also" : "");
                            break;
                         case 30729: //SP1
                            userResult.Text += String.Format("Looks like you {1} have <strong>.NET version 3.5 SP1</strong>. That's the VERY latest .NET Framework. <strong>You don't need to do anything right now.</strong> However, you might make sure your system is setup to get updates from {0} automatically. This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.windowsupdate, net4 ? "also" : "");
                            break;
                         default:
                            userResult.Text += String.Format("Looks like you <i>might</i> {2} have a <em>beta</em> version of <strong>.NET version 3.5 SP1</strong>. Perhaps you're a programmer or you know one? You should probably uninstall that version and run the small setup program for {0}. Also, you might make sure your system is setup to get updates from {1} automatically. This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.dotnet35online, Constants.windowsupdate, net4 ? "also" : "");
                            getdotnet.HRef = Constants.dotnet35url;
                            break;
                      }
                      break;
                }
                break;
          }
       }
       else
       {
          if (Request.UserAgent.Contains("fox"))
          {
              userResult.Text += String.Format(@"Looks like you're running FireFox. That's totally cool, but if you've got a version of .NET earlier than 3.5 SP1, I can't tell if you've got .NET installed from FireFox. 
                   Consider visiting this site, just once, using Internet Explorer, which will tell me more about if your system has .NET on it or not. 
                  Alternatively, if you're running Windows, you can go <strong>download the 2.8 meg installer for {0}.</strong> 
                  Also, you might make sure your system is setup to get updates from {1} automatically. 
                  This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.dotnet35online, Constants.windowsupdate);
          }
          else
          {
             string explain = String.Format(whyitissmall, 60);
             userResult.Text += String.Format(@"I can't tell if you've got .NET installed. Perhaps you don't have .NET installed or perhaps 
                  your browser isn't letting me know. Consider visiting this site using Internet Explorer, which will tell me more about if your system has .NET on it or not. Alternatively, if you're running Windows, you can go <strong>download the 2.8 meg installer for {0}.</strong> {1}
                  Also, you might make sure your system is setup to get updates from {2} automatically. 
                  This will make sure your system is up to date with the lastest stuff, including the latest .NET Framework.", Constants.dotnet35online, explain, Constants.windowsupdate);
          }

       }
       userAgent.Text = "<strong>" + HttpUtility.HtmlEncode(Request.UserAgent) + "</strong>";
       developerOnline.Text = String.Format(@"If your users have internet connectivity, the .NET Framework is only between 10 and 60 megs. Why such a wide range? Well, it depends on if they already have some version of .NET. 
         If you point your users to the online setup for the {0}, that 2.8 meg download will automatically detect and download the smallest archive possible to get the job done.", Constants.dotnet35online);
       developerOfflineResult.Text = String.Format(@"If you are a developer and are distributing your code on CD or DVD, you might want to download the 
                  <a href=""{0}"">FULL OFFLINE .NET 3.5 installation</a> on your media. The download is about 200 megs, but again,
                  that contains all the different 50-60 meg installs that any one system might need.",
               "http://download.microsoft.com/download/2/0/e/20e90413-712f-438c-988e-fdaa79a8ac3d/dotnetfx35.exe");
//       developerCPOnline.Text = @"Soon, Microsoft will release a super-small download for XP SP2 machines that have no version of the .NET Framework. 
//               It's a 280k setup program that will download the ""Client Profile"" of the .NET Framework that's only about 26megs and will run most Client .NET applications.
//               Then, in the next few months, those ""Client Profile"" will receive the rest of the complete .NET Framework (another 30 or so megs) over Windows Update. More details on the Client Profile will be coming in September!";

       if (Request.UserAgent.Contains("Mac"))
       {
           userResult.Text += "It looks like you're running a Mac. There's no .NET Framework download from Microsoft for the Mac, but you might check out either <a href=\"http://www.microsoft.com/silverlight/resources/install.aspx\">Silverlight</a> which is a browser plugin that includes a small version of the .NET Framework. You could also check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on a Mac.";
       }

       if (Request.UserAgent.Contains("nix"))
       {
           userResult.Text += "It looks like you're running a Unix machine. There's no .NET Framework download from Microsoft for Unix, but you might check out <a href=\"http://www.go-mono.com/mono-downloads/download.html\">Mono</a>, which is an Open Source platform that can run .NET code on Unix.";
       }


       //need to see if windows 2000 has the latest version
       if (Request.UserAgent.Contains("Windows NT 5.0"))
       {
           userResult.Text += String.Format("It looks like you're running Windows 2000. Sorry, but .NET 3.5 isn't supported on Windows 2000, but you can still run <a href=\"{0}\">NET Framework 2.0 SP1</a>", "http://www.microsoft.com/downloads/details.aspx?familyid=79BC3B77-E02C-4AD3-AACF-A7633F706BA5&displaylang=en");
       }

       if (Request.UserAgent.Contains("Windows 98"))
       {
           userResult.Text += String.Format("It looks like you're running Windows 98. Sorry, but .NET 3.5 isn't supported on Windows 98, but you can still run <a href=\"{0}\">NET Framework 2.0 SP1</a>", "http://www.microsoft.com/downloads/details.aspx?familyid=79BC3B77-E02C-4AD3-AACF-A7633F706BA5&displaylang=en");
       }

       if (Request.UserAgent.Contains("Windows 95"))
       {
           userResult.Text += String.Format("It looks like you're running Windows 95. Sorry, but .NET 3.5 isn't supported on Windows 95, but you can still run <a href=\"{0}\">NET Framework 2.0 SP1</a>", "http://www.microsoft.com/downloads/details.aspx?familyid=79BC3B77-E02C-4AD3-AACF-A7633F706BA5&displaylang=en");
       }        

    }
}

