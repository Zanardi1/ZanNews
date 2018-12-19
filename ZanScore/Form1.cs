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
        RSSData R = new RSSData();
        public Form1()
        {
            InitializeComponent();
        }

        private void DownloadNews(object sender, EventArgs e)
        {
            R.LoadRSSFile("http://www.nba.com/rss/nba_rss.xml");
            R.DownloadRSSFile();
            R.ReadRSSContent();
            R.FillRSSData();
            FillGrid();
        }

        private void FillGrid()
        //Umple tabelul cu stirile citite
        {
            for (int i = 0; i < R.NewsTitle.Length; i++)
            {
                dgNewsDetails.Rows.Add();
                dgNewsDetails.Rows[i].Cells[0].Value = R.NewsTitle[i];
                dgNewsDetails.Rows[i].Cells[1].Value = R.NewsLink[i];
                dgNewsDetails.Rows[i].Cells[2].Value = R.NewsDescription[i];
            }
        }

        private void LoadNewsURL(object sender, DataGridViewCellEventArgs e)
        {
            wbNewsWebPage.Navigate(new Uri(R.NewsLink[dgNewsDetails.CurrentCell.RowIndex]));
        }
    }
}
