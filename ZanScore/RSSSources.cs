using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ZanScore
{
    class RSSSources
    //Aceasta clasa se ocupa de gestionarea surselor de stiri. 
    //Operatiuni:
    // 1. Citirea lor din fisier;
    // 2. Scrierea lor in fisier;
    // 3. Adaugarea unei surse;
    // 4. Editarea unei surse;
    // 5. Stergerea unei surse
    {
        string[] SourceTitle = new string[] { };
        string[] SourceURL = new string[] { };
        public int NumberofSources;

        public RSSSources()
        {
            NumberofSources = 0;
            CheckForRSSFile();
            LoadSources();
        }

        public void LoadSources()
        {
            string[] TextToRead = new string[] { }; //retine textul care va fi citit din fisier. E de forma <sursa> <URL>
            TextToRead = File.ReadAllLines("Sources.txt");
            for (int i = 0; i < TextToRead.Length; i++) //Imparte fiecare text in sursa si URL
            {
                Array.Resize(ref SourceTitle, SourceTitle.Length + 1);
                Array.Resize(ref SourceURL, SourceURL.Length + 1);
                SourceTitle[i] = TextToRead[i].Substring(0, TextToRead[i].IndexOf(" "));
                SourceURL[i] = TextToRead[i].Substring(TextToRead[i].IndexOf(" ") + 1);
                SourceTitle[i] = SourceTitle[i].Trim();
                SourceURL[i] = SourceURL[i].Trim();
                NumberofSources++;
            }
        }

        public void SaveSources()
        {
            string[] TextToWrite = new string[] { }; //retine textul care va fi scris in fisier. E de forma <sursa> <URL>
            Array.Resize(ref TextToWrite, SourceTitle.Length);
            for (int i = 0; i < SourceTitle.Length; i++)
                TextToWrite[i] = SourceTitle[i] + " " + SourceURL[i];
            File.WriteAllLines("Sources.txt", TextToWrite);
        }

        public void AddNewSource(string NewSourceName, string NewSourceURL)
        {
            Array.Resize(ref SourceTitle, SourceTitle.Length + 1);
            Array.Resize(ref SourceURL, SourceURL.Length + 1);
            SourceTitle[SourceTitle.Length - 1] = NewSourceName;
            SourceURL[SourceURL.Length - 1] = NewSourceURL;
        }

        public void EditSource()
        {

        }

        public void RemoveSource()
        {

        }

        public void ShowNewsSourcesInDataGrid(DataGridView Grid)
        //Afiseaza sursele de stiri in fereastra EditSources
        {
            for (int i = 0; i < SourceTitle.Length; i++)
            {
                Grid.Rows.Add();
                Grid.Rows[i].Cells[0].Value = SourceTitle[i];
                Grid.Rows[i].Cells[1].Value = SourceURL[i];
            }
        }

        public string[] GetNewsURL()
        {
            string[] List = new string[] { };
            for (int i = 0; i < NumberofSources; i++)
            {
                Array.Resize(ref List, List.Length + 1);
                List[i] = SourceURL[i];
            }
            return List;
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
        {
            SourceTitle = Array.Empty<string>();
            SourceURL = Array.Empty<string>();
            NumberofSources = 0;
        }
    }
}
