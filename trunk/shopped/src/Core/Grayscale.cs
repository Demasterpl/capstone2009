using System.Drawing;
using System.Drawing.Imaging;
using Core.Images;

namespace Core
{
    public class Grayscale
    {

        /**
         * A filter that will make an Image object grayscale.
         * 
         * @param pictureBoxImage The PictureBoxImage object in the current context of Shopped GUI
         * @return A PictureBoxImage object with the appropriate properties set by this method.
         */

        public PictureBoxImage MakeGrayscale(PictureBoxImage pictureBoxImage)
        {
            PictureBoxImage newPictureBoxImage = new PictureBoxImage(pictureBoxImage);

            Bitmap grayscaleBmp = new Bitmap(newPictureBoxImage.CurrentImage.Width, newPictureBoxImage.CurrentImage.Height);
            Graphics g = Graphics.FromImage(grayscaleBmp);

            ColorMatrix colorMatrix = new ColorMatrix(
                new[]
                    {
                    new float[] {.3f, .3f, .3f, 0, 0},
                    new float[] {.59f, .59f, .59f, 0, 0},
                    new float[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(newPictureBoxImage.CurrentImage,
                new Rectangle(0, 0, newPictureBoxImage.CurrentImage.Width, newPictureBoxImage.CurrentImage.Height),
                    0, 0, newPictureBoxImage.CurrentImage.Width, newPictureBoxImage.CurrentImage.Height,
                    GraphicsUnit.Pixel, attributes);
            g.Dispose();

            newPictureBoxImage.CurrentImage = grayscaleBmp;

            return newPictureBoxImage;
        }
    }
}
