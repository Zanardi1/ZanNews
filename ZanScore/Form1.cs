using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//todo de facut rutina pentru redimensionarea componentelor odata cu fereastra

namespace ZanScore
{
    public partial class Form1 : Form
    {
        RSSData NewsSourceData = new RSSData();
        RSSSources NewsSourcesCollection = new RSSSources();

        public Form1()
        {
            InitializeComponent();
            StatusLabel.Text = "Welcome";
        }

        private void DownloadAllNews(object sender, EventArgs e)
        {
            NewsSourceData.EmptyFields();
            NewsDetails.Rows.Clear();
            string[] URLList = new string[7];
            URLList[0] = "http://www.nba.com/rss/nba_rss.xml";
            URLList[1] = "https://www.uefa.com/rssfeed/news/rss.xml";
            URLList[2] = "https://www.uefa.com/rssfeed/uefachampionsleague/rss.xml";
            URLList[3] = "https://www.uefa.com/rssfeed/trainingground/calendar/news.xml";
            URLList[4] = "https://www.uefa.com/rssfeed/uefaeuropaleague/rss.xml";
            URLList[5] = "https://store.steampowered.com/feeds/news.xml";
            URLList[6] = "http://www.romaniatv.net/rss/stiri.xml";
            Cursor.Current = Cursors.WaitCursor;
            StatusLabel.Text = "Downloading RSS...";
            for (int i = 0; i < URLList.Length; i++)
            {
                NewsSourceData.LoadRSSFile(URLList[i]);
                NewsSourceData.DownloadRSSFile();
                NewsSourceData.ReadRSSContent();
                NewsSourceData.FillRSSData();
            }
            StatusLabel.Text = "Download complete";
            Cursor.Current = Cursors.Arrow;
            FillGrid();
        }

        private void FillGrid()
        //Umple tabelul cu stirile citite
        {
            for (int i = 0; i < NewsSourceData.NewsTitle.Length; i++)
            {
                NewsDetails.Rows.Add();
                NewsDetails.Rows[i].Cells[0].Value = NewsSourceData.NewsTitle[i];
                NewsDetails.Rows[i].Cells[1].Value = NewsSourceData.NewsLink[i];
                NewsDetails.Rows[i].Cells[2].Value = NewsSourceData.NewsDescription[i];
            }
        }

        private void LoadNewsURL(object sender, DataGridViewCellEventArgs e)
        {
            NewsWebPage.Navigate(new Uri(NewsSourceData.NewsLink[NewsDetails.CurrentCell.RowIndex]));
        }

        private void SelectNewsSources(object sender, EventArgs e)
        {
            SelectSource S = new SelectSource();
            S.ShowDialog();
        }

        private void ShowAddNewsSourcesWindow(object sender, EventArgs e)
        {
            AddSource A = new AddSource();
            string s="", s2="";
            A.ShowDialog();
            if (A.DialogResult == DialogResult.OK)
            {
                foreach (Control c in A.Controls)
                {
                    if (c.Name == "SourceNameText")
                        s = c.Text;
                    if (c.Name == "SourceNameURL")
                        s2 = c.Text;
                }
                NewsSourcesCollection.AddNewSource(s, s2); //todo de reparat bug-ul de aici
                NewsSourcesCollection.SaveSources();
            }
        }

        private void ShowEditSourcesWindow(object sender, EventArgs e)
        {
            EditSources E = new EditSources();
            E.ShowDialog();
        }

        private void ShowOptionsWindow(object sender, EventArgs e)
        {
            Options O = new Options();
            O.ShowDialog();
        }

        private void ShowAboutBoxWindow(object sender, EventArgs e)
        {
            AboutBox A = new AboutBox();
            A.ShowDialog();
        }
    }
}
