using System;
using System.Drawing;
using System.Windows.Forms;
using Core.Images;

namespace Core
{
    /**
     * Handles the opening and saving of images from file.
     */
    public class FileOperations
    {
        /**  
         * Opens a file dialog to select an image, then opens the file inside the Shopped main GUI.
         *  
         * @return A shoppedImage object with the opened image inside it.
         */
        public ShoppedImage OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
             {
                 InitialDirectory = "c:\\"
             };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var openedImage = new Bitmap(openFileDialog.OpenFile());
                    ShoppedImage shoppedImage = new ShoppedImage(System.IO.Path.GetFileName(openFileDialog.FileName), openedImage.Height, openedImage.Width, openedImage);
                    return shoppedImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    return null;
                }
            }

            return null;
        }

        /**  
         * Opens a save file dialog to save the image that is open in the Shopped main GUI.
         *  
         * @param shoppedImage The shoppedImage object in the current context of Shopped GUI that we will save.
         */
        public void SaveFile(ShoppedImage shoppedImage)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
             {
                 FileName = shoppedImage.FileName,
                 Filter = "JPEG (*.jpeg)|*.jpeg| Bitmap (*.bmp)|*.bmp"
             };
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Image to save is JPEG
                if(saveFileDialog.FilterIndex == 1)
                {
                    try
                    {
                        shoppedImage.CurrentImage.Save(saveFileDialog.FileName);
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
                        shoppedImage.CurrentImage.Save(saveFileDialog.FileName);
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