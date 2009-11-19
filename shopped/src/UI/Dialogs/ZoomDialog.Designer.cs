namespace UI.Dialogs
{
    partial class ZoomDialog
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
            this.ZoomTextBox = new System.Windows.Forms.TextBox();
            this.ZoomButton = new System.Windows.Forms.Button();
            this.CancelZoomButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zoom Image (%)";
            // 
            // ZoomTextBox
            // 
            this.ZoomTextBox.Location = new System.Drawing.Point(122, 27);
            this.ZoomTextBox.MaxLength = 3;
            this.ZoomTextBox.Name = "ZoomTextBox";
            this.ZoomTextBox.Size = new System.Drawing.Size(100, 20);
            this.ZoomTextBox.TabIndex = 1;
            // 
            // ZoomButton
            // 
            this.ZoomButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ZoomButton.Location = new System.Drawing.Point(29, 81);
            this.ZoomButton.Name = "ZoomButton";
            this.ZoomButton.Size = new System.Drawing.Size(75, 23);
            this.ZoomButton.TabIndex = 2;
            this.ZoomButton.Text = "Zoom";
            this.ZoomButton.UseVisualStyleBackColor = true;
            this.ZoomButton.Click += new System.EventHandler(this.ZoomButton_Click);
            // 
            // CancelZoomButton
            // 
            this.CancelZoomButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelZoomButton.Location = new System.Drawing.Point(136, 81);
            this.CancelZoomButton.Name = "CancelZoomButton";
            this.CancelZoomButton.Size = new System.Drawing.Size(75, 23);
            this.CancelZoomButton.TabIndex = 3;
            this.CancelZoomButton.Text = "Cancel";
            this.CancelZoomButton.UseVisualStyleBackColor = true;
            // 
            // ZoomDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 116);
            this.Controls.Add(this.CancelZoomButton);
            this.Controls.Add(this.ZoomButton);
            this.Controls.Add(this.ZoomTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ZoomDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ZoomDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ZoomTextBox;
        private System.Windows.Forms.Button ZoomButton;
        private System.Windows.Forms.Button CancelZoomButton;
    }
}