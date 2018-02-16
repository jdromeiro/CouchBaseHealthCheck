using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Nimator;

namespace CouchBaseHealthCheck.Tests
{
    [TestClass]
    public class MemoryCheckTests
    {
        public const decimal BadMinPercAvailableMem = -10;
        public const decimal GoodMinPercAvailableMem = 15;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBadMinPercMemAvailable_ThrowsArgumentException()
        {
            CouchBaseServerInfo serverInfo = new CouchBaseServerInfo(TestConst.GoodServer, TestConst.GoodUserName, TestConst.GoodPassword);
            new MemoryCheck(serverInfo, BadMinPercAvailableMem);
        }

        [TestMethod]
        public void TestGoodMinPercMemAvailable()
        {
            CouchBaseServerInfo serverInfo = new CouchBaseServerInfo(TestConst.GoodServer, TestConst.GoodUserName, TestConst.GoodPassword);
            new MemoryCheck(serverInfo, GoodMinPercAvailableMem);
        }

        [TestMethod]
        public void TestSufficientMemoryAvailable()
        {
            CouchBaseServerInfo serverInfo = new CouchBaseServerInfo(TestConst.GoodServer, TestConst.GoodUserName, TestConst.GoodPassword);
            MemoryCheck memCheck = new MemoryCheck(serverInfo, GoodMinPercAvailableMem);
            var memAvailable = GoodMinPercAvailableMem;
            Assert.AreEqual(memCheck.CheckMemoryAvailable(memAvailable), NotificationLevel.Okay);
        }

        [TestMethod]
        public void TestInsufficientMemoryAvailable()
        {
            CouchBaseServerInfo serverInfo = new CouchBaseServerInfo(TestConst.GoodServer, TestConst.GoodUserName, TestConst.GoodPassword);
            MemoryCheck memCheck = new MemoryCheck(serverInfo, GoodMinPercAvailableMem);
            var memAvailable = GoodMinPercAvailableMem - 1;
            Assert.AreEqual(memCheck.CheckMemoryAvailable(memAvailable), NotificationLevel.Error);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestBadComputeCouchBaseStats_ThrowsArgumentNullException()
        {
            CouchBaseServerInfo serverInfo = new CouchBaseServerInfo(TestConst.GoodServer, TestConst.GoodUserName, TestConst.GoodPassword);
            MemoryCheck memCheck = new MemoryCheck(serverInfo, GoodMinPercAvailableMem);
            memCheck.ComputeCouchBaseStats(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestBadComputeMemoryAvailable_ThrowsArgumentNullException()
        {
            CouchBaseServerInfo serverInfo = new CouchBaseServerInfo(TestConst.GoodServer, TestConst.GoodUserName, TestConst.GoodPassword);
            MemoryCheck memCheck = new MemoryCheck(serverInfo, GoodMinPercAvailableMem);
            memCheck.ComputeMemoryAvailable(null);
        }
    }
}
