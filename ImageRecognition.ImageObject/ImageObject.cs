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
        int VerticalCenterPosition { get; set; }
        string Shape { get; set; }
        List<ImageObject> WithinObjects { get; set; }
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public ImageObject()
        {
            HorizontalCenterPosition = Constants.Unknown;
            VerticalCenterPosition = Constants.Unknown;
            Shape = Constants.NotRecognised;
            WithinObjects = new List<ImageObject>();
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
                return "Right";
            }
            else if (HorizontalCenterPosition > o.HorizontalCenterPosition)
            {
                return "Left";
            }
            else
                return Constants.NotRecognised;
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
                return "Below";
            }
            else if (VerticalCenterPosition > o.VerticalCenterPosition)
            {
                return "Above";
            }
            else
                return Constants.NotRecognised;
        }
    }
}
