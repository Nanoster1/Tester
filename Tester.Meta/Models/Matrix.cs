using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Models
{
	public class Matrix : IEnumerable<Vector>
	{
		private Point _mesure;
		private Vector[] _values;
		public Matrix(int columnSize, int rowSize)
		{
			CreateMatrix(new Point(columnSize, rowSize));
		}
		public Matrix(Point size)
		{
			CreateMatrix(size);
		}
		private void CreateMatrix(Point size)
		{
			if (size.X < 1) size.X = 1;
			_mesure = size;
			_values = new Vector[size.X];
			for (int i = 0; i < size.X; i++)
			{
				_values[i] = new Vector(size.Y);
			}
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

		public Point Count => _mesure;

		public int[] this[int index]
		{
			get => _values[index].ToArray();
			set => _values[index] = value.ToVector();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _values.GetEnumerator();
		}

		IEnumerator<Vector> IEnumerable<Vector>.GetEnumerator()
		{
			return ((IEnumerable<Vector>)_values).GetEnumerator();
		}
	}
}
