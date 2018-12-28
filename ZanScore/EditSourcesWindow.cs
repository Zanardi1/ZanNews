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
            DialogResult UserAnswer;
            string text = "Are you sure you want to delete the selected news source?";
            string caption = "Confirm deletion";
            MessageBoxButtons Buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon Icon = MessageBoxIcon.Question;
            MessageBoxDefaultButton Default = MessageBoxDefaultButton.Button1;
            UserAnswer = MessageBox.Show(text, caption, Buttons, Icon, Default);
            if (UserAnswer == DialogResult.Yes)
            {
                List<int> Positions = new List<int>();
                int j = 0;
                for (int i = 0; i < AllTheSources.RowCount; i++)
                    if (AllTheSources.Rows[i].Selected)
                    {
                        Positions.Add(i);
                        j++;
                    }
           ((Form1)Owner).NewsSourcesCollection.RemoveSource(Positions);
                for (int i = 0; i < AllTheSources.Rows.Count; i++)
                    if (AllTheSources.Rows[i].Selected)
                        AllTheSources.Rows.RemoveAt(i);
            }
        }

        private void EditSelectedSource(object sender, EventArgs e)
        {
            NewSourceNameLabel.Enabled = true;
            NewSourceURLLabel.Enabled = true;
            NewSourceNameText.Enabled = true;
            NewSourceURLText.Enabled = true;
            SaveNewsEditButton.Enabled = true;
            DiscardNewsEditButton.Enabled = true;
            SortNewsButton.Enabled = false;
            DeleteNewsButton.Enabled = false;
            SaveChanges.Enabled = false;
            DiscardChanges.Enabled = false;
            for (int i = 0; i < AllTheSources.RowCount; i++)
                if (AllTheSources.Rows[i].Selected)
                {
                    NewSourceNameText.Text = AllTheSources.Rows[i].Cells[0].Value.ToString();
                    NewSourceURLText.Text = AllTheSources.Rows[i].Cells[1].Value.ToString();
                }
        }
    }
}
