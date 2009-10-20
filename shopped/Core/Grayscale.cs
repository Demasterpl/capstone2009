using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
namespace Core
{
    public class Grayscale
    {
        public void MakeGrayscale()
        {
            var GrayscaleBmp = new Bitmap(ShoppedGuiHelper.CurrentImage.CurrentImage.Width, ShoppedGuiHelper.CurrentImage.CurrentImage.Height);
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
            g.DrawImage(ShoppedGuiHelper.CurrentImage.CurrentImage,
                new Rectangle(0, 0, ShoppedGuiHelper.CurrentImage.CurrentImage.Width, ShoppedGuiHelper.CurrentImage.CurrentImage.Height),
                    0, 0, ShoppedGuiHelper.CurrentImage.CurrentImage.Width, ShoppedGuiHelper.CurrentImage.CurrentImage.Height,
                    GraphicsUnit.Pixel, attributes);
            g.Dispose();

            ShoppedGuiHelper.CurrentImage.CurrentImage = GrayscaleBmp;

            
        }
    }
}
