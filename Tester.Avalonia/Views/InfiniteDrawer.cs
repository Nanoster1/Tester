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
    public class InfiniteDrawer
    {
        private IField _field;

        public InfiniteDrawer(IField field)
        {
            _field = field;
        }

        public void DrawGrid()
        {
            _field.Canvas.Children.Clear();
            DrawRightY();
            DrawLeftY();
            DrawBotX();
            DrawUpX();
        }

        public void DrawRightY()
        {
            for (double i = 0; i < _field.X2; i += _field.OneCmScale) //для правых y
            {
                if (i > _field.X1)
                    AddYLine(i);
            }
        }

        public void DrawLeftY()
        {
            for (double i = 0; i > _field.X1; i -= _field.OneCmScale) //для левых y
            {
                if (i < _field.X2)
                    AddYLine(i);
            }
        }

        public void DrawBotX()
        {
            for (double i = 0; i < _field.Y2; i += _field.OneCmScale) //для нижних x
            {
                if (i > _field.Y1)
                    AddXLine(i);
            }
        }

        public void DrawUpX()
        {
            for (double i = 0; i > _field.Y1; i -= _field.OneCmScale) //для верхних x
            {
                if (i < _field.Y2)
                    AddXLine(i);
            }
        }

        private void AddYLine(double i)
        {
            _field.Canvas.Children.Add(GetLine(i, Axis.AY));
            var vpoint = new VisualPoint(i, 0, _field);
            if (0 > _field.Y1 && 0 < _field.Y2)
            {
                if (_field.AxisEllipsesVisible)
                    _field.Canvas.Children.Add(vpoint.GetEllipse(Brushes.Black));
                if (_field.AxisPointsVisible)
                    _field.Canvas.Children.Add(vpoint.GetVisualNumber(i / _field.OneCmScale));
            }
        }

        private void AddXLine(double i)
        {
            _field.Canvas.Children.Add(GetLine(i, Axis.AX));
            var vpoint = new VisualPoint(0, i, _field);
            if (0 > _field.X1 && 0 < _field.X2)
            {
                if (_field.AxisEllipsesVisible)
                    _field.Canvas.Children.Add(vpoint.GetEllipse(Brushes.Black));
                if (_field.AxisPointsVisible)
                    if (i != 0) { _field.Canvas.Children.Add(vpoint.GetVisualNumber(-i / _field.OneCmScale)); }
            }
        }

        private Line GetLine(double i, Axis axis)
        {
            Line line = new();
            if (i == 0)
            {
                line.Stroke = Brushes.Black;
            }
                
            else if (_field.GridVisible)
            {
                line.Stroke = Brushes.Gray;
                line.Opacity = 0.7;
            }
                
            if (axis == Axis.AY)
            {
                line.StartPoint = new(i - _field.X1, 0);
                line.EndPoint = new(i - _field.X1, _field.Canvas.Height);
            }
            else
            {
                line.StartPoint = new(0, i - _field.Y1);
                line.EndPoint = new(_field.Canvas.Width, i - _field.Y1);
            }
            return line;
        }

        public void AddFunction(List<Point> coordinates)
        {
            var functionPoints = new List<Point>();
            for (int i = coordinates.Count - 1; i >= 0; i--)
            {
                if (СheckBorder(coordinates[i].X, coordinates[i].Y))
                {
                    if (!CheckOnlyXBorder(coordinates[i].X) && i != 0) //Если x выходит за границы, то мы обрываем проверку ост. x
                        break;
                    VisualPoint vpoint = new(coordinates[i].X * _field.OneCmScale, -coordinates[i].Y * _field.OneCmScale, _field);
                    functionPoints.Add(vpoint.GetPointForFunction());
                    if (_field.FunctionPointsVisible)
                    {
                        Ellipse ellipse = vpoint.GetEllipse(Brushes.Red);
                        _field.Canvas.Children.Add(ellipse);
                    }
                }
            }
            Polyline function = new() { Points = functionPoints, Stroke = Brushes.Black };
            _field.Canvas.Children.Add(function);
        }

        private bool СheckBorder(double x, double y)
        {
            if (x * _field.OneCmScale > _field.X1 &&
                x * _field.OneCmScale < _field.X2 &&
               -y * _field.OneCmScale > _field.Y1 &&
               -y * _field.OneCmScale < _field.Y2)
                return true;
            else
                return false;
        }

        private bool CheckOnlyXBorder(double x)
        {
            if (x * _field.OneCmScale > _field.X1 &&
                x * _field.OneCmScale < _field.X2)
                return true;
            else
                return false;
        }
    }
}
