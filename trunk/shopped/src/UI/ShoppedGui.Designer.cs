﻿namespace UI
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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.AdditionalInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.openPictureButton = new System.Windows.Forms.ToolStripButton();
            this.saveImageButton = new System.Windows.Forms.ToolStripButton();
            this.UndoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RedoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RotateToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ZoomToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ResizeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.FilterToolStripButton = new System.Windows.Forms.ToolStripSplitButton();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PictureBoxPanel = new System.Windows.Forms.Panel();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.MenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.PictureBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1008, 24);
            this.MenuStrip.TabIndex = 1;
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
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomImageToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // zoomImageToolStripMenuItem
            // 
            this.zoomImageToolStripMenuItem.Name = "zoomImageToolStripMenuItem";
            this.zoomImageToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.zoomImageToolStripMenuItem.Text = "Zoom Image";
            this.zoomImageToolStripMenuItem.Click += new System.EventHandler(this.zoomImageToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateToolStripMenuItem,
            this.resizeToolStripMenuItem,
            this.filterToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.rotateToolStripMenuItem.Text = "Rotate";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.rotateToolStripMenuItem_Click);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.resizeToolStripMenuItem.Text = "Resize";
            this.resizeToolStripMenuItem.Click += new System.EventHandler(this.resizeToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayscaleToolStripMenuItem1,
            this.sepiaToolStripMenuItem,
            this.toolStripSeparator1,
            this.brightnessToolStripMenuItem,
            this.contrastToolStripMenuItem,
            this.toolStripSeparator2,
            this.invertToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.filterToolStripMenuItem.Text = "Filters";
            // 
            // grayscaleToolStripMenuItem1
            // 
            this.grayscaleToolStripMenuItem1.Name = "grayscaleToolStripMenuItem1";
            this.grayscaleToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.grayscaleToolStripMenuItem1.Text = "Grayscale";
            this.grayscaleToolStripMenuItem1.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.sepiaToolStripMenuItem.Text = "Sepia";
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.sepiaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // brightnessToolStripMenuItem
            // 
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            this.brightnessToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.brightnessToolStripMenuItem.Text = "Brightness";
            this.brightnessToolStripMenuItem.Click += new System.EventHandler(this.brightnessToolStripMenuItem_Click);
            // 
            // contrastToolStripMenuItem
            // 
            this.contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
            this.contrastToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.contrastToolStripMenuItem.Text = "Contrast";
            this.contrastToolStripMenuItem.Click += new System.EventHandler(this.contrastToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(126, 6);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.invertToolStripMenuItem.Text = "Invert";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
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
            // 
            // ToolStrip
            // 
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPictureButton,
            this.saveImageButton,
            this.UndoToolStripButton,
            this.RedoToolStripButton,
            this.RotateToolStripButton,
            this.ZoomToolStripButton,
            this.ResizeToolStripButton,
            this.FilterToolStripButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 24);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(1008, 25);
            this.ToolStrip.TabIndex = 4;
            this.ToolStrip.Text = "toolStrip1";
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
            // UndoToolStripButton
            // 
            this.UndoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UndoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("UndoToolStripButton.Image")));
            this.UndoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UndoToolStripButton.Name = "UndoToolStripButton";
            this.UndoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.UndoToolStripButton.Text = "Undo";
            this.UndoToolStripButton.Click += new System.EventHandler(this.UndoToolStripButton_Click);
            // 
            // RedoToolStripButton
            // 
            this.RedoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RedoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RedoToolStripButton.Image")));
            this.RedoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RedoToolStripButton.Name = "RedoToolStripButton";
            this.RedoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.RedoToolStripButton.Text = "Redo";
            this.RedoToolStripButton.Click += new System.EventHandler(this.RedoToolStripButton_Click);
            // 
            // RotateToolStripButton
            // 
            this.RotateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RotateToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RotateToolStripButton.Image")));
            this.RotateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RotateToolStripButton.Name = "RotateToolStripButton";
            this.RotateToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.RotateToolStripButton.Text = "Rotate";
            this.RotateToolStripButton.ToolTipText = "Rotate Image";
            this.RotateToolStripButton.Click += new System.EventHandler(this.RotateToolStripButton_Click);
            // 
            // ZoomToolStripButton
            // 
            this.ZoomToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ZoomToolStripButton.Image")));
            this.ZoomToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomToolStripButton.Name = "ZoomToolStripButton";
            this.ZoomToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ZoomToolStripButton.Text = "Zoom Image";
            this.ZoomToolStripButton.Click += new System.EventHandler(this.ZoomToolStripButton_Click);
            // 
            // ResizeToolStripButton
            // 
            this.ResizeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ResizeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ResizeToolStripButton.Image")));
            this.ResizeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResizeToolStripButton.Name = "ResizeToolStripButton";
            this.ResizeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ResizeToolStripButton.Text = "Resize";
            this.ResizeToolStripButton.ToolTipText = "Resize Image";
            this.ResizeToolStripButton.Click += new System.EventHandler(this.ResizeToolStripButton_Click);
            // 
            // FilterToolStripButton
            // 
            this.FilterToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FilterToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayscaleToolStripMenuItem,
            this.sepiaToolStripMenuItem1,
            this.brightnessToolStripMenuItem1,
            this.contrastToolStripMenuItem1,
            this.invertToolStripMenuItem1});
            this.FilterToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("FilterToolStripButton.Image")));
            this.FilterToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FilterToolStripButton.Name = "FilterToolStripButton";
            this.FilterToolStripButton.Size = new System.Drawing.Size(32, 22);
            this.FilterToolStripButton.Text = "Filters";
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            // 
            // sepiaToolStripMenuItem1
            // 
            this.sepiaToolStripMenuItem1.Name = "sepiaToolStripMenuItem1";
            this.sepiaToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.sepiaToolStripMenuItem1.Text = "Sepia";
            // 
            // brightnessToolStripMenuItem1
            // 
            this.brightnessToolStripMenuItem1.Name = "brightnessToolStripMenuItem1";
            this.brightnessToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.brightnessToolStripMenuItem1.Text = "Brightness";
            // 
            // contrastToolStripMenuItem1
            // 
            this.contrastToolStripMenuItem1.Name = "contrastToolStripMenuItem1";
            this.contrastToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.contrastToolStripMenuItem1.Text = "Contrast";
            // 
            // invertToolStripMenuItem1
            // 
            this.invertToolStripMenuItem1.Name = "invertToolStripMenuItem1";
            this.invertToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.invertToolStripMenuItem1.Text = "Invert";
            // 
            // PictureBoxPanel
            // 
            this.PictureBoxPanel.AutoScroll = true;
            this.PictureBoxPanel.AutoSize = true;
            this.PictureBoxPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PictureBoxPanel.Controls.Add(this.PictureBox);
            this.PictureBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxPanel.Location = new System.Drawing.Point(0, 49);
            this.PictureBoxPanel.Name = "PictureBoxPanel";
            this.PictureBoxPanel.Size = new System.Drawing.Size(1008, 661);
            this.PictureBoxPanel.TabIndex = 5;
            // 
            // PictureBox
            // 
            this.PictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PictureBox.Location = new System.Drawing.Point(3, 0);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(1005, 649);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            // 
            // ShoppedGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 732);
            this.Controls.Add(this.PictureBoxPanel);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "ShoppedGui";
            this.Text = "Shopped";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.PictureBoxPanel.ResumeLayout(false);
            this.PictureBoxPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
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
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton openPictureButton;
        private System.Windows.Forms.ToolStripButton saveImageButton;
        private System.Windows.Forms.Panel PictureBoxPanel;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton RedoToolStripButton;
        private System.Windows.Forms.ToolStripButton UndoToolStripButton;
        private System.Windows.Forms.ToolStripButton RotateToolStripButton;
        private System.Windows.Forms.ToolStripButton ZoomToolStripButton;
        private System.Windows.Forms.ToolStripSplitButton FilterToolStripButton;
        private System.Windows.Forms.ToolStripButton ResizeToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem brightnessToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem1;
    }
}