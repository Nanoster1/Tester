using Algorithms.FirstTask;
using System;
using System.Diagnostics;
using System.Linq;
using Tester.DataTypes;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var tester = new TimeTester();
            for (int i = 1; i < 2001; i++)
            {
                var vector = Vector.RandomGenerate(i);
                tester.Test((() => VectorSorts.BubbleSort(vector)), 5, nameof(VectorSorts.BubbleSort));
            }
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TimeTester");
        }
    }
}
