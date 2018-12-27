using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace ZanScore
{
    public partial class EditSourcesWindow : Form
    {
        public EditSourcesWindow()
        {
            InitializeComponent();
            SourceNameToEdit.Width = AllTheSources.Width / 3;
            SourceURLToEdit.Width = 2 * AllTheSources.Width / 3;
        }

        private void DeleteSelectedNewsSources(object sender, System.EventArgs e)
        {
            List<int> Positions = new List<int>();
            int j = 0;
            for (int i = 0; i < AllTheSources.RowCount; i++)
                if (AllTheSources.Rows[i].Selected)
                {
                    //Array.Resize(ref Positions, Positions.Length + 1);
                    Positions.Add(i);
                    j++;
                }
           ((Form1)Owner).NewsSourcesCollection.RemoveSource(Positions);
            for (int i = 0; i < AllTheSources.Rows.Count; i++)
                if (AllTheSources.Rows[i].Selected)
                    AllTheSources.Rows.RemoveAt(i);
        }
    }
}
