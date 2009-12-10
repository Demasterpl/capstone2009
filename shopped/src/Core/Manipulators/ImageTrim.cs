using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Core.Manipulators
{
    public class ImageTrim
    {
        private Bitmap originalImage;

        /**
         * Goes through an algorithm which will remove all excess whitespace around an
         * image.
         * 
         * @param original The image with excess whitespace to be trimmed.
         * @return A new image that has all the excess whitespace removed.
         */
        public Bitmap TrimImage(Bitmap original)
        {
            originalImage = new Bitmap(original);

            //Start the coordinates at the boundaries of the image - (0,0) to (Width, Height)
            int top = 0, bottom = originalImage.Height, left = 0, right = originalImage.Width;

            //Find the coordinates of where the image is inside of the whitespace surrounding it
            top = GetTopCoordinate();
            bottom = GetBottomCoordinate();
            left = GetLeftCoordinate();
            right = GetRightCoordinate();

            //Calculate new height and width of image without excess whitespace
            var trimmedHeight = bottom - top;
            var trimmedWidth = right - left;
            var trimmedBmp = new Bitmap(trimmedWidth, trimmedHeight);

            //Grab each pixel from the original image and set it respectively to the pixel in
            //new image without whitespace
            for (int x = 0; x < trimmedWidth; ++x)
            {
                for (int y = 0; y < trimmedHeight; ++y)
                {
                    trimmedBmp.SetPixel(x, y, originalImage.GetPixel(x + left, y + top));
                }
            }

            return trimmedBmp;
        }

        /**
         * Goes from the right-most column of pixels in the image and checks each pixel
         * in the column for alpha value of 0. As soon as a pixel in a given column
         * has an alpha value != 0, then we have found where the boundary of the image
         * is and return that position.
         * 
         * @return the first column from the right that contains part of the actual image.
         * 
         */
        private int GetRightCoordinate()
        {
            for (int x = originalImage.Width - 1; x >= 0; --x)
            {
                for (int y = originalImage.Height - 1; y >= 0; --y)
                {
                    if (originalImage.GetPixel(x, y).A != 0)
                    {
                        return x;
                    }
                }
            }

            return originalImage.Width;
        }

        /**
         * Goes from the left-most column of pixels in the image and checks each pixel
         * in the column for alpha value of 0. As soon as a pixel in a given column
         * has an alpha value != 0, then we have found where the boundary of the image
         * is and return that position.
         * 
         * @return the first column from the left that contains part of the actual image.
         * 
         */
        private int GetLeftCoordinate()
        {
            for (int x = 0; x < originalImage.Width; ++x)
            {
                for (int y = 0; y < originalImage.Height; ++y)
                {
                    if (originalImage.GetPixel(x, y).A != 0)
                    {
                        return x;
                    }
                }
            }

            return 0;
        }

        /**
         * Goes from the bottom-most row of pixels in the image and checks each pixel
         * in the row for alpha value of 0. As soon as a pixel in a given row
         * has an alpha value != 0, then we have found where the boundary of the image
         * is and return that position.
         * 
         * @return the first row from the bottom that contains part of the actual image.
         * 
         */
        private int GetBottomCoordinate()
        {
            for (int y = originalImage.Height - 1; y >= 0; --y)
            {
                for (int x = originalImage.Width - 1; x >= 0; --x)
                {
                    if (originalImage.GetPixel(x, y).A != 0)
                    {
                        return y;
                    }
                }
            }

            return originalImage.Height;
        }

        /**
         * Goes from the top-most row of pixels in the image and checks each pixel
         * in the row for alpha value of 0. As soon as a pixel in a given row
         * has an alpha value != 0, then we have found where the boundary of the image
         * is and return that position.
         * 
         * @return the first row from the top that contains part of the actual image.
         * 
         */
        private int GetTopCoordinate()
        {
            for (int y = 0; y < originalImage.Height; ++y)
            {
                for (int x = 0; x < originalImage.Width; ++x)
                {
                    if (originalImage.GetPixel(x, y).A != 0)
                    {
                        return y;
                    }
                }
            }

            return 0;
        }
    }
}
