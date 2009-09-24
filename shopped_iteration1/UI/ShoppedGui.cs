using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Core;
using Core.Interfaces;

namespace UI
{
    public partial class ShoppedGui : Form
    {
        public string CurrentFileName { get; set; }
        public int OriginalHeight { get; set; }
        public int OriginalWidth { get; set; }
        public Image OriginalImage { get; set; }

        public ShoppedGui()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AdditionalInfo.Visible = false;
            toolsToolStripMenuItem.Enabled = false;
            editToolStripMenuItem.Enabled = false;
            viewToolStripMenuItem.Enabled = false;
            ZoomBox.Enabled = false;
            saveImageButton.Enabled = false;
            savePictureToolStripMenuItem.Enabled = false;
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

            OriginalHeight = PictureBox.Height;
            OriginalWidth = PictureBox.Width;
            OriginalImage = PictureBox.Image;
            EnableGuiItems();
            SetAdditionalInfo();
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

            OriginalHeight = PictureBox.Height;
            OriginalWidth = PictureBox.Width;
            OriginalImage = PictureBox.Image;

            EnableGuiItems();
            SetAdditionalInfo();

        }

        private void savePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFileOperations fileOperation = new FileOperations();
            fileOperation.SaveFile(PictureBox, CurrentFileName);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PictureBox.Height = OriginalHeight;
            PictureBox.Width = OriginalWidth;
            PictureBox.Image = OriginalImage;
            SetAdditionalInfo();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            PictureBox.Height = OriginalHeight * 2;
            PictureBox.Width = OriginalWidth * 2;
            PictureBox.Image = new Bitmap(OriginalImage, PictureBox.Size);

            OriginalImage = PictureBox.Image;
            OriginalHeight = OriginalImage.Height;
            OriginalWidth = OriginalImage.Width;

            SetAdditionalInfo();
        }

        public void EnableGuiItems()
        {
            AdditionalInfo.Visible = true;
            toolsToolStripMenuItem.Enabled = true;
            editToolStripMenuItem.Enabled = true;
            viewToolStripMenuItem.Enabled = true;
            saveImageButton.Enabled = true;
            ZoomBox.Enabled = true;
            savePictureToolStripMenuItem.Enabled = true;
        }

        public void SetAdditionalInfo()
        {
            AdditionalInfo.Text = string.Format("Height: {0} | Width: {1} | Name: {2}", PictureBox.Height, PictureBox.Width, System.IO.Path.GetFileName(CurrentFileName));
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rotateDialog = new RotateDialog();
            rotateDialog.ShowDialog();

            if (rotateDialog.DialogResult == DialogResult.OK)
            {
                var imageRotate = new ImageRotate();

                Image rotatedImage = imageRotate.RotateImageByAngle(PictureBox.Image, rotateDialog.rotateDegrees);
                PictureBox.Image = new Bitmap(rotatedImage);
            }

        }
    }
}