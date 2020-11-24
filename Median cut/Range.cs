using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Median_cut
{
    class Range
    {
        public List<ColorIndex> colorIndex { get; set; }

        public List<Color> allPixelColors { get; set; }

        public Range()
        {
            this.allPixelColors = new List<Color>();
            this.colorIndex = new List<ColorIndex>();
        }

        public enum ColorIndex
        {
            R,
            G,
            B
        }


        public List<Range> divideRange()
        {
            var ranges = new List<Range>();

            Dictionary<ColorIndex, int> colorValuesFromPixels =
                new Dictionary<ColorIndex, int>();

            colorValuesFromPixels.Add(ColorIndex.R, 0);
            colorValuesFromPixels.Add(ColorIndex.G, 0);
            colorValuesFromPixels.Add(ColorIndex.B, 0);

            foreach (var color in allPixelColors)
            {
                colorValuesFromPixels[ColorIndex.R] += color.R;
                colorValuesFromPixels[ColorIndex.G] += color.G;
                colorValuesFromPixels[ColorIndex.B] += color.B;
            }

            colorValuesFromPixels = colorValuesFromPixels.OrderByDescending(o => o.Value).ToDictionary(x => x.Key, x => x.Value);

            colorIndex.Add(colorValuesFromPixels.ElementAt(0).Key);
            colorIndex.Add(colorValuesFromPixels.ElementAt(1).Key);
            colorIndex.Add(colorValuesFromPixels.ElementAt(2).Key);

            allPixelColors = allPixelColors.OrderBy(o => getColor(o, colorValuesFromPixels.ElementAt(0).Key)).ThenBy(o => getColor(o, colorValuesFromPixels.ElementAt(1).Key)).ThenBy(o => getColor(o, colorValuesFromPixels.ElementAt(2).Key)).ToList();

            ranges.Add(new Range());
            ranges.Add(new Range());

            return ranges;
        }

        public int getColor(Color color, ColorIndex colorIndex)
        {
            if (colorIndex == ColorIndex.R)
            {
                return color.R;
            }
            else if (colorIndex == ColorIndex.G)
            {
                return color.G;
            }
            else if (colorIndex == ColorIndex.B)
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
