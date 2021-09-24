using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.Meta.Models
{
	public static class MatrixExstention
	{
		public static Matrix ToMatrix(this int[][] enumerable)
		{
			return new Matrix(enumerable);
		}
	}
}
