using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition.ObjectDetectionLibrary
{
    public interface IImageCanalMatrix
    {
        int[,] imageMatrix { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        int[,] GetEdges();
    }
}
