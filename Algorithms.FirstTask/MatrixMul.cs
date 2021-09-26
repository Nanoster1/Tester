using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask
{
    public static class MatrixMul
    {
        public static int[,] MulMatrix(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(1)) throw new Exception();
            var finalMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    var result = 0;
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        result += matrix1[i, k] * matrix2[k, j];
                    }
                    finalMatrix[i, j] = result;
                }
            }
            return finalMatrix;
        }
    }
}
