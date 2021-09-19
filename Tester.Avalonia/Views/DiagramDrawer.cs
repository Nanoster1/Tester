using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Avalonia.Views
{
    public class DiagramDrawer
    {
        private Canvas Canvas { get; set; }
        private List<Points> Functions { get; set; }
        private double OffsetY { get; set; }
        private double OffsetX { get; set; }
        private double MaxX { get; set; }
        private double MaxY { get; set; }
        private Point CanvasAxes { get; set; }
        public DiagramDrawer(Canvas canvas, List<Points> functions)
        {
            Canvas = canvas;
            Functions = functions;
            OffsetY = 10;
            OffsetX = 10;
            MaxX = Functions.SelectMany(func => func).Max(point => point.X);
            MaxY = Functions.SelectMany(func => func).Max(point => point.Y);
            CanvasAxes = new(Canvas.Width - OffsetX, Canvas.Height - OffsetY);
        }
        public void DrawAll()
        {
            DrawAxes();
            DrawPoints();
            foreach(var func in Functions)
                AddFunction(func);
        }
        private void DrawAxes()
        {
            var AX = new Line()
            {
                StartPoint = new(OffsetX, Canvas.Height - OffsetY),
                EndPoint = new(Canvas.Width, Canvas.Height - OffsetY),
                Stroke = Brushes.Black
            };
            var AY = new Line()
            {
                StartPoint = new(OffsetX, 0),
                EndPoint = new(OffsetX, Canvas.Height - OffsetY),
                Stroke = Brushes.Black
            };
            Canvas.Children.Add(AX);
            Canvas.Children.Add(AY);
        }
        private void DrawPoints()
        {
            var distanceX = CanvasAxes.X / 4;
            var distanceY = CanvasAxes.Y / 4;
            DrawVisualPoint(0, Axis.AX, distanceX, 0);
            for (int i = 1; i < 4; i++)
            {
                var lineX = new Line()
                {
                    StartPoint = new(OffsetX + i * distanceX, Canvas.Height - OffsetY - 10),
                    EndPoint = new(OffsetX + i * distanceX, Canvas.Height - OffsetY + 10),
                    Stroke = Brushes.Black
                };
                var lineY = new Line()
                {
                    StartPoint = new(OffsetX - 10, i * distanceY - OffsetY),
                    EndPoint = new(OffsetX + 10, i * distanceY - OffsetY),
                    Stroke = Brushes.Black
                };
                DrawVisualPoint(MaxX / 4 * i, Axis.AX, distanceX, i);
                DrawVisualPoint(MaxY / 4 * i, Axis.AY, distanceY, i);
                
                Canvas.Children.Add(lineX);
                Canvas.Children.Add(lineY);
            }
        }
        private void DrawVisualPoint(double num, Axis axis, double distance, double index)
        {
            Label number = new() { Content = num };
            if (axis == Axis.AX)
            {
                Canvas.SetLeft(number, OffsetX + index * distance - number.FontSize * number.Content.ToString().Length / 2);
                Canvas.SetTop(number, Canvas.Height - OffsetY + 12);
            }
            else
            {
                Canvas.SetLeft(number, OffsetX - 12 - number.FontSize * number.Content.ToString().Length);
                Canvas.SetTop(number, CanvasAxes.Y - index * distance - number.FontSize * 2);
            }
            Canvas.Children.Add(number);
        }
        public void AddFunction(Points coordinates)
        {
            var functionPoints = new Points() { new(0,0) };
            for (int i = 0; i < coordinates.Count; i++)
            {
                var x = coordinates[i].X / MaxX * CanvasAxes.X;
                var y = Canvas.Height - coordinates[i].Y / MaxY * CanvasAxes.Y;
                var point = new Point(x, y);
                functionPoints.Add(point);
            }
            Polyline function = new() { Points = functionPoints, Stroke = Brushes.Black };
            Canvas.SetLeft(function, OffsetX);
            Canvas.SetTop(function, -OffsetY);
            Canvas.Children.Add(function);
        }
    }
}
