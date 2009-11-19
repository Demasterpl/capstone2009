namespace UI.Dialogs
{
    partial class DrawingDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lineColorLabel = new System.Windows.Forms.Label();
            this.lineColorButton = new System.Windows.Forms.Button();
            this.lineThicknessLabel = new System.Windows.Forms.Label();
            this.ThicknessTextBox = new System.Windows.Forms.TextBox();
            this.lineStyleLabel = new System.Windows.Forms.Label();
            this.lineStyleComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.colorTextBox = new System.Windows.Forms.TextBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.RadiusLabel = new System.Windows.Forms.Label();
            this.RadiusTextBox = new System.Windows.Forms.TextBox();
            this.imageDrawBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DrawingEnabledLabel = new System.Windows.Forms.Label();
            this.DrawingEnabledCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageDrawBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lineColorLabel
            // 
            this.lineColorLabel.AutoSize = true;
            this.lineColorLabel.Location = new System.Drawing.Point(13, 49);
            this.lineColorLabel.Name = "lineColorLabel";
            this.lineColorLabel.Size = new System.Drawing.Size(54, 13);
            this.lineColorLabel.TabIndex = 0;
            this.lineColorLabel.Text = "Line Color";
            // 
            // lineColorButton
            // 
            this.lineColorButton.Location = new System.Drawing.Point(138, 72);
            this.lineColorButton.Name = "lineColorButton";
            this.lineColorButton.Size = new System.Drawing.Size(118, 23);
            this.lineColorButton.TabIndex = 1;
            this.lineColorButton.Text = "Show Color Palette";
            this.lineColorButton.UseVisualStyleBackColor = true;
            this.lineColorButton.Click += new System.EventHandler(this.lineColorButton_Click);
            // 
            // lineThicknessLabel
            // 
            this.lineThicknessLabel.AutoSize = true;
            this.lineThicknessLabel.Location = new System.Drawing.Point(13, 184);
            this.lineThicknessLabel.Name = "lineThicknessLabel";
            this.lineThicknessLabel.Size = new System.Drawing.Size(91, 13);
            this.lineThicknessLabel.TabIndex = 2;
            this.lineThicknessLabel.Text = "Thickness (pixels)";
            this.lineThicknessLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ThicknessTextBox
            // 
            this.ThicknessTextBox.Location = new System.Drawing.Point(138, 181);
            this.ThicknessTextBox.MaxLength = 4;
            this.ThicknessTextBox.Name = "ThicknessTextBox";
            this.ThicknessTextBox.Size = new System.Drawing.Size(118, 20);
            this.ThicknessTextBox.TabIndex = 3;
            // 
            // lineStyleLabel
            // 
            this.lineStyleLabel.AutoSize = true;
            this.lineStyleLabel.Location = new System.Drawing.Point(13, 120);
            this.lineStyleLabel.Name = "lineStyleLabel";
            this.lineStyleLabel.Size = new System.Drawing.Size(69, 13);
            this.lineStyleLabel.TabIndex = 4;
            this.lineStyleLabel.Text = "Draw Pattern";
            // 
            // lineStyleComboBox
            // 
            this.lineStyleComboBox.FormattingEnabled = true;
            this.lineStyleComboBox.Location = new System.Drawing.Point(138, 117);
            this.lineStyleComboBox.Name = "lineStyleComboBox";
            this.lineStyleComboBox.Size = new System.Drawing.Size(117, 21);
            this.lineStyleComboBox.TabIndex = 5;
            this.lineStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.lineStyleComboBox_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(41, 311);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(152, 311);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // colorTextBox
            // 
            this.colorTextBox.Location = new System.Drawing.Point(139, 46);
            this.colorTextBox.Name = "colorTextBox";
            this.colorTextBox.ReadOnly = true;
            this.colorTextBox.Size = new System.Drawing.Size(117, 20);
            this.colorTextBox.TabIndex = 8;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(15, 214);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(73, 13);
            this.HeightLabel.TabIndex = 9;
            this.HeightLabel.Text = "Height (pixels)";
            this.HeightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(137, 211);
            this.HeightTextBox.MaxLength = 4;
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(118, 20);
            this.HeightTextBox.TabIndex = 10;
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(15, 245);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(70, 13);
            this.WidthLabel.TabIndex = 11;
            this.WidthLabel.Text = "Width (pixels)";
            this.WidthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(137, 242);
            this.WidthTextBox.MaxLength = 4;
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(118, 20);
            this.WidthTextBox.TabIndex = 12;
            // 
            // RadiusLabel
            // 
            this.RadiusLabel.AutoSize = true;
            this.RadiusLabel.Location = new System.Drawing.Point(13, 276);
            this.RadiusLabel.Name = "RadiusLabel";
            this.RadiusLabel.Size = new System.Drawing.Size(75, 13);
            this.RadiusLabel.TabIndex = 13;
            this.RadiusLabel.Text = "Radius (pixels)";
            this.RadiusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RadiusTextBox
            // 
            this.RadiusTextBox.Location = new System.Drawing.Point(137, 273);
            this.RadiusTextBox.MaxLength = 4;
            this.RadiusTextBox.Name = "RadiusTextBox";
            this.RadiusTextBox.Size = new System.Drawing.Size(118, 20);
            this.RadiusTextBox.TabIndex = 14;
            // 
            // imageDrawBindingSource
            // 
            this.imageDrawBindingSource.DataSource = typeof(Core.Manipulators.ImageDraw);
            // 
            // DrawingEnabledLabel
            // 
            this.DrawingEnabledLabel.AutoSize = true;
            this.DrawingEnabledLabel.Location = new System.Drawing.Point(13, 18);
            this.DrawingEnabledLabel.Name = "DrawingEnabledLabel";
            this.DrawingEnabledLabel.Size = new System.Drawing.Size(88, 13);
            this.DrawingEnabledLabel.TabIndex = 15;
            this.DrawingEnabledLabel.Text = "Drawing Enabled";
            // 
            // DrawingEnabledCheckBox
            // 
            this.DrawingEnabledCheckBox.AutoSize = true;
            this.DrawingEnabledCheckBox.Location = new System.Drawing.Point(139, 18);
            this.DrawingEnabledCheckBox.Name = "DrawingEnabledCheckBox";
            this.DrawingEnabledCheckBox.Size = new System.Drawing.Size(15, 14);
            this.DrawingEnabledCheckBox.TabIndex = 16;
            this.DrawingEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // DrawingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 346);
            this.Controls.Add(this.DrawingEnabledCheckBox);
            this.Controls.Add(this.DrawingEnabledLabel);
            this.Controls.Add(this.RadiusTextBox);
            this.Controls.Add(this.RadiusLabel);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.colorTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.lineStyleComboBox);
            this.Controls.Add(this.lineStyleLabel);
            this.Controls.Add(this.ThicknessTextBox);
            this.Controls.Add(this.lineThicknessLabel);
            this.Controls.Add(this.lineColorButton);
            this.Controls.Add(this.lineColorLabel);
            this.Name = "DrawingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DrawingDialog";
            ((System.ComponentModel.ISupportInitialize)(this.imageDrawBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lineColorLabel;
        private System.Windows.Forms.Button lineColorButton;
        private System.Windows.Forms.Label lineThicknessLabel;
        private System.Windows.Forms.TextBox ThicknessTextBox;
        private System.Windows.Forms.Label lineStyleLabel;
        private System.Windows.Forms.ComboBox lineStyleComboBox;
        private System.Windows.Forms.BindingSource imageDrawBindingSource;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox colorTextBox;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.Label RadiusLabel;
        private System.Windows.Forms.TextBox RadiusTextBox;
        private System.Windows.Forms.Label DrawingEnabledLabel;
        private System.Windows.Forms.CheckBox DrawingEnabledCheckBox;
    }
}