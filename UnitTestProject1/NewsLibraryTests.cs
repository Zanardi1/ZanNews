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
            //Arrange
            NewsLibrary N = new NewsLibrary();

            //Act

            //Assert
            Assert.AreEqual(1,1);
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
            Assert.AreEqual(1, 1);
        }
    }
}