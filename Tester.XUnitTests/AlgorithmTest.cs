using Algorithms.FirstTask;
using System;
using System.Collections.Generic;
using System.Linq;
using Tester.Meta.Interfaces;
using Tester.Meta.Models;
using Tester.Meta.Testers;
using Xunit;

namespace Tester.XUnitTests
{
    public class AlgorithmTest
    {
        [Fact]
        public void AlgorithmsTest()
        {
            ITester<long> tester = new MemoryTester();
            var x = 13.53;
            for (int i = 1; i <= 2000; i++)
            {
                var vector = Vector.RandomGenerate(i).Select(x => Convert.ToDouble(x)).ToArray();

                tester.Test(() => BaseAlgortithm.Calculate(vector), 5, nameof(BaseAlgortithm));
                tester.Test(() => Sum.Calculate(vector), 5, nameof(Sum));
                tester.Test(() => Mov.Calculate(vector), 5, nameof(Mov));
                tester.Test(() => Polynom.Calculate(vector), 5, nameof(Polynom));
            }
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MemoryTester");
            tester.AllResults.Clear();

            for (int i = 1; i <= 2000; i++)
            {
                var vector = Vector.RandomGenerate(i).Select(x => Convert.ToDouble(x)).ToArray();

                tester.Test(() => VectorSorts.BubbleSort(vector), 5, nameof(VectorSorts.BubbleSort));
                tester.Test(() => VectorSorts.InsertionSort(vector), 5, nameof(VectorSorts.InsertionSort));
                tester.Test(() => VectorSorts.QuickSort(vector), 5, nameof(VectorSorts.QuickSort));
                tester.Test(() => TimSort.Sort(vector), 5, nameof(TimSort));
            }
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MemoryTester");
            tester.AllResults.Clear();

            for (int i = 1; i <= 2000; i++)
            {
                tester.Test(() => Pow.Cycle(x, i), 5, nameof(Pow.Cycle));
                tester.Test(() => Pow.Recursion(x, i), 5, nameof(Pow.Recursion));
                tester.Test(() => Pow.QuickPow(x, i), 5, nameof(Pow.QuickPow));
                tester.Test(() => Pow.QuickPowAlt(x, i), 5, nameof(Pow.QuickPowAlt));
            }

            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MemoryTester");

            ITester<double> tester2 = new TimeTester();
            for (int i = 1; i <= 2000; i++)
            {
                var vector = Vector.RandomGenerate(i).Select(x => Convert.ToDouble(x)).ToArray();

                tester2.Test(() => BaseAlgortithm.Calculate(vector), 5, nameof(BaseAlgortithm));
                tester2.Test(() => Sum.Calculate(vector), 5, nameof(Sum));
                tester2.Test(() => Mov.Calculate(vector), 5, nameof(Mov));
                tester2.Test(() => Polynom.Calculate(vector), 5, nameof(Polynom));
            }
            tester2.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TimeTester");
            tester2.AllResults.Clear();

            for (int i = 1; i <= 2000; i++)
            {
                var vector = Vector.RandomGenerate(i).Select(x => Convert.ToDouble(x)).ToArray();

                tester2.Test(() => VectorSorts.BubbleSort(vector), 5, nameof(VectorSorts.BubbleSort));
                tester2.Test(() => VectorSorts.InsertionSort(vector), 5, nameof(VectorSorts.InsertionSort));
                tester2.Test(() => VectorSorts.QuickSort(vector), 5, nameof(VectorSorts.QuickSort));
                tester2.Test(() => TimSort.Sort(vector), 5, nameof(TimSort));
            }
            tester2.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TimeTester");
            tester2.AllResults.Clear();

            for (int i = 1; i <= 2000; i++)
            {
                tester2.Test(() => Pow.Cycle(x, i), 5, nameof(Pow.Cycle));
                tester2.Test(() => Pow.Recursion(x, i), 5, nameof(Pow.Recursion));
                tester2.Test(() => Pow.QuickPow(x, i), 5, nameof(Pow.QuickPow));
                tester2.Test(() => Pow.QuickPowAlt(x, i), 5, nameof(Pow.QuickPowAlt));
            }

            tester2.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TimeTester");
        }
    }
}
