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
            ((System.ComponentModel.ISupportInitialize)(this.AllTheSources)).BeginInit();
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
            this.AllTheSources.Location = new System.Drawing.Point(35, 38);
            this.AllTheSources.Name = "AllTheSources";
            this.AllTheSources.RowTemplate.Height = 24;
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
            this.NewsSourceSelectGroupBox.Location = new System.Drawing.Point(27, 12);
            this.NewsSourceSelectGroupBox.Name = "NewsSourceSelectGroupBox";
            this.NewsSourceSelectGroupBox.Size = new System.Drawing.Size(738, 443);
            this.NewsSourceSelectGroupBox.TabIndex = 5;
            this.NewsSourceSelectGroupBox.TabStop = false;
            this.NewsSourceSelectGroupBox.Text = "Select the news source to edit or delete";
            // 
            // EditSourcesWindow
            // 
            this.AcceptButton = this.SaveChanges;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DiscardChanges;
            this.ClientSize = new System.Drawing.Size(800, 542);
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
    }
}