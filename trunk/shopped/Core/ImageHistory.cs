using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Core
{
    public class ImageHistory
    {
        public List<Image> ImageRevisions { get; set; }
        private int CurrentRevision;

        public ImageHistory()
        {
            ImageRevisions = new List<Image>();
            CurrentRevision = -1;
        }

        public void AddImageToImageHistory(Image image)
        {
            ImageRevisions.Add(image);
            ++CurrentRevision;
        }

        public Image Undo()
        {
            try
            {
                if (CurrentRevision > 0)
                {
                    --CurrentRevision;
                }

                return ImageRevisions[CurrentRevision];
            }
            catch
            {
                throw new IndexOutOfRangeException(string.Format("ImageHistory index is invalid. CurrentRevision: {0}, Size: {1}", CurrentRevision, ImageRevisions.Count()));
            }

        }

        public Image Redo()
        {
            try
            {
                if (CurrentRevision >= 0 && CurrentRevision < ImageRevisions.Count())
                {
                    ++CurrentRevision;
                }

                return ImageRevisions[CurrentRevision];
            }
            catch
            {
                throw new IndexOutOfRangeException(string.Format("ImageHistory index is invalid. CurrentRevision: {0}, Size: {1}", CurrentRevision, ImageRevisions.Count()));
            }
        }

        public int GetNumberOfImagesInHistory()
        {
            return ImageRevisions.Count();
        }

        public int GetCurrentRevision()
        {
            return CurrentRevision;
        }
    }
}
