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
        public float DegreesRotated { get; set; }
        public Image InitialImage { get; set; }

        public CurrentImage() { }
        public CurrentImage(int currentHeight, int currentWidth, float degreesRotated, Image currentImage)
        {
            CurrentHeight = currentHeight;
            CurrentWidth = currentWidth;
            DegreesRotated = degreesRotated;
            InitialImage = currentImage;
        }
    }
}
