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


        getdotnet.HRef = Constants.dotnet35url;
        userResult.Text = "";

        userAgent.Text = "<strong>" + HttpUtility.HtmlEncode(Request.UserAgent) + "</strong>";

        userResult.Text = Helpers.GetUpdateInformation(Request);

        developerOnline.Text = String.Format(@"If your users have internet connectivity, the .NET Framework is only between 10 and 60 megs. Why such a wide range? Well, it depends on if they already have some version of .NET. 
         If you point your users to the online setup for the {0}, that 2.8 meg download will automatically detect and download the smallest archive possible to get the job done.", Constants.dotnet35online);
        developerOfflineResult.Text = String.Format(@"If you are a developer and are distributing your code on CD or DVD, you might want to download the 
                  <a href=""{0}"">FULL OFFLINE .NET 3.5 installation</a> on your media. The download is about 200 megs, but again,
                  that contains all the different 50-60 meg installs that any one system might need.",
                "http://download.microsoft.com/download/2/0/e/20e90413-712f-438c-988e-fdaa79a8ac3d/dotnetfx35.exe");

    }

}

