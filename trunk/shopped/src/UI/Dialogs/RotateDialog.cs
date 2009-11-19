using System;
using System.Windows.Forms;

namespace UI.Dialogs
{
    /**
     * The RotateDialog class displays a small dialog box to prompt the user for
     * an amount to rotate the image loaded into the editor.
     * 
     * @param RotateDegrees Contains the amount of rotation (in degrees) the user specifies.
     */

    public partial class RotateDialog : Form
    {
        public float RotateDegrees;
        
        /**
         * A constructor for RotateDialog
         * 
         * @param zoomLevel The amount of zoom of the current image in Shopped GUI
         */

        public RotateDialog(float zoomLevel)
        {
            InitializeComponent();

            //Warn user that zoom level will be reset to 100%
            if (zoomLevel != 1.0f)
            {
                ZoomWarningLabel.Visible = true;
            }
            else
            {
                ZoomWarningLabel.Visible = false;
            }

        }


        /**
         * Once the user hits the "Rotate Image" button, this grabs the value from the dialog box.
         */
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                RotateDegrees = float.Parse(RotateTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Invalid input. Must be integer value");
                DialogResult = DialogResult.Retry;
            }
        }

    }
}
