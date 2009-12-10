using Core.Images;
using Core.Filters;
using Core.Manipulators;
using System.Drawing;
using System.Windows.Forms;

namespace Core
{
    /**
     * A class that contains the initialized objects of the classes in Core. This is a "poor man's"
     * implementation of Inverion of Control.
     */
    public class ShoppedGuiHelper
    {
        public ShoppedImage CurrentImage { get; set; }
        public ImageRotate ImageRotate { get; set; }
        public FileOperations FileOperation { get; set; }
        public ImageHistory ImageHistory { get; set; }
        public ImageZoom ImageZoom { get; set; }
        public ImageResize ImageResize { get; set; }
        public Grayscale Grayscale { get; set; }
        public Sepia Sepia { get; set; }
        public Invert Invert { get; set; }
        public Brightness Brightness { get; set; }
        public Contrast Contrast { get; set; }
        public ImageDraw ImageDraw { get; set; }
        public ImageCrop ImageCrop { get; set; }
        public Gamma Gamma { get; set; }
        public SelectionBox SelectionBox;



        /**
         * The default constructor. Works by newing up all the properties of ShoppedGuiHelper and passing them
         * into a constructor that handles all those properties.
         */
        public ShoppedGuiHelper()
            : this(new ShoppedImage(), new ImageRotate(), new FileOperations(), 
            new ImageHistory(), new ImageZoom(), new ImageResize(), new Grayscale(), 
            new Sepia(), new Invert(), new Brightness(), new Contrast(), new ImageDraw(),
            new Gamma(), new SelectionBox(), new ImageCrop())
        { }

        /**
         * The constructor that is passed in instances of all the objects that ShoppedGuiHelper maintains.
         */
        public ShoppedGuiHelper(ShoppedImage shoppedImage, 
            ImageRotate imageRotate, FileOperations fileOperation, ImageHistory imageHistory, 
            ImageZoom imageZoom, ImageResize imageResize, Grayscale grayscale, Sepia sepia, 
            Invert invert, Brightness brightness, Contrast contrast, ImageDraw imageDraw,
            Gamma gamma, SelectionBox selectionBox, ImageCrop imageCrop)
        {
            CurrentImage = shoppedImage;
            ImageRotate = imageRotate;
            FileOperation = fileOperation;
            ImageHistory = imageHistory;
            ImageZoom = imageZoom;
            ImageResize = imageResize;
            Grayscale = grayscale;
            Sepia = sepia;
            Invert = invert;
            Brightness = brightness;
            Contrast = contrast;
            ImageDraw = imageDraw;
            Gamma = gamma;
            SelectionBox = selectionBox;
            ImageCrop = imageCrop;
        }

        /**
         * Handles the call from the GUI to rotate an image.
         * 
         * @param angle The angle to rotate the image by.
         */
        public void RotateImage(float angle)
        {
            angle %= 360.0f;

            if (angle == 0.0f)
            {
                return;
            }

            ZoomImage(CurrentImage.CurrentImage, 1.0f);

            CurrentImage = ImageRotate.RotateImageByAngle(CurrentImage, angle);
        }

        /**
         * Handles the call to resize an image from the GUI.
         * 
         * @param resizeLevel The amount to resize the image by.
         */
        public void ResizeImage(float resizeLevel)
        {
            if (resizeLevel == 1.0f)
            {
                return;
            }

            ZoomImage(CurrentImage.CurrentImage, 1.0f);

            CurrentImage = ImageResize.ResizeImage(CurrentImage, resizeLevel);
        }

        /**
         * Handles the call to zoom an image from the GUI.
         * 
         * @param image The image to be zoomed.
         * @param zoomLevel The amount to zoom the image by.
         */
        public Image ZoomImage(Image image, float zoomLevel)
        {
            CurrentImage.ZoomLevel = zoomLevel;

            if (zoomLevel == 1.0f)
            {
                return CurrentImage.CurrentImage;
            }

            return ImageZoom.ZoomImage(image, zoomLevel);
        }

        /**
         * Handles the call from the GUI to adjust the contrast of an image.
         * 
         * @param amount The amount to adjust the contrast by.
         */
        public void AdjustContrast(float amount)
        {
            CurrentImage = Contrast.AdjustContrast(CurrentImage, amount);
        }

        /**
         * Handles the call from the GUI to adjust the brightness of an image.
         * 
         * @param amount The amount to adjust the brightness by.
         */
        public void AdjustBrightness(float amount)
        {
            CurrentImage = Brightness.AdjustBrightness(CurrentImage, amount);
        }

        /**
         * Handles the call from the GUI to adjust the gamma of an image.
         * 
         * @param RedLevel The amount to adjust the red gamma by.
         * @param GreenLevel The amount to adjust the green gamma by.
         * @param BlueLevel The amount to adjust the blue gamma by.
         */
        public void AdjustGamma(double RedLevel, double GreenLevel, double BlueLevel)
        {
            CurrentImage = Gamma.AdjustGamma(CurrentImage, RedLevel, GreenLevel, BlueLevel);
        }


        /**
         * Called after a drawing event occurred in the gui. Checks if the image is different
         * from the CurrentImage and adds it to history if it is.
         * 
         * @param image The current image being displayed in the gui.
         */
        public void CommitDrawingToCurrentImage(Image image)
        {
            if (image != null && !image.Equals(CurrentImage.CurrentImage))
            {
                CurrentImage = new ShoppedImage(CurrentImage.FileName, image.Height, image.Width, image);
                ImageZoom.ZoomImage(CurrentImage.CurrentImage, 1.0f);
                ImageHistory.AddImageToImageHistory(CurrentImage, "Draw");
            }
        }
    }
}
