using System;
using System.Drawing;
using System.Windows.Forms;
using Core.Interfaces;

namespace Core
{
    public class FileOperations : IFileOperations
    {


        public string OpenFile(PictureBox pictureBox)
        {
            var openFileDialog = new OpenFileDialog
             {
                 InitialDirectory = "c:\\"
             };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox.Image = new Bitmap(openFileDialog.OpenFile());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }

            return openFileDialog.FileName;
        }

        public void SaveFile(PictureBox pictureBox, string fileCurrentlyOpen)
        {
            var saveFileDialog = new SaveFileDialog
             {
                 FileName = fileCurrentlyOpen
             };
            

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox.Image.Save(saveFileDialog.FileName);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
            }
        }
    }
}