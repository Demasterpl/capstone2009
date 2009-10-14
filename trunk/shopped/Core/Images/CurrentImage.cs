using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Images
{
    /**
     * Holds the current state of the image in the Shopped GUI. Anytime the loaded image is modified
     * (i.e. rotated, resized, etc.), this object gets updated to reflect the modification.
     * 
     * @param CurrentHeight Contains the height of the loaded image.
     * @param CurrentWidth Contains the width of the loaded image.
     * @param DegreesRotated Contains how many degrees the image is currently rotated.
     * @param InitialImage Image object that holds the actual Image object.
     */
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

        /**
         * Sets the CurrentImage object with the values of the parameter.
         * @param image The image to set CurrentImage to.
         */
        public void SetCurrentImage()
        {
            ShoppedGuiHelper.CurrentImage.CurrentHeight = ShoppedGuiHelper.TempImage.Height;
            ShoppedGuiHelper.CurrentImage.CurrentWidth = ShoppedGuiHelper.TempImage.Width;
            ShoppedGuiHelper.CurrentImage.DegreesRotated = ShoppedGuiHelper.DegreesRotated;
            ShoppedGuiHelper.CurrentImage.InitialImage = ShoppedGuiHelper.TempImage;
        }
    }
}
