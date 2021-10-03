using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester.DataTypes
{
    public static class VectorExtensions
    {
        public static Vector ToVector(this IEnumerable<int> enumerable)
        {
            return new Vector(enumerable);
        }
    }
}
