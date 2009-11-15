using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Core.Manipulators
{
    /**
     * Handles all the drawing functionality.
     * 
     * @param LineColor The color of the line to be drawn.
     * @param LineThickness How wide the line to be drawn will be.
     * @param LineShape The shape of the line (i.e. rounded, square, etc.)
     * @param Enabled Holds whether or not the drawing functionality is enabled.
     */
    public class ImageDraw
    {
        public Color LineColor { get; set; }
        public int LineThickness { get; set; }
        public string LineShape { get; set; }
        public bool Enabled { get; set; }

        public ImageDraw()
        {
            LineColor = Color.Black;
            LineThickness = 25;
            LineShape = "square";
            Enabled = false;
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

            if (mouse.Button == MouseButtons.Left && Enabled == true)
            {            
                var tempImage = new Bitmap(image);
                var g = Graphics.FromImage(tempImage);

                var x = mouse.X;
                var y = mouse.Y;
                var centerLine = LineThickness / 2;

                var upperLeftX = x - centerLine;
                var upperLeftY = y - centerLine;

                switch (LineShape)
                {
                    case "square":
                        g.FillRectangle(new SolidBrush(LineColor), upperLeftX, upperLeftY, LineThickness, LineThickness);
                        break;
                    case "circle":
                        break;
                }

                //for (int i = x - centerLine; i <= x + centerLine; ++i)
                //{
                //    for (int j = y - centerLine; j <= y + centerLine; ++j)
                //    {
                //        try
                //        {
                //            tempImage.SetPixel(i, j, LineColor);
                //        }
                //        catch
                //        {
                //            //gulp - IndexOutOfBounds Exception (person is drawing near picture bound)
                //        }
                //    }
                //}            
                return tempImage;
            }

            return image;
        }

        /**
         * Called upon when the Draw button is clicked in the GUI and sets the Enabled property accordingly.
         */
        public void ToggleEnabledState()
        {
            if (Enabled == true)
            {
                Enabled = false;
            }
            else
            {
                Enabled = true;
            }
        }
    }
}
