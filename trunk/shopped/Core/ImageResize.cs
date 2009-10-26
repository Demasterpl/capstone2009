using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Core.Images;

namespace Core
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
         * @param resize The amount to resize the image to.
         */
        public PictureBoxImage ResizeImage(PictureBoxImage pictureBoxImage, float resize)
        {
            _imageZoom.ZoomImage(pictureBoxImage, 1.0f);
            pictureBoxImage.ResizeLevel = resize;

            if (resize == 1.0f)
            {
                return pictureBoxImage;
            }
            else
            {
                //Set unzoomed image to new image
                pictureBoxImage.UnzoomedImage = pictureBoxImage.CurrentImage = new Bitmap(
                    pictureBoxImage.CurrentImage,
                    (int)(pictureBoxImage.CurrentImage.Width * resize),
                    (int)(pictureBoxImage.CurrentImage.Height * resize));

                //Set image back to its original rotation
                _imageRotate.RotateImageByAngle
                    (pictureBoxImage, pictureBoxImage.DegreesRotated);

                //Set Height and Width of current image
                pictureBoxImage.CurrentHeight = pictureBoxImage.UnzoomedHeight = pictureBoxImage.CurrentImage.Height;
                pictureBoxImage.CurrentWidth = pictureBoxImage.UnzoomedWidth = pictureBoxImage.CurrentImage.Width;

                return pictureBoxImage;
            }
        }
    }
}
