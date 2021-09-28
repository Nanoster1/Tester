using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask
{
    public static class MatrixMul
    {
        public static double[,] MulMatrix(double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(1)) throw new Exception();
            var finalMatrix = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
            Enumerable.Range(0, matrix1.GetLength(0)).AsParallel()
                .ForAll(i =>
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        var result = 0d;
                        for (int k = 0; k < matrix1.GetLength(1); k++)
                        {
                            result += matrix1[i, k] * matrix2[k, j];
                        }
                        finalMatrix[i, j] = result;
                    }
                });
            return finalMatrix;
        }
    }
}
