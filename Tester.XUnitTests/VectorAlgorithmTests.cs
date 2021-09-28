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
    public class VectorAlgorithmTests
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
        //[Fact]
        //public void MulAlgorithmTest()
        //{
        //    BigTestVectorAlgorithm(x => Mul.Calculate(x), nameof(Mul), 5);
        //}
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
            SaveResult(tester, tester2);
        }            
        public static void SaveResult(ITester<long> tester, ITester<double> tester2)
		{
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(MemoryTester));
            tester.AllResults.Clear();
            tester2.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nameof(TimeTester));
            tester2.AllResults.Clear();
        }
        
    }
    
}
