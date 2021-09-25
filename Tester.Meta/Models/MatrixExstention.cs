using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Models
{
	public static class MatrixExstention
	{
		public static Matrix<T> ToMatrix<T>(this IEnumerable<T> enumerable) where T :struct
		{
			return new Matrix<T>(enumerable);
		}
	}
}
