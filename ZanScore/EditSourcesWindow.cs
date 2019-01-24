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
            SourceNameToEdit.Width = 2 * AllTheSources.Width / 10;
            SourceURLToEdit.Width = 7 * AllTheSources.Width / 10;
        }

        private void DeletingNewsEngine()
        {
            List<int> Positions = new List<int>(); //retine pozitiile stirilor care vor fi sterse
            ((Form1)Owner).OH.WindowsStartup = 1;
            for (int i = 0; i < AllTheSources.RowCount; i++)
                if (AllTheSources.Rows[i].Selected)
                    Positions.Add(i);
            ((Form1)Owner).NewsSourcesCollection.RemoveSource(Positions);
            ((Form1)Owner).NewsSourcesCollection.SaveSources();
            for (int i = 0; i < AllTheSources.Rows.Count; i++)
                if (AllTheSources.Rows[i].Selected)
                    AllTheSources.Rows.RemoveAt(i);
        }

        private void DeleteSelectedNewsSources(object sender, EventArgs e)
        {
            MessageBoxButtons Buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon Icon = MessageBoxIcon.Question;
            MessageBoxDefaultButton Default = MessageBoxDefaultButton.Button1;
            DialogResult UserAnswer = MessageBox.Show("Are you sure you want to delete the selected news source? This cannot be undone!", "Confirm deletion", Buttons, Icon, Default);
            if (UserAnswer == DialogResult.Yes)
                DeletingNewsEngine();
        }

        private void SouceEditingEngine(int Pos)
        {
            if (AllTheSources.Rows[Pos].Selected)
            {
                int j = 0;

                NewSourceNameText.Text = AllTheSources.Rows[Pos].Cells[0].Value.ToString();
                NewSourceURLText.Text = AllTheSources.Rows[Pos].Cells[1].Value.ToString();
                j = Pos + 1;
                SelectedPositionInGrid = Pos;
                while (j < AllTheSources.RowCount) //Deselecteaza toate stirile de dedesubtul primei stiri alese (care va fi si editata)
                {
                    AllTheSources.Rows[j].Selected = false;
                    j++;
                }
            }
        }

        private void EditSelectedSource(object sender, EventArgs e)
        {
            int i = 0;
            EnableEditingControls();
            while (i < AllTheSources.RowCount)
            {
                SouceEditingEngine(i);
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

        private void DisableReorderingControls()
        {
            MoveUpOnePositionButton.Enabled = false;
            MoveDownOnePositionButton.Enabled = false;
            MoveToFirstPositionButton.Enabled = false;
            MoveToLastPositionButton.Enabled = false;
            EditNewsButton.Enabled = true;
            DeleteNewsButton.Enabled = true;
            FinishReorderingButton.Enabled = false;
        }

        private void EnableReorderingControls()
        //Activeaza controalele ce permit reordonarea surselor
        {
            MoveUpOnePositionButton.Enabled = true;
            MoveDownOnePositionButton.Enabled = true;
            MoveToFirstPositionButton.Enabled = true;
            MoveToLastPositionButton.Enabled = true;
            EditNewsButton.Enabled = false;
            DeleteNewsButton.Enabled = false;
            FinishReorderingButton.Enabled = true;
        }

        private void ReorderSelectedNewsSources(object sender, EventArgs e)
        {
            EnableReorderingControls();
        }

        private void MoveUpOnePositionInGrid(int Position,int Cell)
        {
            string buffer;

            buffer = AllTheSources.Rows[Position - 1].Cells[Cell].Value.ToString();
            AllTheSources.Rows[Position - 1].Cells[Cell].Value = AllTheSources.Rows[Position].Cells[Cell].Value;
            AllTheSources.Rows[Position].Cells[Cell].Value = buffer;
        }

        private void MoveUpOnePositionEngine(int Position)
        //Logica de mutare a stirii selectate cu o pozitie mai sus
        {
            ((Form1)this.Owner).NewsSourcesCollection.SortSources(Position, 1);

            MoveUpOnePositionInGrid(Position, 0);
            MoveUpOnePositionInGrid(Position, 1);

            AllTheSources.Rows[Position - 1].Selected = true;
            AllTheSources.Rows[Position].Selected = false;
        }

        private void MoveSelectedSourceUpOnePosition(object sender, EventArgs e)
        //Subrutina muta sursa aleasa cu o pozitie mai sus
        {
            int i = 0;
            while (AllTheSources.Rows[i].Selected == false)
                i++; //Cauta prima sursa selectata si-i retine pozitia
            DisselectEverythingBelow(i);
            if (i > 0)
                MoveUpOnePositionEngine(i);
        }

        private void MoveDownOnePositionInGrid(int Position, int Cell)
        {
            string buffer;

            buffer = AllTheSources.Rows[Position + 1].Cells[Cell].Value.ToString();
            AllTheSources.Rows[Position + 1].Cells[Cell].Value = AllTheSources.Rows[Position].Cells[Cell].Value;
            AllTheSources.Rows[Position].Cells[Cell].Value = buffer;
        }

        private void MoveDownOnePositionEngine(int Position)
        //Logica de mutare a stirii selectate cu o pozitie mai jos
        {
            ((Form1)Owner).NewsSourcesCollection.SortSources(Position, 2);

            MoveDownOnePositionInGrid(Position, 0);
            MoveDownOnePositionInGrid(Position, 1);

            AllTheSources.Rows[Position + 1].Selected = true;
            AllTheSources.Rows[Position].Selected = false;
        }

        private void MoveSelectedSourceDownOnePosition(object sender, EventArgs e)
        //Subrutina muta sursa aleasa cu o pozitie mai jos
        {
            int i = 0;
            while (AllTheSources.Rows[i].Selected == false)
                i++; //Cauta prima sursa selectata si-i retine pozitia
            DisselectEverythingBelow(i);
            if (i < AllTheSources.RowCount - 1)
                MoveDownOnePositionEngine(i);
        }

        private void MoveToFirstPositionInGrid(int Position,int Cell)
        {
            string buffer;

            buffer = AllTheSources.Rows[Position].Cells[Cell].Value.ToString();
            for (int j = Position; j > 0; j--)
                AllTheSources.Rows[j].Cells[Cell].Value = AllTheSources.Rows[j - 1].Cells[Cell].Value;
            AllTheSources.Rows[0].Cells[0].Value = buffer;
        }

        private void MoveToFirstPositionEngine(int StartingPosition)
        //Logica de mutare a stirii selectate pe prima pozitie 
        {
            ((Form1)this.Owner).NewsSourcesCollection.SortSources(StartingPosition, 3);

            MoveToFirstPositionInGrid(StartingPosition, 0);
            MoveToFirstPositionInGrid(StartingPosition, 1);
        }

        private void MoveSelectedSourceToFirstPosition(object sender, EventArgs e)
        //Subrutina muta sursa aleasa pe prima pozitie
        {
            int i = 0;
            while (AllTheSources.Rows[i].Selected == false)
                i++; //Cauta prima sursa selectata si-i retine pozitia
            if (i > 0)
                MoveToFirstPositionEngine(i);
        }

        private void MoveToLastPositionInGrid(int Position,int Cell)
        {
            string buffer;

            buffer = AllTheSources.Rows[Position].Cells[Cell].Value.ToString();
            for (int j = Position; j < AllTheSources.RowCount - 1; j++)
                AllTheSources.Rows[j].Cells[Cell].Value = AllTheSources.Rows[j + 1].Cells[Cell].Value;
            AllTheSources.Rows[AllTheSources.RowCount - 1].Cells[Cell].Value = buffer;

        }

        private void MovingToLastPositionEngine(int StartingPosition)
        //Logica de mutare a stirii selectate pe ultima pozitie 
        {
            ((Form1)this.Owner).NewsSourcesCollection.SortSources(StartingPosition, 4);

            MoveToLastPositionInGrid(StartingPosition, 0);
            MoveToLastPositionInGrid(StartingPosition, 1);
        }

        private void MoveSelectedSourceToLastPosition(object sender, EventArgs e)
        //Subrutina muta sursa aleasa pe ultima pozitie
        {
            int i = 0;
            while (AllTheSources.Rows[i].Selected == false)
                i++; //Cauta prima sursa selectata si-i retine pozitia
            DisselectEverythingBelow(i);
            if (i < AllTheSources.RowCount)
                MovingToLastPositionEngine(i);
        }

        private void FinishReorderingSelectedNewsSource(object sender, EventArgs e)
        {
            DisableReorderingControls();
            ((Form1)this.Owner).NewsSourcesCollection.SaveSources();
        }

        private void DisselectEverythingBelow(int Position)
        //Subrutina deselecteaza toate randurile de sub randul cu numarul Position
        {
            int j = Position + 1;
            while (j < AllTheSources.RowCount)
            {
                AllTheSources.Rows[j].Selected = false;
                j++;
            }
        }

        private void CloseWindow(object sender, FormClosedEventArgs e)
        {
            ((Form1)this.Owner).NewsSourcesCollection.SaveSources();
        }
    }
}
