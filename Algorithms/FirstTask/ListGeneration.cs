using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.FirstTask
{
    public class ListGeneration
    {
        public static int[] Generation(int n)
        {
            int[] arr = new int[2];
            while (arr.Length < n)
                arr = new int[arr.Length * 2];
            arr[n - 1] = n;
            return arr;
        }
    }
}
