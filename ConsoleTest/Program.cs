using Algorithms.FirstTask;
using Algorithms.SecondTask;
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
            var matrixFunc = (Func<int[][], int[][], int[][]>)MatrixAlgorithm.MullMatrix;
            var matrixA = new int[2][];
            for (int i = 0; i < matrixA.Length; i++)
            {
                matrixA[i] = new int[] { 1, 2 };
            }
            var matrixB = new int[2][];
            for (int i = 0; i < matrixA.Length; i++)
            {
                matrixB[i] = new int[] { 2, 1 };
            }
            var newMAtrix = matrixFunc.Invoke((matrixA), (matrixB));
            var result = new int[2][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new int[] { 6, 3 };
            }
            newMAtrix.ToArray();

        }
    }
}
