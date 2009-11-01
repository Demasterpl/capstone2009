using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Core.Images;
using Core.Interfaces;
using Core;

namespace Core
{
    /**
     * A class that contains the initialized objects of the classes in Core. This is a "poor man's"
     * implementation of Inverion of Control. If time, convert this to an appropriate IoC container.
     */
    public class ShoppedGuiHelper
    {
        public PictureBoxImage CurrentImage { get; set; }
        public ImageRotate ImageRotate { get; set; }
        public IFileOperations FileOperation { get; set; }
        public ImageHistory ImageHistory { get; set; }
        public ImageZoom ImageZoom { get; set; }
        public ImageResize ImageResize { get; set; }
        public Grayscale Grayscale { get; set; }
        public Sepia Sepia { get; set; }

        public ShoppedGuiHelper()
            : this(new PictureBoxImage(), new ImageRotate(), new FileOperations(), new ImageHistory(), new ImageZoom(), new ImageResize(), new Grayscale(), new Sepia())
        { }

        public ShoppedGuiHelper(PictureBoxImage pictureBoxImage, 
            ImageRotate imageRotate, FileOperations fileOperation, ImageHistory imageHistory, 
            ImageZoom imageZoom, ImageResize imageResize, Grayscale grayscale, Sepia sepia)
        {
            CurrentImage = pictureBoxImage;
            ImageRotate = imageRotate;
            FileOperation = fileOperation;
            ImageHistory = imageHistory;
            ImageZoom = imageZoom;
            ImageResize = imageResize;
            Grayscale = grayscale;
            Sepia = sepia;
        }
    }
}
