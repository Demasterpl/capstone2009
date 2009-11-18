using System;
using System.Windows.Forms;
using Core;
using Core.Images;
using System.Drawing;
using NLog;
using UI.Dialogs;
using Core.Manipulators;
using Core.Interfaces;
using Core.Filters;
using Core.Model;

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
        private PictureBoxImage CurrentImage;
        private ImageRotate ImageRotate;
        private IFileOperations FileOperation;
        private ImageHistory ImageHistory;
        private ImageZoom ImageZoom;
        private ImageResize ImageResize;
        private Grayscale Grayscale;
        private Sepia Sepia;
        private Invert Invert;
        private Brightness Brightness;
        private Contrast Contrast;
        private IDrawOnImage IDrawOnImage;
        private ImageDraw ImageDraw;


        private ShoppedGuiHelper _shoppedGuiHelper;
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public ShoppedGui()
        {
            InitializeComponent();

            IoCRegistrar.EnsureDependenciesRegistered();

            _shoppedGuiHelper = new ShoppedGuiHelper();

            CurrentImage = IoC.Resolve<PictureBoxImage>();
            ImageRotate = IoC.Resolve<ImageRotate>();
            FileOperation = IoC.Resolve<FileOperations>();
            ImageHistory = IoC.Resolve<ImageHistory>();
            ImageZoom = IoC.Resolve<ImageZoom>();
            ImageResize = IoC.Resolve<ImageResize>();
            Grayscale = IoC.Resolve<Grayscale>();
            Sepia = IoC.Resolve<Sepia>();
            Invert = IoC.Resolve<Invert>();
            Brightness = IoC.Resolve<Brightness>();
            Contrast = IoC.Resolve<Contrast>();
            IDrawOnImage = IoC.Resolve<IDrawOnImage>();
            ImageDraw = IoC.Resolve<ImageDraw>();

            //Adding mouse event handlers
            PictureBox.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
            PictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            PictureBox.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
            MouseWheel += new MouseEventHandler(PictureBox_MouseWheelScroll);
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
            FileOperation.SaveFile(CurrentImage);
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
            FileOperation.SaveFile(CurrentImage);
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
            FilterToolStripButton.Enabled = true;
            ResizeToolStripButton.Enabled = true;
            RotateToolStripButton.Enabled = true;
            ZoomToolStripButton.Enabled = true;
            DrawToolStripButton.Enabled = true;
        }

        /**
         * Handles the event of clicking the Tools->Grayscale menu item.
         */
        private void grayscaleMenuItem_Click(object sender, EventArgs e)
        {
            ApplyGrayscaleFilterToImage();
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyGrayscaleFilterToImage();
        }

        /**
        * Handles the event of clicking the Tools->Sepia menu item.
        */
        private void sepiaMenuItem_Click(object sender, EventArgs e)
        {
            ApplySepiaFilterToImage();
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplySepiaFilterToImage();
        }

        /**
        * Handles the event of clicking the Tools->Invert menu item.
        */
        private void invertMenuItem_Click(object sender, EventArgs e)
        {
            InvertImage();
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertImage();
        }

        /**
        * Handles the event of clicking the Tools->Brightness menu item.
        */
        private void brightnessMenuItem_Click(object sender, EventArgs e)
        {
            AdjustBrightness();
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdjustBrightness();
        }

        /**
        * Handles the event of clicking the Tools->Contrast menu item.
        */
        private void contrastMenuItem_Click(object sender, EventArgs e)
        {
            AdjustContrast();
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdjustContrast();
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
         * Handles the event of clicking the Tools->Resize menu item. Displays the ResizeDialog windows form,
         * obtains the value to resize from the form, then resizes the image according to the resize value.
         */
        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
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
         * Handles the event of clicking the Edit->Undo menu item.
         */
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
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
         * Handles the event of clicking the Edit->Redo menu item.
         */
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
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
         * Handles the event of clicking the Tools->Rotate menu item. Displays the RotateDialog windows form,
         * obtains the value to rotate from the form, then rotates the image according to the rotate value.
         */
        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage();
        }

        /**
         * Handles the event of the cursor moving around on the PictureBox.
         */
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (PictureBox.Image != null && ImageDraw.CurrentLineShape == "Line")
            {
                DrawOnPictureBox(e);
            }

            SetAdditionalInfo();
        }

        /**
         * Handles the event of the the mouse button being pressed down on the PictureBox.
         */
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (ImageDraw.Enabled == true)
            {
                DrawOnPictureBox(e);
                _shoppedGuiHelper.CommitDrawingToCurrentImage(PictureBox.Image);
                SetUndoAndRedo();
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            IDrawOnImage.SetInitialPoint(e.X, e.Y);

        }

        private void PictureBox_MouseWheelScroll(object sender, MouseEventArgs e)
        {
            if (PictureBox.Image != null)
            {
                ZoomImageOnScroll(e.Delta);
            }
        }

        /**
         * Handles the event of the user selecting "Drawing" from the Tools menu. Opens up a 
         * DrawingDialog and sets the values to ImageDraw object accordingly.
         */
        private void drawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawingDialog drawingDialog = new DrawingDialog(ImageDraw);

            do
            {
                drawingDialog.ShowDialog();
            } while (drawingDialog.DialogResult == DialogResult.Retry);

            //if (drawingDialog.DialogResult == DialogResult.OK)
            //{
            //    _shoppedGuiHelper.IDrawOnImage = drawingDialog.ImageDraw;
            //}
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
            IDrawOnImage.ToggleEnabledState();
        }        
        
        /**
         * Pops up a dialog box for the user to input a number to rotate the picture by.
         * Calls RotateImage of ShoppedGuiHelper and updates the Gui with the new image.
         */
        private void RotateImage()
        {
            RotateDialog rotateDialog = new RotateDialog(CurrentImage.ZoomLevel);
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
            do
            {
                zoomDialog.ShowDialog();
            } while (zoomDialog.DialogResult == DialogResult.Retry);

            if (zoomDialog.DialogResult == DialogResult.OK)
            {                
                PictureBox.Image = _shoppedGuiHelper.ZoomImage((Image)PictureBox.Image, zoomDialog.ZoomLevel) as Image;
                CurrentImage.ZoomLevel = zoomDialog.ZoomLevel;
                SetAdditionalInfo();
                PictureBox.Refresh();
            }
        }

        private void ZoomImageOnScroll(int mouseWheelDelta)
        {
            if (PictureBox.Image != null)
            {
                if (mouseWheelDelta < 0)
                {
                    CurrentImage.SetZoomLevel(-.05f);
                }
                if (mouseWheelDelta > 0)
                {
                   CurrentImage.SetZoomLevel(.05f);
                }

                using(var tempImage = new Bitmap(CurrentImage.CurrentImage))
                {
                    PictureBox.Image = _shoppedGuiHelper.ZoomImage(tempImage, CurrentImage.ZoomLevel);
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
            ResizeDialog resizeDialog = new ResizeDialog(CurrentImage.ZoomLevel);

            do
            {
                resizeDialog.ShowDialog();
            } while (resizeDialog.DialogResult == DialogResult.Retry);

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

        private void ApplyGrayscaleFilterToImage()
        {
            CurrentImage = Grayscale.MakeGrayscale(CurrentImage);
            UpdatePictureBoxInfo(string.Format("Convert Grayscale"));
        }

        private void ApplySepiaFilterToImage()
        {
           CurrentImage = Sepia.MakeSepia(CurrentImage);
            UpdatePictureBoxInfo(string.Format("Convert Sepia"));
        }

        private void InvertImage()
        {
            CurrentImage = Invert.InvertColors(CurrentImage);
            UpdatePictureBoxInfo(string.Format("Invert Colors"));
        }


        /**
         * Called upon when the event of clicking Undo/Redo in the Shopped GUI, this will enable or disable the Undo/Redo
         * buttons and menu items in the GUI. This will also set the tooltip text for the undo/redo GUI items.
         */
        private void SetUndoAndRedo()
        {
            redoToolStripMenuItem.Enabled = ImageHistory.RedoIsPossible();
            RedoToolStripButton.Enabled = ImageHistory.RedoIsPossible();
            redoToolStripMenuItem.ToolTipText = ImageHistory.GetRedoToolTip();

            undoToolStripMenuItem.Enabled = ImageHistory.UndoIsPossible();
            UndoToolStripButton.Enabled = ImageHistory.UndoIsPossible();
            undoToolStripMenuItem.ToolTipText = ImageHistory.GetUndoToolTip();
        }

        /**
         * Sets the information about the PictureBox image that is located at the bottom of the Shopped GUI.
         * Information includes height, width and the name of the image.
         */
        public void SetAdditionalInfo()
        {
            AdditionalInfo.Text = string.Format("Height: {0} | Width: {1} | Zoom Level: {2}% | Name: {3} | Color: {4} | (x,y): {5}",
                CurrentImage.CurrentHeight,
                CurrentImage.CurrentWidth,
                Math.Round((CurrentImage.ZoomLevel * 100.0f), 1),
                CurrentImage.FileName,
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
           CurrentImage = FileOperation.OpenFile();

            if (CurrentImage != null)
            {
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
            PictureBox.Image = CurrentImage.CurrentImage;
            ImageHistory.AddImageToImageHistory(CurrentImage, operation);
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
            CurrentImage = new PictureBoxImage(ImageHistory.Undo());
            _logger.Debug("Image being set to PictureBox: " + CurrentImage.ToString());
            PictureBox.Image = CurrentImage.CurrentImage;
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
            CurrentImage = new PictureBoxImage(ImageHistory.Redo());
            _logger.Debug("Image being set to PictureBox: " + CurrentImage.ToString());
            PictureBox.Image = CurrentImage.CurrentImage;
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
                IDrawOnImage.SetDestinationPoint(mouse.X, mouse.Y);
                PictureBox.Image = IDrawOnImage.DrawShapeOnImage(PictureBox.Image, mouse);
                IDrawOnImage.SetInitialPoint(ImageDraw.DestinationPoint.X, ImageDraw.DestinationPoint.Y);
                SetUndoAndRedo();
                PictureBox.Refresh();
            }
        }
    }
}