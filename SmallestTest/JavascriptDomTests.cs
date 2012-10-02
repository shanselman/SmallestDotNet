using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallestDotNetLib;
using System.Linq;

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
        public void WriteOnlyVersionsThatHaveLinksForDownload()
        {
            var downloadableVersions = CLRVersions.GetDownloadableVersions();
            
            Assert.IsTrue(downloadableVersions.All(pair => pair.Value.Url != ""));

        }


        [TestMethod]
        public void Write40AsLatestVersion()
        {
            var userAgent = ".NET4.0E";

            var expectedVersion = generateLatestVersionString(4, 0, "full", null);

            var actualVersion = JsonVersions.WriteLatestVersions(userAgent);

            Assert.AreEqual(expectedVersion, actualVersion);

        }

        [TestMethod]
        public void Write40ClientAsLatestVersion()
        {
            var userAgent = ".NET4.0C";

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


        //This test is very white space sensitive currently.
        //Needs to be cleaned up where it is only looking at the actual JSON objects
        [TestMethod]
        public void WritesCorrectDownloadVersionJson()
        {

            var expected = @"SmallestDotNet.downloadableVersions = [{
                                        major: 1,
                                        minor: 1,
                                        profile: 'full',
                                        servicePack: null,
                                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyID=a8f5654f-088e-40b2-bbdb-a83353618b38&DisplayLang=en'
                                    },{
                                        major: 2,
                                        minor: 0,
                                        profile: 'full',
                                        servicePack: null,
                                        url: 'http://www.microsoft.com/downloads/details.aspx?familyid=5B2C0358-915B-4EB5-9B1D-10E506DA9D0F&displaylang=en'
                                    },{
                                        major: 3,
                                        minor: 0,
                                        profile: 'full',
                                        servicePack: null,
                                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyId=10CC340B-F857-4A14-83F5-25634C3BF043&displaylang=en'
                                    },{
                                        major: 3,
                                        minor: 5,
                                        profile: 'client',
                                        servicePack: 1,
                                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyId=8CEA6CD1-15BC-4664-B27D-8CEBA808B28B&displaylang=en'
                                    },{
                                        major: 3,
                                        minor: 5,
                                        profile: 'full',
                                        servicePack: 1,
                                        url: 'http://www.microsoft.com/en-us/download/details.aspx?id=22'
                                    },{
                                        major: 4,
                                        minor: 0,
                                        profile: 'client',
                                        servicePack: null,
                                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyID=68a7173d-7ee5-4213-a06f-f2e943ec9249&displaylang=en'
                                    },{
                                        major: 4,
                                        minor: 0,
                                        profile: 'full',
                                        servicePack: null,
                                        url: 'http://www.microsoft.com/downloads/details.aspx?FamilyID=9f5e8774-c8dc-4ff6-8285-03a4c387c0db&displaylang=en'
                                    },{
                                        major: 4,
                                        minor: 5,
                                        profile: 'full',
                                        servicePack: null,
                                        url: 'http://www.microsoft.com/en-us/download/details.aspx?id=30653'
                                    }];";

            var actual = JsonVersions.WriteDownloads();

            Assert.AreEqual(expected, actual);

        }
    }
}
