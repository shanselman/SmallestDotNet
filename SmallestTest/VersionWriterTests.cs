using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmallestDotNetLib;

namespace SmallestTest
{
    [TestClass]
    public class VersionWriterTests
    {
        [TestMethod]
        public void Test10Version()
        {
            var expected = @"{
                major: 1,
                minor: 0,
                profile: ""full"",
                servicePack: null                
            }";
            
            int? servicePack = null;

            var actual = SmallestDotNetLib.JsonVersions.WriteVersion(1, 0, "full", servicePack);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test11Json()
        {
            var expected = @"{
                major: 1,
                minor: 1,
                profile: ""full"",
                servicePack: null                
            }";

            int? servicePack = null;

            var actual = SmallestDotNetLib.JsonVersions.WriteVersion(1, 1, "full", servicePack);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test20Json()
        {
            var expected = @"{
                major: 2,
                minor: 0,
                profile: ""full"",
                servicePack: null                
            }";

            int? servicePack = null;

            var actual = SmallestDotNetLib.JsonVersions.WriteVersion(2, 0, "full", servicePack);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Test35Json()
        {
            var expected = @"{
                major: 3,
                minor: 5,
                profile: ""full"",
                servicePack: null                
            }";

            int? servicePack = null;

            var actual = SmallestDotNetLib.JsonVersions.WriteVersion(3, 5, "full", servicePack);

            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void Test35ServicePackOneJson()
        {
            var expected = @"{
                major: 3,
                minor: 5,
                profile: ""full"",
                servicePack: 1                
            }";

            int? servicePack = 1;

            var actual = SmallestDotNetLib.JsonVersions.WriteVersion(3, 5, "full", servicePack);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test35ClientServicePackOneJson()
        {
            var expected = @"{
                major: 3,
                minor: 5,
                profile: ""client"",
                servicePack: 1                
            }";

            int? servicePack = 1;

            var actual = SmallestDotNetLib.JsonVersions.WriteVersion(3, 5, "client", servicePack);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test40Json()
        {
            var expected = @"{
                major: 4,
                minor: 0,
                profile: ""full"",
                servicePack: null                
            }";

            int? servicePack = null;

            var actual = SmallestDotNetLib.JsonVersions.WriteVersion(4, 0, "full", servicePack);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test40ClientProfileJson()
        {
            var expected = @"{
                major: 4,
                minor: 0,
                profile: ""client"",
                servicePack: null                
            }";

            int? servicePack = null;

            var actual = SmallestDotNetLib.JsonVersions.WriteVersion(4, 0, "client", servicePack);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test45Json()
        {
            var expected = @"{
                major: 1,
                minor: 0,
                profile: ""full"",
                servicePack: null                
            }";

            int? servicePack = null;

            var actual = SmallestDotNetLib.JsonVersions.WriteVersion(1, 0, "full", servicePack);

            Assert.AreEqual(expected, actual);
        }
    }
}
