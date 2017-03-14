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
        private ImageCanalMatrix red { get; set; }
        private ImageCanalMatrix green { get; set; }
        private ImageCanalMatrix blue { get; set; }
        private int Width { get; set; }
        private int Height { get; set; }

        public ColorImageMatrix(Bitmap m)
        {
            Width = m.Width;
            Height = m.Height;
            red = new ImageCanalMatrix(new int[Width, Height]);
            green = new ImageCanalMatrix(new int[Width, Height]);
            blue = new ImageCanalMatrix(new int[Width, Height]);
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
                    Color c = Color.FromArgb(red.imageMatrix[i, j], green.imageMatrix[i, j], blue.imageMatrix[i, j]);
                    currentBitmap.SetPixel(i, j, c);
                }
            }
            return currentBitmap;
        }

        public Bitmap EdgeDetection()
        {
            Bitmap currentBitmap = new Bitmap(Width, Height);
            int[,] tmpRed = red.GetEdges();
            int[,] tmpGreen = green.GetEdges();
            int[,] tmpBlue = blue.GetEdges();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Color c = Color.FromArgb(255, 255, 255);
                    if (tmpRed[i, j]==0 || tmpGreen[i, j] == 0 || tmpBlue[i, j] == 0)
                        c = Color.FromArgb(0, 0, 0);
                    
                    currentBitmap.SetPixel(i, j, c);
                }
            }
            return currentBitmap;
        }
    }
}
