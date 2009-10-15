using System;
using System.Windows.Forms;

namespace UI
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

        public ZoomDialog()
        {
            InitializeComponent();
        }

        /**
         * Once the user hits the "Zoom Image" button, this grabs the value from the dialog box.
         */
        private void ZoomButton_Click(object sender, EventArgs e)
        {
            ZoomLevel = float.Parse(ZoomTextBox.Text) / 100.0f;
        }
    }
}
