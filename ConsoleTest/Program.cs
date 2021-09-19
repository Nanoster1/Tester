using Algorithms.FirstTask;
using System;
using System.Linq;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;
using Tester.Meta.Testers;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ITester<double> tester = new TimeTester();
            double x = 10.53;
            for (int i = 1; i <= 2000; i++)
            {
                var vector = Vector.RandomGenerate(i).Select(x => Convert.ToDouble(x)).ToArray();

                tester.Test(() => BaseAlgortithm.Calculate(vector), 5, nameof(BaseAlgortithm));
                tester.Test(() => Sum.Calculate(vector), 5, nameof(Sum));
                tester.Test(() => Mov.Calculate(vector), 5, nameof(Mov));
                tester.Test(() => Polynom.Calculate(vector), 5, nameof(Polynom));
            }
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TimeTester");
            tester.AllResults.Clear();

            for (int i = 1; i <= 2000; i++)
            {
                var vector = Vector.RandomGenerate(i).Select(x => Convert.ToDouble(x)).ToArray();

                tester.Test(() => VectorSorts.BubbleSort(vector), 5, nameof(VectorSorts.BubbleSort));
                tester.Test(() => VectorSorts.InsertionSort(vector), 5, nameof(VectorSorts.InsertionSort));
                tester.Test(() => VectorSorts.QuickSort(vector), 5, nameof(VectorSorts.QuickSort));
                tester.Test(() => TimSort.Sort(vector), 5, nameof(TimSort));
            }
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TimeTester");
            tester.AllResults.Clear();

            for (int i = 1; i <= 2000; i++)
            {
                tester.Test(() => Pow.Cycle(x, i), 5, nameof(Pow.Cycle));
                tester.Test(() => Pow.Recursion(x, i), 5, nameof(Pow.Recursion));
                tester.Test(() => Pow.QuickPow(x, i), 5, nameof(Pow.QuickPow));
                tester.Test(() => Pow.QuickPowAlt(x, i), 5, nameof(Pow.QuickPowAlt));
            }

            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TimeTester");
        }
    }
}
