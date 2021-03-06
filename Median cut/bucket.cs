﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Median_cut
{
    class Bucket
    {
        public Bucket child1 { get; set; }
        public Bucket child2 { get; set; }
        public const int MAX_ITERATION = 4;
        public int iteration { get; set; }
        public Range range { get; set; }

        public Bucket(int iteration, Range range)
        {
            this.iteration = iteration;
            this.range = range;
        }

        public List<Color> run()
        {
            if (!checkCondition())
            {
                var ranges = range.divideRange();

                ranges[0].allPixelColors = range.allPixelColors.Take(range.allPixelColors.Count / 2).ToList();
                ranges[1].allPixelColors = range.allPixelColors.Skip(range.allPixelColors.Count / 2).ToList();

                child1 = new Bucket(iteration + 1, ranges[0]);
                var child1Color = child1.run();
                child2 = new Bucket(iteration + 1, ranges[1]);
                var child2Color = child2.run();

                var colors = child1Color.Concat(child2Color).ToList();
                return colors;
            }
            else
            {
                var red = 0;
                var green = 0;
                var blue = 0;
                foreach (var color in range.allPixelColors)
                {
                    red += color.R;
                    green += color.G;
                    blue += color.B;
                }

                if (range.allPixelColors.Count == 0)
                {
                    return new List<Color>();
                }

                var mixedColor = Color.FromArgb(1, red / range.allPixelColors.Count, green / range.allPixelColors.Count, blue / range.allPixelColors.Count);

                //var mixedColor = new Color();

                return new List<Color> { mixedColor };
            }
        }

        public bool checkCondition()
        {
            Console.WriteLine(iteration);

            if (iteration >= MAX_ITERATION || range.allPixelColors.Count == 0)
            {
                return true;
            }

            return false;
        }

        public void show()
        {
            //if (iteration != MAX_ITERATION)
            //{
            //    Console.WriteLine($"{iteration} {range.allPixelColors.Count} {range.colorIndex[0]}");
            //}
            //else
            //{
                Console.WriteLine($"{iteration} {range.allPixelColors.Count}");
            //}

            if (child1 != null)
            {
                child1.show();
                child2.show();
            }
        }
    }
}
