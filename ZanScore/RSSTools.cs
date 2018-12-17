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
    internal class RSSTools
    {
        readonly string FileToProcess;
        string[] FileContent;

        public struct Item
        //O structura ce retine o singura stire
        //todo: Sa adaug si restul subcategoriilor, odata ce am o aplicatie functionala
        {
            public string Title; //Titlul stirii
            public string Link; //Link-ul catre stire
            public string Description; //Descrierea stirii
        }

        public struct RSSData
        // O structura ce retine datele dintr-un fisier RSS. Detalii despre acesta sunt la https://www.w3schools.com/xml/xml_rss.asp.
        //Deoarece aceste campuri sunt citire dintr-un fisier, toti membrii acestei structuri sunt readonly
        //todo: Sa adaug si restul subcategoriilor, odata ce am o aplicatie functionala
        {
            public float RSSVersion; //Versiunea de RSS folosita
            public string ChannelTitle; //Titlul canalului
            public string ChannelLink; //Link catre URL-ul canalului
            public string ChannelDescription; //Descrierea canalului
            public string Category; //Categoria stirilor
            public string Copyright; //Informatii despre copyright
            public string Language; //Limba in care sunt scrise stirile
            public string PubDate; //Data publicarii stirii
            public string ManagingEditor; //E-mailul editorului continutului fisierului RSS
            public Item[] AllNews; //Retine toate stirile
        }

        public RSSTools(string File)
        //Constructor. Parametrul reprezinta fisierul care va fi citit
        {
            FileToProcess = File;
        }

        public bool CheckRSSFile()
        //Metoda verifica daca fisierul RSS exista sau nu
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
            RSSData Data;
        }
    }
}