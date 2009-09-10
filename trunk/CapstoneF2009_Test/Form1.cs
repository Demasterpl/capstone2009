using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace CapstoneF2009_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pictureBox1.Width = this.Width / 2;
            pictureBox1.Height = this.Height / 2;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
 
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.OpenFile());
                pictureBox1.Height = pictureBox1.Image.Height;
                pictureBox1.Width = pictureBox1.Image.Width;
            }
        }

        private void savePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = saveFileDialog.OpenFile()) != null)
                    {
                        pictureBox1.Image.Save(myStream, pictureBox1.Image.RawFormat);
                        myStream.Close();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
