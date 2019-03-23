using System.Collections.Generic;
using System.IO;
using System;
using System.Windows.Forms;
using System.Security;

namespace ZanScore
{
    /// <summary>
    /// Class that handles the program options.
    /// </summary>
    /// <remarks>
    /// Class that handles the options file and applying the read options.
    /// 
    /// Properties:
    /// 1. WindowsStartup. 1 if the application starts with Windows. 0 if it doesn't;
    /// 2. MinimizeToTray. 1 if the application minimizez to Systray. 0 if it doesn't;
    /// 3. StartupOptions. 1 if the application will start with minimized main window, 2 if it starts with normal window and 3 if it starts maximized;
    /// 4. DisableInvalidNewsFiles. 1 if it disables the news sources with invalid RSS files (and skips them next time). 0 if it doesn't;
    /// 5. WindowWidth. Stores the main window with at program shutdown;
    /// 6. WindowHeight. Stores the main window height at program shutdown;
    /// 7. NewsDownloadAtStartup. 1 if the application automatically downloads news at startup. 0 if the user manually downloads them;
    /// 8. NewsDownloadAtInterval. 1 if the application automatically downloads news at a certain interval. 0 if it doesn't;
    /// 9. IntervalNumber. The numerical value of the interval after which the application automatically downloads the news. Example: if it's set to download them after 15 minutes, this variable has the value 15;
    /// 10. IntervalTime. The unit of measure of the time interval after which the application downloads automatically the news. It's 0 for seconds, 1 for minutes and 2 for hours.
    /// 
    /// Methods (the order doesn't matter):
    /// 1. Opening the options file;
    /// 2. Verifying the existence of the file. If it doesn't exist, create a new one, with default options;
    /// 3. Saving the options in the file;
    /// 4. Reading the options from a file;
    /// 5. Verifying the options file integrity;
    /// 6. Setting default options, in case the options file is missing.
    /// 
    /// File format:
    /// property=value
    /// </remarks>
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
        /// Stores if the program should start with the OS boot. It equals 1 is the program starts with OS, else it's 0.
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

        /// <summary>
        /// Stores the number of options. Will be modified if options appear or disappear.
        /// </summary>
        private readonly int NumberOfOptions = 10; 
        /// <summary>
        /// Stores the option's names.
        /// </summary>
        private readonly string[] OptionNames = new string[] { "WindowsStartup", "MinimizeToTray", "StartupOptions", "DisableInvNews", "WindowW", "WindowH", "NewsDownlAtStartup", "NewsDownlAtInterval", "IntervNumber", "IntervTime" };
        /// <summary>
        /// Default values for the options above.
        /// </summary>
        private readonly int[] OptionValues = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// Class constructor.
        /// </summary>
        public OptionsHandling() 
        {
            OpenOptionsFile();
        }

        /// <summary>
        /// Opens the options file. This functions has two parts:
        /// 1. Check if the options file exists;
        /// 2. Reading the options from the options file.
        /// </summary>
        /// <returns>true if the entire process ended without throwing exceptions. Else, it returns false</returns>
        public bool OpenOptionsFile() 
        {
            return CheckOptionsFileExistence() && ReadOptionsFromFile();
        }

        /// <summary>
        /// Checks if the options file exists.
        /// </summary>
        /// <returns>True, if the options file exists. Oterwise it returns false.</returns>
        private bool CheckOptionsFileExistence() 
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

        /// <summary>
        /// Fills the options' values array with corresponding values from the variables.
        /// </summary>
        private void FillOptionValues()
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
        /// <exception cref="UnauthorizedAccessException">Handles this type of access.</exception>
        /// <exception cref="SecurityException">Handles security exceptions.</exception>
        public bool SaveOptionsToFile() 
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

        /// <summary>
        /// Reads the options from the options file.
        /// </summary>
        /// <returns>true if no exception was thrown.</returns>
        /// <exception cref="FileNotFoundException">Thrown if the options file was not found.</exception>
        /// <exception cref="FileLoadException">Thrown if the options file could not be loaded.</exception>
        /// <exception cref="IOException">Thrown at any I/O exception.</exception>
        /// <exception cref="SecurityException">Thrown when security exceptions occur.</exception>
        /// <exception cref="ArgumentNullException">Thrown if integer parsing uses a null argument.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown at substring operations, if the argument exceeds string length.</exception>
        /// <exception cref="FormatException">Thrown if parsing encounters an invalid format.</exception>
        /// <exception cref="OverflowException">Thrown when an overflow occurs.</exception>
        private bool ReadOptionsFromFile() 
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

        /// <summary>
        /// Sets the options variables to default values.
        /// </summary>
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
