using Core.Images;
using Core.Filters;
using Core.Interfaces;
using Core.Manipulators;

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

        public ShoppedGuiHelper()
            : this(new PictureBoxImage(), new ImageRotate(), new FileOperations(), 
            new ImageHistory(), new ImageZoom(), new ImageResize(), new Grayscale(), new Sepia(), new Invert(), new Brightness(), new Contrast())
        { }

        public ShoppedGuiHelper(PictureBoxImage pictureBoxImage, 
            ImageRotate imageRotate, FileOperations fileOperation, ImageHistory imageHistory, 
            ImageZoom imageZoom, ImageResize imageResize, Grayscale grayscale, Sepia sepia, Invert invert, Brightness brightness, Contrast contrast)
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
    }
}
