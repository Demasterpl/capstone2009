using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Core.Images;

namespace Core
{
    public class ImageZoom
    {
        private readonly ImageRotate _imageRotate;

        public ImageZoom()
        {
            _imageRotate = new ImageRotate();
        }

        /**
         * Zooms the image in the Shopped GUI to the specified zoom level.
         * 
         * @param zoom The amount of zoom to use on the image (1.0f == 100%).
         * @param pictureBoxImage The PictureBoxImage object in the current context of Shopped GUI
         * @return A PictureBoxImage object with the appropriate properties set by this method.
         */
        public PictureBoxImage ZoomImage(PictureBoxImage pictureBoxImage, float zoom)
        {
            PictureBoxImage newPictureBoxImage = new PictureBoxImage(pictureBoxImage);
            //Reset current image to 100% zoom
            newPictureBoxImage.CurrentImage = newPictureBoxImage.UnzoomedImage;
            newPictureBoxImage.ZoomLevel = zoom;

            if (zoom == 1.0f)
            {
                return pictureBoxImage;
            }
            else
            {
                newPictureBoxImage.UnzoomedHeight = newPictureBoxImage.CurrentHeight;
                newPictureBoxImage.UnzoomedWidth = newPictureBoxImage.CurrentWidth;

                newPictureBoxImage.CurrentImage = new Bitmap(
                   newPictureBoxImage.CurrentImage,
                    (int)(newPictureBoxImage.CurrentImage.Width * zoom),
                    (int)(newPictureBoxImage.CurrentImage.Height * zoom));

                newPictureBoxImage.CurrentHeight = newPictureBoxImage.CurrentImage.Height;
                newPictureBoxImage.CurrentWidth = newPictureBoxImage.CurrentImage.Width;

                return newPictureBoxImage;
            }
        }
    }
}
