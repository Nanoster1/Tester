using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Tester.Avalonia.Views
{
    public partial class DiagramField : ReactiveUserControl<ReactiveObject>
    {
        public DiagramField()
        {
            InitializeComponent();
            var canvas = this.FindControl<Canvas>("Canvas");
            Functions = new() { new() { new(0, 0), new(2, 4), new(54, 8) } };
            Drawer = new(canvas, Functions);
            Drawer.DrawAll();
        }

        private DiagramDrawer Drawer { get; set; }
        public List<Points> Functions { get; set; } 

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        
    }
}
