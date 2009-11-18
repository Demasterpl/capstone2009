using Core.Images;
using Core.Filters;
using Core.Interfaces;
using Core.Manipulators;
using System.Drawing;
using System.Windows.Forms;
using Core.Model;

namespace Core
{
    /**
     * A class that contains the initialized objects of the classes in Core. This is a "poor man's"
     * implementation of Inverion of Control. If time, convert this to an appropriate IoC container.
     */

    public class ShoppedGuiHelper
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

        public ShoppedGuiHelper()
            : this(new PictureBoxImage(), new ImageRotate(), new FileOperations(), 
            new ImageHistory(), new ImageZoom(), new ImageResize(), new Grayscale(), 
            new Sepia(), new Invert(), new Brightness(), new Contrast(), IoC.Resolve<DrawOnImage>(), IoC.Resolve<ImageDraw>())
        { }

        public ShoppedGuiHelper(PictureBoxImage pictureBoxImage, 
            ImageRotate imageRotate, FileOperations fileOperation, ImageHistory imageHistory, 
            ImageZoom imageZoom, ImageResize imageResize, Grayscale grayscale, Sepia sepia, 
            Invert invert, Brightness brightness, Contrast contrast, DrawOnImage drawOnImage, ImageDraw imageDraw)
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
            IDrawOnImage = drawOnImage;
            ImageDraw = imageDraw;
        }

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

        public void ResizeImage(float resizeLevel)
        {
            if (resizeLevel == 1.0f)
            {
                return;
            }

            ZoomImage(CurrentImage.CurrentImage, 1.0f);

            CurrentImage = ImageResize.ResizeImage(CurrentImage, resizeLevel);
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
                ImageZoom.ZoomImage(CurrentImage.CurrentImage, 1.0f);
                ImageHistory.AddImageToImageHistory(CurrentImage, "Draw");
            }
        }

        public Image ZoomImage(Image image, float zoomLevel)
        {            
            CurrentImage.ZoomLevel = zoomLevel;

            if (zoomLevel == 1.0f)
            {
                return CurrentImage.CurrentImage;
            }

            return ImageZoom.ZoomImage(image, zoomLevel);
        }
    }
}
