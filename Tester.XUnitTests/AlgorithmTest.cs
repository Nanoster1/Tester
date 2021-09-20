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
        [Theory]
        [MemberData(nameof(GetSortAlgs))]
        public void TestSortAlgorithm(Func<double[],double[]> sortFunc)
		{
            double[] array = { 1.2, 3.6, 1.2, 2.4, 0.2 };
            var newArr = sortFunc.Invoke(array);
            Assert.Equal(newArr, array.OrderBy(x => x));
        }
		public static IEnumerable<object[]> GetSortAlgs()
		{
            yield return new object[] { (Func<double[], double[]>)VectorSorts.BubbleSort };
            yield return new object[] { (Func<double[],double[]>)(x=> VectorSorts.InsertionSort(x,0,0)) };
            yield return new object[] { (Func<double[], double[]>)VectorSorts.QuickSort };
            yield return new object[] { (Func<double[], double[]>)VectorSorts.TimSort };
        }
        [Theory]
        [MemberData(nameof(GetPowAlgs))]
        public void TestPowAlgorithm(Func<double,int,double> sortFunc)
        {
            int rank = 3;
            double num = 1.5;
            var result = sortFunc.Invoke(num,rank);
            Assert.Equal(result, Math.Pow(num,rank));
        }
        public static IEnumerable<object[]> GetPowAlgs()
        {
            yield return new object[] { (Func<double, int, double>)Pow.Cycle };
            yield return new object[] { (Func<double, int, double>)Pow.QuickPow };
            yield return new object[] { (Func<double, int, double>)Pow.QuickPowAlt };
            yield return new object[] { (Func<double, int, double>)Pow.Recursion };
        }
        [Fact]
        public void BaseAlgorithmTest()
		{
            BigTestVectorAlgorithm(x => BaseAlgorithm.Calculate(x),nameof(BaseAlgorithm),5);
        }
        [Fact]
        public void SumAlgorithmTest()
        {
            BigTestVectorAlgorithm(x => Sum.Calculate(x), nameof(Sum), 5);
        }
        [Fact]
        public void MulAlgorithmTest()
        {
            BigTestVectorAlgorithm(x => Mul.Calculate(x), nameof(Mul), 5);
        }
        [Fact]
        public void PolynomAlgorithmTest()
        {
            BigTestVectorAlgorithm(x => Polynom.Calculate(x,10.57f), nameof(Polynom), 5);
        }
        [Fact]
        public void BubleSortAlgorithmTest()
        {
            BigTestVectorAlgorithm(x => VectorSorts.BubbleSort(x), nameof(VectorSorts.BubbleSort), 5);
        }
        [Fact]
        public void InsertionSortAlgorithmTest()
        {
            BigTestVectorAlgorithm(x => VectorSorts.InsertionSort(x), nameof(VectorSorts.InsertionSort), 5);
        }
        [Fact]
        public void QuickSortAlgorithmTest()
        {
            BigTestVectorAlgorithm(x => VectorSorts.QuickSort(x), nameof(VectorSorts.QuickSort), 5);         
        }
        [Fact]
        public void TimSortAlgorithmTest()
        {
            BigTestVectorAlgorithm(x => VectorSorts.TimSort(x), nameof(VectorSorts.TimSort), 5);
        }
        [Fact]
        public void PowCycleTest()
        {
            BigTestPowAlgorithm(x => Pow.Cycle(10.12,x), nameof(Pow.Cycle), 5);
        }
        [Fact]
        public void QuickPowTest()
        {
            BigTestPowAlgorithm(x => Pow.QuickPow(10.12, x), nameof(Pow.QuickPow), 5);
        }
        [Fact]
        public void PowRecursionTest()
        {
            BigTestPowAlgorithm(x => Pow.Recursion(10.12, x), nameof(Pow.Recursion), 5);
        }
        [Fact]
        public void QuickPowAltTest()
        {
            BigTestPowAlgorithm(x => Pow.QuickPowAlt(10.12, x), nameof(Pow.QuickPowAlt), 5);
        }
        private static void BigTestVectorAlgorithm(Func<double[],object> function,string name , int interationCount)
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
        private static void BigTestPowAlgorithm(Func<int, object> function, string name, int interationCount)
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
