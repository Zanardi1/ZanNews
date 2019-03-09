using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZanScore.Tests
{
    [TestClass()]
    public class NewsLibraryTests
    {
        [TestMethod()]
        public void ReadFromLibraryTest()
        {
            //Arrange
            NewsLibrary N = new NewsLibrary();
            bool Result;

            //Act
            NewsLibrary.NewsSourcesList.Clear();
            N.NewsCategoriesList.Clear();
            NewsLibrary.NewsSourcesRSSList.Clear();
            Result = N.ReadFromLibrary();

            //Assert
            Assert.AreEqual(Result, true);
        }
    }
}