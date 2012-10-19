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


        getdotnet.HRef = Constants.Version45URL;
        
        userAgent.Text = HttpUtility.HtmlEncode(Request.UserAgent);
        if (Request.QueryString["realversion"] == "")
        {
            userResult.Text = Helpers.GetUpdateInformation(Request.QueryString["realversion"], Request.Browser.ClrVersion);
        }
        else
        {
            userResult.Text = Helpers.GetUpdateInformation(Request.UserAgent, Request.Browser.ClrVersion);
        }
        developerOnline.Text = String.Format(@"If your users have internet connectivity, the .NET Framework is only between 10 and 60 megs. Why such a wide range? Well, it depends on if they already have some version of .NET. 
         If you point your users to the online setup for the {0}, that 980 KB download will automatically detect and download the smallest archive possible to get the job done.", Constants.DotNetOnline);
        
        developerOfflineResult.Text = String.Format(@"If you are a developer and are distributing your code on CD or DVD, you might want to download the 
                  <a href=""{0}"">FULL OFFLINE .NET 4.5 installation</a> on your media. The download is about 48 MB", Constants.DotNetOffline);

    }

}
