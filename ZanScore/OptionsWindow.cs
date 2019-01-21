using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZanScore
{
    public partial class OptionsWindow : Form
    {
        OptionsHandling O = new OptionsHandling();

        public OptionsWindow()
        {
            InitializeComponent();
            ShowOptionsInOptionsWindow();
        }

        private void ShowOptionsInOptionsWindow()
        {
            StartWithWindowsCheckBox.Checked = (O.WindowsStartup == 1 ? true : false);
            MinimizeToTrayCheckBox.Checked = (O.MinimizeToTray == 1 ? true : false);
            DisableBadSources.Checked = (O.DisableInvalidNewsFiles == 1 ? true : false);
            DownloadNewsAtStartup.Checked = (O.AutomaticNewsDownload == 1 ? true : false);
            switch (O.StartupOptions)
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
                O.StartupOptions = 1;
        }

        private void Assign2ToVar(object sender, EventArgs e)
        {
            if (StartNormal.Checked)
                O.StartupOptions = 2;
        }

        private void Assign3ToVar(object sender, EventArgs e)
        {
            if (StartMaximized.Checked)
                O.StartupOptions = 3;
        }
    }
}
