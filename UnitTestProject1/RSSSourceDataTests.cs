using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZanScore.Tests
{
    [TestClass()]
    public class RSSSourceDataTests
    {
        [TestMethod()]
        [DataTestMethod]
        //[DataRow("http://www.xml.ro")] //Declanseaza System.Net.WebException. Nu o pot prinde avand in vedere cum am scris rutina
        //[DataRow("https://www.afp.com/en/search/site/rss")] //Site cu RSS invalid
        [DataRow("https://www.digi24.ro/rss")]
        public void FillRSSDataTest(string value)
        {
            //Arrange
            RSSSourceData R = new RSSSourceData();
            bool Result = true;

            //Act
            Result = R.FillRSSData(value);

            //Assert
            Assert.AreEqual(Result,true);
        }
    }
}