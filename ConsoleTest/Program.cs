using Algorithms.FirstTask;
using System;
using System.Diagnostics;
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
            Stopwatch timer = new();
            var matrix4 = new int[,] { { 1, 2, 3 }, { 1, 2, 3 } };
            var matrix5 = new int[,] { { 2, 1 }, { 2, 1 }, { 2, 1 } };
            var matrix6 = MatrixMul.MulMatrix(matrix4, matrix5);
            var source = new double[]{1, 2, 3, 1, 2, 3};
            var matrix = new Matrix(source, 3, 2);
            var row = matrix.GetRow(1);
            var column = matrix.GetColumn(1);
            var source2 = new double[]{2, 1, 2, 1, 2, 1};
            var matrix2 = new Matrix(source2, 2, 3);
            var matrix3 = matrix * matrix2;
            timer.Restart();
            var m = matrix3.ToArray();
            timer.Stop();
            var i = timer.Elapsed;
        }
    }
}
