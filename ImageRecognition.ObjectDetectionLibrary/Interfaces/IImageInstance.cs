using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition.ObjectDetectionLibrary
{
    public interface IImageInstance
    {
        Bitmap GetColorBitmap();
        Bitmap GetGrayScaleBitmap();
        Bitmap EdgeDetectionBitmap();
    }
}
