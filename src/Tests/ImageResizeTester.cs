using NUnit.Framework;
using Core.Images;
using System.Drawing;
using Core.Manipulators;

namespace Tests
{
    [TestFixture]
    class ImageResizeTester
    {
        [Test]
        public void ResizingImageBy200PercentDoublesSizeOfPicture()
        {
            const float RESIZELEVEL = 2.0f;
            Bitmap image = new Bitmap(800, 600);

            ImageResize imageResize = new ImageResize();
            PictureBoxImage pictureBoxImage = new PictureBoxImage
            {
                CurrentHeight = image.Height,
                CurrentWidth = image.Width,
                DegreesRotated = 0.0f,
                ResizeLevel = 1.0f,
                ZoomLevel = 1.0f,
                CurrentImage = image,
            };

            pictureBoxImage = imageResize.ResizeImage(pictureBoxImage, RESIZELEVEL);

            Assert.AreEqual(image.Height * 2.0, pictureBoxImage.CurrentHeight);
            Assert.AreEqual(image.Width * 2.0, pictureBoxImage.CurrentWidth);
            Assert.AreEqual(1.0f, pictureBoxImage.ZoomLevel);
            Assert.AreEqual(RESIZELEVEL, pictureBoxImage.ResizeLevel);
            Assert.AreEqual(0.0f, pictureBoxImage.DegreesRotated);
        }
    }
}
