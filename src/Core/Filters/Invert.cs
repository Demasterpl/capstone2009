using System.Drawing;
using System.Drawing.Imaging;
using Core.Images;

namespace Core.Filters
{
    public class Invert
    {

        /**
         * A filter that will invert the colors of an Image Object.
         * 
         * @param pictureBoxImage The PictureBoxImage object in the current context of Shopped GUI
         * @return A PictureBoxImage object with the appropriate properties set by this method.
         */

        public PictureBoxImage InvertColors(PictureBoxImage pictureBoxImage)
        {
            PictureBoxImage newPictureBoxImage = new PictureBoxImage(pictureBoxImage);

            Bitmap invertedBmp = new Bitmap(newPictureBoxImage.CurrentImage.Width, newPictureBoxImage.CurrentImage.Height);
            Graphics g = Graphics.FromImage(invertedBmp);

            ColorMatrix colorMatrix = new ColorMatrix(
                new[]
                    {
                        new float[] {-1, 0, 0, 0, 0},
                        new float[] {0, -1, 0, 0, 0},
                        new float[] {0, 0, -1, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {1, 1, 1, 0, 1}
                    });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(newPictureBoxImage.CurrentImage,
                new Rectangle(0, 0, newPictureBoxImage.CurrentImage.Width, newPictureBoxImage.CurrentImage.Height),
                    0, 0, newPictureBoxImage.CurrentImage.Width, newPictureBoxImage.CurrentImage.Height,
                    GraphicsUnit.Pixel, attributes);
            g.Dispose();

            newPictureBoxImage.CurrentImage = invertedBmp;

            return newPictureBoxImage;
        }
    }
}
