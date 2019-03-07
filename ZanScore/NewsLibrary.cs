using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System;

namespace ZanScore
{
    public partial class NewsLibrary : Form
    {
        private static int absoluteindex = 0;

        static public List<string> NewsSourcesList = new List<string>() { };
        public List<string> NewsCategoriesList = new List<string>() { };
        static public List<string> NewsSourcesRSSList = new List<string>() { };

        static public int AbsoluteIndex //calculeaza numarul de ordine al unei stiri din lista de stiri citita si stocata in cele trei liste declarate mai sus
        {
            get
            {
                return absoluteindex;
            }
            set
            {
                if (value >= 0)
                    absoluteindex = value;
                else
                    absoluteindex = 0;
            }
        }

        public NewsLibrary()
        {
            InitializeComponent();
            ClearLists();
            OpenLibraryFile();
        }

        private void ClearLists()
        {
            NewsSourcesList.Clear();
            NewsCategoriesList.Clear();
            NewsSourcesRSSList.Clear();
        }

        public bool ReadFromLibrary()
        //Procedura citeste din biblioteca si umple cele trei liste. Am setat-o ca publica pentru a putea fi testata.
        {
            string[] ReadBuffer = new string[] { };
            try
            {
                ReadBuffer = File.ReadAllLines("Library.txt");
                int i = 0, found = 0, j = 0;
                for (i = 0; i < ReadBuffer.Length; i += 3)
                {
                    ReadBuffer[i] = ReadBuffer[i].Trim();
                    NewsSourcesList.Add(ReadBuffer[i]);
                    found = ReadBuffer[i].IndexOf(":");
                    NewsSourcesList[j] = (found == -1 ? "" : NewsSourcesList[j].Substring(found + 1));

                    ReadBuffer[i + 1] = ReadBuffer[i + 1].Trim();
                    NewsCategoriesList.Add(ReadBuffer[i + 1]);
                    found = ReadBuffer[i + 1].IndexOf(":");
                    NewsCategoriesList[j] = (found == -1 ? "" : NewsCategoriesList[j].Substring(found + 1));

                    ReadBuffer[i + 2] = ReadBuffer[i + 2].Trim();
                    NewsSourcesRSSList.Add(ReadBuffer[i + 2]);
                    found = ReadBuffer[i + 2].IndexOf(":");
                    NewsSourcesRSSList[j] = (found == -1 ? "" : NewsSourcesRSSList[j].Substring(found + 1));

                    j++;
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
            catch (ArgumentOutOfRangeException A) //Exceptie pentru Substring. Ma indoiesc ca va fi ridicata vreodata, dar mai bine sa fiu precaut.
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(A.Message, "Error!", MB, MI);
                return false;
            }
        }

        private void FillWindowDatagrid(int Category)
        /*Procedura ia datele din cele trei liste si umple datagrid-ul in functie de categoria selectata. Valorile pentru Category sunt:
         0 - National & World News;
         1 - Sports;
         2 - Gaming;
         3 - Lifestyle;
         4 - Music;
         5 - Science;
         6 - Technology;
         7 - Politics;
         8 - Entertainment;
         9 - Business;*/
        {
            int LowerBound = 0, UpperBound = 0, j = 0;
            try
            {
                NewsLibrarySourcesView.Rows.Clear();
                switch (Category)
                {
                    case 0:
                        {
                            LowerBound = 0;
                            UpperBound = 26;
                            break;
                        }
                    case 1:
                        {
                            LowerBound = 27;
                            UpperBound = 43;
                            break;
                        }
                    case 2:
                        {
                            LowerBound = 44;
                            UpperBound = 52;
                            break;
                        }
                    case 3:
                        {
                            LowerBound = 53;
                            UpperBound = 94;
                            break;
                        }
                    case 4:
                        {
                            LowerBound = 95;
                            UpperBound = 102;
                            break;
                        }
                    case 5:
                        {
                            LowerBound = 103;
                            UpperBound = 117;
                            break;
                        }
                    case 6:
                        {
                            LowerBound = 118;
                            UpperBound = 129;
                            break;
                        }
                    case 7:
                        {
                            LowerBound = 130;
                            UpperBound = 136;
                            break;
                        }
                    case 8:
                        {
                            LowerBound = 137;
                            UpperBound = 143;
                            break;
                        }
                    case 9:
                        {
                            LowerBound = 144;
                            UpperBound = 150;
                            break;
                        }
                    default: //Pentru cazurile in care functia primeste o alta valoare, care nu se afla in vreo categorie. Nu cred ca acest lucru se va intampla, dar prefer sa fiu precaut
                        {
                            LowerBound = 0;
                            UpperBound = 26;
                            break;
                        }
                }
                for (int i = LowerBound; i <= UpperBound; i++)
                {
                    NewsLibrarySourcesView.Rows.Add();
                    NewsLibrarySourcesView.Rows[j].Cells[0].Value = NewsSourcesList[i];
                    j++;
                }
                NewsLibrarySourcesView.Rows[0].Selected = true;
            }
            catch (InvalidOperationException I)
            {
                MessageBoxButtons MB = MessageBoxButtons.OK;
                MessageBoxIcon MI = MessageBoxIcon.Error;
                MessageBox.Show(I.Message, "Error!", MB, MI);
            }
        }

        private void OpenLibraryFile()
        //Instructiunile de deschidere a bibliotecii
        {
            if (ReadFromLibrary())
            {
                CategoryListBox.SelectedIndex = 0;
                FillWindowDatagrid(0);
            }
            else
            {
                Close();
            }
        }

        private void ChangeNewsSourcesCategory(object sender, System.EventArgs e)
        //Procedura afiseaza sursele in functie de categoria selectata
        {
            FillWindowDatagrid(CategoryListBox.SelectedIndex);
        }

        private int ReturnFirstSelected(DataGridView Grid)
        //Functia intoarce pozitia primului element selectat din grila.
        {
            int SelectedPosition = 0;
            for (int i = 0; i < Grid.RowCount; i++)
                if (Grid.Rows[i].Selected)
                    SelectedPosition = i;
            return SelectedPosition;
        }

        private int ComputeAbsoluteIndex()
        {
            int Category = 0, Place = 0;
            switch (CategoryListBox.SelectedIndex)
            {
                case 0:
                    {
                        Category = 0;
                        break;
                    }
                case 1:
                    {
                        Category = 27;
                        break;
                    }
                case 2:
                    {
                        Category = 44;
                        break;
                    }
                case 3:
                    {
                        Category = 53;
                        break;
                    }
                case 4:
                    {
                        Category = 95;
                        break;
                    }
                case 5:
                    {
                        Category = 103;
                        break;
                    }
                case 6:
                    {
                        Category = 118;
                        break;
                    }
                case 7:
                    {
                        Category = 130;
                        break;
                    }
                case 8:
                    {
                        Category = 137;
                        break;
                    }
                case 9:
                    {
                        Category = 144;
                        break;
                    }
            }
            Place = ReturnFirstSelected(NewsLibrarySourcesView);
            return Category + Place;
        }

        private void VisitTheSelectedSource(object sender, System.EventArgs e)
        //Procedura de vizitare a sursei selectate
        {
            AbsoluteIndex = ComputeAbsoluteIndex();
            ((Form1)Owner).DownloadAllNewsProcess(false);
            Close();
        }
    }
}
