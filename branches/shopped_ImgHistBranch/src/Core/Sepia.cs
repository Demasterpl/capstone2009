using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using Core.Images;
namespace Core
{
    public class Sepia
    {

        /**
         * A filter that will make an Image object sepia.
         * 
         * @param pictureBoxImage The PictureBoxImage object in the current context of Shopped GUI
         * @return A PictureBoxImage object with the appropriate properties set by this method.
         */
        public PictureBoxImage MakeSepia(PictureBoxImage pictureBoxImage)
        {
            var SepiaBmp = new Bitmap(pictureBoxImage.CurrentImage.Width, pictureBoxImage.CurrentImage.Height);
            Graphics g = Graphics.FromImage(SepiaBmp);

            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {.393f, .349f, .272f, 0, 0},
                    new float[] {0.769f, 0.686f, 0.534f, 0, 0},
                    new float[] {0.189f, 0.168f, 0.131f, 0, 0},
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

            pictureBoxImage.CurrentImage = SepiaBmp;

            return pictureBoxImage;
        }
    }
}
