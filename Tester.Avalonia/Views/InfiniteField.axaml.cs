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
    public partial class InfiniteField : ReactiveUserControl<ReactiveObject>, IField
    {
        public double X1 { get; private set; }
        public double Y1 { get; private set; }
        public double Scale { get; set; } = 100;
        public double CmInOne { get; set; } = 1;
        public bool FunctionPointsVisible { get; set; } = true;
        public bool AxisPointsVisible { get; set; } = true;
        public bool GridVisible { get; set; } = true;
        public bool AxisEllipsesVisible { get; set; } = true;
        public InfiniteDrawer Drawer { get; private set; }
        public Point StartPoint { get; private set; }
        public bool IsPressed { get; private set; } = false;
        public Canvas Canvas { get; private set; }

        public InfiniteField()
        {
            InitializeComponent();
            this.WhenActivated(disposables =>
            {
                Canvas = this.FindControl<Canvas>("Canvas");
                Drawer = new(this);
                bool isFirstDrawing = true;

                this.WhenAny(view => view.Bounds.Width, view => view.Bounds.Height, (width, heigh) => (width, heigh))
                    .Throttle(TimeSpan.FromMilliseconds(200))
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(tuple =>
                    {
                        Canvas.Width = tuple.width.Value;
                        Canvas.Height = tuple.heigh.Value;
                        if (isFirstDrawing)
                        {
                            X1 = -Canvas.Width / 2;
                            Y1 = -Canvas.Height / 2;
                            isFirstDrawing = false;
                        }
                        Drawer.DrawGrid();
                    })
                    .DisposeWith(disposables);
            });
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void Field_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            StartPoint = e.GetCurrentPoint(Canvas).Position;
            IsPressed = true;
        }

        private void Field_PointerMoved(object? sender, PointerEventArgs e)
        {
            if (!IsPressed) return;
            var moveChange = e.GetCurrentPoint(Canvas).Position - StartPoint;
            X1 -= moveChange.X;
            Y1 -= moveChange.Y;
            Drawer.DrawGrid();
            StartPoint = e.GetCurrentPoint(Canvas).Position;
        }

        private void Field_PointerReleased(object? sender, PointerReleasedEventArgs e)
        {
            IsPressed = false;
        }

        private void Field_PointerWheelChanged(object? sender, PointerWheelEventArgs e)
        {
            double startX = (X1 + Bounds.Width / 2) / Scale;
            double startY = (Y1 + Bounds.Height / 2) / Scale;
            if (e.Delta.Y > 0)
                Scale += 5;
            else if (Scale > 40)
                Scale -= 5;
            X1 = startX * Scale - Canvas.Width / 2;
            Y1 = startY * Scale - Canvas.Height / 2;
            Drawer.DrawGrid();
        }
    }
}
