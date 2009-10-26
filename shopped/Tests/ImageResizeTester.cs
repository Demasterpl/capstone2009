using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Core;
using Core.Images;
using System.Drawing;

namespace Tests
{
    [TestFixture]
    class ImageResizeTester
    {
        [Test]
        public void ResizingImageBy200PercentDoublesSizeOfPicture()
        {
            const float RESIZELEVEL = 2.0f;
            var image = new Bitmap(800, 600);

            var imageResize = new ImageResize();
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

            pictureBoxImage = imageResize.ResizeImage(pictureBoxImage, RESIZELEVEL);

            Assert.AreEqual(image.Height * 2.0, pictureBoxImage.CurrentHeight);
            Assert.AreEqual(image.Width * 2.0, pictureBoxImage.CurrentWidth);
            Assert.AreEqual(image.Height * 2.0, pictureBoxImage.UnzoomedHeight);
            Assert.AreEqual(image.Width * 2.0, pictureBoxImage.UnzoomedWidth);
            Assert.AreEqual(1.0f, pictureBoxImage.ZoomLevel);
            Assert.AreEqual(RESIZELEVEL, pictureBoxImage.ResizeLevel);
            Assert.AreEqual(0.0f, pictureBoxImage.DegreesRotated);
        }

        [Test]
        public void UnzoomedImageHasSamePropertiesAsCurrentImageAfterResize()
        {
            const float RESIZELEVEL = 2.0f;
            var image = new Bitmap(800, 600);

            var imageResize = new ImageResize();
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

            pictureBoxImage = imageResize.ResizeImage(pictureBoxImage, RESIZELEVEL);

            Assert.AreEqual(pictureBoxImage.CurrentHeight, pictureBoxImage.UnzoomedHeight);
            Assert.AreEqual(pictureBoxImage.CurrentWidth, pictureBoxImage.UnzoomedWidth);
            Assert.AreEqual(pictureBoxImage.CurrentImage.Height, pictureBoxImage.UnzoomedImage.Height);
            Assert.AreEqual(pictureBoxImage.CurrentImage.Width, pictureBoxImage.UnzoomedImage.Width);
        }
    }
}
