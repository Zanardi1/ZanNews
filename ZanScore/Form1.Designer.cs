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
            this.NewsWebPage = new System.Windows.Forms.WebBrowser();
            this.NewsDetails = new System.Windows.Forms.DataGridView();
            this.News = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewsURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewsHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.DownloadNewsOption = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadFromAllSourcesOption = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadFromSelectedSourcesOption = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageNewsSourcesOption = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewsSourcesOption = new System.Windows.Forms.ToolStripMenuItem();
            this.EditNewsSourcesOption = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsWindowOption = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProgramOption = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.NewsDetails)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewsWebPage
            // 
            this.NewsWebPage.Location = new System.Drawing.Point(495, 50);
            this.NewsWebPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.NewsWebPage.Name = "NewsWebPage";
            this.NewsWebPage.ScriptErrorsSuppressed = true;
            this.NewsWebPage.Size = new System.Drawing.Size(1033, 617);
            this.NewsWebPage.TabIndex = 1;
            // 
            // NewsDetails
            // 
            this.NewsDetails.AllowUserToAddRows = false;
            this.NewsDetails.AllowUserToDeleteRows = false;
            this.NewsDetails.AllowUserToResizeRows = false;
            this.NewsDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NewsDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NewsDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.News,
            this.NewsURL,
            this.NewsHeader});
            this.NewsDetails.Location = new System.Drawing.Point(12, 50);
            this.NewsDetails.MultiSelect = false;
            this.NewsDetails.Name = "NewsDetails";
            this.NewsDetails.ReadOnly = true;
            this.NewsDetails.RowTemplate.Height = 24;
            this.NewsDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NewsDetails.Size = new System.Drawing.Size(451, 617);
            this.NewsDetails.TabIndex = 2;
            this.NewsDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LoadNewsURL);
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
            this.DownloadNewsOption,
            this.ManageNewsSourcesOption,
            this.OptionsWindowOption,
            this.AboutProgramOption});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1582, 28);
            this.MainMenu.TabIndex = 4;
            this.MainMenu.Text = "menuStrip1";
            // 
            // DownloadNewsOption
            // 
            this.DownloadNewsOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DownloadFromAllSourcesOption,
            this.DownloadFromSelectedSourcesOption});
            this.DownloadNewsOption.Name = "DownloadNewsOption";
            this.DownloadNewsOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.DownloadNewsOption.Size = new System.Drawing.Size(90, 24);
            this.DownloadNewsOption.Text = "Download";
            // 
            // DownloadFromAllSourcesOption
            // 
            this.DownloadFromAllSourcesOption.Name = "DownloadFromAllSourcesOption";
            this.DownloadFromAllSourcesOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.DownloadFromAllSourcesOption.Size = new System.Drawing.Size(191, 26);
            this.DownloadFromAllSourcesOption.Text = "All";
            this.DownloadFromAllSourcesOption.Click += new System.EventHandler(this.DownloadAllNews);
            // 
            // DownloadFromSelectedSourcesOption
            // 
            this.DownloadFromSelectedSourcesOption.Name = "DownloadFromSelectedSourcesOption";
            this.DownloadFromSelectedSourcesOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.DownloadFromSelectedSourcesOption.Size = new System.Drawing.Size(191, 26);
            this.DownloadFromSelectedSourcesOption.Text = "Selected";
            this.DownloadFromSelectedSourcesOption.Click += new System.EventHandler(this.SelectNewsSources);
            // 
            // ManageNewsSourcesOption
            // 
            this.ManageNewsSourcesOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNewsSourcesOption,
            this.EditNewsSourcesOption});
            this.ManageNewsSourcesOption.Name = "ManageNewsSourcesOption";
            this.ManageNewsSourcesOption.Size = new System.Drawing.Size(112, 24);
            this.ManageNewsSourcesOption.Text = "News Sources";
            // 
            // AddNewsSourcesOption
            // 
            this.AddNewsSourcesOption.Name = "AddNewsSourcesOption";
            this.AddNewsSourcesOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.AddNewsSourcesOption.Size = new System.Drawing.Size(164, 26);
            this.AddNewsSourcesOption.Text = "Add";
            this.AddNewsSourcesOption.Click += new System.EventHandler(this.ShowAddNewsSourcesWindow);
            // 
            // EditNewsSourcesOption
            // 
            this.EditNewsSourcesOption.Name = "EditNewsSourcesOption";
            this.EditNewsSourcesOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.EditNewsSourcesOption.Size = new System.Drawing.Size(164, 26);
            this.EditNewsSourcesOption.Text = "Edit";
            this.EditNewsSourcesOption.Click += new System.EventHandler(this.ShowEditSourcesWindow);
            // 
            // OptionsWindowOption
            // 
            this.OptionsWindowOption.Name = "OptionsWindowOption";
            this.OptionsWindowOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OptionsWindowOption.Size = new System.Drawing.Size(73, 24);
            this.OptionsWindowOption.Text = "Options";
            this.OptionsWindowOption.Click += new System.EventHandler(this.ShowOptionsWindow);
            // 
            // AboutProgramOption
            // 
            this.AboutProgramOption.Name = "AboutProgramOption";
            this.AboutProgramOption.Size = new System.Drawing.Size(62, 24);
            this.AboutProgramOption.Text = "About";
            this.AboutProgramOption.Click += new System.EventHandler(this.ShowAboutBoxWindow);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 703);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.NewsDetails);
            this.Controls.Add(this.NewsWebPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(1600, 750);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZanScore";
            ((System.ComponentModel.ISupportInitialize)(this.NewsDetails)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.WebBrowser NewsWebPage;
        private System.Windows.Forms.DataGridView NewsDetails;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem ManageNewsSourcesOption;
        private System.Windows.Forms.ToolStripMenuItem AddNewsSourcesOption;
        private System.Windows.Forms.ToolStripMenuItem EditNewsSourcesOption;
        private System.Windows.Forms.ToolStripMenuItem DownloadNewsOption;
        private System.Windows.Forms.DataGridViewTextBoxColumn News;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsHeader;
        private System.Windows.Forms.ToolStripMenuItem OptionsWindowOption;
        private System.Windows.Forms.ToolStripMenuItem DownloadFromAllSourcesOption;
        private System.Windows.Forms.ToolStripMenuItem DownloadFromSelectedSourcesOption;
        private System.Windows.Forms.ToolStripMenuItem AboutProgramOption;
    }
}

