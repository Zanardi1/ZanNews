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
            N.ReadFromLibrary(); //Sa schimb prototipul functiei in private dupa ce termin testele

            //Assert
            Assert.AreEqual(1, 1);
        }
    }
}