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
    public partial class AddSourceWindow : Form
    {
        public string NewName, NewURL;

        private void SaveNewData(object sender, EventArgs e)
        {
            NewName = SourceNameText.Text;
            NewURL = SourceURLText.Text;
        }

        public AddSourceWindow()
        {
            InitializeComponent();
        }
    }
}
