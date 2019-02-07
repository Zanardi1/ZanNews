namespace ZanScore
{
    partial class AddSourceWindow
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
            this.SourceNameText = new System.Windows.Forms.TextBox();
            this.SourceURLText = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.URLRSSLabel = new System.Windows.Forms.Label();
            this.NewDataSource = new System.Windows.Forms.GroupBox();
            this.SaveChanges = new System.Windows.Forms.Button();
            this.DiscardChanges = new System.Windows.Forms.Button();
            this.NewDataSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourceNameText
            // 
            this.SourceNameText.Location = new System.Drawing.Point(150, 38);
            this.SourceNameText.Name = "SourceNameText";
            this.SourceNameText.Size = new System.Drawing.Size(381, 22);
            this.SourceNameText.TabIndex = 0;
            // 
            // SourceURLText
            // 
            this.SourceURLText.Location = new System.Drawing.Point(150, 89);
            this.SourceURLText.Name = "SourceURLText";
            this.SourceURLText.Size = new System.Drawing.Size(381, 22);
            this.SourceURLText.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(10, 41);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(98, 17);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Source Name:";
            // 
            // URLRSSLabel
            // 
            this.URLRSSLabel.AutoSize = true;
            this.URLRSSLabel.Location = new System.Drawing.Point(10, 94);
            this.URLRSSLabel.Name = "URLRSSLabel";
            this.URLRSSLabel.Size = new System.Drawing.Size(134, 17);
            this.URLRSSLabel.TabIndex = 3;
            this.URLRSSLabel.Text = "URL of the RSS file:";
            // 
            // NewDataSource
            // 
            this.NewDataSource.Controls.Add(this.SourceNameText);
            this.NewDataSource.Controls.Add(this.URLRSSLabel);
            this.NewDataSource.Controls.Add(this.SourceURLText);
            this.NewDataSource.Controls.Add(this.NameLabel);
            this.NewDataSource.Location = new System.Drawing.Point(12, 12);
            this.NewDataSource.Name = "NewDataSource";
            this.NewDataSource.Size = new System.Drawing.Size(553, 127);
            this.NewDataSource.TabIndex = 4;
            this.NewDataSource.TabStop = false;
            this.NewDataSource.Text = "Data for the new source";
            // 
            // SaveChanges
            // 
            this.SaveChanges.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveChanges.Location = new System.Drawing.Point(112, 145);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(75, 23);
            this.SaveChanges.TabIndex = 5;
            this.SaveChanges.Text = "OK";
            this.SaveChanges.UseVisualStyleBackColor = true;
            this.SaveChanges.Click += new System.EventHandler(this.SaveNewData);
            // 
            // DiscardChanges
            // 
            this.DiscardChanges.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DiscardChanges.Location = new System.Drawing.Point(360, 145);
            this.DiscardChanges.Name = "DiscardChanges";
            this.DiscardChanges.Size = new System.Drawing.Size(75, 23);
            this.DiscardChanges.TabIndex = 6;
            this.DiscardChanges.Text = "Cancel";
            this.DiscardChanges.UseVisualStyleBackColor = true;
            // 
            // AddSourceWindow
            // 
            this.AcceptButton = this.SaveChanges;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.DiscardChanges;
            this.ClientSize = new System.Drawing.Size(579, 181);
            this.ControlBox = false;
            this.Controls.Add(this.DiscardChanges);
            this.Controls.Add(this.SaveChanges);
            this.Controls.Add(this.NewDataSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSourceWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add a news source";
            this.NewDataSource.ResumeLayout(false);
            this.NewDataSource.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label URLRSSLabel;
        private System.Windows.Forms.GroupBox NewDataSource;
        private System.Windows.Forms.Button SaveChanges;
        private System.Windows.Forms.Button DiscardChanges;
        public System.Windows.Forms.TextBox SourceNameText;
        public System.Windows.Forms.TextBox SourceURLText;
    }
}