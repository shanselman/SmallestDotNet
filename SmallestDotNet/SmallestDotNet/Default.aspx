<%@ Page Language="C#" AutoEventWireup="true" Inherits="_Default" Codebehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
    <meta name="Description" content="Get the right .NET Framework download for you, as fast as possible by downloading as little as possible." />
    <meta name="Keywords" content=".NET Framework Gast" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="Distribution" content="Global" />
    <meta name="t_omni_extblogid" content="msstoextblogs1" />
    <meta name="t_omni_blogname" content="Scott Hanselman" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <link rel="stylesheet" href="images/BrightSide.css" type="text/css" />
    <title>Get the .NET Framework Fast - Download the smallest .NET Framework Distribution possible</title>
</head>

<body>
    <!-- wrap starts here -->
    <form runat="server">
        <div id="wrap">

            <div id="header">

                <h1 id="logo">Smallest<span class="green">dot</span>NET<span class="gray"></span></h1>
                <h2 id="slogan">Get the smallest .NET Framework download possible.</h2>
            </div>

            <!-- content-wrap starts here -->
            <div id="content-wrap">

                <img src="images/headerphoto.jpg" width="820" height="120" alt="headerphoto" class="no-border" />

                <div id="sidebar">
                    <h1>Javascript</h1>
                    <p>Want SmallestDotNet functionality for your own site? Add this chunk of Javascript, it'll spit out HTML and you can style to taste.</p>
                    <textarea id="sidebartext">&LT;script type="text/javascript" src="http://www.smallestdotnet.com/javascript.ashx"&GT;&LT;/script&GT;</textarea>

                    <p>Prefer a Javascript Object (JSON) to detect .NET Framework installatons? Try this instead:</p>
                    <textarea id="sidebartext">&LT;script type="text/javascript" src="http://www.smallestdotnet.com/javascriptdom.ashx"&GT;&LT;/script&GT;</textarea>
                    <p>Get examples on <a href="http://www.hanselman.com/blog/SmallestDotNetUpdateNowWithNet4SupportandanincludableJavascriptapi.aspx">how to use the JSON object on Scott's Blog.</a></p>


                    <h1>Useful Sites</h1>
                    <ul class="sidemenu">
                        <li><a href="http://www.hanselman.com">Scott's Blog</a></li>
                        <li><a href="http://www.asp.net">ASP.NET</a></li>
                        <li><a href="http://www.silverlight.net">Silverlight.NET</a></li>
                        <li><a href="http://www.windowsclient.net">WindowsClient.NET</a></li>
                    </ul>


                    <h1>Wise Words</h1>
                    <p>&quot;Your most unhappy customers are your greatest source of learning.&quot;</p>

                    <p class="align-right">- Bill Gates</p>



                </div>

                <div id="main">
                    <a runat="server" id="getdotnet"><img src="images/badge.png" alt="" class="no-border" id="badge" /></a>
                    <h1>The .NET Download for you is:</h1>
                    <a name="TemplateInfo"></a>
                    <div id="user">
                        <h2>YOUR PERSONALIZED RESULTS</h2>
                        <p>
                            <asp:Literal runat="server" Visible="true" ID="userResult" /></p>
                    </div>
                    <h2>What just happened?</h2>
                    <p>This site looked at your browser's "UserAgent" and figured out what version (if any) of the .NET Framework you have (or don't have) installed, then calculated the total size if you chose to download the .NET Framework.</p>
                    <h2>Are you a .NET Programmer?</h2>
                    <p>If you're a programmer/developer, you might be trying to figure out which .NET Framework for your users to use. </p>
                    <p>Sometimes finding the right .NET Framework is confusing because different kinds of machines (x86, x64, ia64) that may or may not have different versions of .NET already on them.</p>
                    <p>
                        If you look for .NET Downloads on Microsoft's site, it might look like the .NET Framework is 200+ megs. <strong>It's not</strong>. Those big downloads are the Complete Offline Versions of every version of the .NET 
			Framework for every kind of machine possible. The big .NET download includes x86, x64, and ia64. It includes .NET 2.0, 3.0, and 3.5 code for all systems all in one super-archive.
                    </p>
                    <p>Why would you EVER want to download the whole archive? Only if you're a developer and you want to distribute the .NET Framework the widest possible audience in a format like a CD or DVD.</p>
                    <h3>Online Download</h3>
                    <p>
                        <asp:Literal runat="server" ID="developerOnline" /></p>
                    <h3>Offline Download to Install Later</h3>
                    <p>
                        <asp:Literal runat="server" ID="developerOfflineResult" /></p>

                    <p>For technical or debugging purposes, this is exactly what your browser said about itself:<br />
                        <asp:Literal runat="server" ID="userAgent" /></p>
                    <p>Thanks! If this was helpful to you, please visit <a href="http://www.hanselman.com">my blog</a>.</p>
                </div>

                <div id="rightbar">

                    <h1>What's <span class="green">This?</span></h1>

                    <p>
                        <strong>SmallestDotNet.com</strong> is a single page site that does one thing. It tells you the smallest, easiest download you'd need to get the .NET Framework on your system. <strong><span id="smaller">The size of the .NET download is usually WAY smaller than you think it'll be.</span></strong>
                        There's no database, no cookies, and nothing about your computer has been stored or kept. We just look at the information your browser already reports about your computer and make a suggestion as to the best .NET Framework download for you.
                    </p>

                    <h1>Support</h1>
                    <p>There's no support for this website. It's just a single page meant to save you some time and confusion. I hope it helps you. If not, I'm sorry. When all else fails, you usually can't go wrong by a visit to <a href="http://www.windowsupdate.com">WindowsUpdate.com</a>.</p>
                    <p>However, if the site breaks or tells you something that's not right, <a href="http://2idi.com/contact/=scott.hanselman">do let me know.</a></p>
                </div>

                <!-- content-wrap ends here -->
            </div>

            <!-- footer starts here -->
            <div id="footer">

                <div class="footer-left">
                    <p class="align-left">
                        &copy; 2012 <strong><a href="http://www.hanselman.com/">Scott Hanselman</a></strong> |
		Design by <a href="http://www.styleshout.com/">styleshout</a> and Erwin Aligam | This site is not affliated with or endorsed by Microsoft |
		Valid <a href="http://validator.w3.org/check/referer">XHTML</a> |
		<a href="http://jigsaw.w3.org/css-validator/check/referer">CSS</a>
                    </p>
                </div>

                <div class="footer-right">
                    <p class="align-right">
                        <a href="index.html">Home</a>&nbsp;|&nbsp;
  		<a href="index.html">SiteMap</a>&nbsp;|&nbsp;
   	<a href="index.html">RSS Feed</a>
                    </p>
                </div>

            </div>
            <!-- footer ends here -->

            <!-- wrap ends here -->
        </div>
    </form>

    <script type="text/javascript" src="/blog/scripts/omni_external_blogs_v2.js"></script>
    <noscript><a href='http://www.omniture.com' title='Web Analytics'>
        <img src='http://mssto.112.2o7.net/b/ss/msstoextblogsnojs/1/H.20.2--NS/0' height='1' width='1' border='0' alt='' /></a></noscript>
    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <script type="text/javascript">
        var pageTracker = _gat._getTracker("UA-130207-3");
        pageTracker._trackPageview();
    </script>
</body>
</html>
