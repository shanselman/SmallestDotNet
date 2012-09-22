using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    using System.Collections.Generic;
    using System.Web;
    using SmallestDotNetLib;
    using SmallestDotNetLib.RequestAnalyzer;    

    [TestClass]
    public class RequestAnalzyerAppTests
    {
        [TestMethod]
        public void GetInfoStringReturnsExpectedResultForNet35With4BetaE()
        {
            var browser = new BrowserMock(new Version(4, 0));

            var userAgent = ".NET4.0E";

            var request = new RequestMock(browser, userAgent);

            var requestAnalyzers = new List<IRequestAnalyzer>();

            requestAnalyzers.Add(new Net3RequestAnalyzer(new Net4BetaRequestAnalyzer()));

            var sut = new RequestAnalyzerApp(requestAnalyzers);

            string result = sut.GetUpdateInformation(request);

            string net4Beta = "Seem you're an early adopter! You've got a <strong>full install of .NET 4.0</strong> on your machine. ";
            
            string explain = String.Format(Constants.whyItIsSmallMessage, "only 10");

            net4Beta += string.Format(@"Looks like you {2} have <strong>.NET version 3.0</strong>. 
                That's a very recent version of the .NET Framework, but you can upgrade fairly easily to the 3.5 version by downloading the 2.8 meg installer for {0}. {1}", Constants.htmlLinkToDotNet35Download, explain, true ? "also" : "");

            Assert.AreEqual<string>(net4Beta, result);
        }

        [TestMethod]
        public void GetInfoStringReturnsExpectedResultForNet35With4BetaC()
        {
            var browser = new BrowserMock(new Version(4, 0));

            var userAgent = ".NET4.0C";

            var request = new RequestMock(browser, userAgent);

            var requestAnalyzers = new List<IRequestAnalyzer>();

            requestAnalyzers.Add(new Net3RequestAnalyzer(new Net4BetaRequestAnalyzer()));

            var sut = new RequestAnalyzerApp(requestAnalyzers);

            string result = sut.GetUpdateInformation(request);

            string net4Beta = "Seem you're an early adopter! You've got a <strong>.NET 4.0 Client Profile</strong> on your machine. ";

            string explain = String.Format(Constants.whyItIsSmallMessage, "only 10");

            net4Beta += string.Format(@"Looks like you {2} have <strong>.NET version 3.0</strong>. 
                That's a very recent version of the .NET Framework, but you can upgrade fairly easily to the 3.5 version by downloading the 2.8 meg installer for {0}. {1}", Constants.htmlLinkToDotNet35Download, explain, true ? "also" : "");

            Assert.AreEqual<string>(net4Beta, result);
        }
    }

    class RequestMock : HttpRequestBase
    {
        private readonly string userAgent;

        private readonly HttpBrowserCapabilitiesBase browser;

        public RequestMock(HttpBrowserCapabilitiesBase browser, string userAgent)
        {
            this.browser = browser;

            this.userAgent = userAgent;
        }

        public override string UserAgent
        {
            get
            {
                return this.userAgent;
            }
        }

        public override HttpBrowserCapabilitiesBase Browser
        {
            get
            {
                return this.browser;
            }
        }
    }

    class BrowserMock : HttpBrowserCapabilitiesBase
    {
        private readonly Version version;

        public BrowserMock(Version version)
        {
            this.version = version;
        }

        public override Version ClrVersion
        {
            get
            {
                return this.version;
            }
        }
    }
}
