﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition.ObjectDetectionLibrary
{
    public interface IGrayScaleMatrix
    {
        int[,] imageMatrix { get; set; }
        int Width { get; set; }
        int Height { get; set; }

        Bitmap GetBitmap();
    }
}
