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
            CurrentRevision = -1;
        }

        /**
         * Appends the Image object and string passed in to the end of the ImageRevisions list.
         * @param image The image to add to the list
         * @param operation A string detailing what operation was just performed
         */
        public void AddImageToImageHistory(PictureBoxImage image, string operation)
        {
            //CurrentRevision is somewhere in middle of list, need to delete items beyond current image
            if (RedoIsPossible())
            {
                ImageRevisions = ImageRevisions.Take(CurrentRevision + 1).ToList();
            }

            ImageRevisions.Add(new ImageHistoryItem(image, operation));

            CurrentRevision += 1;
            _logger.Debug("Adding image to history: " + image.ToString() + ", CurRev = " + CurrentRevision + "HistSize = " + ImageRevisions.Count());
        }

        /**
         * Attempts an undo operation by checking if an object exists before the CurrentRevision iterator, then returning that
         * ImageHistoryItem node if it does exist.
         */
        public PictureBoxImage Undo()
        {
            if (UndoIsPossible())
            {
                CurrentRevision -= 1;
                _logger.Debug("Performing undo: " + ImageRevisions[CurrentRevision].Image.ToString() 
                    + ", CurRev = " + CurrentRevision + "HistSize = " + ImageRevisions.Count());
                return ImageRevisions[CurrentRevision].Image;
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
                CurrentRevision += 1;
                _logger.Debug("Performing redo: " + ImageRevisions[CurrentRevision].Image.ToString() 
                    + ", CurRev = " + CurrentRevision + "HistSize = " + ImageRevisions.Count());
                return ImageRevisions[CurrentRevision].Image;
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
            return GetCurrentRevision() > -1 && GetCurrentRevision() < GetNumberOfImagesInHistory() - 1 && GetNumberOfImagesInHistory() > 1;
        }

        /**
         * Returns whether or not there exists an image to undo to in the history.
         * 
         * @return bool Whether or not ImageHistory can perform a undo.
         */
        public bool UndoIsPossible()
        {
            return GetCurrentRevision() > 0 && GetNumberOfImagesInHistory() > 0;
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
                return ImageRevisions[CurrentRevision + 1].OperationPerformed;
            }

            return null;
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
                return ImageRevisions[CurrentRevision - 1].OperationPerformed;
            }

            return null;
        }
    }
}
