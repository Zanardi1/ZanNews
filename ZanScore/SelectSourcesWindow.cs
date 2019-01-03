using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZanScore
{
    public partial class SelectSourcesWindow : Form
    {
        public SelectSourcesWindow()
        {
            InitializeComponent();
        }

        private void DisplaySourceNames(object sender, EventArgs e)
        {
            int NumberOfSources = ((Form1)this.Owner).NewsSourcesCollection.NumberofSources;
            for (int i = 0; i < NumberOfSources; i++)
            {
                NewsSourcesDataGrid.Rows.Add();
                NewsSourcesDataGrid.Rows[i].Cells[0].Value = ((Form1)this.Owner).NewsSourcesCollection.IsSourceSelected[i];
                NewsSourcesDataGrid.Rows[i].Cells[1].Value = ((Form1)this.Owner).NewsSourcesCollection.SourceTitle[i];
            }
            NewsSourcesDataGrid.RefreshEdit();
        }

        private void UpdateSelectedSourcesList(object sender, EventArgs e)
        {
            for (int i = 0; i < NewsSourcesDataGrid.RowCount; i++)
            {
                if ((bool)NewsSourcesDataGrid.Rows[i].Cells[0].Value == true)
                {
                    ((Form1)this.Owner).NewsSourcesCollection.IsSourceSelected[i] = true;
                    ((Form1)this.Owner).NewsSourcesCollection.NumberofSelectedSources++;
                }
                else
                    ((Form1)this.Owner).NewsSourcesCollection.IsSourceSelected[i] = false;
            }
        }
    }
}
