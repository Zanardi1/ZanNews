namespace ZanScore
{
    partial class SelectSourcesWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NewsSourcesDataGrid = new System.Windows.Forms.DataGridView();
            this.SelectedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SourceNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaveChanges = new System.Windows.Forms.Button();
            this.DiscardChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NewsSourcesDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // NewsSourcesDataGrid
            // 
            this.NewsSourcesDataGrid.AllowUserToAddRows = false;
            this.NewsSourcesDataGrid.AllowUserToDeleteRows = false;
            this.NewsSourcesDataGrid.AllowUserToResizeRows = false;
            this.NewsSourcesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NewsSourcesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectedColumn,
            this.SourceNameColumn});
            this.NewsSourcesDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.NewsSourcesDataGrid.Location = new System.Drawing.Point(22, 25);
            this.NewsSourcesDataGrid.MultiSelect = false;
            this.NewsSourcesDataGrid.Name = "NewsSourcesDataGrid";
            this.NewsSourcesDataGrid.RowTemplate.Height = 24;
            this.NewsSourcesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NewsSourcesDataGrid.Size = new System.Drawing.Size(346, 367);
            this.NewsSourcesDataGrid.TabIndex = 0;
            // 
            // SelectedColumn
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.NullValue = false;
            this.SelectedColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.SelectedColumn.HeaderText = "Selected";
            this.SelectedColumn.Name = "SelectedColumn";
            this.SelectedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SourceNameColumn
            // 
            this.SourceNameColumn.HeaderText = "Source name";
            this.SourceNameColumn.Name = "SourceNameColumn";
            this.SourceNameColumn.ReadOnly = true;
            this.SourceNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SourceNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SaveChanges
            // 
            this.SaveChanges.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveChanges.Location = new System.Drawing.Point(22, 415);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(75, 23);
            this.SaveChanges.TabIndex = 1;
            this.SaveChanges.Text = "OK";
            this.SaveChanges.UseVisualStyleBackColor = true;
            this.SaveChanges.Click += new System.EventHandler(this.UpdateSelectedSourcesList);
            // 
            // DiscardChanges
            // 
            this.DiscardChanges.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DiscardChanges.Location = new System.Drawing.Point(293, 415);
            this.DiscardChanges.Name = "DiscardChanges";
            this.DiscardChanges.Size = new System.Drawing.Size(75, 23);
            this.DiscardChanges.TabIndex = 2;
            this.DiscardChanges.Text = "Cancel";
            this.DiscardChanges.UseVisualStyleBackColor = true;
            // 
            // SelectSourcesWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(408, 453);
            this.ControlBox = false;
            this.Controls.Add(this.DiscardChanges);
            this.Controls.Add(this.SaveChanges);
            this.Controls.Add(this.NewsSourcesDataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectSourcesWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select News Source(s)";
            this.Shown += new System.EventHandler(this.DisplaySourceNames);
            ((System.ComponentModel.ISupportInitialize)(this.NewsSourcesDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SaveChanges;
        private System.Windows.Forms.Button DiscardChanges;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceNameColumn;
        public System.Windows.Forms.DataGridView NewsSourcesDataGrid;
    }
}