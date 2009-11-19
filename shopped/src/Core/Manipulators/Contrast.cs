using System.Drawing;
using Core.Images;

namespace Core.Manipulators
{
    /**
     * Applies a contrast filter to an image.
     */
    public class Contrast
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
        * A filter that will change the contrast of an image.
        * 
        * @param shoppedImage The ShoppedImage object in the current context of Shopped GUI
        * @return A ShoppedImage object with the appropriate properties set by this method.
        */  
        public ShoppedImage AdjustContrast(ShoppedImage shoppedImage, float contrastLevel)

        {
            ShoppedImage newShoppedImage = new ShoppedImage(shoppedImage);

            contrastLevel = (100.0f + contrastLevel)/100.0f;
            contrastLevel *= contrastLevel;
            Bitmap contrastBmp = new Bitmap(newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height);
            Graphics g = Graphics.FromImage(contrastBmp);

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
                    Color pixel = contrastBmp.GetPixel(x, y);
                    float red = pixel.R/255.0f;
                    float green = pixel.G/255.0f;
                    float blue = pixel.B/255.0f;
                    red = (((red - 0.5f)*contrastLevel) + 0.5f)*255.0f;
                    green = (((green - 0.5f)*contrastLevel) + 0.5f)*255.0f;
                    blue = (((blue - 0.5f)*contrastLevel) + 0.5f)*255.0f;
                    contrastBmp.SetPixel(x, y, Color.FromArgb(Clamp((int)red, 255, 0), Clamp((int)green, 255, 0),Clamp((int)blue, 255, 0)));
                }
            }
            newShoppedImage.CurrentImage = contrastBmp;
            return newShoppedImage;
        }
    }
}