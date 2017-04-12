using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition.ImageObject
{
    public class ImageObject
    {
        /// <summary>
        /// Class Properties
        /// </summary>
        int HorizontalCenterPosition { get; set; }
        int HorizontalLeftPosition { get; set; }
        int HorizontalRightPosition { get; set; }

        int VerticalCenterPosition { get; set; }
        int VerticalBottomPosition { get; set; }
        int VerticalTopPosition { get; set; }

        int[] HorizontalAligment { get; set; }
        int[] VerticalAligment { get; set; }

        string Shape { get; set; }
        List<ImageObject> WithinObjects { get; set; }
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public ImageObject()
        {
            HorizontalCenterPosition = Constants.UNKNOWN;
            VerticalCenterPosition = Constants.UNKNOWN;
            Shape = Constants.NOTRRECOGNISED;
            WithinObjects = new List<ImageObject>();
        }

        public ImageObject(bool[,] objectMatrix)
        {
            HorizontalAligment = new int[objectMatrix.GetLength(0)];
            VerticalAligment = new int[objectMatrix.GetLength(1)];

            for (int i = 0; i < objectMatrix.GetLength(1); i++)
            {
                VerticalAligment[i] = 0;
            }
            for (int i = 0; i < objectMatrix.GetLength(0); i++)
            {
                HorizontalAligment[i] = 0;
            }

            for (int i = 0; i < objectMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < objectMatrix.GetLength(1); j++)
                {
                    if (objectMatrix[i,j])
                    {
                        HorizontalAligment[i]++;
                        VerticalAligment[j]++;
                    }
                }
            }

            for (int i = 1; i < objectMatrix.GetLength(1); i++)
            {
                if (VerticalAligment[i - 1] == 0 && VerticalAligment[i]>0)
                    VerticalTopPosition = i;
                if (VerticalAligment[i + 1] == 0 && VerticalAligment[i] > 0)
                    VerticalBottomPosition = i;
            }

            if (VerticalTopPosition == Constants.UNKNOWN)
                VerticalTopPosition = 0;
            if (VerticalBottomPosition == Constants.UNKNOWN)
                VerticalBottomPosition = objectMatrix.GetLength(1) - 1;

            for (int i = 0; i < objectMatrix.GetLength(0); i++)
            {
                if (HorizontalAligment[i - 1] == 0 && HorizontalAligment[i] > 0)
                    HorizontalLeftPosition = i;
                if (HorizontalAligment[i + 1] == 0 && HorizontalAligment[i] > 0)
                    HorizontalRightPosition = i;
            }

            if (HorizontalLeftPosition == Constants.UNKNOWN)
                HorizontalLeftPosition = 0;
            if (HorizontalRightPosition == Constants.UNKNOWN)
                HorizontalRightPosition = objectMatrix.GetLength(1) - 1;
        
            HorizontalCenterPosition = HorizontalLeftPosition + ((HorizontalRightPosition - HorizontalLeftPosition) / 2);
            VerticalCenterPosition = VerticalTopPosition + ((VerticalBottomPosition - VerticalTopPosition) / 2);

            Shape = Constants.NOTRRECOGNISED;
            WithinObjects = new List<ImageObject>();
        }

        /// <summary>
        /// Method returning information about horizontal position of other object
        /// with comparison to position of active image object
        /// </summary>
        /// <param name="o">Compared Image Object</param>
        /// <returns>Position</returns>
        public bool OtherObjectWithin(ImageObject o)
        {
            if (HorizontalLeftPosition > o.HorizontalLeftPosition &&
                HorizontalRightPosition < o.HorizontalRightPosition &&
                VerticalTopPosition < o.VerticalTopPosition &&
                VerticalBottomPosition > o.VerticalBottomPosition)
            {
                return true;
            }
            
            else
                return false;
        }

        /// <summary>
        /// Method returning information about horizontal position of other object
        /// with comparison to position of active image object
        /// </summary>
        /// <param name="o">Compared Image Object</param>
        /// <returns>Position</returns>
        public string OtherObjectHorizontalPosition(ImageObject o)
        {
            if (HorizontalCenterPosition < o.HorizontalCenterPosition)
            {
                return Constants.RIGHT;
            }
            else if (HorizontalCenterPosition > o.HorizontalCenterPosition)
            {
                return Constants.LEFT;
            }
            else
                return Constants.NOTRRECOGNISED;
        }

        /// <summary>
        /// Method returning information about vertical position of other object
        /// with comparison to position of active image object
        /// </summary>
        /// <param name="o">Compared Image Object</param>
        /// <returns>Position</returns>
        public string OtherObjectVerticalPositiong(ImageObject o)
        {
            if (VerticalCenterPosition < o.VerticalCenterPosition)
            {
                return Constants.BELOW;
            }
            else if (VerticalCenterPosition > o.VerticalCenterPosition)
            {
                return Constants.ABOVE;
            }
            else
                return Constants.NOTRRECOGNISED;
        }
    }
}
