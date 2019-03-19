using System.Collections.Generic;
using System.IO;
using System;
using System.Windows.Forms;
using System.Security;

/*Clasa ce se ocupa de manipularea fisierului de optiuni si de punerea in aplicare a optiunilor citite.
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
    /// <summary>
    /// Class that handles the program options
    /// </summary>
    public class OptionsHandling
    {
        private int windowsstartup;
        private int minimizetotray;
        private int startupoptions;
        private int disableinvalidnewsfiles;
        private int windowwidth;
        private int windowheight;
        private int newsdownloadatstartup;
        private int newsdownloadatinterval;
        private int intervalnumber;
        private int intervaltime;

        /// <summary>
        /// Stores if the program should start with the OS boot. It equals 1 is the program starts with OS, else it's 0
        /// </summary>
        public int WindowsStartup
        {
            get
            {
                return windowsstartup;
            }
            set
            {
                if ((value != 0) && (value != 1))
                    windowsstartup = 0;
                else
                    windowsstartup = value;
            }
        }

        /// <summary>
        /// Stores if the program should be minimized to tray (equals 1) or not (0)
        /// </summary>
        public int MinimizeToTray
        {
            get
            {
                return minimizetotray;
            }
            set
            {
                if ((value != 0) && (value != 1))
                    minimizetotray = 0;
                else
                    minimizetotray = value;
            }
        }

        /// <summary>
        /// Stores the startup options:
        /// 1. 0 - start minimized
        /// 2. 1 - start normal
        /// 3. 2 - start maximized
        /// </summary>
        public int StartupOptions
        {
            get
            {
                return startupoptions;
            }
            set
            {
                if ((value < 1) || (value > 3))
                    startupoptions = 2;
                else
                    startupoptions = value;
            }
        }

        /// <summary>
        /// Stores if the invalid news RSS files (those that, from one reason or another, cannot be read) should be marked as disabled and skipped the next time (stores 1) or not (0)
        /// </summary>
        public int DisableInvalidNewsFiles
        {
            get
            {
                return disableinvalidnewsfiles;
            }
            set
            {
                if ((value != 0) && (value != 1))
                    disableinvalidnewsfiles = 0;
                else
                    disableinvalidnewsfiles = value;
            }
        }

        /// <summary>
        /// Stores the main window width
        /// </summary>
        public int WindowWidth
        {
            get
            {
                return windowwidth;
            }
            set
            {
                if (value <= 0)
                    windowwidth = 1200;
                else
                    windowwidth = value;
            }
        }

        /// <summary>
        /// Stores the main window height
        /// </summary>
        public int WindowHeight
        {
            get
            {
                return windowheight;
            }
            set
            {
                if (value <= 0)
                    windowheight = 563;
                else
                    windowheight = value;
            }
        }

        /// <summary>
        /// Stores if the news should be automatically downloaded at program startup (stores 1) or the user manually starts the downloading process (stores 0)
        /// </summary>
        public int NewsDownloadAtStartup
        {
            get
            {
                return newsdownloadatstartup;
            }
            set
            {
                if ((value != 0) && (value != 1))
                    newsdownloadatstartup = 1;
                else
                    newsdownloadatstartup = value;
            }
        }

        /// <summary>
        /// Stores if the news should be automatically downloaded at a set interval (stores 1) or not (stores 0)
        /// </summary>
        public int NewsDownloadAtInterval
        {
            get
            {
                return newsdownloadatinterval;
            }
            set
            {
                if ((value != 0) && (value != 1))
                    newsdownloadatinterval = 1;
                else
                    newsdownloadatinterval = value;
            }
        }

        /// <summary>
        /// Stores the numerical value of the download interval. Example: if the interval is 15 minutes, then this variable stores the value 15.
        /// </summary>
        public int IntervalNumber
        {
            get
            {
                return intervalnumber;
            }
            set
            {
                if ((value != 0) && (value != 1))
                    intervalnumber = 1;
                else
                    intervalnumber = value;
            }
        }

        /// <summary>
        /// Stores the time unit for the automatical download interval:
        /// 1. 0 - seconds
        /// 2. 1 - minutes
        /// 3. 2 - hours
        /// </summary>
        public int IntervalTime
        {
            get
            {
                return intervaltime;
            }
            set
            {
                if ((value < 0) || (value > 2))
                    intervaltime = 1;
                else
                    intervaltime = value;
            }
        }

        private readonly int NumberOfOptions = 10; //retine numarul de optiuni. Daca mai apar sau dispar altele noi, acest numar se va modifica
        private readonly string[] OptionNames = new string[] { "WindowsStartup", "MinimizeToTray", "StartupOptions", "DisableInvNews", "WindowW", "WindowH", "NewsDownlAtStartup", "NewsDownlAtInterval", "IntervNumber", "IntervTime" };
        private readonly int[] OptionValues = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// Class constructor
        /// </summary>
        public OptionsHandling() //constructor
        {
            OpenOptionsFile();
        }

        /// <summary>
        /// Opens the options file. This functions has two parts:
        /// 1. Check if the options file exists
        /// 2. Reading the options from the options file
        /// </summary>
        /// <returns>true if the entire process ended without throwing exceptions. Else, it returns false</returns>
        public bool OpenOptionsFile() //deschiderea fisierului de optiuni
        {
            return CheckOptionsFileExistence() && ReadOptionsFromFile();
        }

        private bool CheckOptionsFileExistence() //verificarea existentei acestuia
        {
            bool Result = true;
            if (!File.Exists("Options.txt"))
            {
                SetDefaultOptions();
                Result = SaveOptionsToFile();
            }
            else
                Result = true;
            return Result;
        }

        private void FillOptionValues()
        //Procedura umple sirul valorilor pentru optiuni cu valorile variabilelor corespunzatoare
        {
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
        }

        /// <summary>
        /// Saves the stored options to the options file
        /// </summary>
        /// <returns>true, if the saving process ended without throwing any exceptions, otherwise it returns false</returns>
        public bool SaveOptionsToFile() //salvarea optiunilor in fisier
        {
            List<string> WriteBuffer = new List<string>() { };

            FillOptionValues();

            for (int i = 0; i < NumberOfOptions; i++)
                WriteBuffer.Add(OptionNames[i] + "=" + OptionValues[i]);

            try
            {
                File.WriteAllLines("Options.txt", WriteBuffer.ToArray());
                return true;
            }
            catch (UnauthorizedAccessException U)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(U.Message, "Error!", MB, MI);
                return false;
            }
            catch (SecurityException S)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(S.Message, "Error!", MB, MI);
                return false;
            }
        }

        private bool ReadOptionsFromFile() //citeste optiunile din fisier
        {
            string[] ReadBuffer = new string[] { };
            try
            {
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
                return true;
            }
            catch (FileNotFoundException F) //Exceptii pentru ReadAllLines
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(F.Message, "Error!", MB, MI);
                return false;
            }
            catch (FileLoadException F)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(F.Message, "Error!", MB, MI);
                return false;
            }
            catch (IOException I)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(I.Message, "Error!", MB, MI);
                return false;
            }
            catch (SecurityException S)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(S.Message, "Error!", MB, MI);
                return false;
            }
            catch (ArgumentNullException A)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(A.Message, "Error!", MB, MI);
                return false;
            }
            catch (ArgumentOutOfRangeException A) //Exceptii de la Substring
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(A.Message, "Error!", MB, MI);
                return false;
            }
            catch (FormatException F) //Exceptii de la Parse
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(F.Message, "Error!", MB, MI);
                return false;
            }

            catch (OverflowException O)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(O.Message, "Error!", MB, MI);
                return false;
            }
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
