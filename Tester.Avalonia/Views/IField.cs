using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tester.Avalonia.ViewModels;

namespace Tester.Avalonia.Views
{
    public interface IField
    {
        double X1 { get; }
        double Y1 { get; }
        double X2 { get { return X1 + Canvas.Width; } }
        double Y2 { get { return Y1 + Canvas.Height; } }
        double Scale { get; set; }
        double CmInOne { get; set; }
        double EllipseScale { get { return Scale * 0.10; } }
        double OneCmScale { get { return Scale * 0.8; } }
        double FontScale { get { return Scale * 0.2; } }
        bool FunctionPointsVisible { get; set; }
        bool AxisPointsVisible { get; set; }
        bool GridVisible { get; set; }
        bool AxisEllipsesVisible { get; set; }

        Canvas Canvas { get; }
        InfiniteDrawer Drawer { get; }
        Point StartPoint { get; }
        bool IsPressed { get; }
    }
}
