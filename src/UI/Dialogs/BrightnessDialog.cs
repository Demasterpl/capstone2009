using System;
using System.Windows.Forms;

namespace UI.Dialogs
{
    public partial class BrightnessDialog : Form
    {
        public float BrightnessLevel;

        /**
         * A constructor for BrignessDialog
         */

        public BrightnessDialog()
        {
            InitializeComponent();
        }

        /**
         * Once the user hits the "Accept" button, this grabs the value from the dialog box.
         */

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            BrightnessLevel = float.Parse(BrightnessTextBox.Text);
        }
    }
}
