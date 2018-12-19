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
            R.EmptyFields();
            dgNewsDetails.Rows.Clear();
            string[] URLList = new string[7];
            URLList[0] = "http://www.nba.com/rss/nba_rss.xml";
            URLList[1] = "https://www.uefa.com/rssfeed/news/rss.xml";
            URLList[2] = "https://www.uefa.com/rssfeed/uefachampionsleague/rss.xml";
            URLList[3] = "https://www.uefa.com/rssfeed/trainingground/calendar/news.xml";
            URLList[4] = "https://www.uefa.com/rssfeed/uefaeuropaleague/rss.xml";
            URLList[5] = "https://store.steampowered.com/feeds/news.xml";
            URLList[6] = "http://www.romaniatv.net/rss/stiri.xml";
            for (int i = 0; i < URLList.Length; i++)
            {
                R.LoadRSSFile(URLList[i]);
                R.DownloadRSSFile();
                R.ReadRSSContent();
                R.FillRSSData();
            }
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
