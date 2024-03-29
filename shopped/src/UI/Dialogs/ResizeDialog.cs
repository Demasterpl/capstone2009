﻿using System;
using System.Windows.Forms;

namespace UI.Dialogs
{
    /**
     * The ResizeDialog class displays a small dialog box to prompt the user for
     * an amount to resize the image loaded into the editor.
     * 
     * @param ResizeLevel Contains the amount of resize the user specifies.
     */
    public partial class ResizeDialog : Form
    {
        public float ResizeLevel;

        /**
         * A constructor for ResizeDialog
         * 
         * @param zoomLevel The amount of zoom of the current image in Shopped GUI
         */

        public ResizeDialog(float zoomLevel)
        {
            InitializeComponent();

            //Warn user that image will be rezoomed to 100%
            if (zoomLevel != 1.0f)
            {
                ZoomWarningLabel.Visible = true;
            }
            else
            {
                ZoomWarningLabel.Visible = false;
            }
        }

        /**
         * Once the user hits the "Resize Image" button, this grabs the value from the dialog box.
         */
        private void ResizeButton_Click(object sender, EventArgs e)
        {
            try
            {
                ResizeLevel = float.Parse(ResizeTextBox.Text) / 100.0f;
            }
            catch
            {
                MessageBox.Show("Resize level must be positive, greater than 5% and less than 200%");
                DialogResult = DialogResult.Retry;
            }

            if (!IsValidResizeLevel())
            {
                MessageBox.Show("Resize level must be positive, greater than 5% and less than 200%");
                DialogResult = DialogResult.Retry;
            }
        }

        /**
         * Checks if the user's input is within the bounds of allowable resize values.
         */
        private bool IsValidResizeLevel()
        {
            return ResizeLevel > 0.05f && ResizeLevel < 2.0f;
        }
    }
}
