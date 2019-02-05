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
        private int numberofsources = 0, numberofselectedsources = 0;

        public List<string> SourceTitle = new List<string>();
        private List<string> SourceURL = new List<string>();
        public List<bool> IsSourceSelected = new List<bool>();

        public int NumberofSources
        {
            get
            {
                return numberofsources;
            }
            set
            {
                if (value < 0)
                    numberofsources = 0;
                else
                    numberofsources = value;
            }
        }

        public int NumberofSelectedSources
        {
            get
            {
                return numberofselectedsources;
            }
            set
            {
                if (value < 0)
                    numberofselectedsources = 0;
                else
                    numberofselectedsources = value;
            }
        }

        public RSSSourcesLibrary()
        {
            CheckForRSSFile();
            LoadSources(true);
        }

        public void EnableNewsSource(int SourceNo)
        {
            IsSourceSelected[SourceNo] = true;
            SaveSources();
        }

        public void DisableNewsSource(int SourceNo)
        {
            IsSourceSelected[SourceNo] = false;
            SaveSources();
        }

        private void ReadSourcesFile()
        {
            string[] TextToRead = new string[] { }; //retine textele care vor fi citite din fisier. 
            int j = 0;
            int found = 0;
            TextToRead = File.ReadAllLines("Sources.txt");
            for (int i = 0; i < TextToRead.Length; i += 3) //Imparte fiecare text in sursa si URL
            {
                SourceTitle.Add(TextToRead[i]);
                found = TextToRead[i].IndexOf(":");
                SourceTitle[j] = SourceTitle[j].Substring(found + 1);

                SourceURL.Add(TextToRead[i + 1]);
                found = TextToRead[i + 1].IndexOf(":");
                SourceURL[j] = SourceURL[j].Substring(found + 1);


                if (TextToRead[i + 2].Contains("True"))
                {
                    IsSourceSelected.Add(true);
                    NumberofSelectedSources++;
                }
                else
                    IsSourceSelected.Add(false);
                j++;
                NumberofSources++;
            }
        }

        private void ReadLibraryFile()
        {
            SourceTitle.Add(NewsLibrary.NewsSourcesList[NewsLibrary.AbsoluteIndex]);
            SourceURL.Add(NewsLibrary.NewsSourcesRSSList[NewsLibrary.AbsoluteIndex]);
            IsSourceSelected.Add(true);
        }

        public void LoadSources(bool AreSources)
        {

            if (AreSources)
            {
                ReadSourcesFile();
            }
            else
            {
                ReadLibraryFile();
            }
        }

        public void SaveSources()
        /*Functia salveaza sursele de stiri in fisier. 
        Forma fisierului este: 
        name:numele sursei (dat de utilizator)
        URL:Adresa fisierului XML
        selected:Daca e selectat sau nu*/
        {
            List<string> TextToWrite = new List<string>(); //retine textele care vor fi scrise in fisier.
            for (int i = 0; i < SourceTitle.Count; i++)
            {
                TextToWrite.Add("name:" + SourceTitle[i]);
                TextToWrite.Add("URL:" + SourceURL[i]);
                TextToWrite.Add("selected:" + IsSourceSelected[i]);
            }
            File.WriteAllLines("Sources.txt", TextToWrite.ToArray());
        }

        public void AddNewSource(string NewSourceName, string NewSourceURL)
        {
            SourceTitle.Add(NewSourceName);
            SourceURL.Add(NewSourceURL);
            IsSourceSelected.Add(true);
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
            for (int i = 0; i < NewsNumbers.Count; i++)
            {
                SourceTitle.RemoveAt(NewsNumbers[i]);
                SourceURL.RemoveAt(NewsNumbers[i]);
                NumberofSources--;
            }
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

        public List<string> GetNewsURL() => SourceURL;

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
            NumberofSelectedSources = 0;
        }

        public void SortSources(int Position, int SortingWay)
        /*Subrutina muta sursa de pe pozitia Position in functie de valoarea lui SortingWay:
         1 - muta cu o pozitie mai sus (Up 1)
         2 - muta cu o pozitie mai jos (Down 1)
         3 - muta pe prima pozitie (Move first)
         4 - muta pe ultima pozitie (Move last)*/
        {
            switch (SortingWay)
            {
                case 1:
                    {
                        ExchangeElementsString(SourceTitle, Position - 1, Position);
                        ExchangeElementsString(SourceURL, Position - 1, Position);
                        ExchangeElementsBoolean(IsSourceSelected, Position - 1, Position);

                        break;
                    }
                case 2:
                    {
                        ExchangeElementsString(SourceTitle, Position + 1, Position);
                        ExchangeElementsString(SourceURL, Position + 1, Position);
                        ExchangeElementsBoolean(IsSourceSelected, Position + 1, Position);

                        break;
                    }
                case 3:
                    {
                        MoveToFirstPositionString(SourceTitle, Position);
                        MoveToFirstPositionString(SourceURL, Position);
                        MoveToFirstPositionBoolean(IsSourceSelected, Position);

                        break;
                    }
                case 4:
                    {

                        MoveToLastPositionString(SourceTitle, Position);
                        MoveToLastPositionString(SourceURL, Position);
                        MoveToLastPositionBoolean(IsSourceSelected, Position);

                        break;
                    }
            }
        }

        private void ExchangeElementsString(List<string> List, int Pos1, int Pos2)
        {
            string buffer = List[Pos1];
            List[Pos1] = List[Pos2];
            List[Pos2] = buffer;
        }

        private void ExchangeElementsBoolean(List<bool> List, int Pos1, int Pos2)
        {
            bool buffer = List[Pos1];
            List[Pos1] = List[Pos2];
            List[Pos2] = buffer;
        }

        private void MoveToFirstPositionString(List<string> List, int PosFrom)
        {
            string buffer = List[PosFrom];
            for (int i = PosFrom; i > 0; i--)
                List[i] = List[i - 1];
            List[0] = buffer;
        }

        private void MoveToFirstPositionBoolean(List<bool> List, int PosFrom)
        {
            bool buffer = List[PosFrom];
            for (int i = PosFrom; i > 0; i--)
                List[i] = List[i - 1];
            List[0] = buffer;
        }

        private void MoveToLastPositionString(List<string> List, int PosFrom)
        {
            string buffer = List[PosFrom];
            for (int i = PosFrom; i < List.Count - 1; i++)
                List[i] = List[i + 1];
            List[List.Count - 1] = buffer;
        }

        private void MoveToLastPositionBoolean(List<bool> List, int PosFrom)
        {
            bool buffer = List[PosFrom];
            for (int i = PosFrom; i < List.Count - 1; i++)
                List[i] = List[i + 1];
            List[List.Count - 1] = buffer;
        }
    }
}