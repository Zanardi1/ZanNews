using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace ZanScore
{
    public partial class EditSourcesWindow : Form
    {
        private int selectedpositioningrid = 0;

        int SelectedPositionInGrid //retine pozitia selectata din grila
        {
            get
            {
                return selectedpositioningrid;
            }
            set
            {
                if (value >= 0)
                    selectedpositioningrid = value;
                else
                    selectedpositioningrid = 0;
            }
        }

        public EditSourcesWindow()
        {
            InitializeComponent();
            SourceNameToEdit.Width = 2 * AllTheSources.Width / 10;
            SourceURLToEdit.Width = 7 * AllTheSources.Width / 10;
        }

        private void DeleteNewsFromGrid()
        //Sterge stirile din grila
        {
            for (int i = 0; i < AllTheSources.Rows.Count; i++)
                if (AllTheSources.Rows[i].Selected)
                    AllTheSources.Rows.RemoveAt(i);
        }

        private void DeletingNewsEngine()
        //instructiunile de stergere propriu-zisa a stirilor selectate
        {
            List<int> Positions = new List<int>(); //retine pozitiile stirilor care vor fi sterse
            for (int i = 0; i < AllTheSources.RowCount; i++)
                if (AllTheSources.Rows[i].Selected)
                    Positions.Add(i);

            ((Form1)Owner).NewsSourcesCollection.RemoveSource(Positions);
            ((Form1)Owner).NewsSourcesCollection.SaveSources();

            DeleteNewsFromGrid();
        }

        private void DeleteSelectedNewsSources(object sender, EventArgs e)
        //procedura de stergere a stirilor selectate
        {
            MessageBoxButtons Buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon Icon = MessageBoxIcon.Question;
            MessageBoxDefaultButton Default = MessageBoxDefaultButton.Button1;
            DialogResult UserAnswer = MessageBox.Show("Are you sure you want to delete the selected news source? This cannot be undone!", "Confirm deletion", Buttons, Icon, Default);
            if (UserAnswer == DialogResult.Yes)
                DeletingNewsEngine();
        }

        private void SouceEditingEngine(int Pos)
        //Instructiunile de editare propriu-zisa a sursei selectate
        {
            NewSourceNameText.Text = AllTheSources.Rows[Pos].Cells[0].Value.ToString();
            NewSourceURLText.Text = AllTheSources.Rows[Pos].Cells[1].Value.ToString();

            SelectedPositionInGrid = Pos;

            DisselectEverythingBelow(Pos);
        }

        private void EditSelectedSource(object sender, EventArgs e)
        //Procedura de editare a sursei selectate
        {
            int i = 0;
            EnableEditingControls();
            while ((i < AllTheSources.RowCount) && (AllTheSources.Rows[i].Selected))
            {
                SouceEditingEngine(i);
                i++;
            }
        }

        private void DiscardEditingChanges(object sender, EventArgs e) => DisableEditingControls();
        //Procedura de renuntare la editare si de stergere a modificarilor aduse

        private void SaveEditChanges(object sender, EventArgs e)
        //Procedura de salvare a modificarilor efectuate
        {
            ((Form1)Owner).NewsSourcesCollection.EditSource(SelectedPositionInGrid, NewSourceNameText.Text, NewSourceURLText.Text);
            AllTheSources.Rows[SelectedPositionInGrid].Cells[0].Value = NewSourceNameText.Text;
            AllTheSources.Rows[SelectedPositionInGrid].Cells[1].Value = NewSourceURLText.Text;
            DisableEditingControls();
        }

        private void EnableEditingControls()
        //Procedura de activare a controlalelor legate de editarea sursei
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
        //Procedura de dezactivare a controlalelor legate de editarea sursei
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
        //Procedura de dezactivare a controlalelor legate de ordonarea surselor de stiri
        {
            MoveUpOnePositionButton.Enabled = false;
            MoveDownOnePositionButton.Enabled = false;
            MoveToFirstPositionButton.Enabled = false;
            MoveToLastPositionButton.Enabled = false;
            EditNewsButton.Enabled = AllTheSources.RowCount > 0 ? true : false;
            DeleteNewsButton.Enabled = AllTheSources.RowCount > 0 ? true : false;
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

        private void ReorderSelectedNewsSources(object sender, EventArgs e) => EnableReorderingControls();
        //Reordonarea surselor de stiri

        private void MoveUpOnePositionInGrid(int Position, int Cell)
        //Procedura de mutare cu o pozitie in sus a stirii selectate
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
        //Procedura de mutare cu o pozitie in jos a stirii selectate
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

        private void MoveToFirstPositionInGrid(int Position, int Cell)
        //Procedura de mutare pe prima pozitie a stirii selectate
        {
            string buffer;

            buffer = AllTheSources.Rows[Position].Cells[Cell].Value.ToString();
            for (int j = Position; j > 0; j--)
                AllTheSources.Rows[j].Cells[Cell].Value = AllTheSources.Rows[j - 1].Cells[Cell].Value;
            AllTheSources.Rows[0].Cells[0].Value = buffer;
        }

        private void MoveToFirstPositionEngine(int StartingPosition)
        //Instructiunile de mutare propriu-zisa a stirii selectate pe prima pozitie 
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

        private void MoveToLastPositionInGrid(int Position, int Cell)
        //Instructiunile de mutare propriu-zisa a stirii selectate pe ultima pozitie 
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
        //Procedura de salvare a modificarilor stirii editate
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

        private void CloseWindow(object sender, FormClosedEventArgs e) => ((Form1)this.Owner).NewsSourcesCollection.SaveSources();
        //Procedura de inchidere a ferestrei

        private void CheckForButtonAvailability()
        //procedura testeaza daca cele trei butoane sunt activate sau nu, in functie de numarul de stiri din aceasta fereastra
        {
            EditNewsButton.Enabled = AllTheSources.RowCount > 0 ? true : false;
            DeleteNewsButton.Enabled = AllTheSources.RowCount > 0 ? true : false;
            ReorderNewsButton.Enabled = AllTheSources.RowCount > 0 ? true : false;
        }

        private void StuffAfterTheFormIsShown(object sender, EventArgs e) => CheckForButtonAvailability();
        //Procesari efectuate dupa afisarea ferestrei

        private void CheckForEmptyGrid(object sender, DataGridViewRowsRemovedEventArgs e) => CheckForButtonAvailability();
        //Procedura verifica daca, dupa eliminearea unei surse de stiri, grila devine goala, deoarece nu mai e nicio sursa de stiri
    }
}
