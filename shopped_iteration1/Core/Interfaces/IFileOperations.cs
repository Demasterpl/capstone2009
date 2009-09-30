using System.Windows.Forms;
using System.Drawing;

namespace Core.Interfaces
{
    public interface IFileOperations
    {
        string OpenFile(ref Image imageToOpen);
        void SaveFile(Image imageToSave, string fileCurrentlyOpen);
    }
}