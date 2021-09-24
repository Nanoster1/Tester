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
    class SierpinskiTriangleAlt
    {
        public SierpinskiTriangleAlt(Canvas canvas)
        {
            Canvas = canvas;
        }
        private Canvas Canvas { get; set; }
        public double Widht { get => Scale * 4; }
        public int Scale { get; set; } = 100;
        public void DrawTriangle(Point center)
        {
            var polygon = new Polygon()
            {
                Points = GetPointsForTriangle(center),
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Canvas.Children.Add(polygon);
        }
        public Points GetPointsForTriangle(Point center, int depth = 5, int iteration = 1)
        {
            if (iteration == depth + 1) return new();
            double length;
            if (iteration > 1)
                length = Scale * 4 / (Math.Pow(3, (iteration - 1)));
            else
                length = Scale * 4;

            Points points = new()
            {
                new(center.X - length / 2, center.Y + length / 3),//left
                new(center.X, center.Y - length / 3 * 2),//top
                new(center.X + length / 2, center.Y + length / 3),//right
                new(center.X - length / 2, center.Y + length / 3),//left
            };

            Points centers = new()
            {
                new(center.X - length / 6, center.Y - 1d / 9 * length),
                new(center.X, center.Y - 4d / 9 * length),
                new(center.X + length / 6, center.Y - 1d / 9 * length),
                new(center.X + 2d / 6 * length, center.Y + 2d / 9 * length),
                new(center.X, center.Y + 2d / 9 * length),
                new(center.X - 2d / 6 * length, center.Y + 2d / 9 * length),
            };

            foreach (var newCenter in centers)
            {
                points.AddRange(GetPointsForTriangle(newCenter, depth, iteration + 1));
            }

            return points;
        }
    }
}
