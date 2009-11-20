using System.Drawing;
using Core.Images;

namespace Core.Manipulators
{
     /**
     * Applies a gamma filter to an image.
     */
    public class Gamma
    {
        /**
         * A clamp class that make sure the RBG values lie in the specified
         * range. If it is greater than the max value, it is replaced by the max value.
         * 
         * @param value The value being compared
         * @param max The maximum allowed value
         * @param min The minimum allowed value
         */
        private static int Clamp(int Value, int Max, int Min)
        {
            Value = Value > Max ? Max : Value;
            Value = Value < Min ? Min : Value;
            return Value;
        }

       /**
        * A filter that will change the gamma of an image.
        * 
        * @param shoppedImage The ShoppedImage object in the current context of Shopped GUI
        * @param RedLevel The level the red gamma will be adjusted to
        * @param GreenLevel The level the green gamma will be adjusted to
        * @param BlueLevel The level the blue gamma will be adjusted to
        * @return A ShoppedImage object with the appropriate properties set by this method.
        */

        public ShoppedImage AdjustGamma(ShoppedImage shoppedImage,
            float RedLevel, float GreenLevel, float BlueLevel)
        {
            ShoppedImage newShoppedImage = new ShoppedImage(shoppedImage);
            Bitmap contrastBmp = new Bitmap(newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height);
            
            Graphics g = Graphics.FromImage(contrastBmp);
            g.DrawImage(newShoppedImage.CurrentImage,
                        new Rectangle(0, 0, newShoppedImage.CurrentImage.Width,
                                      newShoppedImage.CurrentImage.Height),
                        new Rectangle(0, 0, newShoppedImage.CurrentImage.Width,
                                      newShoppedImage.CurrentImage.Height), GraphicsUnit.Pixel);
            g.Dispose();

            int[] RedRamp = new int[256];
            int[] GreenRamp = new int[256];
            int[] BlueRamp = new int[256];
            for (int x = 0; x < 256; ++x)
            {
                RedRamp[x] = Clamp((int)((255.0 * System.Math.Pow(x / 255.0, 1.0 / RedLevel)) + 0.5), 255, 0);
                GreenRamp[x] = Clamp((int)((255.0 * System.Math.Pow(x / 255.0, 1.0 / GreenLevel)) + 0.5), 255, 0);
                BlueRamp[x] = Clamp((int)((255.0 * System.Math.Pow(x / 255.0, 1.0 / BlueLevel)) + 0.5), 255, 0);
            }

            for (int x = 0; x < contrastBmp.Width; ++x)
            {
                for (int y = 0; y < contrastBmp.Height; ++y)
                {
                    Color Pixel = contrastBmp.GetPixel(x, y);
                    int Red = RedRamp[Pixel.R];
                    int Green = GreenRamp[Pixel.G];
                    int Blue = BlueRamp[Pixel.B];
                    contrastBmp.SetPixel(x, y, Color.FromArgb(Red, Green, Blue));
                }
            }

            newShoppedImage.CurrentImage = contrastBmp;
            return newShoppedImage;
        }
    }
}
