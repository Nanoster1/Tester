using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Printing;

namespace Tester.Meta.Models
{
	public static class MatrixExstentions
	{
		public static Matrix ToMatrix(this IEnumerable<double> enumerable, int rowLength, int columnLength)
		{
			return new Matrix(enumerable, rowLength, columnLength);
		}
		public static double[,] ToArray(this Matrix matrix)
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
	}
}
