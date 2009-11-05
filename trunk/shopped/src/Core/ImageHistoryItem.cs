using Core.Images;

namespace Core
{
    /**
     * A simple class that contains an Image object and a string that details the operation performed.
     */

    public class ImageHistoryItem
    {
        public PictureBoxImage Image { get; set; }
        public string OperationPerformed { get; set; }

        public ImageHistoryItem()
        { }

        public ImageHistoryItem(PictureBoxImage image, string operation)
        {
            Image = image;
            OperationPerformed = operation;
        }
    }
}
