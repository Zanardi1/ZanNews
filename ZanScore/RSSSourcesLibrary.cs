using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Security;

namespace ZanScore
{
    /// <summary>
    /// Class that handles the news sources
    /// </summary>
    /// <remarks>
    /// Implemented functions:
    /// 1 - reading the news sources from a file;
    /// 2 - writing them to a file;
    /// 3 - adding a source;
    /// 4 - editing a source;
    /// 5 - deleting a source;
    /// 6 - sources sorting.
    /// </remarks>
    public class RSSSourcesLibrary
    {
        private int numberofsources = 0, numberofselectedsources = 0;

        /// <summary>
        /// List which stores the source titles
        /// </summary>
        public List<string> SourceTitle = new List<string>();
        /// <summary>
        /// List which stores the source URLs
        /// </summary>
        private List<string> SourceURL = new List<string>();
        /// <summary>
        /// List which stores if the source titles are selected or not
        /// </summary>
        public List<bool> IsSourceSelected = new List<bool>();

        /// <summary>
        /// Stores the number of sources that are entered by the user
        /// </summary>
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

        /// <summary>
        /// Stores the number of selected sources by the user
        /// </summary>
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

        /// <summary>
        /// Class constructor
        /// </summary>
        public RSSSourcesLibrary()
        {
            LoadSources(true);
        }

        /// <summary>
        /// Enables a certain, selected, news source
        /// </summary>
        /// <param name="SourceNo">The position of the news source to be enabled</param>
        /// <returns>true if the function doesn't throw any exceptions. Else it returns false</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the parameter is outside the existent data scope. Unlikely, but better be sure.</exception>
        public bool EnableNewsSource(int SourceNo)
        {
            try
            {
                IsSourceSelected[SourceNo] = true;
                SaveSources();
                return true;
            }

            catch (ArgumentOutOfRangeException A) 
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(A.Message, "Error loading news source file", buttons, icon);
                return false;
            }
        }

        /// <summary>
        /// Disables a certain, selected, news source
        /// </summary>
        /// <param name="SourceNo">The position of the news source to be disabled</param>
        /// <returns>true, if the function throws no exceptions. Else it returns false</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the parameter is outside the existent data scope. Unlikely, but better be sure.</exception>
        public bool DisableNewsSource(int SourceNo)
        {
            try
            {
                IsSourceSelected[SourceNo] = false;
                SaveSources();
                return true;
            }

            catch (ArgumentOutOfRangeException A)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(A.Message, "Error loading news source file", buttons, icon);
                return false;
            }
        }

        /// <summary>
        /// Reads from the news sources file.
        /// </summary>
        /// <returns>true if no exception was thrown.</returns>
        /// <exception cref="FileNotFoundException">Thrown if the file is not found.</exception>
        /// <exception cref="FileLoadException">Thrown if the news file cannot be loaded.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of unauthorized access.</exception>
        /// <exception cref="SecurityException">Thrown in case of security exceptions.</exception>
        private bool ReadSourcesFile()
        {
            ClearSources();
            string[] TextToRead = new string[] { }; //retine textele care vor fi citite din fisier. 
            int j = 0, found = 0;
            try
            {
                TextToRead = File.ReadAllLines("Sources.txt");
                for (int i = 0; i < TextToRead.Length; i += 3) //Imparte fiecare text in sursa si URL
                {
                    TextToRead[i] = TextToRead[i].Trim();
                    SourceTitle.Add(TextToRead[i]);
                    found = TextToRead[i].IndexOf(":");
                    SourceTitle[j] = SourceTitle[j].Substring(found + 1);

                    TextToRead[i + 1] = TextToRead[i + 1].Trim();
                    SourceURL.Add(TextToRead[i + 1]);
                    found = TextToRead[i + 1].IndexOf(":");
                    SourceURL[j] = SourceURL[j].Substring(found + 1);


                    TextToRead[i + 2] = TextToRead[i + 2].Trim();
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
                return true;
            }
            catch (FileNotFoundException F)
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
        /// Reads from library file and stores the information in the lists.
        /// </summary>
        /// <returns>true if no exception is thrown. Else, it returns false.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if AbsoluteIndex points to a non-existant position. Unlikely but better be sure.</exception>
        private bool ReadLibraryFile()
        {
            try
            {
                SourceTitle.Add(NewsLibrary.NewsSourcesList[NewsLibrary.AbsoluteIndex]);
                SourceURL.Add(NewsLibrary.NewsSourcesRSSList[NewsLibrary.AbsoluteIndex]);
                IsSourceSelected.Add(true);
                return true;
            }
            catch (ArgumentOutOfRangeException A) 
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(A.Message, "Error loading news source file", buttons, icon);
                return false;
            }
        }

        /// <summary>
        /// Loads the news sources from either the news sources entered by the user or the default news library
        /// </summary>
        /// <param name="AreSources">Signifies wether the news sources entered by the user should be loaded (true) or the default library (false)</param>
        /// <returns>true if the loading process threw no exceptions. Otherwise it returns false</returns>
        public bool LoadSources(bool AreSources)
        {
            bool Result = true;

            if (AreSources)
            {
                Result = ReadSourcesFile();
            }
            else
            {
                Result = ReadLibraryFile();
            }
            return Result;
        }

        /// <summary>
        /// Saves the news sources in a text file. 
        /// The file format is:
        /// name: source name (provided by the user)
        /// URL: the web adress of the XML file
        /// selected: if the news source is selected or not
        /// </summary>
        /// <returns>true, if no exception was raised. Else it returns false</returns>
        /// <exception cref="UnauthorizedAccessException">Thrown if unauthorized access occurs.</exception>
        /// <exception cref="SecurityException">Thrown in case of security exceptions.</exception>
        public bool SaveSources()
        {
            List<string> TextToWrite = new List<string>(); //retine textele care vor fi scrise in fisier.
            for (int i = 0; i < SourceTitle.Count; i++)
            {
                TextToWrite.Add("name:" + SourceTitle[i]);
                TextToWrite.Add("URL:" + SourceURL[i]);
                TextToWrite.Add("selected:" + IsSourceSelected[i]);
            }

            try
            {
                File.WriteAllLines("Sources.txt", TextToWrite.ToArray());
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
        /// Adds a new news source.
        /// </summary>
        /// <param name="NewSourceName">The name of the added news source</param>
        /// <param name="NewSourceURL">The URL of the XML file of the news source</param>
        public void AddNewSource(string NewSourceName, string NewSourceURL)
        //Procedura de adaugare a unei noi surse de stiri
        {
            SourceTitle.Add(NewSourceName);
            SourceURL.Add(NewSourceURL);
            IsSourceSelected.Add(true);
            NumberofSources++;
        }
        /// <summary>
        /// Edits a selected news source
        /// </summary>
        /// <param name="SourcePosition">The position of the selected news source in the news sources window</param>
        /// <param name="NewSourceName">The new name of the news source</param>
        /// <param name="NewSourceURL">The new URL of the XML file for the news source</param>
        /// <returns>true if no exception was thrown</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if SourcePosition points to a non-existent position. Unlikely but better be sure.</exception>
        public bool EditSource(int SourcePosition, string NewSourceName, string NewSourceURL)
        {
            try
            {
                SourceTitle[SourcePosition] = NewSourceName;
                SourceURL[SourcePosition] = NewSourceURL;
                return true;
            }
            catch (ArgumentOutOfRangeException A)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(A.Message, "Error!", MB, MI);
                return false;
            }
        }

        /// <summary>
        /// Removes the news source(s) indicated by their position numbers
        /// </summary>
        /// <param name="NewsNumbers">A list containing the position number(s) of the selected source(s)</param>
        /// <returns>true if the function doesn't throw any exceptions. Otherwise it returns false</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if SourcePosition points to a non-existent position. Unlikely but better be sure.</exception>
        public bool RemoveSource(List<int> NewsNumbers)
        {
            try
            {
                for (int i = 0; i < NewsNumbers.Count; i++)
                {
                    SourceTitle.RemoveAt(NewsNumbers[i]);
                    SourceURL.RemoveAt(NewsNumbers[i]);
                    NumberofSources--;
                }
                return true;
            }

            catch (ArgumentOutOfRangeException A)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(A.Message, "Error!", MB, MI);
                return false;
            }
        }

        /// <summary>
        /// Shows the selected news sources in the window datagrid
        /// </summary>
        /// <param name="Grid">The name of the grid component</param>
        public void ShowNewsSourcesInDataGrid(DataGridView Grid)
        {
            for (int i = 0; i < SourceTitle.Count; i++)
            {
                Grid.Rows.Add();
                Grid.Rows[i].Cells[0].Value = SourceTitle[i];
                Grid.Rows[i].Cells[1].Value = SourceURL[i];
            }
        }

        /// <summary>
        /// Returns the news source(s) URL(s)
        /// </summary>
        /// <returns>A list with the URL(s) of the news source(s)</returns>
        public List<string> GetNewsURL()
        {
            return SourceURL;
        }

        /// <summary>
        /// Clears the lists which have the data for the news sources. Useful if I don't want a news to appear twice.
        /// </summary>
        public void ClearSources()
        {
            SourceTitle.Clear();
            SourceURL.Clear();
            IsSourceSelected.Clear();
            NumberofSources = 0;
            NumberofSelectedSources = 0;
        }

        /// <summary>
        /// Moves the news source on a new position, depending on what kind of sorting it is chosen
        /// </summary>
        /// <param name="Position">The position of the news source that will be moved</param>
        /// <param name="SortingWay">Flag to determine on which position should the selected source be moved:</param>
        /// <remarks>SortingWay can have one of these 4 values:
        /// 1 - moves the news source one position higher (Up 1);
        /// 2 - moves the news source one position lower (Down 1);
        /// 3 - moves the news source on the first position (Move first);
        /// 4 - moves the news source on the last posibion (Move last)</remarks>
        public void SortSources(int Position, int SortingWay)
        {
            switch (SortingWay)
            {
                case 1:
                    {
                        if (Position > 0) //Nu pot muta mai sus cu o pozitie un element de pe prima pozitie
                        {
                            ExchangeElementsString(SourceTitle, Position - 1, Position);
                            ExchangeElementsString(SourceURL, Position - 1, Position);
                            ExchangeElementsBoolean(IsSourceSelected, Position - 1, Position);
                        }
                        break;
                    }

                case 2:
                    {
                        if (Position < SourceTitle.Count - 1) //Nu pot muta cu o pozitie mai jos un element de pe ultima pozitie
                        {
                            ExchangeElementsString(SourceTitle, Position + 1, Position);
                            ExchangeElementsString(SourceURL, Position + 1, Position);
                            ExchangeElementsBoolean(IsSourceSelected, Position + 1, Position);
                        }
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

                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// Exchanges two strings from a string list.
        /// </summary>
        /// <param name="List">The list to work with.</param>
        /// <param name="Pos1">The position of the first element to exchange.</param>
        /// <param name="Pos2">The position of the second element to exchange.</param>
        private void ExchangeElementsString(List<string> List, int Pos1, int Pos2)
        {
            string buffer = List[Pos1];
            List[Pos1] = List[Pos2];
            List[Pos2] = buffer;
        }

        /// <summary>
        /// Exchanges two strings from a boolean list.
        /// </summary>
        /// <param name="List">The list to work with.</param>
        /// <param name="Pos1">The position of the first element to exchange.</param>
        /// <param name="Pos2">The position of the second element to exchange.</param>
        private void ExchangeElementsBoolean(List<bool> List, int Pos1, int Pos2)
        {
            bool buffer = List[Pos1];
            List[Pos1] = List[Pos2];
            List[Pos2] = buffer;
        }

        /// <summary>
        /// Moves on the first position of a string list an element from a specified position.
        /// </summary>
        /// <param name="List">The list to work with.</param>
        /// <param name="PosFrom">The position of the element that will go on the first position.</param>
        private void MoveToFirstPositionString(List<string> List, int PosFrom)
        {
            string buffer = List[PosFrom];
            for (int i = PosFrom; i > 0; i--)
                List[i] = List[i - 1];
            List[0] = buffer;
        }

        /// <summary>
        /// Moves on the first position of a boolean list an element from a specified position.
        /// </summary>
        /// <param name="List">The list to work with.</param>
        /// <param name="PosFrom">The position of the element that will go on the first position.</param>
        private void MoveToFirstPositionBoolean(List<bool> List, int PosFrom)
        {
            bool buffer = List[PosFrom];
            for (int i = PosFrom; i > 0; i--)
                List[i] = List[i - 1];
            List[0] = buffer;
        }

        /// <summary>
        /// Moves on the last position of a string list an element from a specified position.
        /// </summary>
        /// <param name="List">The list to work with.</param>
        /// <param name="PosFrom">The position of the element that will go on the first position.</param>
        private void MoveToLastPositionString(List<string> List, int PosFrom)
        {
            string buffer = List[PosFrom];
            for (int i = PosFrom; i < List.Count - 1; i++)
                List[i] = List[i + 1];
            List[List.Count - 1] = buffer;
        }

        /// <summary>
        /// Moves on the last position of a boolean list an element from a specified position.
        /// </summary>
        /// <param name="List">The list to work with.</param>
        /// <param name="PosFrom">The position of the element that will go on the first position.</param>
        private void MoveToLastPositionBoolean(List<bool> List, int PosFrom)
        {
            bool buffer = List[PosFrom];
            for (int i = PosFrom; i < List.Count - 1; i++)
                List[i] = List[i + 1];
            List[List.Count - 1] = buffer;
        }
    }
}