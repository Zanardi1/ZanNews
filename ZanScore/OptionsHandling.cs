using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

/*Clasa ce se ocpa de manipularea fisierului de optiuni si de punerea in aplicare a optiunilor citite.
 Proprietati:
 
     1. WindowsStartup. 1 daca aplicatia porneste odata cu Windows, 0 altfel
     2. MinimizeToTray. 1 daca aplicatia se minimizeaza in SysTray, 0 altfel
     3. StartupOptions. 1 daca aplicatia va porni cu fereastra minimizata, 2 daca va porni cu fereastra la dimensiunile implicite, 3 daca va porni cu fereastra maximizata
     4. DisableInvalidNewsFiles. 1 daca dezactiveaza sursele de stiri care au fisiere RSS invalide, 0 altfel
     5. WindowWidth. Retine latimea ferestrei atunci cand programul a fost inchis
     6. WindowHeight. Acelasi lucru, dar pentru inaltimea ferestrei
     7. AutomaticNewsDownload. 1 daca aplicatia descarca automat stirile la pornirea ei, 0 daca descarcarea o face utilizatorul
     
Metode:
     
     1.Deschiderea fisierului de optiuni
     2.Verificarea existentei lui si, daca el nu exista, crearea unuia nou, cu optiuni implicite
     3.Salvarea optiunilor in fisier
     4.Citirea optiunilor din fisier (atribuirea valorilor citite din fisier catre proprietatile clasei 
     5.Verificarea integritatii continutului fisierului de optiuni
     6.Stabilirea unor optiuni prestabilite, in cazul in care nu exista fisierul de rezultate
     
Formatul fisierului:
     [proprietate,valoare]*/

namespace ZanScore
{
    class OptionsHandling
    {
        public int WindowsStartup;
        public int MinimizeToTray;
        public int StartupOptions;
        public int DisableInvalidNewsFiles;
        public int WindowWidth;
        public int WindowHeight;
        public int AutomaticNewsDownload;

        List<KeyValuePair<string, int>> OptionsFileContent = new List<KeyValuePair<string, int>>();

        //todo de scris o rutina care sa sa se asigure ca StartupOptions e 1, 2 sau 3

        public OptionsHandling() //constructor
        {
            OptionsFileContent.Add(new KeyValuePair<string, int>("fxf", 5));
            MessageBox.Show(OptionsFileContent[0].Key);
            SaveOptionsToFile();
        }

        public void OpenOptionsFile() //deschiderea fisierului de optiuni
        {
            CheckOptionsFileExistence();
            ReadOptionsFromFile();
        }

        private void CheckOptionsFileExistence() //verificarea existentei acestuia
        {
            if (!File.Exists("Options.txt"))
            {
                FileStream FS = File.Create("Options.txt");
                SetDefaultOptions();
                SaveOptionsToFile();
                FS.Close();
            }
        }

        public void SaveOptionsToFile() //salvarea optiunilor in fisier
        {
            List<string> WriteBuffer = new List<string>() { };
            for (int i = 0; i < OptionsFileContent.Count; i++)
                WriteBuffer.Add(OptionsFileContent[i].ToString());
            File.WriteAllLines("Options.txt", WriteBuffer.ToArray());
        }

        public void ReadOptionsFromFile() //citeste optiunile din fisier
        {

        }

        public bool CheckOptionsFileContent()
        {
            return true;
        }

        private void SetDefaultOptions() //setul de optiuni prestabilite
        {
            WindowsStartup = 0;
            MinimizeToTray = 0;
            StartupOptions = 2;
            DisableInvalidNewsFiles = 0;
            WindowWidth = 1200;
            WindowHeight = 563;
            AutomaticNewsDownload = 1;
        }
    }
}
