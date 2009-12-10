using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace UI.Dialogs
{
    partial class AboutShoppedDialog : Form
    {
        public AboutShoppedDialog()
        {
            InitializeComponent();
            //this.Text = String.Format("About {0} {0}", AssemblyTitle);
            //this.labelProductName.Text = AssemblyProduct;
            //this.labelVersion.Text = String.Format("Version {0} {0}", AssemblyVersion);
            //this.labelCopyright.Text = AssemblyCopyright;
            //this.labelCompanyName.Text = AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;

            this.Text = "About Shopped";
            this.labelProductName.Text = "Shopped Image Editor";
            this.labelVersion.Text = "Version 1.0";
            this.labelCopyright.Text = string.Empty;
            this.labelCompanyName.Text = "Written by Greg Beca, Dan Sheaffer and Andy Vanek";
            this.textBoxDescription.Text = "This software was developed for the Capstone course of the Computer Science"
                + " department at Kent State University. It is an open source image editing software written in C#. You can"
                + " find our project page and repository here:\n http://code.google.com/p/capstone2009/";
        }
    }
}
