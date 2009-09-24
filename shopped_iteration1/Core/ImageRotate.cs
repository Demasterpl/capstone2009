using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Core
{
    public class ImageRotate
    {
        public Image RotateImageByAngle(Image originalImage, float angle)
        {
            var rotatedImage = new Bitmap(originalImage);
            Graphics g = Graphics.FromImage(rotatedImage);

            //move rotation point to center of image
            g.TranslateTransform((float)originalImage.Width / 2, (float)originalImage.Height / 2);
            //rotate
            g.RotateTransform(angle);
            //move image back
            g.TranslateTransform(-(float)originalImage.Width / 2, -(float)originalImage.Height / 2);
            //draw passed in image onto graphics object
            g.DrawImage(originalImage, new Point(0, 0));
            return rotatedImage;
        }
    }
}
