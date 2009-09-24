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
    public partial class RotateDialog : Form
    {
        public float rotateDegrees;

        public RotateDialog()
        {
            InitializeComponent();
        }

        private void RotateDialog_Load(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            rotateDegrees = (float)Convert.ToDouble(RotateTextBox.Text);
        }

    }
}
