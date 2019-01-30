using System.Collections.Generic;
using System.IO;

/*Clasa ce se ocpa de manipularea fisierului de optiuni si de punerea in aplicare a optiunilor citite.
 Proprietati:
 
     1. WindowsStartup. 1 daca aplicatia porneste odata cu Windows, 0 altfel
     2. MinimizeToTray. 1 daca aplicatia se minimizeaza in SysTray, 0 altfel -- gata
     3. StartupOptions. 1 daca aplicatia va porni cu fereastra minimizata, 2 daca va porni cu fereastra la dimensiunile implicite, 3 daca va porni cu fereastra maximizata -- gata
     4. DisableInvalidNewsFiles. 1 daca dezactiveaza sursele de stiri care au fisiere RSS invalide, 0 altfel -- gata
     5. WindowWidth. Retine latimea ferestrei atunci cand programul a fost inchis -- gata
     6. WindowHeight. Acelasi lucru, dar pentru inaltimea ferestrei -- gata
     7. NewsDownloadAtStartup. 1 daca aplicatia descarca automat stirile la pornirea ei, 0 daca descarcarea o face utilizatorul -- gata
     8. NewsDownloadAtInterval. 1 daca aplicatia descarca automat stirile la un anumit interval, 0 altfel
     9. IntervalNumber. Valoarea numerica a intervalului dupa care aplicatia descarca automat stirile. De exemplu, daca e programata sa descarce dupa 15 minute, aceasta variabila are valoarea 15.
    10. IntervalTime. UM a intervalului de timp dupa care aplicatia descarca automat stirile. Are valoarea 0 daca UM e secunda, 1 daca UM e minutul si 2 daca UM este ora.
     
Metode:
     
     1. Deschiderea fisierului de optiuni
     2. Verificarea existentei lui si, daca el nu exista, crearea unuia nou, cu optiuni implicite
     3. Salvarea optiunilor in fisier
     4. Citirea optiunilor din fisier (atribuirea valorilor citite din fisier catre proprietatile clasei 
     5. Verificarea integritatii continutului fisierului de optiuni
     6. Stabilirea unor optiuni prestabilite, in cazul in care nu exista fisierul de rezultate
     
Formatul fisierului:
     proprietate=valoare*/

namespace ZanScore
{
    public class OptionsHandling
    {
        public int WindowsStartup;
        public int MinimizeToTray;
        public int StartupOptions;
        public int DisableInvalidNewsFiles;
        public int WindowWidth;
        public int WindowHeight;
        public int NewsDownloadAtStartup;
        public int NewsDownloadAtInterval;
        public int IntervalNumber;
        public int IntervalTime;
        private readonly int NumberOfOptions = 10; //retine numarul de optiuni. Daca mai apar sau dispar altele noi, acest numar se va modifica
        private readonly string[] OptionNames = new string[] { "WindowsStartup", "MinimizeToTray", "StartupOptions", "DisableInvNews", "WindowW", "WindowH", "NewsDownlAtStartup", "NewsDownlAtInterval", "IntervNumber", "IntervTime" };
        private readonly int[] OptionValues = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        //todo pe viitor sa-i implementez o optiune descarcare automata a stirilor o data la un interval ales de catre utilizator
        //todo pe viitor sa implementez o biblioteca de surse de stiri


        public OptionsHandling() //constructor
        {
            OpenOptionsFile();
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
            OptionValues[0] = WindowsStartup;
            OptionValues[1] = MinimizeToTray;
            OptionValues[2] = StartupOptions;
            OptionValues[3] = DisableInvalidNewsFiles;
            OptionValues[4] = WindowWidth;
            OptionValues[5] = WindowHeight;
            OptionValues[6] = NewsDownloadAtStartup;
            OptionValues[7] = NewsDownloadAtInterval;
            OptionValues[8] = IntervalNumber;
            OptionValues[9] = IntervalTime;
            for (int i = 0; i < NumberOfOptions; i++)
                WriteBuffer.Add(OptionNames[i] + "=" + OptionValues[i]);
            File.WriteAllLines("Options.txt", WriteBuffer.ToArray());
        }

        public void ReadOptionsFromFile() //citeste optiunile din fisier
        {
            string[] ReadBuffer = new string[] { };
            ReadBuffer = File.ReadAllLines("Options.txt");
            for (int i = 0; i < ReadBuffer.Length; i++)
                ReadBuffer[i] = ReadBuffer[i].Trim();
            WindowsStartup = int.Parse(ReadBuffer[0].Substring(ReadBuffer[0].IndexOf("=") + 1));
            MinimizeToTray = int.Parse(ReadBuffer[1].Substring(ReadBuffer[1].IndexOf("=") + 1));
            StartupOptions = int.Parse(ReadBuffer[2].Substring(ReadBuffer[2].IndexOf("=") + 1));
            DisableInvalidNewsFiles = int.Parse(ReadBuffer[3].Substring(ReadBuffer[3].IndexOf("=") + 1));
            WindowWidth = int.Parse(ReadBuffer[4].Substring(ReadBuffer[4].IndexOf("=") + 1));
            WindowHeight = int.Parse(ReadBuffer[5].Substring(ReadBuffer[5].IndexOf("=") + 1));
            NewsDownloadAtStartup = int.Parse(ReadBuffer[6].Substring(ReadBuffer[6].IndexOf("=") + 1));
            NewsDownloadAtInterval = int.Parse(ReadBuffer[7].Substring(ReadBuffer[7].IndexOf("=") + 1));
            IntervalNumber = int.Parse(ReadBuffer[8].Substring(ReadBuffer[8].IndexOf("=") + 1));
            IntervalTime = int.Parse(ReadBuffer[9].Substring(ReadBuffer[9].IndexOf("=") + 1));
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
            NewsDownloadAtStartup = 1;
            NewsDownloadAtInterval = 1;
            IntervalNumber = 1;
            IntervalTime = 1;
        }
    }
}
