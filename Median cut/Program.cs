using System;
using System.Collections.Generic;
using System.Drawing;

namespace Median_cut
{
    class Program
    {
        static void Main(string[] args)
        {
            var allPixelColors = new List<Color>();
            //Image image = Image.FromFile("..\\..\\..\\..\\testR.jpg");
            //Image image = Image.FromFile("..\\..\\..\\..\\testG.jpg");
            Image image = Image.FromFile("..\\..\\..\\..\\testB.png");
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

            if (red > green && red > blue)
            {
                Console.WriteLine("red");
            }
            else if (green > red && green > blue)
            {
                Console.WriteLine("green");
            } 
            else
            {
                Console.WriteLine("blue");
            }
        }
    }
}
