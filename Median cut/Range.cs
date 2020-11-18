using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Median_cut
{
    class Range
    {
        public int colorIndex { get; set; }

        public List<Color> allPixelColors { get; set; }

        public Range(int colorIndex)
        {
            this.allPixelColors = new List<Color>();
            this.colorIndex = colorIndex;
        }

        public List<Range> divideRange()
        {
            var ranges = new List<Range>();

            var red = 0;
            var green = 0;
            var blue = 0;

            foreach (var color in allPixelColors)
            {
                red += color.R;
                green += color.G;
                blue += color.B;
            }
            if (red > green && red > blue)
            {
                Console.WriteLine("red");
                colorIndex = 0;
            }
            else if (green > red && green > blue)
            {
                Console.WriteLine("green");
                colorIndex = 1;
            }
            else
            {
                Console.WriteLine("blue");
                colorIndex = 2;
            }

            allPixelColors = allPixelColors.OrderBy(o => getColor(o)).ToList();

            ranges.Add(new Range(colorIndex)); 
            ranges.Add(new Range(colorIndex));

            return ranges;
        }

        //public bool InRange(int number)
        //{
        //    if (number1 <= number && number2 >= number)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public int getColor(Color color)
        {
            if (colorIndex == 0)
            {
                return color.R;
            }
            else if (colorIndex == 1)
            {
                return color.G;
            }
            else if (colorIndex == 2)
            {
                return color.B;
            }
            else
            {
                throw new Exception("Wrong index");
            }
        }
    }
}
