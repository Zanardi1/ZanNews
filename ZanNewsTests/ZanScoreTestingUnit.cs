using NUnit.Framework;
using ZanScore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZanScore.Tests
{
    [TestFixture()]
    public class Form1Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test()]
        public void SetAutomaticDownloadTimerEngineTest()
        {
            //Arrange
            int flag = 1;
            bool Result = true;
            Form1 f = new Form1();

            //Act
            for (flag = -5; flag <= 10; flag++)
                Result = f.SetAutomaticDownloadTimerEngine(flag);

            //Assert
            if (flag == 1)
                Assert.AreEqual(Result, true);
            else
                Assert.AreEqual(Result, false);
        }

        [Test()]
        public void CheckForNetworkTest()
        {
            //Arrange
            bool Result = true;
            Form1 f = new Form1();

            //Act
            Result = f.CheckForNetwork();

            //Assert
            Assert.AreEqual(Result, true);
        }

        [Test()]
        public void Form1Test()
        {
            Assert.Fail();
        }

        [Test()]
        public void DownloadAllNewsProcessTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void LoadingNewsEngineTest()
        {
            Assert.Fail();
        }
    }
}