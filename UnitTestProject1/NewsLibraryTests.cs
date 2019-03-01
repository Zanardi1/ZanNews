using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;

namespace ZanScore.Tests
{
    [TestClass()]
    public class NewsLibraryTests
    {
        [TestMethod()]
        public void NewsLibraryTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ReadFromLibraryTest()
        {
            //Arrange
            NewsLibrary N = new NewsLibrary();

            //Act
            NewsLibrary.NewsSourcesList.Clear();
            N.NewsCategoriesList.Clear();
            NewsLibrary.NewsSourcesRSSList.Clear();
            N.ReadFromLibrary();

            //Assert
            Assert.Fail();
        }
    }
}