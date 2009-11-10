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
         * @param pictureBoxImage The PictureBoxImage object in the current context of Shopped GUI
         * @return A PictureBoxImage object with the appropriate properties set by this method.
         */

        public PictureBoxImage AdjustBrightness(PictureBoxImage pictureBoxImage, float brightnessLevel)
        {
            PictureBoxImage newPictureBoxImage = new PictureBoxImage(pictureBoxImage);
            float finalValue = brightnessLevel / 255.0f;
            Bitmap brightnessBmp = new Bitmap(newPictureBoxImage.CurrentImage.Width, newPictureBoxImage.CurrentImage.Height);
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
            g.DrawImage(newPictureBoxImage.CurrentImage,
                new Rectangle(0, 0, newPictureBoxImage.CurrentImage.Width, newPictureBoxImage.CurrentImage.Height),
                    0, 0, newPictureBoxImage.CurrentImage.Width, newPictureBoxImage.CurrentImage.Height,
                    GraphicsUnit.Pixel, attributes);
            g.Dispose();

            newPictureBoxImage.CurrentImage = brightnessBmp;

            return newPictureBoxImage;
        }
    }
}
