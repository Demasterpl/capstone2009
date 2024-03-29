﻿using System;
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

            SetTextBoxValues();

            lineStyleComboBox.Items.AddRange(imageDraw.LineShapeTypes.ToArray());
            DrawingEnabledCheckBox.Checked = imageDraw.Enabled;

            //Set index of drop-down list based on line shape being currently used.
            lineStyleComboBox.SelectedIndex = lineStyleComboBox.Items.IndexOf(ImageDraw.CurrentLineShape);
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

            if (AllTextBoxesHaveValidInput())
            {
                try
                {
                    ImageDraw.LineThickness = Convert.ToInt32(ThicknessTextBox.Text);
                    ImageDraw.ShapeHeight = Convert.ToInt32(HeightTextBox.Text);
                    ImageDraw.ShapeWidth = Convert.ToInt32(WidthTextBox.Text);
                    ImageDraw.ShapeRadius = Convert.ToInt32(RadiusTextBox.Text);
                    ImageDraw.Enabled = DrawingEnabledCheckBox.Checked;
                }
                catch
                {
                    MessageBox.Show("Invalid input. Must be positive integer value");
                    DialogResult = DialogResult.Retry;
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Must be positive integer value");
                DialogResult = DialogResult.Retry;
            }

        }

        /**
         * Makes sure that each textbox has a positive integer value inside it.
         * 
         * @return Whether or not the above statement is true.
         */
        private bool AllTextBoxesHaveValidInput()
        {
            try
            {
                Convert.ToInt32(ThicknessTextBox.Text);
                Convert.ToInt32(HeightTextBox.Text);
                Convert.ToInt32(WidthTextBox.Text);
                Convert.ToInt32(RadiusTextBox.Text);
            }
            catch
            {
                return false;
            }

            return (Convert.ToInt32(ThicknessTextBox.Text) > 0) &&
                    (Convert.ToInt32(HeightTextBox.Text) > 0) &&
                    (Convert.ToInt32(WidthTextBox.Text) > 0) &&
                    (Convert.ToInt32(RadiusTextBox.Text) > 0);
        }

        /**
         * Grabs the property values from the ImageDraw object and sets the textboxes.
         */
        private void SetTextBoxValues()
        {
            colorTextBox.Text = ImageDraw.LineColor.ToString();
            HeightTextBox.Text = ImageDraw.ShapeHeight.ToString();
            WidthTextBox.Text = ImageDraw.ShapeWidth.ToString();
            ThicknessTextBox.Text = ImageDraw.LineThickness.ToString();
            RadiusTextBox.Text = ImageDraw.ShapeRadius.ToString();
        }

        /**
         * Handler for the changing of the selection in the drop-down list for the shape
         * of the draw object.
         */
        private void lineStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageDraw.CurrentLineShape = lineStyleComboBox.SelectedItem.ToString();

            switch (lineStyleComboBox.SelectedItem.ToString())
            {
                case "Square":
                    HeightTextBox.Enabled = true;
                    ThicknessTextBox.Enabled = false;
                    WidthTextBox.Enabled = false;
                    RadiusTextBox.Enabled = false;
                    break;
                case "Rectangle":
                    HeightTextBox.Enabled = true;
                    ThicknessTextBox.Enabled = false;
                    WidthTextBox.Enabled = true;
                    RadiusTextBox.Enabled = false;
                    break;
                case "Triangle":
                    HeightTextBox.Enabled = true;
                    ThicknessTextBox.Enabled = false;
                    WidthTextBox.Enabled = true;
                    RadiusTextBox.Enabled = false;
                    break;
                case "Circle":
                    HeightTextBox.Enabled = false;
                    ThicknessTextBox.Enabled = false;
                    WidthTextBox.Enabled = false;
                    RadiusTextBox.Enabled = true;
                    break;
                case "Line":
                    HeightTextBox.Enabled = false;
                    ThicknessTextBox.Enabled = true;
                    WidthTextBox.Enabled = false;
                    RadiusTextBox.Enabled = false;
                    break;
            }
        }
    }
}
