using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Images;
using System.Drawing;

namespace Core.Manipulators
{
    public class ImageCrop
    {
        public ShoppedImage CropImage(ShoppedImage shoppedImage, SelectionBox selectionBox)
        {
            var selectionHeight = selectionBox.GetSelectionHeight();
            var selectionWidth = selectionBox.GetSelectionWidth();
            var leftX = selectionBox.GetLeftMostX();
            var topY = selectionBox.GetTopMostY();

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
            newShoppedImage.CurrentHeight = selectedImage.Height;
            newShoppedImage.CurrentWidth = selectedImage.Width;

            return newShoppedImage;
        }
    }
}
