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
            this.lineThicknessTextBox = new System.Windows.Forms.TextBox();
            this.lineStyleLabel = new System.Windows.Forms.Label();
            this.lineStyleComboBox = new System.Windows.Forms.ComboBox();
            this.imageDrawBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.colorTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageDrawBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lineColorLabel
            // 
            this.lineColorLabel.AutoSize = true;
            this.lineColorLabel.Location = new System.Drawing.Point(13, 45);
            this.lineColorLabel.Name = "lineColorLabel";
            this.lineColorLabel.Size = new System.Drawing.Size(54, 13);
            this.lineColorLabel.TabIndex = 0;
            this.lineColorLabel.Text = "Line Color";
            // 
            // lineColorButton
            // 
            this.lineColorButton.Location = new System.Drawing.Point(138, 63);
            this.lineColorButton.Name = "lineColorButton";
            this.lineColorButton.Size = new System.Drawing.Size(118, 23);
            this.lineColorButton.TabIndex = 1;
            this.lineColorButton.Text = "Open Color Dialog";
            this.lineColorButton.UseVisualStyleBackColor = true;
            this.lineColorButton.Click += new System.EventHandler(this.lineColorButton_Click);
            // 
            // lineThicknessLabel
            // 
            this.lineThicknessLabel.AutoSize = true;
            this.lineThicknessLabel.Location = new System.Drawing.Point(12, 115);
            this.lineThicknessLabel.Name = "lineThicknessLabel";
            this.lineThicknessLabel.Size = new System.Drawing.Size(114, 13);
            this.lineThicknessLabel.TabIndex = 2;
            this.lineThicknessLabel.Text = "Line Thickness (pixels)";
            // 
            // lineThicknessTextBox
            // 
            this.lineThicknessTextBox.Location = new System.Drawing.Point(138, 112);
            this.lineThicknessTextBox.Name = "lineThicknessTextBox";
            this.lineThicknessTextBox.Size = new System.Drawing.Size(118, 20);
            this.lineThicknessTextBox.TabIndex = 3;
            // 
            // lineStyleLabel
            // 
            this.lineStyleLabel.AutoSize = true;
            this.lineStyleLabel.Location = new System.Drawing.Point(14, 171);
            this.lineStyleLabel.Name = "lineStyleLabel";
            this.lineStyleLabel.Size = new System.Drawing.Size(53, 13);
            this.lineStyleLabel.TabIndex = 4;
            this.lineStyleLabel.Text = "Line Style";
            // 
            // lineStyleComboBox
            // 
            this.lineStyleComboBox.FormattingEnabled = true;
            this.lineStyleComboBox.Location = new System.Drawing.Point(139, 168);
            this.lineStyleComboBox.Name = "lineStyleComboBox";
            this.lineStyleComboBox.Size = new System.Drawing.Size(117, 21);
            this.lineStyleComboBox.TabIndex = 5;
            this.lineStyleComboBox.SelectedIndexChanged += new System.EventHandler(this.lineStyleComboBox_SelectedIndexChanged);
            // 
            // imageDrawBindingSource
            // 
            this.imageDrawBindingSource.DataSource = typeof(Core.Manipulators.ImageDraw);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(45, 229);
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
            this.cancelButton.Location = new System.Drawing.Point(158, 229);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // colorTextBox
            // 
            this.colorTextBox.Location = new System.Drawing.Point(138, 37);
            this.colorTextBox.Name = "colorTextBox";
            this.colorTextBox.ReadOnly = true;
            this.colorTextBox.Size = new System.Drawing.Size(117, 20);
            this.colorTextBox.TabIndex = 8;
            // 
            // DrawingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.colorTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.lineStyleComboBox);
            this.Controls.Add(this.lineStyleLabel);
            this.Controls.Add(this.lineThicknessTextBox);
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
        private System.Windows.Forms.TextBox lineThicknessTextBox;
        private System.Windows.Forms.Label lineStyleLabel;
        private System.Windows.Forms.ComboBox lineStyleComboBox;
        private System.Windows.Forms.BindingSource imageDrawBindingSource;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox colorTextBox;
    }
}