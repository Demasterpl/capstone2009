using System.Drawing;
using Core.Images;

namespace Core
{


    public class Contrast
    {
        /**
         * A generic clamp class that make sure the RBG values lie in the specified
         * range. If it is greater than the max value, it is replaced by the max value.
         * 
         * @param value The value being compared
         * @param max The maximum allowed value
         * @param min The minimum allowed value
         */

        public static T Clamp<T>(T value, T max, T min)
            where T : System.IComparable<T>
         {
            var result = value;
            if (value.CompareTo(max) > 0)
                result = max;
            if (value.CompareTo(min) < 0)
                result = min;
            return result;
        } 

        /**
        * A filter that will change the contrast of an image.
        * 
        * @param pictureBoxImage The PictureBoxImage object in the current context of Shopped GUI
        * @return A PictureBoxImage object with the appropriate properties set by this method.
        */  

        public PictureBoxImage AdjustContrast(PictureBoxImage pictureBoxImage, float contrastLevel)

        {
            var newPictureBoxImage = new PictureBoxImage(pictureBoxImage);

            contrastLevel = (100.0f + contrastLevel)/100.0f;
            contrastLevel *= contrastLevel;
            var contrastBmp = new Bitmap(newPictureBoxImage.CurrentImage.Width, newPictureBoxImage.CurrentImage.Height);
            var g = Graphics.FromImage(contrastBmp);

            g.DrawImage(newPictureBoxImage.CurrentImage,
                        new Rectangle(0, 0, newPictureBoxImage.CurrentImage.Width,
                                      newPictureBoxImage.CurrentImage.Height),
                        new Rectangle(0, 0, newPictureBoxImage.CurrentImage.Width,
                                      newPictureBoxImage.CurrentImage.Height), GraphicsUnit.Pixel);
            g.Dispose();

            for (var x = 0; x < newPictureBoxImage.CurrentImage.Width; ++x)
            {
                for (var y = 0; y < newPictureBoxImage.CurrentImage.Height; ++y)
                {
                    var pixel = contrastBmp.GetPixel(x, y);
                    var red = pixel.R/255.0f;
                    var green = pixel.G/255.0f;
                    var blue = pixel.B/255.0f;
                    red = (((red - 0.5f)*contrastLevel) + 0.5f)*255.0f;
                    green = (((green - 0.5f)*contrastLevel) + 0.5f)*255.0f;
                    blue = (((blue - 0.5f)*contrastLevel) + 0.5f)*255.0f;
                    contrastBmp.SetPixel(x, y, Color.FromArgb(Clamp((int)red, 255, 0), Clamp((int)green, 255, 0),Clamp((int)blue, 255, 0)));
                }
            }
            newPictureBoxImage.CurrentImage = contrastBmp;
            return newPictureBoxImage;
        }
    }
}