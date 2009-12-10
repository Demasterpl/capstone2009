namespace UI.Dialogs
{
    partial class SelectionBoxDialog
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
            this.zoomButton = new System.Windows.Forms.Button();
            this.cropButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zoomButton
            // 
            this.zoomButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.zoomButton.Location = new System.Drawing.Point(35, 32);
            this.zoomButton.Name = "zoomButton";
            this.zoomButton.Size = new System.Drawing.Size(178, 23);
            this.zoomButton.TabIndex = 0;
            this.zoomButton.Text = "Zoom in on Selected Area";
            this.zoomButton.UseVisualStyleBackColor = true;
            // 
            // cropButton
            // 
            this.cropButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cropButton.Location = new System.Drawing.Point(35, 72);
            this.cropButton.Name = "cropButton";
            this.cropButton.Size = new System.Drawing.Size(178, 23);
            this.cropButton.TabIndex = 1;
            this.cropButton.Text = "Crop Selected Area";
            this.cropButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(35, 150);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(178, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.No;
            this.button1.Location = new System.Drawing.Point(35, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Copy Selected Area To Clipboard";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SelectionBoxDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 201);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.cropButton);
            this.Controls.Add(this.zoomButton);
            this.Name = "SelectionBoxDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selected Area Options";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button zoomButton;
        private System.Windows.Forms.Button cropButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button button1;

    }
}