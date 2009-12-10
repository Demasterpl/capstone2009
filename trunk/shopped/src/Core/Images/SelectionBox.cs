using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Core.Images
{
    public class SelectionBox
    {
        public Point InitialPoint;
        public Point DestinationPoint;

        public SelectionBox()
        {
            InitialPoint = new Point();
            DestinationPoint = new Point();
        }

        public int GetSelectionWidth()
        {
            var leftX = InitialPoint.X < DestinationPoint.X ? InitialPoint.X : DestinationPoint.X;
            var rightX = InitialPoint.X > DestinationPoint.X ? InitialPoint.X : DestinationPoint.X;

            return rightX - leftX;
        }

        public int GetSelectionHeight()
        {
            var topY = InitialPoint.Y < DestinationPoint.Y ? InitialPoint.Y : DestinationPoint.Y;
            var bottomY = InitialPoint.Y > DestinationPoint.Y ? InitialPoint.Y : DestinationPoint.Y;

            return bottomY - topY;
        }

        public void SetInitialPoint(int x, int y, int width, int height)
        {
            if (x >= 0 && x < width)
            {
                InitialPoint.X = x;
            }
            if (y >= 0 && y < height)
            {
                InitialPoint.Y = y;
            }
        }

        public void SetDestinationPoint(int x, int y, int width, int height)
        {
            if (x >= 0 && x < width)
            {
                DestinationPoint.X = x;
            }
            if (y >= 0 && y < height)
            {
                DestinationPoint.Y = y;
            }
        }

        public int GetLeftMostX()
        {
            return InitialPoint.X < DestinationPoint.X ? InitialPoint.X : DestinationPoint.X;
        }

        public int GetTopMostY()
        {
            return InitialPoint.Y < DestinationPoint.Y ? InitialPoint.Y : DestinationPoint.Y;
        }

        public int GetRightMostX()
        {
            return InitialPoint.X > DestinationPoint.X ? InitialPoint.X : DestinationPoint.X;
        }

        public int GetBottomMostY()
        {
            return InitialPoint.Y > DestinationPoint.Y ? InitialPoint.Y : DestinationPoint.Y;
        }

        public bool IsMinimumSize()
        {
            return GetSelectionHeight() > 2 && GetSelectionWidth() > 2;
        }

        public Image DrawSelectionBox(Bitmap image)
        {
            //Orient the coordinates correctly based on positions of two points
            var leftX = GetLeftMostX();
            var topY = GetTopMostY();
            var rightX = GetRightMostX();
            var bottomY = GetBottomMostY();

            using (var g = Graphics.FromImage(image))
            {
                g.DrawRectangle(new Pen(Color.Crimson, 3), new Rectangle(leftX, topY, rightX - leftX, bottomY - topY));
            }

            return image;
        }
    }
}
