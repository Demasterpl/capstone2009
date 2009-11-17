using System.Drawing;

namespace Core.Manipulators
{
    public class ImageZoom
    {
        public ImageZoom()
        {
        }

        /**
         * Zooms the image in the Shopped GUI to the specified zoom level.
         * 
         * @param zoom The amount of zoom to use on the image (1.0f == 100%).
         * @param pictureBoxImage The PictureBoxImage object in the current context of Shopped GUI
         * @return A PictureBoxImage object with the appropriate properties set by this method.
         */

        public Image ZoomImage(Image pictureBox, float zoom)
        {
            pictureBox = new Bitmap(pictureBox, 
                (int)(pictureBox.Width * zoom),
                (int)(pictureBox.Height * zoom));

            return pictureBox;          
        }
    }
}
