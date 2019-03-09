using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZanScore.Tests
{
    [TestClass()]
    public class OptionsHandlingTests
    {
        [TestMethod()]
        public void OpenOptionsFileTest()
        {
            //Arrange
            OptionsHandling O = new OptionsHandling();
            bool Result;

            //Act
            Result = O.OpenOptionsFile();

            //Assert
            Assert.AreEqual(Result, true);
        }

        [TestMethod()]
        public void SaveOptionsToFileTest()
        {
            //Arrange
            OptionsHandling O = new OptionsHandling();
            bool Result;

            //Act
            Result = O.SaveOptionsToFile();

            //Assert
            Assert.AreEqual(Result, true);
        }
    }
}