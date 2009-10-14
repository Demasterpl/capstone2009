using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Core.Images;
using Core.Interfaces;
using Core;

namespace Core
{
    public static class ShoppedGuiHelper
    {
        public static string CurrentFileName { get; set; }
        public static CurrentImage CurrentImage { get; set; }
        public static Image TempImage { get; set; }
        public static float Zoom { get; set; }
        public static float DegreesRotated { get; set; }
        public static ImageRotate ImageRotate { get; set; }
        public static IFileOperations FileOperation { get; set; }
        public static ImageHistory ImageHistory { get; set; }
        public static ImageZoom ImageZoom { get; set; }
        public static ImageResize ImageResize { get; set; }
    }
}
