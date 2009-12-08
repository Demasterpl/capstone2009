using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using Core.Images;

namespace Core.Manipulators
{
    /**
     * Handles the zooming in and out of an image.
     */
    public class ImageZoom
    {
        /**
         * Zooms the image in the Shopped GUI to the specified zoom level.
         * 
         * @param zoom The amount of zoom to use on the image (1.0f == 100%).
         * @param image The image to be zoomed.
         * @return The zoomed Image object.
         */
        public Image ZoomImage(Image image, float zoom)
        {
            image = new Bitmap(image,
                (int)(image.Width * zoom),
                (int)(image.Height * zoom));

            return image;

        }

        public ShoppedImage ZoomImage2x(ShoppedImage shoppedImage)
        {
            var newShoppedImage = new ShoppedImage(shoppedImage);

            newShoppedImage.CurrentImage = new Bitmap(shoppedImage.CurrentImage.Width * 2, shoppedImage.CurrentImage.Height * 2);

            for (int origX = 0, zoomX = 0; origX < shoppedImage.CurrentImage.Width; ++origX, zoomX += 2)
            {
                for (int origY = 0, zoomY = 0; origY < shoppedImage.CurrentImage.Height; ++origY, zoomY += 2)
                {
                    var color = (shoppedImage.CurrentImage as Bitmap).GetPixel(origX, origY);
                    (newShoppedImage.CurrentImage as Bitmap).SetPixel(zoomX, zoomY, color);
                    (newShoppedImage.CurrentImage as Bitmap).SetPixel(zoomX + 1, zoomY, color);
                    (newShoppedImage.CurrentImage as Bitmap).SetPixel(zoomX, zoomY + 1, color);
                    (newShoppedImage.CurrentImage as Bitmap).SetPixel(zoomX + 1, zoomY + 1, color);
                }
            }

            newShoppedImage.CurrentHeight = newShoppedImage.CurrentImage.Height;
            newShoppedImage.CurrentWidth = newShoppedImage.CurrentImage.Width;

            return newShoppedImage;
        }
    }
}
