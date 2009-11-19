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
         * @param shoppedImage The ShoppedImage object in the current context of Shopped GUI.
         * @return A ShoppedImage object with the appropriate properties set by this method.
         */
        public ShoppedImage InvertColors(ShoppedImage shoppedImage)
        {
            ShoppedImage newShoppedImage = new ShoppedImage(shoppedImage);

            Bitmap invertedBmp = new Bitmap(newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height);
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
            g.DrawImage(newShoppedImage.CurrentImage,
                new Rectangle(0, 0, newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height),
                    0, 0, newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height,
                    GraphicsUnit.Pixel, attributes);
            g.Dispose();

            newShoppedImage.CurrentImage = invertedBmp;

            return newShoppedImage;
        }
    }
}
