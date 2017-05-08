using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition.ImageObject
{
    class ImageProcessing
    {
        Tuple<int[], int[]> VerticalAndHorizontalProjection(int[,] mat, int color)
        {
            int[] horizontal = new int[mat.GetLength(0)];
            int[] vertical = new int[mat.GetLength(1)];
            for (int i = 0; i<mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {

                }
            }
            Tuple<int[], int[]> projection = new Tuple<int[], int[]>(horizontal, vertical);
            return projection;
        }
    }
}
