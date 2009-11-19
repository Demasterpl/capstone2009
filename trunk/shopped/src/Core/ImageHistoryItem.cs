using Core.Images;

namespace Core
{
    /**
     * A simple class that contains an ShoppedImage object and a string that details the operation performed.
     * 
     * @param Image A ShoppedImage object to store in history.
     * @param OperationPerformed A string that describes the actions performed on the ShoppedImage.
     */
    public class ImageHistoryItem
    {
        public ShoppedImage Image { get; set; }
        public string OperationPerformed { get; set; }

        /**
         * Default Constructor.
         */
        public ImageHistoryItem()
        { }

        /**
         * Constructor that has properties of ImageHistoryItem passed in.
         * 
         * @param image A ShoppedImage object.
         * @param operation A string that describes the actions performed on the ShoppedImage.
         */
        public ImageHistoryItem(ShoppedImage image, string operation)
        {
            Image = image;
            OperationPerformed = operation;
        }
    }
}
