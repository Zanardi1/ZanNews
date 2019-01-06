using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace ZanScore
/*
O biblioteca ce contine toate functiile necesare prelucrarii unui fisier RSS:
1. Deschiderea unui fisier RSS;
2. Validarea acestuia;
3. Citirea si interpretarea lui;
4. Extragerea informatiilor din el si punerea lor in program;
5. 

 */

{
    class RSSSourceData
    //O clasa ce retine datele dintr-un fisier RSS. Detalii despre acesta sunt la https://www.w3schools.com/xml/xml_rss.asp.
    //todo Sa adaug si restul subcategoriilor din definitia unui fisier RSS, odata ce am o aplicatie functionala
    {
        public string ChannelTitle; //Titlul canalului
        public string ChannelLink; //Link catre URL-ul canalului
        public string ChannelDescription; //Descrierea canalului
        public string Category; //Categoria stirilor
        public string Copyright; //Informatii despre copyright
        public string Language; //Limba in care sunt scrise stirile
        public string PubDate; //Data publicarii stirii
        public string ManagingEditor; //E-mailul editorului continutului fisierului RSS
        public List<string> NewsTitle = new List<string>(); //Titlurile stirilor
        public List<string> NewsLink = new List<string>(); //Link-urile catre stiri
        public List<string> NewsDescription = new List<string>(); //Descrierile stirilor

        private string OnlineSource; //Retine numele fisierului XML original, aflat pe internet

        public RSSSourceData()
        {

        }

        public bool ValidateRSSFile()
        //Valideaza fisierul RSS.
        //todo De gandit si de scris detaliile subrutinei
        {
            return true;
        }

        public void FillRSSData(string FileToLoad)
        //Ideea si metoda am luat-o de la: https://stackoverflow.com/questions/10399400/best-way-to-read-rss-feed-in-net-using-c-sharp
        {
            XmlReader reader = XmlReader.Create(FileToLoad);
            SyndicationFeed feed = new SyndicationFeed();

            try
            {
                feed = SyndicationFeed.Load(reader);
            }
            catch (XmlException e)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show("Error reading file " + e.SourceUri + ". File format unknown. Program will go to the next news source", "Error loading news source file", buttons, icon);
                return;
            }

            reader.Close();

            if (feed.Title == null)
                ChannelTitle = "";
            else
                ChannelTitle = feed.Title.Text.ToString();

            if (feed.Description == null)
                ChannelDescription = "";
            else
                ChannelDescription = feed.Description.Text.ToString();

            if (feed.Links.Count == 0)
                ChannelLink = "";
            else
                ChannelLink = feed.Links[feed.Links.Count - 1].Uri.ToString();

            if (feed.Categories.Count == 0)
                Category = "";
            else
                Category = feed.Categories[feed.Categories.Count - 1].Name.ToString();

            if (feed.Copyright == null)
                Copyright = "";
            else
                Copyright = feed.Copyright.Text.ToString();

            if (feed.Language == null)
                Language = "";
            else
                Language = feed.Language.ToString();

            if (feed.Authors.Count == 0)
                ManagingEditor = "";
            else
                ManagingEditor = feed.Authors[feed.Authors.Count - 1].Email.ToString();

            if (feed.LastUpdatedTime == null)
                PubDate = "";
            else
                PubDate = feed.LastUpdatedTime.ToString();

            foreach (SyndicationItem item in feed.Items)
            {
                if (item.Title == null)
                    NewsTitle.Add("");
                else
                    NewsTitle.Add(item.Title.Text);

                if (item.Links[0].Uri.ToString() == null)
                    NewsLink.Add("");
                else
                    NewsLink.Add(item.Links[0].Uri.ToString());

                if (item.Summary == null)
                    NewsDescription.Add("");
                else
                    NewsDescription.Add(item.Summary.Text);
            }
            reader.Dispose();
        }

        public void EmptyFields()
        {
            ChannelTitle = String.Empty;
            ChannelLink = String.Empty;
            ChannelDescription = String.Empty;
            Category = String.Empty;
            Copyright = String.Empty;
            Language = String.Empty;
            PubDate = String.Empty;
            ManagingEditor = String.Empty;
            OnlineSource = String.Empty;
            NewsDescription.Clear();
            NewsLink.Clear();
            NewsTitle.Clear();
        }
    }
}