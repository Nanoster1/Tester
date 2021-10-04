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
            var tester = new MemoryTester();

            /*for (int i = 2; i < 3002; i++)
            {
                var vector2 = Enumerable.Range(1, i).ToArray();
                tester.Test(() => Pow.Cycle(4.23, i), 5, nameof(Pow.Cycle));
                tester.Test(() => Pow.Recursion(4.23, i), 5, nameof(Pow.Recursion));
                tester.Test(() => Pow.QuickPow(4.23, i), 5, nameof(Pow.QuickPow));
                tester.Test(() => Pow.QuickPowAlt(4.23, i), 5, nameof(Pow.QuickPowAlt));
                tester.Test(() => BinarySearch.Search(vector2, i), 5, nameof(BinarySearch.Search));
                
                tester.Test(() => ListGeneration.Generation(i), 5, nameof(ListGeneration.Generation));
            }*/

            for (int i = 1; i < 301; i++)
            {
                var vector3 = Enumerable.Range(0, i * i).Select(x => (double)x).ToArray();
                var matrix1 = new Matrix(vector3, i, i);
                tester.Test(() => matrix1.Determinant(), 5, "MatrixDeterminant");
                
            }
            tester.SaveAsExcel(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MemoryTester");
        }
    }
}
