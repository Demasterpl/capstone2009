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
            ShoppedGuiHelper.TempImage = new Bitmap(ShoppedGuiHelper.TempImage, (int)(ShoppedGuiHelper.TempImage.Width * resize),
                (int)(ShoppedGuiHelper.TempImage.Height * resize));
            ShoppedGuiHelper.CurrentImage.InitialImage = ShoppedGuiHelper.TempImage;
        }
    }
}
