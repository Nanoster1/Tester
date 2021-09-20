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
			if (columnSize < 1) columnSize = 1;
			_mesure = new Point(columnSize, rowSize);
			_values = new Vector[columnSize];
			for (int i = 0; i < columnSize; i++)
			{
				_values[i] = new Vector(rowSize);
			}
		}
		public static Matrix RandomGenerate(int columnSize, int rowSize)
		{
			Matrix matrix = new(columnSize,rowSize);
			for (int i = 0; i < matrix.Count; i++)
			{
				matrix[i] = Vector.RandomGenerate(rowSize).ToArray();
			}
			return matrix;
		}

		public int Count => _values.Length;

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
