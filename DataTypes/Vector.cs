using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.DataTypes
{
	public class Vector: IEnumerable<int>
	{
		private int _mesure;
		private int[] _values;

		public Vector(int size)
		{
			if (size < 1) size = 1;
			_mesure = size;
			_values = new int[_mesure];
		}

		public Vector(IEnumerable<int> enumerable)
        {
			_values = enumerable.ToArray();
			_mesure = _values.Length;
        }

		public int Count => _values.Length;

		public int this[int index]
        {
			get => _values[index];
			set => _values[index] = value;
        }

		public static Vector operator ^(Vector vector1, Vector vector2)
        {
			return vector1.Concat(vector2).ToVector();
        }

		public static double[] RandomGenerate(int measure)
        {
			Random random = new();
			var vector = new double[measure];
			for (int i = 0; i < vector.Length; i++)
            {
				vector[i] = random.Next();
            }
			return vector;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)_values).GetEnumerator();
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _values.GetEnumerator();
        }
    }
}
