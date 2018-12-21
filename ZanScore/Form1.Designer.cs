namespace ZanScore
{
    partial class Form1
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
            this.wbNewsWebPage = new System.Windows.Forms.WebBrowser();
            this.dgNewsDetails = new System.Windows.Forms.DataGridView();
            this.News = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewsURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewsHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadFromAllSources = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadFromSelectedSources = new System.Windows.Forms.ToolStripMenuItem();
            this.newsSourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewsSources = new System.Windows.Forms.ToolStripMenuItem();
            this.EditNewsSources = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgNewsDetails)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbNewsWebPage
            // 
            this.wbNewsWebPage.Location = new System.Drawing.Point(495, 50);
            this.wbNewsWebPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNewsWebPage.Name = "wbNewsWebPage";
            this.wbNewsWebPage.ScriptErrorsSuppressed = true;
            this.wbNewsWebPage.Size = new System.Drawing.Size(1033, 617);
            this.wbNewsWebPage.TabIndex = 1;
            // 
            // dgNewsDetails
            // 
            this.dgNewsDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgNewsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNewsDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.News,
            this.NewsURL,
            this.NewsHeader});
            this.dgNewsDetails.Location = new System.Drawing.Point(12, 50);
            this.dgNewsDetails.MultiSelect = false;
            this.dgNewsDetails.Name = "dgNewsDetails";
            this.dgNewsDetails.ReadOnly = true;
            this.dgNewsDetails.RowTemplate.Height = 24;
            this.dgNewsDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgNewsDetails.Size = new System.Drawing.Size(451, 617);
            this.dgNewsDetails.TabIndex = 2;
            this.dgNewsDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LoadNewsURL);
            // 
            // News
            // 
            this.News.HeaderText = "Title";
            this.News.Name = "News";
            this.News.ReadOnly = true;
            this.News.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NewsURL
            // 
            this.NewsURL.HeaderText = "Link";
            this.NewsURL.Name = "NewsURL";
            this.NewsURL.ReadOnly = true;
            this.NewsURL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NewsHeader
            // 
            this.NewsHeader.HeaderText = "Description";
            this.NewsHeader.Name = "NewsHeader";
            this.NewsHeader.ReadOnly = true;
            this.NewsHeader.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 681);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1582, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.newsSourcesToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.AboutProgram});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1582, 28);
            this.MainMenu.TabIndex = 4;
            this.MainMenu.Text = "menuStrip1";
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DownloadFromAllSources,
            this.DownloadFromSelectedSources});
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.downloadToolStripMenuItem.Text = "Download";
            // 
            // DownloadFromAllSources
            // 
            this.DownloadFromAllSources.Name = "DownloadFromAllSources";
            this.DownloadFromAllSources.Size = new System.Drawing.Size(141, 26);
            this.DownloadFromAllSources.Text = "All";
            this.DownloadFromAllSources.Click += new System.EventHandler(this.DownloadAllNews);
            // 
            // DownloadFromSelectedSources
            // 
            this.DownloadFromSelectedSources.Name = "DownloadFromSelectedSources";
            this.DownloadFromSelectedSources.Size = new System.Drawing.Size(141, 26);
            this.DownloadFromSelectedSources.Text = "Selected";
            this.DownloadFromSelectedSources.Click += new System.EventHandler(this.SelectNewsSources);
            // 
            // newsSourcesToolStripMenuItem
            // 
            this.newsSourcesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNewsSources,
            this.EditNewsSources});
            this.newsSourcesToolStripMenuItem.Name = "newsSourcesToolStripMenuItem";
            this.newsSourcesToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.newsSourcesToolStripMenuItem.Text = "News Sources";
            // 
            // AddNewsSources
            // 
            this.AddNewsSources.Name = "AddNewsSources";
            this.AddNewsSources.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.AddNewsSources.Size = new System.Drawing.Size(216, 26);
            this.AddNewsSources.Text = "Add";
            this.AddNewsSources.Click += new System.EventHandler(this.ShowAddNewsSourcesWindow);
            // 
            // EditNewsSources
            // 
            this.EditNewsSources.Name = "EditNewsSources";
            this.EditNewsSources.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.EditNewsSources.Size = new System.Drawing.Size(216, 26);
            this.EditNewsSources.Text = "Edit";
            this.EditNewsSources.Click += new System.EventHandler(this.ShowEditSourcesWindow);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.ShowOptionsWindow);
            // 
            // AboutProgram
            // 
            this.AboutProgram.Name = "AboutProgram";
            this.AboutProgram.Size = new System.Drawing.Size(62, 24);
            this.AboutProgram.Text = "About";
            this.AboutProgram.Click += new System.EventHandler(this.ShowAboutBoxWindow);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 703);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.dgNewsDetails);
            this.Controls.Add(this.wbNewsWebPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(1600, 750);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZanScore";
            ((System.ComponentModel.ISupportInitialize)(this.dgNewsDetails)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.WebBrowser wbNewsWebPage;
        private System.Windows.Forms.DataGridView dgNewsDetails;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem newsSourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddNewsSources;
        private System.Windows.Forms.ToolStripMenuItem EditNewsSources;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn News;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsHeader;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownloadFromAllSources;
        private System.Windows.Forms.ToolStripMenuItem DownloadFromSelectedSources;
        private System.Windows.Forms.ToolStripMenuItem AboutProgram;
    }
}

