using System.Linq;
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
            ShoppedImage shoppedImage = new ShoppedImage();

            _imageHistory.AddImageToImageHistory(shoppedImage, "Testing Image");

            Assert.AreEqual(1, _imageHistory.ImageRevisions.Count());
        }

        [Test]
        public void DescriptionGivenToImageHistoryItemIsSetProperly()
        {
            const string message = "Testing Image";
            ShoppedImage shoppedImage = new ShoppedImage();

            _imageHistory.AddImageToImageHistory(shoppedImage, message);

            Assert.AreEqual(message, _imageHistory.ImageRevisions.First().OperationPerformed);
        }

        [Test]
        public void ImageAddedToImageHistoryIsIdenticalToshoppedImage()
        {
            int currentHeight = 800;
            int currentWidth = 600;
            Image image = new Bitmap(currentWidth, currentHeight);
            float zoomLevel = 1.0f;
            float resizelevel = 1.0f;


            ShoppedImage shoppedImage = new ShoppedImage
            {
                CurrentImage = image,
                CurrentHeight = currentHeight,
                CurrentWidth = currentWidth,
                ZoomLevel = zoomLevel,
                ResizeLevel = resizelevel,
            };

            _imageHistory.AddImageToImageHistory(shoppedImage, "Testing Image");

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


            ShoppedImage shoppedImage = new ShoppedImage
            {
                CurrentImage = image,
                CurrentHeight = currentHeight,
                CurrentWidth = currentWidth,
                ZoomLevel = zoomLevel,
                ResizeLevel = resizelevel,
            };

            _imageHistory.AddImageToImageHistory(shoppedImage, "Testing Image");
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Dummy Image so I can Undo");
            ShoppedImage undoImage = _imageHistory.Undo();

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


            ShoppedImage shoppedImage = new ShoppedImage
            {
                CurrentImage = image,
                CurrentHeight = currentHeight,
                CurrentWidth = currentWidth,
                ZoomLevel = zoomLevel,
                ResizeLevel = resizelevel,
            };

            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Dummy image so I can undo/redo");
            _imageHistory.AddImageToImageHistory(shoppedImage, "Image we're testing");
            _imageHistory.Undo();
            ShoppedImage redoImage = _imageHistory.Redo();

            Assert.AreEqual(currentHeight, redoImage.CurrentHeight);
            Assert.AreEqual(currentWidth, redoImage.CurrentWidth);
            Assert.AreEqual(image, redoImage.CurrentImage);
            Assert.AreEqual(zoomLevel, redoImage.ZoomLevel);
            Assert.AreEqual(resizelevel, redoImage.ResizeLevel);
        }

        [Test]
        public void GetCurrentRevisionIsNegativeOneOnEmptyImageHistory()
        {
            Assert.AreEqual(-1, _imageHistory.GetCurrentRevision());
        }

        [Test]
        public void GetCurrentRevisionIsZeroAtFirstImageAdded()
        {
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Only one image here");

            Assert.AreEqual(0, _imageHistory.GetCurrentRevision());
        }

        [Test]
        public void GetCurrentRevisionIsZeroAfterUndoThenRedo()
        {
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Only one image here");
            _imageHistory.Undo();
            _imageHistory.Redo();

            Assert.AreEqual(0, _imageHistory.GetCurrentRevision());
        }

        [Test]
        public void UndoIsNotPossibleOnEmptyImageHistory()
        {
            bool isPossible = _imageHistory.UndoIsPossible();

            Assert.AreEqual(false, isPossible);
        }

        [Test]
        public void UndoIsPossibleOnImageHistoryWithTwoImagesInHistory()
        {
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Dummy image so I can undo/redo");
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Only one image here");
            bool isPossible = _imageHistory.UndoIsPossible();

            Assert.AreEqual(true, isPossible);
        }

        [Test]
        public void UndoIsNotPossibleOnImageHistoryWhenIteratorAtLowerBound()
        {
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Only one image here");
            _imageHistory.Undo();
            bool isPossible = _imageHistory.UndoIsPossible();

            Assert.AreEqual(false, isPossible);
        }

        [Test]
        public void RedoIsNotPossibleOnEmptyImageHistory()
        {
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Only one image here");
            bool isPossible = _imageHistory.RedoIsPossible();

            Assert.AreEqual(false, isPossible);
        }

        [Test]
        public void RedoIsPossibleOnImageHistoryWhenIteratorIsBeforeLastImageInHistory()
        {
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Dummy image so I can undo/redo");
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Only one image here");
            _imageHistory.Undo();

            bool isPossible = _imageHistory.RedoIsPossible();

            Assert.AreEqual(true, isPossible);
        }

        [Test]
        public void RedoIsNotPossibleOnImageHistoryWhenIteratorAtRightBound()
        {
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Only one image here");

            bool isPossible = _imageHistory.RedoIsPossible();

            Assert.AreEqual(false, isPossible);
        }

        [Test]
        public void OperationPerformedOnMiddleOfImageHistoryListRemovesImagesAfter()
        {
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "First Image");
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Second Image");
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Third Image");

            _imageHistory.Undo();
            _imageHistory.Undo();
            _imageHistory.AddImageToImageHistory(new ShoppedImage(), "Middle operation");

            Assert.AreEqual(1, _imageHistory.GetCurrentRevision());
            Assert.AreEqual(2, _imageHistory.GetNumberOfImagesInHistory());

        }
    }
}
