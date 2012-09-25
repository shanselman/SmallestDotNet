using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using SmallestDotNetLib;

namespace SmallestTest
{
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

            Assert.IsTrue(Helpers.Has10(userAgentCLRString), ".NET Version 1.0");
            Assert.IsTrue(Helpers.Has11(userAgentCLRString), ".NET Version 1.1");
            Assert.IsTrue(Helpers.Has20(userAgentCLRString), ".NET Version 2.0");
            Assert.IsTrue(Helpers.Has35(userAgentCLRString), ".NET Version 3.5");
            Assert.IsTrue(Helpers.Has35SP1C(userAgentCLRString), ".NET Version 3.5 SP1 Client Profile");
            Assert.IsTrue(Helpers.Has35SP1E(userAgentCLRString), ".NET Version 3.5 SP1 Full");
            Assert.IsTrue(Helpers.Has40C(userAgentCLRString), ".NET Version 4.0 Client Profile");
            Assert.IsTrue(Helpers.Has40E(userAgentCLRString), ".NET Version 4.0 Full");
        }
    }
}
