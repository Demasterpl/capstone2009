using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Core
{
    public class ImageResize
    {
        /**
         * Resizes the image in the Shopped GUI to the specified resize level.
         * @param resize The amount to resize the image to.
         */
        public void ResizeImage(float resize)
        {
            ShoppedGuiHelper.ImageZoom.ZoomImage(1.0f);
            ShoppedGuiHelper.CurrentImage.ResizeLevel = resize;

            if (resize == 1.0f)
            {
                return;
            }
            else
            {
                //Set unzoomed image to new image
                ShoppedGuiHelper.CurrentImage.UnzoomedImage = ShoppedGuiHelper.CurrentImage.CurrentImage = new Bitmap(
                    ShoppedGuiHelper.CurrentImage.CurrentImage,
                    (int)(ShoppedGuiHelper.CurrentImage.CurrentImage.Width * resize),
                    (int)(ShoppedGuiHelper.CurrentImage.CurrentImage.Height * resize));

                //Set image back to its original rotation
                ShoppedGuiHelper.ImageRotate.RotateImageByAngle
                    (ShoppedGuiHelper.CurrentImage.DegreesRotated);

                //Set Height and Width of current image
                ShoppedGuiHelper.CurrentImage.CurrentHeight = ShoppedGuiHelper.CurrentImage.UnzoomedHeight = ShoppedGuiHelper.CurrentImage.CurrentImage.Height;
                ShoppedGuiHelper.CurrentImage.CurrentWidth = ShoppedGuiHelper.CurrentImage.UnzoomedWidth = ShoppedGuiHelper.CurrentImage.CurrentImage.Width;
            }
        }
    }
}
