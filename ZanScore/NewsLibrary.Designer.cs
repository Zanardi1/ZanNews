namespace ZanScore
{
    partial class NewsLibrary
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
            this.CategoryListBox = new System.Windows.Forms.ListBox();
            this.NewsSourceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewsLibrarySourcesView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.NewsLibrarySourcesView)).BeginInit();
            this.SuspendLayout();
            // 
            // CategoryListBox
            // 
            this.CategoryListBox.FormattingEnabled = true;
            this.CategoryListBox.ItemHeight = 16;
            this.CategoryListBox.Items.AddRange(new object[] {
            "National & World News",
            "Sports",
            "Gaming",
            "Lifestyle",
            "Music",
            "Science",
            "Technology",
            "Politics",
            "Entertainment",
            "Business"});
            this.CategoryListBox.Location = new System.Drawing.Point(12, 12);
            this.CategoryListBox.Name = "CategoryListBox";
            this.CategoryListBox.Size = new System.Drawing.Size(191, 420);
            this.CategoryListBox.TabIndex = 1;
            this.CategoryListBox.SelectedIndexChanged += new System.EventHandler(this.ChangeNewsSourcesCategory);
            // 
            // NewsSourceName
            // 
            this.NewsSourceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NewsSourceName.HeaderText = "News Source Name";
            this.NewsSourceName.Name = "NewsSourceName";
            this.NewsSourceName.ReadOnly = true;
            this.NewsSourceName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // NewsLibrarySourcesView
            // 
            this.NewsLibrarySourcesView.AllowUserToAddRows = false;
            this.NewsLibrarySourcesView.AllowUserToDeleteRows = false;
            this.NewsLibrarySourcesView.AllowUserToResizeColumns = false;
            this.NewsLibrarySourcesView.AllowUserToResizeRows = false;
            this.NewsLibrarySourcesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NewsLibrarySourcesView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NewsSourceName});
            this.NewsLibrarySourcesView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.NewsLibrarySourcesView.Location = new System.Drawing.Point(231, 12);
            this.NewsLibrarySourcesView.MultiSelect = false;
            this.NewsLibrarySourcesView.Name = "NewsLibrarySourcesView";
            this.NewsLibrarySourcesView.ReadOnly = true;
            this.NewsLibrarySourcesView.RowTemplate.Height = 24;
            this.NewsLibrarySourcesView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NewsLibrarySourcesView.Size = new System.Drawing.Size(453, 420);
            this.NewsLibrarySourcesView.TabIndex = 0;
            this.NewsLibrarySourcesView.DoubleClick += new System.EventHandler(this.VisitTheSelectedSource);
            // 
            // NewsLibrary
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(706, 450);
            this.Controls.Add(this.CategoryListBox);
            this.Controls.Add(this.NewsLibrarySourcesView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewsLibrary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NewsLibrary";
            ((System.ComponentModel.ISupportInitialize)(this.NewsLibrarySourcesView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox CategoryListBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsSourceName;
        public System.Windows.Forms.DataGridView NewsLibrarySourcesView;
    }
}