using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

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

        public void FillRSSDataOld()
        //Umple proprietatile clasei cu informatiile necesare

        {
            bool IsNews = false;
            //Campurile obligatorii, title, link si description, pot fi atata la canal cat si la o stire. IsItem retine daca am inceput prelucrarea unei stiri, nu a unui canal. Daca IsItem este adevarata, atunci prelucrez o stire, altfel prelucrez canalul.
            for (int i = 0; i <= FileContent.Count - 1; i++) //Verifica fiecare rand pentru a vedea ce informatii sunt. Apoi le clasifica unde trebuie
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
                        NewsTitle.Add(FileContent[i].Trim());
                        if (NewsTitle[NewsTitle.Count - 1].Contains("CDATA")) //Daca titlul are si eticheta CDATA
                        {
                            NewsTitle[NewsTitle.Count - 1] = NewsTitle[NewsTitle.Count - 1].Remove(NewsTitle[NewsTitle.Count - 1].IndexOf("<"), 16);
                            if (NewsTitle[NewsTitle.Count - 1].Length != 0) //Daca eticheta nu are continut, ci doar <title></title>
                                NewsTitle[NewsTitle.Count - 1] = NewsTitle[NewsTitle.Count - 1].Remove(NewsTitle[NewsTitle.Count - 1].IndexOf("]"));
                        }
                        else
                        {
                            NewsTitle[NewsTitle.Count - 1] = NewsTitle[NewsTitle.Count - 1].Remove(NewsTitle[NewsTitle.Count - 1].IndexOf("<"), NewsTitle[NewsTitle.Count - 1].IndexOf(">") + 1);
                            if (NewsTitle[NewsTitle.Count - 1].Length != 0)
                                NewsTitle[NewsTitle.Count - 1] = NewsTitle[NewsTitle.Count - 1].Remove(NewsTitle[NewsTitle.Count - 1].IndexOf("<"));
                        }
                    }
                    else //Titlu de canal
                    {
                        ChannelTitle = FileContent[i].Trim();
                        ChannelTitle = ChannelTitle.Remove(ChannelTitle.IndexOf("<"), ChannelTitle.IndexOf(">") + 1);
                        if (ChannelTitle.Length != 0)
                            ChannelTitle = ChannelTitle.Remove(ChannelTitle.IndexOf("<"));
                    }
                }

                if (FileContent[i].Contains("<link>"))
                {
                    if (IsNews) //Link-ul stirii
                    {
                        NewsLink.Add(FileContent[i].Trim());
                        if (NewsLink[NewsLink.Count - 1].Contains("CDATA")) //Daca link-ul catre stire are si eticheta CDATA
                        {
                            NewsLink[NewsLink.Count - 1] = NewsLink[NewsLink.Count - 1].Remove(NewsLink[NewsLink.Count - 1].IndexOf("<"), 15);
                            if (NewsLink[NewsLink.Count - 1].Length != 0)
                                NewsLink[NewsLink.Count - 1] = NewsLink[NewsLink.Count - 1].Remove(NewsLink[NewsLink.Count - 1].IndexOf("]"));
                        }
                        else
                        {
                            NewsLink[NewsLink.Count - 1] = NewsLink[NewsLink.Count - 1].Remove(NewsLink[NewsLink.Count - 1].IndexOf("<"), NewsLink[NewsLink.Count - 1].IndexOf(">") + 1);
                            if (NewsLink[NewsLink.Count - 1].Length != 0)
                                NewsLink[NewsLink.Count - 1] = NewsLink[NewsLink.Count - 1].Remove(NewsLink[NewsLink.Count - 1].IndexOf("<"));
                        }
                    }

                    else //Link-ul canalului
                    {
                        ChannelLink = FileContent[i].Trim();
                        ChannelLink = ChannelLink.Remove(ChannelLink.IndexOf("<"), ChannelLink.IndexOf(">") + 1);
                        if (ChannelLink.Length != 0)
                            ChannelLink = ChannelLink.Remove(ChannelLink.IndexOf("<"));
                    }
                }

                if (FileContent[i].Contains("<description>"))
                {
                    if (IsNews) //Descrierea stirii
                    {
                        NewsDescription.Add(FileContent[i].Trim());
                        if (NewsDescription[NewsDescription.Count - 1].Contains("CDATA"))
                        {
                            NewsDescription[NewsDescription.Count - 1] = NewsDescription[NewsDescription.Count - 1].Remove(NewsDescription[NewsDescription.Count - 1].IndexOf("<"), 22);
                            if (NewsDescription[NewsDescription.Count - 1].Length != 0)
                                NewsDescription[NewsDescription.Count - 1] = NewsDescription[NewsDescription.Count - 1].Remove(NewsDescription[NewsDescription.Count - 1].IndexOf("]"));
                        }
                        else
                        {
                            NewsDescription[NewsDescription.Count - 1] = NewsDescription[NewsDescription.Count - 1].Remove(NewsDescription[NewsDescription.Count - 1].IndexOf("<"), NewsDescription[NewsDescription.Count - 1].IndexOf(">") + 1);
                            if (NewsDescription[NewsDescription.Count - 1].Length != 0)
                                NewsDescription[NewsDescription.Count - 1] = NewsDescription[NewsDescription.Count - 1].Remove(NewsDescription[NewsDescription.Count - 1].IndexOf("<"));
                        }
                    }

                    else //Descrierea canalului
                    {
                        ChannelDescription = FileContent[i].Trim();
                        ChannelDescription = ChannelDescription.Remove(ChannelDescription.IndexOf("<"), ChannelDescription.IndexOf(">") + 1);
                        if (ChannelDescription.Length != 0)
                            ChannelDescription = ChannelDescription.Remove(ChannelDescription.IndexOf("<"));
                    }
                }

                if (FileContent[i].Contains("<copyright>"))
                {
                    Copyright = FileContent[i].Trim();
                    Copyright = Copyright.Remove(Copyright.IndexOf("<"), Copyright.IndexOf(">") + 1);
                    if (Copyright.Length != 0)
                        Copyright = Copyright.Remove(Copyright.IndexOf("<"));
                }

                if (FileContent[i].Contains("<managingEditor>"))
                {
                    ManagingEditor = FileContent[i].Trim();
                    ManagingEditor = ManagingEditor.Remove(ManagingEditor.IndexOf("<"), ManagingEditor.IndexOf(">") + 1);
                    if (ManagingEditor.Length != 0)
                        ManagingEditor = ManagingEditor.Remove(ManagingEditor.IndexOf("<"));
                }

                if (FileContent[i].Contains("<language>"))
                {
                    Language = FileContent[i].Trim();
                    Language = Language.Remove(Language.IndexOf("<"), Language.IndexOf(">") + 1);
                    if (Language.Length != 0)
                        Language = Language.Remove(Language.IndexOf("<"));
                }

                if (FileContent[i].Contains("<pubDate>"))
                {
                    PubDate = FileContent[i].Trim();
                    PubDate = PubDate.Remove(PubDate.IndexOf("<"), PubDate.IndexOf(">") + 1);
                    if (PubDate.Length != 0)
                        PubDate = PubDate.Remove(PubDate.IndexOf("<"));
                }
            }
        }

        public void FillRSSData()
        //todo de rescris subrutina folosind bibliotecile XML existente
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            XmlReader reader = XmlReader.Create(OnlineSource, settings);
            string StartTag;
            while (reader.Read())
            {
                if (reader.IsStartElement())
                    if (reader.IsEmptyElement)
                        MessageBox.Show("Empty");
                    else
                    {
                        StartTag = reader.Name; //retine numele etichetei
                        switch(StartTag)
                        {
                            case "rss":
                                {
                                    break;
                                }
                            case "link":
                                {
                                    ChannelLink = reader.ReadElementContentAsString();
                                    break;
                                }
                            case "description":
                                {
                                    ChannelDescription = reader.ReadElementContentAsString();
                                    break;
                                }
                            case "title":
                                {
                                    ChannelTitle = reader.ReadElementContentAsString();
                                    break;
                                }
                            case "language":
                                {
                                    Language = reader.ReadElementContentAsString();
                                    break;
                                }
                            case "copyright":
                                {
                                    Copyright = reader.ReadElementContentAsString();
                                    break;
                                }
                            case "managingeditor":
                                {
                                    ManagingEditor = reader.ReadElementContentAsString();
                                    break;
                                }
                            case "pubdate":
                                {
                                    PubDate = reader.ReadElementContentAsString();
                                    break;
                                }
                        }
                        reader.Read(); //Citeste eticheta de pornire
                        if (reader.IsStartElement())  //Se ocupa de elementele secundare
                            Console.Write(reader.Name);
                        Console.Write(reader.ReadString()); //Citeste continutul elementului
                    }
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