using NUnit.Framework;
using Core.Images;
using System.Drawing;
using Core.Manipulators;

namespace Tests
{
    [TestFixture]
    public class ImageRotateTester
    {
        [Test]
        public void RotateImageSetsshoppedImagePropertiesToNewRotatedValues()
        {
            const float ROTATEDEG = 90.0f;
            Bitmap image = new Bitmap(800, 600);

            ImageRotate imageRotate = new ImageRotate();
            ShoppedImage shoppedImage = new ShoppedImage 
            {
                CurrentHeight = image.Height,
                CurrentWidth = image.Width, 
                DegreesRotated = 0.0f, 
                ResizeLevel = 1.0f,
                ZoomLevel = 1.0f,
                CurrentImage = image,
            };

            shoppedImage = imageRotate.RotateImageByAngle(shoppedImage, ROTATEDEG);

            Assert.AreEqual(image.Width, shoppedImage.CurrentHeight);
            Assert.AreEqual(image.Height, shoppedImage.CurrentWidth);
            Assert.AreEqual(1.0f, shoppedImage.ZoomLevel);
            Assert.AreEqual(1.0f, shoppedImage.ResizeLevel);
            Assert.AreEqual(ROTATEDEG, shoppedImage.DegreesRotated);
        }
    }
}
