using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Tester.Avalonia.Models;

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
            Canvas canvas = this.FindControl<Canvas>("Canvas"); 
            SierpinskiTriangle triangle = new(canvas);
            SierpinskiTriangleAlt triangleAlt = new(canvas);
            triangle.DrawTriangle(new(triangle.Widht, triangle.Widht));
            triangleAlt.DrawTriangle(new(triangle.Widht * 3, triangle.Widht));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
