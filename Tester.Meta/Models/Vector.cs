using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Models
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

		public int Count => _values.Length;

		public int this[int index]
        {
			get => _values[index];
			set => _values[index] = value;
        }

		public static Vector RandomGenerate(int measure)
        {
			Random random = new();
			Vector vector = new(measure);
			for (int i = 0; i < vector.Count; i++)
            {
				vector[i] = random.Next();
            }
			return vector;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)_values).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _values.GetEnumerator();
        }
    }
}
