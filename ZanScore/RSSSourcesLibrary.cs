using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ZanScore
{
    public class RSSSourcesLibrary
    //Aceasta clasa se ocupa de gestionarea surselor de stiri. 
    //Operatiuni:
    // 1. Citirea lor din fisier;
    // 2. Scrierea lor in fisier;
    // 3. Adaugarea unei surse;
    // 4. Editarea unei surse;
    // 5. Stergerea unei surse;
    // 6. Sortarea surselor;

    {
        //string[] SourceTitle = new string[] { };
        List<string> SourceTitle = new List<string>();
        List<string> SourceURL = new List<string>();
        public int NumberofSources;

        public RSSSourcesLibrary()
        {
            NumberofSources = 0;
            CheckForRSSFile();
            LoadSources();
        }

        public void LoadSources()
        {
            string[] TextToRead = new string[] { }; //retine textele care vor fi citite din fisier. 
            int j = 0;
            TextToRead = File.ReadAllLines("Sources.txt");
            for (int i = 0; i < TextToRead.Length; i += 2) //Imparte fiecare text in sursa si URL
            {
                SourceTitle.Add(TextToRead[i]);
                SourceURL.Add(TextToRead[i + 1]);
                SourceTitle[j] = SourceTitle[j].Remove(0, SourceTitle[j].IndexOf(">") + 1); //Elimina "<name">
                SourceTitle[j] = SourceTitle[j].Remove(SourceTitle[j].IndexOf("<")); //Elimina "</name>"
                SourceURL[j] = SourceURL[j].Remove(0, SourceURL[j].IndexOf(">") + 1); //Elimina "<URL>"
                SourceURL[j] = SourceURL[j].Remove(SourceURL[j].IndexOf("<")); //Elimina "</URL>"
                j++;
                NumberofSources++;
            }
        }

        public void SaveSources()
        /*Functia salveaza sursele de stiri in fisier. 
        Forma fisierului este: 
        <name>numele sursei (dat de utilizator></name>
        <URL>Adresa fisierului XML</URL>*/
        {
            string[] TextToWrite = new string[] { }; //retine textele care vor fi scrise in fisier. 
            int j = 0;
            Array.Resize(ref TextToWrite, SourceTitle.Count * 2);
            for (int i = 0; i < SourceTitle.Count; i++)
            {
                TextToWrite[j] = "<name>" + SourceTitle[i] + "</name>";
                TextToWrite[j + 1] = "<URL>" + SourceURL[i] + "</URL>";
                j += 2;
            }
            File.WriteAllLines("Sources.txt", TextToWrite);
        }

        public void AddNewSource(string NewSourceName, string NewSourceURL)
        {
            SourceTitle.Add(NewSourceName);
            SourceURL.Add(NewSourceURL);
            NumberofSources++;
        }

        public void EditSource(int SourcePosition, string NewSourceName, string NewSourceURL)
        //Functia editeaza sursa care se afla la pozitia SourcePosition
        {
            SourceTitle[SourcePosition] = NewSourceName;
            SourceURL[SourcePosition] = NewSourceURL;
        }

        public void RemoveSource(List<int> NewsNumbers)
        //Elimina una sau mai multe surse de stiri. Numerele lor de ordine sunt transmise ca parametri
        {
            List<string> TempSourceTitle = new List<string>(SourceTitle);
            List<string> TempSourceURL = new List<string>(SourceURL);
            for (int i = 0; i < NewsNumbers.Count; i++)
            {
                TempSourceTitle.RemoveAt(NewsNumbers[i]);
                TempSourceURL.RemoveAt(NewsNumbers[i]);
                NumberofSources--;
            }
            SourceTitle = TempSourceTitle;
            SourceURL = TempSourceURL;
        }

        public void ShowNewsSourcesInDataGrid(DataGridView Grid)
        //Afiseaza sursele de stiri in fereastra EditSources
        {
            for (int i = 0; i < SourceTitle.Count; i++)
            {
                Grid.Rows.Add();
                Grid.Rows[i].Cells[0].Value = SourceTitle[i];
                Grid.Rows[i].Cells[1].Value = SourceURL[i];
            }
        }

        public List<string> GetNewsURL()
        {
            List<string> NewsURLList = new List<string>();
            for (int i = 0; i < NumberofSources; i++)
                NewsURLList.Add(SourceURL[i]);
            return NewsURLList;
        }

        private void CheckForRSSFile()
        //Subrutina verifica daca exista fisierul "Sources.txt". Daca nu exista, creaza un fisier gol
        {

            if (!File.Exists("Sources.txt"))
            {
                FileStream FS = File.Create("Sources.txt");
                FS.Close();
            }
        }

        public void ClearSources()
        //Goleste datele legate de sursele de stiri. Utila in cazul in care nu vreau ca aceleasi stiri sa apara de 2+ ori
        {
            SourceTitle.Clear();
            SourceURL.Clear();
            NumberofSources = 0;
        }

        public void SortSources(int Position, int SortingWay)
        /*Subrutina muta sursa de pe pozitia Position in functie de valoarea lui SortingWay:
         1 - muta cu o pozitie mai sus (Up 1)
         2 - muta cu o pozitie mai jos (Down 1)
         3 - muta pe prima pozitie (Move first)
         4 - muta pe ultima pozitie (Move last)*/
        {
            string buffer; //variabila temporara utilizata la interschimbari
            switch (SortingWay)
            {
                case 1:
                    {
                        if (Position > 0) //Daca nu incerc sa mut mai sus prima sursa de stiri
                        {
                            buffer = SourceTitle[Position - 1];
                            SourceTitle[Position - 1] = SourceTitle[Position];
                            SourceTitle[Position] = buffer;

                            buffer = SourceURL[Position - 1];
                            SourceURL[Position - 1] = SourceURL[Position];
                            SourceURL[Position] = buffer;
                        }
                        break;
                    }
                case 2:
                    {
                        if (Position < SourceTitle.Count)
                        {
                            buffer = SourceTitle[Position + 1];
                            SourceTitle[Position + 1] = SourceTitle[Position];
                            SourceTitle[Position] = buffer;

                            buffer = SourceURL[Position + 1];
                            SourceURL[Position + 1] = SourceURL[Position];
                            SourceURL[Position] = buffer;
                        }
                        break;
                    }
                case 3:
                    {
                        if (Position > 0)
                        {
                            buffer = SourceTitle[Position];
                            for (int i = Position; i > 0; i--)
                                SourceTitle[i] = SourceTitle[i - 1];
                            SourceTitle[0] = buffer;

                            buffer = SourceURL[Position];
                            for (int i = Position; i > 0; i--)
                                SourceURL[i] = SourceURL[i - 1];
                            SourceURL[0] = buffer;
                        }
                        break;
                    }
                case 4:
                    {
                        if (Position < SourceTitle.Count)
                        {
                            buffer = SourceTitle[Position];
                            for (int i = Position; i < SourceTitle.Count - 1; i++)
                                SourceTitle[i] = SourceTitle[i + 1];
                            SourceTitle[SourceTitle.Count - 1] = buffer;

                            buffer = SourceURL[Position];
                            for (int i = Position; i < SourceURL.Count - 1; i++)
                                SourceURL[i] = SourceURL[i + 1];
                            SourceURL[SourceURL.Count - 1] = buffer;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
