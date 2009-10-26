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
         * @param zoom The amount of zoom to use on the image (1.0f == 100%).
         */
        public PictureBoxImage ZoomImage(PictureBoxImage pictureBoxImage, float zoom)
        {
            //Reset current image to 100% zoom
            pictureBoxImage.CurrentImage = pictureBoxImage.UnzoomedImage;
            pictureBoxImage.ZoomLevel = zoom;

            if (zoom == 1.0f)
            {
                return pictureBoxImage;
            }
            else
            {
                //Rotate unzoomed image back to 
                pictureBoxImage = _imageRotate.RotateImageByAngle(pictureBoxImage, pictureBoxImage.DegreesRotated);
                pictureBoxImage.UnzoomedHeight = pictureBoxImage.CurrentHeight;
                pictureBoxImage.UnzoomedWidth = pictureBoxImage.CurrentWidth;

                pictureBoxImage.CurrentImage = new Bitmap(
                   pictureBoxImage.CurrentImage,
                    (int)(pictureBoxImage.CurrentImage.Width * zoom),
                    (int)(pictureBoxImage.CurrentImage.Height * zoom));

                pictureBoxImage.CurrentHeight = pictureBoxImage.CurrentImage.Height;
                pictureBoxImage.CurrentWidth = pictureBoxImage.CurrentImage.Width; 

                return pictureBoxImage;
            }
        }
    }
}
