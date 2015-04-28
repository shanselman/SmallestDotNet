using Microsoft.Win32;

namespace CheckForDotNet45
{
    using System;
    using System.Diagnostics;

    class Program
    {
        private const string Site = "http://smallestdotnet.com/?realversion={0}";
        private const string ReleaseKeyParameter = "&releaseKey={1}";

        static void Main(string[] args)
        {
            Console.Write("Checking .NET version...");

            int releaseKey = 0;
            bool exact = true;
            string version = IsNet45OrNewer() 
                ? Get45or451FromRegistry(out exact, out releaseKey) 
                : Environment.Version.ToString();
            try
            {
                string url = exact
                    ? string.Format(Site, version)
                    : string.Format(Site + ReleaseKeyParameter, version, releaseKey);
                Process.Start(url);
            }
            catch (Exception)
            {
                Console.WriteLine("\nApplication was unable to launch browser");
                Console.WriteLine("Your current .NET version is: " + version);
                Console.ReadLine(); //Pause
            }
        }

        public static bool IsNet45OrNewer()
        {
            // Class "ReflectionContext" exists in .NET 4.5 .
            return Type.GetType("System.Reflection.ReflectionContext", false) != null;
        }

        //Improved but based on http://msdn.microsoft.com/en-us/library/hh925568%28v=vs.110%29.aspx#net_d
        private static string Get45or451FromRegistry(out bool exact, out int releaseKey)
        {
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
               RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"))
            {
                exact = true;
                releaseKey = (int)ndpKey.GetValue("Release");
                {
                    if (releaseKey == 378389)
                        return "4.5";

                    if (releaseKey == 378758 || releaseKey == 378675)
                        return "4.5.1";

                    if (releaseKey == 379893)
                        return "4.5.2";

                    if (releaseKey == 381029)
                        return "4.6 Preview";

                    if (releaseKey > 381029)
                    {
                        exact = false;
                    }
                }
            }

            exact = false;
            return "4.5 or greater";
        }
    }
}
