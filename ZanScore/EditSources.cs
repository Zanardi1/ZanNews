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
    public partial class EditSources : Form
    {
        public EditSources()
        {
            InitializeComponent();
            SourceNameToEdit.Width = AllTheSources.Width / 3;
            SourceURLToEdit.Width = 2 * AllTheSources.Width / 3;
        }
    }
}
