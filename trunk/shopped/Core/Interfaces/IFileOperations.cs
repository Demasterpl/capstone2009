using System.Windows.Forms;
using System.Drawing;

namespace Core.Interfaces
{
    /**
     * IFileOperations is an interface to the FileOperations class. 
     * The interface contains two methods, OpenFile and SaveFile.
     * 
     */
    public interface IFileOperations
    {
        string OpenFile();
        void SaveFile();
    }
}