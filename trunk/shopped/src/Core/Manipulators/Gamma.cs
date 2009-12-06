using System;
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
            double RedLevel, double GreenLevel, double BlueLevel)
        {
            ShoppedImage newShoppedImage = new ShoppedImage(shoppedImage);
            Bitmap gammaBmp = new Bitmap(newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height);
            Graphics g = Graphics.FromImage(gammaBmp);

            g.DrawImage(newShoppedImage.CurrentImage,
                        new Rectangle(0, 0, newShoppedImage.CurrentImage.Width,
                                      newShoppedImage.CurrentImage.Height),
                        new Rectangle(0, 0, newShoppedImage.CurrentImage.Width,
                                      newShoppedImage.CurrentImage.Height), GraphicsUnit.Pixel);
            g.Dispose();

            byte[] redGamma = CreateGammaArray(RedLevel);
            byte[] greenGamma = CreateGammaArray(GreenLevel);
            byte[] blueGamma = CreateGammaArray(BlueLevel);
            for (int i = 0; i < gammaBmp.Width; i++)
            {
                for (int j = 0; j < gammaBmp.Height; j++)
                {
                    Color pixel = gammaBmp.GetPixel(i, j);
                    gammaBmp.SetPixel(i, j, Color.FromArgb(Clamp(redGamma[pixel.R], 255, 0), Clamp(greenGamma[pixel.G], 255, 0), Clamp(blueGamma[pixel.B], 255, 0)));
                }
            }

            newShoppedImage.CurrentImage = (Bitmap)gammaBmp.Clone();
            return newShoppedImage;
        }

        private byte[] CreateGammaArray(double color)
        {
            byte[] gammaArray = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                gammaArray[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / color)) + 0.5));
            }
            return gammaArray;
        }
    }
}
