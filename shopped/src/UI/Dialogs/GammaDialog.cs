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
                if (string.IsNullOrEmpty(RedTextBox.Text))
                    RedTextBox.Text = "0";
                return Convert.ToDouble(RedTextBox.Text);
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

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if((RedComponent < 0.2 || RedComponent > 5.0) 
                || (GreenComponent < 0.2 || GreenComponent > 5.0) 
                || (BlueComponent < 0.2 || BlueComponent > 5.0))
            {
                MessageBox.Show("Values must be between 0.2 and 5.0");
                DialogResult = DialogResult.Retry;
            }
        }
    }
}
