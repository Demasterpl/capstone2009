using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Core
{
    /**
     * Manages the list of ImageHistoryItems (to do undo and redo) as well as carry out the undo and redo operations.
     * 
     * @param ImageRevisions A list of ImageHistoryItem objects (which contain an Image object and a string detailing the operation).
     */
    public class ImageHistory
    {
        public List<ImageHistoryItem> ImageRevisions;
        private int CurrentRevision;

        public ImageHistory()
        {
            ImageRevisions = new List<ImageHistoryItem>();
            CurrentRevision = -1;
        }

        /**
         * Appends the Image object and string passed in to the end of the ImageRevisions list.
         * @param image The image to add to the list
         * @param operation A string detailing what operation was just performed
         */
        public void AddImageToImageHistory(Image image, string operation)
        {
            ImageRevisions.Add(new ImageHistoryItem { Image = image, OperationPerformed = operation });
            ++CurrentRevision;
        }

        /**
         * Attempts an undo operation by checking if an object exists before the CurrentRevision iterator, then returning that
         * ImageHistoryItem node if it does exist.
         */
        public Image Undo()
        {
            try
            {
                if (CurrentRevision > 0)
                {
                    --CurrentRevision;
                }

                return ImageRevisions[CurrentRevision].Image;
            }
            catch
            {
                throw new IndexOutOfRangeException(string.Format("ImageHistory index is invalid. CurrentRevision: {0}, Size: {1}", CurrentRevision, ImageRevisions.Count()));
            }

        }

        /**
         * Attempts a redo operation by checking if an object exists after the CurrentRevision iterator, then returning that
         * ImageHistoryItem node if it does exist.
         */
        public Image Redo()
        {
            try
            {
                if (CurrentRevision >= 0 && CurrentRevision < ImageRevisions.Count())
                {
                    ++CurrentRevision;
                }

                return ImageRevisions[CurrentRevision].Image;
            }
            catch
            {
                throw new IndexOutOfRangeException(string.Format("ImageHistory index is invalid. CurrentRevision: {0}, Size: {1}", CurrentRevision, ImageRevisions.Count()));
            }
        }

        /**
         * Returns the number of ImageHistoryItem objects on the ImageRevisions list.
         * @return ImageRevisions.Count() The current number of items in the list.
         */
        public int GetNumberOfImagesInHistory()
        {
            return ImageRevisions.Count();
        }

        /**
         * Returns the value of the iterator (essentially where we are in the ImageRevisions list).
         * @return CurrentRevision The value of the iterator for the list.
         */
        public int GetCurrentRevision()
        {
            return CurrentRevision;
        }
    }
}
