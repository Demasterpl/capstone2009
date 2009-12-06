using System;
using System.Windows.Forms;

namespace UI.Dialogs
{
    public partial class GammaDialog : Form
    {
        public GammaDialog()
        {
            InitializeComponent();
            AcceptButton.DialogResult = DialogResult.OK;
        }

        public double RedComponent
        {
            get
            {
                if (string.IsNullOrEmpty(GreenTextBox.Text))
                    RedTextBox.Text = "0";
                return Convert.ToDouble(GreenTextBox.Text);
            }
            set { RedTextBox.Text = value.ToString(); }
        }

        public double GreenComponent
        {
            get
            {
                if (string.IsNullOrEmpty(GreenTextBox.Text))
                    GreenTextBox.Text = "0";
                return Convert.ToDouble(GreenTextBox.Text);
            }
            set { GreenTextBox.Text = value.ToString(); }
        }

        public double BlueComponent
        {
            get
            {
                if (string.IsNullOrEmpty(BlueTextBox.Text))
                    BlueTextBox.Text = "0";
                return Convert.ToDouble(BlueTextBox.Text);
            }
            set { BlueTextBox.Text = value.ToString(); }
        }
    }
}
