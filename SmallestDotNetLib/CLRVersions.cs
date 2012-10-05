using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallestDotNetLib
{
    /// <summary>
    /// Contains Methods for discovering information about CLR Versions
    /// </summary>
    public class CLRVersions
    {
        private static CLRVersion NET10Full = new CLRVersion() { Major = 1, Minor = 0, Profile = "full", PrettyVersion = ".NET 1.0" };
        private static CLRVersion NET11Full = new CLRVersion() { Major = 1, Minor = 1, Profile = "full", Url = Constants.Version11URL, PrettyVersion = ".NET 1.1" };
        private static CLRVersion NET20Full = new CLRVersion() { Major = 2, Minor = 0, Profile = "full", Url = Constants.Version20URL, PrettyVersion = ".NET 2.0" };
        private static CLRVersion NET30Full = new CLRVersion() { Major = 3, Minor = 0, Profile = "full", Url = Constants.Version30URL, PrettyVersion = ".NET 3.0" };
        private static CLRVersion NET35Full = new CLRVersion() { Major = 3, Minor = 5, Profile = "full", PrettyVersion = ".NET 3.5" };
        private static CLRVersion NET35SP1Client = new CLRVersion() { Major = 3, Minor = 5, Profile = "client", ServicePack = 1, Url = Constants.Version35SP1ClientURL, PrettyVersion = ".NET 3.5 Client SP1" };
        private static CLRVersion NET35SP1Full = new CLRVersion() { Major = 3, Minor = 5, Profile = "full", ServicePack = 1, Url = Constants.Version35SP1FullURL, PrettyVersion = ".NET 3.5 SP1" };
        private static CLRVersion NET40Client = new CLRVersion() { Major = 4, Minor = 0, Profile = "client", Url = Constants.Version40ClientURL, PrettyVersion = ".NET 4.0 Client" };
        private static CLRVersion NET40Full = new CLRVersion() { Major = 4, Minor = 0, Profile = "full", Url = Constants.Version40FullURL, PrettyVersion = ".NET 4.0" };
        private static CLRVersion NET45Full = new CLRVersion() { Major = 4, Minor = 5, Profile = "full", Url = Constants.Version45URL, PrettyVersion = ".NET 4.5" };

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

        public CLRVersion GetLatestVersion()
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
