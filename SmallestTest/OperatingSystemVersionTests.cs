namespace SmallestTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SmallestDotNetLib;

    [TestClass]
    public class OperatingSystemVersionTests
    {
	[TestMethod]
	public void CheckNoMatch()
	{
	    var UserAgent = "Apeture";

	    var actualOS = OperatingSystems.GetOperatingSystem(UserAgent);

	    Assert.IsNull(actualOS);

	}


	[TestMethod]
	public void CheckWindows8()
	{
	    var UserAgent = "Windows NT 6.2";
	    var Windows8OperatingSystem = OperatingSystems.Windows8;

	    var actualOS = OperatingSystems.GetOperatingSystem(UserAgent);

	    Assert.AreEqual(Windows8OperatingSystem, actualOS);
	}

	[TestMethod]
	public void CheckWindows7()
	{
	    var UserAgent = "Windows NT 6.1";
	    var Windows7OperatingSystem = OperatingSystems.Windows7;

	    var actualOS = OperatingSystems.GetOperatingSystem(UserAgent);

	    Assert.AreEqual(Windows7OperatingSystem, actualOS);
	}

	[TestMethod]
	public void CheckWindowsVista()
	{
	    var UserAgent = "Windows NT 6.0";
	    var WinodwsVistaOperatingSytem = OperatingSystems.WindowsVista;

	    var actualOS = OperatingSystems.GetOperatingSystem(UserAgent);

	    Assert.AreEqual(WinodwsVistaOperatingSytem, actualOS);
	}

	[TestMethod]
	public void CheckoutWindowsServer2003()
	{
	    var UserAgent = "Windows NT 5.2";
	    var WindowsServer2003OperatingSystem = OperatingSystems.WindowsXP64ORServer2003;

	    var actualOS = OperatingSystems.GetOperatingSystem(UserAgent);

	    Assert.AreEqual(WindowsServer2003OperatingSystem, actualOS);
	}


    }
}
