using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Avalonia.Models
{
    public class SierpinskiTriangle
    {
        public SierpinskiTriangle(Canvas canvas)
        {
            Canvas = canvas;
        }
        private Canvas Canvas { get; set; }
        public double Widht { get => Scale * 4; }
        public int Scale { get; set; } = 100;
        public void DrawTriangle(Point center, int depth = 5, int iteration = 1)
        {
            if (iteration == depth + 1) return;

            double length = 
                iteration > 1 ? Scale * 4 / (Math.Pow(3, (iteration - 1))) : Scale * 4;

            Points points = new() 
            {
                new(center.X - length / 2, center.Y + length / 3),
                new(center.X + length / 2, center.Y + length / 3),
                new(center.X, center.Y - length / 3 * 2)
            };

            if (iteration == 5)
            {
                Canvas.Children.Add(new Polygon()
                {
                    Points = points,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    Fill = Brushes.Black
                });
            }

            Points centers = new() 
            {
                new(center.X, center.Y - 4d / 9 * length),
                new(center.X - length / 6, center.Y - 1d / 9 * length),
                new(center.X + length / 6, center.Y - 1d / 9 * length),
                new(center.X - 2d / 6 * length, center.Y + 2d / 9 * length),
                new(center.X, center.Y + 2d / 9 * length),
                new(center.X + 2d / 6 * length, center.Y + 2d / 9 * length)
            };

            foreach(var newCenter in centers)
            {
                DrawTriangle(newCenter, depth, iteration + 1);
            }
        }
    }
}
