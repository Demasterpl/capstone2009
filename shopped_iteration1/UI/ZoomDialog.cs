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
    public partial class ZoomDialog : Form
    {
        public float zoomLevel;

        public ZoomDialog()
        {
            InitializeComponent();
        }

        private void ZoomButton_Click(object sender, EventArgs e)
        {
            zoomLevel = float.Parse(ZoomTextBox.Text) / 100.0f;
        }
    }
}
