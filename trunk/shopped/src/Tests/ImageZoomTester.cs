using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class ImageZoomTester
    {
        //[Test]
        //public void ZoomingImageBy200PercentDoublesImageSize()
        //{
        //    const float ZOOMLEVEL = 2.0f;
        //    Bitmap image = new Bitmap(800, 600);

        //    ImageZoom imageZoom = new ImageZoom();
        //    shoppedImage shoppedImage = new shoppedImage
        //    {
        //        CurrentHeight = image.Height,
        //        CurrentWidth = image.Width,
        //        DegreesRotated = 0.0f,
        //        ResizeLevel = 1.0f,
        //        UnzoomedHeight = image.Height,
        //        UnzoomedWidth = image.Width,
        //        ZoomLevel = 1.0f,
        //        CurrentImage = image,
        //        UnzoomedImage = image,
        //    };

        //    shoppedImage = imageZoom.ZoomImage(shoppedImage, ZOOMLEVEL);

        //    Assert.AreEqual(image.Height * 2.0, shoppedImage.CurrentHeight);
        //    Assert.AreEqual(image.Width * 2.0, shoppedImage.CurrentWidth);
        //    Assert.AreEqual(image.Height, shoppedImage.UnzoomedHeight);
        //    Assert.AreEqual(image.Width, shoppedImage.UnzoomedWidth);
        //    Assert.AreEqual(ZOOMLEVEL, shoppedImage.ZoomLevel);
        //    Assert.AreEqual(1.0f, shoppedImage.ResizeLevel);
        //    Assert.AreEqual(0.0f, shoppedImage.DegreesRotated);
        //}

        //[Test]
        //public void UnzoomedImageRetainsOriginalPropertiesAfterZoom()
        //{
        //    const float RESIZELEVEL = 2.0f;
        //    Bitmap image = new Bitmap(800, 600);

        //    ImageZoom imageZoom = new ImageZoom();
        //    shoppedImage shoppedImage = new shoppedImage
        //    {
        //        CurrentHeight = image.Height,
        //        CurrentWidth = image.Width,
        //        DegreesRotated = 0.0f,
        //        ResizeLevel = 1.0f,
        //        UnzoomedHeight = image.Height,
        //        UnzoomedWidth = image.Width,
        //        ZoomLevel = 1.0f,
        //        CurrentImage = image,
        //        UnzoomedImage = image,
        //    };

        //    shoppedImage = imageZoom.ZoomImage(shoppedImage, RESIZELEVEL);

        //    Assert.AreNotEqual(shoppedImage.CurrentHeight, shoppedImage.UnzoomedHeight);
        //    Assert.AreNotEqual(shoppedImage.CurrentWidth, shoppedImage.UnzoomedWidth);
        //    Assert.AreNotEqual(shoppedImage.CurrentImage.Height, shoppedImage.UnzoomedImage.Height);
        //    Assert.AreNotEqual(shoppedImage.CurrentImage.Width, shoppedImage.UnzoomedImage.Width);
        //}

    }
}
