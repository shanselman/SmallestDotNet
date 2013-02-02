﻿using System;
using System.Collections.Generic;

/// <summary>
/// A Place for the Strings
/// </summary>
public static class Constants
{
    public static readonly string DotNetOnline = String.Format("<a href=\"{0}\">{1}</a>", Version45URL, Version45Full);
    public const string DotNetOffline = @"http://go.microsoft.com/fwlink/?LinkId=225702";

    public const string WindowsUpdate = "<a href=\"http://www.update.microsoft.com\">Windows Update</a>";
    public const string WhyItIsSmall = @" The .NET installer is smart enough to look at your system and automatically download the <strong>smallest upgrade package</strong> possible. 
                           For you, it'll probably be <strong>{0} megabytes total</strong>.";

    public const string EarlyAdopter = "You're totally up to date! You've got a <strong>{0}</strong> on your machine. ";

    public static readonly Dictionary<string, string> OldWindows = new Dictionary<string, string>
    {
        {"Windows NT 5.0", "Windows 2000"},
        {"Windows 95", "Windows 95"},
        {"Windows 98", "Windows 98"}
    };

    public const string Windows8 = "Windows NT 6.2";

    public const string Version45Detected = "4.5";
    public const string Version45Full = ".NET 4.5";
    public const string Version40Full = ".NET4.0E";
    public const string Version40Client = ".NET4.0C";
    public const string Version35SP1Full = ".NET CLR 3.5.30729";
    public const string Version35SP1Client = ".NET Client 3.5";
    public const string Version35Full = ".NET CLR 3.5";
    public const string Version35Full_1 = ".NET CLR 3.5.21022";
    public const string Version30Full = ".NET CLR 3.0";
    public const string Version30SP2Full = ".NET CLR 3.0.04506.2152";
    public const string Version20Full = ".NET CLR 2.0";
    public const string Version11Full = ".NET CLR 1.1";
    public const string Version10Full = ".NET CLR 1.0";

    public const string Version45OfflineURL = "http://go.microsoft.com/fwlink/?LinkId=225702";

    public const string Version11URL = "http://www.microsoft.com/downloads/details.aspx?FamilyID=a8f5654f-088e-40b2-bbdb-a83353618b38&DisplayLang=en";
    public const string Version20URL = "http://www.microsoft.com/downloads/details.aspx?familyid=5B2C0358-915B-4EB5-9B1D-10E506DA9D0F&displaylang=en";
    public const string Version30URL = "http://www.microsoft.com/downloads/details.aspx?FamilyId=10CC340B-F857-4A14-83F5-25634C3BF043&displaylang=en";
    public const string Version35SP1FullURL = "http://www.microsoft.com/en-us/download/details.aspx?id=22";
    public const string Version35SP1ClientURL = "http://www.microsoft.com/downloads/details.aspx?FamilyId=8CEA6CD1-15BC-4664-B27D-8CEBA808B28B&displaylang=en";
    public const string Version40FullURL = "http://www.microsoft.com/downloads/details.aspx?FamilyID=9f5e8774-c8dc-4ff6-8285-03a4c387c0db&displaylang=en";
    public const string Version40ClientURL = "http://www.microsoft.com/downloads/details.aspx?FamilyID=68a7173d-7ee5-4213-a06f-f2e943ec9249&displaylang=en";
    public const string Version45URL = "http://www.microsoft.com/en-us/download/details.aspx?id=30653";

}
