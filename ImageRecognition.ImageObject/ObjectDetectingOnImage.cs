using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageRecognition.ImageObject;
using ImageRecognition.SemanticEngine;

namespace ImageRecognition.ImageObject
{
    public class ObjectDetectingOnImage
    {
        private int[,,] imageMatrix;
        private int[,,] segmentedImageMatrix;
        private int Width { get; set; }
        private int Height { get; set; }
        public int[] colorHistogram { get; set; }
        private List<ImageObject> imageObjects;
        public Bitmap segmentedImage;
        public List<Bitmap> horizontalProjections;
        public List<Bitmap> verticalProjections;

        /// <summary>
        /// Constructor Of Image Object convention changed from previous version for optimalisation reasons.
        /// Dividing operations on Image into different functions and classes was not optimal in our scenario,
        /// because it multiplied number of iterations through image.
        /// </summary>
        /// <param name="mat"></param>

        public ObjectDetectingOnImage(Bitmap mat)
        {
            Width = mat.Width;
            Height = mat.Height;
            imageMatrix = new int[Width, Height, 3];
            segmentedImageMatrix = new int[Width, Height, 3];
            colorHistogram = new int[256];
            List<int[]> colorList = new List<int[]>();
            verticalProjections = new List<Bitmap>();
            horizontalProjections = new List<Bitmap>();
            imageObjects = new List<ImageObject>();
            for (int i = 0; i < 256; i++)
            {
                colorHistogram[i] = 0;
            }
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Color pixel = mat.GetPixel(i, j);
                    int p = pixel.ToArgb();

                    if (pixel != null)
                    {
                        //picture data
                        imageMatrix[i, j, 0] = pixel.R;
                        imageMatrix[i, j, 1] = pixel.G;
                        imageMatrix[i, j, 2] = pixel.B;
                        colorHistogram[pixel.R]++;
                        colorHistogram[pixel.G]++;
                        colorHistogram[pixel.B]++;
                    }
                    int[] currentColor = new int[] { pixel.R, pixel.G, pixel.B};
                    bool contains = true;
                    foreach (int[] o in colorList)
                    {
                        if (o[0]==currentColor[0] && o[1]==currentColor[1] && o[2]==currentColor[2])
                        {
                            contains = false; 
                        }
                    }
                    if(contains)
                    {
                        colorList.Add(currentColor);
                    }
                    segmentedImageMatrix[i, j, 0] = pixel.R;
                    segmentedImageMatrix[i, j, 1] = pixel.G;
                    segmentedImageMatrix[i, j, 2] = pixel.B;
                }
            }

            /// To be implemented here:
            /// Opreations on histogram - creating segmentation + create list of segmented colors
            /// Creating segmented image matrix (using color segmentation from histogram),
            /// use new loop or add to existing one if possible
            int[,] colorArray = new int[colorList.Count(), 3];
            int[,] veticalProjectionsArray = new int[colorList.Count(), Height];
            int[,] horzontalProjectionsArray = new int[colorList.Count(), Width];

            foreach (int[] o in colorList)
            {
                int index = colorList.IndexOf(o);
                colorArray[index, 0] = o[0];
                colorArray[index, 1] = o[1];
                colorArray[index, 2] = o[2];
                for (int i = 0; i < Width; i++)
                {
                    horzontalProjectionsArray[index, i] = 0;
                }
                for (int j = 0; j < Height; j++)
                {
                    veticalProjectionsArray[index, j] = 0;
                }

                horizontalProjections.Add(new Bitmap(Width, Height));
                verticalProjections.Add(new Bitmap(Width, Height));
            }
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    foreach (int[] o in colorList)
                    {
                        if (segmentedImageMatrix[i, j, 0] == o[0] && segmentedImageMatrix[i, j, 1] == o[1] && segmentedImageMatrix[i, j, 2] == o[2])
                        {
                            int index = colorList.IndexOf(o);
                            horzontalProjectionsArray[index, i]++;
                            veticalProjectionsArray[index, j]++;
                        }
                    }
                }
            }

            segmentedImage = new Bitmap(Width, Height);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Color c = Color.FromArgb(segmentedImageMatrix[i,j,0], segmentedImageMatrix[i,j,1], segmentedImageMatrix[i,j,2]);
                    
                    segmentedImage.SetPixel(i, j, c);
                    foreach (int[] o in colorList)
                    {
                        
                        int index = colorList.IndexOf(o);
                        if (horzontalProjectionsArray[index, i] > j)
                        {
                            c = Color.FromArgb(0, 0, 0);
                            horizontalProjections[index].SetPixel(i, j, c);
                        }
                        else
                        {
                            c = Color.FromArgb(255, 255, 255);
                            horizontalProjections[index].SetPixel(i, j, c);
                        }

                        if (veticalProjectionsArray[index, j] > i)
                        {
                            c = Color.FromArgb(0, 0, 0);
                            verticalProjections[index].SetPixel(i, j, c);
                        }
                        else
                        {
                            c = Color.FromArgb(255, 255, 255);
                            verticalProjections[index].SetPixel(i, j, c);
                        }
                        
                    }

                }
            }
            OntologyEngine myOntology = new OntologyEngine();

            int k = 0;
        }
    }
}
