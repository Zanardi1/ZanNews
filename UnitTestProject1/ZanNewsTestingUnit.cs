using ZanScore;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZanScore.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void SetAutomaticDownloadTimerEngineTest()
        {
            int flag = 0;
            bool Result = true;
            Form1 f = new Form1();

            Result=f.SetAutomaticDownloadTimerEngine(flag);

            Assert.AreEqual(Result,false);
        }

        [TestMethod()]
        public void CheckForNetworkTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Form1Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DownloadAllNewsProcessTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadingNewsEngineTest()
        {
            Assert.Fail();
        }
    }
}

namespace UnitTestProject1
{
    [TestClass]
    public class ZanNewsTestingUnit
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
