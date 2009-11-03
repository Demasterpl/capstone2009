using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Core.Images;
using System.Drawing.Imaging;

namespace Core
{
    public class Brightness
    {
        public PictureBoxImage AdjustBrightness(PictureBoxImage pictureBoxImage, float brightnessLevel)
        {
            PictureBoxImage newPictureBoxImage = new PictureBoxImage(pictureBoxImage);
            float FinalValue = (float)brightnessLevel / 255.0f;
            var BrightnessBmp = new Bitmap(newPictureBoxImage.CurrentImage.Width, newPictureBoxImage.CurrentImage.Height);
            Graphics g = Graphics.FromImage(BrightnessBmp);

            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {FinalValue, FinalValue, FinalValue, 1, 1}
                });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(newPictureBoxImage.CurrentImage,
                new Rectangle(0, 0, newPictureBoxImage.CurrentImage.Width, newPictureBoxImage.CurrentImage.Height),
                    0, 0, newPictureBoxImage.CurrentImage.Width, newPictureBoxImage.CurrentImage.Height,
                    GraphicsUnit.Pixel, attributes);
            g.Dispose();

            newPictureBoxImage.CurrentImage = BrightnessBmp;

            return newPictureBoxImage;
        }
    }
}
