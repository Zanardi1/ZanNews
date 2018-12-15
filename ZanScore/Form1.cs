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
            RSSTools R = new RSSTools("nba_rss.xml");
            if (R.CheckRSSFile())
                R.ReadRSSContent();
            InitializeComponent();
        }
    }
}
