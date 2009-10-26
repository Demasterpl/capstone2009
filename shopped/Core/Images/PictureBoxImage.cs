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
     * @param UnzoomedHeight Contains the height of the image in its unzoomed (100%) form.
     * @param UnzoomedWidth Contains the width of the loaded image in its unzoomed (100%) form.
     * @param DegreesRotated Contains how many degrees the image is currently rotated.
     * @param CurrentImage Image object that holds the actual Image object.
     * @param UnzoomedImage Image object that holds the unzoomed version of CurrentImage
     */
    public class PictureBoxImage
    {
        public string FileName { get; set; }
        public int CurrentHeight { get; set; }
        public int CurrentWidth { get; set; }
        public int UnzoomedHeight { get; set; }
        public int UnzoomedWidth { get; set;}
        public float DegreesRotated { get; set; }
        public float ZoomLevel { get; set; }
        public float ResizeLevel { get; set; }
        public Image CurrentImage { get; set; }
        public Image UnzoomedImage { get; set; }

        public PictureBoxImage() { }


        public void InitializeCurrentImage()
        {
            CurrentHeight = UnzoomedHeight = CurrentImage.Height;
            CurrentWidth = UnzoomedWidth = CurrentImage.Width;
            DegreesRotated = 0.0f;

            UnzoomedImage = CurrentImage;
            ZoomLevel = ResizeLevel = 1.0f;
        }
    }
}
