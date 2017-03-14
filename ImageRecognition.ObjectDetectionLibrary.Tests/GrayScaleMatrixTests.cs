﻿using System;
using System.Linq;
using System.Drawing;
using Xunit;

namespace ImageRecognition.ObjectDetectionLibrary.Tests
{
    public class GrayScaleMatrixTests
    {
        [Fact]
        public void GSTypeTest()
        {
            Bitmap b = (Bitmap)Image.FromFile(@"F:\OneDrive\Dokumenty\Visual Studio 2017\Projects\ImageRecognition\TestBitmaps\bitmap_01.bmp", true);
            var m = new GrayScaleMatrix(b);
            Assert.IsType<GrayScaleMatrix>(m);
        }

        [Fact]
        public void GSTest()
        {
            IGrayScaleMatrix m;
            Bitmap b = (Bitmap)Image.FromFile(@"F:\OneDrive\Dokumenty\Visual Studio 2017\Projects\ImageRecognition\TestBitmaps\bitmap_01.bmp", true);
            m = new GrayScaleMatrix(b);
            //Bitmap temp = m.GetBitmap;
            Assert.Equal(m.imageMatrix[3, 0], 255);
        }

    }
}
