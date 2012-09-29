using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallestDotNetLib;

namespace SmallestTest
{
    [TestClass]
    public class JavascriptDomTests
    {
        private string generateLatestVersionString(int major, int minor, string profile, int? sp)
        {
            return String.Format(@"SmallestDotNet.latestVersion = {{
                major: {0},
                minor: {1},
                profile: ""{2}"",
                servicePack: {3}                
            }}", major, minor, profile, sp.HasValue ? sp.ToString() : "null");
        }

        [TestMethod]
        public void Write40AsLatestVersion()
        {
            var userAgent = ".NET 4.0E";

            var expectedVersion = generateLatestVersionString(4, 0, "full", null);

            var actualVersion = JsonVersions.WriteLatestVersions(userAgent);

            Assert.AreEqual(expectedVersion, actualVersion);

        }

        [TestMethod]
        public void Write40ClientAsLatestVersion()
        {
            var userAgent = ".NET 4.0C";

            var expectedVersion = generateLatestVersionString(4, 0, "client", null);

            var actualVersion = JsonVersions.WriteLatestVersions(userAgent);

            Assert.AreEqual(expectedVersion, actualVersion);
        }

        [TestMethod]
        public void Write35SP1AsLatestVersion()
        {
            var userAgent = ".NET CLR 3.5.30729";

            var expectedVersion = generateLatestVersionString(3, 5, "full", 1);

            var actualVersion = JsonVersions.WriteLatestVersions(userAgent);

            Assert.AreEqual(expectedVersion, actualVersion);
        }

        [TestMethod]
        public void Write35SP1ClientAsLatestVersion()
        {
            var userAgent = ".NET Client 3.5";

            var expectedVersion = generateLatestVersionString(3, 5, "client", 1);

            var actualVersion = JsonVersions.WriteLatestVersions(userAgent);

            Assert.AreEqual(expectedVersion, actualVersion);
        }

        [TestMethod]
        public void Write35AsLatestVersion()
        {
            var userAgent = ".NET CLR 3.5.21022";

            var expectedVersion = generateLatestVersionString(3, 5, "full", null);

            var actualVersion = JsonVersions.WriteLatestVersions(userAgent);

            Assert.AreEqual(expectedVersion, actualVersion);
        }

        [TestMethod]
        public void Write20AsLatestVersion()
        {
            var userAgent = ".NET CLR 2.0";

            var expectedVersion = generateLatestVersionString(2, 0, "full", null);

            var actualVersion = JsonVersions.WriteLatestVersions(userAgent);

            Assert.AreEqual(expectedVersion, actualVersion);
        }

        [TestMethod]
        public void Write11AsLatestVersion()
        {
            var userAgent = ".NET CLR 1.1";

            var expectedVersion = generateLatestVersionString(1, 1, "full", null);

            var actualVersion = JsonVersions.WriteLatestVersions(userAgent);

            Assert.AreEqual(expectedVersion, actualVersion);
        }

        [TestMethod]
        public void Write10AsLatestVersion()
        {
            var userAgent = ".NET CLR 1.0";

            var expectedVersion = generateLatestVersionString(1, 0, "full", null);

            var actualVersion = JsonVersions.WriteLatestVersions(userAgent);

            Assert.AreEqual(expectedVersion, actualVersion);
        }

        [TestMethod]
        public void WriteNullAsLatestVersion()
        {
            var userAgent = "";

            var expectedVersion = "SmallestDotNet.latestVersion = null;";

            var actualVersion = JsonVersions.WriteLatestVersions(userAgent);

            Assert.AreEqual(expectedVersion, actualVersion);
        }
    }
}
