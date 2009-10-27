using System.Windows.Forms;
using System.Drawing;
using Core.Images;

namespace Core.Interfaces
{
    /**
     * IFileOperations is an interface to the FileOperations class. 
     * The interface contains two methods, OpenFile and SaveFile.
     * 
     */
    public interface IFileOperations
    {
        PictureBoxImage OpenFile(PictureBoxImage pictureBoxImage);
        void SaveFile(PictureBoxImage pictureBoxImage);
    }
}