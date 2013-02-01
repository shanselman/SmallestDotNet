namespace SmallestDotNetLib
{
    using System.Collections.Generic;
    using System.Linq;

    public class OperatingSystem
    {
        public string UserAgentVersion { get; set; }
        public string PrettyVersion { get; set; }
        public CLRVersion LatestCLRVersion { get; set; }
    }

    public class OperatingSystems
    {
        public static OperatingSystem Windows8 = new OperatingSystem() { UserAgentVersion = "Windows NT 6.2", PrettyVersion = "Windows 8", LatestCLRVersion = CLRVersions.NET45Full };
        public static OperatingSystem Windows7 = new OperatingSystem() { UserAgentVersion = "Windows NT 6.1", PrettyVersion = "Windows 7", LatestCLRVersion = CLRVersions.NET45Full };
        public static OperatingSystem WindowsVista = new OperatingSystem() { UserAgentVersion = "Windows NT 6.0", PrettyVersion = "Windows Vista", LatestCLRVersion = CLRVersions.NET45Full };
        public static OperatingSystem WindowsXP64ORServer2003 = new OperatingSystem { UserAgentVersion = "Windows NT 5.2", PrettyVersion = "Windows XP x64, Windows Server 2003", LatestCLRVersion = CLRVersions.NET40Full };
        public static OperatingSystem WindowsXP = new OperatingSystem() { UserAgentVersion = "Windows NT 5.1", PrettyVersion = "Windows XP", LatestCLRVersion = CLRVersions.NET40Full };
        public static OperatingSystem Windows2000SP1 = new OperatingSystem() { UserAgentVersion = "Windows NT 5.01", PrettyVersion = "Windows 2000 SP1", LatestCLRVersion = CLRVersions.NET20Full };
        public static OperatingSystem Windows2000 = new OperatingSystem() { UserAgentVersion = "Windows NT 5.0", PrettyVersion = "Windows 2000", LatestCLRVersion = CLRVersions.NET20Full };
        public static OperatingSystem Windows98 = new OperatingSystem() { UserAgentVersion = "Windows 98", PrettyVersion = "Windows 98", LatestCLRVersion = CLRVersions.NET20Full };
        public static OperatingSystem Macintosh = new OperatingSystem() { UserAgentVersion = "Mac", PrettyVersion = "Macintosh", LatestCLRVersion = null };
        public static OperatingSystem UnixBased = new OperatingSystem() { UserAgentVersion = "nix", PrettyVersion = "Unix/Linux", LatestCLRVersion = null };
        public static OperatingSystem Android = new OperatingSystem() { UserAgentVersion = "Android", PrettyVersion = "Android", LatestCLRVersion = null };

        public static List<OperatingSystem> OSVersions = new List<OperatingSystem>
	{
	    Windows8,
	    Windows7,
	    WindowsVista,
	    WindowsXP64ORServer2003,
	    WindowsXP,
	    Windows2000SP1,
	    Windows2000,
	    Windows98,
	    Macintosh,
	    UnixBased
	};

        public static OperatingSystem GetOperatingSystem(string UserAgent)
        {
            return OSVersions.FirstOrDefault(o => UserAgent.Contains(o.UserAgentVersion));
        }

    }
}
