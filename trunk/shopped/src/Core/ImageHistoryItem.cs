using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Core
{
    /**
     * A simple class that contains an Image object and a string that details the operation performed.
     */
    public class ImageHistoryItem
    {
        public Image Image { get; set; }
        public string OperationPerformed { get; set; }
    }
}
