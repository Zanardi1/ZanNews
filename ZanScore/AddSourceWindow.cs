using System;
using System.Windows.Forms;

namespace ZanScore
{
    public partial class AddSourceWindow : Form
    {

        public string NewName { get; set; }
        public string NewURL { get; set; }

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
