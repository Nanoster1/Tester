using Algorithms.SecondTask;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Models
{
	public class Matrix : IEnumerable<int[]>
	{
		private Point _mesure;
		private int[][] _values;
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
		public int[] GetRows(int num)
		{
			int[] row = new int[Count.X];
			for (int j = 0; j < Count.X; j++)
			{
				row[j] = _values[j][num];
			}
			return row;
		}
		public static Matrix RandomGenerate(int columnSize, int rowSize)
		{
			Matrix matrix = new(columnSize,rowSize);
			for (int i = 0; i < matrix.Count.X; i++)
			{
				matrix[i] = Vector.RandomGenerate(rowSize).ToArray();
			}
			return matrix;
		}
		public static Matrix operator *(Matrix matrix1, Matrix matrix2)
		{
			return new Matrix(MatrixAlgorithm.MullMatrix(matrix1.ToArray(),matrix2.ToArray()));
		}

		public Point Count => _mesure;

		public int[] this[int index]
		{
			get => _values[index].ToArray();
			set => _values[index] = value;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _values.GetEnumerator();
		}
		public IEnumerator<int[]> GetEnumerator()
		{
			return ((IEnumerable<int[]>)_values).GetEnumerator();
		}
	}
}
