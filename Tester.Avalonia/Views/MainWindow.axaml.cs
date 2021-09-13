using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Tester.Avalonia.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private Field Field { get; set; }
        private Point StartPoint { get; set; }

        private void Center_Click(object sender, RoutedEventArgs e)
        {
            Field.X1 = -canvas.Width / 2;
            Field.Y1 = -canvas.Height / 2;
            Field.Draw(InfoWorker);
        }

        private void Field_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StartPoint = Mouse.GetPosition(this);
        }

        private void Field_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var moveChange = Mouse.GetPosition(this) - StartPoint;
                Field.X1 -= moveChange.X;
                Field.Y1 -= moveChange.Y;
                if (InfoWorker != null) { Field.Draw(InfoWorker); }
                StartPoint = Mouse.GetPosition(this);
            }
            SetLblCoords();
        }

        private void SetLblCoords()
        {
            lblCoords.Content =
                $"X: {Math.Round((Field.X1 + Mouse.GetPosition(canvas).X) / Field.OneCmScale, 2)} " +
                $"Y: {Math.Round(-(Field.Y1 + Mouse.GetPosition(canvas).Y) / Field.OneCmScale, 2)}";
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            canvas.Width = this.ActualWidth;
            canvas.Height = this.ActualHeight - (Row1.ActualHeight + Row2.ActualHeight + Row3.ActualHeight);
            if (InfoWorker != null) { Field.Draw(InfoWorker); }
        }

        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (InfoWorker != null)
            {
                double startX = (Field.X1 + canvas.Width / 2) / Field.Scale;
                double startY = (Field.Y1 + canvas.Height / 2) / Field.Scale;
                if (e.Delta > 0)
                    Field.Scale += 5;
                else if (Field.Scale > 40)
                    Field.Scale -= 5;
                Field.X1 = startX * Field.Scale - canvas.Width / 2;
                Field.Y1 = startY * Field.Scale - canvas.Height / 2;
                Field.Draw(InfoWorker);
            }
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Field.FunctionPointsVisible = (bool)functionPointsVisible.IsChecked;
            Field.AxisPointsVisible = (bool)axisPointsVisible.IsChecked;
            Field.GridVisible = (bool)gridVisible.IsChecked;
            Field.AxisEllipsesVisible = (bool)axisEllipsesVisible.IsChecked;
            if (InfoWorker != null) { Field.Draw(InfoWorker); }
        }
        private void SetScale_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double scale = double.Parse(tbScale.Text);
                if (scale <= 400 && scale >= 40)
                {
                    Field.Scale = double.Parse(tbScale.Text);
                    if (InfoWorker != null) { Field.Draw(InfoWorker); }
                }
                else
                    MessageBox.Show("Максимальный масштаб - 400%, минимальный - 40%");
            }
            catch
            {
                MessageBox.Show("Ошибка при выставлении масштаба");
            }
        }
        private void ShowDataGrid_Click(object sender, RoutedEventArgs e)
        {
            Table table = new Table(InfoWorker);
            table.Show();
        }
    }
}
