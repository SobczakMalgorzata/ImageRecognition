using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition.ObjectDetectionLibrary
{
    public class ImageCanalMatrix : IImageCanalMatrix
    {
        public int[,] imageMatrix { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public ImageCanalMatrix()
        {
            imageMatrix = new int[1, 1] { { -1} };
            Width = 0;
            Height = 0;
        }

        public ImageCanalMatrix(int[,] i)
        {
            imageMatrix = i;
            Width = i.GetLength(0);
            Height = i.GetLength(1);
        }
    }
}
