﻿using NUnit.Framework;

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
        //    PictureBoxImage pictureBoxImage = new PictureBoxImage
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

        //    pictureBoxImage = imageZoom.ZoomImage(pictureBoxImage, ZOOMLEVEL);

        //    Assert.AreEqual(image.Height * 2.0, pictureBoxImage.CurrentHeight);
        //    Assert.AreEqual(image.Width * 2.0, pictureBoxImage.CurrentWidth);
        //    Assert.AreEqual(image.Height, pictureBoxImage.UnzoomedHeight);
        //    Assert.AreEqual(image.Width, pictureBoxImage.UnzoomedWidth);
        //    Assert.AreEqual(ZOOMLEVEL, pictureBoxImage.ZoomLevel);
        //    Assert.AreEqual(1.0f, pictureBoxImage.ResizeLevel);
        //    Assert.AreEqual(0.0f, pictureBoxImage.DegreesRotated);
        //}

        //[Test]
        //public void UnzoomedImageRetainsOriginalPropertiesAfterZoom()
        //{
        //    const float RESIZELEVEL = 2.0f;
        //    Bitmap image = new Bitmap(800, 600);

        //    ImageZoom imageZoom = new ImageZoom();
        //    PictureBoxImage pictureBoxImage = new PictureBoxImage
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

        //    pictureBoxImage = imageZoom.ZoomImage(pictureBoxImage, RESIZELEVEL);

        //    Assert.AreNotEqual(pictureBoxImage.CurrentHeight, pictureBoxImage.UnzoomedHeight);
        //    Assert.AreNotEqual(pictureBoxImage.CurrentWidth, pictureBoxImage.UnzoomedWidth);
        //    Assert.AreNotEqual(pictureBoxImage.CurrentImage.Height, pictureBoxImage.UnzoomedImage.Height);
        //    Assert.AreNotEqual(pictureBoxImage.CurrentImage.Width, pictureBoxImage.UnzoomedImage.Width);
        //}

    }
}