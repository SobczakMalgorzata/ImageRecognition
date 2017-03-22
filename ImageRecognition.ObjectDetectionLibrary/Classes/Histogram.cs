using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition.ObjectDetectionLibrary.Classes
{
    class Histogram
    {
        public int[] histogram { get; set; }

        public Histogram()
        {
            histogram = new int[256];
            for (int i = 0; i < 256; i++)
            {
                histogram[i] = 0;
            }
        }

        public Histogram(int[,] m)
        {
            histogram = new int[256];
            for (int i = 0; i < 256; i++)
            {
                histogram[i] = 0;
            }
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    histogram[m[i, j]]++;
                }
            }
        }
    }
}
