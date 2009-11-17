using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core.Manipulators;

namespace UI.Dialogs
{
    /**
     * Performs the actions necessary to grab the drawing info from the 
     * dialog box and set the ImageDraw properties accordingly.
     * 
     * @param ImageDraw A new instance of ImageDraw class that will contain the new values.
     */
    public partial class DrawingDialog : Form
    {
        public ImageDraw ImageDraw;

        /**
         * Constructor that sets the values of the dialog based on the current ImageDraw
         * settings.
         * 
         * @param imageDraw The ImageDraw object that contains the current settings.
         */
        public DrawingDialog(ImageDraw imageDraw)
        {
            InitializeComponent();

            ImageDraw = imageDraw;

            lineStyleComboBox.Items.AddRange(imageDraw.LineShapeTypes.ToArray());
            lineThicknessTextBox.Text = imageDraw.LineThickness.ToString();
            colorTextBox.Text = imageDraw.LineColor.ToString();

            //Set index of drop-down list based on line shape being currently used.
            this.lineStyleComboBox.SelectedIndex = lineStyleComboBox.Items.IndexOf(ImageDraw.CurrentLineShape);
        }

        /**
         * Opens up a color dialog for the user to choose a new color for the draw utility.
         */
        private void lineColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            colorDialog.ShowDialog();

            ImageDraw.LineColor = colorDialog.Color;
            colorTextBox.Text = ImageDraw.LineColor.ToString();
        }

        /**
         * The handler for when the OK button is clicked in the dialog.
         * Grabs the value out of the line thickness text box.
         */
        private void okButton_Click(object sender, EventArgs e)
        {
            ImageDraw.LineThickness = Convert.ToInt32(lineThicknessTextBox.Text);
        }

        /**
         * Handler for the changing of the selection in the drop-down list for the shape
         * of the draw object.
         */
        private void lineStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageDraw.CurrentLineShape = lineStyleComboBox.SelectedItem.ToString();
        }
    }
}
