namespace SmallestTest
{
    using System.Globalization;

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

            Assert.IsTrue(Helpers.Has10(userAgentCLRString), ".NET Version 1.0");
            Assert.IsTrue(Helpers.Has11(userAgentCLRString), ".NET Version 1.1");
            Assert.IsTrue(Helpers.Has20(userAgentCLRString), ".NET Version 2.0");
            Assert.IsTrue(Helpers.Has35(userAgentCLRString), ".NET Version 3.5");
            Assert.IsTrue(Helpers.Has35SP1C(userAgentCLRString), ".NET Version 3.5 SP1 Client Profile");
            Assert.IsTrue(Helpers.Has35SP1E(userAgentCLRString), ".NET Version 3.5 SP1 Full");
            Assert.IsTrue(Helpers.Has40C(userAgentCLRString), ".NET Version 4.0 Client Profile");
            Assert.IsTrue(Helpers.Has40E(userAgentCLRString), ".NET Version 4.0 Full");
        }

        [TestMethod]
        public void CheckWindows8Detection()
        {
            var userAgent = "Windows NT 6.2";

            Assert.IsTrue(Helpers.HasWindows8(userAgent), "Windows 8");
            userAgent = "Windows NT 6.3";

            Assert.IsTrue(Helpers.HasWindows8(userAgent), "Windows 8.1");
        }

        [TestMethod]
        public void CheckRealVersion()
        {
            // Arrange
            const string UserAgent = ".NET Version 1.0";
            const string RealVersion = "4.5.1";
            const string CheckerApplicationText = "The .Net Checker application determined that you have";
            const string UnableToDetermineText = "The application was not able to determine the exact version you have.";
            var releaseKey = 0;

            // Act
            string message = Helpers.GetUpdateInformation(UserAgent, RealVersion, releaseKey).Text;

            // Assert
            StringAssert.StartsWith(message, CheckerApplicationText);
            StringAssert.Contains(message, RealVersion);
            Assert.IsFalse(message.Contains(UnableToDetermineText), "The '...not able to determine the exact version...' message should NOT appear if realVersion is present and releaseKey=0");
   
            foreach (var releaseVersion in Constants.ReleaseVersions)
            {
                // Arrange
                releaseKey = releaseVersion.Key;

                // Act
                message = Helpers.GetUpdateInformation(UserAgent, null, releaseKey).Text;

                // Assert
                StringAssert.StartsWith(message, CheckerApplicationText);
                StringAssert.Contains(message, releaseVersion.Value);
                Assert.IsFalse(message.Contains(UnableToDetermineText), "The '...not able to determine the exact version...' message should NOT appear if releaseKey is contained in Constants.ReleaseVersions");

                // Arrange
                releaseKey = releaseVersion.Key + 1;

                // Act
                message = Helpers.GetUpdateInformation(UserAgent, null, releaseKey).Text;

                // Assert
                StringAssert.StartsWith(message, CheckerApplicationText);
                StringAssert.Contains(message, releaseVersion.Value + " or greater");
                StringAssert.Contains(message, UnableToDetermineText, "The '...not able to determine the exact version...' message SHOULD appear if releaseKey is not contained in Constants.ReleaseVersions");
            }
        }
    }
}
