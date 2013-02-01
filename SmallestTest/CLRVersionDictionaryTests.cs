using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallestDotNetLib;
using System.Drawing;
using System.Collections;

namespace SmallestTest
{
    [TestClass]
    public class CLRVersionDictionaryTests
    {
        [TestMethod]
        public void ParseVersionsProperlyTest()
        {
            var UserAgent = @"Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E; InfoPath.3; MS-RTC LM 8)";

            var expected = new Dictionary<string, CLRVersion>();

            expected.Add(Constants.Version20Full, CLRVersions.Versions[Constants.Version20Full]);
            expected.Add(Constants.Version30Full, CLRVersions.Versions[Constants.Version30Full]);
            expected.Add(Constants.Version35SP1Full, CLRVersions.Versions[Constants.Version35SP1Full]);
            expected.Add(Constants.Version40Client, CLRVersions.Versions[Constants.Version40Client]);
            expected.Add(Constants.Version40Full, CLRVersions.Versions[Constants.Version40Full]);

            var CLRVersionFac = new CLRVersions(UserAgent);
            var actual = CLRVersionFac.GetInstalledVersions();

            
            CollectionAssert.AreEquivalent((ICollection)expected, (ICollection)actual);

            var expectedLatestVersion = CLRVersions.Versions[Constants.Version40Full];
            var actualLatestVersion = CLRVersionFac.GetLatestVersion();
            Assert.IsTrue(actualLatestVersion != null, "Version is not null");
            
            Assert.AreEqual(expectedLatestVersion.Major, actualLatestVersion.Major, "Major Versions Are the Same");
            Assert.AreEqual(expectedLatestVersion.Minor, actualLatestVersion.Minor, "Minor Versions Are the Same");
            Assert.AreEqual(expectedLatestVersion.Profile, actualLatestVersion.Profile, "Profile is the Same");
            Assert.AreEqual(expectedLatestVersion.ServicePack, actualLatestVersion.ServicePack, "Service Pack is the Same");

        }
    }
}
