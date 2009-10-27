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
    public class ImageHistoryTester
    {
        private ImageHistory _imageHistory;

        [SetUp]
        public void Initialize()
        {
            _imageHistory = new ImageHistory();
        }

        [TearDown]
        public void TearDown()
        {
            _imageHistory = null;
        }

        [Test]
        public void CanCreate()
        {
            new ImageHistory();
        }

        [Test]
        public void ImageHistoryWithNoImagesIsEmpty()
        {
            Assert.AreEqual(0, _imageHistory.ImageRevisions.Count());
        }

        [Test]
        public void CanAddImageToImageHistory()
        {
            var pictureBoxImage = new PictureBoxImage();

            _imageHistory.AddImageToImageHistory(pictureBoxImage, "Testing Image");

            Assert.AreEqual(1, _imageHistory.ImageRevisions.Count());
        }

        [Test]
        public void ImageAddedToImageHistoryIsIdenticalToPictureBoxImage()
        {
            int currentHeight = 800;
            int currentWidth = 600;
            Image image = new Bitmap(currentWidth, currentHeight);
            float zoomLevel = 1.0f;
            float resizelevel = 1.0f;


            var pictureBoxImage = new PictureBoxImage 
                {
                    CurrentImage = image, 
                    CurrentHeight = currentHeight, 
                    CurrentWidth = currentWidth,
                    ZoomLevel = zoomLevel,
                    ResizeLevel = resizelevel,
                };

            _imageHistory.AddImageToImageHistory(pictureBoxImage, "Testing Image");

            Assert.AreEqual(currentHeight, _imageHistory.ImageRevisions.First().Image.CurrentHeight);
            Assert.AreEqual(currentWidth, _imageHistory.ImageRevisions.First().Image.CurrentWidth);
            Assert.AreEqual(image, _imageHistory.ImageRevisions.First().Image.CurrentImage);
            Assert.AreEqual(zoomLevel, _imageHistory.ImageRevisions.First().Image.ZoomLevel);
            Assert.AreEqual(resizelevel, _imageHistory.ImageRevisions.First().Image.ResizeLevel);
        }
    }
}
