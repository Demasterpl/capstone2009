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
            if (zoom == 1.0f)
            {
                ShoppedGuiHelper.TempImage = ShoppedGuiHelper.ImageRotate.RotateImageByAngle(ShoppedGuiHelper.CurrentImage.InitialImage, ShoppedGuiHelper.DegreesRotated);
            }
            else
            {
                ShoppedGuiHelper.TempImage = new Bitmap(ShoppedGuiHelper.TempImage,
                    (int)(ShoppedGuiHelper.TempImage.Width * zoom), (int)(ShoppedGuiHelper.TempImage.Height * zoom));
            }
            ShoppedGuiHelper.Zoom = zoom;
        }
    }
}
