namespace UI.Dialogs
{
    partial class ResizeDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.ResizeButton = new System.Windows.Forms.Button();
            this.ResizeTextBox = new System.Windows.Forms.TextBox();
            this.ZoomWarningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resize Image (%)";
            // 
            // ResizeButton
            // 
            this.ResizeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ResizeButton.Location = new System.Drawing.Point(92, 95);
            this.ResizeButton.Name = "ResizeButton";
            this.ResizeButton.Size = new System.Drawing.Size(75, 23);
            this.ResizeButton.TabIndex = 1;
            this.ResizeButton.Text = "Resize";
            this.ResizeButton.UseVisualStyleBackColor = true;
            this.ResizeButton.Click += new System.EventHandler(this.ResizeButton_Click);
            // 
            // ResizeTextBox
            // 
            this.ResizeTextBox.Location = new System.Drawing.Point(125, 36);
            this.ResizeTextBox.MaxLength = 3;
            this.ResizeTextBox.Name = "ResizeTextBox";
            this.ResizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.ResizeTextBox.TabIndex = 2;
            // 
            // ZoomWarningLabel
            // 
            this.ZoomWarningLabel.AutoSize = true;
            this.ZoomWarningLabel.Location = new System.Drawing.Point(43, 136);
            this.ZoomWarningLabel.Name = "ZoomWarningLabel";
            this.ZoomWarningLabel.Size = new System.Drawing.Size(173, 13);
            this.ZoomWarningLabel.TabIndex = 3;
            this.ZoomWarningLabel.Text = "Note: This will zoom image to 100%";
            // 
            // ResizeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 158);
            this.Controls.Add(this.ZoomWarningLabel);
            this.Controls.Add(this.ResizeTextBox);
            this.Controls.Add(this.ResizeButton);
            this.Controls.Add(this.label1);
            this.Name = "ResizeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ResizeDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ResizeButton;
        private System.Windows.Forms.TextBox ResizeTextBox;
        private System.Windows.Forms.Label ZoomWarningLabel;
    }
}