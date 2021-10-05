using Algorithms.FirstTask;
using System;
using System.Diagnostics;
using System.Linq;
using Algorithms.FirstTask.FirstTask;
using Tester.DataTypes;
using Tester.Meta.Interfaces;
using Tester.Meta.Testers;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var tester = new MemoryTester();
            
            /*for (int i = 2; i < 10002; i++)
            {
                var vector2 = Enumerable.Range(1, i).ToArray();
                var vector = Vector.RandomGenerate(i);
                
                tester.Test(() => Polynom.Calculate(vector, 10.4f), 5, nameof(Polynom));
                tester.Test(() => VectorSorts.InsertionSort(vector), 5, nameof(VectorSorts.InsertionSort));
                tester.Test(() => VectorSorts.QuickSort(vector), 5, nameof(VectorSorts.QuickSort));
                tester.Test(() => VectorSorts.TimSort(vector), 5, nameof(VectorSorts.TimSort));
                tester.Test(() => MergeSort.Sort(vector), 5, nameof(MergeSort));
                
                tester.Test(() => Pow.Cycle(4.23, i), 5, "PowCycle");
                tester.Test(() => Pow.Recursion(4.23, i), 5, "PowRecursion");
                tester.Test(() => Pow.QuickPow(4.23, i), 5, "PowQuick");
                tester.Test(() => Pow.QuickPowAlt(4.23, i), 5, "PowQuickAlt");
                tester.Test(() => BinarySearch.Search(vector2, i), 5, nameof(BinarySearch));
                tester.Test(() => ListGeneration.Generation(i), 5, nameof(ListGeneration.Generation));
            }
            */

            for (int i = 1; i < 30; i++)
            {
                tester.Test(() => Fibonacci.FibRec(i), 5, "FibonacciRec");
                /*var vector3 = Enumerable.Range(0, i * i).Select(x => (double)x).ToArray();
                var matrix1 = new Matrix(vector3, i, i);
                var matrix2 = new Matrix(vector3, i, i);
                var matrix3 = matrix1.To2DArray();
                var matrix4 = matrix1.To2DArray();
                tester.Test(() => { var a = matrix1 * matrix2; }, 5, "MatrixOperator");
                tester.Test(() => MatrixMul.MulMatrix(matrix3, matrix4), 5, "MatrixMul");
                tester.Test(() => matrix1.Determinant(), 5, "MatrixDeterminant");*/
            }
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MemoryTester");
        }
    }
}
