
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Models
{
	public record MatrixElement<T>
	{
		public MatrixElement(int row,int column,T element)
		{
			Element = element;
			Row = row;
			Column = column;
		}
		public T Element { get; init; }
		public int Row { get; init; }
		public int Column { get; init; }
	}

	public class Matrix<TResult> : ICollection<MatrixElement<TResult>>, 
		IEnumerable<MatrixElement<TResult>>, 
		IEnumerable, IList<MatrixElement<TResult>>, 
		IReadOnlyCollection<MatrixElement<TResult>>, 
		IReadOnlyList<MatrixElement<TResult>>, 
		ICollection, IList
		where TResult : struct 
	{
		public int RowLenght { get; private set; }
		public int ColumnLenght { get; private set; }
		private MatrixElement<TResult>[] _values;
		public Matrix(int columnSize, int rowSize)
		{
			CreateMatrix(new Point(columnSize, rowSize));
		}
		public Matrix(Point size)
		{
			CreateMatrix(size);
		}
		public Matrix(IEnumerable<int[]> enumerable)
		{
			_values = enumerable.ToArray();
			_mesure = new Point(enumerable.Count(),enumerable.First().Length);
		}
		private void CreateMatrix(Point size)
		{
			if (size.X < 1) size.X = 1;
			_mesure = size;
			_values = new int[size.X][];
			for (int i = 0; i < size.X; i++)
			{
				_values[i] = new int[size.Y];
			}
		}
		public TResult[] GetColumn(int num)
		{
			TResult[] column = new TResult[ColumnLenght];
			var index = 0;
			foreach (var item in _values)
			{
				if (item.Column == num)
				{
					column[index] = item.Element;
					index++;
				}
					
			}
			return column;
		}
		public TResult[] GetRow(int num)
		{
			if (num < 1)
				throw new IndexOutOfRangeException("You are Gay");

			TResult[] row = new TResult[RowLenght];
			int start = (num-1) * RowLenght;
			for (int i = start; i < start + RowLenght; i++)
			{
				row[i - start] = _values[i].Element;
			}			
			return row;
		}
		public static Matrix<int> RandomGenerate(int columnSize, int rowSize)
		{
			var matrix = new Matrix<int>(columnSize, rowSize);
			for (int i = 0; i < matrix.Count.X; i++)
			{
				matrix = Vector.RandomGenerate(rowSize*columnSize).ToArray().ToMa;
			}
			return matrix;
		}
		//public static Matrix operator *(Matrix matrix1, Matrix matrix2)
		//{
		//	return new Matrix(MatrixAlgorithm.MullMatrix(matrix1.ToArray(),matrix2.ToArray()));
		//}

		public Point Count => _mesure;

		public int[,] this[int index]
		{
			get => _values[index].ToArray();
			set => _values[index] = value;
		}
	}
}
