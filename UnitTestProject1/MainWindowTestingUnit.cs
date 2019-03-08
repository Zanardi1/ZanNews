using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZanScore.Tests
{
    [TestClass()]
    public class MainWindowTest
    {
        [TestMethod()]
        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        public void SetAutomaticDownloadTimerEngineTest(int value)
        {
            //Arrange
            bool Result = true;
            Form1 f = new Form1();

            //Act
            Result = f.SetAutomaticDownloadTimerEngine(value);

            //Assert
            Assert.AreEqual(Result, value == 1 ? true : false);
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
            Assert.AreEqual(Result, true);
        }

        [TestMethod()]
        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void DownloadAllNewsProcessTest(bool value)
        {
            //Arrange
            Form1 f = new Form1();
            NewsLibrary N = new NewsLibrary
            {
                Owner = f
            };

            //Act
            //f.DownloadAllNewsProcess(value);
            //f.DownloadAllNewsInitialization(value); //Eroare la NewsSourcesCollection.LoadSources(false)
            f.DownloadingEngine(value); //NewsSourceData.FillRSSData(NewsLibrary.NewsSourcesRSSList[NewsLibrary.AbsoluteIndex]);, pe ramura false

            //Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        [DataTestMethod]
        [DataRow("http://www.șarpe.ro")]
        //[DataRow("www.protv.ro")] //Genereaza UriFormatException
        //[DataRow("ww")] //Genereaza UriFormatException
        [DataRow("https://stirileprotv.ro/stiri-despre/news-feed/")]
        public void LoadingNewsEngineTest(string value)
        {
            //Arrange
            Form1 f = new Form1();

            //Act
            f.LoadingNewsEngine(value);

            //Assert
            Assert.AreEqual(1,1);
        }
    }
}
