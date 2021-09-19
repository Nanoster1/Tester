using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Media;
using System;
using Tester.Avalonia.Views;

namespace Tester.Avalonia
{
    public enum Axis { AX, AY }
    public class VisualPoint
    {
        public Point Point { get; private set; }
        public Axis Axis { get; private set; }
        public IField Field { get; private set; }
        public VisualPoint(double x, double y, IField field)
        {
            Point = new Point(x, y);
            Field = field;
        }
        public Ellipse GetEllipse(ISolidColorBrush brush)
        {
            double x = Point.X / Field.OneCmScale;
            double y = -Point.Y / Field.OneCmScale;
            if (y == -0) { y = 0; }
            Ellipse ellipse = new()
            {
                Width = Field.EllipseScale,
                Height = Field.EllipseScale,
                Stroke = Brushes.Black,
                Fill = brush
            };
            ToolTip.SetTip(ellipse, $"X:{x * Field.CmInOne} Y:{y * Field.CmInOne}");
            ToolTip.SetIsTemplateFocusTarget(ellipse, true);
            ellipse.PointerEnter += MouseEnterEllipse;
            ellipse.PointerLeave += MouseLeaveEllipse;
            Canvas.SetLeft(ellipse, Point.X - Field.X1 - Field.EllipseScale / 2);
            Canvas.SetTop(ellipse, Point.Y - Field.Y1 - Field.EllipseScale / 2);
            return ellipse;
        }
        private void MouseEnterEllipse(object sender, PointerEventArgs e)
        {
            var ellipse = ((Ellipse)sender);
            ellipse.Width = Field.EllipseScale * 2;
            ellipse.Height = Field.EllipseScale * 2;
            Canvas.SetLeft(ellipse, Point.X - Field.X1 - Field.EllipseScale);
            Canvas.SetTop(ellipse, Point.Y - Field.Y1 - Field.EllipseScale);
        }
        private void MouseLeaveEllipse(object sender, PointerEventArgs e)
        {
            var ellipse = ((Ellipse)sender);
            ellipse.Width = Field.EllipseScale;
            ellipse.Height = Field.EllipseScale;
            Canvas.SetLeft(ellipse, Point.X - Field.X1 - Field.EllipseScale / 2);
            Canvas.SetTop(ellipse, Point.Y - Field.Y1 - Field.EllipseScale / 2);
        }
        public Point GetPointForFunction()
        {
            var X = Point.X - Field.X1;
            var Y = Point.Y - Field.Y1;
            return new(X, Y);
        }
        public Label GetVisualNumber(double number)
        {
            Label num = new() { FontSize = Field.FontScale };
            num.Content = Convert.ToInt32(number) * Field.CmInOne;
            Canvas.SetLeft(num, Point.X - Field.X1 - 1);
            Canvas.SetTop(num, Point.Y - Field.Y1 - 1);
            return num;
        }
    }
}