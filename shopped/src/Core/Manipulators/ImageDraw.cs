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
     * @param LineShape The shape of the line (i.e. Circle, square, etc.)
     * @param Enabled Holds whether or not the drawing functionality is enabled.
     * @param _lineShapeTypes The private backing field for LineShapeTypes (can be set).
     * @param LineShapeTypes The public-facing list of possible line shapes (read-only).
     */
    public class ImageDraw
    {
        public Color LineColor { get; set; }
        public int LineThickness { get; set; }
        public string CurrentLineShape { get; set; }
        public bool Enabled { get; set; }
        public Point InitialPoint { get; set; }
        public Point DestinationPoint { get; set; }

        // Want the public-facing List to be read-only, so we need private backing field here.
        private List<string> _lineShapeTypes { get; set; }
        public List<string> LineShapeTypes 
        { 
            get
            {
                return _lineShapeTypes;
            } 
        }

        /**
         * Default constructor that uses default values.
         */
        public ImageDraw() : this(Color.Black, 25, new List<String> {"Square", "Circle", "Line"}, "Square", false)
        { }

        /**
         * Constructor that takes in an ImageDraw object as a parameter.
         */
        public ImageDraw(ImageDraw imageDraw) 
            : this(imageDraw.LineColor, imageDraw.LineThickness, imageDraw.LineShapeTypes, 
                    imageDraw.CurrentLineShape, imageDraw.Enabled)
        { }

        /**
         * The constructor that is called on by all others in ImageDraw, this sets the properties values.
         */
        public ImageDraw(Color lineColor, int lineThickness, List<string> lineShapes, string lineShape, bool enabled)
        {
            LineColor = lineColor;
            LineThickness = lineThickness;
            _lineShapeTypes = lineShapes;
            CurrentLineShape = lineShape;
            Enabled = enabled;
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
        public Image DrawShapeOnImage(Image image, MouseEventArgs mouse)
        {

            if (mouse.Button == MouseButtons.Left && Enabled == true)
            {            
                var tempImage = new Bitmap(image);
                using (var g = Graphics.FromImage(tempImage))
                {
                    var x = mouse.X;
                    var y = mouse.Y;
                    var centerLine = LineThickness / 2;

                    var upperLeftX = x - centerLine;
                    var upperLeftY = y - centerLine;

                    switch (CurrentLineShape)
                    {
                        case "Square":
                            g.FillRectangle(new SolidBrush(LineColor), upperLeftX, upperLeftY, LineThickness, LineThickness);
                            break;
                        case "Circle":
                            g.FillEllipse(new SolidBrush(LineColor), upperLeftX, upperLeftY, LineThickness, LineThickness);
                            break;
                        case "Line":
                            g.DrawLine(new Pen(LineColor, LineThickness), InitialPoint, DestinationPoint);
                            break;
                    }

                    return tempImage;
                }
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

        public void SetInitialPoint(int xCoordinate, int yCoordinate)
        {
            InitialPoint = new Point(xCoordinate, yCoordinate);
        }

        public void SetDestinationPoint(int xCoordinate, int yCoordinate)
        {
            DestinationPoint = new Point(xCoordinate, yCoordinate);
        }
    }
}
