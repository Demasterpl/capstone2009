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
        public void RotateImageSetsPictureBoxImagePropertiesToNewRotatedValues()
        {
            const float ROTATEDEG = 90.0f;
            Bitmap image = new Bitmap(800, 600);

            ImageRotate imageRotate = new ImageRotate();
            PictureBoxImage pictureBoxImage = new PictureBoxImage 
            {
                CurrentHeight = image.Height,
                CurrentWidth = image.Width, 
                DegreesRotated = 0.0f, 
                ResizeLevel = 1.0f,
                ZoomLevel = 1.0f,
                CurrentImage = image,
            };

            pictureBoxImage = imageRotate.RotateImageByAngle(pictureBoxImage, ROTATEDEG);

            Assert.AreEqual(image.Width, pictureBoxImage.CurrentHeight);
            Assert.AreEqual(image.Height, pictureBoxImage.CurrentWidth);
            Assert.AreEqual(1.0f, pictureBoxImage.ZoomLevel);
            Assert.AreEqual(1.0f, pictureBoxImage.ResizeLevel);
            Assert.AreEqual(ROTATEDEG, pictureBoxImage.DegreesRotated);
        }
    }
}
