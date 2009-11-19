using System.Drawing;
using System.Drawing.Imaging;
using Core.Images;

namespace Core.Filters
{
    public class Sepia
    {
        /**
         * A filter that will make an Image object sepia.
         * 
         * @param shoppedImage The ShoppedImage object in the current context of Shopped GUI.
         * @return A ShoppedImage object with the appropriate properties set by this method.
         */
        public ShoppedImage MakeSepia(ShoppedImage shoppedImage)
        {
            ShoppedImage newShoppedImage = new ShoppedImage(shoppedImage);
            Bitmap sepiaBmp = new Bitmap(newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height);
            Graphics g = Graphics.FromImage(sepiaBmp);

            ColorMatrix colorMatrix = new ColorMatrix( 
                new float[][]
                {
                    new float[] {.393f, .349f, .272f, 0, 0},
                    new float[] {0.769f, 0.686f, 0.534f, 0, 0},
                    new float[] {0.189f, 0.168f, 0.131f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(newShoppedImage.CurrentImage,
                new Rectangle(0, 0, newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height),
                    0, 0, newShoppedImage.CurrentImage.Width, newShoppedImage.CurrentImage.Height,
                    GraphicsUnit.Pixel, attributes);
            g.Dispose();

            newShoppedImage.CurrentImage = sepiaBmp;

            return newShoppedImage;
        }
    }
}
