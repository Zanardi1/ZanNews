using System;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.IO;

namespace ZanScore
{
    /// <summary>
    /// Class that handles the options window.
    /// </summary>
    public partial class OptionsWindow : Form
    {
        /// <summary>
        /// Options window constructor.
        /// </summary>
        public OptionsWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the loaded options in the options window.
        /// </summary>
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

        /// <summary>
        /// Logic for assigning the value of 1 for the StartupOptions variable.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void Assign1ToStartupOptionsVar(object sender, EventArgs e)
        {
            if (StartMinimized.Checked)
                ((Form1)Owner).OH.StartupOptions = 1;
        }

        /// <summary>
        /// Logic for assigning the value of 2 for the StartupOptions variable.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void Assign2ToStartupOptionsVar(object sender, EventArgs e)
        {
            if (StartNormal.Checked)
                ((Form1)Owner).OH.StartupOptions = 2;
        }

        /// <summary>
        /// Logic for assigning the value of 3 for the StartupOptions variable.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void Assign3ToStartupOptionsVar(object sender, EventArgs e)
        {
            if (StartMaximized.Checked)
                ((Form1)Owner).OH.StartupOptions = 3;
        }

        /// <summary>
        /// Creates the shortcut in the startup folder which ensures that the program runs at Windows startup
        /// </summary>
        private void CreateTheShortcut()
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

        /// <summary>
        /// Deletes the shortcut created in the Startup folder.
        /// </summary>
        /// <exception cref="FileNotFoundException">Thrown if the shortcut is not there (somebody deleted it before, as an example></exception>
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

        /// <summary>
        /// The logic behind deciding if the program runs with Windows or not.
        /// </summary>
        /// <param name="enable">true if the program runs with Windows.</param>
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

        /// <summary>
        /// Chooses if the program should run with Windows startup, based on the WindowsStartup variable.
        /// </summary>
        private void ChooseStartup()
        {
            if (((Form1)Owner).OH.WindowsStartup == 1)
                StartupEngine(true);
            else
                StartupEngine(false);
        }

        /// <summary>
        /// Saves the changes made to the options file.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void SaveChanges(object sender, EventArgs e)
        {
            ((Form1)Owner).OH.SaveOptionsToFile();
            ChooseStartup();
            ((Form1)Owner).DownloadNewsTimer.Enabled = ((Form1)Owner).SetAutomaticDownloadTimerEngine(((Form1)Owner).OH.NewsDownloadAtInterval);
            Close();
        }

        /// <summary>
        /// Checks or unchecks the "Start with Windows" checkbox.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void StartWithWindowsToggle(object sender, EventArgs e)
        {
            ((Form1)Owner).OH.WindowsStartup = (StartWithWindowsCheckBox.Checked ? 1 : 0);
        }

        /// <summary>
        /// Checks or unchecks the "Minimize to Notification Area" checkbox.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void MinimizeToTrayToggle(object sender, EventArgs e)
        {
            ((Form1)Owner).OH.MinimizeToTray = (MinimizeToTrayCheckBox.Checked ? 1 : 0);
        }

        /// <summary>
        /// Checks or unchecks the "Disable news sources with invalid RSS files" checkbox.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void DisableNewsSourcesToggle(object sender, EventArgs e)
        {
            ((Form1)Owner).OH.DisableInvalidNewsFiles = (DisableBadSources.Checked ? 1 : 0);
        }

        /// <summary>
        /// Checks or unchecks the "Download news automatically when program starts" checkbox.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void DownloadAtStartupToggle(object sender, EventArgs e)
        {
            ((Form1)Owner).OH.NewsDownloadAtStartup = (DownloadNewsAtStartup.Checked ? 1 : 0);
        }

        /// <summary>
        /// Closes the options window.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Shows the options in the options window.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void ShowOptions(object sender, EventArgs e)
        {
            ShowOptionsInOptionsWindow();
        }

        /// <summary>
        /// Enables or disables the controls for setting the wait time between automatical news downloads.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void ToggleIntervalEnabling(object sender, EventArgs e)
        {
            DownlInterval.Enabled = AutomaticalDownload.Checked;
            NumericValue.Enabled = AutomaticalDownload.Checked;
            TimeInterval.Enabled = AutomaticalDownload.Checked;
            ((Form1)Owner).OH.NewsDownloadAtInterval = (AutomaticalDownload.Checked ? 1 : 0);
        }

        /// <summary>
        /// Adjusts the upper limit for selecting the numerical values.
        /// </summary>
        /// <remarks>These values are: 60 for seconds and 23 for hours.</remarks>
        private void AdjustSuperiorValues()
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

        /// <summary>
        /// Processing linked to selecting the units of measure for the time to wait between automatical downloads of the news.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void UnitSelectionEngine(object sender, EventArgs e)
        {
            AdjustSuperiorValues();
        }

        /// <summary>
        /// Assigns the IntervalNumber variable the value read from the NumericUpDown control.
        /// </summary>
        private void SetValueInOptionsStructure()
        {
            ((Form1)Owner).OH.IntervalNumber = (int)NumericValue.Value;
        }

        /// <summary>
        /// Event handler for setting the numerical value for duration between automatical news downloads.
        /// </summary>
        /// <param name="sender">The object that triggers the event.</param>
        /// <param name="e">The parameters used to trigger the event.</param>
        /// <remarks>Event handler.</remarks>
        private void AdjustingValueEngine(object sender, EventArgs e)
        {
            SetValueInOptionsStructure();
        }
    }
}
