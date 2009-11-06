using System;
using System.Drawing;
using System.Windows.Forms;
using Core.Interfaces;
using Core.Images;

namespace Core
{
    public class FileOperations : IFileOperations
    {
        /**  
         *  Opens a file dialog to select an image, then opens the file inside the Shopped main GUI.
         *  
         * @param pictureBoxImage The PictureBoxImage object in the current context of Shopped GUI
         * @return A PictureBoxImage object with the appropriate properties set by this method.
         */

        public PictureBoxImage OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
             {
                 InitialDirectory = "c:\\"
             };


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image openedImage = new Bitmap(openFileDialog.OpenFile());
                    PictureBoxImage pictureBoxImage = new PictureBoxImage(System.IO.Path.GetFileName(openFileDialog.FileName), openedImage.Height, openedImage.Width, openedImage);            
                    return pictureBoxImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
            return null;
        }

        /**  
         *  Opens a save file dialog to save the image that is open in the Shopped main GUI.
         *  
         * @param pictureBoxImage The PictureBoxImage object in the current context of Shopped GUI
         */

        public void SaveFile(PictureBoxImage pictureBoxImage)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
             {
                 FileName = pictureBoxImage.FileName,
                 Filter = "JPEG (*.jpeg)|*.jpeg| Bitmap (*.bmp)|*.bmp"
             };
            

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Image to save is JPEG
                if(saveFileDialog.FilterIndex == 1)
                {
                    try
                    {
                        pictureBoxImage.CurrentImage.Save(saveFileDialog.FileName);
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
                        pictureBoxImage.CurrentImage.Save(saveFileDialog.FileName);
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