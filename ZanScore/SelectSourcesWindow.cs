using System;
using System.Windows.Forms;

namespace ZanScore
{
    /// <summary>
    /// Class that handles the source selecting window
    /// </summary>
    public partial class SelectSourcesWindow : Form
    {

        /// <summary>
        /// Class constructor
        /// </summary>
        public SelectSourcesWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds news to the Datagrid rows.
        /// </summary>
        private void AddRows()
        {
            int NumberOfSources = ((Form1)Owner).NewsSourcesCollection.NumberofSources;

            for (int i = 0; i < NumberOfSources; i++)
            {
                NewsSourcesDataGrid.Rows.Add();
                NewsSourcesDataGrid.Rows[i].Cells[0].Value = ((Form1)Owner).NewsSourcesCollection.IsSourceSelected[i];
                NewsSourcesDataGrid.Rows[i].Cells[1].Value = ((Form1)Owner).NewsSourcesCollection.SourceTitle[i];
            }
        }

        /// <summary>
        /// Contains the instructions to display the source names.
        /// </summary>
        /// <remarks>It has two steps:
        /// 1 - adding the rows on the data grid;
        /// 2 - refreshing the data grid to display the updated sources</remarks>
        public void DisplaySourceNamesEngine()
        {
            AddRows();
            NewsSourcesDataGrid.RefreshEdit();
        }

        /// <summary>
        /// Displays source names.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The params used to trigger the event.</param>
        /// <remarks>It's an event handler</remarks>
        private void DisplaySourceNames(object sender, EventArgs e)
        {
            DisplaySourceNamesEngine();
        }

        /// <summary>
        /// Contains the instructions which update the selected sources
        /// </summary>
        /// <remarks>The updating engine has the following steps:
        /// 1 - initializing the selected news sources count;
        /// 2 - cycling through the data grid. If a news source is selected, then increase the count with 1 and mark that source as selected in the IsSourceSelected list</remarks>
        public void UpdateSelectedSourcesListEngine()
        {
            ((Form1)Owner).NewsSourcesCollection.NumberofSelectedSources = 0;
            for (int i = 0; i < NewsSourcesDataGrid.RowCount; i++)
            {
                if ((bool)NewsSourcesDataGrid.Rows[i].Cells[0].Value == true)
                {
                    ((Form1)Owner).NewsSourcesCollection.IsSourceSelected[i] = true;
                    ((Form1)Owner).NewsSourcesCollection.NumberofSelectedSources++;
                }
                else
                    ((Form1)this.Owner).NewsSourcesCollection.IsSourceSelected[i] = false;
            }
        }

        /// <summary>
        /// Updates the selected sources list.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The params used to trigger the event.</param>
        /// <remarks>It's an event handler</remarks>
        private void UpdateSelectedSourcesList(object sender, EventArgs e)
        {
            UpdateSelectedSourcesListEngine();
        }
    }
}
