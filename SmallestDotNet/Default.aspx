<%@ Page Language="C#" AutoEventWireup="true" Inherits="_Default" CodeBehind="Default.aspx.cs" %>

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
    <link rel="stylesheet" href="css/bootstrap.min.css" type="text/css" />
    <link rel="stylesheet" href="css/bootstrap-responsive.min.css" type="text/css" />
    <link rel="Stylesheet" href="css/main.css" type="text/css" />
    <title>Get the .NET Framework Fast - Download the smallest .NET Framework Distribution possible</title>
</head>

<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="navbar-inner">
            <div class="container">
                <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </a>
                <a class="brand" href="#">Smallestdotnet</a>
                <div class="nav-collapse ">
                    <ul class="nav">
                        <li><a href="http://www.hanselman.com">Scott's Blog</a></li>
                        <li><a href="https://github.com/shanselman/SmallestDotNet/">This site on GitHub</a></li>
                        <li><a href="https://github.com/shanselman/SmallestDotNet/imags">Report a Bug</a></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </div>
    </div>

    <div class="container">

        <!-- Main hero unit for a primary marketing message or call to action -->
        <div class="hero-unit">
            <h1>You're up to date! (or...)</h1>
            <p id="javascriptResult">
                <asp:Literal runat="server" Visible="true" ID="userResult" />
            </p>
            <p><a runat="server" id="getdotnet" class="btn btn-primary btn-large" href="#">Get .NET now! &raquo;</a></p>
        </div>

        <!-- Example row of columns -->
        <div class="row-fluid">
            <div class="span4">
                <h2>What just happened?</h2>
                <p>This site looked at your browser's "UserAgent" and figured out what version (if any) of the .NET Framework you have (or don't have) installed, then calculated the total size if you chose to download the .NET Framework.</p>
                <%--          <p><a class="btn" href="#">View details &raquo;</a></p>--%>
            </div>
            <div class="span4">
                <h2>Offline Download</h2>
                <p><asp:Literal runat="server" ID="developerOfflineResult" /></p>
                <%--          <p><a class="btn" href="#">View details &raquo;</a></p>--%>
            </div>
            <div class="span4">
                <h2>Online Download</h2>
                <p><asp:Literal runat="server" ID="developerOnline" /></p>
                <%--          <p><a class="btn" href="#">View details &raquo;</a></p>--%>
            </div>
            </div>
                <div class="row-fluid">

            <div class="span8">
                <h2>Are you a .NET Programmer?</h2>
                <p>If you're a programmer/developer, you might be trying to figure out which .NET Framework for your users to use.</p>
                <p>Sometimes finding the right .NET Framework is confusing because different kinds of machines (x86, x64, ia64) that may or may not have different versions of .NET already on them.</p>
                <p>If you look for .NET Downloads on Microsoft's site, it might look like the .NET Framework is 200+ megs. It's not. Those big downloads are the Complete Offline Versions of every version of the .NET Framework for every kind of machine possible. The big .NET download includes x86, x64, and ia64. It includes .NET 2.0, 3.0, and 3.5 code for all systems all in one super-archive.</p>
                <p>Why would you EVER want to download the whole archive? Only if you're a developer and you want to distribute the .NET Framework the widest possible audience in a format like a CD or DVD.</p>
                <%--<p><a class="btn" href="#">View details &raquo;</a></p>--%>
            </div>
            <div class="span4">
                <h2>Your User Agent</h2>
                <p>
                    For technical or debugging purposes, this is exactly what your browser said about itself:<br />
                    <asp:Literal runat="server" ID="userAgent" />
                </p>
                <%--          <p><a class="btn" href="#">View details &raquo;</a></p>--%>
            </div>
        </div>

        <div class="span12">
            <hr />
            <footer>
            <p>&copy; Scott Hanselman and Friends 2012</p>
        </footer>
        </div>
    </div>
    <!-- /container -->

    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(function() { 
            var userAgent = navigator.userAgent;
            if (userAgent.indexOf('Trident/5.0') !== -1 || userAgent.indexOf('Trident/6.0') !== -1) {
                $.get('/VersionCheck.ashx',
                        { 'userAgent': userAgent },
                        function (data) {
                            $('#javascriptResult').html(data);
                        }
                );
            }
        })
    </script>

    <noscript>
        <a href='http://www.omniture.com' title='Web Analytics'>
            <img src='http://mssto.112.2o7.net/b/ss/msstoextblogsnojs/1/H.20.2--NS/0' height='1' width='1' border='0' alt='' /></a>
    </noscript>
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
