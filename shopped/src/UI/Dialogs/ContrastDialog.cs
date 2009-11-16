using System;
using System.Windows.Forms;

namespace UI.Dialogs
{
    public partial class ContrastDialog : Form
    {
        public float ContrastLevel;

        /**
         * A constructor for ContrastDialog
         */

        public ContrastDialog()
        {
            InitializeComponent();
        }

        /**
         * Once the user hits the "Accept" button, this grabs the value from the dialog box.
         */

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            ContrastLevel = float.Parse(ContrastTextBox.Text);
        }
    }
}
