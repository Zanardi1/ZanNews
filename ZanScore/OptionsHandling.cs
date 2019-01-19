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
     
Metode:
     
     1.Deschiderea fisierului de optiuni
     2.Verificarea existentei lui si, daca el nu exista, crearea unuia nou, cu optiuni implicite
     3.Salvarea optiunilor in fisier
     4.Citirea optiunilor din fisier (atribuirea valorilor citite din fisier catre proprietatile clasei 
     5.Afisarea acestora in ferastra de optiuni
     6.Verificarea integritatii continutului fisierului de optiuni
     7.Stabilirea unor optiuni prestabilite, in cazul in care nu exista fisierul de rezultate
     
Formatul fisierului:
     proprietare:valoare*/

namespace ZanScore
{
    class OptionsHandling
    {
        int WindowsStartup;
        int MinimizeToTray;
        int StartupOptions;
        int DisableInvalidNewsFiles;
        int WindowWidth;
        int WindowHeight;

        List<KeyValuePair<string, int>> buffer = new List<KeyValuePair<string, int>>();

        //todo de scris o rutina care sa sa se asigure ca StartupOptions e 1, 2 sau 3

        public OptionsHandling()
        {
            buffer.Add(["f",5]);
        }

        public void OpenOptionsFile()
        {
            CheckOptionsFileExistence();
        }

        public void CheckOptionsFileExistence()
        {
            if (!File.Exists("Options.txt"))
            {
                FileStream FS = File.Create("Options.txt");
                SaveOptionsToFile();
                FS.Close();
            }
        }

        public void SaveOptionsToFile()
        {

        }

        public void ReadOptionsFromFile()
        {

        }

        public void ShowOptionsInOptionsWindow()
        {

        }

        public bool CheckOptionsFileContent()
        {
            return true;
        }

        private void SetDefaultOptions()
        {
            WindowsStartup = 0;
            MinimizeToTray = 0;
            StartupOptions = 2;
            DisableInvalidNewsFiles = 0;
            WindowWidth = 1200;
            WindowHeight = 563;
        }
    }
}
