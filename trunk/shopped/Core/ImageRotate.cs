using System;
using System.Drawing;

namespace Core
{
    public class ImageRotate
    {
        /**
         *  Given a certain angle (in degrees), this method will take the CurrentImage object and rotate
         *  it by the given angle.
         *  
         *  @param angle The angle (in degrees) to rotate the image
         */
        public void RotateImageByAngle(float angle)
        {

            if (ShoppedGuiHelper.CurrentImage.CurrentImage == null)
            {
                throw new ArgumentNullException("image");
            }

            const double pi2 = Math.PI / 2.0;

            var oldWidth = ShoppedGuiHelper.CurrentImage.CurrentImage.Width;
            var oldHeight = ShoppedGuiHelper.CurrentImage.CurrentImage.Height;

            // Convert degrees to radians
            var theta = angle * Math.PI / 180.0;
            var lockedTheta = theta;

            // Ensure theta is now [0, 2pi)
            while (lockedTheta < 0.0)
                lockedTheta += 2 * Math.PI;

            double adjacentTop, oppositeTop;
            double adjacentBottom, oppositeBottom;

            // We need to calculate the sides of the triangles based
            // on how much rotation is being done to the bitmap.
            //   Refer to the first paragraph in the explaination above for 
            //   reasons why.
            if ((lockedTheta >= 0.0 && lockedTheta < pi2) ||
                (lockedTheta >= Math.PI && lockedTheta < (Math.PI + pi2)))
            {
                adjacentTop = Math.Abs(Math.Cos(lockedTheta)) * oldWidth;
                oppositeTop = Math.Abs(Math.Sin(lockedTheta)) * oldWidth;

                adjacentBottom = Math.Abs(Math.Cos(lockedTheta)) * oldHeight;
                oppositeBottom = Math.Abs(Math.Sin(lockedTheta)) * oldHeight;
            }
            else
            {
                adjacentTop = Math.Abs(Math.Sin(lockedTheta)) * oldHeight;
                oppositeTop = Math.Abs(Math.Cos(lockedTheta)) * oldHeight;

                adjacentBottom = Math.Abs(Math.Sin(lockedTheta)) * oldWidth;
                oppositeBottom = Math.Abs(Math.Cos(lockedTheta)) * oldWidth;
            }

            var newWidth = adjacentTop + oppositeBottom;
            var newHeight = adjacentBottom + oppositeTop;

            var nWidth = (int)Math.Ceiling(newWidth);
            var nHeight = (int)Math.Ceiling(newHeight);

            var rotatedBmp = new Bitmap(nWidth, nHeight);

            using (var g = Graphics.FromImage(rotatedBmp))
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
                    points = new[] { 
											 new Point( (int) oppositeBottom, 0 ), 
											 new Point( nWidth, (int) oppositeTop ),
											 new Point( 0, (int) adjacentBottom )
										 };

                }
                else if (lockedTheta >= pi2 && lockedTheta < Math.PI)
                {
                    points = new[] { 
											 new Point( nWidth, (int) oppositeTop ),
											 new Point( (int) adjacentTop, nHeight ),
											 new Point( (int) oppositeBottom, 0 )						 
										 };
                }
                else if (lockedTheta >= Math.PI && lockedTheta < (Math.PI + pi2))
                {
                    points = new[] { 
											 new Point( (int) adjacentTop, nHeight ), 
											 new Point( 0, (int) adjacentBottom ),
											 new Point( nWidth, (int) oppositeTop )
										 };
                }
                else
                {
                    points = new[] { 
											 new Point( 0, (int) adjacentBottom ), 
											 new Point( (int) oppositeBottom, 0 ),
											 new Point( (int) adjacentTop, nHeight )		
										 };
                }

                g.DrawImage(ShoppedGuiHelper.CurrentImage.CurrentImage, points);
            }

            ShoppedGuiHelper.CurrentImage.CurrentImage = rotatedBmp;
            ShoppedGuiHelper.CurrentImage.CurrentHeight = rotatedBmp.Height;
            ShoppedGuiHelper.CurrentImage.CurrentWidth = rotatedBmp.Width;
        }
    }
}
