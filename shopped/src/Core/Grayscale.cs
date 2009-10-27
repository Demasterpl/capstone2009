using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var GrayscaleBmp = new Bitmap(pictureBoxImage.CurrentImage.Width, pictureBoxImage.CurrentImage.Height);
            Graphics g = Graphics.FromImage(GrayscaleBmp);

            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {.3f, .3f, .3f, 0, 0},
                    new float[] {.59f, .59f, .59f, 0, 0},
                    new float[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(pictureBoxImage.CurrentImage,
                new Rectangle(0, 0, pictureBoxImage.CurrentImage.Width, pictureBoxImage.CurrentImage.Height),
                    0, 0, pictureBoxImage.CurrentImage.Width, pictureBoxImage.CurrentImage.Height,
                    GraphicsUnit.Pixel, attributes);
            g.Dispose();

            pictureBoxImage.CurrentImage = GrayscaleBmp;

            return pictureBoxImage;
        }
    }
}
