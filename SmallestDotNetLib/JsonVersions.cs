using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib
{
    public class JsonVersions
    {
        public static string WriteLatestVersion(int major, int minor, string profile, int? sp)
        {
            return String.Format(@"SmallestDotNet.latestVersion = {0}", WriteVersion(major, minor, profile, sp));
        }

        public static string WriteVersion(int major, int minor, string profile, int? sp)
        {
            return String.Format(@"{{
                major: {0},
                minor: {1},
                profile: ""{2}"",
                servicePack: {3}                
            }}", major, minor, profile, sp.HasValue ? sp.ToString() : "null");
        }


        public static string WriteVersionWithDownload(int major, int minor, string profile, int? sp, string url)
        {
            return String.Format(@"{{
                major: {0},
                minor: {1},
                profile: ""{2}"",
                servicePack: {3},
                url: {4}
            }}", major, minor, profile, sp.HasValue ? sp.ToString() : "null", url);
        }

        public static string WriteLatestVersions(string userAgent)
        {
            if (Helpers.Has40E(userAgent))
                return WriteLatestVersion(4, 0, "full", null);
            else if (Helpers.Has40C(userAgent))
                return WriteLatestVersion(4, 0, "client", null);
            else if (Helpers.Has35SP1E(userAgent))
                return WriteLatestVersion(3, 5, "full", 1);
            else if (Helpers.Has35SP1C(userAgent))
                return WriteLatestVersion(3, 5, "client", 1);
            else if (Helpers.Has35(userAgent))
                return WriteLatestVersion(3, 5, "full", null);
            else if (Helpers.Has20(userAgent))
                return WriteLatestVersion(2, 0, "full", null);
            else if (Helpers.Has11(userAgent))
                return WriteLatestVersion(1, 1, "full", null);
            else if (Helpers.Has10(userAgent))
                return WriteLatestVersion(1, 0, "full", null);
            else
                return "SmallestDotNet.latestVersion = null;";
        }

        public static string WriteAllVersions(string userAgent)
        {
            var versions = new List<string>();

            if (Helpers.Has40E(userAgent))
                versions.Add(WriteVersion(4, 0, "full", null));

            if (Helpers.Has40C(userAgent))
                versions.Add(WriteVersion(4, 0, "client", null));

            if (Helpers.Has35SP1E(userAgent))
                versions.Add(WriteVersion(3, 5, "full", 1));

            if (Helpers.Has35SP1C(userAgent))
                versions.Add(WriteVersion(3, 5, "client", 1));

            if (Helpers.Has35(userAgent))
                versions.Add(WriteVersion(3, 5, "full", null));

            if (Helpers.Has20(userAgent))
                versions.Add(WriteVersion(2, 0, "full", null));

            if (Helpers.Has11(userAgent))
                versions.Add(WriteVersion(1, 1, "full", null));

            if (Helpers.Has10(userAgent))
                versions.Add(WriteVersion(1, 0, "full", null));

            return String.Format(@"SmallestDotNet.allVersions = [{0}];", String.Join(",", versions.ToArray()));

        }

        public static string WriteDownloads(string userAgent)
        {
            return @"
                SmallestDotNet.downloadableVersions =
                [{
                        major: 4,
                        minor: 0,
                        profile: 'client',
                        servicePack: null,
                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyID=68a7173d-7ee5-4213-a06f-f2e943ec9249&displaylang=en'                                        
                },{
                        major: 4,
                        minor: 0,
                        profile: 'full',
                        servicePack: null,
                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyID=9f5e8774-c8dc-4ff6-8285-03a4c387c0db&displaylang=en'                                        
                },{
                        major: 3,
                        minor: 5,
                        profile: 'client',
                        servicePack: 1,
                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyId=8CEA6CD1-15BC-4664-B27D-8CEBA808B28B&displaylang=en'                        
                },{
                        major: 3,
                        minor: 5,
                        profile: 'full',
                        servicePack: 1,               
                        url: 'http://go.microsoft.com/fwlink/?LinkId=124150'                                        
                },{
                        major: 3,
                        minor: 0,
                        profile: 'full',
                        servicePack: 1,
                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyId=10CC340B-F857-4A14-83F5-25634C3BF043&displaylang=en'                                        
                },{
                        major: 2,
                        minor: 0,
                        profile: 'full',
                        servicePack: 2,
                        url: 'http://www.microsoft.com/downloads/details.aspx?familyid=5B2C0358-915B-4EB5-9B1D-10E506DA9D0F&displaylang=en'                                        
                },{
                        major: 1,
                        minor: 1,
                        profile: 'full',
                        servicePack: 1,
                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyID=a8f5654f-088e-40b2-bbdb-a83353618b38&DisplayLang=en'                                        
                }];
                ";
        }

    }
}
