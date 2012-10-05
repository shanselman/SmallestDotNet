using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallestDotNetLib
{
    public class JsonVersions
    {
        /// <summary>
        /// Writes the Latest Version Json 
        /// </summary>
        /// <param name="major">Major Version</param>
        /// <param name="minor">Minor Version</param>
        /// <param name="profile">Profile</param>
        /// <param name="sp">Service Pack</param>
        /// <returns>A Json String Representing the latest version</returns>
        public static string WriteLatestVersion(int major, int minor, string profile, int? sp)
        {
            return String.Format(@"SmallestDotNet.latestVersion = {0};", WriteVersion(major, minor, profile, sp));
        }

        /// <summary>
        /// Writes the Version Json
        /// </summary>
        /// <param name="major">Major Version</param>
        /// <param name="minor">Minor Version</param>
        /// <param name="profile">Profile</param>
        /// <param name="sp">Service Pack</param>
        /// <returns>A Json string representing the version</returns>
        public static string WriteVersion(int major, int minor, string profile, int? sp)
        {
            return String.Format(@"{{
                major: {0},
                minor: {1},
                profile: ""{2}"",
                servicePack: {3}                
            }}", major, minor, profile, sp.HasValue ? sp.ToString() : "null");
        }

        /// <summary>
        /// Writes the Version Json
        /// </summary>
        /// <param name="version">CLRVersion Struct</param>
        /// <returns>A Json string representing the version</returns>
        public static string WriteVersion(CLRVersion version)
        {
            return String.Format(@"{{
                major: {0},
                minor: {1},
                profile: ""{2}"",
                servicePack: {3}                
            }}", version.Major, version.Minor, version.Profile, version.ServicePack.HasValue ? version.ServicePack.ToString() : "null");
        }

        /// <summary>
        /// Write the Download Information Json
        /// </summary>
        /// <param name="major">Major Version</param>
        /// <param name="minor">Minor Version</param>
        /// <param name="profile">.NET CLR Profile</param>
        /// <param name="sp">Service Pack</param>
        /// <param name="url">Download URL</param>
        /// <returns>A Json string representing the version with a download url</returns>
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

        /// <summary>
        /// Write the Download Information Json
        /// </summary>
        /// <param name="version">CLRVersion Struct</param>
        /// <returns>A Json string representing the version with a download url</returns>
        public static string WriteVersionWithDownload(CLRVersion version)
        {
            return String.Format(@"{{
                                        major: {0},
                                        minor: {1},
                                        profile: '{2}',
                                        servicePack: {3},
                                        url: '{4}'
                                    }}",
                       version.Major,
                       version.Minor,
                       version.Profile,
                       version.ServicePack.HasValue ? version.ServicePack.Value.ToString() : "null",
                       version.Url);
        }

        /// <summary>
        /// Writes the Latest Version Json 
        /// </summary>
        /// <param name="version">CLRVersion Struct</param>
        /// <returns></returns>
        public static string WriteLatestVersion(CLRVersion version)
        {
            return String.Format(@"SmallestDotNet.latestVersion = {0};", version != null ?  WriteVersion(version) : "null");
        }

        /// <summary>
        /// Writes the latest .NET CLR Version found in the provided UserAgent String
        /// </summary>
        /// <param name="userAgent">A User Agent String</param>
        /// <returns>A Json string containing the latest .NET CLR Version</returns>
        public static string WriteLatestVersions(string userAgent)
        {
            var latestVersion = (new CLRVersions(userAgent)).GetLatestVersion();

            return WriteLatestVersion(latestVersion);
        }

        /// <summary>
        /// Writes all .NET CLR VErsions found in the User Agent String
        /// </summary>
        /// <param name="userAgent">A User Agent String</param>
        /// <returns>A Json string containing all the CLR Versions found in the User Agent String</returns>
        public static string WriteAllVersions(string userAgent)
        {
            var versions = new List<string>();
            var detectedVersions = (new CLRVersions(userAgent)).GetInstalledVersions();

            foreach (var version in detectedVersions)
            {
                versions.Add(WriteVersion(version.Value));
            }

            return String.Format(@"SmallestDotNet.allVersions = [{0}];", String.Join(",", versions.ToArray()));

        }

       
        private static string _downloadString = "";

        /// <summary>
        /// Writes a Json String Containing Download Information for all of the .NET CLR Versions
        /// </summary>
        /// <returns>A Json String</returns>
        public static string WriteDownloads()
        {
            if (_downloadString == "")
            {
                var DownloadableVersions = CLRVersions.GetDownloadableVersions().Select(p => JsonVersions.WriteVersionWithDownload(p.Value)).ToList();

                _downloadString = String.Format(@"SmallestDotNet.downloadableVersions = [{0}];", String.Join(",", DownloadableVersions.ToArray()));
            }

            return _downloadString;
        }

    }

    
}
