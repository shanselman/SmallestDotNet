namespace CheckForDotNet45
{
    using System;
    using System.Diagnostics;

    class Program
    {
        const string site = "http://smallestdotnet.com/?realversion={0}";

        static void Main(string[] args)
        {
            Console.Write("Checking .NET version...");
            var versionString = Environment.Version.ToString();
            if (IsDotNet45OrNewer())
                versionString = "4.5";
             Process.Start(String.Format(site, versionString));
        }

        public static bool IsDotNet45OrNewer()
        {
            // Class "ReflectionContext" exists in .NET 4.5 (and later).
            return Type.GetType("System.Reflection.ReflectionContext", false) != null;
        }
    }
}
