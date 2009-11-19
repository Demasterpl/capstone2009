using System;
using System.Windows.Forms;

namespace UI.Dialogs
{
    /**
     * A dialog that prompts the user to input a level for the Brightness filter.
     * 
     * @param BrightnessLevel The level of brightness to apply in the filter.
     */
    public partial class BrightnessDialog : Form
    {
        public float BrightnessLevel;

        /**
         * Default constructor for BrignessDialog.
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
            try
            {
                BrightnessLevel = float.Parse(BrightnessTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Brightness level must be integer between -255 and 255.");
                DialogResult = DialogResult.Retry;
            }

            if (!IsValidBrightnessLevel())
            {
                MessageBox.Show("Brightness level must be integer between -255 and 255.");
                DialogResult = DialogResult.Retry;
            }
        }
        
        /**
         * Checks the user's input to make sure it is valid.
         */
        private bool IsValidBrightnessLevel()
        {
            return BrightnessLevel >= -255.0f && BrightnessLevel <= 255.0f;
        }
    }
}
