using System;
using System.Windows.Forms;
using Core;
using Core.Images;
using System.Drawing;
using NLog;

namespace UI
{
    /**
     * The class that loads, runs and handles events of the Shopped main GUI.
     * 
     * @param _shoppedGuiHelper An instance of the ShoppedGuiHelper class.
     * @param _logger An instance of nLogger, which allows us to write debug statements to file.
     *
     */
    public partial class ShoppedGui : Form
    {
        private ShoppedGuiHelper _shoppedGuiHelper;
        private static Logger _logger = LogManager.GetCurrentClassLogger(); 

        public ShoppedGui()
        {
            InitializeComponent();

            _shoppedGuiHelper = new ShoppedGuiHelper();
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
            grayscaleToolStripMenuItem1.Enabled = false;
            sepiaToolStripMenuItem.Enabled = false;
            brightnessToolStripMenuItem.Enabled = false;
            FilterToolStripButton.Enabled = false;
            UndoToolStripButton.Enabled = false;
            RedoToolStripButton.Enabled = false;
            ResizeToolStripButton.Enabled = false;
            RotateToolStripButton.Enabled = false;
            ZoomToolStripButton.Enabled = false;
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
            _shoppedGuiHelper.FileOperation.SaveFile(_shoppedGuiHelper.CurrentImage);
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
            _shoppedGuiHelper.FileOperation.SaveFile(_shoppedGuiHelper.CurrentImage);
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
            grayscaleToolStripMenuItem1.Enabled = true;
            sepiaToolStripMenuItem.Enabled = true;
            brightnessToolStripMenuItem.Enabled = true;
            FilterToolStripButton.Enabled = true;
            UndoToolStripButton.Enabled = true;
            RedoToolStripButton.Enabled = true;
            ResizeToolStripButton.Enabled = true;
            RotateToolStripButton.Enabled = true;
            ZoomToolStripButton.Enabled = true;
        }

        /**
         * Handles the event of clicking the Tools->Rotate menu item. Displays the RotateDialog windows form,
         * obtains the value to rotate from the form, then rotates the image according to the rotate value.
         */
        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage();
        }

        /**
         * Handles the event of clicking the View->Zoom Image menu item. Displays the ZoomDialog windows form,
         * obtains the value to zoom from the form, then zooms the image according to the zoom value.
         */
        private void zoomImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomImage();
        }

        /**
         * Handles the event of clicking the Tools->Resize menu item. Displays the ResizeDialog windows form,
         * obtains the value to resize from the form, then resizes the image according to the resize value.
         */
        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizeImage();
        }

        /**
         * Handles the event of clicking the Edit->Undo menu item.
         */
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPictureBoxOnUndoOrRedo(_shoppedGuiHelper.ImageHistory.Undo());
        }

        /**
         * Handles the event of clicking the Edit->Redo menu item.
         */
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPictureBoxOnUndoOrRedo(_shoppedGuiHelper.ImageHistory.Redo());
        }

        /**
         * Handles the event of clicking the Tools->Grayscale menu item.
         */
        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shoppedGuiHelper.CurrentImage = _shoppedGuiHelper.Grayscale.MakeGrayscale(_shoppedGuiHelper.CurrentImage);
            UpdatePictureBoxInfo(string.Format("Convert Grayscale"));
        }
 
        /**
        * Handles the event of clicking the Tools->Sepia menu item.
        */
        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shoppedGuiHelper.CurrentImage = _shoppedGuiHelper.Sepia.MakeSepia(_shoppedGuiHelper.CurrentImage);
            UpdatePictureBoxInfo(string.Format("Convert Sepia"));
        }

        /**
        * Handles the event of clicking the Tools->Invert menu item.
        */
        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shoppedGuiHelper.CurrentImage = _shoppedGuiHelper.Invert.InvertColors(_shoppedGuiHelper.CurrentImage);
            UpdatePictureBoxInfo(string.Format("Invert Colors"));
        }

        /**
        * Handles the event of clicking the Tools->Brightness menu item.
        */
        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdjustBrightness();
        }

        /**
        * Handles the event of clicking the Tools->Contrast menu item.
        */
        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdjustContrast();
        }

        /**
        * Handles the event of clicking the Zoom Image button.
        */
        private void ZoomToolStripButton_Click(object sender, EventArgs e)
        {
            ZoomImage();
        }

        /**
        * Handles the event of clicking the Resize Image button.
        */
        private void ResizeToolStripButton_Click(object sender, EventArgs e)
        {
            ResizeImage();
        }

        /**
        * Handles the event of clicking the Undo button.
        */
        private void UndoToolStripButton_Click(object sender, EventArgs e)
        {
            SetPictureBoxOnUndoOrRedo(_shoppedGuiHelper.ImageHistory.Undo());
        }

        /**
        * Handles the event of clicking the Redo button.
        */
        private void RedoToolStripButton_Click(object sender, EventArgs e)
        {
            SetPictureBoxOnUndoOrRedo(_shoppedGuiHelper.ImageHistory.Redo());
        }

        /**
        * Handles the event of clicking the Rotate Image button.
        */
        private void RotateToolStripButton_Click(object sender, EventArgs e)
        {
            RotateImage();
        }

        /**
         * Pops up a dialog box for the user to input a number to rotate the picture by.
         * Calls RotateImage of ShoppedGuiHelper and updates the Gui with the new image.
         */
        private void RotateImage()
        {
            RotateDialog rotateDialog = new RotateDialog(_shoppedGuiHelper.CurrentImage.ZoomLevel);
            rotateDialog.ShowDialog();

            if (rotateDialog.DialogResult == DialogResult.OK)
            {
                _shoppedGuiHelper.RotateImage(rotateDialog.RotateDegrees);

                UpdatePictureBoxInfo(string.Format("Rotate {0} deg", rotateDialog.RotateDegrees % 360.0f));
                PictureBox.Refresh();
            }
        }

        /**
         * Pops up a dialog box for the user to input a number to zoom the picture.
         * Calls ZoomImage of ShoppedGuiHelper and updates the Gui with the new image.
         */
        private void ZoomImage()
        {
            ZoomDialog zoomDialog = new ZoomDialog();
            zoomDialog.ShowDialog();

            if (zoomDialog.DialogResult == DialogResult.OK)
            {
                PictureBox.Image = _shoppedGuiHelper.ImageZoom.ZoomImage((Image)PictureBox.Image, zoomDialog.ZoomLevel) as Image;
                _shoppedGuiHelper.CurrentImage.ZoomLevel = zoomDialog.ZoomLevel;
                PictureBox.Refresh();
            }
        }

        /**
         * Pops up a dialog box for the user to input a number to resize the picture by.
         * Calls ResizeImage of ShoppedGuiHelper and updates the Gui with the new image.
         */
        private void ResizeImage()
        {
            ResizeDialog resizeDialog = new ResizeDialog(_shoppedGuiHelper.CurrentImage.ZoomLevel);
            resizeDialog.ShowDialog();

            if (resizeDialog.DialogResult == DialogResult.OK)
            {
                _shoppedGuiHelper.ResizeImage(resizeDialog.ResizeLevel);
                UpdatePictureBoxInfo(string.Format("Resize {0}%", resizeDialog.ResizeLevel * 100.0f));
                PictureBox.Refresh();
            }
        }

        /**
         * Pops up a dialog box for the user to input a number adjust image contrast.
         * Calls AdjustContrast of ShoppedGuiHelper and updates the Gui with the new image.
         */
        private void AdjustContrast()
        {
            ContrastDialog contrastDialog = new ContrastDialog();
            contrastDialog.ShowDialog();

            if (contrastDialog.DialogResult == DialogResult.OK)
            {
                _shoppedGuiHelper.AdjustContrast(contrastDialog.ContrastLevel);
                UpdatePictureBoxInfo(string.Format("Contrast {0}%", contrastDialog.ContrastLevel));
                PictureBox.Refresh();
            }
        }

        /**
         * Pops up a dialog box for the user to input a number adjust image brightness.
         * Calls AdjustBrightness of ShoppedGuiHelper and updates the Gui with the new image.
         */
        private void AdjustBrightness()
        {
            BrightnessDialog brightnessDialog = new BrightnessDialog();
            brightnessDialog.ShowDialog();

            if (brightnessDialog.DialogResult == DialogResult.OK)
            {
                _shoppedGuiHelper.AdjustBrightness(brightnessDialog.BrightnessLevel);
                UpdatePictureBoxInfo(string.Format("Brightness {0}%", brightnessDialog.BrightnessLevel));
                PictureBox.Refresh();
            }
        }

        /**
         * Called upon when the event of clicking Undo/Redo in the Shopped GUI, this will enable or disable the Undo/Redo
         * buttons and menu items in the GUI. This will also set the tooltip text for the undo/redo GUI items.
         */
        private void SetUndoAndRedo()
        {
            redoToolStripMenuItem.Enabled = _shoppedGuiHelper.ImageHistory.RedoIsPossible();
            redoToolStripMenuItem.ToolTipText =
                    _shoppedGuiHelper.ImageHistory.GetRedoToolTip();


            undoToolStripMenuItem.Enabled = _shoppedGuiHelper.ImageHistory.UndoIsPossible();
            undoToolStripMenuItem.ToolTipText =
                _shoppedGuiHelper.ImageHistory.GetUndoToolTip();
        }

        /**
         * Sets the information about the PictureBox image that is located at the bottom of the Shopped GUI.
         * Information includes height, width and the name of the image.
         */
        public void SetAdditionalInfo()
        {
            AdditionalInfo.Text = string.Format("Height: {0} | Width: {1} | Zoom Level: {2}% | Name: {3}",
                PictureBox.Height,
                PictureBox.Width,
                _shoppedGuiHelper.CurrentImage.ZoomLevel * 100.0f,
                _shoppedGuiHelper.CurrentImage.FileName);
        }


        /**
         * Uses FileOperation instance to prompt user to open an image file.
         * Sets the image in the editor once image is opened.
         */
        public void OpenImage()
        {
            _shoppedGuiHelper.CurrentImage = _shoppedGuiHelper.FileOperation.OpenFile();

            if (_shoppedGuiHelper.CurrentImage != null)
            {
                _shoppedGuiHelper.ImageHistory = new ImageHistory();

                UpdatePictureBoxInfo("Open image");

                EnableGuiItems();
            }
        }

        /**
         * Sets the PictureBox to the image passed to this method.
         *
         * @param operation A brief description of the operation just performed to the Shopped GUI image.
         */
        public void UpdatePictureBoxInfo(string operation)
        {
            PictureBox.Image = _shoppedGuiHelper.CurrentImage.CurrentImage;
            _shoppedGuiHelper.ImageHistory.AddImageToImageHistory(_shoppedGuiHelper.CurrentImage, operation);
            SetAdditionalInfo();
            SetUndoAndRedo();
        }

        /**
         * Given an Image object from the ImageHistory class, set the ShoppedGUI PictureBox (image being currently
         * displayed) to that Image object.
         * 
         * @param image The image from the ImageHistory class.
         */
        public void SetPictureBoxOnUndoOrRedo(PictureBoxImage image)
        {
            _logger.Debug("Image being set to PictureBox: " + image.ToString());
            PictureBox.Image = image.CurrentImage;
            SetAdditionalInfo();
            SetUndoAndRedo();
        }
    }
}