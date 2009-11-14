using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Core.Manipulators
{
    public class ImageDraw
    {
        public int LineThickness { get; set; }

        public ImageDraw()
        {
            LineThickness = 25;
        }

        /**
         * Gets the current position of the cursor over the PictureBox and sets the pixels
         * around the cursor (within the lineThickness) to the specified color.
         * 
         * @param image The image from PictureBox.
         * @param mouse Contains the current status of the mouse.
         * 
         * @return The new image that has been drawn on.
         */
        public Image DrawOnImage(Image image, MouseEventArgs mouse)
        {
            var tempImage = new Bitmap(image);

            if (mouse.Button == MouseButtons.Left)
            {
                var x = mouse.X;
                var y = mouse.Y;
                var centerLine = LineThickness / 2;

                for (int i = x - centerLine; i <= x + centerLine; ++i)
                {
                    for (int j = y - centerLine; j <= y + centerLine; ++j)
                    {
                        try
                        {
                            tempImage.SetPixel(i, j, Color.Red);
                        }
                        catch
                        {
                            //gulp - IndexOutOfBounds Exception
                        }
                    }
                }
            }
            return tempImage;
        }
    }
}
