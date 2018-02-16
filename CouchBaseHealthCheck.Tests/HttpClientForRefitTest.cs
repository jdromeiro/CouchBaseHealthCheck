using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CouchBaseHealthCheck.Tests
{
    [TestClass]
    public class HttpClientForRefitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullServerName_ThrowsNullArgumentException()
        {
            new HttpClientForRefit(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBadServerName_ThrowsArgumentException()
        {
            CouchBaseServerInfo serverInfo = new CouchBaseServerInfo(TestConst.BadServer, TestConst.GoodUserName, TestConst.GoodPassword);
            new HttpClientForRefit(serverInfo);
        }
    }
}
