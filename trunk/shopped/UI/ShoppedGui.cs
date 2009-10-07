using System;
using System.Drawing;
using System.Windows.Forms;
using Core;
using Core.Interfaces;
using Core.Images;

namespace UI
{
    /**
     * The class that loads, runs and handles events of the Shopped main GUI.
     * @param CurrentFileName The absolute path to the image file loaded.
     * @param CurrentImage Holds the state of the current image in the GUI.
     * @param TempImage Holds temporary states of the image in the GUI (i.e. zoom).
     * @param Zoom How much the image is zoomed in the GUI (1.0 == 100%).
     * @param DegreesRotated Holds the value for how much the image is rotated in the GUI (in degrees).
     * @param ImageRotate Instance of ImageRotate class to handle rotating the image.
     * @param FileOperation Instance of FileOperation class to handle opening/saving the image.
     */
    public partial class ShoppedGui : Form
    {
        public string CurrentFileName { get; set; }
        public CurrentImage CurrentImage;
        public Image TempImage;
        public float Zoom;
        public float DegreesRotated;
        public ImageRotate ImageRotate;
        public IFileOperations FileOperation;
        public ImageHistory ImageHistory; 



        public ShoppedGui()
        {
            InitializeComponent();
        }

        /**
         * Initial loading of the Shopped program. Disables certain features/options
         * that should not be available until an image is loaded into the program.
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            AdditionalInfo.Visible = false;
            toolsToolStripMenuItem.Enabled = false;
            editToolStripMenuItem.Enabled = false;
            viewToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            saveImageButton.Enabled = false;
            savePictureToolStripMenuItem.Enabled = false;

            Zoom = 1.0f;
            CurrentImage = new CurrentImage();
            ImageRotate = new ImageRotate();
            FileOperation = new FileOperations();
            ImageHistory = new ImageHistory();
        }



        /**
         * Handles the event of clicking File->Exit menu item. Exits the program.
         */
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /**
         * Handles the event of clicking Help->About menu item. Displays message box
         * containing information about Shopped (developer names, program info).
         */
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed Fall 2009 at Kent State University\nGroup 4\n\n\nGreg Beca\nAndy Vanek\nDaniel Sheaffer","About Us");
        }


        /**
         * Handles the event of clicking "Open Image" icon.
         */
        private void openPictureButton_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        /**
         * Handles the event of clicking "Save Image" icon.
         */
        private void saveImageButton_Click(object sender, EventArgs e)
        {
            FileOperation.SaveFile(TempImage, CurrentFileName);
        }

        /**
         * Handles the event of clicking File->Open Picture menu item.
         */
        private void openPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        /**
         * Handles the event of clicking File->Save Picture menu item.
         */
        private void savePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOperation.SaveFile(TempImage, CurrentFileName);
        }

        /**
         * Called upon once an image is loaded from file, this enables the features/options
         * that can now be used.
         */
        public void EnableGuiItems()
        {
            AdditionalInfo.Visible = true;
            toolsToolStripMenuItem.Enabled = true;
            editToolStripMenuItem.Enabled = true;
            viewToolStripMenuItem.Enabled = true;
            saveImageButton.Enabled = true;
            savePictureToolStripMenuItem.Enabled = true;
        }

        /**
         * Uses FileOperation instance to prompt user to open an image file.
         * Sets the image in the editor once image is opened.
         */
        public void OpenImage()
        {
            CurrentFileName = FileOperation.OpenFile(ref TempImage);

            SetPictureBox(TempImage);
            SetCurrentImage(TempImage);

            EnableGuiItems();
            SetAdditionalInfo();
        }

        /**
         * Sets the PictureBox to the image passed to this method.
         * @param image The image to set the PictureBox to.
         */
        public void SetPictureBox(Image image)
        {
            PictureBox.Height = image.Height;
            PictureBox.Width = image.Width;
            PictureBox.Image = image;
            AddImageToImageHistory(PictureBox.Image);
            SetUndoAndRedo();
        }

        public void SetPictureBoxOnUndoOrRedo(Image image)
        {
            PictureBox.Height = image.Height;
            PictureBox.Width = image.Width;
            PictureBox.Image = image;
            SetUndoAndRedo();
        }

        /**
         * Sets the CurrentImage object with the values of the parameter.
         * @param image The image to set CurrentImage to.
         */
        public void SetCurrentImage(Image image)
        {
            CurrentImage.CurrentHeight = image.Height;
            CurrentImage.CurrentWidth = image.Width;
            CurrentImage.DegreesRotated = DegreesRotated;
            CurrentImage.InitialImage = image;
        }

        /**
         * Zooms the image in the Shopped GUI to the specified zoom level.
         * @param zoom The amount of zoom to use on the image (1.0f == 100%).
         */
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

        /**
         * Resizes the image in the Shopped GUI to the specified resize level.
         * @param resize The amount to resize the image to.
         */
        public void ResizeImage(float resize)
        {
            TempImage = new Bitmap(TempImage, (int)(TempImage.Width * resize), (int)(TempImage.Height * resize));
            CurrentImage.InitialImage = TempImage;
            SetPictureBox(CurrentImage.InitialImage);
            SetAdditionalInfo();
        }

        /**
         * Sets the information about the PictureBox image that is located at the bottom of the Shopped GUI.
         * Information includes height, width and the name of the image.
         */
        public void SetAdditionalInfo()
        {
            AdditionalInfo.Text = string.Format("Height: {0} | Width: {1} | Name: {2}", 
                PictureBox.Height, PictureBox.Width, System.IO.Path.GetFileName(CurrentFileName));
        }

        /**
         * Handles the event of clicking the Tools->Rotate menu item. Displays the RotateDialog windows form,
         * obtains the value to rotate from the form, then rotates the image according to the rotate value.
         */
        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rotateDialog = new RotateDialog();
            rotateDialog.ShowDialog();

            if (rotateDialog.DialogResult == DialogResult.OK)
            {
                DegreesRotated += (rotateDialog.RotateDegrees % 360.0f);

                TempImage = ImageRotate.RotateImageByAngle(CurrentImage.InitialImage, DegreesRotated);
                ZoomImage(Zoom);
                //SetPictureBox(TempImage);
                PictureBox.Refresh();
            }
        }

        /**
         * Handles the event of clicking the View->Zoom Image menu item. Displays the ZoomDialog windows form,
         * obtains the value to zoom from the form, then zooms the image according to the zoom value.
         */
        private void zoomImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var zoomDialog = new ZoomDialog();
            zoomDialog.ShowDialog();

            if (zoomDialog.DialogResult == DialogResult.OK)
            {
                ZoomImage(zoomDialog.ZoomLevel);
                PictureBox.Refresh();
            }
        }

        /**
         * Handles the event of clicking the Tools->Resize menu item. Displays the ResizeDialog windows form,
         * obtains the value to resize from the form, then resizes the image according to the resize value.
         */
        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resizeDialog = new ResizeDialog();
            resizeDialog.ShowDialog();

            if (resizeDialog.DialogResult == DialogResult.OK)
            {
                ResizeImage(resizeDialog.ResizeLevel);
                PictureBox.Refresh();
            }
        }

        private void AddImageToImageHistory(Image image)
        {
            ImageHistory.AddImageToImageHistory(image);
        }

        private void SetUndoAndRedo()
        {
            int count = ImageHistory.GetNumberOfImagesInHistory();
            int revision = ImageHistory.GetCurrentRevision();

            //for redo
            if (revision >= 0 && revision != (count - 1))
            {
                redoToolStripMenuItem.Enabled = true;
            }
            else
            {
                redoToolStripMenuItem.Enabled = false;
            }

            //for undo
            if (count > 1 && revision > 0)
            {
                undoToolStripMenuItem.Enabled = true;
            }
            else
            {
                undoToolStripMenuItem.Enabled = false;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPictureBoxOnUndoOrRedo(ImageHistory.Undo());
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPictureBoxOnUndoOrRedo(ImageHistory.Redo());
        }
    }
}