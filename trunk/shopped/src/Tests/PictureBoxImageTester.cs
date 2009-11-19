using NUnit.Framework;
using Core.Images;

namespace Tests
{
    [TestFixture]
    public class shoppedImageTester
    {
        [Test]
        public void CanCreate()
        {
            new ShoppedImage();
        }

        [Test]
        public void CanSetshoppedImageProperties()
        {
            const int HEIGHT = 5;
            const int WIDTH = 10;
            const float ZOOM = 5.0f;
            const float ROTATE = 75.0f;
            const float RESIZE = .56f;


            ShoppedImage image = new ShoppedImage
            {
                CurrentHeight = HEIGHT,
                CurrentWidth = WIDTH,
                ResizeLevel = RESIZE,
                ZoomLevel = ZOOM,
                DegreesRotated = ROTATE,
            };

            Assert.AreEqual(HEIGHT, image.CurrentHeight);
            Assert.AreEqual(WIDTH, image.CurrentWidth);
            Assert.AreEqual(RESIZE, image.ResizeLevel);
            Assert.AreEqual(ZOOM, image.ZoomLevel);
            Assert.AreEqual(ROTATE, image.DegreesRotated);
        }
    }
}
