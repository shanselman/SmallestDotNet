using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib
{
    public class JsonVersions
    {
        public static string WriteLatest(int major, int minor, string profile, int? sp)
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

        public static string WriteAll()
        {
            return "";
        }
    }
}
