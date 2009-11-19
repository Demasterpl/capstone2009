using System.Drawing;
using System.Drawing.Imaging;
using Core.Images;

namespace Core.Filters
{
    public class Grayscale
    {
        /**
         * A filter that will make an Image object grayscale.
         * 
         * @param shoppedImage The ShoppedImage object in the current context of Shopped GUI
         * @return A ShoppedImage object with the appropriate properties set by this method.
         */
        public ShoppedImage MakeGrayscale(ShoppedImage shoppedImage)
        {
            ShoppedImage newShoppedImage = new ShoppedImage(shoppedImage);

            Bitmap grayscaleBmp = new Bitmap(newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height);
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
            g.DrawImage(newShoppedImage.CurrentImage,
                new Rectangle(0, 0, newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height),
                    0, 0, newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height,
                    GraphicsUnit.Pixel, attributes);
            g.Dispose();

            newShoppedImage.CurrentImage = grayscaleBmp;

            return newShoppedImage;
        }
    }
}
