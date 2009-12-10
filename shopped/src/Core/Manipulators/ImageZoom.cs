using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using Core.Images;

namespace Core.Manipulators
{
    /**
     * Handles the zooming in and out of an image.
     */
    public class ImageZoom
    {
        public Point initialPoint;
        public Point destinationPoint;

        public ImageZoom()
        {
            initialPoint = new Point();
            destinationPoint = new Point();
        }

        /**
         * Zooms the image in the Shopped GUI to the specified zoom level.
         * 
         * @param zoom The amount of zoom to use on the image (1.0f == 100%).
         * @param image The image to be zoomed.
         * @return The zoomed Image object.
         */
        public Image ZoomImage(Image image, float zoom)
        {
            image = new Bitmap(image,
                (int)(image.Width * zoom),
                (int)(image.Height * zoom));

            return image;

        }

        public ShoppedImage ZoomImage2x(ShoppedImage shoppedImage)
        {
            var newShoppedImage = new ShoppedImage(shoppedImage);

            newShoppedImage.CurrentImage = new Bitmap(shoppedImage.CurrentImage.Width * 2, shoppedImage.CurrentImage.Height * 2);

            for (int origX = 0, zoomX = 0; origX < shoppedImage.CurrentImage.Width; ++origX, zoomX += 2)
            {
                for (int origY = 0, zoomY = 0; origY < shoppedImage.CurrentImage.Height; ++origY, zoomY += 2)
                {
                    var color = (shoppedImage.CurrentImage as Bitmap).GetPixel(origX, origY);
                    (newShoppedImage.CurrentImage as Bitmap).SetPixel(zoomX, zoomY, color);
                    (newShoppedImage.CurrentImage as Bitmap).SetPixel(zoomX + 1, zoomY, color);
                    (newShoppedImage.CurrentImage as Bitmap).SetPixel(zoomX, zoomY + 1, color);
                    (newShoppedImage.CurrentImage as Bitmap).SetPixel(zoomX + 1, zoomY + 1, color);
                }
            }

            newShoppedImage.CurrentHeight = newShoppedImage.CurrentImage.Height;
            newShoppedImage.CurrentWidth = newShoppedImage.CurrentImage.Width;

            return newShoppedImage;
        }

        public ShoppedImage ZoomImageSelection2x(ShoppedImage shoppedImage)
        {
            var selectionHeight = GetSelectionHeight();
            var selectionWidth = GetSelectionWidth();
            var leftX = initialPoint.X < destinationPoint.X ? initialPoint.X : destinationPoint.X;
            var topY = initialPoint.Y < destinationPoint.Y ? initialPoint.Y : destinationPoint.Y;

            var selectedImage = new Bitmap(selectionWidth, selectionHeight);

            for (int x = 0; x < selectionWidth; ++x)
            {
                for (int y = 0; y < selectionHeight; ++y)
                {
                    selectedImage.SetPixel(x, y, (shoppedImage.CurrentImage as Bitmap).GetPixel(x + leftX, y + topY));
                }
            }
            
            var newShoppedImage = new ShoppedImage(shoppedImage);

            newShoppedImage.CurrentImage = new Bitmap(selectedImage);

            return ZoomImage2x(newShoppedImage);
        }

        private int GetSelectionWidth()
        {
            var leftX = initialPoint.X < destinationPoint.X ? initialPoint.X : destinationPoint.X;
            var rightX = initialPoint.X > destinationPoint.X ? initialPoint.X : destinationPoint.X;

            return rightX - leftX;
        }

        private int GetSelectionHeight()
        {
            var topY = initialPoint.Y < destinationPoint.Y ? initialPoint.Y : destinationPoint.Y;
            var bottomY = initialPoint.Y > destinationPoint.Y ? initialPoint.Y : destinationPoint.Y;

            return bottomY - topY;
        }

        public void SetInitialPoint(int x, int y)
        {
            initialPoint.X = x;
            initialPoint.Y = y;
        }

        public void SetDestinationPoint(int x, int y)
        {
            destinationPoint.X = x;
            destinationPoint.Y = y;
        }


    }
}
