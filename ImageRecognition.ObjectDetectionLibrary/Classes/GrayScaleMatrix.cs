using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition.ObjectDetectionLibrary
{
    public class GrayScaleMatrix : ImageCanalMatrix, IGrayScaleMatrix
    {
        public GrayScaleMatrix(Bitmap m)
        {
            Width = m.Width;
            Height = m.Height;
            imageMatrix = new int[m.Width, m.Height];
            for (int i = 0; i < m.Width; i++)
            {
                for (int j = 0; j < m.Height; j++)
                {
                    Color pixel = m.GetPixel(i, j);
                    int p = pixel.ToArgb();

                    //picture data
                    if (pixel != null)
                    {
                        int mean = (pixel.R + pixel.G + pixel.B) / 3;
                        imageMatrix[i, j] = mean;
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
                    Color c = System.Drawing.Color.FromArgb(imageMatrix[i, j], imageMatrix[i, j], imageMatrix[i, j]);
                    currentBitmap.SetPixel(i, j, c);
                }
            }
            return currentBitmap;
        }

    }
}
