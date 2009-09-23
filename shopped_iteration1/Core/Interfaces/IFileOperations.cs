using System.Windows.Forms;

namespace Core.Interfaces
{
    public interface IFileOperations
    {
        string OpenFile(PictureBox pictureBox);
        void SaveFile(PictureBox pictureBox, string fileCurrentlyOpen);
    }
}