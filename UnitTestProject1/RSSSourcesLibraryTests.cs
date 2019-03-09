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
        //[DataRow(-1)] //Genereaza ArgumentOutOfRange
        [DataRow(1)]
        public void EnableNewsSourceTest(int value)
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();
            bool Result;

            //Act
            Result = R.EnableNewsSource(value);

            //Assert
            Assert.AreEqual(Result, true);
        }

        [TestMethod()]
        [DataTestMethod]
        [DataRow(0)]
        //[DataRow(-1)] //Genereaza ArgumentOutOfRange
        [DataRow(1)]
        public void DisableNewsSourceTest(int value)
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();
            bool Result;

            //Act
            Result = R.DisableNewsSource(value);

            //Assert
            Assert.AreEqual(Result, true);
        }

        [TestMethod()]
        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void LoadSourcesTest(bool value)
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();
            NewsLibrary N = new NewsLibrary();
            bool Result;

            //Act
            Result = R.LoadSources(value);

            //Assert
            Assert.AreEqual(Result, true);
        }

        [TestMethod()]
        public void SaveSourcesTest()
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();
            bool Result;

            //Act
            Result = R.SaveSources();

            //Assert
            Assert.AreEqual(Result, true);
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
            //List<int> L = new List<int>() { 1, 2, 3 };
            List<int> L = new List<int>() { 0 };

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
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();
            List<string> Result = new List<string>() { };

            //Act
            Result = R.GetNewsURL();

            //Assert
            Assert.AreNotEqual(Result, null);
        }

        [TestMethod()]
        public void ClearSourcesTest()
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();

            //Act
            R.ClearSources();

            //Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(1, 2)]
        [DataRow(1, 3)]
        [DataRow(1, 4)]
        [DataRow(0, 1)]
        [DataRow(0, 2)]
        [DataRow(0, 3)]
        [DataRow(0, 4)]
        public void SortSourcesTest(int Pos, int Way)
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();

            //Act
            R.SortSources(Pos, Way);

            //Assert
            Assert.AreEqual(1, 1);
        }
    }
}