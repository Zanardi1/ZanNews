using System;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.IO;

namespace ZanScore
{
    /// <summary>
    /// Class that handles the options window
    /// </summary>
    public partial class OptionsWindow : Form
    {
        /// <summary>
        /// Options window constructor
        /// </summary>
        public OptionsWindow()
        {
            InitializeComponent();
        }

        private void ShowOptionsInOptionsWindow()
        {
            StartWithWindowsCheckBox.Checked = (((Form1)Owner).OH.WindowsStartup == 1 ? true : false);
            MinimizeToTrayCheckBox.Checked = (((Form1)Owner).OH.MinimizeToTray == 1 ? true : false);
            DisableBadSources.Checked = (((Form1)Owner).OH.DisableInvalidNewsFiles == 1 ? true : false);
            DownloadNewsAtStartup.Checked = (((Form1)Owner).OH.NewsDownloadAtStartup == 1 ? true : false);
            AutomaticalDownload.Checked = (((Form1)Owner).OH.NewsDownloadAtInterval == 1 ? true : false);
            NumericValue.Value = ((Form1)Owner).OH.IntervalNumber;
            TimeInterval.SelectedIndex = ((Form1)Owner).OH.IntervalTime;

            switch (((Form1)Owner).OH.StartupOptions)
            {
                case 1:
                    {
                        StartMinimized.Checked = true;
                        break;
                    }
                case 2:
                    {
                        StartNormal.Checked = true;
                        break;
                    }
                case 3:
                    {
                        StartMaximized.Checked = true;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void Assign1ToStartupOptionsVar(object sender, EventArgs e)
        {
            if (StartMinimized.Checked)
                ((Form1)Owner).OH.StartupOptions = 1;
        }

        private void Assign2ToStartupOptionsVar(object sender, EventArgs e)
        {
            if (StartNormal.Checked)
                ((Form1)Owner).OH.StartupOptions = 2;
        }

        private void Assign3ToStartupOptionsVar(object sender, EventArgs e)
        {
            if (StartMaximized.Checked)
                ((Form1)Owner).OH.StartupOptions = 3;
        }

        private void CreateTheShortcut()
        //Creaza scurtatura care va fi pusa la startup
        {
            WshShell wshShell = new WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut;
            string startUpFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            // Create the shortcut
            shortcut = (IWshShortcut)wshShell.CreateShortcut(startUpFolderPath + "\\" + Application.ProductName + ".lnk");
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.WorkingDirectory = Application.StartupPath;
            shortcut.Description = "Launch My Application";
            // shortcut.IconLocation = Application.StartupPath + @"\App.ico";
            shortcut.Save();
        }

        private void DeleteTheShortcut()
        {
            string PathToShortcut = "";
            PathToShortcut = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + Application.ProductName + ".lnk";
            try
            {
                System.IO.File.Delete(PathToShortcut);
            }
            catch (FileNotFoundException F)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(F.Message, "Error!", MB, MI);
            }
        }

        private void StartupEngine(bool enable)
        //Instructiunile pentru pornirea sau nepornirea aplicatiei odata cu Windows
        {
            if (enable)
            {
                CreateTheShortcut();
            }
            else
            {
                DeleteTheShortcut();
            }
        }

        private void ChooseStartup()
        //Alege daca sa porneasca sau nu aplicatia odata cu Windows
        {
            if (((Form1)Owner).OH.WindowsStartup == 1)
                StartupEngine(true);
            else
                StartupEngine(false);
        }

        private void SaveChanges(object sender, EventArgs e)
        {
            ((Form1)Owner).OH.SaveOptionsToFile();
            ChooseStartup();
            ((Form1)Owner).DownloadNewsTimer.Enabled = ((Form1)Owner).SetAutomaticDownloadTimerEngine(((Form1)Owner).OH.NewsDownloadAtInterval);
            Close();
        }

        private void StartWithWindowsToggle(object sender, EventArgs e) => ((Form1)Owner).OH.WindowsStartup = (StartWithWindowsCheckBox.Checked ? 1 : 0);
        //Procedura bifeaza sau debifeaza checkbox-ul legat de pornirea programului odata cu sistemul de operare

        private void MinimizeToTrayToggle(object sender, EventArgs e) => ((Form1)Owner).OH.MinimizeToTray = (MinimizeToTrayCheckBox.Checked ? 1 : 0);
        //Procedura bifeaza sau debifeaza checkbox-ul legat de minimizarea in Systray a programului

        private void DisableNewsSourcesToggle(object sender, EventArgs e) => ((Form1)Owner).OH.DisableInvalidNewsFiles = (DisableBadSources.Checked ? 1 : 0);
        //Procedura bifeaza sau debifeaza checkbox-ul legat de dezactivarea surselor de stiri cu un RSS ce nu poate fi citit

        private void DownloadAtStartupToggle(object sender, EventArgs e) => ((Form1)Owner).OH.NewsDownloadAtStartup = (DownloadNewsAtStartup.Checked ? 1 : 0);
        //Procedura bifeaza sau debifeaza checkbox-ul legat de descarcarea stirilor la pornirea programului

        private void CloseWindow(object sender, EventArgs e) => Close();
        //Procedura inchide freastra de optiuni

        private void ShowOptions(object sender, EventArgs e) => ShowOptionsInOptionsWindow();
        //Procedura afiseaza optiunile in fereastra

        private void ToggleIntervalEnabling(object sender, EventArgs e)
        //Activeaza sau dezactiveaza controlalele pentru stabilirea duratei de asteptate intre descarcari
        {
            DownlInterval.Enabled = AutomaticalDownload.Checked;
            NumericValue.Enabled = AutomaticalDownload.Checked;
            TimeInterval.Enabled = AutomaticalDownload.Checked;
            ((Form1)Owner).OH.NewsDownloadAtInterval = (AutomaticalDownload.Checked ? 1 : 0);
        }

        private void AdjustSuperiorValues()
        //Modifica valoarea superioara a componentei de selectie a valorii numerice (60 in cazul secundelor si minutelor si 23 in cazul orelor
        {
            switch (TimeInterval.SelectedIndex)
            {
                case 0:
                    {
                        NumericValue.Maximum = 60;
                        ((Form1)Owner).OH.IntervalTime = 0;
                        break;
                    }
                case 1:
                    {
                        NumericValue.Maximum = 60;
                        ((Form1)Owner).OH.IntervalTime = 1;
                        break;
                    }
                case 2:
                    {
                        NumericValue.Maximum = 23;
                        ((Form1)Owner).OH.IntervalTime = 2;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void UnitSelectionEngine(object sender, EventArgs e) => AdjustSuperiorValues();
        //Procedura efectueaza procesarile legate de selectarea unitatii de masura

        private void SetValueInOptionsStructure() => ((Form1)Owner).OH.IntervalNumber = (int)NumericValue.Value;
        //Procedura atribuie valoarea numerica in variabila potrivita, variabila citita din fereastra

        private void AdjustingValueEngine(object sender, EventArgs e) => SetValueInOptionsStructure();
        //Seteaza valoarea numerica in structura optiunilor
    }
}
