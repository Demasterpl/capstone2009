﻿using System;
using System.Windows.Forms;
using Core;
using Core.Images;
using System.Drawing;
using NLog;
using UI.Dialogs;
using Core.Manipulators;

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

            //Adding mouse event handlers
            PictureBox.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
            PictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            PictureBox.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
            this.MouseWheel += new MouseEventHandler(PictureBox_MouseWheelScroll);
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
            DrawToolStripButton.Enabled = false;
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
            DrawToolStripButton.Enabled = true;
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
            SetPictureBoxOnUndo();
        }

        /**
         * Handles the event of clicking the Edit->Redo menu item.
         */
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPictureBoxOnRedo();
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
         * Handles the event of the cursor moving around on the PictureBox.
         */
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (PictureBox.Image != null && _shoppedGuiHelper.ImageDraw.CurrentLineShape == "Line")
            {
                DrawOnPictureBox(e);
                SetAdditionalInfo();
            }
        }

        /**
         * Handles the event of the the mouse button being pressed down on the PictureBox.
         */
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            DrawOnPictureBox(e);
            _shoppedGuiHelper.CommitDrawingToCurrentImage(PictureBox.Image);
            SetUndoAndRedo();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _shoppedGuiHelper.ImageDraw.SetInitialPoint(e.X, e.Y);
            
        }

        private void PictureBox_MouseWheelScroll(object sender, MouseEventArgs e)
        {
            ZoomImageOnScroll(e.Delta);
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
            SetPictureBoxOnUndo();
        }

        /**
        * Handles the event of clicking the Redo button.
        */
        private void RedoToolStripButton_Click(object sender, EventArgs e)
        {
            SetPictureBoxOnRedo();
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

        private void ZoomImageOnScroll(int mouseWheelDelta)
        {
            if (PictureBox.Image != null)
            {
                if (mouseWheelDelta < 0)
                {
                    _shoppedGuiHelper.CurrentImage.ZoomLevel -= .05f;
                }
                if (mouseWheelDelta > 0)
                {
                    _shoppedGuiHelper.CurrentImage.ZoomLevel += .05f;
                }

                using(var tempImage = new Bitmap(_shoppedGuiHelper.CurrentImage.CurrentImage))
                {
                    PictureBox.Image = _shoppedGuiHelper.ImageZoom.ZoomImage(tempImage, _shoppedGuiHelper.CurrentImage.ZoomLevel);
                    PictureBox.Refresh();
                    SetAdditionalInfo();
                }
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
         * Handles the event of the user selecting "Drawing" from the Tools menu. Opens up a 
         * DrawingDialog and sets the values to ImageDraw object accordingly.
         */
        private void drawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingDialog drawingDialog = new DrawingDialog(new ImageDraw(_shoppedGuiHelper.ImageDraw));
            drawingDialog.ShowDialog();

            if (drawingDialog.DialogResult == DialogResult.OK)
            {
                _shoppedGuiHelper.ImageDraw = drawingDialog.ImageDraw;
            }
        }

        /**
         * Handles the event of the Draw button being clicked in the GUI. Sets the tooltip text according
         * to the current toggle state and sets the toggle state.
         */
        private void DrawToolStripButton_Click(object sender, EventArgs e)
        {
            if (DrawToolStripButton.Checked == true)
            {
                DrawToolStripButton.Text = "Disable Drawing";
            }
            else
            {
                DrawToolStripButton.Text = "Enable Drawing";
            }
            _shoppedGuiHelper.ImageDraw.ToggleEnabledState();
        }

        /**
         * Called upon when the event of clicking Undo/Redo in the Shopped GUI, this will enable or disable the Undo/Redo
         * buttons and menu items in the GUI. This will also set the tooltip text for the undo/redo GUI items.
         */
        private void SetUndoAndRedo()
        {
            redoToolStripMenuItem.Enabled = _shoppedGuiHelper.ImageHistory.RedoIsPossible();
            RedoToolStripButton.Enabled = _shoppedGuiHelper.ImageHistory.RedoIsPossible();
            redoToolStripMenuItem.ToolTipText =
                    _shoppedGuiHelper.ImageHistory.GetRedoToolTip();


            undoToolStripMenuItem.Enabled = _shoppedGuiHelper.ImageHistory.UndoIsPossible();
            UndoToolStripButton.Enabled = _shoppedGuiHelper.ImageHistory.UndoIsPossible();
            undoToolStripMenuItem.ToolTipText =
                _shoppedGuiHelper.ImageHistory.GetUndoToolTip();
        }

        /**
         * Sets the information about the PictureBox image that is located at the bottom of the Shopped GUI.
         * Information includes height, width and the name of the image.
         */
        public void SetAdditionalInfo()
        {
            AdditionalInfo.Text = string.Format("Height: {0} | Width: {1} | Zoom Level: {2}% | Name: {3} | Color: {4} | (x,y): {5}",
                PictureBox.Height,
                PictureBox.Width,
                _shoppedGuiHelper.CurrentImage.ZoomLevel * 100.0f,
                _shoppedGuiHelper.CurrentImage.FileName,
                GetPixelColor(),
                GetCoordinates());
        }

        /**
         * Gets the current coordinates of the mouse in the PictureBox and returns them as an ordered pair.
         * 
         * @return A string representation of the coordinates as an ordered pair.
         */
        private string GetCoordinates()
        {
            return "(" + MousePosition.X + "," + MousePosition.Y + ")";
        }

        /**
         * Takes the cursor's current position on the image and attempts to get the color of that pixel.
         * 
         * @return The hexadecimal representation of the pixel's color.
         */
        private string GetPixelColor()
        {
            if (PictureBox.Image != null)
            {
                var xCoordinate = MousePosition.X;
                var yCoordinate = MousePosition.Y;

                if (xCoordinate < PictureBox.Image.Width - 1 && yCoordinate < PictureBox.Image.Height - 1)
                {
                    var redHue = Convert.ToString(new Bitmap(PictureBox.Image).GetPixel(xCoordinate, yCoordinate).R, 16);
                    var greenHue = Convert.ToString(new Bitmap(PictureBox.Image).GetPixel(xCoordinate, yCoordinate).G, 16);
                    var blueHue = Convert.ToString(new Bitmap(PictureBox.Image).GetPixel(xCoordinate, yCoordinate).B, 16);

                    //var color = Color.FromArgb(redHue, greenHue, blueHue);

                   return redHue.ToUpper() + greenHue.ToUpper() + blueHue.ToUpper();
                }
            }
            return "";
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
         */
        public void SetPictureBoxOnUndo()
        {
            _shoppedGuiHelper.CurrentImage = new PictureBoxImage(_shoppedGuiHelper.ImageHistory.Undo());
            _logger.Debug("Image being set to PictureBox: " + _shoppedGuiHelper.CurrentImage.ToString());
            PictureBox.Image = _shoppedGuiHelper.CurrentImage.CurrentImage;
            SetAdditionalInfo();
            SetUndoAndRedo();
        }

        /**
         * Given an Image object from the ImageHistory class, set the ShoppedGUI PictureBox (image being currently
         * displayed) to that Image object.
         * 
         */
        public void SetPictureBoxOnRedo()
        {
            _shoppedGuiHelper.CurrentImage = new PictureBoxImage(_shoppedGuiHelper.ImageHistory.Redo());
            _logger.Debug("Image being set to PictureBox: " + _shoppedGuiHelper.CurrentImage.ToString());
            PictureBox.Image = _shoppedGuiHelper.CurrentImage.CurrentImage;
            SetAdditionalInfo();
            SetUndoAndRedo();
        }

        /**
         * Calls upon ImageDraw class to draw on the current PictureBox
         * 
         * @param mouse Contains the current status of the mouse.
         */
        private void DrawOnPictureBox(MouseEventArgs mouse)
        {
            if (PictureBox.Image != null && mouse.Button == MouseButtons.Left)
            {
                _shoppedGuiHelper.ImageDraw.SetDestinationPoint(mouse.X, mouse.Y);
                PictureBox.Image = _shoppedGuiHelper.ImageDraw.DrawShapeOnImage(PictureBox.Image, mouse);
                _shoppedGuiHelper.ImageDraw.SetInitialPoint(_shoppedGuiHelper.ImageDraw.DestinationPoint.X, _shoppedGuiHelper.ImageDraw.DestinationPoint.Y);
                SetUndoAndRedo();
                PictureBox.Refresh();
            }
        }
    }
}