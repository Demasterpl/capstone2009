namespace UI.Dialogs
{
    partial class RotateDialog
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
            this.RotateTextBox = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ZoomWarningLabel = new System.Windows.Forms.Label();
            this.CancelRotateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RotateTextBox
            // 
            this.RotateTextBox.Location = new System.Drawing.Point(156, 47);
            this.RotateTextBox.MaxLength = 4;
            this.RotateTextBox.Name = "RotateTextBox";
            this.RotateTextBox.Size = new System.Drawing.Size(111, 20);
            this.RotateTextBox.TabIndex = 0;
            // 
            // SubmitButton
            // 
            this.SubmitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SubmitButton.Location = new System.Drawing.Point(24, 96);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(110, 28);
            this.SubmitButton.TabIndex = 1;
            this.SubmitButton.Text = "Rotate";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rotate (Degrees)";
            // 
            // ZoomWarningLabel
            // 
            this.ZoomWarningLabel.AutoSize = true;
            this.ZoomWarningLabel.Location = new System.Drawing.Point(59, 144);
            this.ZoomWarningLabel.Name = "ZoomWarningLabel";
            this.ZoomWarningLabel.Size = new System.Drawing.Size(173, 13);
            this.ZoomWarningLabel.TabIndex = 3;
            this.ZoomWarningLabel.Text = "Note: This will zoom image to 100%";
            // 
            // CancelRotateButton
            // 
            this.CancelRotateButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelRotateButton.Location = new System.Drawing.Point(156, 96);
            this.CancelRotateButton.Name = "CancelRotateButton";
            this.CancelRotateButton.Size = new System.Drawing.Size(110, 28);
            this.CancelRotateButton.TabIndex = 4;
            this.CancelRotateButton.Text = "Cancel";
            this.CancelRotateButton.UseVisualStyleBackColor = true;
            // 
            // RotateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 166);
            this.Controls.Add(this.CancelRotateButton);
            this.Controls.Add(this.ZoomWarningLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.RotateTextBox);
            this.Name = "RotateDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rotate Image";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RotateTextBox;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ZoomWarningLabel;
        private System.Windows.Forms.Button CancelRotateButton;

    }
}