﻿using NUnit.Framework;
using Core.Images;

namespace Tests
{
    [TestFixture]
    public class PictureBoxImageTester
    {
        [Test]
        public void CanCreate()
        {
            new PictureBoxImage();
        }

        [Test]
        public void CanSetPictureBoxImageProperties()
        {
            const int HEIGHT = 5;
            const int WIDTH = 10;
            const float ZOOM = 5.0f;
            const float ROTATE = 75.0f;
            const float RESIZE = .56f;


            PictureBoxImage image = new PictureBoxImage
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