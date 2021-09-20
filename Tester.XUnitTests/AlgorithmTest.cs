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
        public void BaseAlgorithmTest()
		{
            TestVectorAlgorithm(x => BaseAlgorithm.Calculate(x),nameof(BaseAlgorithm),5);
        }
        [Fact]
        public void SumAlgorithmTest()
        {
            TestVectorAlgorithm(x => Sum.Calculate(x), nameof(Sum), 5);
        }
        [Fact]
        public void MulAlgorithmTest()
        {
            TestVectorAlgorithm(x => Mul.Calculate(x), nameof(Mul), 5);
        }
        [Fact]
        public void PolynomAlgorithmTest()
        {
            TestVectorAlgorithm(x => Polynom.Calculate(x,10.57f), nameof(Polynom), 5);
        }
        [Fact]
        public void BubleSortAlgorithmTest()
        {
            TestVectorAlgorithm(x => VectorSorts.BubbleSort(x), nameof(VectorSorts.BubbleSort), 5);
        }
        [Fact]
        public void InsertionSortAlgorithmTest()
        {
            TestVectorAlgorithm(x => VectorSorts.InsertionSort(x), nameof(VectorSorts.InsertionSort), 5);
        }
        [Fact]
        public void QuickSortAlgorithmTest()
        {
            TestVectorAlgorithm(x => VectorSorts.QuickSort(x), nameof(VectorSorts.QuickSort), 5);         
        }
        [Fact]
        public void TimSortAlgorithmTest()
        {
            TestVectorAlgorithm(x => VectorSorts.TimSort(x), nameof(VectorSorts.TimSort), 5);
        }
        [Fact]
        public void PowCycleTest()
        {
            TestPowAlgorithm(x => Pow.Cycle(10.12,x), nameof(Pow.Cycle), 5);
        }
        [Fact]
        public void QuickPowTest()
        {
            TestPowAlgorithm(x => Pow.QuickPow(10.12, x), nameof(Pow.QuickPow), 5);
        }
        [Fact]
        public void PowRecursionTest()
        {
            TestPowAlgorithm(x => Pow.Recursion(10.12, x), nameof(Pow.Recursion), 5);
        }
        [Fact]
        public void QuickPowAltTest()
        {
            TestPowAlgorithm(x => Pow.QuickPowAlt(10.12, x), nameof(Pow.QuickPowAlt), 5);
        }
        private static void TestVectorAlgorithm(Func<double[],object> function,string name , int interationCount)
		{
            ITester<long> tester = new MemoryTester();
            ITester<double> tester2 = new TimeTester();
            for (int i = 0; i < 2000; i++)
            {
                var vector = Vector.RandomGenerate(i).Select(x => Convert.ToDouble(x)).ToArray();
                tester.Test(() => function.Invoke(vector), interationCount, name);
                tester2.Test(() => function.Invoke(vector), interationCount, name);
            }
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(MemoryTester));
            tester.AllResults.Clear();
            tester2.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(TimeTester));
            tester2.AllResults.Clear();
        }
        private static void TestPowAlgorithm(Func<int, object> function, string name, int interationCount)
		{
            ITester<long> tester = new MemoryTester();
            ITester<double> tester2 = new TimeTester();
            for (int i = 0; i < 2000; i++)
            {
                tester.Test(() => function.Invoke(i), interationCount, name);
                tester2.Test(() => function.Invoke(i), interationCount, name);
            }
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(MemoryTester));
            tester.AllResults.Clear();
            tester2.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(TimeTester));
            tester2.AllResults.Clear();
        }
    }
    
}
