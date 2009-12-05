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

        public ShoppedImage MakeGrayscaleTraditional(ShoppedImage shoppedImage)
        {
            ShoppedImage newShoppedImage = new ShoppedImage(shoppedImage);

            Bitmap grayscaletBmp = new Bitmap(newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height);
            Graphics g = Graphics.FromImage(grayscaletBmp);

            g.DrawImage(newShoppedImage.CurrentImage,
                        new Rectangle(0, 0, newShoppedImage.CurrentImage.Width,
                                      newShoppedImage.CurrentImage.Height),
                        new Rectangle(0, 0, newShoppedImage.CurrentImage.Width,
                                      newShoppedImage.CurrentImage.Height), GraphicsUnit.Pixel);
            g.Dispose();

            for (int x = 0; x < newShoppedImage.CurrentImage.Width; ++x)
            {
                for (int y = 0; y < newShoppedImage.CurrentImage.Height; ++y)
                {
                    Color pixel = grayscaletBmp.GetPixel(x, y);
                    int grayscale = (int) ((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));
                    Color grayscaleColor = Color.FromArgb(Clamp(grayscale, 255, 0), Clamp(grayscale, 255, 0), Clamp(grayscale, 255, 0));
                    grayscaletBmp.SetPixel(x, y, grayscaleColor);
                }
            }

            newShoppedImage.CurrentImage = grayscaletBmp;
            return newShoppedImage;
        }
        
        private static int Clamp(int Value, int Max, int Min)
        {
            Value = Value > Max ? Max : Value;
            Value = Value < Min ? Min : Value;
            return Value;
        }

    }
}
