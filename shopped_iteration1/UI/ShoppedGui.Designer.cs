namespace UI
{
    partial class ShoppedGui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShoppedGui));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tODOAddMoreToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tODOAddMoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.AdditionalInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openPictureButton = new System.Windows.Forms.ToolStripButton();
            this.saveImageButton = new System.Windows.Forms.ToolStripButton();
            this.PictureBoxPanel = new System.Windows.Forms.Panel();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.PictureBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                                                        this.fileToolStripMenuItem,
                                                                                        this.editToolStripMenuItem,
                                                                                        this.viewToolStripMenuItem,
                                                                                        this.toolsToolStripMenuItem,
                                                                                        this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                                                                           this.openPictureToolStripMenuItem,
                                                                                                           this.savePictureToolStripMenuItem,
                                                                                                           this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openPictureToolStripMenuItem
            // 
            this.openPictureToolStripMenuItem.Name = "openPictureToolStripMenuItem";
            this.openPictureToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openPictureToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openPictureToolStripMenuItem.Text = "Open Picture";
            this.openPictureToolStripMenuItem.Click += new System.EventHandler(this.openPictureToolStripMenuItem_Click);
            // 
            // savePictureToolStripMenuItem
            // 
            this.savePictureToolStripMenuItem.Name = "savePictureToolStripMenuItem";
            this.savePictureToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.savePictureToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.savePictureToolStripMenuItem.Text = "Save Picture";
            this.savePictureToolStripMenuItem.Click += new System.EventHandler(this.savePictureToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                                                                           this.undoToolStripMenuItem,
                                                                                                           this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                                                                           this.tODOAddMoreToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // tODOAddMoreToolStripMenuItem1
            // 
            this.tODOAddMoreToolStripMenuItem1.Name = "tODOAddMoreToolStripMenuItem1";
            this.tODOAddMoreToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.tODOAddMoreToolStripMenuItem1.Text = "TODO: Add More";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                                                                            this.tODOAddMoreToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // tODOAddMoreToolStripMenuItem
            // 
            this.tODOAddMoreToolStripMenuItem.Name = "tODOAddMoreToolStripMenuItem";
            this.tODOAddMoreToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.tODOAddMoreToolStripMenuItem.Text = "TODO: Add More";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                                                                           this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                                                          this.AdditionalInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 710);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // AdditionalInfo
            // 
            this.AdditionalInfo.Name = "AdditionalInfo";
            this.AdditionalInfo.Size = new System.Drawing.Size(185, 17);
            this.AdditionalInfo.Text = "Additional Info About The Picture";
            this.AdditionalInfo.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                                                        this.openPictureButton,
                                                                                        this.saveImageButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openPictureButton
            // 
            this.openPictureButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openPictureButton.Image = ((System.Drawing.Image)(resources.GetObject("openPictureButton.Image")));
            this.openPictureButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openPictureButton.Name = "openPictureButton";
            this.openPictureButton.Size = new System.Drawing.Size(23, 22);
            this.openPictureButton.Text = "toolStripButton1";
            this.openPictureButton.ToolTipText = "Open Picture";
            this.openPictureButton.Click += new System.EventHandler(this.openPictureButton_Click);
            // 
            // saveImageButton
            // 
            this.saveImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveImageButton.Image = ((System.Drawing.Image)(resources.GetObject("saveImageButton.Image")));
            this.saveImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveImageButton.Name = "saveImageButton";
            this.saveImageButton.Size = new System.Drawing.Size(23, 22);
            this.saveImageButton.Text = "toolStripButton2";
            this.saveImageButton.ToolTipText = "Save Picture";
            this.saveImageButton.Click += new System.EventHandler(this.saveImageButton_Click);
            // 
            // PictureBoxPanel
            // 
            this.PictureBoxPanel.AutoScroll = true;
            this.PictureBoxPanel.Controls.Add(this.PictureBox);
            this.PictureBoxPanel.Location = new System.Drawing.Point(0, 52);
            this.PictureBoxPanel.Name = "PictureBoxPanel";
            this.PictureBoxPanel.Size = new System.Drawing.Size(1008, 655);
            this.PictureBoxPanel.TabIndex = 5;
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(3, 0);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(1005, 649);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // ShoppedGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 732);
            this.Controls.Add(this.PictureBoxPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ShoppedGui";
            this.Text = "Shopped";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.PictureBoxPanel.ResumeLayout(false);
            this.PictureBoxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePictureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel AdditionalInfo;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tODOAddMoreToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tODOAddMoreToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openPictureButton;
        private System.Windows.Forms.ToolStripButton saveImageButton;
        private System.Windows.Forms.Panel PictureBoxPanel;
        private System.Windows.Forms.PictureBox PictureBox;
    }
}