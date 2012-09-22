using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Constants
/// </summary>
public static class Constants
{
    public const string urlToDotNet35Download = "http://www.microsoft.com/downloads/details.aspx?FamilyId=AB99342F-5D1A-413D-8319-81DA479AB0D7&displaylang=en";
    public const string urlToDotNet2Sp1Download = "http://www.microsoft.com/downloads/details.aspx?familyid=79BC3B77-E02C-4AD3-AACF-A7633F706BA5&displaylang=en";
    public static readonly string htmlLinkToDotNet35Download = String.Format("<a href=\"{0}\">.NET Framework 3.5 SP1</a>", urlToDotNet35Download);
    public const string htmlLinkToWindowsUpdate = "<a href=\"http://www.windowsupdate.com\">Windows Update</a>";
    public const string whyItIsSmallMessage = @" The .NET installer is smart enough to look at your system and automatically download the <strong>smallest upgrade package</strong> possible. 
                           For you, it'll probably be <strong>{0} megabytes total</strong>.";
}
