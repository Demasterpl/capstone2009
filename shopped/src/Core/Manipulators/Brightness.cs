using System.Drawing;
using Core.Images;
using System.Drawing.Imaging;

namespace Core.Manipulators
{
    public class Brightness
    {
       /**
         * A filter that will change the brightness of an image.
         * 
         * @param shoppedImage The ShoppedImage object in the current context of Shopped GUI
         * @return A ShoppedImage object with the appropriate properties set by this method.
         */
        public ShoppedImage AdjustBrightness(ShoppedImage shoppedImage, float brightnessLevel)
        {
            ShoppedImage newShoppedImage = new ShoppedImage(shoppedImage);
            float finalValue = brightnessLevel / 255.0f;
            Bitmap brightnessBmp = new Bitmap(newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height);
            Graphics g = Graphics.FromImage(brightnessBmp);

            ColorMatrix colorMatrix = new ColorMatrix(
                new[]
                    {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {finalValue, finalValue, finalValue, 1, 1}
                });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(newShoppedImage.CurrentImage,
                new Rectangle(0, 0, newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height),
                    0, 0, newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height,
                    GraphicsUnit.Pixel, attributes);
            g.Dispose();

            newShoppedImage.CurrentImage = brightnessBmp;

            return newShoppedImage;
        }
    }
}
