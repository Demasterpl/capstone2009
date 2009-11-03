using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
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
