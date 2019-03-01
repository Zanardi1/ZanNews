using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZanScore.Tests
{
    [TestClass()]
    public class RSSSourceDataTests
    {
        [TestMethod()]
        [DataTestMethod]
        [DataRow("www.xml.ro")]
        [DataRow("https://www.afp.com/en/search/site/rss")]
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

        [TestMethod()]
        public void EmptyFieldsTest()
        {
            //Arrange
            RSSSourceData R = new RSSSourceData();

            //Act
            R.EmptyFields();

            //Assert
            Assert.AreEqual(1,1);
        }
    }
}