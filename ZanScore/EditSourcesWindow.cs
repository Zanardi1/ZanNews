using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace ZanScore
{
    public partial class EditSourcesWindow : Form
    {
        int SelectedPositionInGrid = 0;
        public EditSourcesWindow()
        {
            InitializeComponent();
            SourceNameToEdit.Width = AllTheSources.Width / 3;
            SourceURLToEdit.Width = 2 * AllTheSources.Width / 3;
        }

        private void DeleteSelectedNewsSources(object sender, System.EventArgs e)
        {
            DialogResult UserAnswer;
            string text = "Are you sure you want to delete the selected news source? This cannot be undone!";
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
                ((Form1)Owner).NewsSourcesCollection.SaveSources();
                for (int i = 0; i < AllTheSources.Rows.Count; i++)
                    if (AllTheSources.Rows[i].Selected)
                        AllTheSources.Rows.RemoveAt(i);
            }
        }

        private void EditSelectedSource(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            bool IsNewsSelected = false;
            EnableEditingControls();
            while ((i < AllTheSources.RowCount) && (!IsNewsSelected))
            {
                if (AllTheSources.Rows[i].Selected)
                {
                    NewSourceNameText.Text = AllTheSources.Rows[i].Cells[0].Value.ToString();
                    NewSourceURLText.Text = AllTheSources.Rows[i].Cells[1].Value.ToString();
                    j = i + 1;
                    SelectedPositionInGrid = i;
                    while (j < AllTheSources.RowCount) //Deselecteaza toate stirile de dedesubtul primei stiri alese (care va fi si editata)
                    {
                        AllTheSources.Rows[j].Selected = false;
                        j++;
                    }
                    IsNewsSelected = true;
                }
                i++;
            }
        }

        private void DiscardEditingChanges(object sender, EventArgs e)
        {
            DisableEditingControls();
        }

        private void SaveEditChanges(object sender, EventArgs e)
        {
            ((Form1)Owner).NewsSourcesCollection.EditSource(SelectedPositionInGrid, NewSourceNameText.Text, NewSourceURLText.Text);
            AllTheSources.Rows[SelectedPositionInGrid].Cells[0].Value = NewSourceNameText.Text;
            AllTheSources.Rows[SelectedPositionInGrid].Cells[1].Value = NewSourceURLText.Text;
            DisableEditingControls();
        }

        private void EnableEditingControls()
        {
            NewSourceNameLabel.Enabled = true;
            NewSourceURLLabel.Enabled = true;
            NewSourceNameText.Enabled = true;
            NewSourceURLText.Enabled = true;
            SaveNewsEditButton.Enabled = true;
            DiscardNewsEditButton.Enabled = true;
            ReorderNewsButton.Enabled = false;
            DeleteNewsButton.Enabled = false;
        }

        private void DisableEditingControls()
        {
            NewSourceNameLabel.Enabled = false;
            NewSourceURLLabel.Enabled = false;
            NewSourceNameText.Enabled = false;
            NewSourceURLText.Enabled = false;
            SaveNewsEditButton.Enabled = false;
            DiscardNewsEditButton.Enabled = false;
            ReorderNewsButton.Enabled = true;
            DeleteNewsButton.Enabled = true;
            NewSourceNameText.Text = "";
            NewSourceURLText.Text = "";
        }
    }
}
