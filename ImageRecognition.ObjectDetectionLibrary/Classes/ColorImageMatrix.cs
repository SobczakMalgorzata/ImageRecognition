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

        public ColorImageMatrix(Bitmap m)
        {

        }
    }
}
