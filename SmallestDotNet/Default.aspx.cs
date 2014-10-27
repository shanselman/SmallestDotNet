using System;
using System.Web;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        userAgent.Text = HttpUtility.HtmlEncode(Request.UserAgent);
        if (Request.QueryString["realversion"] != null)
        {
            userResult.Text = Helpers.GetUpdateInformation(Request.QueryString["realversion"], Request.Browser.ClrVersion);
        }
        else
        {
            userResult.Text = Helpers.GetUpdateInformation(Request.UserAgent, Request.Browser.ClrVersion);
        }
        developerOnline.Text = String.Format(@"If your users have internet connectivity, the .NET Framework is only between {1} and {2} megs. Why such a wide range? Well, it depends on if they already have some version of .NET.
         If you point your users to the online setup for the {0}, that {3} MB download will automatically detect and download the smallest archive possible to get the job done.", Constants.DotNetOnline, Constants.DotNetOfflineMB - Constants.Version3OfflineMB, Constants.DotNetOfflineMB, Constants.DotNetOnlineMB);
        
        developerOfflineResult.Text = String.Format(@"If you are a developer and are distributing your code on CD or DVD, you might want to download the 
         {0} on your media. The download is about {1} MB", Constants.DotNetOffline, Constants.DotNetOfflineMB);

        if (userResult.Text.Contains("can't")) //This is the worst thing I've ever done. We will fix it soon.
        {
            getdotnet.Visible = false;
            checkdotnet.Visible = true;
        }

        if (userResult.Text.Contains("Mac") || userResult.Text.Contains("Linux")) //No, THIS is the worst thing I've ever done. We will fix it soon.
        {
            getdotnet.Visible = false;
            checkdotnet.Visible = false;
        }
        
    }

}
