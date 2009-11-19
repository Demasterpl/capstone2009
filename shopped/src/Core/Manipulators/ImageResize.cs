using System.Drawing;
using Core.Images;

namespace Core.Manipulators
{
    /**
     * Handles the resizing of an image.
     */
    public class ImageResize
    {
        /**
         * Resizes the image in the Shopped GUI to the specified resize level.
         * 
         * @param resize The amount to resize the image to.
         * @param shoppedImage The ShoppedImage object in the current context of Shopped GUI
         * @return A ShoppedImage object with the appropriate properties set by this method.
         */
        public ShoppedImage ResizeImage(ShoppedImage shoppedImage, float resize)
        {
            //new up a ShoppedImage
            ShoppedImage newShoppedImage = new ShoppedImage(shoppedImage);

            newShoppedImage.ResizeLevel = resize;

            //Calculate new height and width
            int newWidth = (int) (newShoppedImage.CurrentImage.Width*resize);
            int newHeight = (int) (newShoppedImage.CurrentImage.Height*resize);

            //Set unzoomed image to new image
            newShoppedImage.CurrentWidth = newWidth;
            newShoppedImage.CurrentHeight = newHeight;
            newShoppedImage.CurrentImage = new Bitmap(newShoppedImage.CurrentImage, new Size(newWidth, newHeight));

            return newShoppedImage;
        }
    }
}
