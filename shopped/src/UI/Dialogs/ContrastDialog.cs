using System;
using System.Windows.Forms;

namespace UI.Dialogs
{
    /**
     * A dialog box that prompts user for the contrast level to apply to the image.
     * 
     * @param ContrastLevel The level of contrast to apply in the contrast filter.
     */
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
            try
            {
                ContrastLevel = float.Parse(ContrastTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Contrast level must be integer between -100 and 100.");
                DialogResult = DialogResult.Retry;
            }


            if (!IsValidContrastLevel())
            {                
                MessageBox.Show("Contrast level must be integer between -100 and 100.");
                DialogResult = DialogResult.Retry;
            }
        }

        /**
         * Checks if user's input for contrast level is within bounds and is valid.
         */
        private bool IsValidContrastLevel()
        {
            return ContrastLevel >= -100.0f && ContrastLevel <= 100.0f;
        }
    }
}
