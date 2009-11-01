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
        public void DescriptionGivenToImageHistoryItemIsSetProperly()
        {
            const string message = "Testing Image";
            var pictureBoxImage = new PictureBoxImage();

            _imageHistory.AddImageToImageHistory(pictureBoxImage, message);

            Assert.AreEqual(message, _imageHistory.ImageRevisions.First().OperationPerformed);
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


        [Test]
        public void ImageReturnedByImageHistoryUndoIsIdenticalToOriginal()
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
            var undoImage = _imageHistory.Undo();

            Assert.AreEqual(currentHeight, undoImage.CurrentHeight);
            Assert.AreEqual(currentWidth, undoImage.CurrentWidth);
            Assert.AreEqual(image, undoImage.CurrentImage);
            Assert.AreEqual(zoomLevel, undoImage.ZoomLevel);
            Assert.AreEqual(resizelevel, undoImage.ResizeLevel);
        }

        [Test]
        public void ImageReturnedByImageHistoryUndoThenRedoIsIdenticalToCurrent()
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

            _imageHistory.AddImageToImageHistory(pictureBoxImage, "Image we're testing");
            _imageHistory.Undo();
            var redoImage = _imageHistory.Redo();

            Assert.AreEqual(currentHeight, redoImage.CurrentHeight);
            Assert.AreEqual(currentWidth, redoImage.CurrentWidth);
            Assert.AreEqual(image, redoImage.CurrentImage);
            Assert.AreEqual(zoomLevel, redoImage.ZoomLevel);
            Assert.AreEqual(resizelevel, redoImage.ResizeLevel);
        }

        [Test]
        public void GetCurrentRevisionIsNegativeOneOnEmptyImageHistory()
        {
            Assert.AreEqual(0, _imageHistory.GetCurrentRevision());
        }

        [Test]
        public void GetCurrentRevisionIsZeroAtFirstImageAdded()
        {
            _imageHistory.AddImageToImageHistory(new PictureBoxImage(), "Only one image here");

            Assert.AreEqual(1, _imageHistory.GetCurrentRevision());
        }

        [Test]
        public void GetCurrentRevisionIsZeroAfterUndoThenRedo()
        {
            _imageHistory.AddImageToImageHistory(new PictureBoxImage(), "Only one image here");
            _imageHistory.Undo();
            _imageHistory.Redo();

            Assert.AreEqual(0, _imageHistory.GetCurrentRevision());
        }

        [Test]
        public void UndoIsNotPossibleOnEmptyImageHistory()
        {
            var isPossible = _imageHistory.UndoIsPossible();

            Assert.AreEqual(false, isPossible);
        }

        [Test]
        public void UndoIsPossibleOnImageHistoryWithOneImage()
        {
            _imageHistory.AddImageToImageHistory(new PictureBoxImage(), "Only one image here");
            var isPossible = _imageHistory.UndoIsPossible();

            Assert.AreEqual(true, isPossible);
        }

        [Test]
        public void UndoIsNotPossibleOnImageHistoryWhenIteratorAtLowerBound()
        {
            _imageHistory.AddImageToImageHistory(new PictureBoxImage(), "Only one image here");
            _imageHistory.Undo();
            var isPossible = _imageHistory.UndoIsPossible();

            Assert.AreEqual(false, isPossible);
        }

        [Test]
        public void RedoIsNotPossibleOnEmptyImageHistory()
        {
            _imageHistory.AddImageToImageHistory(new PictureBoxImage(), "Only one image here");
            var isPossible = _imageHistory.RedoIsPossible();

            Assert.AreEqual(false, isPossible);
        }

        [Test]
        public void RedoIsPossibleOnImageHistoryWithOneImageAndIteratorIsBeforeIt()
        {
            _imageHistory.AddImageToImageHistory(new PictureBoxImage(), "Only one image here");
            _imageHistory.Undo();

            var isPossible = _imageHistory.RedoIsPossible();

            Assert.AreEqual(true, isPossible);
        }

        [Test]
        public void RedoIsNotPossibleOnImageHistoryWhenIteratorAtRightBound()
        {
            _imageHistory.AddImageToImageHistory(new PictureBoxImage(), "Only one image here");

            var isPossible = _imageHistory.RedoIsPossible();

            Assert.AreEqual(false, isPossible);
        }
    }
}
