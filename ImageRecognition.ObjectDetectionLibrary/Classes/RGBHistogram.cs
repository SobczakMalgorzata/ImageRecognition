using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition.ObjectDetectionLibrary.Classes
{
    class RGBHistogram : Histogram
    {
        public RGBHistogram(Bitmap m)
        {
            histogram = new int[256];
            for (int i = 0; i < 256; i++)
            {
                histogram[i] = 0;
            }
            for (int i = 0; i < m.Width; i++)
            {
                for (int j = 0; j < m.Height; j++)
                {
                    Color pixel = m.GetPixel(i, j);
                    int p = pixel.ToArgb();

                    if (pixel != null)
                    {
                        //picture data
                        histogram[pixel.R]++;
                        histogram[pixel.G]++;
                        histogram[pixel.B]++;
                    }
                    
                }
            }
        }
    }
}
