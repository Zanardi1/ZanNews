using System;
using System.Collections.Generic;
using System.Windows.Forms;

//bug Daca citesc stiri dintr-o sursa din biblioteca predefinita si am activata descarcarea automata a stirilor, apare o exceptie;
//bug Daca citesc stiri dintr-o sursa din biblioteca predefinita si apas CTRL+D (descarcarea stirilor din lista facuta de utilizator) apare o exceptie;

namespace ZanScore
{
    public partial class Form1 : Form
    {
        private static int initialwindowwidth = 0, initialwindowheight = 0;
        /// <summary>
        /// Stores if the window was maximized (stores true) or not (false).
        /// </summary>
        private static bool WasMaximized;
        /// <summary>
        /// Stores the initial width of the browser.
        /// </summary>
        /// <remarks> The usefulness of this variable appears because on the else branch, on the ResizeControlsEngine() function the program can go in two ways: when the window is resized and when it automatically goes back to the initial sizes, after it was maximized (it was restored). In the second case, all the windows components must me resized, while in the first case, the resizing automatically occurs when the ResizeEnd event gets triggered</remarks>
        private static int InitialBrowserWidth;

        /// <summary>
        /// Stores the entire data about the used news sources.
        /// </summary>
        public RSSSourceData NewsSourceData = new RSSSourceData();
        /// <summary>
        /// Stores the entire news sources collection, without any additional data.
        /// </summary>
        public RSSSourcesLibrary NewsSourcesCollection = new RSSSourcesLibrary();
        /// <summary>
        /// Class instance dealing with the program options.
        /// </summary>
        public OptionsHandling OH = new OptionsHandling();


        /// <summary>
        /// Stores the initial window width.
        /// </summary>
        /// <remarks>
        /// Used to store the initial width of the window before beginning resizing.
        /// </remarks>
        static public int InitialWindowWidth
        {
            get
            {
                return initialwindowwidth;
            }
            set
            {
                if (value > 0)
                    initialwindowwidth = value;
                else
                    initialwindowwidth = 1;
            }
        }

        /// <summary>
        /// Stores the initial window height.
        /// </summary>
        /// <remarks>
        /// Used to store the initial height of the window before beginning resizing.
        /// </remarks>
        static int InitialWindowHeight 
        {
            get
            {
                return initialwindowheight;
            }
            set
            {
                if (value > 0)
                    initialwindowheight = value;
                else
                    initialwindowheight = 1;
            }
        }

        /// <summary>
        /// Stores with how many pixels the window width increased or decreased.
        /// </summary>
        static int WidthDiff { get; set; }
        /// <summary>
        /// Stores with how many pixels the window height increased or decreased.
        /// </summary>
        static int HeightDiff { get; set; }

        /// <summary>
        /// Sets the news window grid.
        /// </summary>
        /// <remarks>
        /// The distribution is equal: 1/3 for every column.
        /// </remarks>
        private void SetColumnsWidth()
        {
            NewsChannel.Width = NewsDetailsGrid.Width / 3;
            NewsTitle.Width = NewsDetailsGrid.Width / 3;
            NewsDescription.Width = NewsDetailsGrid.Width / 3;
        }

        /// <summary>
        /// Stores the window sizes before the resizing process.
        /// </summary>
        private void GetInitialWindowSizes()
        {
            Height = OH.WindowHeight;
            Width = OH.WindowWidth;
        }

        /// <summary>
        /// Loads the window sizes from the options file and adjusts the dimensions of the controls according to the set proportions.
        /// </summary>
        private void LoadWindowSizes()
        {
            StoreInitialSizes();
            GetInitialWindowSizes();
            ApplyResizeEngine();
        }

        /// <summary>
        /// Sets the window state at startup: minimized, normal or maximized.
        /// </summary>
        /// <remarks>
        /// It's done according to the StartupOptions variable:
        /// 1 - window will start minimized;
        /// 2 - window will start normal;
        /// 3 - window will start maximized;
        /// The function also has a default case. This is as a caution measure for the case if, somehow, the StartupOptions value is different than 1, 2 or 3.
        /// </remarks>
        private void SetWindowMaximizationState()
        {
            switch (OH.StartupOptions)
            {
                case 1:
                    {
                        WindowState = FormWindowState.Minimized;
                        break;
                    }

                case 2:
                    {
                        WindowState = FormWindowState.Normal;
                        break;
                    }

                case 3:
                    {
                        WindowState = FormWindowState.Maximized;
                        break;
                    }

                default: 
                    {
                        WindowState = FormWindowState.Normal;
                        break;
                    }
            }
        }

        /// <summary>
        /// Computes the time interval, in miliseconds, which will be passed as a parameter to the timer.
        /// </summary>
        /// <returns>The time converted in ms.</returns>
        /// <remarks>
        /// The function convets the IntervalNumber variable in seconds, then in ms.
        /// The local variabile Multiplier converts hours, minutes or seconds into seconds.
        /// </remarks>
        private int ComputeTimeInterval()
        {
            int Multiplier = 1; 

            switch (OH.IntervalTime)
            {
                case 0:
                    {
                        Multiplier = 1;
                        break;
                    }
                case 1:
                    {
                        Multiplier = 60;
                        break;
                    }
                case 2:
                    {
                        Multiplier = 3600;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return Multiplier * OH.IntervalNumber * 1000;
        }

        /// <summary>
        /// The necessary actions of timer start or stop and, if it's started, to set the timer for automatically news download.
        /// </summary>
        /// <param name="DownloadAtInterval">Starts (value=1) or stops (value=0) the process.</param>
        /// <returns>true if news download at a certain interval is on. Else it returns false.</returns>
        public bool SetAutomaticDownloadTimerEngine(int DownloadAtInterval)
        {
            if (DownloadAtInterval == 1)
            {
                DownloadNewsTimer.Interval = ComputeTimeInterval();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the initial values for the different window and its components characteristics.
        /// </summary>
        private void SetInitialValues()
        {
            InitialBrowserWidth = NewsWebPage.Width;
            StatusLabel.Text = "Welcome";
            SetColumnsWidth();
            LoadWindowSizes();
            SetWindowMaximizationState();
            DownloadNewsTimer.Enabled = SetAutomaticDownloadTimerEngine(OH.NewsDownloadAtInterval);
        }

        /// <summary>
        /// Automatically downloads the news at program startup, if the user wanted so.
        /// </summary>
        private void AutomaticalNewsDownloadEngine()
        {
            if (OH.NewsDownloadAtStartup == 1)
            {
                DownloadAllNewsProcess(true);
            }
        }

        /// <summary>
        /// Checks to see if a network connection is available.
        /// </summary>
        /// <returns>true if the program has access to a network, false if it doesn't.</returns>
        public bool CheckForNetwork()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        /// <summary>
        /// Class constructor. 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the necessary variables for the news download.
        /// </summary>
        /// <param name="AreSources">Sets if the news come from the user defined sources (true) or from the default library (false).</param>
        /// <returns>true if no exceptions where thrown.</returns>
        private bool DownloadAllNewsInitialization(bool AreSources)
        {
            bool Result = true;

            if (AreSources)
                DownloadProgressBar.Maximum = NewsSourcesCollection.NumberofSelectedSources;
            else
                DownloadProgressBar.Maximum = 1;
            DownloadProgressBar.Value = 0;
            NewsSourceData.EmptyFields();
            NewsDetailsGrid.Rows.Clear();
            NewsSourcesCollection.ClearSources();
            Result = NewsSourcesCollection.LoadSources(AreSources);
            Cursor.Current = Cursors.WaitCursor;
            StatusLabel.Text = "Reading selected news feeds...";
            return Result;
        }

        /// <summary>
        /// The news downloading engine.
        /// </summary>
        /// <param name="AreSources">If the news that will be downloaded come from the sources set by the user (true) or from the default library.</param>
        /// <returns>True, if the function raised no exceptions.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown if, somehow, the AbsoluteIndex local variable points to a non-existent position. I don't think it will be thrown, but better be sure.
        /// </exception>
        public bool DownloadingEngine(bool AreSources)
        {
            if (AreSources)
            {
                List<string> URLList = new List<string>();
                URLList = NewsSourcesCollection.GetNewsURL();
                for (int i = 0; i < URLList.Count; i++)
                {
                    if (NewsSourcesCollection.IsSourceSelected[i])
                    {
                        if ((!NewsSourceData.FillRSSData(URLList[i])) && (OH.DisableInvalidNewsFiles == 1))
                            NewsSourcesCollection.DisableNewsSource(i);
                        DownloadProgressBar.Value++;
                    }
                }
                return true;
            }
            else
            {
                try
                {
                    NewsSourceData.FillRSSData(NewsLibrary.NewsSourcesRSSList[NewsLibrary.AbsoluteIndex]);
                    return true;
                }

                catch (ArgumentOutOfRangeException A) 
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBox.Show(A.Message, "Error downloading news from library", buttons, icon);
                    return false;
                }
            }
        }

        /// <summary>
        /// Shows the downloaded news.
        /// </summary>
        /// <returns>Always true. I need this to be able to write the DownloadAllNewsProcess function's result simpler and because nothing bad can happen so that an exception is thrown.</returns>
        private bool DownloadAllNewsFinalization()
        {
            Cursor.Current = Cursors.Arrow;
            FillGrid();
            StatusLabel.Text = "Download complete. " + NewsDetailsGrid.RowCount.ToString() + " news downloaded.";
            return true;
        }

        /// <summary>
        /// The entire news downloading process, which has three steps:
        /// 1. Initialization;
        /// 2. Running the engine;
        /// 3. Finalization.
        /// </summary>
        /// <param name="AreSources">Stores if the download should be made from the user specified sources (true) of from the default library.</param>
        /// <returns>True, if no exceptions were raised. Else, returns false.</returns>
        public bool DownloadAllNewsProcess(bool AreSources)
        {
            return DownloadAllNewsInitialization(AreSources) && DownloadingEngine(AreSources) && DownloadAllNewsFinalization();
        }

        /// <summary>
        /// Processing made with the download of the news from the chosen news sources.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The params used to trigger the event.</param>
        /// <remarks>It's an event handler</remarks>
        private void DownloadAllNews(object sender, EventArgs e)
        {
            DownloadAllNewsProcess(true);
        }

        /// <summary>
        /// Fills the grid with the downloaded news.
        /// </summary>
        private void FillGrid()
        {
            for (int i = 0; i < NewsSourceData.NewsTitle.Count; i++)
            {
                NewsDetailsGrid.Rows.Add();
                NewsDetailsGrid.Rows[i].Cells[0].Value = NewsSourceData.NewsChannelTitle[i];
                NewsDetailsGrid.Rows[i].Cells[1].Value = NewsSourceData.NewsTitle[i];
                NewsDetailsGrid.Rows[i].Cells[2].Value = NewsSourceData.NewsDescription[i];
            }
        }

        /// <summary>
        /// The instructions for the selected news download.
        /// </summary>
        /// <param name="URL">The news URL</param>
        /// <returns>true if no exception was raised. Else it returns false.</returns>
        /// <exception cref="System.ObjectDisposedException">Treats errors that appear while object disposing.</exception>
        /// <exception cref="System.InvalidOperationException">Treats errors that appear because of invalid operations.</exception>
        /// <exception cref="System.ArgumentException">Treats errors that appear because of invalid arguments.</exception>
        /// <exception cref="System.UriFormatException">Treats errors that appear because of a invalid URI format.</exception>
        public bool LoadingNewsEngine(string URL)
        {
            try
            {
                NewsWebPage.Navigate(new Uri(URL));
                return true;
            }

            catch (ObjectDisposedException O)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(O.Message, "Error!", MB, MI);
                return false;
            }

            catch (InvalidOperationException I)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(I.Message, "Error!", MB, MI);
                return false;
            }

            catch (ArgumentException A)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(A.Message, "Error!", MB, MI);
                return false;
            }

            catch (UriFormatException U)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(U.Message, "Error!", MB, MI);
                return false;
            }
        }

        /// <summary>
        /// Loads the selected news.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void LoadNewsURL(object sender, DataGridViewCellEventArgs e)
        {
            LoadingNewsEngine(NewsSourceData.NewsLink[NewsDetailsGrid.CurrentCell.RowIndex]);
        }

        /// <summary>
        /// Shows the news source selection window.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void SelectNewsSources(object sender, EventArgs e)
        //Afiseaza fereastra de selectie a surselor de stiri
        {
            SelectSourcesWindow S = new SelectSourcesWindow();
            S.ShowDialog(owner: this);
            if (S.DialogResult == DialogResult.OK)
                NewsSourcesCollection.SaveSources();
        }

        /// <summary>
        /// Shows the news sources adding window.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void ShowAddNewsSourcesWindow(object sender, EventArgs e)
        {
            AddSourceWindow A = new AddSourceWindow();
            A.ShowDialog(owner: this);
            if (A.DialogResult == DialogResult.OK)
            {
                NewsSourcesCollection.AddNewSource(A.SourceNameText.Text, A.SourceURLText.Text);
                NewsSourcesCollection.SaveSources();
            }
        }

        /// <summary>
        /// Shows the news sources editing window.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void ShowEditSourcesWindow(object sender, EventArgs e)
        {
            EditSourcesWindow E = new EditSourcesWindow();
            NewsSourcesCollection.ShowNewsSourcesInDataGrid(E.AllTheSources);
            E.ShowDialog(owner: this);
        }

        /// <summary>
        /// Shows the program options window.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void ShowOptionsWindow(object sender, EventArgs e)
        {
            OptionsWindow O = new OptionsWindow();
            O.ShowDialog(owner: this);
        }

        /// <summary>
        /// Shows the program about box.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void ShowAboutBoxWindow(object sender, EventArgs e)
        {
            AboutBox A = new AboutBox();
            A.ShowDialog();
        }

        /// <summary>
        /// Displays a message when the cursor is over the "Download" menu option.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void DisplayDownloadHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Options for downloading from news sources";
        }

        /// <summary>
        /// Displays a message when the cursor is over the "News Sources" menu option.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void DisplayNewsSourcesHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "News sources management";
        }

        /// <summary>
        /// Displays a message when the cursor is over the "All" menu option.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void DisplayAllHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Download from all selected news sources";
        }

        /// <summary>
        /// Displays a message when the cursor is over the "Selected" menu option.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void DisplaySelectedHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Select the news sources that will be downloaded";
        }

        /// <summary>
        /// Displays a message when the cursor is over the "Add" menu option.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void DisplayAddHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Add a new news source";
        }

        /// <summary>
        /// Displays a message when the cursor is over the "Edit" menu option.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void DisplayEditHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Edit, delete or reorder news sources";
        }

        /// <summary>
        /// Displays a message when the cursor is over the "Options" menu option.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void DisplayOptionsHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Options for customizing ZanNews";
        }

        /// <summary>
        /// Displays a message when thw cursor is over the "About" menu option.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void DisplayAboutBoxHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "About ZanNews";
        }

        /// <summary>
        /// Computes the difference between the initial window sizes and the window sizes after the user finishes dragging window borders.
        /// </summary>
        private void ApplyResizeEngine()
        {
            if (Width > MinimumSize.Width)
                NewsWebPage.Width += WidthDiff;
            else
                NewsWebPage.Width = InitialBrowserWidth;

            NewsWebPage.Height += HeightDiff;
            NewsDetailsGrid.Height += HeightDiff;

            WasMaximized = false;
        }

        /// <summary>
        /// Resizes the controls with the computed difference.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void EndResize(object sender, EventArgs e)
        //Rutina mareste sau micsoreaza controalele in cu diferenta calculata
        {
            ApplyResizeEngine();
        }

        /// <summary>
        /// Computes the size differences for the window.
        /// </summary>
        private void ComputeSizeDifferences()
        {
            HeightDiff = Height - InitialWindowHeight;
            WidthDiff = Width - InitialWindowWidth;
        }

        /// <summary>
        /// Sets the controls size when the window is maximized.
        /// </summary>
        /// <remarks>Values .02 and .12 are taken approximatively, based on what I saw on my laptop. I think there is a better way here, though.</remarks>
        private void SetControlSizeWhenMaximized()
        {
            NewsWebPage.Width = Width - NewsWebPage.Left - (int)(Width * 0.02);
            NewsWebPage.Height = NewsDetailsGrid.Height;
            NewsDetailsGrid.Height = Screen.PrimaryScreen.Bounds.Height - statusStrip1.Height - MainMenu.Height - (int)(Height * 0.12);
        }

        /// <summary>
        /// Actually resizes the controls of the window.
        /// </summary>
        private void ResizeControlsEngine()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                SetControlSizeWhenMaximized();
                StoreInitialSizes();
                ComputeSizeDifferences();
                WasMaximized = true;
            }
            else
            {
                ComputeSizeDifferences();
                if (WasMaximized)
                    ApplyResizeEngine();
            }
        }

        /// <summary>
        /// Minimizes the program on Systray.
        /// </summary>
        private void MinimizeToSystrayEngine()
        {
            if ((OH.MinimizeToTray == 1) && (this.WindowState == FormWindowState.Minimized))
            {
                Hide();
                MinimizeToSystray.Visible = true;
                MinimizeToSystray.ShowBalloonTip(1000);
            }
        }

        /// <summary>
        /// Computes the widths and heights of the controls that will be resized.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void ResizeEngine(object sender, EventArgs e)
        {
            ResizeControlsEngine();
            MinimizeToSystrayEngine();
        }

        /// <summary>
        /// Actions performed at program shutdown.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void Bye(object sender, FormClosedEventArgs e)
        {
            OH.WindowHeight = Height;
            OH.WindowWidth = Width;
            OH.SaveOptionsToFile();
        }

        /// <summary>
        /// Actions made after the main window is shown.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.
        /// The actions are:
        /// 1. Checking if there is an internet connection;
        /// 2. Automatically download the news, if needed;
        /// 3. Load the initial window values.
        /// </remarks>
        private void StuffAfterFormIsShown(object sender, EventArgs e)
        {
            if (!CheckForNetwork())
            {
                MessageBox.Show("No internet connection available. Application will now terminate.");
                Close();
            }
            AutomaticalNewsDownloadEngine();
            SetInitialValues();
        }

        /// <summary>
        /// Restores the application, if it was minimized to Systray.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void RestoreApplication(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            MinimizeToSystray.Visible = false;
        }

        /// <summary>
        /// Actions required to automatically download news from news sources.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void AutomaticalDownloadEngine(object sender, EventArgs e)
        {
            DownloadAllNewsProcess(true);
        }

        /// <summary>
        /// Shows the news library window.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void ShowNewsLibraryWindow(object sender, EventArgs e)
        {
            NewsLibrary N = new NewsLibrary();
            if (!N.IsDisposed)
                N.ShowDialog(this);
        }

        /// <summary>
        /// Stores the initial sizes of the main window.
        /// </summary>
        /// <remarks>
        /// Useful when the window is resized.
        /// </remarks>
        private void StoreInitialSizes()
        {
            InitialWindowHeight = Height;
            InitialWindowWidth = Width;
        }

        /// <summary>
        /// Stores the initial sizes of the controls, before window resizing begins.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void BeginResize(object sender, EventArgs e)
        {
            StoreInitialSizes();
        }
    }
}
