using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition.ObjectDetectionLibrary
{
    class ColorImageMatrix : IColorImageMatrix
    {
        private IImageCanalMatrix red { get; set; }
        private IImageCanalMatrix green { get; set; }
        private IImageCanalMatrix blue { get; set; }
        private int Width { get; set; }
        private int Height { get; set; }

        public ColorImageMatrix(Bitmap m)
        {
            Width = m.Width;
            Height = m.Height;
            red.imageMatrix = new int[Width, Height];
            green.imageMatrix = new int[Width, Height];
            blue.imageMatrix = new int[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Color pixel = m.GetPixel(i, j);
                    int p = pixel.ToArgb();

                    if (pixel != null)
                    {
                        //picture data
                        red.imageMatrix[i, j] = pixel.R;
                        green.imageMatrix[i, j] = pixel.G;
                        blue.imageMatrix[i, j] = pixel.B;
                    }
                }
            }
        }
        public Bitmap GetBitmap()
        {
            Bitmap currentBitmap = new Bitmap(Width, Height);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Color c = System.Drawing.Color.FromArgb(red.imageMatrix[i, j], green.imageMatrix[i, j], blue.imageMatrix[i, j]);
                    currentBitmap.SetPixel(i, j, c);
                }
            }
            return currentBitmap;
        }
    }
}
