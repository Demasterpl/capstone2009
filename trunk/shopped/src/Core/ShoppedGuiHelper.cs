using Core.Images;
using Core.Filters;
using Core.Interfaces;
using Core.Manipulators;
using System.Drawing;
using System.Windows.Forms;

namespace Core
{
    /**
     * A class that contains the initialized objects of the classes in Core. This is a "poor man's"
     * implementation of Inverion of Control. If time, convert this to an appropriate IoC container.
     */

    public class ShoppedGuiHelper
    {
        public PictureBoxImage CurrentImage { get; set; }
        public ImageRotate ImageRotate { get; set; }
        public IFileOperations FileOperation { get; set; }
        public ImageHistory ImageHistory { get; set; }
        public ImageZoom ImageZoom { get; set; }
        public ImageResize ImageResize { get; set; }
        public Grayscale Grayscale { get; set; }
        public Sepia Sepia { get; set; }
        public Invert Invert { get; set; }
        public Brightness Brightness { get; set; }
        public Contrast Contrast { get; set; }
        public ImageDraw ImageDraw { get; set; }

        public ShoppedGuiHelper()
            : this(new PictureBoxImage(), new ImageRotate(), new FileOperations(), 
            new ImageHistory(), new ImageZoom(), new ImageResize(), new Grayscale(), 
            new Sepia(), new Invert(), new Brightness(), new Contrast(), new ImageDraw())
        { }

        public ShoppedGuiHelper(PictureBoxImage pictureBoxImage, 
            ImageRotate imageRotate, FileOperations fileOperation, ImageHistory imageHistory, 
            ImageZoom imageZoom, ImageResize imageResize, Grayscale grayscale, Sepia sepia, 
            Invert invert, Brightness brightness, Contrast contrast, ImageDraw imageDraw)
        {
            CurrentImage = pictureBoxImage;
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
        }

        public void RotateImage(float angle)
        {
            angle %= 360.0f;

            CurrentImage = ImageRotate.RotateImageByAngle(CurrentImage, angle);
        }

        public void ResizeImage(float amount)
        {
            CurrentImage = ImageResize.ResizeImage(CurrentImage, amount);
        }

        public void AdjustContrast(float amount)
        {
            CurrentImage = Contrast.AdjustContrast(CurrentImage, amount);
        }

        public void AdjustBrightness(float amount)
        {
            CurrentImage = Brightness.AdjustBrightness(CurrentImage, amount);
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
                CurrentImage = new PictureBoxImage(CurrentImage.FileName, image.Height, image.Width, image);
                ImageHistory.AddImageToImageHistory(CurrentImage, "Draw");
            }
        }
    }
}
