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
            NewsSourcesCollection.ClearSources();
            NewsSourcesCollection.LoadSources();
            string[] URLList=NewsSourcesCollection.GetNewsURL();
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
        /* Liniile de cod scrise intre "//*" arata modalitatea de a citi numele si URL-ul sursei noi, introduse de catre utilizator. Deoarece acestea se afla intr-o alta fereastra si deoarece componentele sunt marcate cu private, metoda corecta de ajungere la acele valori este urmatoarea:
         1. Se cicleaza prin fiecare component al ferestrei;
         2. In cazul in care ajungem la un GroupBox, se cicleaza prin componentele acestuia
         3. In cazul in care o componenta din GroupBox are numele pe care il vreau eu, atunci citeste valoarea dorita

         E nevoie de doua ciclari, deoarece componentele din GroupBox sunt copii pentru acesta, iar GroupBox este copil pentru fereastra. In ambele cazuri, trebuie cautat ceea ce doresc prin toate componentele copil*/
        {
            AddSource A = new AddSource();
            string s = "", s2 = "";
            A.ShowDialog();
            if (A.DialogResult == DialogResult.OK) //*
            {
                foreach (Control c in A.Controls)
                {
                    if (c is GroupBox)
                        foreach (Control c2 in c.Controls)
                        {
                            if (c2.Name == "SourceNameText")
                                s = c2.Text;
                            else if (c2.Name == "SourceURLText")
                                s2 = c2.Text;
                        }
                } //*
                NewsSourcesCollection.AddNewSource(s, s2); //todo de reparat bug-ul de aici
                NewsSourcesCollection.SaveSources();
            }
        }

        private void ShowEditSourcesWindow(object sender, EventArgs e)
        {
            EditSources E = new EditSources();
            foreach (Control c in E.Controls)
                if (c is DataGridView)
                    NewsSourcesCollection.ShowNewsSourcesInDataGrid(c as DataGridView);
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
