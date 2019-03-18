using System;
using System.Collections.Generic;
using System.Windows.Forms;

//todo sa generez documentatia XML

namespace ZanScore
{
    public partial class Form1 : Form
    {
        private static int initialwindowwidth = 0, initialwindowheight = 0;
        private static bool WasMaximized; //retine daca fereastra a fost maximizata sau nu (atunci e true)
        private static int InitialBrowserWidth; //retine latimea initiala a browserului

        /// <summary>
        /// Stores the entire data about the used news sources
        /// </summary>
        public RSSSourceData NewsSourceData = new RSSSourceData();
        /// <summary>
        /// Stores the entire news sources collection, without any additional data
        /// </summary>
        public RSSSourcesLibrary NewsSourcesCollection = new RSSSourcesLibrary();
        /// <summary>
        /// Class instance dealing with the program options
        /// </summary>
        public OptionsHandling OH = new OptionsHandling();


        /// <summary>
        /// Stores the initial window width
        /// </summary>
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

        static int InitialWindowHeight //folosite la redimensionarea controalelor ferestrei. Retin dimensiunile initiale ale ferestrei
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

        static int WidthDiff { get; set; }
        static int HeightDiff { get; set; } //retin cu ce latime respectiv inaltime fereastra s-a marit sau s-a micsorat

        private void SetColumnsWidth()
        //Seteaza latimile grilei cu stiri
        {
            NewsChannel.Width = NewsDetailsGrid.Width / 3;
            NewsTitle.Width = NewsDetailsGrid.Width / 3;
            NewsDescription.Width = NewsDetailsGrid.Width / 3;
        }

        private void GetInitialWindowSizes()
        {
            Height = OH.WindowHeight;
            Width = OH.WindowWidth;
        }

        private void LoadWindowSizes()
        //Incarca dimensiunile ferestrei din fisierul de optiuni si ajusteaza dimensiunile controalelor in functie de proportiile stabilite
        {
            StoreInitialSizes();
            GetInitialWindowSizes();
            ApplyResizeEngine();
        }

        private void SetWindowMaximizationState()
        //Stabileste cum va fi fereastra la pornirea programului: minimizata, normala sau maximizata
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

                default: //Pentru cazul in care, cumva, optiunea de pornire are o valoare diferita de 1, 2 sau 3.
                    {
                        WindowState = FormWindowState.Normal;
                        break;
                    }
            }
        }

        private int ComputeTimeInterval()
        //Calculeaza intervalul de timp, in ms, care va fi transmis ca parametru Timerului
        {
            int Multiplier = 1; //transforma din ore, minute, secunde in secunde

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
        /// <param name="DownloadAtInterval">Starts (value=1) or stops (value=0) the process</param>
        /// <returns>true if news download at a certain interval is on. Else it returns false</returns>
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

        private void SetInitialValues()
        //Stabileste valorile initiale pentru diferite caracteristici ale ferestrei si ale componentelor ei
        {
            InitialBrowserWidth = NewsWebPage.Width;
            StatusLabel.Text = "Welcome";
            SetColumnsWidth();
            LoadWindowSizes();
            SetWindowMaximizationState();
            DownloadNewsTimer.Enabled = SetAutomaticDownloadTimerEngine(OH.NewsDownloadAtInterval);
        }

        private void AutomaticalNewsDownloadEngine()
        //Se ocupa de descarcarea automata a stirilor, daca a fost stabilit acest lucru
        {
            if (OH.NewsDownloadAtStartup == 1)
            {
                DownloadAllNewsProcess(true);
            }
        }

        /// <summary>
        /// Checks to see if a network connection is available
        /// </summary>
        /// <returns>true if the program has access to a network, false if it doesn't</returns>
        public bool CheckForNetwork()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        /// <summary>
        /// Class constructor. 
        /// </summary>
        public Form1()
        //Constructor
        {
            InitializeComponent();
        }

        private bool DownloadAllNewsInitialization(bool AreSources)
        //Initializarea variabilelor necesare pentru downloadul stirilor
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
        /// <param name="AreSources">If the news that will be downloaded come from the sources set by the user (true) or from the default library</param>
        /// <returns>True, if the function raised no exceptions</returns>
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

                catch (ArgumentOutOfRangeException A) //In cazul in care AbsoluteIndex arata spre o pozitie inexistenta. Nu cred ca va aparea, dar sa fiu sigur
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBox.Show(A.Message, "Error downloading news from library", buttons, icon);
                    return false;
                }
            }
        }

        private bool DownloadAllNewsFinalization()
        //Functia afiseaza stirile descarcate in program. Va intoarce intotdeauna true pentru a scrie mai simplu rezultatul functiei DownloadAllNewsProcess si pentru ca nu poate avea loc nicio eroare, ca sa forteze aceasta functie sa intoarca false;
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
        /// 3. Finalization
        /// </summary>
        /// <param name="AreSources">Stores if the download should be made from the user specified sources (true) of from the default library</param>
        /// <returns>True, if no exceptions were raised. Else, returns false</returns>
        public bool DownloadAllNewsProcess(bool AreSources)
        {
            return DownloadAllNewsInitialization(AreSources) && DownloadingEngine(AreSources) && DownloadAllNewsFinalization();
        }

        private void DownloadAllNews(object sender, EventArgs e)
        //Procesarea efectuata cu ocazia descarcarii stirilor din sursele alese
        {
            DownloadAllNewsProcess(true);
        }

        private void FillGrid()
        //Umple tabelul cu stirile citite
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
        /// The instructions for the selected news download
        /// </summary>
        /// <param name="URL">The news URL</param>
        /// <returns>true if no exception was raised. Else it returns false</returns>
        public bool LoadingNewsEngine(string URL)
        //Instructiunile pentru incararea efectiva a stirii selectate
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

        private void LoadNewsURL(object sender, DataGridViewCellEventArgs e)
        //Incarca stirea selectata
        {
            LoadingNewsEngine(NewsSourceData.NewsLink[NewsDetailsGrid.CurrentCell.RowIndex]);
        }

        private void SelectNewsSources(object sender, EventArgs e)
        //Afiseaza fereastra de selectie a surselor de stiri
        {
            SelectSourcesWindow S = new SelectSourcesWindow();
            S.ShowDialog(owner: this);
            if (S.DialogResult == DialogResult.OK)
                NewsSourcesCollection.SaveSources();
        }

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

        private void ShowEditSourcesWindow(object sender, EventArgs e)
        {
            EditSourcesWindow E = new EditSourcesWindow();
            NewsSourcesCollection.ShowNewsSourcesInDataGrid(E.AllTheSources);
            E.ShowDialog(owner: this);
        }

        private void ShowOptionsWindow(object sender, EventArgs e)
        {
            OptionsWindow O = new OptionsWindow();
            O.ShowDialog(owner: this);
        }

        private void ShowAboutBoxWindow(object sender, EventArgs e)
        {
            AboutBox A = new AboutBox();
            A.ShowDialog();
        }

        private void DisplayDownloadHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Options for downloading from news sources";
        }

        private void DisplayNewsSourcesHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "News sources management";
        }

        private void DisplayAllHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Download from all selected news sources";
        }

        private void DisplaySelectedHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Select the news sources that will be downloaded";
        }

        private void DisplayAddHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Add a new news source";
        }

        private void DisplayEditHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Edit, delete or reorder news sources";
        }

        private void DisplayOptionsHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Options for customizing ZanNews";
        }

        private void DisplayAboutBoxHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "About ZanNews";
        }

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

        private void EndResize(object sender, EventArgs e)
        //Rutina mareste sau micsoreaza controalele in cu diferenta calculata
        {
            ApplyResizeEngine();
        }

        private void ComputeSizeDifferences()
        {
            HeightDiff = Height - InitialWindowHeight;
            WidthDiff = Width - InitialWindowWidth;
        }

        private void SetControlSizeWhenMaximized()
        {
            NewsWebPage.Width = Width - NewsWebPage.Left - (int)(Width * 0.02);
            NewsWebPage.Height = NewsDetailsGrid.Height;
            NewsDetailsGrid.Height = Screen.PrimaryScreen.Bounds.Height - statusStrip1.Height - MainMenu.Height - (int)(Height * 0.12);
        }

        private void ResizeControlsEngine()
        //Procedura de redimensionare a controlalelor ferestrei
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
                /*Necesitatea variabilei WasMaximized apare deoarece pe ramura else se ajunge in doua feluri: atunci cand fereastra e redimensionata si atunci cand fereastra revine la dimensiunile sale initiale dupa ce a fost maximizata. In al doilea caz, trebuie redimensionate, efectiv, controalele ferestrei pe cand in primul caz, acest lucru se face automat prin declansarea evenimentului ResizeEnd*/
                if (WasMaximized)
                    ApplyResizeEngine();
            }
        }

        private void MinimizeToSystrayEngine()
        //Instructiunile pentru minimizarea pe Systray
        {
            if ((OH.MinimizeToTray == 1) && (this.WindowState == FormWindowState.Minimized))
            {
                Hide();
                MinimizeToSystray.Visible = true;
                MinimizeToSystray.ShowBalloonTip(1000);
            }
        }

        private void ResizeEngine(object sender, EventArgs e)
        //Rutina calculeaza valorile latimilor si ale inaltimilor cu care controalele vor fi marite sau micsorate
        {
            ResizeControlsEngine();
            MinimizeToSystrayEngine();
        }

        private void Bye(object sender, FormClosedEventArgs e)
        //Actiuni efectuate la inchiderea programului
        {
            OH.WindowHeight = Height;
            OH.WindowWidth = Width;
            OH.SaveOptionsToFile();
        }

        private void StuffAfterFormIsShown(object sender, EventArgs e)
        //Questii efectuate atunci cand fereastra este afisata
        {
            if (!CheckForNetwork())
            {
                MessageBox.Show("No internet connection available. Application will now terminate.");
                Close();
            }
            AutomaticalNewsDownloadEngine();
            SetInitialValues();
        }

        private void RestoreApplication(object sender, EventArgs e)
        //Aduce aplicatia in prim-plan daca utilizatorul a facut click pe ea
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            MinimizeToSystray.Visible = false;
        }

        private void AutomaticalDownloadEngine(object sender, EventArgs e)
        //Se ocupa de actiunile necesare descarcarii automate a stirilor
        {
            DownloadAllNewsProcess(true);
        }

        private void ShowNewsLibraryWindow(object sender, EventArgs e)
        {
            NewsLibrary N = new NewsLibrary();
            if (!N.IsDisposed)
                N.ShowDialog(this);
        }

        private void StoreInitialSizes()
        //Stocheaza dimensiunile initiale ale ferestrei. Utile la redimensionarea acesteia
        {
            InitialWindowHeight = Height;
            InitialWindowWidth = Width;
        }

        private void BeginResize(object sender, EventArgs e)
        //Stocheaza valorile initiale ale dimensiunilor controlalelor, dinainte de redimensionarea ferestrei
        {
            StoreInitialSizes();
        }
    }
}
