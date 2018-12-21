using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public RSSSources()
        {

        }

        public void LoadSources()
        {
            string[] TextToRead = new string[] { }; //retine textul care va fi citit din fisier. E de forma <sursa> <URL>
            TextToRead = File.ReadAllLines("Sources.txt");
            for (int i = 0; i < TextToRead.Length; i++) //Imparte fiecare text in sursa si URL
            {
                Array.Resize(ref SourceTitle, SourceTitle.Length + 1);
                Array.Resize(ref SourceURL, SourceURL.Length + 1);
                SourceTitle[i] = TextToRead[i].Substring(0, SourceTitle[i].IndexOf(" ") + 1);
                SourceURL[i] = TextToRead[i].Substring(SourceURL[i].IndexOf(" "), SourceURL[i].Length);
            }
        }

        public void SaveSources()
        {
            string[] TextToWrite = new string[] { }; //retine textul care va fi scris in fisier. E de forma <sursa> <URL>
            for (int i = 0; i < SourceTitle.Length; i++)
                TextToWrite[i] = SourceTitle[i] + " " + SourceURL[i];
            File.WriteAllLines("Sources.txt", TextToWrite);
        }

        public void AddNewSource(string NewSourceName, string NewSourceURL)
        {
            Array.Resize(ref SourceTitle, SourceTitle.Length + 1);
            Array.Resize(ref SourceURL, SourceURL.Length + 1);
            SourceTitle[SourceTitle.Length + 1] = NewSourceName;
            SourceURL[SourceURL.Length + 1] = NewSourceURL;
        }

        public void EditSource()
        {

        }

        public void RemoveSource()
        {

        }
    }
}
