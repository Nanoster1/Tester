using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask.FirstTask
{
    class Levenshtein
    {
        public static int LevenshteinDistance(string first, string second)
        {
            var opt = new int[first.Length + 1, second.Length + 1];
            for (var i = 0; i <= first.Length; ++i) opt[i, 0] = i;
            for (var i = 0; i <= second.Length; ++i) opt[0, i] = i;
            for (var i = 1; i <= first.Length; ++i)
                for (var j = 1; j <= second.Length; ++j)
                {
                    if (first[i - 1] == second[j - 1])
                        opt[i, j] = opt[i - 1, j - 1];
                    else
                        opt[i, j] = (new int[] { 1 + opt[i - 1, j], 1 + opt[i - 1, j - 1], 1 + opt[i, j - 1] }).Min();
                }
            return opt[first.Length, second.Length];
        }
    }
}
