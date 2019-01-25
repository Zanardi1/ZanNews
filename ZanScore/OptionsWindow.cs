using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ZanScore
{
    public partial class OptionsWindow : Form
    {
        RegistryKey Key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true); //retine registrul care se ocupa de rularea odata cu Windows-ul a aplicatiei

        public OptionsWindow()
        {
            InitializeComponent();
        }

        private void ShowOptionsInOptionsWindow()
        {
            StartWithWindowsCheckBox.Checked = (((Form1)Owner).OH.WindowsStartup == 1 ? true : false);
            MinimizeToTrayCheckBox.Checked = (((Form1)Owner).OH.MinimizeToTray == 1 ? true : false);
            DisableBadSources.Checked = (((Form1)Owner).OH.DisableInvalidNewsFiles == 1 ? true : false);
            DownloadNewsAtStartup.Checked = (((Form1)Owner).OH.AutomaticNewsDownload == 1 ? true : false);
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

        private void EnableWindowsStartup()
        {
            Key.SetValue("ZanNews", Application.ExecutablePath);
        }

        private void DisableWindowsStartup()
        {
            Key.DeleteValue("ZanNews", false);
        }

        private void SwitchWindowsStartupMode()
        {
            if (((Form1)Owner).OH.WindowsStartup == 1)
                EnableWindowsStartup();
            else
                DisableWindowsStartup();
        }

        private void SaveChanges(object sender, EventArgs e)
        {
            ((Form1)Owner).OH.SaveOptionsToFile();
            SwitchWindowsStartupMode();
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
            ((Form1)Owner).OH.AutomaticNewsDownload = (DownloadNewsAtStartup.Checked ? 1 : 0);
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowOptions(object sender, EventArgs e)
        {
            ShowOptionsInOptionsWindow();
        }
    }
}
