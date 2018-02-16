using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Nimator;

namespace CouchBaseHealthCheck.Tests
{
    [TestClass]
    public class NumberOfDocsCheckTest
    {
        public const int BadNumberOfDocs = -10;
        public const int GoodMaxdNumberOfDocs = 15;

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBadNumberOfDocs_ThrowsArgumentException()
        {
            CouchBaseServerInfo serverInfo = new CouchBaseServerInfo(TestConst.GoodServer, TestConst.GoodUserName, TestConst.GoodPassword);
            new NumberOfDocsCheck(serverInfo, TestConst.GoodBucket, BadNumberOfDocs);
        }

        [TestMethod]
        public void TestGoodMaxNumberOfDocs()
        {
            CouchBaseServerInfo serverInfo = new CouchBaseServerInfo(TestConst.GoodServer, TestConst.GoodUserName, TestConst.GoodPassword);
            new NumberOfDocsCheck(serverInfo, TestConst.GoodBucket, GoodMaxdNumberOfDocs);
        }

        [TestMethod]
        public void TestAcceptableNumberOfDocs()
        {
            CouchBaseServerInfo serverInfo = new CouchBaseServerInfo(TestConst.GoodServer, TestConst.GoodUserName, TestConst.GoodPassword);
            NumberOfDocsCheck docsCheck = new NumberOfDocsCheck(serverInfo, TestConst.GoodBucket, GoodMaxdNumberOfDocs);
            var docsExisting = GoodMaxdNumberOfDocs;
            Assert.AreEqual(docsCheck.CheckNumberOfDocs(docsExisting), NotificationLevel.Okay);
        }

        [TestMethod]
        public void TestUnnaceptableNumberNumberOfDocs()
        {
            CouchBaseServerInfo serverInfo = new CouchBaseServerInfo(TestConst.GoodServer, TestConst.GoodUserName, TestConst.GoodPassword);
            NumberOfDocsCheck docsCheck = new NumberOfDocsCheck(serverInfo, TestConst.GoodBucket, GoodMaxdNumberOfDocs);
            var docsExisting = GoodMaxdNumberOfDocs + 1;
            Assert.AreEqual(docsCheck.CheckNumberOfDocs(docsExisting), NotificationLevel.Error);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestBadComputeCouchBaseBucketStats_ThrowsArgumentNullException()
        {
            CouchBaseServerInfo serverInfo = new CouchBaseServerInfo(TestConst.GoodServer, TestConst.GoodUserName, TestConst.GoodPassword);
            NumberOfDocsCheck docsCheck = new NumberOfDocsCheck(serverInfo, TestConst.GoodBucket, GoodMaxdNumberOfDocs);
            docsCheck.ComputeCouchBaseBucketStats(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestBadComputeNumberOfDocs_ThrowsArgumentNullException()
        {
            CouchBaseServerInfo serverInfo = new CouchBaseServerInfo(TestConst.GoodServer, TestConst.GoodUserName, TestConst.GoodPassword);
            NumberOfDocsCheck docsCheck = new NumberOfDocsCheck(serverInfo, TestConst.GoodBucket, GoodMaxdNumberOfDocs);
            docsCheck.ComputeNumberOfDocs(null);
        }
    }
}
