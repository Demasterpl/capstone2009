using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Core;
using Core.Interfaces;

namespace CapstoneF2009_Test
{
    public partial class Form1 : Form
    {
        public string CurrentFileName { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed Fall 2009 at Kent State University\nGroup 4\n\n\nGreg Beca\nAndy Vanek\nDaniel Sheaffer","About Us");
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void openPictureButton_Click(object sender, EventArgs e)
        {
            IFileOperations fileOperation = new FileOperations();
            CurrentFileName = fileOperation.OpenFile(PictureBox);
        }

        private void saveImageButton_Click(object sender, EventArgs e)
        {
            IFileOperations fileOperation = new FileOperations();
            fileOperation.SaveFile(PictureBox, CurrentFileName);
        }

        private void openPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFileOperations fileOperation = new FileOperations();
            fileOperation.OpenFile(PictureBox);
        }

        private void savePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFileOperations fileOperation = new FileOperations();
            fileOperation.SaveFile(PictureBox, CurrentFileName);
        }



    }
}
