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
        private ColorImageMatrix imageMatrix;
        private GrayScaleMatrix grayScaleMatrix;

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
            //Bitmap temp = grayScaleMatrix.EdgeDetection();
            return temp;
        }

        public Bitmap GetSegmentationBitmap()
        {
            return imageMatrix.ColorSegmentation(4);
        }

        public Bitmap GetSegmentationWithEdges()
        {
            return GetBlackAndColorBitmap(imageMatrix.ColorSegmentation(4), imageMatrix.EdgeDetection());
        }

        public Bitmap GetBlackAndColorBitmap(Bitmap color, Bitmap black)
        {
            Bitmap currentBitmap = new Bitmap(imageMatrix.GetWidth(), imageMatrix.GetHeight());
            for (int i = 0; i < imageMatrix.GetWidth(); i++)
            {
                for (int j = 0; j < imageMatrix.GetHeight(); j++)
                {
                    Color c = Color.FromArgb(0, 0, 0);
                    if (black.GetPixel(i, j) != c)
                        c = color.GetPixel(i, j);

                    currentBitmap.SetPixel(i, j, c);
                    
                }
            }
            return currentBitmap;
        }
    }
}
