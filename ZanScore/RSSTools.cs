using System;
using System.Windows;
using System.Windows.Forms;
using System.IO;

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
    class RSSData
    //O clasa ce retine datele dintr-un fisier RSS. Detalii despre acesta sunt la https://www.w3schools.com/xml/xml_rss.asp.
    //Deoarece aceste campuri sunt citire dintr-un fisier, toti membrii acestei structuri sunt readonly
    //todo: Sa adaug si restul subcategoriilor, odata ce am o aplicatie functionala
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
        public string[] NewsTitle = new string[] { }; //Titlurile stirilor
        public string[] NewsLink = new string[] { }; //Link-urile catre stiri
        public string[] NewsDescription = new string[] { }; //Descrierile stirilor

        private readonly string FileToProcess; //Retine numele fisierului care va fi procesat
        private string[] FileContent; //Retine liniile fisierului citit
        private int i; //Numarator intern

        public RSSData(string File)
        {
            RSSVersion = "";
            ChannelTitle = "";
            ChannelLink = "";
            ChannelDescription = "";
            Category = "";
            Copyright = "";
            Language = "";
            PubDate = "";
            ManagingEditor = "";
            for (i = 0; i < NewsTitle.Length; i++)
                NewsTitle[i] = "";
            for (i = 0; i < NewsLink.Length; i++)
                NewsLink[i] = "";
            for (i = 0; i < NewsDescription.Length; i++)
                NewsDescription[i] = "";
            FileToProcess = File;
        }

        public bool CheckRSSFile()
        {
            if (File.Exists(FileToProcess))
                return true;
            else
            {
                MessageBox.Show("Fisierul " + FileToProcess + " nu exista");
                return false;
            }
        }

        public string[] ReadRSSContent()
        //Citeste continutul fisierului RSS
        {
            FileContent = File.ReadAllLines(FileToProcess);
            return FileContent;
        }

        public bool ValidateRSSFile()
        //Valideaza fisierul RSS. 
        //todo: De gandit si de scris detaliile subrutinei
        {
            return true;
        }

        public void FillRSSData()
        {
            for (int i = 0; i <= FileContent.Length - 1; i++) //Verifica fiecare rand pentru a vedea ce informatii sunt. Apoi le clasifica unde trebuie
            {
                if (FileContent[i].Contains("<rss")) //Contine versiunea de RSS
                {
                    RSSVersion = FileContent[i];
                    RSSVersion = RSSVersion.Remove(RSSVersion.IndexOf("<"), RSSVersion.IndexOf("\"") + 1);
                    RSSVersion = RSSVersion.Remove(RSSVersion.IndexOf("\""), 2);
                }

                if (FileContent[i].Contains("<channel>")) //Daca avem un canal
                {
                    //Nimic momentan
                }

                if (FileContent[i].Contains("</channel>"))
                {
                    //Nimic momentan
                }

                bool IsNews = false;
                //Campurile obligatorii, title, link si description, pot fi atata la canal cat si la o stire. IsItem retine daca am inceput prelucrarea unei stiri, nu a unui canal. Daca IsItem este adevarata, atunci prelucrez o stire, altfel prelucrez canalul.
                if (FileContent[i].Contains("<item>"))
                {
                    IsNews = true;
                }

                if (FileContent[i].Contains("</item>"))
                {
                    IsNews = false;
                }

                if (FileContent[i].Contains("<title>"))
                {
                    if (IsNews) //Titlu de stire

                    {
                        //todo: De perfectionat ramura asta
                    }

                    else //Titlu de canal
                    {
                        ChannelTitle = FileContent[i];
                        ChannelTitle = ChannelTitle.Remove(ChannelTitle.IndexOf("<"), ChannelTitle.IndexOf(">") + 1);
                        ChannelTitle = ChannelTitle.Remove(ChannelTitle.IndexOf("<"), 8);
                    }
                }

                if (FileContent[i].Contains("<link>"))
                {
                    if (IsNews) //Link-ul stirii
                    {
                        //todo: De lucrat la varianta asta
                    }

                    else //Link-ul canalului
                    {
                        ChannelLink = FileContent[i];
                        ChannelLink = ChannelLink.Remove(ChannelLink.IndexOf("<"), ChannelLink.IndexOf(">") + 1);
                        ChannelLink = ChannelLink.Remove(ChannelLink.IndexOf("<"), 7);
                    }
                }

                if (FileContent[i].Contains("<description>"))
                {
                    if (IsNews) //Descrierea stirii
                    {
                        //todo: De lucrat la varianta asta
                    }

                    else //Descrierea canalului
                    {
                        ChannelDescription = FileContent[i];
                        ChannelDescription = ChannelDescription.Remove(ChannelDescription.IndexOf("<"), ChannelDescription.IndexOf(">") + 1);
                        ChannelDescription = ChannelDescription.Remove(ChannelDescription.IndexOf("<"), 14);
                    }
                }

                if (FileContent[i].Contains("<copyright>"))
                {
                    Copyright = FileContent[i];
                    Copyright = Copyright.Remove(Copyright.IndexOf("<"), Copyright.IndexOf(">") + 1);
                    Copyright = Copyright.Remove(Copyright.IndexOf("<"), 12);
                }

                if (FileContent[i].Contains("<managingEditor>"))
                {
                    ManagingEditor = FileContent[i];
                    ManagingEditor = ManagingEditor.Remove(ManagingEditor.IndexOf("<"), ManagingEditor.IndexOf(">") + 1);
                    ManagingEditor = ManagingEditor.Remove(ManagingEditor.IndexOf("<"), 17);
                }

                if (FileContent[i].Contains("<language>"))
                {
                    Language = FileContent[i];
                    Language = Language.Remove(Language.IndexOf("<"), Language.IndexOf(">") + 1);
                    Language = Language.Remove(Language.IndexOf("<"), 11);
                }

                if (FileContent[i].Contains("<pubDate>"))
                {
                    PubDate = FileContent[i];
                    PubDate = PubDate.Remove(PubDate.IndexOf("<"), PubDate.IndexOf(">") + 1);
                    PubDate = PubDate.Remove(PubDate.IndexOf("<"), 10);
                }
            }
        }
    }
}