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
            ShoppedImage shoppedImage = new ShoppedImage
            {
                CurrentHeight = image.Height,
                CurrentWidth = image.Width,
                DegreesRotated = 0.0f,
                ResizeLevel = 1.0f,
                ZoomLevel = 1.0f,
                CurrentImage = image,
            };

            shoppedImage = imageResize.ResizeImage(shoppedImage, RESIZELEVEL);

            Assert.AreEqual(image.Height * 2.0, shoppedImage.CurrentHeight);
            Assert.AreEqual(image.Width * 2.0, shoppedImage.CurrentWidth);
            Assert.AreEqual(1.0f, shoppedImage.ZoomLevel);
            Assert.AreEqual(RESIZELEVEL, shoppedImage.ResizeLevel);
            Assert.AreEqual(0.0f, shoppedImage.DegreesRotated);
        }
    }
}
