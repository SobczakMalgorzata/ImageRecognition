using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition.ObjectDetectionLibrary
{
    public class ImageInstance : IImageInstance
    {
        private IColorImageMatrix imageMatrix;
        private IGrayScaleMatrix grayScaleMatrix;

        public ImageInstance()
        {

        }

        public ImageInstance(Bitmap mat)
        {
            imageMatrix = new ColorImageMatrix(mat);
            grayScaleMatrix = new GrayScaleMatrix(mat);
        }

        public Bitmap GetColorBitmap()
        {
            return imageMatrix.GetBitmap();
        }

        public Bitmap GetGrayScaleBitmap()
        {
            return grayScaleMatrix.GetBitmap();
        }

        public Bitmap EdgeDetectionBitmap()
        {
            Bitmap temp = imageMatrix.EdgeDetection();
            return temp;
        }
    }
}
