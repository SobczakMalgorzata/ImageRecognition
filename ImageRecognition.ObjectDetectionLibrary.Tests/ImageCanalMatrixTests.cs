using System;
using System.Drawing;
using System.Linq;
using Xunit;

namespace ImageRecognition.ObjectDetectionLibrary.Tests
{
    public class ImageCanalMatrixTests
    {
        [Fact]
        public void TypeTest()
        {
            IImageCanalMatrix m;
            m = new ImageCanalMatrix(new int[2,2]{ {0,0 },{0,0 } });
            Assert.IsType<ImageCanalMatrix>(m);
        }

        [Fact]
        public void WidthTest()
        {
            IImageCanalMatrix m;
            m = new ImageCanalMatrix(new int[4, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } });
            Assert.Equal(m.Width, 4);
        }

        [Fact]
        public void HeightTest()
        {
            IImageCanalMatrix m;
            m = new ImageCanalMatrix(new int[4, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } });
            Assert.Equal(m.Height, 2);
        }

        [Fact]
        public void matrixSetTest()
        {
            IImageCanalMatrix m;
            m = new ImageCanalMatrix(new int[4, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } });
            m.imageMatrix[2, 1] = 9;
            Assert.Equal(m.imageMatrix[2, 1], 9);
        }

        [Fact]
        public void EmptyCreatorTest()
        {
            IImageCanalMatrix m;
            m = new ImageCanalMatrix();
            Assert.Equal(m.imageMatrix[0, 0], -1);
        }

        [Fact]
        public void EmptyCreatorWidthTest()
        {
            IImageCanalMatrix m;
            m = new ImageCanalMatrix();
            Assert.Equal(m.Width, 0);
        }

        [Fact]
        public void EmptyCreatorHeightTest()
        {
            IImageCanalMatrix m;
            m = new ImageCanalMatrix();
            Assert.Equal(m.Height, 0);
        }

        
    }
}
