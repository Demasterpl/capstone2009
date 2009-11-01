using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Core.Images;
using NLog;

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
        private static Logger _logger = LogManager.GetCurrentClassLogger(); 

        public ImageHistory()
        {
            ImageRevisions = new List<ImageHistoryItem>();
            CurrentRevision = 0;
        }

        /**
         * Appends the Image object and string passed in to the end of the ImageRevisions list.
         * @param image The image to add to the list
         * @param operation A string detailing what operation was just performed
         */
        public void AddImageToImageHistory(PictureBoxImage image, string operation)
        {
            _logger.Debug("Adding PictureBoxImage to History: " + image.ToString() 
                + ", Cur rev = " + GetCurrentRevision() + ", hist size = " + GetNumberOfImagesInHistory()); 
            ImageRevisions.Add(new ImageHistoryItem { Image = image, OperationPerformed = operation });
            if (CurrentRevision != 0)
            {
                ++CurrentRevision;
            }
        }

        /**
         * Attempts an undo operation by checking if an object exists before the CurrentRevision iterator, then returning that
         * ImageHistoryItem node if it does exist.
         */
        public PictureBoxImage Undo()
        {
            if (UndoIsPossible())
            {
                _logger.Debug("Performing Undo: " + ImageRevisions[CurrentRevision - 1].Image.ToString()
                    + ", Cur rev = " + GetCurrentRevision() + ", hist size = " + GetNumberOfImagesInHistory());
                return ImageRevisions[--CurrentRevision].Image;
            }
            return null;
        }

        /**
         * Attempts a redo operation by checking if an object exists after the CurrentRevision iterator, then returning that
         * ImageHistoryItem node if it does exist.
         */
        public PictureBoxImage Redo()
        {
            if (RedoIsPossible())
            {
                _logger.Debug("Performing Redo: " + ImageRevisions[CurrentRevision + 1].Image.ToString()
                    + ", Cur rev = " + GetCurrentRevision() + ", hist size = " + GetNumberOfImagesInHistory());
                return ImageRevisions[++CurrentRevision].Image;
            }
            return null;
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

        /**
         * Returns whether or not there exists an image to redo in the history.
         * @return bool Whether or not ImageHistory can perform a redo
         */
        public bool RedoIsPossible()
        {
            return GetNumberOfImagesInHistory() > 0 && GetCurrentRevision() != GetNumberOfImagesInHistory();
        }

        /**
         * Returns whether or not there exists an image to undo to in the history.
         * 
         * @return bool Whether or not ImageHistory can perform a undo.
         */
        public bool UndoIsPossible()
        {
            return GetNumberOfImagesInHistory() >= 1 && GetCurrentRevision() >= 0;
        }

        /**
         * Returns the tooltip for the next item in the history.
         * 
         * @return string The tooltip for the next item.
         */
        public string GetRedoToolTip()
        {
            if (RedoIsPossible())
            {
                return ImageRevisions[GetCurrentRevision() + 1].OperationPerformed;
            }
            return string.Empty;
        }

        /**
         * Returns the tooltip for the previous item in the history.
         * 
         * @return string The tooltip for the previous item.
         */
        public string GetUndoToolTip()
        {
            if (UndoIsPossible())
            {
                return ImageRevisions[GetCurrentRevision()].OperationPerformed;
            }
            return string.Empty;
        }
    }
}
