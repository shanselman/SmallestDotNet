using System;
using System.Collections.Generic;
using System.Linq;


namespace SmallestDotNetLib
{
    /// <summary>
    /// Represent A .NET CLR Version
    /// </summary>
    public struct CLRVersion
    {
        /// <summary>
        /// The Major Version
        /// </summary>
        public int Major;

        /// <summary>
        /// The Minor Version
        /// </summary>
        public int Minor;

        /// <summary>
        /// The .NET CLR Profile (Full or Client)
        /// </summary>
        public string Profile;

        /// <summary>
        /// Service Pack Version, null if none
        /// </summary>
        public int? ServicePack;

        /// <summary>
        /// A URL to download the CLR Version Installer
        /// </summary>
        public string Url;

        public CLRVersion(int major, int minor, string profile, int? servicePack, string url)
        {
            Major = major;
            Minor = minor;
            Profile = profile;
            ServicePack = servicePack;
            Url = url;
        }


    }

    /// <summary>
    /// Contains Methods for discovering information about CLR Versions
    /// </summary>
    public class CLRVersions
    {
        private static CLRVersion NET10Full = new CLRVersion(1, 0, "full", null, "");
        private static CLRVersion NET11Full = new CLRVersion(1, 1, "full", null, Constants.Version11URL);
        private static CLRVersion NET20Full = new CLRVersion(2, 0, "full", null, Constants.Version20URL);
        private static CLRVersion NET30Full = new CLRVersion(3, 0, "full", null, Constants.Version30URL);
        private static CLRVersion NET35Full = new CLRVersion(3, 5, "full", null, "");
        private static CLRVersion NET35SP1Client = new CLRVersion(3, 5, "client", 1, Constants.Version35SP1ClientURL);
        private static CLRVersion NET35SP1Full = new CLRVersion(3, 5, "full", 1, Constants.Version35SP1FullURL);
        private static CLRVersion NET40Client = new CLRVersion(4, 0, "client", null, Constants.Version40ClientURL);
        private static CLRVersion NET40Full = new CLRVersion(4, 0, "full", null, Constants.Version40FullURL);
        private static CLRVersion NET45Full = new CLRVersion(4, 5, "full", null, Constants.Version45URL);

        /// <summary>
        /// A Dictionary of CLR Versions with information
        /// </summary>
        public static Dictionary<string, CLRVersion> Versions = new Dictionary<string, CLRVersion>
        {
            {Constants.Version10Full, NET10Full},
            {Constants.Version11Full, NET11Full},
            {Constants.Version20Full, NET20Full},
            {Constants.Version30Full, NET30Full},
            {Constants.Version35Full, NET35Full},
            {Constants.Version35SP1Client, NET35SP1Client},
            {Constants.Version35SP1Full, NET35SP1Full},
            {Constants.Version40Client, NET40Client},
            {Constants.Version40Full, NET40Full},
            {Constants.Version45Full, NET45Full}
        };

        /// <summary>
        /// Gets all downloadable CLR Versions represented in the Versions Dictionary
        /// </summary>
        /// <returns>A Dictionary<string, CLRVersion> containing Versions with a download url</returns>
        public static Dictionary<string, CLRVersion> GetDownloadableVersions()
        {
            return Versions.Where(pair => pair.Value.Url != "").ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public string UserAgent { get; set; }
        public CLRVersions(string userAgent)
        {
            UserAgent = userAgent;
        }

        public Dictionary<string, CLRVersion> GetInstalledVersions()
        {
            var results = new Dictionary<string, CLRVersion>();

            var foundVersions = UserAgent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries).Where(s => s.Contains(".NET"));

            
            foreach (string match in foundVersions)
            {
                var v = match.Trim();
                //this really sucks and makes me mad
                if (v.Contains(Constants.Version35Full) && !v.Contains(Constants.Version35SP1Client) && !v.Contains(Constants.Version35SP1Full)) v = Constants.Version35Full;
                if (v.Contains(Constants.Version30Full)) v = Constants.Version30Full;
                if (v.Contains(Constants.Version20Full)) v = Constants.Version20Full;
                if (v.Contains(Constants.Version11Full)) v = Constants.Version11Full;
                if (v.Contains(Constants.Version10Full)) v = Constants.Version10Full;
                if (Versions.ContainsKey(v))
                {
                    var version = Versions[v];
                    results.Add(v, version);
                }
            }

            if (Helpers.HasWindows8(UserAgent))
            {
                results.Add(Constants.Version45Full, Versions[Constants.Version45Full]);
            }

            return results;
        }

        public CLRVersion? GetLatestVersion()
        {
            var installedVersions = GetInstalledVersions();

            installedVersions = installedVersions.OrderByDescending(p => p.Value.Major)
                .ThenByDescending(p => p.Value.Minor)
                .ThenByDescending(p => p.Value.Profile)
                .ThenByDescending(p => p.Value.ServicePack ?? 0)
                .ToDictionary(p => p.Key, p => p.Value);

            if (installedVersions.Any())
            {
                return installedVersions.First().Value;
            }

            return null;
        }

    }
}
