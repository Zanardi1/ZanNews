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
    public partial class Form1 : Form
    {
        public Form1()
        {
            RSSData R = new RSSData("nba_rss.xml");
            if (R.CheckRSSFile())
            {
                R.DownloadRSSFile();
                R.ReadRSSContent();
                R.FillRSSData();
            }
            InitializeComponent();
        }
    }
}
