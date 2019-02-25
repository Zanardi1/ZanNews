using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZanScore.Tests
{
    [TestClass()]
    public class ZanNewsTestUnit
    {
        [TestMethod()]
        public void SetTimerEngineTest()
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

        [TestMethod()]
        public void CheckForNetworkTest()
        {
            //Arrange
            bool Result = true;
            Form1 f = new Form1();

            //Act
            Result = f.CheckForNetwork();

            //Assert
            Assert.AreEqual(Result,true);
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

        [TestMethod()]
        public void SelectSourcesWindowTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RSSSourcesLibraryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EnableNewsSourceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisableNewsSourceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LoadSourcesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveSourcesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddNewSourceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditSourceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveSourceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ShowNewsSourcesInDataGridTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetNewsURLTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ClearSourcesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SortSourcesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RSSSourceDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OptionsWindowTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OptionsHandlingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OpenOptionsFileTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveOptionsToFileTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReadOptionsFromFileTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NewsLibraryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditSourcesWindowTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddSourceWindowTest()
        {
            Assert.Fail();
        }
    }
}

namespace ZanNewsTest
{
    [TestClass]
    public class ZanNewsTestUnit
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
