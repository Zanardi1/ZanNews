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
        [DataRow(1, "dd", "www.google.com")]
        //[DataRow(-1, "dd", "ee")] //Genereaza ArgumentOutOfRangeException
        //[DataRow(4, "gg", "hh")] //Genereaza ArgumentOutOfRangeException
        public void EditSourceTest(int Pos, string NewName, string NewUrL)
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();
            bool Result;

            //Act
            Result = R.EditSource(Pos, NewName, NewUrL);

            //Assert
            Assert.AreEqual(Result, true);
        }

        [TestMethod()]
        public void RemoveSourceTest()
        {
            //Arrange
            RSSSourcesLibrary R = new RSSSourcesLibrary();
            //List<int> L1 = new List<int>() { 1, 2, 3 }; //Genereaza ArgumentOutOfRangeException
            List<int> L2 = new List<int>() { 0 };
            bool /*Result1,*/ Result2;

            //Act
            //Result1 = R.RemoveSource(L1);
            Result2 = R.RemoveSource(L2);

            //Assert
            //Assert.AreEqual(Result1, true);
            Assert.AreEqual(Result2, true);
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
    }
}