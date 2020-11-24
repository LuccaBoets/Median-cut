using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json;

namespace Median_cut
{
    public class Program
    {
        static void Main(string[] args)
        {
            Image image = Image.FromFile("..\\..\\..\\..\\testR.jpg");
            //Image image = Image.FromFile("..\\..\\..\\..\\testG.jpg");
            //Image image = Image.FromFile("..\\..\\..\\..\\testB.png");
            //Image image = Image.FromFile("..\\..\\..\\..\\testYB.jpg");
            //Image image = Image.FromFile("..\\..\\..\\..\\testBR.jpg");
            Control.run(image);
        }
    }
}
