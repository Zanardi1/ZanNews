using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZanScore.Tests
{
    [TestClass()]
    public class RSSSourceDataTests
    {
        [TestMethod()]
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