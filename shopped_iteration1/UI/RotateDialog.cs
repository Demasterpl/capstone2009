using System;
using System.Windows.Forms;

namespace UI
{
    /**
     * The RotateDialog class displays a small windows form to prompt the user for
     * an amount to rotate the image loaded into the editor.
     * 
     * @param RotateDegrees Contains the amount of rotation (in degrees) the user specifies.
     */
    public partial class RotateDialog : Form
    {
        public float RotateDegrees;

        public RotateDialog()
        {
            InitializeComponent();
        }

        private void RotateDialog_Load(object sender, EventArgs e)
        {

        }

        /**
         * Once the user hits the "Rotate Image" button, this grabs the value from the dialog box.
         */
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            RotateDegrees = float.Parse(RotateTextBox.Text);
        }

    }
}
