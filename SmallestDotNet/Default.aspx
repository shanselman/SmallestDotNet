<%@ Page Language="C#" AutoEventWireup="true" Inherits="_Default" CodeBehind="Default.aspx.cs" %>
<!DOCTYPE html>
<html>
<head>
    <meta name="Description" content="Get the right .NET Framework download for you, as fast as possible by downloading as little as possible." />
    <meta name="Keywords" content=".NET Framework Gast" />
    <meta charset="utf-8" />
    <meta name="Distribution" content="Global" />
    <meta name="t_omni_extblogid" content="msstoextblogs1" />
    <meta name="t_omni_blogname" content="Scott Hanselman" />
    <meta name="viewport" content="width=device-width" /> 
    <link rel="stylesheet" href="css/bootstrap.min.css" type="text/css" />
    <link rel="stylesheet" href="css/bootstrap-responsive.min.css" type="text/css" />
    <link href="css/font-awesome.css" rel="stylesheet" type="text/css" />
    <!--[if IE 7]><link rel="stylesheet" href="/css/font-awesome-ie7.css"><![endif]-->
    <link href="css/m-buttons.min.css" rel="stylesheet" media="screen" />
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
                <a class="brand" href="#">SmallestDotNET</a>
                <div class="nav-collapse pull-right">
                    <ul class="nav">
                        <li><a href="http://www.hanselman.com"><i class="icon-sign-blank"></i> Scott's Blog</a></li>
                        <li><a href="https://github.com/shanselman/SmallestDotNet/"><i class="icon-github-sign"></i> This site on GitHub</a></li>
                        <li><a href="https://github.com/shanselman/SmallestDotNet/issues"><i class="icon-heart"></i> Report a Bug</a></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </div>
    </div>

    <div class="container">

        <div class="row-fluid">
            <div class="span12">
                <div class="result-header">
                    <h1 id="header-statement">Do you have .NET?</h1>
                        <p class="lead" id="javascriptResult">
                        <asp:Literal runat="server" Visible="true" ID="userResult" />
                        </p>
                        <br />
                        <a runat="server" id="getdotnet" class="m-btn big" href="#"><i class="icon-download-alt"></i>  <strong>Get .NET</strong> </a>

                        <a runat="server" visible="false" id="checkdotnet" class="m-btn big" href="https://github.com/downloads/shanselman/SmallestDotNet/CheckForDotNet45.exe"><strong><i class="icon-download-alt"> </i> .NET Checker</strong></a>

                    </div>
            </div>
        </div>

        <div class="row-fluid">
            <div class="span12">
                <h2>What about .NET 4.5?</h2>
                
                Download this application <a href="https://github.com/downloads/shanselman/SmallestDotNet/CheckForDotNet45.exe" class="m-btn blue"><i class="icon-download-alt"> </i> .NET Checker</a> and run it.
                This harmless code signed application will tell us if you have .NET 4.5. Don't trust us? Here's <a href="https://github.com/shanselman/SmallestDotNet/blob/master/CheckForDotNet45/Program.cs">the code</a>.
            </div>
        </div>
        <!-- Example row of columns -->
        <div class="row-fluid">
            <div class="span4">
                <h2><i class="icon-question-sign"></i> What happened</h2>
                This site looked at your browser's "UserAgent" and figured out what version (if any) of the .NET Framework you have (or don't have) installed, then calculated the total size if you chose to download the .NET Framework.
                <br />
                <br />
                There's no database, no cookies, and nothing about your computer has been stored or kept. We just look at the information your browser already reports about your computer and make a suggestion as to the best .NET Framework download for you.
                <br />
                <br />
            </div>
            <div class="span8">
                <h2><i class="icon-download-alt"></i> Offline Download</h2>
                    <asp:Literal runat="server" ID="developerOfflineResult" />
                <h2><i class="icon-download-alt"></i> Online Download</h2>
                    <asp:Literal runat="server" ID="developerOnline" />
            </div>
        </div>
        <div class="row-fluid">
            <div class="span8">
                <h3>Are you a .NET Programmer?</h3>
                 If you're a programmer/developer, you might be trying to figure out which .NET Framework for your users to use.
                <br />
                <br />
                 Sometimes finding the right .NET Framework is confusing because different kinds of machines (x86, x64, ia64) that may or may not have different versions of .NET already on them.
                <br />
                <br />
                 If you look for .NET Downloads on Microsoft's site, it might look like the .NET Framework is 200+ megs. It's not. Those big downloads are the Complete Offline Versions of every version of the .NET Framework for every kind of machine possible. The big .NET download includes x86, x64, and ia64. It includes .NET 2.0, 3.0, and 3.5 code for all systems all in one super-archive. The download for .NET 4.5 is even smaller.
                <br />
                <br />
                 Why would you EVER want to download the whole archive? Only if you're a developer and you want to distribute the .NET Framework the widest possible audience in a format like a CD or DVD.
            </div>
            <div class="span4">
                <h3>Your User Agent</h3>
                For technical or debugging purposes, this is exactly what your browser said about itself:
                <br />
                <pre><asp:Literal runat="server" ID="userAgent" /></pre>
            </div>
        </div>

        <div class="row-fluid">
            <div class="span12">
                <h3>Integration</h3>
                Want SmallestDotNet functionality for your own site? Add this chunk of JavaScript, it'll spit out HTML and you can style to taste.
                <br />
                <pre>&LT;script type="text/javascript" src="http://www.smallestdotnet.com/javascript.ashx"&GT;&LT;/script&GT;</pre>

            </div>
        </div>
        <div class="row-fluid">
            <div class="span12">
                Prefer a JavaScript Object (JSON) to detect .NET Framework installations? Try this instead:
                <br />
                <pre>&LT;script type="text/javascript" src="http://www.smallestdotnet.com/javascriptdom.ashx"&GT;&LT;/script&GT;</pre>
                Get examples on <a href="http://www.hanselman.com/blog/SmallestDotNetUpdateNowWithNet4SupportandanincludableJavascriptapi.aspx">how to use the JSON object on Scott's Blog.</a>


            </div>
        </div>


        <div class="row-fluid">
            <div class="span12 ">
                <footer>
                    <hr />
                    <p>&copy; <a href="http://www.hanselman.com">Scott Hanselman</a>, <a href="http://www.MichaelSarchet.com">Michael Sarchet</a> and Friends 2012. <a href="http://www.github.com/shanselman/smallestdotnet">See the Source and report issues</a>.
                    The lovely <a href="http://ace-subido.github.com/css3-microsoft-metro-buttons/index.html">CSS3 Microsoft-Modern Buttons</a> are by <a href="http://acesubido.com/">Ace Subido</a>.</p>
                </footer>
            </div>
        </div>
    </div>
    <!-- /container -->

    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.result-header').hide();
            if (document.location.search.indexOf('realversion') > -1) {
                $('#header-statement').text('We Found .NET!');
                $('.result-header').fadeIn(1000);
                return;
            }
            $('.result-header').show();
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

    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
        var pageTracker = _gat._getTracker("UA-130207-3");
        pageTracker._trackPageview();
    </script>
</body>
</html>
