using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Core;
using Core.Interfaces;
using Core.Images;

namespace UI
{
    public partial class ShoppedGui : Form
    {
        public string CurrentFileName { get; set; }
        public CurrentImage CurrentImage;
        public Image TempImage;
        public float Zoom;
        public float DegreesRotated;
        ImageRotate ImageRotate;


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
            saveImageButton.Enabled = false;
            savePictureToolStripMenuItem.Enabled = false;

            Zoom = 1.0f;
            CurrentImage = new CurrentImage();
            ImageRotate = new ImageRotate();
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
            OpenImage();
        }

        private void saveImageButton_Click(object sender, EventArgs e)
        {
            IFileOperations fileOperation = new FileOperations();
            fileOperation.SaveFile(TempImage, CurrentFileName);
        }

        private void openPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void savePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFileOperations fileOperation = new FileOperations();
            fileOperation.SaveFile(TempImage, CurrentFileName);
        }


        public void EnableGuiItems()
        {
            AdditionalInfo.Visible = true;
            toolsToolStripMenuItem.Enabled = true;
            editToolStripMenuItem.Enabled = true;
            viewToolStripMenuItem.Enabled = true;
            saveImageButton.Enabled = true;
            savePictureToolStripMenuItem.Enabled = true;
        }

        public void OpenImage()
        {
            IFileOperations fileOperation = new FileOperations();
            CurrentFileName = fileOperation.OpenFile(ref TempImage);

            SetPictureBox(TempImage);
            SetCurrentImage(TempImage);

            EnableGuiItems();
            SetAdditionalInfo();
        }

        public void SetPictureBox(Image image)
        {
            PictureBox.Height = image.Height;
            PictureBox.Width = image.Width;
            PictureBox.Image = image;
        }

        public void SetCurrentImage(Image image)
        {
            CurrentImage.CurrentHeight = image.Height;
            CurrentImage.CurrentWidth = image.Width;
            CurrentImage.DegreesRotated = DegreesRotated;
            CurrentImage.InitialImage = image;
        }

        public void ZoomImage(float zoom)
        {
            if (zoom == 1.0f)
            {
                TempImage = ImageRotate.RotateImageByAngle(CurrentImage.InitialImage, DegreesRotated);
                SetPictureBox(TempImage);
            }
            else
            {
                TempImage = new Bitmap(TempImage,(int)(TempImage.Width * zoom), (int)(TempImage.Height * zoom));
                SetPictureBox(TempImage);
            }
            Zoom = zoom;
        }

        public void ResizeImage(float resize)
        {
            TempImage = new Bitmap(TempImage, (int)(TempImage.Width * resize), (int)(TempImage.Height * resize));
            CurrentImage.InitialImage = TempImage;
            SetPictureBox(CurrentImage.InitialImage);
            SetAdditionalInfo();
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
                DegreesRotated += (rotateDialog.rotateDegrees % 360.0f);

                TempImage = ImageRotate.RotateImageByAngle(CurrentImage.InitialImage, DegreesRotated);
                ZoomImage(Zoom);
                PictureBox.Image = TempImage;
                PictureBox.Refresh();
            }

        }

        private void zoomImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var zoomDialog = new ZoomDialog();
            zoomDialog.ShowDialog();

            if (zoomDialog.DialogResult == DialogResult.OK)
            {
                ZoomImage(zoomDialog.zoomLevel);
                PictureBox.Refresh();
            }
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resizeDialog = new ResizeDialog();
            resizeDialog.ShowDialog();

            if (resizeDialog.DialogResult == DialogResult.OK)
            {
                ResizeImage(resizeDialog.resizeLevel);
                PictureBox.Refresh();
            }
        }
    }
}