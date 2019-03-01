using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZanScore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.AreEqual(1,1);
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
            Assert.AreEqual(1,1);
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
            Assert.AreEqual(1,1);
        }

        [TestMethod()]
        public void SaveSourcesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddNewSourceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditSourceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveSourceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ShowNewsSourcesInDataGridTest()
        {
            Assert.Fail();
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