﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;

//todo de facut rutina pentru redimensionarea componentelor odata cu fereastra

namespace ZanScore
{
    public partial class Form1 : Form
    {
        RSSSourceData NewsSourceData = new RSSSourceData();
        public RSSSourcesLibrary NewsSourcesCollection = new RSSSourcesLibrary();

        public Form1()
        {
            InitializeComponent();
            StatusLabel.Text = "Welcome";
        }

        private void DownloadAllNews(object sender, EventArgs e)
        {
            DownloadProgressBar.Maximum = NewsSourcesCollection.IsSourceSelected.Count;
            NewsSourceData.EmptyFields();
            NewsDetails.Rows.Clear();
            NewsSourcesCollection.ClearSources();
            NewsSourcesCollection.LoadSources();
            List<string> URLList = new List<string>();
            URLList = NewsSourcesCollection.GetNewsURL();
            Cursor.Current = Cursors.WaitCursor;
            StatusLabel.Text = "Downloading RSS...";
            for (int i = 0; i < URLList.Count; i++)
            {
                if (NewsSourcesCollection.IsSourceSelected[i])
                {
                    NewsSourceData.FillRSSData(URLList[i]);
                    DownloadProgressBar.Value++;
                }
            }
            StatusLabel.Text = "Download complete";
            Cursor.Current = Cursors.Arrow;
            FillGrid();
        }

        private void FillGrid()
        //Umple tabelul cu stirile citite
        {
            for (int i = 0; i < NewsSourceData.NewsTitle.Count; i++)
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
            SelectSourcesWindow S = new SelectSourcesWindow();
            S.ShowDialog(owner: this);
            if (S.DialogResult == DialogResult.OK)
                NewsSourcesCollection.SaveSources();
        }

        private void ShowAddNewsSourcesWindow(object sender, EventArgs e)
        /* Liniile de cod scrise intre "//*" arata modalitatea de a citi numele si URL-ul sursei noi, introduse de catre utilizator. Deoarece acestea se afla intr-o alta fereastra si deoarece componentele sunt marcate cu private, metoda corecta de ajungere la acele valori este urmatoarea:
         1. Se cicleaza prin fiecare component al ferestrei;
         2. In cazul in care ajungem la un GroupBox, se cicleaza prin componentele acestuia
         3. In cazul in care o componenta din GroupBox are numele pe care il vreau eu, atunci citeste valoarea dorita

         E nevoie de doua ciclari, deoarece componentele din GroupBox sunt copii pentru acesta, iar GroupBox este copil pentru fereastra. In ambele cazuri, trebuie cautat ceea ce doresc prin toate componentele copil*/
        {
            AddSourceWindow A = new AddSourceWindow();
            string s = "", s2 = "";
            A.ShowDialog(this);
            if (A.DialogResult == DialogResult.OK) //*
            {
                s = A.NewName;
                s2 = A.NewURL;

                NewsSourcesCollection.AddNewSource(s, s2);
                NewsSourcesCollection.SaveSources();
            }
        }

        private void ShowEditSourcesWindow(object sender, EventArgs e)
        {
            EditSourcesWindow E = new EditSourcesWindow();
            foreach (Control c in E.Controls)
                if (c is DataGridView)
                    NewsSourcesCollection.ShowNewsSourcesInDataGrid(c as DataGridView);
            E.ShowDialog(owner: this);
            if (E.DialogResult == DialogResult.OK)
                NewsSourcesCollection.SaveSources();
        }

        private void ShowOptionsWindow(object sender, EventArgs e)
        {
            OptionsWindow O = new OptionsWindow();
            O.ShowDialog();
        }

        private void ShowAboutBoxWindow(object sender, EventArgs e)
        {
            AboutBox A = new AboutBox();
            A.ShowDialog();
        }

        private void DisplayDownloadHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Options for downloading from news sources";
        }

        private void DisplayNewsSourcesHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "News sources management";
        }

        private void DisplayAllHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Download from all selected news sources";
        }

        private void DisplaySelectedHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Select the news sources that will be downloaded";
        }

        private void DisplayAddHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Add a new news source";
        }

        private void DisplayEditHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Edit, delete or reorder news sources";
        }

        private void DisplayOptionsHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "Options for customizing ZanNews";
        }

        private void DisplayAboutBoxHelpMessage(object sender, EventArgs e)
        {
            StatusLabel.Text = "About ZanNews";
        }
    }
}
