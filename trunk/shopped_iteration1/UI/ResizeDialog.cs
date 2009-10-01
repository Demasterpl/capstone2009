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
    public partial class ResizeDialog : Form
    {
        public float resizeLevel;

        public ResizeDialog()
        {
            InitializeComponent();
        }

        private void ResizeButton_Click(object sender, EventArgs e)
        {
            resizeLevel = float.Parse(ResizeTextBox.Text) / 100.0f;
        }
    }
}
