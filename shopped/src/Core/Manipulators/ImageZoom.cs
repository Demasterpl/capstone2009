using System.Drawing;

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
    }
}
