using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SmallestDotNetLib
{
    public struct CLRVersion
    {
        public int Major;
        public int Minor;
        public string Profile;
        public int? ServicePack;
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

    public class CLRVersions
    {
        public static Dictionary<string, CLRVersion> Versions = new Dictionary<string, CLRVersion>
        {
            {Constants.Version10Full, new CLRVersion(1, 0, "full", null, "")},
            {Constants.Version11Full, new CLRVersion(1, 1, "full", null, Constants.Version11URL)},
            {Constants.Version20Full, new CLRVersion(2, 0, "full", null, Constants.Version20URL)},
            {Constants.Version30Full, new CLRVersion(3, 0, "full", null, Constants.Version30URL)},
            {Constants.Version35Full, new CLRVersion(3, 5, "full", null, "")},
            {Constants.Version35SP1Client, new CLRVersion(3, 5, "client", 1, Constants.Version35SP1ClientURL)},
            {Constants.Version35SP1Full, new CLRVersion(3, 5, "full", 1, Constants.Version35SP1FullURL)},
            {Constants.Version40Client, new CLRVersion(4, 0, "client", null, Constants.Version40ClientURL)},
            {Constants.Version40Full, new CLRVersion(4, 0, "full", null, Constants.Version40FullURL)}
        };

        public static Dictionary<string, CLRVersion> GetDownloadableVersions()
        {
            return Versions.Where(pair => pair.Value.Url != "").ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}
