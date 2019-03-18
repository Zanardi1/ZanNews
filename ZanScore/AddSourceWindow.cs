using System;
using System.Windows.Forms;

namespace ZanScore
{
    /// <summary>
    /// The class for the source adding window
    /// </summary>
    public partial class AddSourceWindow : Form
    {

        /// <summary>
        /// Stores the name of the new source, that is added by the user
        /// </summary>
        public string NewName { get; set; }
        /// <summary>
        /// Stores the URL of the new source, that is added by the user
        /// </summary>
        public string NewURL { get; set; }

        private void SaveNewData(object sender, EventArgs e)
        {
            NewName = SourceNameText.Text;
            NewURL = SourceURLText.Text;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public AddSourceWindow()
        {
            InitializeComponent();
        }
    }
}
