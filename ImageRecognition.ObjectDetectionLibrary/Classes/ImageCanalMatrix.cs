using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition.ObjectDetectionLibrary
{
    public class ImageCanalMatrix : IImageCanalMatrix
    {
        public int[,] imageMatrix { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public ImageCanalMatrix()
        {
            imageMatrix = new int[1, 1] { { -1} };
            Width = 0;
            Height = 0;
        }

        public ImageCanalMatrix(int[,] i)
        {
            imageMatrix = i;
            Width = i.GetLength(0);
            Height = i.GetLength(1);
        }

        public Bitmap EdgeDetection()
        {
            int[,] imgMatrix;
            List<int[,]> sobelMatrices = new List<int[,]> { new int[3, 3]{ { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } },
                                                    new int[3, 3]{ { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } },
                                                    new int[3, 3]{ { 2, 1, 0 }, { 1, 0, -1 }, { 0, -1, -2 } },
                                                    new int[3, 3]{ { -2, -1, 0 }, { -1, 0, 1 }, { 2, 1, 0 } },
                                                    new int[3, 3]{ { 0, 1, 2 }, { -1, 0, 1 }, { -2, -1, 0 } },
                                                    new int[3, 3]{ { 0, -1, -2 }, { 1, 0, -1 }, { 2, 1, 0 } },
                                                    new int[3, 3]{ { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } },
                                                    new int[3, 3]{ { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } }};
            
            imgMatrix = new int[Width, Height];
            for (int j = 0; j < Width; j++)
            {
                for (int k = 0; k < Height; k++)
                {
                    imgMatrix[j, k] = 255;
                }
            }
            for (int i=0; i<sobelMatrices.Count; i++)
            {
                int[,] imgPartialMatrix = Convolution(sobelMatrices[i], 1, 0);
                for (int j = 0; j < Width; j++)
                {
                    for (int k = 0; k < Height; k++)
                    {
                        if (imgPartialMatrix[j, k] > 225)
                            imgMatrix[j, k] = 0;
                    }
                }
            }

            Bitmap temp = new Bitmap(Width, Height);
            for (int i = 0; i < Width; i++)
            {

                for (int j = 0; j < Height; j++)
                {
                    Color c = System.Drawing.Color.FromArgb(imgMatrix[i, j], imgMatrix[i, j], imgMatrix[i, j]);
                    temp.SetPixel(i, j, c);
                }
            }
            return temp;
        }

        public int[,] GetEdges()
        {
            int[,] imgMatrix;
            List<int[,]> sobelMatrices = new List<int[,]> { new int[3, 3]{ { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } },
                                                    new int[3, 3]{ { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } },
                                                    new int[3, 3]{ { 2, 1, 0 }, { 1, 0, -1 }, { 0, -1, -2 } },
                                                    new int[3, 3]{ { -2, -1, 0 }, { -1, 0, 1 }, { 2, 1, 0 } },
                                                    new int[3, 3]{ { 0, 1, 2 }, { -1, 0, 1 }, { -2, -1, 0 } },
                                                    new int[3, 3]{ { 0, -1, -2 }, { 1, 0, -1 }, { 2, 1, 0 } },
                                                    new int[3, 3]{ { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } },
                                                    new int[3, 3]{ { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } }};
            
            imgMatrix = new int[Width, Height];
            for (int j = 0; j < Width; j++)
            {
                for (int k = 0; k < Height; k++)
                {
                    imgMatrix[j, k] = 255;
                }
            }
            for (int i = 0; i < sobelMatrices.Count; i++)
            {
                int[,] imgPartialMatrix = Convolution(sobelMatrices[i], 1, 0);
                for (int j = 0; j < Width; j++)
                {
                    for (int k = 0; k < Height; k++)
                    {
                        if (imgPartialMatrix[j, k] > 225)
                            imgMatrix[j, k] = 0;
                    }
                }
            }
            
            return imgMatrix;
        }

        public int[,] Convolution(int[,] f, int d, int offset)
        {
            int[,] tmp = new int[Width,Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    int a0 = 0;
                    for (int k = -1; k <= 1; k++)
                    {
                        for (int l = -1; l <= 1; l++)
                        {

                            if (i == 0 && k == -1 && j == 0 && l == -1)
                            {
                                a0 += (f[k + 1, l + 1] * imageMatrix[i + 1 + k, j + 1 + l]);
                            }
                            else if (i == 0 && k == -1 && j == Height - 1 && l == 1)
                            {
                                a0 += (f[k + 1, l + 1] * imageMatrix[i + 1 + k, j - 1 + l]);
                            }
                            else if (i == Width - 1 && k == 1 && j == 0 && l == -1)
                            {
                                a0 += (f[k + 1, l + 1] * imageMatrix[i - 1 + k, j + 1 + l]);
                            }
                            else if (i == Width - 1 && k == 1 && j == Height - 1 && l == 1)
                            {
                                a0 += (f[k + 1, l + 1] * imageMatrix[i - 1 + k, j - 1 + l]);
                            }
                            else if (i == 0 && k == -1)
                            {
                                a0 += (f[k + 1, l + 1] * imageMatrix[i + 1 + k, j + l]);
                            }
                            else if (j == 0 && l == -1)
                            {
                                a0 += (f[k + 1, l + 1] * imageMatrix[i + k, j + 1 + l]);
                            }
                            else if (i == Width - 1 && k == 1)
                            {
                                a0 += (f[k + 1, l + 1] * imageMatrix[i - 1 + k, j + l]);
                            }
                            else if (j == Height - 1 && l == 1)
                            {
                                a0 += (f[k + 1, l + 1] * imageMatrix[i + k, j - 1 + l]);
                            }
                            else
                            {
                                a0 += (f[k + 1, l + 1] * imageMatrix[i + k, j + l]);
                            }
                        }
                    }
                    if (((a0 / d) + offset) < 0)
                        tmp[i, j] = 0;
                    else if (((a0 / d) + offset) > 255)
                        tmp[i, j] = 255;
                    else
                        tmp[i, j] = ((a0 / d) + offset);
                }
            }
            return tmp;
        }
    }
}
