using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestDotNetLib
{
    public class Browser
    {
        public string BrowserString { get; set; }
        public string BrowserPretty { get; set; }
        public bool CanGetCLRVersion { get; set; }
    }

    public class BrowserSupport
    {
        private static Browser Chrome = new Browser { BrowserPretty = "Google Chrome", BrowserString = "Chrome", CanGetCLRVersion = false };
        private static Browser Firefox = new Browser { BrowserPretty = "Mozilla Firefox", BrowserString = "Firefox", CanGetCLRVersion = false };
        private static Browser InternetExplorer = new Browser { BrowserPretty = "Internet Explorer", BrowserString = "Trident", CanGetCLRVersion = true };
        public static List<Browser> Browsers = new List<Browser>
	    {
	        Chrome,
	        Firefox,
	        InternetExplorer
	    };

        public static Browser GetBrowser(string UserAgent)
        {
            return Browsers.FirstOrDefault(b => UserAgent.Contains(b.BrowserString));
        }
    }
}
