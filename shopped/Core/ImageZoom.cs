using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Core
{
    public class ImageZoom
    {
        /**
         * Zooms the image in the Shopped GUI to the specified zoom level.
         * @param zoom The amount of zoom to use on the image (1.0f == 100%).
         */
        public void ZoomImage(float zoom)
        {
            //Reset current image to 100% zoom
            ShoppedGuiHelper.CurrentImage.CurrentImage = ShoppedGuiHelper.CurrentImage.UnzoomedImage;
            ShoppedGuiHelper.CurrentImage.ZoomLevel = zoom;
            
            if (zoom == 1.0f)
            {
                return;
            }
            else
            {
                ShoppedGuiHelper.CurrentImage.CurrentImage = new Bitmap(
                    ShoppedGuiHelper.CurrentImage.CurrentImage,
                    (int)(ShoppedGuiHelper.CurrentImage.CurrentImage.Width * zoom),
                    (int)(ShoppedGuiHelper.CurrentImage.CurrentImage.Height * zoom));
                    ShoppedGuiHelper.ImageRotate.RotateImageByAngle(ShoppedGuiHelper.CurrentImage.DegreesRotated);
            }
        }
    }
}
