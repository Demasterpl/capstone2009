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
         * 
         * @param resize The amount to resize the image to.
         * @param pictureBoxImage The PictureBoxImage object in the current context of Shopped GUI
         * @return A PictureBoxImage object with the appropriate properties set by this method.
         */
        public PictureBoxImage ResizeImage(PictureBoxImage pictureBoxImage, float resize)
        {
            //new up a PictureBoxImage
            PictureBoxImage _newPictureBoxImage = new PictureBoxImage(pictureBoxImage);

            _imageZoom.ZoomImage(_newPictureBoxImage, 1.0f);
            _newPictureBoxImage.ResizeLevel = resize;

            if (resize == 1.0f)
            {
                return _newPictureBoxImage;
            }
            else
            {
                //Calculate new height and width
                var newWidth = (int)(_newPictureBoxImage.CurrentImage.Width * resize);
                var newHeight = (int)(_newPictureBoxImage.CurrentImage.Height * resize);

                //Set unzoomed image to new image
                _newPictureBoxImage.UnzoomedImage = _newPictureBoxImage.CurrentImage = 
                    new Bitmap(_newPictureBoxImage.CurrentImage, newWidth, newHeight);
                _newPictureBoxImage.CurrentWidth = _newPictureBoxImage.UnzoomedWidth = newWidth;
                _newPictureBoxImage.CurrentHeight = _newPictureBoxImage.UnzoomedHeight = newHeight;


                //Set image back to its original rotation
                //_imageRotate.RotateImageByAngle
                //    (_newPictureBoxImage, _newPictureBoxImage.DegreesRotated);

                return _newPictureBoxImage;
            }
        }
    }
}
