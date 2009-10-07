using System;
using System.Windows.Forms;

namespace UI
{
    /**
     * The ResizeDialog class displays a small windows form to prompt the user for
     * an amount to resize the image loaded into the editor.
     * 
     * @param ResizeLevel Contains the amount of resize the user specifies.
     */
    public partial class ResizeDialog : Form
    {
        public float ResizeLevel;

        public ResizeDialog()
        {
            InitializeComponent();
        }

        /**
         * Once the user hits the "Resize Image" button, this grabs the value from the dialog box.
         */
        private void ResizeButton_Click(object sender, EventArgs e)
        {
            ResizeLevel = float.Parse(ResizeTextBox.Text) / 100.0f;
        }
    }
}
