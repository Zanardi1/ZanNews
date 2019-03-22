using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace ZanScore
{
    /// <summary>
    /// The class which implements the source editing window.
    /// </summary>
    public partial class EditSourcesWindow : Form
    {
        private int selectedpositioningrid = 0;

        /// <summary>
        /// Stores the selected position from the grid.
        /// </summary>
        private int SelectedPositionInGrid 
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

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <remarks>
        /// The source name column occupies 20% of the grid width. The source URL occupies 70%.
        /// </remarks>
        public EditSourcesWindow()
        {
            InitializeComponent();
            SourceNameToEdit.Width = 2 * AllTheSources.Width / 10;
            SourceURLToEdit.Width = 7 * AllTheSources.Width / 10;
        }

        /// <summary>
        /// Deletes all the selected news source(s) from the grid.
        /// </summary>
        private void DeleteNewsFromGrid()
        {
            for (int i = 0; i < AllTheSources.Rows.Count; i++)
                if (AllTheSources.Rows[i].Selected)
                    AllTheSources.Rows.RemoveAt(i);
        }

        /// <summary>
        /// Deletes the news source(s) from the internal variables which stores them.
        /// </summary>
        /// <remarks>
        /// Positions is a list which stores the positions of the news that will be deleted.
        /// </remarks>
        private void DeletingNewsEngine()
        {
            List<int> Positions = new List<int>(); 
            for (int i = 0; i < AllTheSources.RowCount; i++)
                if (AllTheSources.Rows[i].Selected)
                    Positions.Add(i);

            if (((Form1)Owner).NewsSourcesCollection.RemoveSource(Positions))
            {
                ((Form1)Owner).NewsSourcesCollection.SaveSources();
                DeleteNewsFromGrid();
            }
            else
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show("The selected source(s) could not be deleted", "Error!", MB, MI);
            }
        }

        /// <summary>
        /// The procedure of deleting the selected news source(s).
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
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

        /// <summary>
        /// The instructions of editing the selected news source.
        /// </summary>
        /// <param name="Pos">The position of the news source to be edited.</param>
        private void SouceEditingEngine(int Pos)
        {
            NewSourceNameText.Text = AllTheSources.Rows[Pos].Cells[0].Value.ToString();
            NewSourceURLText.Text = AllTheSources.Rows[Pos].Cells[1].Value.ToString();

            SelectedPositionInGrid = Pos;

            DisselectEverythingBelow(Pos);
        }

        /// <summary>
        /// The procedure of editing the selected news source.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void EditSelectedSource(object sender, EventArgs e)
        {
            int i = 0;
            EnableEditingControls();
            while ((i < AllTheSources.RowCount) && (AllTheSources.Rows[i].Selected))
            {
                SouceEditingEngine(i);
                i++;
            }
        }

        /// <summary>
        /// The procedure of editing discarding and undoing any changes.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void DiscardEditingChanges(object sender, EventArgs e)
        {
            DisableEditingControls();
        }

        /// <summary>
        /// The procedure of saving the editing changes.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void SaveEditChanges(object sender, EventArgs e)
        {
            if (((Form1)Owner).NewsSourcesCollection.EditSource(SelectedPositionInGrid, NewSourceNameText.Text, NewSourceURLText.Text))
            {
                AllTheSources.Rows[SelectedPositionInGrid].Cells[0].Value = NewSourceNameText.Text;
                AllTheSources.Rows[SelectedPositionInGrid].Cells[1].Value = NewSourceURLText.Text;
                DisableEditingControls();
            }
            else
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show("The changes could not be saved!", "Error!", MB, MI);
            }
        }

        /// <summary>
        /// Enables the source editing controls.
        /// </summary>
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

        /// <summary>
        /// Disables the source editing controls.
        /// </summary>
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

        /// <summary>
        /// Disables the news sources ordering controls.
        /// </summary>
        private void DisableReorderingControls()
        {
            MoveUpOnePositionButton.Enabled = false;
            MoveDownOnePositionButton.Enabled = false;
            MoveToFirstPositionButton.Enabled = false;
            MoveToLastPositionButton.Enabled = false;
            EditNewsButton.Enabled = AllTheSources.RowCount > 0 ? true : false;
            DeleteNewsButton.Enabled = AllTheSources.RowCount > 0 ? true : false;
            FinishReorderingButton.Enabled = false;
        }

        /// <summary>
        /// Enables the news sources ordering controls.
        /// </summary>
        private void EnableReorderingControls()
        {
            MoveUpOnePositionButton.Enabled = true;
            MoveDownOnePositionButton.Enabled = true;
            MoveToFirstPositionButton.Enabled = true;
            MoveToLastPositionButton.Enabled = true;
            EditNewsButton.Enabled = false;
            DeleteNewsButton.Enabled = false;
            FinishReorderingButton.Enabled = true;
        }

        /// <summary>
        /// Reordering news sources.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void ReorderSelectedNewsSources(object sender, EventArgs e)
        {
            EnableReorderingControls();
        }

        /// <summary>
        /// Moves the selected news one position upward in the grid.
        /// </summary>
        /// <param name="Position">The position of the news that will be reordered.</param>
        /// <param name="Cell">The cell (column) of the grid whose content will be reordered.</param>
        private void MoveUpOnePositionInGrid(int Position, int Cell)
        {
            string buffer;

            buffer = AllTheSources.Rows[Position - 1].Cells[Cell].Value.ToString();
            AllTheSources.Rows[Position - 1].Cells[Cell].Value = AllTheSources.Rows[Position].Cells[Cell].Value;
            AllTheSources.Rows[Position].Cells[Cell].Value = buffer;
        }

        /// <summary>
        /// Moves a selected news source one position above.
        /// </summary>
        /// <param name="Position">The position of the news that will be moved.</param>
        private void MoveUpOnePositionEngine(int Position)
        {
            ((Form1)this.Owner).NewsSourcesCollection.SortSources(Position, 1);

            MoveUpOnePositionInGrid(Position, 0);
            MoveUpOnePositionInGrid(Position, 1);

            AllTheSources.Rows[Position - 1].Selected = true;
            AllTheSources.Rows[Position].Selected = false;
        }

        /// <summary>
        /// The entire procedure of moving the selected news one position above plus the other actions required.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void MoveSelectedSourceUpOnePosition(object sender, EventArgs e)
        {
            int i = 0;
            while (AllTheSources.Rows[i].Selected == false)
                i++; 
            DisselectEverythingBelow(i);
            if (i > 0)
                MoveUpOnePositionEngine(i);
        }

        /// <summary>
        ///  Moves the selected news one position downward in the grid.
        /// </summary>
        /// <param name="Position">The position of the news that will be reordered.</param>
        /// <param name="Cell">The cell (column) of the grid whose content will be reordered.</param>
        private void MoveDownOnePositionInGrid(int Position, int Cell)
        {
            string buffer;

            buffer = AllTheSources.Rows[Position + 1].Cells[Cell].Value.ToString();
            AllTheSources.Rows[Position + 1].Cells[Cell].Value = AllTheSources.Rows[Position].Cells[Cell].Value;
            AllTheSources.Rows[Position].Cells[Cell].Value = buffer;
        }

        /// <summary>
        /// Moves a selected news source one position below.
        /// </summary>
        /// <param name="Position">The position of the news that will be moved.</param>
        private void MoveDownOnePositionEngine(int Position)
        {
            ((Form1)Owner).NewsSourcesCollection.SortSources(Position, 2);

            MoveDownOnePositionInGrid(Position, 0);
            MoveDownOnePositionInGrid(Position, 1);

            AllTheSources.Rows[Position + 1].Selected = true;
            AllTheSources.Rows[Position].Selected = false;
        }

        /// <summary>
        /// The entire procedure of moving the selected news one position below, plus the other actions required.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void MoveSelectedSourceDownOnePosition(object sender, EventArgs e)
        {
            int i = 0;
            while (AllTheSources.Rows[i].Selected == false)
                i++; 
            DisselectEverythingBelow(i);
            if (i < AllTheSources.RowCount - 1)
                MoveDownOnePositionEngine(i);
        }

        /// <summary>
        /// Moves the selected news on the first position in the grid.
        /// </summary>
        /// <param name="Position">The position of the news that will be reordered.</param>
        /// <param name="Cell">The cell (column) of the grid whose content will be reordered.</param>
        private void MoveToFirstPositionInGrid(int Position, int Cell)
        {
            string buffer;

            buffer = AllTheSources.Rows[Position].Cells[Cell].Value.ToString();
            for (int j = Position; j > 0; j--)
                AllTheSources.Rows[j].Cells[Cell].Value = AllTheSources.Rows[j - 1].Cells[Cell].Value;
            AllTheSources.Rows[0].Cells[0].Value = buffer;
        }

        /// <summary>
        /// The instructions that move the selected news on the first position.
        /// </summary>
        /// <param name="StartingPosition">The position of the news that will be moved.</param>
        private void MoveToFirstPositionEngine(int StartingPosition)
        {
            ((Form1)this.Owner).NewsSourcesCollection.SortSources(StartingPosition, 3);

            MoveToFirstPositionInGrid(StartingPosition, 0);
            MoveToFirstPositionInGrid(StartingPosition, 1);
        }

        /// <summary>
        /// Moving the source on the first position, plus the other actions required.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void MoveSelectedSourceToFirstPosition(object sender, EventArgs e)
        //Subrutina muta sursa aleasa pe prima pozitie
        {
            int i = 0;
            while (AllTheSources.Rows[i].Selected == false)
                i++; //Cauta prima sursa selectata si-i retine pozitia
            if (i > 0)
                MoveToFirstPositionEngine(i);
        }

        /// <summary>
        /// Moves the selected news on the last position in the grid.
        /// </summary>
        /// <param name="Position">The position of the news that will be reordered.</param>
        /// <param name="Cell">The cell (column) of the grid whose content will be reordered.</param>
        private void MoveToLastPositionInGrid(int Position, int Cell)
        {
            string buffer;

            buffer = AllTheSources.Rows[Position].Cells[Cell].Value.ToString();
            for (int j = Position; j < AllTheSources.RowCount - 1; j++)
                AllTheSources.Rows[j].Cells[Cell].Value = AllTheSources.Rows[j + 1].Cells[Cell].Value;
            AllTheSources.Rows[AllTheSources.RowCount - 1].Cells[Cell].Value = buffer;
        }

        /// <summary>
        /// The instructions that move the selected news on the last position.
        /// </summary>
        /// <param name="StartingPosition">The position of the news that will be moved.</param>
        private void MovingToLastPositionEngine(int StartingPosition)
        {
            ((Form1)this.Owner).NewsSourcesCollection.SortSources(StartingPosition, 4);

            MoveToLastPositionInGrid(StartingPosition, 0);
            MoveToLastPositionInGrid(StartingPosition, 1);
        }

        /// <summary>
        /// Moving the source on the last position, plus the other actions required.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void MoveSelectedSourceToLastPosition(object sender, EventArgs e)
        {
            int i = 0;

            while (AllTheSources.Rows[i].Selected == false)
                i++; 

            DisselectEverythingBelow(i);

            if (i < AllTheSources.RowCount)
                MovingToLastPositionEngine(i);
        }

        /// <summary>
        /// Saves the changes of the news sources reordering.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void FinishReorderingSelectedNewsSource(object sender, EventArgs e)
        {
            DisableReorderingControls();
            ((Form1)this.Owner).NewsSourcesCollection.SaveSources();
        }

        /// <summary>
        /// Disselects all the grid rows below a certain position.
        /// </summary>
        /// <param name="Position">The position from which all the rows will be disselected.</param>
        private void DisselectEverythingBelow(int Position)
        {
            int j = Position + 1;
            while (j < AllTheSources.RowCount)
            {
                AllTheSources.Rows[j].Selected = false;
                j++;
            }
        }

        /// <summary>
        /// Actions made at window closing.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void CloseWindow(object sender, FormClosedEventArgs e)
        {
            ((Form1)this.Owner).NewsSourcesCollection.SaveSources();
        }

        /// <summary>
        /// Tests if the three buttons (editing, deleting and reordering news) are available, depending on the number of news sources from this window.
        /// </summary>
        private void CheckForButtonAvailability()
        {
            EditNewsButton.Enabled = AllTheSources.RowCount > 0 ? true : false;
            DeleteNewsButton.Enabled = AllTheSources.RowCount > 0 ? true : false;
            ReorderNewsButton.Enabled = AllTheSources.RowCount > 0 ? true : false;
        }

        /// <summary>
        /// Actions taken after the window is shown.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void StuffAfterTheFormIsShown(object sender, EventArgs e)
        {
            CheckForButtonAvailability();
        }

        /// <summary>
        /// Actions taken if the sources grid is empty.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void CheckForEmptyGrid(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CheckForButtonAvailability();
        }
    }
}
