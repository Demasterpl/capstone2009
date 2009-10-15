using System;
using System.Drawing;
using System.Windows.Forms;
using Core.Interfaces;

namespace Core
{
    public class FileOperations : IFileOperations
    {
        /**  
         *  Opens a file dialog to select an image, then opens the file inside the Shopped main GUI.
         */
        public string OpenFile()
        {
            var openFileDialog = new OpenFileDialog
             {
                 InitialDirectory = "c:\\"
             };


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ShoppedGuiHelper.CurrentImage.CurrentImage = new Bitmap(openFileDialog.OpenFile());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }

            return openFileDialog.FileName;
        }

        /**  
         *  Opens a save file dialog to save the image that is open in the Shopped main GUI.
         */
        public void SaveFile()
        {
            var saveFileDialog = new SaveFileDialog
             {
                 FileName = ShoppedGuiHelper.CurrentFileName,
                 Filter = "JPEG (*.jpeg)|*.jpeg| Bitmap (*.bmp)|*.bmp"
             };
            

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Image to save is JPEG
                if(saveFileDialog.FilterIndex == 1)
                {
                    try
                    {
                        ShoppedGuiHelper.CurrentImage.CurrentImage.Save(saveFileDialog.FileName);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.ToString());
                    }
                } 
                
                //Image to save is Bitmap
                if (saveFileDialog.FilterIndex == 2)
                {
                    try
                    {
                        ShoppedGuiHelper.CurrentImage.CurrentImage.Save(saveFileDialog.FileName);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.ToString());
                    }
                }
            }
        }
    }
}