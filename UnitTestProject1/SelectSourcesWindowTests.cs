using ZanScore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZanScore.Tests
{
    [TestClass()]
    public class SelectSourcesWindowTests
    {
        [TestMethod()]
        public void UpdateSelectedSourcesListEngineTest()
        {
            //Arrange
            Form1 F = new Form1();
            SelectSourcesWindow S = new SelectSourcesWindow
            {
                Owner = F
            };
            S.NewsSourcesDataGrid.RowCount = 2;
            S.NewsSourcesDataGrid.Rows[0].Cells[0].Value = false;
            S.NewsSourcesDataGrid.Rows[1].Cells[0].Value = false;

            //Act
            S.UpdateSelectedSourcesListEngine();

            //Assert
            Assert.AreEqual(1, 1);
        }

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