using System;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Xml;

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
        public string[] NewsTitle = new string[] { }; //Titlurile stirilor
        public string[] NewsLink = new string[] { }; //Link-urile catre stiri
        public string[] NewsDescription = new string[] { }; //Descrierile stirilor

        private string OnlineSource; //Retine numele fisierului XML original, aflat pe internet
        private string FileToProcess; //Retine numele fisierului care va fi descarcat si procesat
        private string[] FileContent; //Retine liniile fisierului citit
        private readonly int i; //Numarator intern

        public RSSData()
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
            FileToProcess = "";
            OnlineSource = "";
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

        public string[] ReadRSSContent()
        //Citeste continutul fisierului RSS
        {
            FileContent = File.ReadAllLines(FileToProcess);
            return FileContent;
        }

        public bool ValidateRSSFile()
        //Valideaza fisierul RSS.
        //todo De gandit si de scris detaliile subrutinei
        {
            return true;
        }

        public void FillRSSData()
        //Umple proprietatile clasei cu informatiile necesare
        //todo Bug: atunci cand in RSS, textul dintre <description> si </description> e pe 2+ randuri, rutina imi afiseaza un mesaj de eroare, caci da peste cap indecsii din sirurile de caractere citite din fisier
        {
            bool IsNews = false;
            //Campurile obligatorii, title, link si description, pot fi atata la canal cat si la o stire. IsItem retine daca am inceput prelucrarea unei stiri, nu a unui canal. Daca IsItem este adevarata, atunci prelucrez o stire, altfel prelucrez canalul.
            for (int i = 0; i <= FileContent.Length - 1; i++) //Verifica fiecare rand pentru a vedea ce informatii sunt. Apoi le clasifica unde trebuie
            {
                if (FileContent[i].Contains("<rss")) //Contine versiunea de RSS
                {
                    RSSVersion = FileContent[i].Trim();
                    RSSVersion = RSSVersion.Remove(RSSVersion.IndexOf("<"), RSSVersion.IndexOf("\"") + 1);
                    RSSVersion = RSSVersion.Remove(RSSVersion.IndexOf("\""), RSSVersion.Length - RSSVersion.IndexOf("\""));
                }

                if (FileContent[i].Contains("<channel>")) //Daca avem un canal
                {
                    //Nimic momentan
                }

                if (FileContent[i].Contains("</channel>"))
                {
                    //Nimic momentan
                }

                if (FileContent[i].Contains("<item"))
                {
                    IsNews = true;
                }

                if (FileContent[i].Contains("</item"))
                {
                    IsNews = false;
                    MakeNewsLengthEqual();
                }

                if (FileContent[i].Contains("<title>"))
                {
                    if (IsNews) //Titlu de stire
                    {
                        Array.Resize(ref NewsTitle, NewsTitle.Length + 1);
                        NewsTitle[NewsTitle.Length - 1] = FileContent[i].Trim();
                        if (NewsTitle[NewsTitle.Length - 1].Contains("CDATA")) //Daca titlul are si eticheta CDATA
                        {
                            NewsTitle[NewsTitle.Length - 1] = NewsTitle[NewsTitle.Length - 1].Remove(NewsTitle[NewsTitle.Length - 1].IndexOf("<"), 16);
                            if (NewsTitle[NewsTitle.Length - 1].Length != 0) //Daca eticheta nu are continut, ci doar <title></title>
                                NewsTitle[NewsTitle.Length - 1] = NewsTitle[NewsTitle.Length - 1].Remove(NewsTitle[NewsTitle.Length - 1].IndexOf("]"), NewsTitle[NewsTitle.Length - 1].Length - NewsTitle[NewsTitle.Length - 1].IndexOf("]"));
                        }
                        else
                        {
                            NewsTitle[NewsTitle.Length - 1] = NewsTitle[NewsTitle.Length - 1].Remove(NewsTitle[NewsTitle.Length - 1].IndexOf("<"), NewsTitle[NewsTitle.Length - 1].IndexOf(">") + 1);
                            if (NewsTitle[NewsTitle.Length - 1].Length != 0)
                                NewsTitle[NewsTitle.Length - 1] = NewsTitle[NewsTitle.Length - 1].Remove(NewsTitle[NewsTitle.Length - 1].IndexOf("<"), NewsTitle[NewsTitle.Length - 1].Length - NewsTitle[NewsTitle.Length - 1].IndexOf("<"));
                        }
                    }
                    else //Titlu de canal
                    {
                        ChannelTitle = FileContent[i].Trim();
                        ChannelTitle = ChannelTitle.Remove(ChannelTitle.IndexOf("<"), ChannelTitle.IndexOf(">") + 1);
                        if (ChannelTitle.Length != 0)
                            ChannelTitle = ChannelTitle.Remove(ChannelTitle.IndexOf("<"), ChannelTitle.Length - ChannelTitle.IndexOf("<"));
                    }
                }

                if (FileContent[i].Contains("<link>"))
                {
                    if (IsNews) //Link-ul stirii
                    {
                        Array.Resize(ref NewsLink, NewsLink.Length + 1);
                        NewsLink[NewsLink.Length - 1] = FileContent[i].Trim();
                        if (NewsLink[NewsLink.Length - 1].Contains("CDATA")) //Daca link-ul catre stire are si eticheta CDATA
                        {
                            NewsLink[NewsLink.Length - 1] = NewsLink[NewsLink.Length - 1].Remove(NewsLink[NewsLink.Length - 1].IndexOf("<"), 15);
                            if (NewsLink[NewsLink.Length - 1].Length != 0)
                                NewsLink[NewsLink.Length - 1] = NewsLink[NewsLink.Length - 1].Remove(NewsLink[NewsLink.Length - 1].IndexOf("]"), NewsLink[NewsLink.Length - 1].Length - NewsLink[NewsLink.Length - 1].IndexOf("]"));
                        }
                        else
                        {
                            NewsLink[NewsLink.Length - 1] = NewsLink[NewsLink.Length - 1].Remove(NewsLink[NewsLink.Length - 1].IndexOf("<"), NewsLink[NewsLink.Length - 1].IndexOf(">") + 1);
                            if (NewsLink[NewsLink.Length - 1].Length != 0)
                                NewsLink[NewsLink.Length - 1] = NewsLink[NewsLink.Length - 1].Remove(NewsLink[NewsLink.Length - 1].IndexOf("<"), NewsLink[NewsLink.Length - 1].Length - NewsLink[NewsLink.Length - 1].IndexOf("<"));
                        }
                    }

                    else //Link-ul canalului
                    {
                        ChannelLink = FileContent[i].Trim();
                        ChannelLink = ChannelLink.Remove(ChannelLink.IndexOf("<"), ChannelLink.IndexOf(">") + 1);
                        if (ChannelLink.Length != 0)
                            ChannelLink = ChannelLink.Remove(ChannelLink.IndexOf("<"), ChannelLink.Length - ChannelLink.IndexOf("<"));
                    }
                }

                if (FileContent[i].Contains("<description>"))
                {
                    if (IsNews) //Descrierea stirii
                    {
                        Array.Resize(ref NewsDescription, NewsDescription.Length + 1);
                        NewsDescription[NewsDescription.Length - 1] = FileContent[i].Trim();
                        if (NewsDescription[NewsDescription.Length - 1].Contains("CDATA"))
                        {
                            NewsDescription[NewsDescription.Length - 1] = NewsDescription[NewsDescription.Length - 1].Remove(NewsDescription[NewsDescription.Length - 1].IndexOf("<"), 22);
                            if (NewsDescription[NewsDescription.Length - 1].Length != 0)
                                NewsDescription[NewsDescription.Length - 1] = NewsDescription[NewsDescription.Length - 1].Remove(NewsDescription[NewsDescription.Length - 1].IndexOf("]"), NewsDescription[NewsDescription.Length - 1].Length - NewsDescription[NewsDescription.Length - 1].IndexOf("]"));
                        }
                        else
                        {
                            NewsDescription[NewsDescription.Length - 1] = NewsDescription[NewsDescription.Length - 1].Remove(NewsDescription[NewsDescription.Length - 1].IndexOf("<"), NewsDescription[NewsDescription.Length - 1].IndexOf(">") + 1);
                            if (NewsDescription[NewsDescription.Length - 1].Length != 0)
                                NewsDescription[NewsDescription.Length - 1] = NewsDescription[NewsDescription.Length - 1].Remove(NewsDescription[NewsDescription.Length - 1].IndexOf("<"), NewsDescription[NewsDescription.Length - 1].Length - NewsDescription[NewsDescription.Length - 1].IndexOf("<"));
                        }
                    }

                    else //Descrierea canalului
                    {
                        ChannelDescription = FileContent[i].Trim();
                        ChannelDescription = ChannelDescription.Remove(ChannelDescription.IndexOf("<"), ChannelDescription.IndexOf(">") + 1);
                        if (ChannelDescription.Length != 0)
                            ChannelDescription = ChannelDescription.Remove(ChannelDescription.IndexOf("<"), ChannelDescription.Length - ChannelDescription.IndexOf("<"));
                    }
                }

                if (FileContent[i].Contains("<copyright>"))
                {
                    Copyright = FileContent[i].Trim();
                    Copyright = Copyright.Remove(Copyright.IndexOf("<"), Copyright.IndexOf(">") + 1);
                    if (Copyright.Length != 0)
                        Copyright = Copyright.Remove(Copyright.IndexOf("<"), Copyright.Length - Copyright.IndexOf("<"));
                }

                if (FileContent[i].Contains("<managingEditor>"))
                {
                    ManagingEditor = FileContent[i].Trim();
                    ManagingEditor = ManagingEditor.Remove(ManagingEditor.IndexOf("<"), ManagingEditor.IndexOf(">") + 1);
                    if (ManagingEditor.Length != 0)
                        ManagingEditor = ManagingEditor.Remove(ManagingEditor.IndexOf("<"), ManagingEditor.Length - ManagingEditor.IndexOf("<"));
                }

                if (FileContent[i].Contains("<language>"))
                {
                    Language = FileContent[i].Trim();
                    Language = Language.Remove(Language.IndexOf("<"), Language.IndexOf(">") + 1);
                    if (Language.Length != 0)
                        Language = Language.Remove(Language.IndexOf("<"), Language.Length - Language.IndexOf("<"));
                }

                if (FileContent[i].Contains("<pubDate>"))
                {
                    PubDate = FileContent[i].Trim();
                    PubDate = PubDate.Remove(PubDate.IndexOf("<"), PubDate.IndexOf(">") + 1);
                    if (PubDate.Length != 0)
                        PubDate = PubDate.Remove(PubDate.IndexOf("<"), PubDate.Length - PubDate.IndexOf("<"));
                }
            }
        }

        private void MakeNewsLengthEqual()
        //Procedura aceasta se asigura, la finalul fiecarei iteratii, ca cei trei vectori legati de stiri (titlu, URL si descriere) au aceeasi lungime. Desi e obligatoriu, exista RSS-uri la care lipseste macar unul dintre aceste trei caracteristici, fapt ce provoaca probleme la afisarea lor in program.
        //Compar fiecare caracteristica cu fiecare si, acolo unde intalnesc un sir mai mic, adaug un element gol.
        {
            if (NewsLink.Length > NewsTitle.Length)
            {
                Array.Resize(ref NewsTitle, NewsTitle.Length + 1);
                NewsTitle[NewsTitle.Length - 1] = "";
            }

            if (NewsLink.Length < NewsTitle.Length)
            {
                Array.Resize(ref NewsLink, NewsLink.Length + 1);
                NewsLink[NewsLink.Length - 1] = "";
            }

            if (NewsLink.Length > NewsDescription.Length)
            {
                Array.Resize(ref NewsDescription, NewsDescription.Length + 1);
                NewsDescription[NewsDescription.Length - 1] = "";
            }

            if (NewsLink.Length < NewsDescription.Length)
            {
                Array.Resize(ref NewsLink, NewsLink.Length + 1);
                NewsLink[NewsLink.Length - 1] = "";
            }

            if (NewsDescription.Length > NewsTitle.Length)
            {
                Array.Resize(ref NewsTitle, NewsTitle.Length);
                NewsTitle[NewsTitle.Length - 1] = "";
            }

            if (NewsDescription.Length < NewsTitle.Length)
            {
                Array.Resize(ref NewsDescription, NewsDescription.Length + 1);
                NewsDescription[NewsDescription.Length - 1] = "";
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
            RSSVersion = "";
            ChannelTitle = "";
            ChannelLink = "";
            ChannelDescription = "";
            Category = "";
            Copyright = "";
            Language = "";
            PubDate = "";
            ManagingEditor = "";
            FileToProcess = "";
            OnlineSource = "";
            NewsDescription = Array.Empty<string>();
            NewsLink = Array.Empty<string>();
            NewsTitle = Array.Empty<string>();
        }
    }
}