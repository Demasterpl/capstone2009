using NUnit.Framework;
using Core;
using Core.Images;
using System.Drawing;

namespace Tests
{
    [TestFixture]
    public class ImageRotateTester
    {
        [Test]
        public void RotateImageSetsPictureBoxImagePropertiesToNewRotatedValues()
        {
            const float ROTATEDEG = 90.0f;
            var image = new Bitmap(800, 600);

            var imageRotate = new ImageRotate();
            var pictureBoxImage = new PictureBoxImage 
            {
                CurrentHeight = image.Height,
                CurrentWidth = image.Width, 
                DegreesRotated = 0.0f, 
                ResizeLevel = 1.0f,
                UnzoomedHeight = image.Height,
                UnzoomedWidth = image.Width, 
                ZoomLevel = 1.0f,
                CurrentImage = image,
                UnzoomedImage = image,
            };

            pictureBoxImage = imageRotate.RotateImageByAngle(pictureBoxImage, ROTATEDEG);

            Assert.AreEqual(image.Width, pictureBoxImage.CurrentHeight);
            Assert.AreEqual(image.Height, pictureBoxImage.CurrentWidth);
            Assert.AreEqual(image.Width, pictureBoxImage.UnzoomedHeight);
            Assert.AreEqual(image.Height, pictureBoxImage.UnzoomedWidth);
            Assert.AreEqual(1.0f, pictureBoxImage.ZoomLevel);
            Assert.AreEqual(1.0f, pictureBoxImage.ResizeLevel);
            Assert.AreEqual(ROTATEDEG, pictureBoxImage.DegreesRotated);
        }
    }
}
