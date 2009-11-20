using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI.Dialogs
{
    public partial class GammaDialog : Form
    {
        public float RedLevel;
        public float BlueLevel;
        public float GreenLevel;

        public GammaDialog()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            RedLevel = float.Parse(RedTextBox.Text);
            BlueLevel = float.Parse(BlueTextBox.Text);
            GreenLevel = float.Parse(GreenTextBox.Text);

            if (!IsValidLevels())
            {
                MessageBox.Show("Invalid level. Each value must be between 0.2 and 5.0");
                DialogResult = DialogResult.Retry;
            }
        }

        private bool IsValidLevels()
        {
            return ((RedLevel >= 0.2f && RedLevel <= 5.0f) &&
            (BlueLevel >= 0.2f && BlueLevel <= 5.0f) &&
            (GreenLevel >= 0.2f && GreenLevel <= 5.0f));
        }
    }
}
