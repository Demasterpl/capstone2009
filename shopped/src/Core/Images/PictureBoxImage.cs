﻿using System.Drawing;

namespace Core.Images
{
    /**
     * Holds the current state of the image in the Shopped GUI. Anytime the loaded image is modified
     * (i.e. rotated, resized, etc.), this object gets updated to reflect the modification.
     * 
     * @param FileName Contains the name of the opened image file
     * @param CurrentHeight Contains the height of the loaded image.
     * @param CurrentWidth Contains the width of the loaded image.
     * @param DegreesRotated Contains how many degrees the image is currently rotated.
     * @param CurrentImage Image object that holds the actual Image object.
     */

    public class PictureBoxImage
    {
        public string FileName { get; set; }
        public int CurrentHeight { get; set; }
        public int CurrentWidth { get; set; }
        public float DegreesRotated { get; set; }
        public float ZoomLevel { get; set; }
        public float ResizeLevel { get; set; }
        public int BrightnessLevel { get; set; }
        public Image CurrentImage { get; set; }

        public PictureBoxImage() { }

        public PictureBoxImage(string fileName, int height, int width, Image image)
        {
            FileName = fileName;
            CurrentHeight = height;
            CurrentWidth = width;
            DegreesRotated = 0.0f;
            ZoomLevel = ResizeLevel = 1.0f;
            CurrentImage = image;
        }

        public PictureBoxImage(PictureBoxImage original)
        {
                CurrentHeight = original.CurrentHeight;
                CurrentImage = original.CurrentImage;
                CurrentWidth = original.CurrentWidth;
                DegreesRotated = original.DegreesRotated;
                FileName = original.FileName;
                ResizeLevel = original.ResizeLevel;
                ZoomLevel = original.ZoomLevel;
        }

        public override string ToString()
        {
            return string.Format("Height = {0} | Width = {1} | Rotate = {2} | Zoom = {3} | Resize = {4}"
                , CurrentHeight, CurrentWidth, DegreesRotated, ZoomLevel, ResizeLevel);
        }
    }
}