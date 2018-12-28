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
            this.SortNewsButton = new System.Windows.Forms.Button();
            this.NewSourceNameText = new System.Windows.Forms.TextBox();
            this.NewSourceURLText = new System.Windows.Forms.TextBox();
            this.NewSourceNameLabel = new System.Windows.Forms.Label();
            this.NewSourceURLLabel = new System.Windows.Forms.Label();
            this.SaveNewsEditButton = new System.Windows.Forms.Button();
            this.DiscardNewsEditButton = new System.Windows.Forms.Button();
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
            this.SaveChanges.Location = new System.Drawing.Point(143, 461);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(75, 23);
            this.SaveChanges.TabIndex = 2;
            this.SaveChanges.Text = "OK";
            this.SaveChanges.UseVisualStyleBackColor = true;
            // 
            // DiscardChanges
            // 
            this.DiscardChanges.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DiscardChanges.Location = new System.Drawing.Point(445, 461);
            this.DiscardChanges.Name = "DiscardChanges";
            this.DiscardChanges.Size = new System.Drawing.Size(75, 23);
            this.DiscardChanges.TabIndex = 3;
            this.DiscardChanges.Text = "Cancel";
            this.DiscardChanges.UseVisualStyleBackColor = true;
            // 
            // AllTheSources
            // 
            this.AllTheSources.AllowUserToAddRows = false;
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
            this.AllTheSources.Size = new System.Drawing.Size(615, 411);
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
            this.NewsSourceSelectGroupBox.Controls.Add(this.DiscardNewsEditButton);
            this.NewsSourceSelectGroupBox.Controls.Add(this.SaveNewsEditButton);
            this.NewsSourceSelectGroupBox.Controls.Add(this.NewSourceURLLabel);
            this.NewsSourceSelectGroupBox.Controls.Add(this.NewSourceNameLabel);
            this.NewsSourceSelectGroupBox.Controls.Add(this.NewSourceURLText);
            this.NewsSourceSelectGroupBox.Controls.Add(this.NewSourceNameText);
            this.NewsSourceSelectGroupBox.Controls.Add(this.SortNewsButton);
            this.NewsSourceSelectGroupBox.Location = new System.Drawing.Point(27, 12);
            this.NewsSourceSelectGroupBox.Name = "NewsSourceSelectGroupBox";
            this.NewsSourceSelectGroupBox.Size = new System.Drawing.Size(909, 443);
            this.NewsSourceSelectGroupBox.TabIndex = 5;
            this.NewsSourceSelectGroupBox.TabStop = false;
            this.NewsSourceSelectGroupBox.Text = "Select the news source to edit or delete";
            // 
            // SortNewsButton
            // 
            this.SortNewsButton.Location = new System.Drawing.Point(645, 110);
            this.SortNewsButton.Name = "SortNewsButton";
            this.SortNewsButton.Size = new System.Drawing.Size(75, 23);
            this.SortNewsButton.TabIndex = 0;
            this.SortNewsButton.Text = "Sort";
            this.SortNewsButton.UseVisualStyleBackColor = true;
            // 
            // NewSourceNameText
            // 
            this.NewSourceNameText.Enabled = false;
            this.NewSourceNameText.Location = new System.Drawing.Point(645, 198);
            this.NewSourceNameText.Name = "NewSourceNameText";
            this.NewSourceNameText.Size = new System.Drawing.Size(236, 22);
            this.NewSourceNameText.TabIndex = 1;
            // 
            // NewSourceURLText
            // 
            this.NewSourceURLText.Enabled = false;
            this.NewSourceURLText.Location = new System.Drawing.Point(645, 278);
            this.NewSourceURLText.Name = "NewSourceURLText";
            this.NewSourceURLText.Size = new System.Drawing.Size(236, 22);
            this.NewSourceURLText.TabIndex = 2;
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
            // NewSourceURLLabel
            // 
            this.NewSourceURLLabel.AutoSize = true;
            this.NewSourceURLLabel.Enabled = false;
            this.NewSourceURLLabel.Location = new System.Drawing.Point(642, 258);
            this.NewSourceURLLabel.Name = "NewSourceURLLabel";
            this.NewSourceURLLabel.Size = new System.Drawing.Size(118, 17);
            this.NewSourceURLLabel.TabIndex = 4;
            this.NewSourceURLLabel.Text = "New source URL:";
            // 
            // SaveNewsEditButton
            // 
            this.SaveNewsEditButton.Enabled = false;
            this.SaveNewsEditButton.Location = new System.Drawing.Point(645, 320);
            this.SaveNewsEditButton.Name = "SaveNewsEditButton";
            this.SaveNewsEditButton.Size = new System.Drawing.Size(75, 23);
            this.SaveNewsEditButton.TabIndex = 5;
            this.SaveNewsEditButton.Text = "Save";
            this.SaveNewsEditButton.UseVisualStyleBackColor = true;
            // 
            // DiscardNewsEditButton
            // 
            this.DiscardNewsEditButton.Enabled = false;
            this.DiscardNewsEditButton.Location = new System.Drawing.Point(806, 320);
            this.DiscardNewsEditButton.Name = "DiscardNewsEditButton";
            this.DiscardNewsEditButton.Size = new System.Drawing.Size(75, 23);
            this.DiscardNewsEditButton.TabIndex = 6;
            this.DiscardNewsEditButton.Text = "Discard";
            this.DiscardNewsEditButton.UseVisualStyleBackColor = true;
            // 
            // EditSourcesWindow
            // 
            this.AcceptButton = this.SaveChanges;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DiscardChanges;
            this.ClientSize = new System.Drawing.Size(964, 542);
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
        private System.Windows.Forms.Button SortNewsButton;
        private System.Windows.Forms.Label NewSourceURLLabel;
        private System.Windows.Forms.Label NewSourceNameLabel;
        private System.Windows.Forms.TextBox NewSourceURLText;
        private System.Windows.Forms.TextBox NewSourceNameText;
        private System.Windows.Forms.Button DiscardNewsEditButton;
        private System.Windows.Forms.Button SaveNewsEditButton;
    }
}