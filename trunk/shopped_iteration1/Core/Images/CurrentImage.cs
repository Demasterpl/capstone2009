using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Images
{
    public class CurrentImage
    {
        public int CurrentHeight { get; set; }
        public int CurrentWidth { get; set; }
        public int ZoomLevel { get; set; }
        public float DegreesRotated { get; set; }
        public Image InitialImage { get; set; }

        public CurrentImage() { }
        public CurrentImage(int currentHeight, int currentWidth, int zoomLevel, float degreesRotated, Image currentImage)
        {
            CurrentHeight = currentHeight;
            CurrentWidth = currentWidth;
            ZoomLevel = zoomLevel;
            DegreesRotated = degreesRotated;
            InitialImage = currentImage;
        }
    }
}
