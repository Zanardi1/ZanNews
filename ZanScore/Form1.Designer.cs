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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.NewsWebPage = new System.Windows.Forms.WebBrowser();
            this.NewsDetailsGrid = new System.Windows.Forms.DataGridView();
            this.NewsChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewsTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewsDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DownloadProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.DownloadNewsOption = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadFromAllSourcesOption = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadFromSelectedSourcesOption = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageNewsSourcesOption = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewsSourcesOption = new System.Windows.Forms.ToolStripMenuItem();
            this.EditNewsSourcesOption = new System.Windows.Forms.ToolStripMenuItem();
            this.AccessNewsLibraryOption = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsWindowOption = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutProgramOption = new System.Windows.Forms.ToolStripMenuItem();
            this.MinimizeToSystray = new System.Windows.Forms.NotifyIcon(this.components);
            this.DownloadNewsTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NewsDetailsGrid)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewsWebPage
            // 
            this.NewsWebPage.AllowWebBrowserDrop = false;
            this.NewsWebPage.Location = new System.Drawing.Point(495, 50);
            this.NewsWebPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.NewsWebPage.Name = "NewsWebPage";
            this.NewsWebPage.ScriptErrorsSuppressed = true;
            this.NewsWebPage.Size = new System.Drawing.Size(675, 429);
            this.NewsWebPage.TabIndex = 1;
            // 
            // NewsDetailsGrid
            // 
            this.NewsDetailsGrid.AllowUserToAddRows = false;
            this.NewsDetailsGrid.AllowUserToDeleteRows = false;
            this.NewsDetailsGrid.AllowUserToResizeRows = false;
            this.NewsDetailsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NewsDetailsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NewsDetailsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NewsChannel,
            this.NewsTitle,
            this.NewsDescription});
            this.NewsDetailsGrid.Location = new System.Drawing.Point(12, 50);
            this.NewsDetailsGrid.MultiSelect = false;
            this.NewsDetailsGrid.Name = "NewsDetailsGrid";
            this.NewsDetailsGrid.ReadOnly = true;
            this.NewsDetailsGrid.RowTemplate.Height = 24;
            this.NewsDetailsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NewsDetailsGrid.Size = new System.Drawing.Size(451, 429);
            this.NewsDetailsGrid.TabIndex = 2;
            this.NewsDetailsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LoadNewsURL);
            // 
            // NewsChannel
            // 
            this.NewsChannel.HeaderText = "Channel";
            this.NewsChannel.Name = "NewsChannel";
            this.NewsChannel.ReadOnly = true;
            this.NewsChannel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NewsTitle
            // 
            this.NewsTitle.HeaderText = "Title";
            this.NewsTitle.Name = "NewsTitle";
            this.NewsTitle.ReadOnly = true;
            this.NewsTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NewsDescription
            // 
            this.NewsDescription.HeaderText = "Description";
            this.NewsDescription.Name = "NewsDescription";
            this.NewsDescription.ReadOnly = true;
            this.NewsDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.DownloadProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 492);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1182, 24);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = false;
            this.StatusLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(300, 19);
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(200, 18);
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
            this.MainMenu.Size = new System.Drawing.Size(1182, 28);
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
            this.DownloadNewsOption.MouseEnter += new System.EventHandler(this.DisplayDownloadHelpMessage);
            // 
            // DownloadFromAllSourcesOption
            // 
            this.DownloadFromAllSourcesOption.Name = "DownloadFromAllSourcesOption";
            this.DownloadFromAllSourcesOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.DownloadFromAllSourcesOption.Size = new System.Drawing.Size(191, 26);
            this.DownloadFromAllSourcesOption.Text = "All";
            this.DownloadFromAllSourcesOption.Click += new System.EventHandler(this.DownloadAllNews);
            this.DownloadFromAllSourcesOption.MouseEnter += new System.EventHandler(this.DisplayAllHelpMessage);
            // 
            // DownloadFromSelectedSourcesOption
            // 
            this.DownloadFromSelectedSourcesOption.Name = "DownloadFromSelectedSourcesOption";
            this.DownloadFromSelectedSourcesOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.DownloadFromSelectedSourcesOption.Size = new System.Drawing.Size(191, 26);
            this.DownloadFromSelectedSourcesOption.Text = "Selected";
            this.DownloadFromSelectedSourcesOption.Click += new System.EventHandler(this.SelectNewsSources);
            this.DownloadFromSelectedSourcesOption.MouseEnter += new System.EventHandler(this.DisplaySelectedHelpMessage);
            // 
            // ManageNewsSourcesOption
            // 
            this.ManageNewsSourcesOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNewsSourcesOption,
            this.EditNewsSourcesOption,
            this.AccessNewsLibraryOption});
            this.ManageNewsSourcesOption.Name = "ManageNewsSourcesOption";
            this.ManageNewsSourcesOption.Size = new System.Drawing.Size(112, 24);
            this.ManageNewsSourcesOption.Text = "News Sources";
            this.ManageNewsSourcesOption.MouseEnter += new System.EventHandler(this.DisplayNewsSourcesHelpMessage);
            // 
            // AddNewsSourcesOption
            // 
            this.AddNewsSourcesOption.Name = "AddNewsSourcesOption";
            this.AddNewsSourcesOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.AddNewsSourcesOption.Size = new System.Drawing.Size(222, 26);
            this.AddNewsSourcesOption.Text = "Add";
            this.AddNewsSourcesOption.Click += new System.EventHandler(this.ShowAddNewsSourcesWindow);
            this.AddNewsSourcesOption.MouseEnter += new System.EventHandler(this.DisplayAddHelpMessage);
            // 
            // EditNewsSourcesOption
            // 
            this.EditNewsSourcesOption.Name = "EditNewsSourcesOption";
            this.EditNewsSourcesOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.EditNewsSourcesOption.Size = new System.Drawing.Size(222, 26);
            this.EditNewsSourcesOption.Text = "Edit";
            this.EditNewsSourcesOption.Click += new System.EventHandler(this.ShowEditSourcesWindow);
            this.EditNewsSourcesOption.MouseEnter += new System.EventHandler(this.DisplayEditHelpMessage);
            // 
            // AccessNewsLibraryOption
            // 
            this.AccessNewsLibraryOption.Name = "AccessNewsLibraryOption";
            this.AccessNewsLibraryOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.AccessNewsLibraryOption.Size = new System.Drawing.Size(222, 26);
            this.AccessNewsLibraryOption.Text = "News Library";
            this.AccessNewsLibraryOption.Click += new System.EventHandler(this.ShowNewsLibraryWindow);
            // 
            // OptionsWindowOption
            // 
            this.OptionsWindowOption.Name = "OptionsWindowOption";
            this.OptionsWindowOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OptionsWindowOption.Size = new System.Drawing.Size(73, 24);
            this.OptionsWindowOption.Text = "Options";
            this.OptionsWindowOption.Click += new System.EventHandler(this.ShowOptionsWindow);
            this.OptionsWindowOption.MouseEnter += new System.EventHandler(this.DisplayOptionsHelpMessage);
            // 
            // AboutProgramOption
            // 
            this.AboutProgramOption.Name = "AboutProgramOption";
            this.AboutProgramOption.Size = new System.Drawing.Size(62, 24);
            this.AboutProgramOption.Text = "About";
            this.AboutProgramOption.Click += new System.EventHandler(this.ShowAboutBoxWindow);
            this.AboutProgramOption.MouseEnter += new System.EventHandler(this.DisplayAboutBoxHelpMessage);
            // 
            // MinimizeToSystray
            // 
            this.MinimizeToSystray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.MinimizeToSystray.BalloonTipText = "Application will run in the background";
            this.MinimizeToSystray.BalloonTipTitle = "Application Minimized";
            this.MinimizeToSystray.Icon = ((System.Drawing.Icon)(resources.GetObject("MinimizeToSystray.Icon")));
            this.MinimizeToSystray.Text = "Notification";
            this.MinimizeToSystray.Click += new System.EventHandler(this.RestoreApplication);
            // 
            // DownloadNewsTimer
            // 
            this.DownloadNewsTimer.Tick += new System.EventHandler(this.AutomaticalDownloadEngine);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1182, 516);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.NewsDetailsGrid);
            this.Controls.Add(this.NewsWebPage);
            this.MinimumSize = new System.Drawing.Size(1200, 563);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZanNews";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Bye);
            this.Shown += new System.EventHandler(this.StuffAfterFormIsShown);
            this.ResizeBegin += new System.EventHandler(this.BeginResize);
            this.ResizeEnd += new System.EventHandler(this.EndResize);
            this.Resize += new System.EventHandler(this.ResizeEngine);
            ((System.ComponentModel.ISupportInitialize)(this.NewsDetailsGrid)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView NewsDetailsGrid;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem ManageNewsSourcesOption;
        private System.Windows.Forms.ToolStripMenuItem AddNewsSourcesOption;
        private System.Windows.Forms.ToolStripMenuItem EditNewsSourcesOption;
        private System.Windows.Forms.ToolStripMenuItem DownloadNewsOption;
        private System.Windows.Forms.ToolStripMenuItem OptionsWindowOption;
        private System.Windows.Forms.ToolStripMenuItem DownloadFromAllSourcesOption;
        private System.Windows.Forms.ToolStripMenuItem DownloadFromSelectedSourcesOption;
        private System.Windows.Forms.ToolStripMenuItem AboutProgramOption;
        private System.Windows.Forms.ToolStripProgressBar DownloadProgressBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewsDescription;
        private System.Windows.Forms.NotifyIcon MinimizeToSystray;
        public System.Windows.Forms.Timer DownloadNewsTimer;
        private System.Windows.Forms.ToolStripMenuItem AccessNewsLibraryOption;
        public System.Windows.Forms.WebBrowser NewsWebPage;
    }
}

