using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Core.Images;

namespace Core.Manipulators
{
    /**
     * Handles all the drawing functionality.
     * 
     * @param LineColor The color of the line to be drawn.
     * @param LineThickness How wide the line to be drawn will be.
     * @param ShapeHeight The height of a given shape to be drawn.
     * @param ShapeWidth The Width of a given shape to be drawn.
     * @param ShapeRadius The Radius of a circle to be drawn.
     * @param CurrentLineShape Holds the current shape to be drawn (Square, Rectangle, Triangle, Circle, Line).
     * @param Enabled Holds whether or not the drawing functionality is enabled.
     * @param _lineShapeTypes The private backing field for LineShapeTypes (can be set).
     * @param LineShapeTypes The public-facing list of possible line shapes (read-only).
     */
    public class ImageDraw
    {
        public Color LineColor { get; set; }
        public int LineThickness { get; set; }
        public int ShapeHeight { get; set; }
        public int ShapeWidth { get; set; }
        public int ShapeRadius { get; set; }
        public string CurrentLineShape { get; set; }
        public bool Enabled { get; set; }

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
        public ImageDraw() : this(Color.Black, 5, 25, 25, 25, new List<String> {"Square", "Rectangle", "Triangle", "Circle", "Line"}, "Line", false)
        { }

        /**
         * Constructor that takes in an ImageDraw object as a parameter.
         */
        public ImageDraw(ImageDraw imageDraw) 
            : this(imageDraw.LineColor, imageDraw.LineThickness, imageDraw.ShapeHeight, imageDraw.ShapeWidth, imageDraw.ShapeRadius, 
                    imageDraw.LineShapeTypes, imageDraw.CurrentLineShape, imageDraw.Enabled)
        { }

        /**
         * The constructor that is called on by all others in ImageDraw, this sets the properties values.
         */
        public ImageDraw(Color lineColor, int lineThickness, int shapeHeight, int shapeWidth, int shapeRadius, 
            List<string> lineShapes, string lineShape, bool enabled)
        {
            LineColor = lineColor;
            LineThickness = lineThickness;
            ShapeHeight = shapeHeight;
            ShapeWidth = shapeWidth;
            ShapeRadius = shapeRadius;
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
        public Image DrawShapeOnImage(Image image, SelectionBox selectionBox)
        {          
            var tempImage = new Bitmap(image);
            using (var g = Graphics.FromImage(tempImage))
            {
                var x = selectionBox.DestinationPoint.X;
                var y = selectionBox.DestinationPoint.Y;

                switch (CurrentLineShape)
                {
                    case "Square":
                        g.FillRectangle(new SolidBrush(LineColor), x - ShapeHeight / 2, y - ShapeHeight / 2, ShapeHeight, ShapeHeight);
                        break;
                    case "Rectangle":
                        g.FillRectangle(new SolidBrush(LineColor), x - ShapeWidth / 2, y - ShapeHeight / 2, ShapeWidth, ShapeHeight);
                        break;
                    case "Triangle":
                        g.FillPolygon(new SolidBrush(LineColor), new Point[] 
                             {
                                 new Point(x, y - ShapeHeight / 2), 
                                 new Point(x - ShapeWidth / 2, y + ShapeHeight / 2),
                                 new Point(x + ShapeWidth / 2, y + ShapeHeight / 2),
                             });
                        break;
                    case "Circle":
                        g.FillEllipse(new SolidBrush(LineColor), x - ShapeRadius, y - ShapeRadius, 2 * ShapeRadius, 2 * ShapeRadius);
                        break;
                    case "Line":
                        g.DrawLine(new Pen(LineColor, LineThickness), selectionBox.InitialPoint, selectionBox.DestinationPoint);
                        break;
                }

                return tempImage;
            }
        }

    }
}
