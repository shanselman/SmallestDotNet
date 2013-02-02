﻿namespace CheckForDotNet45
{
    using System;
    using System.Diagnostics;

    class Program
    {
        const string site = "http://smallestdotnet.com/?realversion={0}";

        static void Main(string[] args)
        {
            Console.Write("Checking .NET version...");
            if (IsNet45OrNewer())
                Process.Start(String.Format(site, "4.5"));
            else
                Process.Start(String.Format(site, Environment.Version.ToString()));
        }

        public static bool IsNet45OrNewer()
        {
            // Class "ReflectionContext" exists in .NET 4.5 .
            return Type.GetType("System.Reflection.ReflectionContext", false) != null;
        }
    }
}
