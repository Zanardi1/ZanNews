using ZanScore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZanScore.Tests
{
    [TestClass()]
    public class ZanNewsTestUnit
    {
        [TestMethod()]
        public void SetTimerEngineTest()
        {
            Form1 f = new Form1();
            f.OH.NewsDownloadAtInterval = 0;
            f.SetTimerEngine();
            Assert.AreEqual(f.DownloadNewsTimer.Enabled, false);
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
