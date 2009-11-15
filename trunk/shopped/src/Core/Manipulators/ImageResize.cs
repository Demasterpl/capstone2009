using System.Drawing;
using Core.Images;

namespace Core.Manipulators
{
    public class ImageResize
    {
        private readonly ImageRotate _imageRotate;
        private readonly ImageZoom _imageZoom;

        public ImageResize()
        {
            _imageRotate = new ImageRotate();
            _imageZoom = new ImageZoom();
        }

        /**
         * Resizes the image in the Shopped GUI to the specified resize level.
         * 
         * @param resize The amount to resize the image to.
         * @param pictureBoxImage The PictureBoxImage object in the current context of Shopped GUI
         * @return A PictureBoxImage object with the appropriate properties set by this method.
         */

        public PictureBoxImage ResizeImage(PictureBoxImage pictureBoxImage, float resize)
        {
            //new up a PictureBoxImage
            PictureBoxImage newPictureBoxImage = new PictureBoxImage(pictureBoxImage);

            //_imageZoom.ZoomImage(newPictureBoxImage, 1.0f);
            newPictureBoxImage.ResizeLevel = resize;

            if (resize == 1.0f)
            {
                return newPictureBoxImage;
            }

            //Calculate new height and width
            int newWidth = (int) (newPictureBoxImage.CurrentImage.Width*resize);
            int newHeight = (int) (newPictureBoxImage.CurrentImage.Height*resize);

            //Set unzoomed image to new image
            newPictureBoxImage.CurrentWidth = newWidth;
            newPictureBoxImage.CurrentHeight = newHeight;
            newPictureBoxImage.CurrentImage = new Bitmap(newPictureBoxImage.CurrentImage, new Size(newWidth, newHeight));
            //Set image back to its original rotation
            //_imageRotate.RotateImageByAngle
            //    (_newPictureBoxImage, _newPictureBoxImage.DegreesRotated);

            return newPictureBoxImage;
        }
    }
}
