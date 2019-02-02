using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ZanScore
{
    public partial class NewsLibrary : Form
    {
        List<string> NewsSourcesList = new List<string>() { };
        List<string> NewsCategoriesList = new List<string>() { };
        List<string> NewsSourcesRSSList = new List<string>() { };

        //todo de adaugat surse de stiri cautate de catre mine

        public NewsLibrary()
        {
            InitializeComponent();
            OpenLibraryFile();
        }

        private bool CheckIfFileExists()
        //Verifica daca fisierul ce contine biblioteca exista
        {
            if (!File.Exists("Library.txt"))
                return false;
            else
                return true;
        }

        private void ReadFromLibrary()
        //Procedura citeste din biblioteca si umple cele trei liste
        {
            string[] ReadBuffer = new string[] { };
            string[] BufferLine = new string[] { };
            ReadBuffer = File.ReadAllLines("Library.txt");
            int i = 0;
            while (i < ReadBuffer.Length)
            {
                BufferLine = ReadBuffer[i].Split(separator: new char[] { ':' });
                NewsSourcesList.Add(BufferLine[1]);
                i++;
                BufferLine = ReadBuffer[i].Split(separator: new char[] { ':' });
                NewsCategoriesList.Add(BufferLine[1]);
                i++;
                BufferLine = ReadBuffer[i].Split(separator: new char[] { ':' });
                NewsSourcesRSSList.Add(BufferLine[1]);
                i++;
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

        }

        private void OpenLibraryFile()
        {
            if (!CheckIfFileExists())
            {
                MessageBox.Show("Library file missing. This window will now close.");
                Close();
            }
            else
            {
                ReadFromLibrary();
                CategoryListBox.SelectedIndex = 0;
                FillWindowDatagrid(0);
            }
        }

        private void ChangeNewsSourcesCategory(object sender, System.EventArgs e)
        //Procedura afiseaza sursele in functie de categoria selectata
        {
            FillWindowDatagrid(CategoryListBox.SelectedIndex);
        }
    }
}
