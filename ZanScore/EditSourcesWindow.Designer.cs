namespace ZanScore
{
    partial class EditSourcesWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EditNewsButton = new System.Windows.Forms.Button();
            this.DeleteNewsButton = new System.Windows.Forms.Button();
            this.SaveChanges = new System.Windows.Forms.Button();
            this.DiscardChanges = new System.Windows.Forms.Button();
            this.AllTheSources = new System.Windows.Forms.DataGridView();
            this.SourceNameToEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceURLToEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewsSourceSelectGroupBox = new System.Windows.Forms.GroupBox();
            this.FinishReorderingButton = new System.Windows.Forms.Button();
            this.MoveToLastPositionButton = new System.Windows.Forms.Button();
            this.MoveToFirstPositionButton = new System.Windows.Forms.Button();
            this.MoveDownOnePositionButton = new System.Windows.Forms.Button();
            this.MoveUpOnePositionButton = new System.Windows.Forms.Button();
            this.DiscardNewsEditButton = new System.Windows.Forms.Button();
            this.SaveNewsEditButton = new System.Windows.Forms.Button();
            this.NewSourceURLLabel = new System.Windows.Forms.Label();
            this.NewSourceNameLabel = new System.Windows.Forms.Label();
            this.NewSourceURLText = new System.Windows.Forms.TextBox();
            this.NewSourceNameText = new System.Windows.Forms.TextBox();
            this.ReorderNewsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AllTheSources)).BeginInit();
            this.NewsSourceSelectGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditNewsButton
            // 
            this.EditNewsButton.Location = new System.Drawing.Point(672, 38);
            this.EditNewsButton.Name = "EditNewsButton";
            this.EditNewsButton.Size = new System.Drawing.Size(75, 23);
            this.EditNewsButton.TabIndex = 0;
            this.EditNewsButton.Text = "Edit";
            this.EditNewsButton.UseVisualStyleBackColor = true;
            this.EditNewsButton.Click += new System.EventHandler(this.EditSelectedSource);
            // 
            // DeleteNewsButton
            // 
            this.DeleteNewsButton.Location = new System.Drawing.Point(672, 80);
            this.DeleteNewsButton.Name = "DeleteNewsButton";
            this.DeleteNewsButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteNewsButton.TabIndex = 1;
            this.DeleteNewsButton.Text = "Delete";
            this.DeleteNewsButton.UseVisualStyleBackColor = true;
            this.DeleteNewsButton.Click += new System.EventHandler(this.DeleteSelectedNewsSources);
            // 
            // SaveChanges
            // 
            this.SaveChanges.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveChanges.Location = new System.Drawing.Point(143, 491);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(75, 23);
            this.SaveChanges.TabIndex = 2;
            this.SaveChanges.Text = "OK";
            this.SaveChanges.UseVisualStyleBackColor = true;
            // 
            // DiscardChanges
            // 
            this.DiscardChanges.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DiscardChanges.Location = new System.Drawing.Point(445, 491);
            this.DiscardChanges.Name = "DiscardChanges";
            this.DiscardChanges.Size = new System.Drawing.Size(75, 23);
            this.DiscardChanges.TabIndex = 3;
            this.DiscardChanges.Text = "Cancel";
            this.DiscardChanges.UseVisualStyleBackColor = true;
            // 
            // AllTheSources
            // 
            this.AllTheSources.AllowUserToAddRows = false;
            this.AllTheSources.AllowUserToDeleteRows = false;
            this.AllTheSources.AllowUserToResizeRows = false;
            this.AllTheSources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllTheSources.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SourceNameToEdit,
            this.SourceURLToEdit});
            this.AllTheSources.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.AllTheSources.Location = new System.Drawing.Point(35, 38);
            this.AllTheSources.Name = "AllTheSources";
            this.AllTheSources.RowTemplate.Height = 24;
            this.AllTheSources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AllTheSources.Size = new System.Drawing.Size(615, 441);
            this.AllTheSources.TabIndex = 4;
            // 
            // SourceNameToEdit
            // 
            this.SourceNameToEdit.HeaderText = "Source Name";
            this.SourceNameToEdit.Name = "SourceNameToEdit";
            this.SourceNameToEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SourceURLToEdit
            // 
            this.SourceURLToEdit.HeaderText = "Source RSS URL";
            this.SourceURLToEdit.Name = "SourceURLToEdit";
            this.SourceURLToEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NewsSourceSelectGroupBox
            // 
            this.NewsSourceSelectGroupBox.Controls.Add(this.FinishReorderingButton);
            this.NewsSourceSelectGroupBox.Controls.Add(this.MoveToLastPositionButton);
            this.NewsSourceSelectGroupBox.Controls.Add(this.MoveToFirstPositionButton);
            this.NewsSourceSelectGroupBox.Controls.Add(this.MoveDownOnePositionButton);
            this.NewsSourceSelectGroupBox.Controls.Add(this.MoveUpOnePositionButton);
            this.NewsSourceSelectGroupBox.Controls.Add(this.DiscardNewsEditButton);
            this.NewsSourceSelectGroupBox.Controls.Add(this.SaveNewsEditButton);
            this.NewsSourceSelectGroupBox.Controls.Add(this.NewSourceURLLabel);
            this.NewsSourceSelectGroupBox.Controls.Add(this.NewSourceNameLabel);
            this.NewsSourceSelectGroupBox.Controls.Add(this.NewSourceURLText);
            this.NewsSourceSelectGroupBox.Controls.Add(this.NewSourceNameText);
            this.NewsSourceSelectGroupBox.Controls.Add(this.ReorderNewsButton);
            this.NewsSourceSelectGroupBox.Location = new System.Drawing.Point(27, 12);
            this.NewsSourceSelectGroupBox.Name = "NewsSourceSelectGroupBox";
            this.NewsSourceSelectGroupBox.Size = new System.Drawing.Size(909, 473);
            this.NewsSourceSelectGroupBox.TabIndex = 5;
            this.NewsSourceSelectGroupBox.TabStop = false;
            this.NewsSourceSelectGroupBox.Text = "Select the news source to edit, delete or reorder";
            // 
            // FinishReorderingButton
            // 
            this.FinishReorderingButton.Enabled = false;
            this.FinishReorderingButton.Location = new System.Drawing.Point(645, 441);
            this.FinishReorderingButton.Name = "FinishReorderingButton";
            this.FinishReorderingButton.Size = new System.Drawing.Size(245, 23);
            this.FinishReorderingButton.TabIndex = 11;
            this.FinishReorderingButton.Text = "Done";
            this.FinishReorderingButton.UseVisualStyleBackColor = true;
            this.FinishReorderingButton.Click += new System.EventHandler(this.FinishReorderingSelectedNewsSource);
            // 
            // MoveToLastPositionButton
            // 
            this.MoveToLastPositionButton.Enabled = false;
            this.MoveToLastPositionButton.Location = new System.Drawing.Point(775, 408);
            this.MoveToLastPositionButton.Name = "MoveToLastPositionButton";
            this.MoveToLastPositionButton.Size = new System.Drawing.Size(115, 23);
            this.MoveToLastPositionButton.TabIndex = 10;
            this.MoveToLastPositionButton.Text = "Move to last";
            this.MoveToLastPositionButton.UseVisualStyleBackColor = true;
            this.MoveToLastPositionButton.Click += new System.EventHandler(this.MoveSelectedSourceToLastPosition);
            // 
            // MoveToFirstPositionButton
            // 
            this.MoveToFirstPositionButton.Enabled = false;
            this.MoveToFirstPositionButton.Location = new System.Drawing.Point(645, 408);
            this.MoveToFirstPositionButton.Name = "MoveToFirstPositionButton";
            this.MoveToFirstPositionButton.Size = new System.Drawing.Size(115, 23);
            this.MoveToFirstPositionButton.TabIndex = 9;
            this.MoveToFirstPositionButton.Text = "Move to first";
            this.MoveToFirstPositionButton.UseVisualStyleBackColor = true;
            this.MoveToFirstPositionButton.Click += new System.EventHandler(this.MoveSelectedSourceToFirstPosition);
            // 
            // MoveDownOnePositionButton
            // 
            this.MoveDownOnePositionButton.Enabled = false;
            this.MoveDownOnePositionButton.Location = new System.Drawing.Point(775, 366);
            this.MoveDownOnePositionButton.Name = "MoveDownOnePositionButton";
            this.MoveDownOnePositionButton.Size = new System.Drawing.Size(115, 23);
            this.MoveDownOnePositionButton.TabIndex = 8;
            this.MoveDownOnePositionButton.Text = "Down 1";
            this.MoveDownOnePositionButton.UseVisualStyleBackColor = true;
            this.MoveDownOnePositionButton.Click += new System.EventHandler(this.MoveSelectedSourceDownOnePosition);
            // 
            // MoveUpOnePositionButton
            // 
            this.MoveUpOnePositionButton.Enabled = false;
            this.MoveUpOnePositionButton.Location = new System.Drawing.Point(645, 366);
            this.MoveUpOnePositionButton.Name = "MoveUpOnePositionButton";
            this.MoveUpOnePositionButton.Size = new System.Drawing.Size(115, 23);
            this.MoveUpOnePositionButton.TabIndex = 7;
            this.MoveUpOnePositionButton.Text = "Up 1";
            this.MoveUpOnePositionButton.UseVisualStyleBackColor = true;
            this.MoveUpOnePositionButton.Click += new System.EventHandler(this.MoveSelectedSourceUpOnePosition);
            // 
            // DiscardNewsEditButton
            // 
            this.DiscardNewsEditButton.Enabled = false;
            this.DiscardNewsEditButton.Location = new System.Drawing.Point(806, 292);
            this.DiscardNewsEditButton.Name = "DiscardNewsEditButton";
            this.DiscardNewsEditButton.Size = new System.Drawing.Size(75, 23);
            this.DiscardNewsEditButton.TabIndex = 6;
            this.DiscardNewsEditButton.Text = "Discard";
            this.DiscardNewsEditButton.UseVisualStyleBackColor = true;
            this.DiscardNewsEditButton.Click += new System.EventHandler(this.DiscardEditingChanges);
            // 
            // SaveNewsEditButton
            // 
            this.SaveNewsEditButton.Enabled = false;
            this.SaveNewsEditButton.Location = new System.Drawing.Point(645, 292);
            this.SaveNewsEditButton.Name = "SaveNewsEditButton";
            this.SaveNewsEditButton.Size = new System.Drawing.Size(75, 23);
            this.SaveNewsEditButton.TabIndex = 5;
            this.SaveNewsEditButton.Text = "Save";
            this.SaveNewsEditButton.UseVisualStyleBackColor = true;
            this.SaveNewsEditButton.Click += new System.EventHandler(this.SaveEditChanges);
            // 
            // NewSourceURLLabel
            // 
            this.NewSourceURLLabel.AutoSize = true;
            this.NewSourceURLLabel.Enabled = false;
            this.NewSourceURLLabel.Location = new System.Drawing.Point(642, 230);
            this.NewSourceURLLabel.Name = "NewSourceURLLabel";
            this.NewSourceURLLabel.Size = new System.Drawing.Size(118, 17);
            this.NewSourceURLLabel.TabIndex = 4;
            this.NewSourceURLLabel.Text = "New source URL:";
            // 
            // NewSourceNameLabel
            // 
            this.NewSourceNameLabel.AutoSize = true;
            this.NewSourceNameLabel.Enabled = false;
            this.NewSourceNameLabel.Location = new System.Drawing.Point(642, 178);
            this.NewSourceNameLabel.Name = "NewSourceNameLabel";
            this.NewSourceNameLabel.Size = new System.Drawing.Size(125, 17);
            this.NewSourceNameLabel.TabIndex = 3;
            this.NewSourceNameLabel.Text = "New source name:";
            // 
            // NewSourceURLText
            // 
            this.NewSourceURLText.Enabled = false;
            this.NewSourceURLText.Location = new System.Drawing.Point(645, 250);
            this.NewSourceURLText.Name = "NewSourceURLText";
            this.NewSourceURLText.Size = new System.Drawing.Size(236, 22);
            this.NewSourceURLText.TabIndex = 2;
            // 
            // NewSourceNameText
            // 
            this.NewSourceNameText.Enabled = false;
            this.NewSourceNameText.Location = new System.Drawing.Point(645, 198);
            this.NewSourceNameText.Name = "NewSourceNameText";
            this.NewSourceNameText.Size = new System.Drawing.Size(236, 22);
            this.NewSourceNameText.TabIndex = 1;
            // 
            // ReorderNewsButton
            // 
            this.ReorderNewsButton.Location = new System.Drawing.Point(645, 110);
            this.ReorderNewsButton.Name = "ReorderNewsButton";
            this.ReorderNewsButton.Size = new System.Drawing.Size(75, 23);
            this.ReorderNewsButton.TabIndex = 0;
            this.ReorderNewsButton.Text = "Reorder";
            this.ReorderNewsButton.UseVisualStyleBackColor = true;
            this.ReorderNewsButton.Click += new System.EventHandler(this.ReorderSelectedNewsSources);
            // 
            // EditSourcesWindow
            // 
            this.AcceptButton = this.SaveChanges;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.DiscardChanges;
            this.ClientSize = new System.Drawing.Size(954, 526);
            this.ControlBox = false;
            this.Controls.Add(this.DeleteNewsButton);
            this.Controls.Add(this.EditNewsButton);
            this.Controls.Add(this.AllTheSources);
            this.Controls.Add(this.NewsSourceSelectGroupBox);
            this.Controls.Add(this.DiscardChanges);
            this.Controls.Add(this.SaveChanges);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSourcesWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit News Sources";
            ((System.ComponentModel.ISupportInitialize)(this.AllTheSources)).EndInit();
            this.NewsSourceSelectGroupBox.ResumeLayout(false);
            this.NewsSourceSelectGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EditNewsButton;
        private System.Windows.Forms.Button DeleteNewsButton;
        private System.Windows.Forms.Button SaveChanges;
        private System.Windows.Forms.Button DiscardChanges;
        private System.Windows.Forms.DataGridView AllTheSources;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceNameToEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceURLToEdit;
        private System.Windows.Forms.GroupBox NewsSourceSelectGroupBox;
        private System.Windows.Forms.Button ReorderNewsButton;
        private System.Windows.Forms.Label NewSourceURLLabel;
        private System.Windows.Forms.Label NewSourceNameLabel;
        private System.Windows.Forms.TextBox NewSourceURLText;
        private System.Windows.Forms.TextBox NewSourceNameText;
        private System.Windows.Forms.Button DiscardNewsEditButton;
        private System.Windows.Forms.Button SaveNewsEditButton;
        private System.Windows.Forms.Button MoveToLastPositionButton;
        private System.Windows.Forms.Button MoveToFirstPositionButton;
        private System.Windows.Forms.Button MoveDownOnePositionButton;
        private System.Windows.Forms.Button MoveUpOnePositionButton;
        private System.Windows.Forms.Button FinishReorderingButton;
    }
}