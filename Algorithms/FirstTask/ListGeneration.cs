using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask
{
    public static class ListGeneration
    {
        public static IEnumerable<int> GetIndexes(int[] array, int count)
        {
            for (int i = 0; i < array.Length; i *= count)
            {
                if (i * count >= array.Length)
                    yield return array.Length;
                yield return array[i * count];
            }
        }
    }
}