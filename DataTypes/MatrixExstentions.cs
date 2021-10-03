using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Printing;
using System.Linq;

namespace Tester.DataTypes
{
	public static class MatrixExstentions
	{
		public static Matrix ToMatrix(this IEnumerable<double> enumerable, int rowLength, int columnLength)
		{
			return new Matrix(enumerable, rowLength, columnLength);
		}
		public static double[,] To2DArray(this Matrix matrix)
		{
			var array = new double[matrix.ColumnLength, matrix.RowLengtn];
			for (int i = 0; i < matrix.ColumnLength; i++)
			{
				for (int j = 0; j < matrix.RowLengtn; j++)
				{
					array[i, j] = matrix[i, j];
				}
			}
			return array;
		}
		public static double[][] ToJaggedArray(this Matrix matrix)
		{
			var array = new double[matrix.ColumnLength][];
			Enumerable.Range(0, matrix.ColumnLength).AsParallel()
				.ForAll(i =>
				{
					array[i] = matrix.GetRow(i + 1);
				});
			return array;
		}

		public static double Determinant(this Matrix matrix)
		{
			if (matrix.RowLengtn != matrix.ColumnLength)
				throw new ArithmeticException();
			const double eps = 1E-9;
			var n = matrix.RowLengtn;
			var a = matrix.ToJaggedArray();
			var b = new double[1][];
			var det = 1d;
			for (int i = 0; i < n; ++i) 
			{
				var k = i;
				for (int j = i + 1; j < n; ++j)
					if (Math.Abs(matrix[j,i]) > Math.Abs(matrix[k,i]))
						k = j;
				if (Math.Abs(a[k] [i]) < eps) 
				{
					det = 0;
					break;
				}
				b[0] = a[i];
				a[i] = a[k];
				a[k] = b[0];
				if (i != k)
					det = -det;
				det *= a[i][i];
				for (int j=i+1; j<n; ++j)
					a[i][j] /= a[i][i];
				for (int j=0; j<n; ++j)
					if ((j != i)&&(Math.Abs(a[j][i]) > eps))
						for (k = i+1; k < n; ++k)
							a[j][k] -= a[i][k] * a[j][i];
			}
			return det;
		}
	}
}
