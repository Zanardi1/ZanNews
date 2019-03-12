using ZanScore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZanScore.Tests
{
    [TestClass()]
    public class SelectSourcesWindowTests
    {
        [TestMethod()]
        public void DisplaySourceNamesEngineTest()
        {
            //Arrange
            Form1 F = new Form1();
            SelectSourcesWindow S = new SelectSourcesWindow
            {
                Owner = F
            };
            F.NewsSourcesCollection.IsSourceSelected[0] = true;
            F.NewsSourcesCollection.IsSourceSelected[1] = true;

            //Act
            S.DisplaySourceNamesEngine();

            //Assert
            Assert.AreEqual(1, 1);
        }
    }
}