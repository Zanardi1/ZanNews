using System;
using System.Windows.Forms;
using System.Collections.Generic;

//todo pe viitor sa incep sa tratez si exceptiile si cazurile de eroare. Pana acum m-am ocupat de cazurile ideale.
//todo pe viitor sa implementez o biblioteca de surse de stiri

namespace ZanScore
{
    public partial class Form1 : Form
    {
        public RSSSourceData NewsSourceData = new RSSSourceData();
        public RSSSourcesLibrary NewsSourcesCollection = new RSSSourcesLibrary();
        public OptionsHandling OH = new OptionsHandling();
        static int InitialWidth, InitialHeight; //folosite la redimensionarea controalelor ferestrei. Retin dimensiunile initiale ale ferestrei
        static int WidthDiff, HeightDiff; //retin cu ce latime respectiv inaltime fereastra s-a marit sau s-a micsorat
        private static bool WasMaximized; //retine daca fereastra a fost maximizata sau nu (atunci e true)
        private static int InitialBrowserWidth; //retine latimea initiala a browserului

        private void SetColumnsWidth()
        //Seteaza latimile grilei cu stiri
        {
            NewsChannel.Width = NewsDetailsGrid.Width / 3;
            NewsTitle.Width = NewsDetailsGrid.Width / 3;
            NewsDescription.Width = NewsDetailsGrid.Width / 3;
        }

        private void LoadWindowSizes()
        //Incarca dimensiunile ferestrei din fisierul de optiuni si ajusteaza dimensiunile controlalelor in functie de proportiile stabilite
        {
            StoreInitialSizes();
            Height = OH.WindowHeight;
            Width = OH.WindowWidth;
            ApplyResize();
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
            }
        }

        private int ComputeTimeInterval()
        //Calculeaza intervalul de timp, in ms, care va fi transmis ca parametru Timerului
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
            }
            return Multiplier * OH.IntervalNumber * 1000;
        }

        public void SetTimerEngine()
        //Actiunile necesare pornirii sau opririi cronometrului si, daca acesta e pornit, setarii cronometrului pentru descarcarea stirilor
        {
            if (OH.NewsDownloadAtInterval == 1)
            {
                DownloadNewsTimer.Interval = ComputeTimeInterval();
                DownloadNewsTimer.Enabled = true;
            }
            else
            {
                DownloadNewsTimer.Enabled = false;
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
            SetTimerEngine();
        }

        private void AutomaticalNewsDownloadEngine()
        //Se ocupa de descarcarea automata a stirilor, daca a fost stabilit acest lucru
        {
            if (OH.NewsDownloadAtStartup == 1)
            {
                DownloadAllNewsProcess();
            }
        }

        public Form1()
        //Constructor
        {
            InitializeComponent();
            SetInitialValues();
        }

        private void DownloadAllNewsInitialization()
        //Initializarea variabilelor necesare pentru downloadul stirilor
        {
            DownloadProgressBar.Maximum = NewsSourcesCollection.NumberofSelectedSources;
            DownloadProgressBar.Value = 0;
            NewsSourceData.EmptyFields();
            NewsDetailsGrid.Rows.Clear();
            NewsSourcesCollection.ClearSources();
            NewsSourcesCollection.LoadSources();
        }

        private void DownloadingEngine()
        //Motorul de download a stirilor
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
        }

        private void DownloadAllNewsProcess()
        //Intreg procesul de descarcare a stirilor
        {
            DownloadAllNewsInitialization();

            Cursor.Current = Cursors.WaitCursor;
            StatusLabel.Text = "Reading selected news feeds...";

            DownloadingEngine();

            Cursor.Current = Cursors.Arrow;
            FillGrid();
            StatusLabel.Text = "Download complete. " + NewsDetailsGrid.RowCount.ToString() + " news downloaded.";
        }

        private void DownloadAllNews(object sender, EventArgs e)
        //Procesarea efectuata cu ocazia descarcarii stirilor din sursele alese
        {
            DownloadAllNewsProcess();
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

        private void LoadNewsURL(object sender, DataGridViewCellEventArgs e)
        //Incarca stirea selectata
        {
            NewsWebPage.Navigate(new Uri(NewsSourceData.NewsLink[NewsDetailsGrid.CurrentCell.RowIndex]));
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
        /* Liniile de cod scrise intre "//*" arata modalitatea de a citi numele si URL-ul sursei noi, introduse de catre utilizator. Deoarece acestea se afla intr-o alta fereastra si deoarece componentele sunt marcate cu private, metoda corecta de ajungere la acele valori este urmatoarea:
         1. Se cicleaza prin fiecare component al ferestrei;
         2. In cazul in care ajungem la un GroupBox, se cicleaza prin componentele acestuia
         3. In cazul in care o componenta din GroupBox are numele pe care il vreau eu, atunci citeste valoarea dorita

         E nevoie de doua ciclari, deoarece componentele din GroupBox sunt copii pentru acesta, iar GroupBox este copil pentru fereastra. In ambele cazuri, trebuie cautat ceea ce doresc prin toate componentele copil*/
        {
            AddSourceWindow A = new AddSourceWindow();
            string s = "", s2 = "";
            A.ShowDialog(this);
            if (A.DialogResult == DialogResult.OK) //*
            {
                s = A.NewName;
                s2 = A.NewURL;

                NewsSourcesCollection.AddNewSource(s, s2);
                NewsSourcesCollection.SaveSources();
            }
        }

        private void ShowEditSourcesWindow(object sender, EventArgs e)
        {
            EditSourcesWindow E = new EditSourcesWindow();
            foreach (Control c in E.Controls)
                if (c is DataGridView)
                    NewsSourcesCollection.ShowNewsSourcesInDataGrid(c as DataGridView);
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

        private void ApplyResize()
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
            ApplyResize();
        }

        private void ComputeSizeDifferences()
        {
            HeightDiff = Height - InitialHeight;
            WidthDiff = Width - InitialWidth;
        }

        private void ResizeControls()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                NewsWebPage.Width = Width - NewsWebPage.Left - (int)(Width * 0.02);
                NewsDetailsGrid.Height = Screen.PrimaryScreen.Bounds.Height - statusStrip1.Height - MainMenu.Height - (int)(Height * 0.12);
                NewsWebPage.Height = NewsDetailsGrid.Height;
                StoreInitialSizes();
                ComputeSizeDifferences();
                WasMaximized = true;
            }
            else
            {
                ComputeSizeDifferences();
                /*Necesitatea variabilei WasMaximized apare deoarece pe ramura else se ajunge in doua feluri: atunci cand fereastra e redimensionata si atunci cand fereastra revine la dimensiunile sale initiale dupa ce a fost maximizata. In al doilea caz, trebuie redimensionate, efectiv, controalele ferestrei pe cand in primul caz, acest lucru se face automat prin declansarea evenimentului ResizeEnd*/
                if (WasMaximized)
                    ApplyResize();
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
            ResizeControls();
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
            AutomaticalNewsDownloadEngine();
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
            DownloadAllNewsProcess();
        }

        private void ShowNewsLibraryWindow(object sender, EventArgs e)
        {
            
        }

        private void StoreInitialSizes()
        {
            InitialHeight = Height;
            InitialWidth = Width;
        }

        private void BeginResize(object sender, EventArgs e)
        //Stocheaza valorile initiale ale dimensiunilor controlalelor, dinainte de redimensionarea ferestrei
        {
            StoreInitialSizes();
        }
    }
}
