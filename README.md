SmallestDotNet
==============

SmallestDotNet - SmallestDotNet.com is a single page site that does one thing. It tells you the smallest, easiest download you would need to get the .NET Framework on your system. 

The code sucks. I did it an hour and I'm sad.

Thanks to Calin Balauru for his help. Anything good here is him. All the bad is me.

Requirements
------------
You should be able to open this code using Visual Studio 2010 or Visual Studio 2012

The code should run under .NET 4 or .NET 4.5

How does it work?
-----------------
To determine if you are running .NET 4.5, the console application "CheckForDotNet45" checks for the existence of 
the type "System.Reflection.ReflectionContext", if it finds it, it passes a query string "realversion=4.5" to the website.

Otherwise, it passes the value returned by System.Environment.Version in the querystring.

Dependencies
------------
- Twitter Bootstrap
- Font Awesome

Development notes
-----------------
During development, you might want to change "site" variable in Program.cs to http://localhost:57099/, otherwise it will go to the actual deployed website, and not the version of the app you have on your development box