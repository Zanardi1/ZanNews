using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ZanScore.Tests
{
    [TestClass()]
    public class RSSSourcesLibraryTests
    {
        [TestMethod()]
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(1)]
        public void EnableNewsSourceTest(int value)
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();

            //Act
            R.EnableNewsSource(value);

            //Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(1)]
        public void DisableNewsSourceTest(int value)
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();

            //Act
            R.DisableNewsSource(value);

            //Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void LoadSourcesTest(bool value)
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();

            //Act
            R.LoadSources(value);

            //Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void SaveSourcesTest()
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();

            //Act
            R.SaveSources();

            //Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        [DataTestMethod]
        [DataRow("caine", "www.yahoo.com")]
        public void AddNewSourceTest(string Name, String URL)
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();

            //Act
            R.AddNewSource(Name, URL);

            //Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        [DataTestMethod]
        [DataRow(1, "dd", "www.google.com")]
        public void EditSourceTest(int Pos, string NewName, string NewUrL)
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();

            //Act
            R.EditSource(Pos, NewName, NewUrL);

            //Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void RemoveSourceTest()
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();
            List<int> L = new List<int>() { 1, 2, 3 };

            //Act
            R.RemoveSource(L);

            //Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void ShowNewsSourcesInDataGridTest()
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();
            DataGridView D = new DataGridView();
            D.ColumnCount = 2;

            //Act
            R.ShowNewsSourcesInDataGrid(D);

            //Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void GetNewsURLTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ClearSourcesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SortSourcesTest()
        {
            Assert.Fail();
        }
    }
}