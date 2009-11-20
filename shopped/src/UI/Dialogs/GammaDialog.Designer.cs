namespace UI.Dialogs
{
    partial class GammaDialog
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
            this.AcceptButton = new System.Windows.Forms.Button();
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.RedLabel = new System.Windows.Forms.Label();
            this.BlueLabel = new System.Windows.Forms.Label();
            this.GreenLabel = new System.Windows.Forms.Label();
            this.GreenTextBox = new System.Windows.Forms.TextBox();
            this.BlueTextBox = new System.Windows.Forms.TextBox();
            this.RedTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AcceptButton
            // 
            this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AcceptButton.Location = new System.Drawing.Point(53, 143);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 0;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Location = new System.Drawing.Point(12, 9);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(157, 13);
            this.InstructionLabel.TabIndex = 1;
            this.InstructionLabel.Text = "Enter RGB values from 0.2 - 5.0";
            // 
            // RedLabel
            // 
            this.RedLabel.AutoSize = true;
            this.RedLabel.Location = new System.Drawing.Point(12, 38);
            this.RedLabel.Name = "RedLabel";
            this.RedLabel.Size = new System.Drawing.Size(27, 13);
            this.RedLabel.TabIndex = 2;
            this.RedLabel.Text = "Red";
            // 
            // BlueLabel
            // 
            this.BlueLabel.AutoSize = true;
            this.BlueLabel.Location = new System.Drawing.Point(12, 110);
            this.BlueLabel.Name = "BlueLabel";
            this.BlueLabel.Size = new System.Drawing.Size(28, 13);
            this.BlueLabel.TabIndex = 3;
            this.BlueLabel.Text = "Blue";
            // 
            // GreenLabel
            // 
            this.GreenLabel.AutoSize = true;
            this.GreenLabel.Location = new System.Drawing.Point(12, 72);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(36, 13);
            this.GreenLabel.TabIndex = 4;
            this.GreenLabel.Text = "Green";
            // 
            // GreenTextBox
            // 
            this.GreenTextBox.Location = new System.Drawing.Point(53, 69);
            this.GreenTextBox.MaxLength = 4;
            this.GreenTextBox.Name = "GreenTextBox";
            this.GreenTextBox.Size = new System.Drawing.Size(66, 20);
            this.GreenTextBox.TabIndex = 5;
            // 
            // BlueTextBox
            // 
            this.BlueTextBox.Location = new System.Drawing.Point(53, 103);
            this.BlueTextBox.MaxLength = 4;
            this.BlueTextBox.Name = "BlueTextBox";
            this.BlueTextBox.Size = new System.Drawing.Size(66, 20);
            this.BlueTextBox.TabIndex = 6;
            // 
            // RedTextBox
            // 
            this.RedTextBox.Location = new System.Drawing.Point(53, 35);
            this.RedTextBox.MaxLength = 4;
            this.RedTextBox.Name = "RedTextBox";
            this.RedTextBox.Size = new System.Drawing.Size(66, 20);
            this.RedTextBox.TabIndex = 7;
            // 
            // GammaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 180);
            this.Controls.Add(this.RedTextBox);
            this.Controls.Add(this.BlueTextBox);
            this.Controls.Add(this.GreenTextBox);
            this.Controls.Add(this.GreenLabel);
            this.Controls.Add(this.BlueLabel);
            this.Controls.Add(this.RedLabel);
            this.Controls.Add(this.InstructionLabel);
            this.Controls.Add(this.AcceptButton);
            this.Name = "GammaDialog";
            this.Text = "GammaDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private new System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.Label RedLabel;
        private System.Windows.Forms.Label BlueLabel;
        private System.Windows.Forms.Label GreenLabel;
        private System.Windows.Forms.TextBox GreenTextBox;
        private System.Windows.Forms.TextBox BlueTextBox;
        private System.Windows.Forms.TextBox RedTextBox;
    }
}