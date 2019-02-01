using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZanScore
{
    public partial class NewsLibrary : Form
    {
        List<string> NewsSourceNames = new List<string>() { };
        List<string> NewsCategories = new List<string>() { };
        List<string> NewsSourcesRSS = new List<string>() { };

        //todo de adaugat surse de stiri cautate de catre mine

        public NewsLibrary()
        {
            InitializeComponent();
        }
    }
}
