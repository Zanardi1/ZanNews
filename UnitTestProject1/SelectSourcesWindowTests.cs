using ZanScore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZanScore.Tests
{
    [TestClass()]
    public class SelectSourcesWindowTests
    {
        [TestMethod()]
        public void UpdateSelectedSourcesListEngineTest()
        {
            //Arrange
            SelectSourcesWindow S = new SelectSourcesWindow();

            //Act
            S.UpdateSelectedSourcesListEngine();

            //Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void DisplaySourceNamesEngineTest()
        {
            //Arrange
            SelectSourcesWindow S = new SelectSourcesWindow();

            //Act
            S.DisplaySourceNamesEngine();
            
            //Assert
            Assert.Fail();
        }
    }
}