using System;
using System.Collections.Generic;
using System.Linq;


namespace SmallestDotNetLib
{
    /// <summary>
    /// Represent A .NET CLR Version
    /// </summary>
    public class CLRVersion
    {
        /// <summary>
        /// The Major Version
        /// </summary>
        public int Major { get; set; }

        /// <summary>
        /// The Minor Version
        /// </summary>
        public int Minor { get; set;}

        /// <summary>
        /// The .NET CLR Profile (Full or Client)
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        /// Service Pack Version, null if none
        /// </summary>
        public int? ServicePack { get; set; }

        /// <summary>
        /// A URL to download the CLR Version Installer
        /// </summary>
        public string Url { get; set; }
        
        /// <summary>
        /// A Human readable string of the .NET CLR Version
        /// </summary>
        public string PrettyVersion { get; set; }

    }
}
