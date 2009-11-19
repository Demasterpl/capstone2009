using System;
using System.Windows.Forms;

namespace UI.Dialogs
{
    /**
     * The ZoomDialog class displays a small dialog box to prompt the user for
     * an amount to zoom the image loaded into the editor.
     * 
     * @param ZoomLevel Contains the amount of zoom the user specifies.
     */
    public partial class ZoomDialog : Form
    {
        public float ZoomLevel;

        /**
         * The default constructor.
         */
        public ZoomDialog()
        {
            InitializeComponent();
        }

        /**
         * Once the user hits the "Zoom Image" button, this grabs the value from the dialog box.
         */
        private void ZoomButton_Click(object sender, EventArgs e)
        {
            try
            {
                ZoomLevel = float.Parse(ZoomTextBox.Text) / 100.0f;
            }
            catch
            {
                MessageBox.Show("Zoom level must be positive, greater than 5% and less than 200%");
                DialogResult = DialogResult.Retry;
            }

            if (!IsValidZoomLevel())
            {
                MessageBox.Show("Zoom level must be positive, greater than 5% and less than 200%");
                DialogResult = DialogResult.Retry;
            }
        }

        /**
         * Determines if the user input is within the allowable zoom range.
         */
        private bool IsValidZoomLevel()
        {
            return ZoomLevel > 0.05f && ZoomLevel < 2.0f;
        }
    }
}
