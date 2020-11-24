using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Median_cut
{
    public class Control
    {
        public static List<Color> run(Image image)
        {
            var allPixelColors = new List<Color>();

            Bitmap picture = new Bitmap(image);
            var red = 0;
            var green = 0;
            var blue = 0;

            for (int i = 0; i < picture.Width; i++)
            {
                for (int j = 0; j < picture.Height; j++)
                {
                    var color = picture.GetPixel(i, j);
                    allPixelColors.Add(color);
                    red += color.R;
                    green += color.G;
                    blue += color.B;
                }
            }

            //Console.WriteLine(allPixelColors.Count);
            //Console.WriteLine(picture.Width+" "+ picture.Height);
            //Console.WriteLine($"R: {red}, G: {green}, B{blue}");
            Range range;
            //allPixelColors = allPixelColors.OrderBy(o => o.R).ToList();
            Bucket bucket;

            if (red > green && red > blue)
            {
                Console.WriteLine("red");
                range = new Range();
                bucket = new Bucket(1, range);

            }
            else if (green > red && green > blue)
            {
                Console.WriteLine("green");
                range = new Range();
                bucket = new Bucket(1, range);

            }
            else
            {
                Console.WriteLine("blue");
                range = new Range();
                bucket = new Bucket(1, range);

            }
            range.allPixelColors = allPixelColors;

            var colors = bucket.run();
            Console.WriteLine("show: ");
            bucket.show();

            Console.WriteLine(colors.Count);
           
            return colors;
        }
    }
}
