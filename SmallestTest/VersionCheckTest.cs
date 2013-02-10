using SmallestDotNetLib;

namespace SmallestTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class VersionCheckTest
    {
        private static List<string> CLRVersionStrings()
        {
            return new List<string> 
            {
                ".NET4.0E"
                , ".NET4.0C"
                , ".NET CLR 3.5.30729"
                , ".NET Client 3.5"
                , ".NET CLR 3.5.21022"
                , ".NET CLR 2.0"
                , ".NET CLR 1.1"
                , ".NET CLR 1.0"
            };
        }

        [TestMethod]
        public void CheckAllCLRInUserAgentDetectionStrings()
        {
            var userAgentCLRString = String.Join(" ", CLRVersionStrings().ToArray());
            var userAgentChecker = new UserAgentReader(userAgentCLRString);

            Assert.IsTrue(userAgentChecker.HasDotNet10, ".NET Version 1.0");
            Assert.IsTrue(userAgentChecker.HasDotNet11, ".NET Version 1.1");
            Assert.IsTrue(userAgentChecker.HasDotNet20, ".NET Version 2.0");
            Assert.IsTrue(userAgentChecker.HasDotNet35, ".NET Version 3.5");
            Assert.IsTrue(userAgentChecker.HasDotNet35SP1Client, ".NET Version 3.5 SP1 Client Profile");
            Assert.IsTrue(userAgentChecker.HasDotNet35SP1Full, ".NET Version 3.5 SP1 Full");
            Assert.IsTrue(userAgentChecker.HasDotNet40Client, ".NET Version 4.0 Client Profile");
            Assert.IsTrue(userAgentChecker.HasDotNet40Full, ".NET Version 4.0 Full");
        }

        [TestMethod]
        public void CheckWindows8Detection()
        {
            const string userAgent = "Windows NT 6.2";
            var userAgentReader = new UserAgentReader(userAgent);

            Assert.IsTrue(userAgentReader.HasWindows8, "Windows 8");
        }
    }
}
