using System;
using System.Drawing;
using Core.Images;
using System.Drawing.Imaging;

namespace Core.Manipulators
{
    /**
     * Handles the rotating of an image.
     */
    public class ImageRotate
    {
        private readonly ImageTrim _imageTrim;

        public ImageRotate()
        {
            _imageTrim = new ImageTrim();
        }

        /**
         *  Given a certain angle (in degrees), this method will take the CurrentImage object and rotate
         *  it by the given angle.
         *  
         * @param angle The angle (in degrees) to rotate the image
         * @param shoppedImage The ShoppedImage object in the current context of Shopped GUI.
         * @return A ShoppedImage object with the appropriate properties set by this method.
         */
        public ShoppedImage RotateImageByAngle(ShoppedImage shoppedImage, float angle)
        {
            if (shoppedImage == null)
            {
                throw new ArgumentNullException("image");
            }

            ShoppedImage newShoppedImage = new ShoppedImage(shoppedImage);

            const double pi2 = Math.PI/2.0;

            int oldWidth = newShoppedImage.CurrentImage.Width;
            int oldHeight = newShoppedImage.CurrentImage.Height;

            // Convert degrees to radians
            double theta = angle*Math.PI/180.0;
            double lockedTheta = theta;

            // Ensure theta is now [0, 2pi)
            while (lockedTheta < 0.0)
                lockedTheta += 2*Math.PI;

            double adjacentTop, oppositeTop;
            double adjacentBottom, oppositeBottom;

            // We need to calculate the sides of the triangles based
            // on how much rotation is being done to the bitmap.
            //   Refer to the first paragraph in the explaination above for 
            //   reasons why.

            if ((lockedTheta >= 0.0 && lockedTheta < pi2) ||
                (lockedTheta >= Math.PI && lockedTheta < (Math.PI + pi2)))
            {
                adjacentTop = Math.Abs(Math.Cos(lockedTheta))*oldWidth;
                oppositeTop = Math.Abs(Math.Sin(lockedTheta))*oldWidth;

                adjacentBottom = Math.Abs(Math.Cos(lockedTheta))*oldHeight;
                oppositeBottom = Math.Abs(Math.Sin(lockedTheta))*oldHeight;
            }
            else
            {
                adjacentTop = Math.Abs(Math.Sin(lockedTheta))*oldHeight;
                oppositeTop = Math.Abs(Math.Cos(lockedTheta))*oldHeight;

                adjacentBottom = Math.Abs(Math.Sin(lockedTheta))*oldWidth;
                oppositeBottom = Math.Abs(Math.Cos(lockedTheta))*oldWidth;
            }

            double newWidth = adjacentTop + oppositeBottom;
            double newHeight = adjacentBottom + oppositeTop;

            int nWidth = (int) Math.Ceiling(newWidth);
            int nHeight = (int) Math.Ceiling(newHeight);

            var rotatedBmp = new Bitmap(nWidth, nHeight);

            //var setAlpha = Graphics.FromImage(rotatedBmp);

            //var colorMatrix = new ColorMatrix(
            //    new[]
            //        {
            //            new float[] {1, 0, 0, 0, 0},
            //            new float[] {0, 1, 0, 0, 0},
            //            new float[] {0, 0, 1, 0, 0},
            //            new float[] {0, 0, 0, 0, 0},
            //            new float[] {0, 0, 0, 0, 1}
            //        });

            //var attributes = new ImageAttributes();
            //attributes.SetColorMatrix(colorMatrix);
            //setAlpha.DrawImage(rotatedBmp,
            //    new Rectangle(0, 0, rotatedBmp.Width, rotatedBmp.Height),
            //        0, 0, rotatedBmp.Width, rotatedBmp.Height,
            //        GraphicsUnit.Pixel, attributes);
            //setAlpha.Dispose();

            
            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {
                // This array will be used to pass in the three points that 
                // make up the rotated image
                Point[] points;

                /*
                 * The values of opposite/adjacentTop/Bottom are referring to 
                 * fixed locations instead of in relation to the
                 * rotating image so I need to change which values are used
                 * based on the how much the image is rotating.
                 * 
                 * For each point, one of the coordinates will always be 0, 
                 * nWidth, or nHeight.  This because the Bitmap we are drawing on
                 * is the bounding box for the rotated bitmap.  If both of the 
                 * corrdinates for any of the given points wasn't in the set above
                 * then the bitmap we are drawing on WOULDN'T be the bounding box
                 * as required.
                 */

                if (lockedTheta >= 0.0 && lockedTheta < pi2)
                {
                    points = new[]
                                 {
                                     new Point((int) oppositeBottom, 0),
                                     new Point(nWidth, (int) oppositeTop),
                                     new Point(0, (int) adjacentBottom)
                                 };
                }
                else if (lockedTheta >= pi2 && lockedTheta < Math.PI)
                {
                    points = new[]
                                 {
                                     new Point(nWidth, (int) oppositeTop),
                                     new Point((int) adjacentTop, nHeight),
                                     new Point((int) oppositeBottom, 0)
                                 };
                }
                else if (lockedTheta >= Math.PI && lockedTheta < (Math.PI + pi2))
                {
                    points = new[]
                                 {
                                     new Point((int) adjacentTop, nHeight),
                                     new Point(0, (int) adjacentBottom),
                                     new Point(nWidth, (int) oppositeTop)
                                 };
                }
                else
                {
                    points = new[]
                                 {
                                     new Point(0, (int) adjacentBottom),
                                     new Point((int) oppositeBottom, 0),
                                     new Point((int) adjacentTop, nHeight)
                                 };
                }


                g.DrawImage(newShoppedImage.CurrentImage, points);

            }

            //Trim off the excess whitespace that is created sometimes by doing multiple rotations
            var trimmedImage = _imageTrim.TrimImage(rotatedBmp);

            newShoppedImage.CurrentImage = trimmedImage;
            newShoppedImage.CurrentWidth = trimmedImage.Width;
            newShoppedImage.CurrentHeight = trimmedImage.Height;
            newShoppedImage.DegreesRotated = angle;

            return newShoppedImage;
        }
    }
}