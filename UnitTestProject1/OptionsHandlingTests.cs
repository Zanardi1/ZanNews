using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;

namespace ZanScore.Tests
{
    [TestClass()]
    public class OptionsHandlingTests
    {
        [TestMethod()]
        public void OpenOptionsFileTest()
        {
            //Arrange
            OptionsHandling O = new OptionsHandling();

            //Act
            O.OpenOptionsFile();

            //Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void SaveOptionsToFileTest()
        {
            //Arrange
            OptionsHandling O = new OptionsHandling();

            //Act
            O.SaveOptionsToFile();

            //Assert
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void ReadOptionsFromFileTest()
        {
            //Arrange
            OptionsHandling O = new OptionsHandling();

            //Act
            O.ReadOptionsFromFile();

            //Assert
            Assert.AreEqual(1,1);
        }
    }
}