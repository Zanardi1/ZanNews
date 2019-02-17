using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ZanScore
{
    public partial class OptionsWindow : Form
    {
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

        private void Assign1ToVar(object sender, EventArgs e)
        {
            if (StartMinimized.Checked)
                ((Form1)Owner).OH.StartupOptions = 1;
        }

        private void Assign2ToVar(object sender, EventArgs e)
        {
            if (StartNormal.Checked)
                ((Form1)Owner).OH.StartupOptions = 2;
        }

        private void Assign3ToVar(object sender, EventArgs e)
        {
            if (StartMaximized.Checked)
                ((Form1)Owner).OH.StartupOptions = 3;
        }

        private void StartupEngine(bool enable)
        //Instructiunile pentru pornirea sau nepornirea aplicatiei odata cu Windows
        //bug functia scrie in registrul corect, conform teoriei, numai ca aplicatia nu porneste odata cu sistemul de operare
        {
            string runKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            RegistryKey startupKey = Registry.CurrentUser.OpenSubKey(runKey);

            if (enable)
            {
                if (startupKey.GetValue("ZanNews") == null)
                {
                    startupKey.Close();
                    startupKey = Registry.CurrentUser.OpenSubKey(runKey, true);
                    startupKey.SetValue("ZanNews", "\"" + Application.ExecutablePath + "\"");
                    startupKey.Close();
                }
            }
            else
            {
                startupKey = Registry.CurrentUser.OpenSubKey(runKey, true);
                startupKey.DeleteValue("ZanNews", false);
                startupKey.Close();
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
            ((Form1)Owner).SetTimerEngine();
            Close();
        }

        private void StartWithWindowsToggle(object sender, EventArgs e)
        {
            ((Form1)Owner).OH.WindowsStartup = (StartWithWindowsCheckBox.Checked ? 1 : 0);
        }

        private void MinimizeToTrayToggle(object sender, EventArgs e)
        {
            ((Form1)Owner).OH.MinimizeToTray = (MinimizeToTrayCheckBox.Checked ? 1 : 0);
        }

        private void DisableNewsSourcesToggle(object sender, EventArgs e)
        {
            ((Form1)Owner).OH.DisableInvalidNewsFiles = (DisableBadSources.Checked ? 1 : 0);
        }

        private void DownloadAtStartupToggle(object sender, EventArgs e)
        {
            ((Form1)Owner).OH.NewsDownloadAtStartup = (DownloadNewsAtStartup.Checked ? 1 : 0);
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowOptions(object sender, EventArgs e)
        {
            ShowOptionsInOptionsWindow();
        }

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

        private void UnitSelectionEngine(object sender, EventArgs e)
        //procesarile legate de selectarea unitatii de masura
        {
            AdjustSuperiorValues();
        }

        private void SetValueInOptionsStructure()
        {
            ((Form1)Owner).OH.IntervalNumber = (int)NumericValue.Value;
        }

        private void AdjustingValueEngine(object sender, EventArgs e)
        //Seteaza valoarea numerica in structura optiunilor
        {
            SetValueInOptionsStructure();
        }
    }
}
