using System;
using System.Web;

using SmallestDotNetLib;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string realVersion = null;
        int releaseKey = 0;
        bool runFromChecker = false;
        string userAgentText = this.Request.UserAgent ?? string.Empty;

        // set the Get.NET link button to the latest offline version
        getdotnet.HRef = HttpUtility.HtmlEncode(Constants.LatestDotNetRawUrl);
        getdotnet.Target = "_blank";

        userAgent.Text = HttpUtility.HtmlEncode(userAgentText);

        if (Request.QueryString["realversion"] != null || this.Request.QueryString["releaseKey"] != null)
        {
            realVersion = this.Request.QueryString["realversion"];
            int.TryParse(this.Request.QueryString["releaseKey"], out releaseKey);
            runFromChecker = true;
        }


        UpdateInformationResponse response = Helpers.GetUpdateInformation(userAgentText, realVersion, releaseKey);

        userResult.Text = response.Text;
        developerOnline.Text = String.Format(@"If your users have internet connectivity, the .NET Framework is only between {1} and {2} megs. Why such a wide range? Well, it depends on if they already have some version of .NET.
         If you point your users to the online setup for the {0}, that {3} MB download will automatically detect and download the smallest archive possible to get the job done.", Constants.DotNetOnline, Constants.DotNetOfflineMB - Constants.Version3OfflineMB, Constants.DotNetOfflineMB, Constants.DotNetOnlineMB);

        developerOfflineResult.Text = String.Format(@"If you are a developer and are distributing your code on CD or DVD, you might want to download the 
         {0} on your media. The download is about {1} MB", Constants.DotNetOffline, Constants.DotNetOfflineMB);
        getdotnet.Visible = response.VersionCanBeDetermined;

        if (response.VersionIsLatest)
            getdotnet.Visible = false;

        checkdotnet.Visible = response.CanRunCheckApp;

        // Hide the 4.5 checker section if 
        // (a) we can't determine the dotnet version or 
        // (b) we're on an OS that doesn't support .Net or
        // (c) the user has already run the checker so we know exactly what version they're on.
        // Note that the checkdotnet section in the header will still be displayed as long as the OS supports it
        dotnet45.Visible = response.VersionCanBeDetermined && response.CanRunCheckApp && !runFromChecker;
    }

}
