using System;
using System.Windows.Forms;

namespace ZanScore
{
    public partial class SelectSourcesWindow : Form
    {

        public SelectSourcesWindow()
        {
            InitializeComponent();
        }

        private void AddRows()
        //Procedura adauga randurile in grila cu stiri
        {
            int NumberOfSources = ((Form1)Owner).NewsSourcesCollection.NumberofSources;

            for (int i = 0; i < NumberOfSources; i++)
            {
                NewsSourcesDataGrid.Rows.Add();
                NewsSourcesDataGrid.Rows[i].Cells[0].Value = ((Form1)Owner).NewsSourcesCollection.IsSourceSelected[i];
                NewsSourcesDataGrid.Rows[i].Cells[1].Value = ((Form1)Owner).NewsSourcesCollection.SourceTitle[i];
            }
        }

        public void DisplaySourceNamesEngine()
        //Procedura afiseaza numele surselor de stiri. Am separat-o de handler pentru a fi mai usor de testat
        {
            AddRows();
            NewsSourcesDataGrid.RefreshEdit();
        }

        private void DisplaySourceNames(object sender, EventArgs e)
        {
            DisplaySourceNamesEngine();
        }

        public void UpdateSelectedSourcesListEngine()
        //Procedura se ocupa de actualizarea listei cu surse selectate. Am separat-o de handler pentru a fi mai usor de testat
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

        private void UpdateSelectedSourcesList(object sender, EventArgs e)
        {
            UpdateSelectedSourcesListEngine();
        }
    }
}
