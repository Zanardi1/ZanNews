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
        public string RSSVersion; //Versiunea de RSS folosita
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
        private string FileToProcess; //Retine numele fisierului care va fi descarcat si procesat. Va fi eliminat odata ce termin cu rescrierea rutinei de umplere a membrilor clasei cu informatiile din XML
        private List<string> FileContent = new List<string>(); //Retine liniile fisierului citit

        public RSSSourceData()
        {

        }

        public void LoadRSSFile(string FileToLoad)
        //Citeste numele fisierului RSS care va fi procesat
        {
            OnlineSource = FileToLoad;
        }

        public bool CheckRSSFile()
        //Verifica existenta fisierului RSS. Inca am dubii asupra utilitatii acestei functii
        {
            if (File.Exists(FileToProcess))
                return true;
            else
            {
                MessageBox.Show("Fisierul " + FileToProcess + " nu exista");
                return false;
            }
        }

        public List<string> ReadRSSContent()
        //Citeste continutul fisierului RSS
        {
            FileContent.Clear();
            string[] buffer = new string[] { }; //retine liniile citite din fisier
            buffer = File.ReadAllLines(FileToProcess);
            for (int i = 0; i < buffer.Length; i++)
                FileContent.Add(buffer[i]);
            return FileContent;
        }

        public bool ValidateRSSFile()
        //Valideaza fisierul RSS.
        //todo De gandit si de scris detaliile subrutinei
        {
            return true;
        }

        public void FillRSSData()
        //Ideea si metoda am luat-o de la: https://stackoverflow.com/questions/10399400/best-way-to-read-rss-feed-in-net-using-c-sharp
        {
            XmlReader reader = XmlReader.Create(OnlineSource);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            ChannelTitle = feed.Title.Text;
            ChannelDescription = feed.Description.Text;
            ChannelLink = feed.Links[feed.Links.Count - 1].Uri.ToString();
            //Category = feed.Categories[feed.Categories.Count-1].Name.ToString();
            Copyright = feed.Copyright.Text.ToString();
            Language = feed.Language.ToString();
            ManagingEditor = feed.Authors[feed.Authors.Count - 1].Email.ToString();
            PubDate = feed.LastUpdatedTime.ToString();
            foreach (SyndicationItem item in feed.Items)
            {
                NewsTitle.Add(item.Title.Text);
                NewsLink.Add(item.Links[0].Uri.ToString());
                NewsDescription.Add(item.Summary.Text);
            }
        }

        private void MakeNewsLengthEqual()
        //Procedura aceasta se asigura, la finalul fiecarei iteratii, ca cei trei vectori legati de stiri (titlu, URL si descriere) au aceeasi lungime. Desi e obligatoriu, exista RSS-uri la care lipseste macar unul dintre aceste trei caracteristici, fapt ce provoaca probleme la afisarea lor in program.
        //Compar fiecare caracteristica cu fiecare si, acolo unde intalnesc un sir mai mic, adaug un element gol.
        {
            if ((NewsLink.Count > NewsTitle.Count) || (NewsDescription.Count > NewsTitle.Count))
            {
                NewsTitle.Add("");
            }

            if ((NewsLink.Count < NewsTitle.Count) || (NewsLink.Count < NewsDescription.Count))
            {
                NewsLink.Add("");
            }

            if ((NewsLink.Count > NewsDescription.Count) || (NewsDescription.Count < NewsTitle.Count))
            {
                NewsDescription.Add("");
            }
        }

        public void DownloadRSSFile()
        {
            XmlDocument document = new XmlDocument();
            document.Load(OnlineSource);
            FileToProcess = Path.GetFileName(OnlineSource);
            FileToProcess = "RSS Files\\" + FileToProcess;
            if (!Directory.Exists("RSS Files\\"))
                Directory.CreateDirectory("RSS Files\\");
            document.Save(FileToProcess);
        }

        public void EmptyFields()
        {
            RSSVersion = String.Empty;
            ChannelTitle = String.Empty; ;
            ChannelLink = String.Empty;
            ChannelDescription = String.Empty;
            Category = String.Empty;
            Copyright = String.Empty;
            Language = String.Empty;
            PubDate = String.Empty;
            ManagingEditor = String.Empty;
            FileToProcess = String.Empty;
            OnlineSource = String.Empty;
            NewsDescription.Clear();
            NewsLink.Clear();
            NewsTitle.Clear();
        }
    }
}